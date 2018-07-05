namespace Bcat_Manager
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decryptedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.encryptedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_tid = new System.Windows.Forms.TextBox();
            this.button_select = new System.Windows.Forms.Button();
            this.textBox_pass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_getList = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_reqAppVer = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.value_reqAppVer = new System.Windows.Forms.NumericUpDown();
            this.checkBox_requiredNA = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_serviceStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_topicId = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_dirHash = new System.Windows.Forms.TextBox();
            this.checkBox_dirGroupCountry = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_dirMode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_dirName = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_fileSize = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.value_fileSize = new System.Windows.Forms.NumericUpDown();
            this.checkBox_fileID = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.value_fileID = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_fileUrl = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_fileHash = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_fileName = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.linkLabel_credits = new System.Windows.Forms.LinkLabel();
            this.linkLabel_infoPass = new System.Windows.Forms.LinkLabel();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.value_reqAppVer)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.value_fileSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_fileID)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(8, 207);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(224, 239);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "file.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(478, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encryptToolStripMenuItem,
            this.decryptToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // encryptToolStripMenuItem
            // 
            this.encryptToolStripMenuItem.Name = "encryptToolStripMenuItem";
            this.encryptToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.encryptToolStripMenuItem.Text = "Encrypt";
            this.encryptToolStripMenuItem.Click += new System.EventHandler(this.encryptToolStripMenuItem_Click);
            // 
            // decryptToolStripMenuItem
            // 
            this.decryptToolStripMenuItem.Name = "decryptToolStripMenuItem";
            this.decryptToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.decryptToolStripMenuItem.Text = "Decrypt";
            this.decryptToolStripMenuItem.Click += new System.EventHandler(this.decryptToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.manageToolStripMenuItem.Text = "Manage";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.addFolderToolStripMenuItem,
            this.addFileToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.exportASToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 114);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawToolStripMenuItem,
            this.decryptedToolStripMenuItem});
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.downloadToolStripMenuItem.Text = "Download File(s)";
            // 
            // rawToolStripMenuItem
            // 
            this.rawToolStripMenuItem.Name = "rawToolStripMenuItem";
            this.rawToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.rawToolStripMenuItem.Text = "Raw";
            this.rawToolStripMenuItem.Click += new System.EventHandler(this.rawToolStripMenuItem_Click);
            // 
            // decryptedToolStripMenuItem
            // 
            this.decryptedToolStripMenuItem.Name = "decryptedToolStripMenuItem";
            this.decryptedToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.decryptedToolStripMenuItem.Text = "Decrypted";
            this.decryptedToolStripMenuItem.Click += new System.EventHandler(this.decryptedToolStripMenuItem_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addFolderToolStripMenuItem.Text = "Add Folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.addFileToolStripMenuItem.Text = "Add File";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // exportASToolStripMenuItem
            // 
            this.exportASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rawToolStripMenuItem1,
            this.encryptedToolStripMenuItem});
            this.exportASToolStripMenuItem.Name = "exportASToolStripMenuItem";
            this.exportASToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportASToolStripMenuItem.Text = "Export";
            // 
            // rawToolStripMenuItem1
            // 
            this.rawToolStripMenuItem1.Name = "rawToolStripMenuItem1";
            this.rawToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
            this.rawToolStripMenuItem1.Text = "Raw MsgPack";
            this.rawToolStripMenuItem1.Click += new System.EventHandler(this.rawToolStripMenuItem1_Click);
            // 
            // encryptedToolStripMenuItem
            // 
            this.encryptedToolStripMenuItem.Name = "encryptedToolStripMenuItem";
            this.encryptedToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.encryptedToolStripMenuItem.Text = "Encrypted";
            this.encryptedToolStripMenuItem.Click += new System.EventHandler(this.encryptedToolStripMenuItem_Click);
            // 
            // textBox_tid
            // 
            this.textBox_tid.BackColor = System.Drawing.Color.Red;
            this.textBox_tid.Location = new System.Drawing.Point(141, 65);
            this.textBox_tid.MaxLength = 16;
            this.textBox_tid.Name = "textBox_tid";
            this.textBox_tid.Size = new System.Drawing.Size(200, 20);
            this.textBox_tid.TabIndex = 2;
            this.textBox_tid.TextChanged += new System.EventHandler(this.textBox_tid_TextChanged);
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(179, 27);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(124, 23);
            this.button_select.TabIndex = 3;
            this.button_select.Text = "Select from Database";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // textBox_pass
            // 
            this.textBox_pass.BackColor = System.Drawing.Color.Red;
            this.textBox_pass.Location = new System.Drawing.Point(141, 101);
            this.textBox_pass.MaxLength = 64;
            this.textBox_pass.Multiline = true;
            this.textBox_pass.Name = "textBox_pass";
            this.textBox_pass.Size = new System.Drawing.Size(200, 36);
            this.textBox_pass.TabIndex = 4;
            this.textBox_pass.TextChanged += new System.EventHandler(this.textBox_pass_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Title ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Passphrase";
            // 
            // button_getList
            // 
            this.button_getList.Enabled = false;
            this.button_getList.Location = new System.Drawing.Point(202, 161);
            this.button_getList.Name = "button_getList";
            this.button_getList.Size = new System.Drawing.Size(75, 23);
            this.button_getList.TabIndex = 7;
            this.button_getList.Text = "Get List";
            this.button_getList.UseVisualStyleBackColor = true;
            this.button_getList.Click += new System.EventHandler(this.button_getList_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ItemSize = new System.Drawing.Size(58, 21);
            this.tabControl1.Location = new System.Drawing.Point(235, 179);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(236, 271);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(228, 242);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(220, 234);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Info";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(228, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_reqAppVer);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.value_reqAppVer);
            this.groupBox3.Controls.Add(this.checkBox_requiredNA);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox_serviceStatus);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox_topicId);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(220, 234);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // checkBox_reqAppVer
            // 
            this.checkBox_reqAppVer.AutoSize = true;
            this.checkBox_reqAppVer.Checked = true;
            this.checkBox_reqAppVer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_reqAppVer.Location = new System.Drawing.Point(160, 134);
            this.checkBox_reqAppVer.Name = "checkBox_reqAppVer";
            this.checkBox_reqAppVer.Size = new System.Drawing.Size(45, 17);
            this.checkBox_reqAppVer.TabIndex = 7;
            this.checkBox_reqAppVer.Text = "Hex";
            this.checkBox_reqAppVer.UseVisualStyleBackColor = true;
            this.checkBox_reqAppVer.CheckedChanged += new System.EventHandler(this.checkBox_reqAppVer_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Required App Version";
            // 
            // value_reqAppVer
            // 
            this.value_reqAppVer.Hexadecimal = true;
            this.value_reqAppVer.Location = new System.Drawing.Point(9, 130);
            this.value_reqAppVer.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.value_reqAppVer.Name = "value_reqAppVer";
            this.value_reqAppVer.Size = new System.Drawing.Size(147, 20);
            this.value_reqAppVer.TabIndex = 6;
            // 
            // checkBox_requiredNA
            // 
            this.checkBox_requiredNA.AutoSize = true;
            this.checkBox_requiredNA.Location = new System.Drawing.Point(9, 94);
            this.checkBox_requiredNA.Name = "checkBox_requiredNA";
            this.checkBox_requiredNA.Size = new System.Drawing.Size(152, 17);
            this.checkBox_requiredNA.TabIndex = 4;
            this.checkBox_requiredNA.Text = "Require Nintendo Account";
            this.checkBox_requiredNA.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Service Status";
            // 
            // textBox_serviceStatus
            // 
            this.textBox_serviceStatus.Location = new System.Drawing.Point(9, 68);
            this.textBox_serviceStatus.Name = "textBox_serviceStatus";
            this.textBox_serviceStatus.Size = new System.Drawing.Size(198, 20);
            this.textBox_serviceStatus.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Topic ID";
            // 
            // textBox_topicId
            // 
            this.textBox_topicId.Location = new System.Drawing.Point(9, 31);
            this.textBox_topicId.Name = "textBox_topicId";
            this.textBox_topicId.Size = new System.Drawing.Size(198, 20);
            this.textBox_topicId.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(228, 242);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox_dirHash);
            this.groupBox2.Controls.Add(this.checkBox_dirGroupCountry);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_dirMode);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_dirName);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 234);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Hash";
            // 
            // textBox_dirHash
            // 
            this.textBox_dirHash.Location = new System.Drawing.Point(9, 130);
            this.textBox_dirHash.Name = "textBox_dirHash";
            this.textBox_dirHash.Size = new System.Drawing.Size(198, 20);
            this.textBox_dirHash.TabIndex = 7;
            // 
            // checkBox_dirGroupCountry
            // 
            this.checkBox_dirGroupCountry.AutoSize = true;
            this.checkBox_dirGroupCountry.Location = new System.Drawing.Point(9, 94);
            this.checkBox_dirGroupCountry.Name = "checkBox_dirGroupCountry";
            this.checkBox_dirGroupCountry.Size = new System.Drawing.Size(109, 17);
            this.checkBox_dirGroupCountry.TabIndex = 6;
            this.checkBox_dirGroupCountry.Text = "Group By Country";
            this.checkBox_dirGroupCountry.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Mode";
            // 
            // textBox_dirMode
            // 
            this.textBox_dirMode.Location = new System.Drawing.Point(9, 68);
            this.textBox_dirMode.Name = "textBox_dirMode";
            this.textBox_dirMode.Size = new System.Drawing.Size(198, 20);
            this.textBox_dirMode.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Name";
            // 
            // textBox_dirName
            // 
            this.textBox_dirName.Location = new System.Drawing.Point(9, 31);
            this.textBox_dirName.Name = "textBox_dirName";
            this.textBox_dirName.Size = new System.Drawing.Size(198, 20);
            this.textBox_dirName.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(228, 242);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_fileSize);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.value_fileSize);
            this.groupBox1.Controls.Add(this.checkBox_fileID);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.value_fileID);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBox_fileUrl);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox_fileHash);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_fileName);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Info";
            // 
            // checkBox_fileSize
            // 
            this.checkBox_fileSize.AutoSize = true;
            this.checkBox_fileSize.Checked = true;
            this.checkBox_fileSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_fileSize.Location = new System.Drawing.Point(160, 204);
            this.checkBox_fileSize.Name = "checkBox_fileSize";
            this.checkBox_fileSize.Size = new System.Drawing.Size(45, 17);
            this.checkBox_fileSize.TabIndex = 18;
            this.checkBox_fileSize.Text = "Hex";
            this.checkBox_fileSize.UseVisualStyleBackColor = true;
            this.checkBox_fileSize.CheckedChanged += new System.EventHandler(this.checkBox_fileSize_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Data Size";
            // 
            // value_fileSize
            // 
            this.value_fileSize.Hexadecimal = true;
            this.value_fileSize.Location = new System.Drawing.Point(9, 201);
            this.value_fileSize.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.value_fileSize.Name = "value_fileSize";
            this.value_fileSize.Size = new System.Drawing.Size(147, 20);
            this.value_fileSize.TabIndex = 17;
            // 
            // checkBox_fileID
            // 
            this.checkBox_fileID.AutoSize = true;
            this.checkBox_fileID.Checked = true;
            this.checkBox_fileID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_fileID.Location = new System.Drawing.Point(160, 170);
            this.checkBox_fileID.Name = "checkBox_fileID";
            this.checkBox_fileID.Size = new System.Drawing.Size(45, 17);
            this.checkBox_fileID.TabIndex = 15;
            this.checkBox_fileID.Text = "Hex";
            this.checkBox_fileID.UseVisualStyleBackColor = true;
            this.checkBox_fileID.CheckedChanged += new System.EventHandler(this.checkBox_fileID_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Data ID";
            // 
            // value_fileID
            // 
            this.value_fileID.Hexadecimal = true;
            this.value_fileID.Location = new System.Drawing.Point(9, 167);
            this.value_fileID.Maximum = new decimal(new int[] {
            -1,
            0,
            0,
            0});
            this.value_fileID.Name = "value_fileID";
            this.value_fileID.Size = new System.Drawing.Size(147, 20);
            this.value_fileID.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "URL";
            // 
            // textBox_fileUrl
            // 
            this.textBox_fileUrl.Location = new System.Drawing.Point(9, 68);
            this.textBox_fileUrl.Multiline = true;
            this.textBox_fileUrl.Name = "textBox_fileUrl";
            this.textBox_fileUrl.Size = new System.Drawing.Size(198, 46);
            this.textBox_fileUrl.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Hash";
            // 
            // textBox_fileHash
            // 
            this.textBox_fileHash.Location = new System.Drawing.Point(9, 130);
            this.textBox_fileHash.Name = "textBox_fileHash";
            this.textBox_fileHash.Size = new System.Drawing.Size(198, 20);
            this.textBox_fileHash.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Name";
            // 
            // textBox_fileName
            // 
            this.textBox_fileName.Location = new System.Drawing.Point(9, 31);
            this.textBox_fileName.Name = "textBox_fileName";
            this.textBox_fileName.Size = new System.Drawing.Size(198, 20);
            this.textBox_fileName.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "All Files (*.*)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "All Files (*.*)|*.*";
            // 
            // linkLabel_credits
            // 
            this.linkLabel_credits.AutoSize = true;
            this.linkLabel_credits.Location = new System.Drawing.Point(426, 448);
            this.linkLabel_credits.Name = "linkLabel_credits";
            this.linkLabel_credits.Size = new System.Drawing.Size(35, 13);
            this.linkLabel_credits.TabIndex = 9;
            this.linkLabel_credits.TabStop = true;
            this.linkLabel_credits.Text = "About";
            this.linkLabel_credits.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_credits_LinkClicked);
            // 
            // linkLabel_infoPass
            // 
            this.linkLabel_infoPass.AutoSize = true;
            this.linkLabel_infoPass.Location = new System.Drawing.Point(168, 139);
            this.linkLabel_infoPass.Name = "linkLabel_infoPass";
            this.linkLabel_infoPass.Size = new System.Drawing.Size(143, 13);
            this.linkLabel_infoPass.TabIndex = 10;
            this.linkLabel_infoPass.TabStop = true;
            this.linkLabel_infoPass.Text = "How to get the passphrase ?";
            this.linkLabel_infoPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_infoPass_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 465);
            this.Controls.Add(this.linkLabel_infoPass);
            this.Controls.Add(this.linkLabel_credits);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_getList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_pass);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.textBox_tid);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Bcat Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.value_reqAppVer)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.value_fileSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.value_fileID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decryptedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFileToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox textBox_tid;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.TextBox textBox_pass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_getList;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown value_reqAppVer;
        private System.Windows.Forms.CheckBox checkBox_requiredNA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_serviceStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_topicId;
        private System.Windows.Forms.CheckBox checkBox_reqAppVer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_dirHash;
        private System.Windows.Forms.CheckBox checkBox_dirGroupCountry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_dirMode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_dirName;
        private System.Windows.Forms.CheckBox checkBox_fileSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown value_fileSize;
        private System.Windows.Forms.CheckBox checkBox_fileID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown value_fileID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_fileUrl;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_fileHash;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_fileName;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStripMenuItem encryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decryptToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem encryptedToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel_credits;
        private System.Windows.Forms.LinkLabel linkLabel_infoPass;
    }
}

