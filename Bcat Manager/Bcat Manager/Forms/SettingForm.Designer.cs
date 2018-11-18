namespace Bcat_Manager
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.textBox_lowersalts = new System.Windows.Forms.TextBox();
            this.button_edit_lowersalt = new System.Windows.Forms.Button();
            this.button_cancel_lowersalts = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_queryString = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_cancel_sdkVer = new System.Windows.Forms.Button();
            this.button_edit_sdkVer = new System.Windows.Forms.Button();
            this.textBox_sdkVersion = new System.Windows.Forms.TextBox();
            this.button_cancel_deviceID = new System.Windows.Forms.Button();
            this.button_edit_deviceID = new System.Windows.Forms.Button();
            this.textBox_deviceId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_lowersalts
            // 
            this.textBox_lowersalts.Enabled = false;
            this.textBox_lowersalts.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_lowersalts.Location = new System.Drawing.Point(12, 45);
            this.textBox_lowersalts.MaxLength = 512;
            this.textBox_lowersalts.Multiline = true;
            this.textBox_lowersalts.Name = "textBox_lowersalts";
            this.textBox_lowersalts.Size = new System.Drawing.Size(121, 458);
            this.textBox_lowersalts.TabIndex = 0;
            this.textBox_lowersalts.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button_edit_lowersalt
            // 
            this.button_edit_lowersalt.Location = new System.Drawing.Point(28, 506);
            this.button_edit_lowersalt.Name = "button_edit_lowersalt";
            this.button_edit_lowersalt.Size = new System.Drawing.Size(84, 20);
            this.button_edit_lowersalt.TabIndex = 1;
            this.button_edit_lowersalt.Text = "Edit";
            this.button_edit_lowersalt.UseVisualStyleBackColor = true;
            this.button_edit_lowersalt.Click += new System.EventHandler(this.button_edit_lowersalt_Click);
            // 
            // button_cancel_lowersalts
            // 
            this.button_cancel_lowersalts.Location = new System.Drawing.Point(28, 526);
            this.button_cancel_lowersalts.Name = "button_cancel_lowersalts";
            this.button_cancel_lowersalts.Size = new System.Drawing.Size(84, 20);
            this.button_cancel_lowersalts.TabIndex = 2;
            this.button_cancel_lowersalts.Text = "Cancel";
            this.button_cancel_lowersalts.UseVisualStyleBackColor = true;
            this.button_cancel_lowersalts.Visible = false;
            this.button_cancel_lowersalts.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Config File (*.bin)|*.bin|All Files (*.*)|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(658, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importConfigToolStripMenuItem,
            this.exportConfigToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importConfigToolStripMenuItem
            // 
            this.importConfigToolStripMenuItem.Name = "importConfigToolStripMenuItem";
            this.importConfigToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.importConfigToolStripMenuItem.Text = "Import Config";
            this.importConfigToolStripMenuItem.Click += new System.EventHandler(this.importConfigToolStripMenuItem_Click);
            // 
            // exportConfigToolStripMenuItem
            // 
            this.exportConfigToolStripMenuItem.Name = "exportConfigToolStripMenuItem";
            this.exportConfigToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exportConfigToolStripMenuItem.Text = "Export Config";
            this.exportConfigToolStripMenuItem.Click += new System.EventHandler(this.exportConfigToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Config File (*.bin)|*.bin|All Files (*.*)|*.*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_queryString);
            this.groupBox1.Location = new System.Drawing.Point(150, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 487);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "News Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Countries";
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(32, 87);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(137, 310);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView1_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 108;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lang";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(40, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Query string";
            // 
            // textBox_queryString
            // 
            this.textBox_queryString.Location = new System.Drawing.Point(5, 430);
            this.textBox_queryString.Multiline = true;
            this.textBox_queryString.Name = "textBox_queryString";
            this.textBox_queryString.ReadOnly = true;
            this.textBox_queryString.Size = new System.Drawing.Size(191, 51);
            this.textBox_queryString.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.button_cancel_sdkVer);
            this.groupBox2.Controls.Add(this.button_edit_sdkVer);
            this.groupBox2.Controls.Add(this.textBox_sdkVersion);
            this.groupBox2.Controls.Add(this.button_cancel_deviceID);
            this.groupBox2.Controls.Add(this.button_edit_deviceID);
            this.groupBox2.Controls.Add(this.textBox_deviceId);
            this.groupBox2.Location = new System.Drawing.Point(385, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(261, 166);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Request Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "SDK Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Device ID";
            // 
            // button_cancel_sdkVer
            // 
            this.button_cancel_sdkVer.Location = new System.Drawing.Point(181, 94);
            this.button_cancel_sdkVer.Name = "button_cancel_sdkVer";
            this.button_cancel_sdkVer.Size = new System.Drawing.Size(60, 20);
            this.button_cancel_sdkVer.TabIndex = 7;
            this.button_cancel_sdkVer.Text = "Cancel";
            this.button_cancel_sdkVer.UseVisualStyleBackColor = true;
            this.button_cancel_sdkVer.Visible = false;
            this.button_cancel_sdkVer.Click += new System.EventHandler(this.button_cancel_sdkVer_Click);
            // 
            // button_edit_sdkVer
            // 
            this.button_edit_sdkVer.Location = new System.Drawing.Point(121, 95);
            this.button_edit_sdkVer.Name = "button_edit_sdkVer";
            this.button_edit_sdkVer.Size = new System.Drawing.Size(60, 20);
            this.button_edit_sdkVer.TabIndex = 6;
            this.button_edit_sdkVer.Text = "Edit";
            this.button_edit_sdkVer.UseVisualStyleBackColor = true;
            this.button_edit_sdkVer.Click += new System.EventHandler(this.button_edit_sdkVer_Click);
            // 
            // textBox_sdkVersion
            // 
            this.textBox_sdkVersion.Enabled = false;
            this.textBox_sdkVersion.Location = new System.Drawing.Point(6, 95);
            this.textBox_sdkVersion.Name = "textBox_sdkVersion";
            this.textBox_sdkVersion.Size = new System.Drawing.Size(114, 20);
            this.textBox_sdkVersion.TabIndex = 5;
            this.textBox_sdkVersion.TextChanged += new System.EventHandler(this.textBox_sdkVersion_TextChanged);
            // 
            // button_cancel_deviceID
            // 
            this.button_cancel_deviceID.Location = new System.Drawing.Point(181, 48);
            this.button_cancel_deviceID.Name = "button_cancel_deviceID";
            this.button_cancel_deviceID.Size = new System.Drawing.Size(60, 20);
            this.button_cancel_deviceID.TabIndex = 4;
            this.button_cancel_deviceID.Text = "Cancel";
            this.button_cancel_deviceID.UseVisualStyleBackColor = true;
            this.button_cancel_deviceID.Visible = false;
            this.button_cancel_deviceID.Click += new System.EventHandler(this.button_cancel_deviceID_Click);
            // 
            // button_edit_deviceID
            // 
            this.button_edit_deviceID.Location = new System.Drawing.Point(121, 49);
            this.button_edit_deviceID.Name = "button_edit_deviceID";
            this.button_edit_deviceID.Size = new System.Drawing.Size(60, 20);
            this.button_edit_deviceID.TabIndex = 3;
            this.button_edit_deviceID.Text = "Edit";
            this.button_edit_deviceID.UseVisualStyleBackColor = true;
            this.button_edit_deviceID.Click += new System.EventHandler(this.button_edit_deviceID_Click);
            // 
            // textBox_deviceId
            // 
            this.textBox_deviceId.Enabled = false;
            this.textBox_deviceId.Location = new System.Drawing.Point(6, 49);
            this.textBox_deviceId.Name = "textBox_deviceId";
            this.textBox_deviceId.Size = new System.Drawing.Size(114, 20);
            this.textBox_deviceId.TabIndex = 0;
            this.textBox_deviceId.TextChanged += new System.EventHandler(this.textBox_deviceId_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Salt Lowers";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 560);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_cancel_lowersalts);
            this.Controls.Add(this.button_edit_lowersalt);
            this.Controls.Add(this.textBox_lowersalts);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_lowersalts;
        private System.Windows.Forms.Button button_edit_lowersalt;
        private System.Windows.Forms.Button button_cancel_lowersalts;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportConfigToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_queryString;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_cancel_sdkVer;
        private System.Windows.Forms.Button button_edit_sdkVer;
        private System.Windows.Forms.TextBox textBox_sdkVersion;
        private System.Windows.Forms.Button button_cancel_deviceID;
        private System.Windows.Forms.Button button_edit_deviceID;
        private System.Windows.Forms.TextBox textBox_deviceId;
        private System.Windows.Forms.Label label6;
    }
}