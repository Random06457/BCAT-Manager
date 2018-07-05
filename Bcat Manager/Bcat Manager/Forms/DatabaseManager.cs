using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Bcat_Manager
{
    public partial class DatabaseManager : Form
    {
        List<TitleInfo> Database = new List<TitleInfo>();

        public DatabaseManager()
        {
            InitializeComponent();
        }

        private void listBox_titles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox_titles.SelectedIndex;
            bool indexExist = (index > -1);

            //enable/disable controls
            textBox_pass.Enabled = indexExist;
            textBox_name.Enabled = indexExist;
            textBox_tid.Enabled = indexExist;
            button_remove.Enabled = indexExist;
            button_save.Enabled = indexExist;

            //show info
            if (indexExist)
            {
                var title = Database[index];
                textBox_name.Text = title.Name;
                textBox_pass.Text = title.Passphrase;
                textBox_tid.Text = title.TitleID.ToString("X16");
            }
            else
            {
                textBox_name.Clear();
                textBox_pass.Clear();
                textBox_tid.Clear();
            }
        }

        private void DatabaseManager_Load(object sender, EventArgs e)
        {
            Database = TitleDatabase.GetDatabase();

            foreach (var title in Database)
            {
                listBox_titles.Items.Add(title.Name);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            listBox_titles.Items.Add("Untitled");
            Database.Add(new TitleInfo("Untitled", 0x0100000000010000, "0000000000000000000000000000000000000000000000000000000000000000"));
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            int index = listBox_titles.SelectedIndex;
            Database.RemoveAt(index);
            listBox_titles.Items.RemoveAt(index);
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            int index = listBox_titles.SelectedIndex;

            var title = Database[index];
            title.Name = textBox_name.Text;
            title.TitleID = long.Parse(textBox_tid.Text, NumberStyles.HexNumber);
            title.Passphrase = textBox_pass.Text;

            listBox_titles.Items[index] = title.Name; 
        }

        private void DatabaseManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            TitleDatabase.SaveDatabase(Database);
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {

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
    }
}
