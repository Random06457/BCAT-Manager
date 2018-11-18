using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.BinaryData;
using System.Collections;
using System.Text.RegularExpressions;
using System.Reflection;

namespace Bcat_Manager
{
    public class ObjectOrArrayAttribute : Attribute
    {
        public bool CanBeBoth = false;
        public ObjectOrArrayAttribute(bool b)
        {
            CanBeBoth = b;
        }
    }


    [Serializable]
    public class MsgPackDeserializationException : Exception
    {
        public MsgPackDeserializationException() { }
        public MsgPackDeserializationException(string message) : base(message) { }
        public MsgPackDeserializationException(string message, Exception inner) : base(message, inner) { }
        protected MsgPackDeserializationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public class MsgPack
    {
        public static T Deserialize<T>(string path)
        {
            using (var fs = File.OpenRead(path))
                return Deserialize<T>(fs);
        }
        public static T Deserialize<T>(byte[] data)
        {
            using (var ms = new MemoryStream(data))
                return Deserialize<T>(ms);
        }
        public static T Deserialize<T>(Stream s)
        {
            BinaryDataReader br = new BinaryDataReader(s);
            br.ByteOrder = ByteOrder.BigEndian;

            byte b = br.ReadByte();
            switch (GetElementFormatFamily(b))
            {
                case ElementFormatFamily.array:
                    Type t1 = typeof(T);
                    if (t1.GetGenericTypeDefinition() != typeof(List<>) || t1.GetGenericArguments().Length != 1)
                        throw new MsgPackDeserializationException("Invalid list!");
                    
                    return (T)ProcessArray(t1, b, br);

                case ElementFormatFamily.map:
                    return (T)ProcessMap(typeof(T), b, br);

                case ElementFormatFamily.bin:
                case ElementFormatFamily.nil:
                case ElementFormatFamily.integer:
                case ElementFormatFamily.floating:
                case ElementFormatFamily.str:
                    return (T)GetElementValue(b, br);
                default:
                    throw new MsgPackDeserializationException($"Invalid element : 0x{b:x}");
            }
        }

        private static object ProcessMap(Type t, byte b, BinaryDataReader br)
        {
            var obj = Activator.CreateInstance(t);

            uint len = GetMapSize(b, br);

            for (uint i = 0; i < len; i++)
            {
                byte b1 = br.ReadByte();
                if (GetElementFormatFamily(b1) != ElementFormatFamily.str)
                    throw new MsgPackDeserializationException($"Invalid Element : 0x{b1:x}");

                var v1 = GetElementValue(b1, br);

                //I test poperty names in a loop while I could do obj.GetType().GetProperty((string)v1) because some keys aren't valid c# identifier are (e.g. "new")
                PropertyInfo property = null;
                bool found = false;
                foreach (var p in obj.GetType().GetProperties())
                {
                    if (p.Name == (string)v1 || p.Name.ToLower() == (string)v1)
                    {
                        found = true;
                        property = p;
                    }
                }

                byte b2 = br.ReadByte();
                object v2;
                
#if DEBUG_BCAT
                if (!found)
                    throw new MsgPackDeserializationException($"Could not find \"{v1}\" in {obj.GetType().FullName}\r\nType : {GetElementFormat(b2)}");
                else
#else
                if (found)
#endif
                {
                    switch (GetElementFormatFamily(b2))
                    {
                        case ElementFormatFamily.array:
                            if (property.PropertyType.GetGenericTypeDefinition() != typeof(List<>) || property.PropertyType.GetGenericArguments().Length != 1)
                                throw new MsgPackDeserializationException("Invalid list!");
                            v2 = ProcessArray(property.PropertyType, b2, br);
                            break;
                        case ElementFormatFamily.map:
                            //"body" can be an object as well as an array
                            ObjectOrArrayAttribute attr = (ObjectOrArrayAttribute)property.GetCustomAttribute(typeof(ObjectOrArrayAttribute));
                            if (attr != null && attr.CanBeBoth)
                            {
                                if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>) && property.PropertyType.GetGenericArguments().Length == 1)
                                {
                                    v2 = Activator.CreateInstance(property.PropertyType);
                                    ((IList)v2).Add(ProcessMap(property.PropertyType.GetGenericArguments()[0], b2, br));
                                }
                                else
                                    throw new MsgPackDeserializationException("Invalid List");
                            }
                            else
                                v2 = ProcessMap(property.PropertyType, b2, br);

                            break;
                        case ElementFormatFamily.unsupported:
                            throw new MsgPackDeserializationException($"Invalid Element : 0x{b1:x}");
                        default:
                            v2 = GetElementValue(b2, br);
                            break;
                    }

                    try
                    {
                        property.SetValue(obj, Convert.ChangeType(v2, property.PropertyType));
                    }
                    catch (Exception ex)
                    {
                        throw new MsgPackDeserializationException($"{ex.Message}\r\nInfo : {obj.GetType().FullName}.{(string)v1}", ex);
                    }
                }

            }

