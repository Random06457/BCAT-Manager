using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagePack;
using Newtonsoft.Json;

namespace Bcat_Manager
{
    public partial class EncryptForm : Form
    {
        private BcatJson DataList;
        private bool IsList;
        private byte[] Signature = new byte[0x100];

        private EncryptForm(bool islist, BcatJson list)
        {
            IsList = islist;
            DataList = list;

            InitializeComponent();

            //defaut values
            comboBox_crypto.SelectedIndex = 2;
            comboBox_sha.SelectedIndex = 1;

            if (IsList)
            {
                textBox_path.Visible = false;
                button2.Visible = false;
            }
        }
        public EncryptForm() : this(false, null) { }
        public EncryptForm(BcatJson list) : this(true, list) { }

        //select tid and pass from database
        private void button_select_Click(object sender, EventArgs e)
        {
            DatabaseSelect selector = new DatabaseSelect();
            if (selector.ShowDialog() == DialogResult.OK)
            {
                var title = TitleDatabase.GetDatabase()[selector.SelectedIndex];
                textBox_tid.Text = title.TitleID.ToString("X16");
                textBox_pass.Text = title.Passphrase;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = openFileDialog1.FileName;
            }
        }

        //check tid and pass
        private void textBox_tid_TextChanged(object sender, EventArgs e)
        {
            checkPassAndTitleId();
        }
        private void textBox_pass_TextChanged(object sender, EventArgs e)
        {
            checkPassAndTitleId();
        }
        private void checkPassAndTitleId()
        {
            bool correctPass = Utils.IsValidPassphrase(textBox_pass.Text);
            bool correctTid = Utils.IsValidTid(textBox_tid.Text);

            textBox_pass.BackColor = (correctPass) ? Color.White : Color.Red;
            textBox_tid.BackColor = (correctTid) ? Color.White : Color.Red;

            button_save.Enabled = correctPass && correctTid;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox_path.Text) && !IsList)
            {
                MessageBox.Show("Input file \"" + textBox_path.Text + "\" does not exist.");
                return;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Thread t = new Thread(() =>
                {
                    //disable contols
                    foreach (Control control in Controls) Invoke(new Action(() => control.Enabled = false));

                    byte[] data = (IsList)
                    ? DataList.GetMsgPack()
                    : File.ReadAllBytes(textBox_path.Text);

                    byte crypto = 0, hashType = 0;
                    Invoke(new Action(() => crypto = (byte)(comboBox_crypto.SelectedIndex +1)));
                    Invoke(new Action(() => hashType = (byte)comboBox_sha.SelectedIndex));
                    byte[] enc = BCAT.EncryptBCAT(data, long.Parse(textBox_tid.Text, NumberStyles.HexNumber), textBox_pass.Text, hashType, crypto, Signature);

                    File.WriteAllBytes(saveFileDialog1.FileName, enc);
                    SystemSounds.Asterisk.Play();

                    Invoke(new Action(() => this.Close()));
                });
                t.IsBackground = true;
                t.Start();
            }
        }

        private void button_importSign_Click(object sender, EventArgs e)
        {
            ImportSignatureForm form = new ImportSignatureForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                Signature = form.Signature;
            }
        }
    }
}
