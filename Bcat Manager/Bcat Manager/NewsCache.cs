using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bcat_Manager
{
    public static class NewsCache
    {
        public const string CACHE_PATH = "Cache";

        public static string NEWS_CACHE_PATH { get { return $"{CACHE_PATH}/{Program.Config.Lang}/News"; } }
        public static string CATALOG_CACHE_PATH { get { return $"{CACHE_PATH}/{Program.Config.Lang}/Catalog"; } }

        public static List<NewsData> RefreshNews(string TopicID, ProgressBar pb, Label lbl)
        {
            string listPath = $"{NEWS_CACHE_PATH}/{TopicID}";

            if (!Directory.Exists(listPath))
                Directory.CreateDirectory(listPath);
            
            byte[] b = BCAT.GetRawBcatNewsList(TopicID);
            File.WriteAllBytes(listPath + ".bin", b);
            var news = MsgPack.Deserialize<BcatNews>(b);

            pb.Invoke(new Action(() => {
                pb.Value = 0;
                pb.Maximum = news.directories[0].data_list.Count;
            }));

            List<NewsData> newsdata = new List<NewsData>();
            int c = 0;
            foreach (var item in news.directories[0].data_list)
            {
                pb.Invoke(new Action(() => pb.Value = c));
                lbl.Invoke(new Action(() => lbl.Text = $"Processing... {c}/{pb.Maximum} (New ID : {item.news_id:X8})"));

                foreach (var lang in item.languages)
                {
                    if (lang.language == Program.Config.Lang)
                    {
                        string path = $"{listPath}/{item.news_id:X8}";

                        if (!File.Exists(path))
                        {
                            b = BCAT.GetRawNewsData(lang.url);
                            File.WriteAllBytes(path, b);
                        }
                        else
                            b = File.ReadAllBytes(path);

                        newsdata.Add(MsgPack.Deserialize<NewsData>(b));
                    }

                }
                c++;
            }
            
            newsdata.Sort(delegate (NewsData d1, NewsData d2) { return d2.published_at.CompareTo(d1.published_at); });

            return newsdata;
        }

        public static List<BcatTopic> RefreshCatalog(ProgressBar pb, Label lbl)
        {
            string catalogPath = $"{CATALOG_CACHE_PATH}.bin";

            byte[] rawCatalog = BCAT.GetRawNewsCatalog();
            List<BcatChannel> catalog = MsgPack.Deserialize<List<BcatChannel>>(rawCatalog);

            List<BcatChannel> cached = (File.Exists(catalogPath))
                ? MsgPack.Deserialize<List<BcatChannel>>(File.ReadAllBytes(catalogPath))
                : null;

            pb.Invoke(new Action(() => {
                pb.Value = 0;
                pb.Maximum = catalog.Count;
            }));

            List<BcatTopic> topics = new List<BcatTopic>();
            for (int i = 0; i < catalog.Count; i++)
            {
                lbl.Invoke(new Action(() => lbl.Text = $"Processing... {i}/{catalog.Count} ({catalog[i].topic_id})"));
                pb.Invoke(new Action(() => pb.Value = i));

                string dir = $"{CATALOG_CACHE_PATH}/{catalog[i].topic_id}";
                string iconPath = $"{dir}/icon.jpg";
                string detailPath = $"{dir}/detail.bin";

                bool redownload = true;

                if (cached != null)
                    foreach (var item in cached)
                        if (item.topic_id == catalog[i].topic_id)
                        {
                            redownload = !(item.Equals(catalog[i]) && File.Exists(iconPath) && File.Exists(detailPath));
                            break;
                        }

                if (redownload)
                {
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    File.WriteAllBytes(iconPath, BCAT.GetRawTopicIcon(catalog[i].topic_id));
                    File.WriteAllBytes(detailPath, BCAT.GetRawTopicDetail(catalog[i].topic_id));
                }

                BcatTopic t = new BcatTopic()
                {
                    Icon = Utils.GetBitmap(File.ReadAllBytes(iconPath)),
                    Details = MsgPack.Deserialize<TopicDetail>(File.ReadAllBytes(detailPath))
                };
                topics.Add(t);
            }

            //if (cached == null)
                File.WriteAllBytes(catalogPath, rawCatalog);

            lbl.Invoke(new Action(() => lbl.Text = "..."));
            pb.Invoke(new Action(() => pb.Value = 0));


            topics = topics.OrderBy(item => item.Details.important).ThenBy(item => item.Details.last_posted_at).Reverse().ToList();

            return topics;
        }

        public static void ClearCache()
        {
            if (Directory.Exists(CACHE_PATH))
                Directory.Delete(CACHE_PATH, true);
        }
    }
}