            return obj;
        }
        private static object ProcessArray(Type t,byte b, BinaryDataReader br)
        {
            var list = (IList)Activator.CreateInstance(t);

            uint len = GetArraySize(b, br);
            for (uint i = 0; i < len; i++)
            {
                byte b1 = br.ReadByte();
                object v2;

                switch (GetElementFormatFamily(b1))
                {
                    case ElementFormatFamily.map:
                        v2 = ProcessMap(t.GetGenericArguments().First(), b1, br);
                        break;
                    case ElementFormatFamily.unsupported:
                    case ElementFormatFamily.array:
                        throw new MsgPackDeserializationException($"Invalid Element : 0x{b1:x}");
                    default:
                        v2 = GetElementValue(b1, br);
                        break;
                }
                list.Add(v2);
            }

            return list;
        }


        private enum ElementFormat
        {
            fixint_positive = 0,
            fixmap = 0x80,
            fixarray = 0x90,
            fixstr = 0xa0,
            nil = 0xc0,
            unsupported_or_unused = 0xc1,
            bool_false = 0xc2,
            bool_true = 0xc3,
            bin8= 0xc4,
            bin16= 0xc5,
            bin32= 0xc6,
            ext8= 0xc7,
            ext16= 0xc8,
            ext32= 0xc9,
            float32= 0xca,
            float64= 0xcb,
            uint8= 0xcc,
            uint16= 0xcd,
            uint32= 0xce,
            uint64= 0xcf,
            int8= 0xd0,
            int16= 0xd1,
            int32= 0xd2,
            int64= 0xd3,
            fixext1= 0xd4,
            fixext2= 0xd5,
            fixext4= 0xd6,
            fixext8= 0xd7,
            fixext16= 0xd8,
            str8= 0xd9,
            str16= 0xda,
            str32= 0xdb,
            array16= 0xdc,
            array32 = 0xdd,
            map16 = 0xde,
            map32= 0xdf,
            fixint_negative= 0xe0,
        }
        private enum ElementFormatFamily
        {
            integer,
            floating,
            boolean,
            array,
            map,
            nil,
            //ext,
            str,
            bin,
            unsupported,
        }

