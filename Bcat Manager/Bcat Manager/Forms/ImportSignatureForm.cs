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

namespace Bcat_Manager
{
    public partial class ImportSignatureForm : Form
    {
        public byte[] Signature;

        public ImportSignatureForm()
        {
            InitializeComponent();
            comboBox_input.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool correct = false;
            try
            {
                switch (comboBox_input.SelectedIndex)
                {
                    case 0: //hex string
                        Signature = Utils.HexToBytes(textBox1.Text);
                        correct = (Signature.Length == 0x100);
                        break;
                    case 1: //base64
                        Signature = Convert.FromBase64String(textBox1.Text);
                        correct = (Signature.Length == 0x100);
                        break;
                }
            }
            catch { }

            textBox1.BackColor = (correct) ? Color.White : Color.Red;
            button_import.Enabled = correct;
        }

        private void button_importFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Utils.BytesToHex(File.ReadAllBytes(openFileDialog1.FileName), " ");
            }
        }

        private void button_import_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1_TextChanged(null, null);
        }
    }
}
