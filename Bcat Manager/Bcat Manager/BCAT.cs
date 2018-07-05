using MessagePack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bcat_Manager
{
    public class BcatJson
    {
        public string topic_id { get; set; }
        public string service_status { get; set; }
        public bool na_required { get; set; }
        public int required_application_version { get; set; }
        public List<DirectoryEntry> directories { get; set; }

        public class DirectoryEntry
        {
            public string name { get; set; }
            public string mode { get; set; }
            public bool by_country_group { get; set; }
            public string digest { get; set; }
            public List<DataEntry> data_list { get; set; }

            public class DataEntry
            {
                public int data_id { get; set; }
                public string filename { get; set; }
                public string url { get; set; }
                public string digest { get; set; }
                public int size { get; set; }
            }
        }

        public BcatJson() { }
        public BcatJson(string json)
        {
            var bcat = JsonConvert.DeserializeObject<BcatJson>(json);

            topic_id = bcat.topic_id;
            service_status = bcat.service_status;
            na_required = bcat.na_required;
            required_application_version = bcat.required_application_version;
            directories = bcat.directories;
        }
        public BcatJson(long titleId, string pass) : this(BCAT.GetBcatJson(titleId, pass))
        {
        }
        public byte[] GetMsgPack()
        {
            return MessagePackSerializer.FromJson(JsonConvert.SerializeObject(this));
        }
    }

    public class BCAT
    {
        //secret keys used by the bcat sysmodule (retail and dev keys are the same)
        private static string[] secretData =
        {
            "a3e20c5c1cd7b720",
            "7f4c637432c8d420",
            "188d087d92a0c087",
            "8e7d23fa7fafe60f",
            "5252ae57c026d3cb",
            "2650f5e53554f01d",
            "b213a1e986307c9f",
            "875d8b01e3df5d7c",
            "c1b9a5ce866e00b1",
            "6a48ae69161e0138",
            "3f7b0401928b1f46",
            "0e9db55903a10f0e",
            "a8914bcbe7b888f9",
            "b15ef3ed6ce0e4cc",
            "f3b9d9f43dedf569",
            "bda4f7a0508c7462",
            "f5dc3586b1b2a8af",
            "7f6828b6f33dd118",
            "860de88547dcbf70",
            "ccbacacb70d11fb5",
            "b1475e5ea18151b9",
            "5f857ca15cf3374c",
            "cfa747c1d09d4f05",
            "30e7d70cb6f98101",
            "c8b3c78772bdcf43",
            "533dfc0702ed9874",
            "a29301cac5219e5c",
            "5776f5bec1b0df06",
            "1d4ab85a07ac4251",
            "7c1bd512b1cf5092",
            "2691cb8b3f76b411",
            "4400abee651c9eb9"
        };
        
        public const string LIST_URL = "https://bcat-list-lp1.cdn.nintendo.net/api/nx/v1/list/";
        private const string BCAT_MAGIC = "bcat";

        public static byte[] GetRawBcat(string url)
        {
            WebClient client = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            try
            {
                return client.DownloadData(url);
            }
            catch
            {
                throw new Exception("Title doesn't have any BCAT data.");
            }
        }
        public static byte[] GetDecBcat(string url, long titleID, string pass)
        {
            return DecryptBCAT(GetRawBcat(url), titleID, pass);
        }
        public static string GetBcatJson(long TitleID, string pass)
        {
            //I prefer dealing with jsons
            try
            {
                return MessagePackSerializer.ToJson(GetDecBcat(LIST_URL + "nx_data_" + TitleID.ToString("x16"), TitleID, pass));
            }
            catch
            {
                throw new Exception("Failed to parse MsgPack !\r\nMake sure the title ID and passphrase are correct.");
            }
        }
        public static byte[] DecryptBCAT(byte[] data, long TitleID, string passStr)
        {
            byte[] dec;
            using (MemoryStream ms = new MemoryStream(data))
            {
                BinaryReader br = new BinaryReader(ms);

                //read the magic
                string magic = Encoding.ASCII.GetString(br.ReadBytes(4));
                if (magic != BCAT_MAGIC)
                    throw new Exception("Invalid bcat header");

                br.BaseStream.Position++; //unknow

                byte crypto = br.ReadByte();
                byte rsaType = br.ReadByte();
                byte secretIndex = br.ReadByte();
                br.BaseStream.Position += 8; //padding

                

                byte[] iv = br.ReadBytes(0x10);
                byte[] rsa = br.ReadBytes(0x100);
                byte[] enc = br.ReadBytes((int)(br.BaseStream.Length - 0x120));

                if (crypto > 3)
                    return enc;

                int kSize = (crypto+1) * 8;

                byte[] salt = Encoding.ASCII.GetBytes(TitleID.ToString("x16") + secretData[secretIndex]);
                byte[] pass = Encoding.ASCII.GetBytes(passStr);
                
                byte[] key = PBKDF2Sha256GetBytes(kSize, pass, salt, 4096);

                dec = AesCrypto.PerformAesCTR(enc, 0, enc.Length, key, iv);

            }
            return dec;

        }
        public static byte[] EncryptBCAT(byte[]data, long TitleID, string passStr, byte HashType, byte crypto, byte[] signature)
        {
            byte[] output;

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);

                Random rnd = new Random();
                byte[] iv = new byte[0x10];
                rnd.NextBytes(iv); //generate random iv
                int secretIndex = rnd.Next(0, secretData.Length - 1); //generate random secret index

                bw.Write(Encoding.ASCII.GetBytes(BCAT_MAGIC));
                bw.Write((byte)1); //must be 1 for some reasons
                bw.Write(crypto);
                bw.Write(HashType);
                bw.Write((byte)secretIndex);
                bw.Write(new byte[8]); //padding
                bw.Write(iv);
                bw.Write(signature);

                if (crypto > 3)
                    bw.Write(data);

                else
                {
                    int kSize = (crypto + 1) * 8;
                    byte[] salt = Encoding.ASCII.GetBytes(TitleID.ToString("x16") + secretData[secretIndex]);
                    byte[] pass = Encoding.ASCII.GetBytes(passStr);
                    byte[] key = PBKDF2Sha256GetBytes(kSize, pass, salt, 4096);
                    bw.Write(AesCrypto.PerformAesCTR(data, 0, data.Length, key, iv));
                }
                output = ms.ToArray();
            }
            return output;
        }


        // code from : https://gist.github.com/peteroupc/6986999
        public static byte[] PBKDF2Sha256GetBytes(int dklen, byte[] password, byte[] salt, int iterationCount)
        {
            using (var hmac = new HMACSHA256(password))
            {
                int hashLength = hmac.HashSize / 8;
                if ((hmac.HashSize & 7) != 0)
                    hashLength++;
                int keyLength = dklen / hashLength;
                if ((long)dklen > (0xFFFFFFFFL * hashLength) || dklen < 0)
                    throw new ArgumentOutOfRangeException("dklen");
                if (dklen % hashLength != 0)
                    keyLength++;
                byte[] extendedkey = new byte[salt.Length + 4];
                Buffer.BlockCopy(salt, 0, extendedkey, 0, salt.Length);


                using (var ms = new MemoryStream())
                {
                    for (int i = 0; i < keyLength; i++)
                    {
                        extendedkey[salt.Length] = (byte)(((i + 1) >> 24) & 0xFF);
                        extendedkey[salt.Length + 1] = (byte)(((i + 1) >> 16) & 0xFF);
                        extendedkey[salt.Length + 2] = (byte)(((i + 1) >> 8) & 0xFF);
                        extendedkey[salt.Length + 3] = (byte)(((i + 1)) & 0xFF);
                        byte[] u = hmac.ComputeHash(extendedkey);
                        Array.Clear(extendedkey, salt.Length, 4);
                        byte[] f = u;
                        for (int j = 1; j < iterationCount; j++)
                        {
                            u = hmac.ComputeHash(u);
                            for (int k = 0; k < f.Length; k++)
                            {
                                f[k] ^= u[k];
                            }
                        }
                        ms.Write(f, 0, f.Length);
                        Array.Clear(u, 0, u.Length);
                        Array.Clear(f, 0, f.Length);
                    }
                    byte[] dk = new byte[dklen];
                    ms.Position = 0;
                    ms.Read(dk, 0, dklen);
                    ms.Position = 0;
                    for (long i = 0; i < ms.Length; i++)
                    {
                        ms.WriteByte(0);
                    }
                    Array.Clear(extendedkey, 0, extendedkey.Length);
                    return dk;
                }
            }
        }
    }
}