        private static ElementFormat GetElementFormat(byte b)
        {
            if (b >> 7 == 0) return ElementFormat.fixint_positive;
            if (b >> 4 == 0b1000) return ElementFormat.fixmap;
            if (b >> 4 == 0b1001) return ElementFormat.fixarray;
            if (b >> 5 == 0b101) return ElementFormat.fixstr;

            if (b >= 0xc0 && b <= 0xdf) return (ElementFormat)b;

            if (b >= 0xe0) return ElementFormat.fixint_negative;

            return ElementFormat.unsupported_or_unused;
        }
        private static ElementFormatFamily GetElementFormatFamily(byte b)
        {
            switch (GetElementFormat(b))
            {
                case ElementFormat.nil:
                    return ElementFormatFamily.nil;

                case ElementFormat.bool_false:
                case ElementFormat.bool_true:
                    return ElementFormatFamily.boolean;

                case ElementFormat.bin8:
                case ElementFormat.bin16:
                case ElementFormat.bin32:
                    return ElementFormatFamily.bin;

                case ElementFormat.float32:
                case ElementFormat.float64:
                    return ElementFormatFamily.floating;

                case ElementFormat.fixint_positive:
                case ElementFormat.fixint_negative:
                case ElementFormat.uint8:
                case ElementFormat.uint16:
                case ElementFormat.uint32:
                case ElementFormat.uint64:
                case ElementFormat.int8:
                case ElementFormat.int16:
                case ElementFormat.int32:
                case ElementFormat.int64:
                    return ElementFormatFamily.integer;

                case ElementFormat.str8:
                case ElementFormat.str16:
                case ElementFormat.str32:
                case ElementFormat.fixstr:
                    return ElementFormatFamily.str;

                case ElementFormat.array16:
                case ElementFormat.array32:
                case ElementFormat.fixarray:
                    return ElementFormatFamily.array;

                case ElementFormat.map16:
                case ElementFormat.map32:
                case ElementFormat.fixmap:
                    return ElementFormatFamily.map;

                //no need to support ext (bcta doesn't use that)
                case ElementFormat.ext8:
                case ElementFormat.ext16:
                case ElementFormat.ext32:
                case ElementFormat.fixext1:
                case ElementFormat.fixext2:
                case ElementFormat.fixext4:
                case ElementFormat.fixext8:
                case ElementFormat.fixext16:
                case ElementFormat.unsupported_or_unused:
                default:
                    return ElementFormatFamily.unsupported;
            }
        }

        private static uint GetMapSize(byte b, BinaryDataReader br)
        {
            switch (GetElementFormat(b))
            {
                case ElementFormat.fixmap:
                    return (uint)(b & 0xf);
                case ElementFormat.map16:
                    return br.ReadUInt16();
                case ElementFormat.map32:
                    return br.ReadUInt32();
                default:
                    throw new MsgPackDeserializationException($"Invalid element : 0x{b:x}");
                }
        }
        private static uint GetArraySize(byte b, BinaryDataReader br)
        {
            switch (GetElementFormat(b))
            {
                case ElementFormat.fixarray:
                    return (uint)(b & 0xf);
                case ElementFormat.array16:
                    return br.ReadUInt16();
                case ElementFormat.array32:
                    return br.ReadUInt32();
                default:
                    throw new MsgPackDeserializationException($"Invalid element : 0x{b:x}");
            }
        }
        private static object GetElementValue(byte b, BinaryDataReader br)
        {
            switch (GetElementFormat(b))
            {
                case ElementFormat.fixstr: return Encoding.UTF8.GetString(br.ReadBytes(b & 0x1F));
                case ElementFormat.nil: return null;
                case ElementFormat.bool_false: return false;
                case ElementFormat.bool_true: return true;
                case ElementFormat.bin8: return br.ReadBytes(br.ReadByte());
                case ElementFormat.bin16: return br.ReadBytes(br.ReadUInt16());
                case ElementFormat.bin32: return br.ReadBytes(br.ReadInt32());
                case ElementFormat.float32: return br.ReadSingle();
                case ElementFormat.float64: return br.ReadDouble();
                case ElementFormat.uint8: return br.ReadByte();
                case ElementFormat.uint16: return br.ReadUInt16();
                case ElementFormat.uint32: return br.ReadUInt32();
                case ElementFormat.uint64: return br.ReadUInt64();
                case ElementFormat.int8: return br.ReadSByte();
                case ElementFormat.int16: return br.ReadInt16();
                case ElementFormat.int32: return br.ReadInt32();
                case ElementFormat.int64: return br.ReadInt64();
                case ElementFormat.str8: return Encoding.UTF8.GetString(br.ReadBytes(br.ReadByte()));
                case ElementFormat.str16: return Encoding.UTF8.GetString(br.ReadBytes(br.ReadUInt16()));
                case ElementFormat.str32: return Encoding.UTF8.GetString(br.ReadBytes(br.ReadInt32()));
                case ElementFormat.fixint_negative:
                case ElementFormat.fixint_positive:
                    return (int)(sbyte)b;
                default:
                    throw new MsgPackDeserializationException($"Invalid Element : 0x{b:x}");
            }
        }
    }
}
