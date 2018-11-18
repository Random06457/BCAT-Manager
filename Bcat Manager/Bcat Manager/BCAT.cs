using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bcat_Manager
{
    //parent class
    public class BcatMsgPack
    {
        public byte[] GetMsgPack()
        {
            throw new NotImplementedException("MsgPack Serialization not supported yet. Wait for the next update.");
            //return MessagePackSerializer.FromJson(JsonConvert.SerializeObject(this));
        }
    }

    public class BcatChannel
    {
        public string topic_id { get; set; }
        public string name { get; set; }
        public string publisher { get; set; }
        public string description { get; set; }
        public ulong publishing_time { get; set; }
        public ulong last_posted_at { get; set; }
        public bool important { get; set; }

        public override bool Equals(object obj)
        {
            var channel = obj as BcatChannel;
            return channel != null &&
                   topic_id == channel.topic_id &&
                   name == channel.name &&
                   publisher == channel.publisher &&
                   description == channel.description &&
                   publishing_time == channel.publishing_time &&
                   last_posted_at == channel.last_posted_at &&
                   important == channel.important;
        }
        public override int GetHashCode()
        {
            var hashCode = -2005109826;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(topic_id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(publisher);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(description);
            hashCode = hashCode * -1521134295 + publishing_time.GetHashCode();
            hashCode = hashCode * -1521134295 + last_posted_at.GetHashCode();
            hashCode = hashCode * -1521134295 + important.GetHashCode();
            return hashCode;
        }
    }

    public class BcatList : BcatMsgPack
    {
        public class DirectoryEntry
        {
            public class DataEntry
            {
                public uint data_id { get; set; }
                public string filename { get; set; }
                public string url { get; set; }
                public string digest { get; set; }
                public uint size { get; set; }
            }

            public string name { get; set; }
            public string mode { get; set; }
            public bool by_country_group { get; set; }
            public string digest { get; set; }
            public List<DataEntry> data_list { get; set; }
        }

        public string topic_id { get; set; }
        public string service_status { get; set; }
        public bool na_required { get; set; }
        public int required_application_version { get; set; }
        public List<DirectoryEntry> directories { get; set; }
    }

    public class BcatNews : BcatMsgPack
    {
        public class DirectoryEntry
        {
            public class DataEntry
            {
                public class DataEntryVersion
                {
                    public int format { get; set; }
                    public int semantics { get; set; }
                }
                public class DataEntryLanguage
                {
                    public string language { get; set; }
                    public uint data_id { get; set; }
                    public string url { get; set; }
                    public uint size { get; set; }
                    public bool overwrite { get; set; }
                }
                public class DataCondition
                {
                    public List<int> serial { get; set; }
                }

                public uint news_id { get; set; }
                public DataEntryVersion version { get; set; }
                public DataCondition conditions { get; set; }
                public string default_language { get; set; }
                public List<DataEntryLanguage> languages { get; set; }
            }

            public string name { get; set; }
            public string mode { get; set; }
            public string digest { get; set; }
            public List<DataEntry> data_list { get; set; }
        }

        public string topic_id { get; set; }
        public string service_status { get; set; }
        public bool na_required { get; set; }
        public bool test_distribution { get; set; }
        public List<DirectoryEntry> directories { get; set; }
    }


    public class NewsData : BcatMsgPack
    {
        public class DataEntryVersion
        {
            public int format { get; set; }
            public int semantics { get; set; }
        }
        public class DataSubject
        {
            public int caption { get; set; }
            public string text { get; set; }
        }
        public class DataFooter
        {
            public string text { get; set; }
        }
        public class DataMore
        {
            public class DataMoreGame
            {
                public List<ulong> application_ids { get; set; }
                public byte[] application_arg { get; set; }
                public string query { get; set; }
                public string text { get; set; }
            }
            public class DataMoreShop
            {
                public string query { get; set; }
                public string text { get; set; }
            }
            public class DataMoreBrowser
            {
                public string text { get; set; }
                public string url { get; set; }
            }

            public DataMoreBrowser browser { get; set; }
            public DataMoreGame game { get; set; }
            public DataMoreShop shop { get; set; }
            /* I've actually never seen this "system_applet" struct but according qlaunch it contains a string (?) value named "type" */
            //public DataMoreSystemApplet system_applet { get; set; }
        }
        public class DataBody
        {
            public string text { get; set; }
            public int main_image_height { get; set; }
            public string movie_url { get; set; }
            public byte[] main_image { get; set; }
        }
        public class DataProduct
        {
            public string query { get; set; }
            public string name { get; set; }
            public byte[] image { get; set; }
            public string content_type { get; set; }
            public string comment { get; set; }
            public string publisher { get; set; }
            public string demo_info { get; set; }
            public string New { get; set; } //capital letter to avoid c# keywords
            public string sale_info { get; set; }
            public string discount_price { get; set; }
            public string pre_purchase { get; set; }
        }
        public class DataChannel
        {
            public string topic_id { get; set; }
            public string topic_name { get; set; }
            public byte[] topic_image { get; set; }
            public string topic_publisher { get; set; }
            public string topic_description { get; set; }
            public int topic_important { get; set; }
        }
        public class DataMovie
        {
            public string movie_url { get; set; }
            public string movie_name { get; set; }
            public byte[] movie_image { get; set; }
        }
        public class DataRatingInfo
        {
            public byte[] rating_icon { get; set; }
            public string contents_descriptors { get; set; }
            public string interactive_elements { get; set; }
        }
        public class DataAgeLimit
        {
            public class AgeLimitRating
            {
                public string name { get; set; }
                public int age { get; set; }
            }

            public List<AgeLimitRating> ratings { get; set; }
        }
        public class DataEssentialPickup
        {
            public uint pickup_limit { get; set; }
            public int priority_after { get; set; }
        }
        public class DataRatingIcon
        {
            public byte[] ESRB { get; set; }
        }
        
        public string topic_id { get; set; }
        public DataEntryVersion version { get; set; }
        public uint news_id { get; set; }
        public uint published_at { get; set; }
        public uint pickup_limit { get; set; }
        public DataEssentialPickup essential_pickup { get; set; }
        public int priority { get; set; }
        public int deletion_priority { get; set; }
        public uint expire_at { get; set; }
        public List<DataRatingIcon> rating_icons { get; set; }
        public string language { get; set; }
        public List<string> supported_languages { get; set; }
        public List<ulong> application_ids { get; set; }
        public string display_type { get; set; }
        public int topic_important { get; set; }
        public int no_photography { get; set; }
        public int surprise { get; set; }
        public int bashotorya { get; set; }
        public int movie { get; set; }
        public int ab_test { get; set; }
        public DataSubject subject { get; set; }
        public string topic_name { get; set; }
        public byte[] topic_image { get; set; }
        public byte[] list_image { get; set; }
        public string topic_publisher { get; set; }
        public string topic_description { get; set; }
        public DataFooter footer { get; set; }
        public string allow_domains { get; set; }
        public DataMore more { get; set; }
        public List<DataAgeLimit> age_limits { get; set; }
        [ObjectOrArray(true)]
        public List<DataBody> body { get; set; }
        public string contents_descriptors { get; set; }
        public string interactive_elements { get; set; }
        public List<DataProduct> related_products { get; set; }
        public List<DataChannel> related_channels { get; set; }
        public List<DataMovie> related_movies { get; set; }
        public List<DataProduct> featured_products { get; set; }
        public List<DataRatingInfo> rating_information { get; set; }
    }

    public class BcatTopic
    {
        public Image Icon { get; set; }
        public TopicDetail Details { get; set; }
    }

    public class TopicDetail : BcatMsgPack
    {
        public string topic_id { get; set; }
        public string name { get; set; }
        public string publisher { get; set; }
        public string description { get; set; }
        public ulong publishing_time { get; set; }
        public ulong last_posted_at { get; set; }
        public bool important { get; set; }
        public List<string> latest_news_urls { get; set; }
    }

    public class BCAT
    {
        public enum Module
        {
            None,
            nnBcat,
            nnNews,
        }

        private const string LIST_URL = "https://bcat-list-lp1.cdn.nintendo.net/api/nx/v1/list/";
        private const string TOPICS_URL = "https://bcat-topics-lp1.cdn.nintendo.net/api/nx/v1/topics/";
        private const string TITLES_URL = "https://bcat-topics-lp1.cdn.nintendo.net/api/nx/v1/titles/";
        
        private const string BCAT_MAGIC = "bcat";

        public const string MAIN_TOPIC_ID = "nx_news";
        public const string QLAUNCH_TOPIC_ID = "nx_news_announcement";

        private const string QLAUNCH_PASS = "acda358b4d32d17fd4037c1b5e0235427a8563f93b0fdb42a4a536ee95bbf80f";
        private const ulong QLAUNCH_TID = 0x0100000000001000;

        public static string[] Langs { get; } = new string[]
        {
            "de",
            "es",
            "es-419",
            "en-GB",
            "en-US",
            "fr",
            "fr-CA",
            "it",
            "ja",
            "ko",
            "nl",
            "pt",
            "ru",
            "zh-CN",
            "zh-Hans",
            "zh-Hant",
            "zh-TW",
        };
        public static string[] Countries { get; } = new string[]
        {
            "AT",
            "AU",
            "BE",
            "BR",
            "CA",
            "CH",
            "CZ",
            "DE",
            "DK",
            "ES",
            "FI",
            "FR",
            "GB",
            "HK",
            "HU",
            "IE",
            "IT",
            "JP",
            "MX",
            "NL",
            "NO",
            "PL",
            "PT",
            "RU",
            "SE",
            "US",
            "ZA",
        };

        public static byte[] GetRawBcat(string url, Module module)
        {
            WebClient client = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            try
            {
                client.Headers.Add(HttpRequestHeader.Accept, "*/*");
                if (module != Module.None)
                    client.Headers.Add(HttpRequestHeader.UserAgent, $"libcurl ({module}; 789f928b-138e-4b2f-afeb-1acae821d897; SDK {Program.Config.SDKVersion})"); //latest : 6.4.0.0
                client.Headers.Add("X-Nintendo-Serial-Number", Program.Config.DeviceID);
                return client.DownloadData(url);
            }
            catch(Exception ex)
            {
                //todo : more details
                throw new Exception("Title doesn't have any BCAT data.");
            }
        }
        public static byte[] GetDecBcat(string url, Module module, ulong titleID, string pass)
        {
            return DecryptBCAT(GetRawBcat(url, module), titleID, pass);
        }
        public static byte[] GetQlaunchBcat(string url, Module module)
        {
            return GetDecBcat(url, module, QLAUNCH_TID, QLAUNCH_PASS);
        }

        public static byte[] GetRawBcatList(ulong TitleID, string pass)
        {
            return GetDecBcat($"{LIST_URL}nx_data_{TitleID:x16}", Module.nnBcat, TitleID, pass);
        }
        public static BcatList GetBcatList(ulong TitleID, string pass)
        {
            return MsgPack.Deserialize<BcatList>(GetRawBcatList(TitleID, pass));
        }

        public static byte[] GetRawBcatNewsList(string topicID)
        {
            return GetQlaunchBcat($"{LIST_URL}{topicID}{MakeQueryString()}", Module.nnBcat);
        }
        public static BcatNews GetBcatNewsList(string topicID)
        {
            return MsgPack.Deserialize<BcatNews>(GetRawBcatNewsList(topicID));
        }

        public static byte[] GetRawTopicDetail(string TopicID)
        {
            return GetQlaunchBcat($"{TOPICS_URL}{TopicID}/detail{MakeQueryString()}", Module.None);
        }
        public static TopicDetail GetTopicDetail(string TopicID)
        {
            return MsgPack.Deserialize<TopicDetail>(GetRawTopicDetail(TopicID));
        }
        public static byte[] GetRawTopicIcon(string TopicID)
        {
            return GetQlaunchBcat($"{TOPICS_URL}{TopicID}/icon", Module.None);
        }
        public static Image GetTopicIcon(string TopicID)
        {
            return Utils.GetBitmap(GetRawTopicIcon(TopicID));
        }
        public static BcatTopic GetBcatTopic(string TopicID)
        {
            BcatTopic topic = new BcatTopic
            {
                Icon = GetTopicIcon(TopicID),
                Details = GetTopicDetail(TopicID)
            };

            return topic;
        }

        public static string GetTitleTopicId(ulong TitleID)
        {
            byte[] buffer = GetDecBcat($"{TITLES_URL}{TitleID:x16}/topics{MakeQueryString()}", Module.nnNews, QLAUNCH_TID, QLAUNCH_PASS);

            //a bit hacky
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                BinaryReader br = new BinaryReader(ms);
                if (br.ReadByte() != 0x91)
                    throw new InvalidDataException($"Failed to get the topic_id : title id : {TitleID:x16}");

                byte b = br.ReadByte();
                if (b >> 5 != 0b101) //topic's id shouldn't be > 0x1F
                    throw new InvalidDataException($"Failed to get the topic_id : title id : {TitleID:x16}");

                int len = b & 0x1F;
                return Encoding.ASCII.GetString(br.ReadBytes(len));
            }
        }
        public static BcatTopic GetBcatTopic(ulong TitleID)
        {
            return GetBcatTopic(GetTitleTopicId(TitleID));
        }

        public static byte[] GetRawNewsCatalog()
        {
            return GetQlaunchBcat($"{TOPICS_URL}catalog{MakeQueryString()}", Module.None);
        }
        public static List<BcatChannel> GetNewsCatalog()
        {
            return MsgPack.Deserialize<List<BcatChannel>>(GetRawNewsCatalog());
        }

        public static byte[] GetRawNewsData(string url)
        {
            Module m = (url.Contains("bcat-data-")) ? Module.nnBcat : Module.None;
            return GetQlaunchBcat(url, m);
        }
        public static NewsData GetNewsData(string url)
        {
            return MsgPack.Deserialize<NewsData>(GetRawNewsData(url));
        }



        public static byte[] DecryptBCAT(byte[] data, ulong TitleID, string passStr)
        {
            byte[] dec;
            using (MemoryStream ms = new MemoryStream(data))
            {
                BinaryReader br = new BinaryReader(ms);

                //read the magic
                string magic = Encoding.ASCII.GetString(br.ReadBytes(4));
                if (magic != BCAT_MAGIC)
                    throw new Exception("Invalid bcat header!");

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

                byte[] salt = Encoding.ASCII.GetBytes(TitleID.ToString("x16") + Program.Config.SaltLower[secretIndex]);
                byte[] pass = Encoding.ASCII.GetBytes(passStr);
                
                byte[] key = PBKDF2Sha256GetBytes(kSize, pass, salt, 4096);

                dec = AesCrypto.PerformAesCTR(enc, 0, enc.Length, key, iv);

            }
            return dec;

        }
        public static byte[] EncryptBCAT(byte[]data, ulong TitleID, string passStr, byte HashType, byte crypto, byte[] signature)
        {
            byte[] output;

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryWriter bw = new BinaryWriter(ms);

                Random rnd = new Random();
                byte[] iv = new byte[0x10];
                rnd.NextBytes(iv); //generate random iv
                int secretIndex = rnd.Next(0, 31); //generate random secret index

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
                    byte[] salt = Encoding.ASCII.GetBytes(TitleID.ToString("x16") + Program.Config.SaltLower[secretIndex]);
                    byte[] pass = Encoding.ASCII.GetBytes(passStr);
                    byte[] key = PBKDF2Sha256GetBytes(kSize, pass, salt, 4096);
                    bw.Write(AesCrypto.PerformAesCTR(data, 0, data.Length, key, iv));
                }
                output = ms.ToArray();
            }
            return output;
        }
        
        public static string MakeQueryString()
        {
            return MakeQueryString(Program.Config.Lang, Program.Config.Countries);
        }
        public static string MakeQueryString(int langIndex, List<int> countryIndices)
        {
            List<string> countries = new List<string>();
            foreach (var nb in countryIndices)
                countries.Add(BCAT.Countries[nb]);

            return MakeQueryString(BCAT.Langs[langIndex], countries);
        }
        public static string MakeQueryString(string lang, string country)
        {
            return MakeQueryString(lang, new string[] { country });
        }
        public static string MakeQueryString(string lang, List<string> countries)
        {
            return MakeQueryString(lang, countries.ToArray());
        }
        public static string MakeQueryString(string lang, string[] countries)
        {
            string s = "?l=" + lang;
            for (int i = 0; i < countries.Length; i++)
                s += "&c%5b%5d=" + countries[i]; //"c%5b%5d" = "c[]"

            return s;
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
