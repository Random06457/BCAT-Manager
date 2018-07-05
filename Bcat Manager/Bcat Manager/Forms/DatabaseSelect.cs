using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bcat_Manager
{
    public partial class DatabaseSelect : Form
    {
        public DatabaseSelect()
        {
            InitializeComponent();
        }
        public int SelectedIndex;

        private void DatabaseSelect_Load(object sender, EventArgs e)
        {
            var database = TitleDatabase.GetDatabase();
            foreach (var title in database)
            {
                listBox_titles.Items.Add(title.Name + " (" + title.TitleID.ToString("X16") + ")");

            }
        }

        private void listBox_titles_DoubleClick(object sender, EventArgs e)
        {
            int index = listBox_titles.SelectedIndex;
            if (index > -1)
            {
                SelectedIndex = index;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
