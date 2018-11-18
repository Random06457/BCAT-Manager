using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bcat_Manager.Properties;

namespace Bcat_Manager
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            textBox_lowersalts.Text = "";
            foreach (var s in Program.Config.SaltLower)
                textBox_lowersalts.Text += s;

            foreach (var s in BCAT.Langs)
                comboBox1.Items.Add(s);
            comboBox1.SelectedItem = Program.Config.Lang;


            var values = Program.Config.Countries;
            for (int i = 0; i < BCAT.Countries.Length; i++)
            {
                var item = listView1.Items.Add(BCAT.Countries[i]);
                if (values.Contains(BCAT.Countries[i]))
                    item.Checked = true;
            }

            textBox_sdkVersion.Text = Program.Config.SDKVersion;
            textBox_deviceId.Text = Program.Config.DeviceID;
        }

        //salts
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox_lowersalts.Text = textBox_lowersalts.Text.Trim(new char[] { '\r', '\n' });
            if (Regex.IsMatch(textBox_lowersalts.Text, @"^[0-9a-f]{512}$"))
            {
                textBox_lowersalts.BackColor = Color.White;
                button_edit_lowersalt.Enabled = true;
            }
            else
            {
                textBox_lowersalts.BackColor = Color.Red;
                button_edit_lowersalt.Enabled = false;
            }
        }
        private void button_edit_lowersalt_Click(object sender, EventArgs e)
        {
            if (button_edit_lowersalt.Text == "Edit")
            {
                button_edit_lowersalt.Text = "Save";
                textBox_lowersalts.Enabled = true;
                button_cancel_lowersalts.Visible = true;
            }
            else
            {
                button_edit_lowersalt.Text = "Edit";
                textBox_lowersalts.Enabled = false;
                button_cancel_lowersalts.Visible = false;

                string[] s = new string[32];
                for (int i = 0; i < 32; i++)
                {
                    s[i] = textBox_lowersalts.Text.Substring(i*16, 16);
                }

                Program.Config.SaltLower = s;
            }
        }
        private void button_cancel_Click(object sender, EventArgs e)
        {
            button_edit_lowersalt.Text = "Edit";
            textBox_lowersalts.Enabled = false;
            button_cancel_lowersalts.Visible = false;

            textBox_lowersalts.Text = "";
            foreach (var s in Program.Config.SaltLower)
                textBox_lowersalts.Text += s;
        }

        //device ID
        private void textBox_deviceId_TextChanged(object sender, EventArgs e)
        {
            if (Utils.IsValidDeviceID(textBox_deviceId.Text))
            {
                textBox_deviceId.BackColor = Color.White;
                button_edit_deviceID.Enabled = true;
            }
            else
            {
                textBox_deviceId.BackColor = Color.Red;
                button_edit_deviceID.Enabled = false;
            }
        }
        private void button_edit_deviceID_Click(object sender, EventArgs e)
        {
            if (button_edit_deviceID.Text == "Edit")
            {
                button_edit_deviceID.Text = "Save";
                textBox_deviceId.Enabled = true;
                button_cancel_deviceID.Visible = true;
            }
            else
            {
                button_edit_deviceID.Text = "Edit";
                textBox_deviceId.Enabled = false;
                button_cancel_deviceID.Visible = false;
                
                Program.Config.DeviceID = textBox_deviceId.Text;
            }
        }
        private void button_cancel_deviceID_Click(object sender, EventArgs e)
        {
            button_edit_deviceID.Text = "Edit";
            textBox_deviceId.Enabled = false;
            button_cancel_deviceID.Visible = false;
            textBox_deviceId.Text = Program.Config.DeviceID;
        }

        //sdk version
        private void textBox_sdkVersion_TextChanged(object sender, EventArgs e)
        {
            if (Utils.IsValidSdkVersion(textBox_sdkVersion.Text))
            {
                textBox_sdkVersion.BackColor = Color.White;
                button_edit_sdkVer.Enabled = true;
            }
            else
            {
                textBox_sdkVersion.BackColor = Color.Red;
                button_edit_sdkVer.Enabled = false;
            }
        }
        private void button_edit_sdkVer_Click(object sender, EventArgs e)
        {
            if (button_edit_sdkVer.Text == "Edit")
            {
                button_edit_sdkVer.Text = "Save";
                textBox_sdkVersion.Enabled = true;
                button_cancel_sdkVer.Visible = true;
            }
            else
            {
                button_edit_sdkVer.Text = "Edit";
                textBox_sdkVersion.Enabled = false;
                button_cancel_sdkVer.Visible = false;

                Program.Config.SDKVersion = textBox_sdkVersion.Text;
            }
        }
        private void button_cancel_sdkVer_Click(object sender, EventArgs e)
        {
            button_edit_sdkVer.Text = "Edit";
            textBox_sdkVersion.Enabled = false;
            button_cancel_sdkVer.Visible = false;
            textBox_sdkVersion.Text = Program.Config.SDKVersion;
        }


        private void importConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Program.Config.ImportConfig(openFileDialog1.FileName);
            }
        }
        private void exportConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Program.Config.ExportConfig(saveFileDialog1.FileName);
            }
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Config.Lang = BCAT.Langs[comboBox1.SelectedIndex];

            List<string> values = new List<string>();

            foreach (ListViewItem item in listView1.Items)
                if (item.Checked)
                    values.Add(item.Text);


            Program.Config.Countries = values;
        }


        //countries
        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            comboBox1_SelectedIndexChanged(null, null);
        }
        //lang
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Checked)
                    indices.Add(i);
            }

            textBox_queryString.Text = BCAT.MakeQueryString(comboBox1.SelectedIndex, indices);
        }

    }
}
