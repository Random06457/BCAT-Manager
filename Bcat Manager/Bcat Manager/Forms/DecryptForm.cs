using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Media;

namespace Bcat_Manager
{
    public partial class DecryptForm : Form
    {
        public DecryptForm()
        {
            InitializeComponent();
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

        //decrypt and save file
        private void button_save_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox_path.Text))
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

                    byte[] data = BCAT.DecryptBCAT(File.ReadAllBytes(textBox_path.Text), long.Parse(textBox_tid.Text, NumberStyles.HexNumber), textBox_pass.Text);

                    File.WriteAllBytes(saveFileDialog1.FileName, data);
                    SystemSounds.Asterisk.Play();

                    Invoke(new Action(() => this.Close()));
                });
                t.IsBackground = true;
                t.Start();
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
    }
}
