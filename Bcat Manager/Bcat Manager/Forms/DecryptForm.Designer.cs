namespace Bcat_Manager
{
    partial class DecryptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DecryptForm));
            this.button_select = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_pass = new System.Windows.Forms.TextBox();
            this.textBox_tid = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(49, 48);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(124, 23);
            this.button_select.TabIndex = 18;
            this.button_select.Text = "Select from Database";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "BCAT passphrase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Title ID";
            // 
            // textBox_pass
            // 
            this.textBox_pass.BackColor = System.Drawing.Color.Red;
            this.textBox_pass.Location = new System.Drawing.Point(12, 131);
            this.textBox_pass.MaxLength = 64;
            this.textBox_pass.Multiline = true;
            this.textBox_pass.Name = "textBox_pass";
            this.textBox_pass.Size = new System.Drawing.Size(198, 38);
            this.textBox_pass.TabIndex = 15;
            this.textBox_pass.TextChanged += new System.EventHandler(this.textBox_pass_TextChanged);
            // 
            // textBox_tid
            // 
            this.textBox_tid.BackColor = System.Drawing.Color.Red;
            this.textBox_tid.Location = new System.Drawing.Point(12, 87);
            this.textBox_tid.MaxLength = 16;
            this.textBox_tid.Name = "textBox_tid";
            this.textBox_tid.Size = new System.Drawing.Size(198, 20);
            this.textBox_tid.TabIndex = 14;
            this.textBox_tid.TextChanged += new System.EventHandler(this.textBox_tid_TextChanged);
            // 
            // button_save
            // 
            this.button_save.Enabled = false;
            this.button_save.Location = new System.Drawing.Point(74, 190);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 19;
            this.button_save.Text = "Save As";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(8, 12);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(176, 20);
            this.textBox_path.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(185, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 20);
            this.button2.TabIndex = 21;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // DecryptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 220);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_pass);
            this.Controls.Add(this.textBox_tid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DecryptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Decrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_pass;
        private System.Windows.Forms.TextBox textBox_tid;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}