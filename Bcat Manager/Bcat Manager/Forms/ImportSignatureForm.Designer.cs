namespace Bcat_Manager
{
    partial class ImportSignatureForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportSignatureForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox_input = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_import = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_importFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(13, 61);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(361, 193);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox_input
            // 
            this.comboBox_input.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_input.FormattingEnabled = true;
            this.comboBox_input.Items.AddRange(new object[] {
            "Hex String",
            "Base64"});
            this.comboBox_input.Location = new System.Drawing.Point(133, 34);
            this.comboBox_input.Name = "comboBox_input";
            this.comboBox_input.Size = new System.Drawing.Size(121, 21);
            this.comboBox_input.TabIndex = 1;
            this.comboBox_input.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Note : Signature size must be 0x100";
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(156, 300);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(75, 23);
            this.button_import.TabIndex = 3;
            this.button_import.Text = "Import";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Input Type";
            // 
            // button_importFile
            // 
            this.button_importFile.Location = new System.Drawing.Point(274, 32);
            this.button_importFile.Name = "button_importFile";
            this.button_importFile.Size = new System.Drawing.Size(84, 23);
            this.button_importFile.TabIndex = 5;
            this.button_importFile.Text = "Import from file";
            this.button_importFile.UseVisualStyleBackColor = true;
            this.button_importFile.Click += new System.EventHandler(this.button_importFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "All Files (*.*)|*.*";
            // 
            // ImportSignatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 332);
            this.Controls.Add(this.button_importFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_input);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportSignatureForm";
            this.Text = "Import Signature";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_importFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}