using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcat_Manager
{
    public class TitleInfo
    {
        public string Name;
        public long TitleID;
        public string Passphrase;

        public TitleInfo(BinaryReader br)
        {
            int len = br.ReadInt32();
            Name = Encoding.Unicode.GetString(br.ReadBytes(len));
            TitleID = br.ReadInt64();
            Passphrase = Encoding.ASCII.GetString(br.ReadBytes(0x40));
        }
        public TitleInfo(string name, long tid, string pass)
        {
            Name = name;
            TitleID = tid;
            Passphrase = pass;
        }
        public void Write(BinaryWriter bw)
        {
            bw.Write(Encoding.Unicode.GetByteCount(Name));
            bw.Write(Encoding.Unicode.GetBytes(Name));
            bw.Write(TitleID);
            bw.Write(Encoding.ASCII.GetBytes(Passphrase));
        }
    }

    public class TitleDatabase
    {
        private const string PATH = "Database.bin";
        private const ulong MAGIC = 0x3938375F41544144; //ASCII : DATA_789

        private static List<TitleInfo> CreateDataBase()
        {
            List<TitleInfo> database = new List<TitleInfo>();
            SaveDatabase(database);

            return database;
        }
        public static List<TitleInfo> GetDatabase()
        {
            if (!File.Exists(PATH))
                return CreateDataBase();

            List<TitleInfo> database = new List<TitleInfo>();

            try
            {
                using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(PATH)))
                {
                    BinaryReader br = new BinaryReader(ms);
                    ulong magic = br.ReadUInt64();

                    if (magic != MAGIC)
                        return CreateDataBase();

                    int count = br.ReadInt32();

                    for (int i = 0; i < count; i++)
                        database.Add(new TitleInfo(br));

                    return database;
                }
            }
            catch
            {
                return CreateDataBase();
            }
        }
        public static void SaveDatabase(List<TitleInfo> database)
        {
            using (var fs = File.Create(PATH))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(MAGIC);
                bw.Write(database.Count);

                foreach (var title in database)
                    title.Write(bw);
            }
        }
    }
}
