using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Bcat_Manager
{
    public class BcatManagerConfig
    {

        [Serializable]
        public class InvalidConfigFileException : Exception
        {
            public InvalidConfigFileException() { }
            public InvalidConfigFileException(string message) : base(message) { }
            public InvalidConfigFileException(string message, Exception inner) : base(message, inner) { }
            protected InvalidConfigFileException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }

        private const string CONFIG_PATH = "Settings.bin";
        private const string CONFIG_MAGIC = "CNFG";
        private const uint CONFIG_VER = 1;

        private string[] _saltLower;
        private int _langIndex;
        private List<int> _countyIndices = new List<int>();
        private string _deviceID;
        private int _sdkVersion;

        public string[] SaltLower {
            get
            {
                ReadConfig();
                return _saltLower;
            }
            set
            {
                if (_saltLower.Length != 32)
                    throw new InvalidDataException("Invalid SaltLower!");

                foreach (var s in _saltLower)
                {
                    if (!Regex.IsMatch(s, "^[0-9a-f]{16}$"))
                        throw new InvalidDataException("Invalid SaltLower!");
                }

                _saltLower = value;
                SaveConfig();
            }
        }
        public string Lang
        {
            get
            {
                ReadConfig();
                return BCAT.Langs[_langIndex];
            }
            set
            {
                int index = Array.IndexOf(BCAT.Langs, value);
                if (index == -1)
                    throw new InvalidDataException($"Could not find {value}!");

                _langIndex = index;

                SaveConfig();
            }
        }
        public List<string> Countries
        {
            get
            {
                ReadConfig();

                List<string> c = new List<string>();
                foreach (var index in _countyIndices)
                    c.Add(BCAT.Countries[index]);

                return c;
            }
            set
            {
                _countyIndices.Clear();

                foreach (var str in value)
                {
                    int index = Array.IndexOf(BCAT.Countries, str);
                    if (index == -1)
                        throw new InvalidDataException($"Could not find {str}!");
                    _countyIndices.Add(index);
                }

                SaveConfig();
            }
        }
        public string DeviceID
        {
            get
            {
                ReadConfig();
                return _deviceID;
            }
            set
            {
                if (!Utils.IsValidDeviceID(value))
                    throw new InvalidDataException("Invalid Device ID!");
                _deviceID = value;
                SaveConfig();
            }
        }
        public string SDKVersion
        {
            get
            {
                ReadConfig();

                int major = (_sdkVersion >> 24 & 0xFF);
                int minor = (_sdkVersion >> 16 & 0xFF);
                int micro = (_sdkVersion >> 08 & 0xFF);
                int build = (_sdkVersion >> 00 & 0xFF);

                return $"{major}.{minor}.{micro}.{build}";
            }
            set
            {
                if (!Utils.IsValidSdkVersion(value))
                    throw new InvalidDataException("Invalid SDK Version!");
                string[] s = value.Split('.');

                _sdkVersion =
                    byte.Parse(s[0]) << 24 |
                    byte.Parse(s[1]) << 16 |
                    byte.Parse(s[2]) << 08 |
                    byte.Parse(s[3]) << 00;

                SaveConfig();
            }
        }

        public BcatManagerConfig()
        {
            //ReadConfig();
        }

        private void ReadConfig()
        {
            if (!File.Exists(CONFIG_PATH))
                CreateNewConfig();
            else
            {
                try
                {
                    using (var fs = File.OpenRead(CONFIG_PATH))
                        ParseConfig(fs);
                }
                catch (InvalidConfigFileException ex)
                {
                    MessageBox.Show($"{ex.Message}\r\nThe config file will be recreated.");
                    CreateNewConfig();
                }
            }
        }
        private void SaveConfig()
        {
            ExportConfig(CONFIG_PATH);
        }

        public void ImportConfig(string path)
        {
            if (!File.Exists(path))
                MessageBox.Show($"Could not find \"{path}\".");
            else
            {
                try
                {
                    using (var fs = File.OpenRead(path))
                        ParseConfig(fs);
                }
                catch (InvalidConfigFileException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            SaveConfig();
        }
        public void ExportConfig(string path)
        {
            if (File.Exists(path))
                File.Delete(path);

            using (var fs = File.OpenWrite(path))
            {
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(Encoding.ASCII.GetBytes(CONFIG_MAGIC));
                bw.Write(CONFIG_VER);

                //salts
                for (int i = 0; i < _saltLower.Length; i++)
                {
                    bw.Write(Encoding.ASCII.GetBytes(_saltLower[i]));
                }

                //device id
                bw.Write(Encoding.ASCII.GetBytes(_deviceID));

                //sdk version
                bw.Write(_sdkVersion);

                //lang
                bw.Write(_langIndex);

                //countries
                bw.Write(_countyIndices.Count);
                foreach (var item in _countyIndices)
                    bw.Write(item);
            }
        }

        private void UpdateConfig(uint ver)
        {
            //update
        }
        private void ParseConfig(Stream s)
        {
            if (s.Length < 4 + 4 + 512 + 14 + 4 + 4 + 4)//magic + ver + salts + device id + sdk version + lang + country nb
                throw new InvalidConfigFileException("Invalid Config Size!");

            BinaryReader br = new BinaryReader(s);
            string magic = Encoding.ASCII.GetString(br.ReadBytes(4));
            if (magic != CONFIG_MAGIC)
                throw new InvalidConfigFileException("Invalid Config Magic!");

            uint ver = br.ReadUInt32();

            if (ver == 0 || ver > CONFIG_VER)
                throw new InvalidConfigFileException("Invalid Config Version!");

            if (ver < CONFIG_VER)
            {
                UpdateConfig(ver);
                return;
            }

            //salts
            _saltLower = new string[32];
            for (int i = 0; i < _saltLower.Length; i++)
            {
                _saltLower[i] = Encoding.ASCII.GetString(br.ReadBytes(16));

                if (!Regex.IsMatch(_saltLower[i], "^[0-9a-f]{16}$"))
                    throw new InvalidDataException("Invalid SaltLower!");
            }

            //device ID
            _deviceID = Encoding.ASCII.GetString(br.ReadBytes(14));
            if (!Utils.IsValidDeviceID(_deviceID))
                throw new InvalidDataException("Invalid Device ID!");

            //SDK Version
            _sdkVersion = br.ReadInt32();

            //lang
            _langIndex = br.ReadInt32();
            if (_langIndex < 0 || _langIndex >= BCAT.Langs.Length)
                throw new InvalidDataException("Invalid Lang Index!");

            //countries
            int nb = br.ReadInt32();

            if (s.Length != br.BaseStream.Position + nb*4)
                throw new InvalidConfigFileException("Invalid Config Size!");

            _countyIndices.Clear();
            for (int i = 0; i < nb; i++)
            {
                _countyIndices.Add(br.ReadInt32());
                if (_countyIndices[i] < 0 || _countyIndices[i] >= BCAT.Countries.Length)
                    throw new InvalidDataException("Invalid Country Index!");
            }

        }
        private void CreateNewConfig()
        {
            _saltLower = new string[]
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
            _langIndex = Array.IndexOf(BCAT.Langs, "en-US");
            _countyIndices = new List<int>()
            {
                Array.IndexOf(BCAT.Countries, "GB"),
                Array.IndexOf(BCAT.Countries, "JP"),
                Array.IndexOf(BCAT.Countries, "US")
            };
            _deviceID = "XAJ00000000000";
            _sdkVersion = 6 << 24 | 4 << 16; //6.4.0.0
            SaveConfig();
        }
    }
}
