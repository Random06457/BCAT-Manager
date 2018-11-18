using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bcat_Manager.Forms
{
    public partial class CatalogForm : Form
    {
        public BcatTopic SelectedTopic { get; private set; }
        public List<BcatTopic> _topics;

        int lastIndex = -1;

        public CatalogForm()
        {
            InitializeComponent();
        }

        private void RefreshCatalog()
        {
            Thread t = new Thread(() => {

                Invoke(new Action(() =>
                {
                    button_refresh.Enabled = false;
                    progressBar1.Visible = true;
                    label_progress.Visible = true;
                }));

                _topics = NewsCache.RefreshCatalog(progressBar1, label_progress);

                Invoke(new Action(() =>
                {
                    listView1.Items.Clear();
                    imageList1.Images.Clear();
                    for (int i = 0; i < _topics.Count; i++)
                    {
                        imageList1.Images.Add(_topics[i].Icon);
                        var item = listView1.Items.Add(_topics[i].Details.name);
                        item.ImageIndex = i;
                        item.SubItems.Add(_topics[i].Details.publisher);
                        item.SubItems.Add(_topics[i].Details.description);
                    }
                    button_refresh.Enabled = true;
                    progressBar1.Visible = false;
                    label_progress.Visible = false;

                }));
            });
            t.IsBackground = true;
            t.Start();
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            RefreshCatalog();
        }

        private void CatalogForm_Load(object sender, EventArgs e)
        {
            RefreshCatalog();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0 && listView1.SelectedIndices[0] > -1)
            {
                int index = listView1.SelectedIndices[0];
                SelectedTopic = _topics[index];
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0 && listView1.SelectedIndices[0] > -1 && listView1.SelectedIndices[0] != lastIndex)
            {
                int index = listView1.SelectedIndices[0];
                lastIndex = index;
                var urls = _topics[index].Details.latest_news_urls;
                flowLayoutPanel1.Controls.Clear();

                Thread t = new Thread(() =>
                {
                    try
                    {
                        Invoke(new Action(() => {
                            progressBar1.Value = 0;
                            progressBar1.Maximum = urls.Count;
                            label_progress.Visible = true;
                            progressBar1.Visible = true;
                        }));

                        for (int i = 0; i < 3 && i < urls.Count; i++)
                        {
                            Invoke(new Action(() => {
                                progressBar1.Value = i + 1;
                                label_progress.Text = $"Downloading latest news... {i}/{urls.Count}";
                            }));

                            var data = BCAT.GetNewsData(urls[i]);

                            Invoke(new Action(() => {
                                TopicBox tb = new TopicBox();
                                tb.Size = new Size(178 + 2 * tb.SelectionSize, 155 + 2 * tb.SelectionSize);
                                tb.Topic = data;
                                flowLayoutPanel1.Controls.Add(tb);
                            }));

                        }

                        Invoke(new Action(() => {
                            progressBar1.Value = 0;
                            label_progress.Visible = false;
                            progressBar1.Visible = false;
                        }));
                        
                    }
                    catch (Exception ex)
                    {
                        if (ex is ObjectDisposedException || ex is InvalidOperationException)
                        { }
                        else
                        {
                            throw ex;
                        }
                    }
                    
                });
                t.IsBackground = true;
                t.Start();

            }
        }

        private void CatalogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button_refresh.Enabled == false)
                e.Cancel = true;
        }
    }
}
