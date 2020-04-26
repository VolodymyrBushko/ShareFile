namespace Client
{
    partial class ClientForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonSendPath = new System.Windows.Forms.Button();
            this.buttonGetFile = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxNewPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Path to file :";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(118, 12);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(154, 20);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.Text = "D:\\\\file.txt";
            // 
            // buttonSendPath
            // 
            this.buttonSendPath.Location = new System.Drawing.Point(12, 38);
            this.buttonSendPath.Name = "buttonSendPath";
            this.buttonSendPath.Size = new System.Drawing.Size(260, 23);
            this.buttonSendPath.TabIndex = 2;
            this.buttonSendPath.Text = "Send path";
            this.buttonSendPath.UseVisualStyleBackColor = true;
            this.buttonSendPath.Click += new System.EventHandler(this.buttonSendPath_Click);
            // 
            // buttonGetFile
            // 
            this.buttonGetFile.Location = new System.Drawing.Point(12, 103);
            this.buttonGetFile.Name = "buttonGetFile";
            this.buttonGetFile.Size = new System.Drawing.Size(260, 23);
            this.buttonGetFile.TabIndex = 3;
            this.buttonGetFile.Text = "Get file";
            this.buttonGetFile.UseVisualStyleBackColor = true;
            this.buttonGetFile.Click += new System.EventHandler(this.buttonGetFile_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 77);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "New path :";
            // 
            // textBoxNewPath
            // 
            this.textBoxNewPath.Location = new System.Drawing.Point(118, 77);
            this.textBoxNewPath.Name = "textBoxNewPath";
            this.textBoxNewPath.Size = new System.Drawing.Size(154, 20);
            this.textBoxNewPath.TabIndex = 5;
            this.textBoxNewPath.Text = "D:\\\\";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 139);
            this.Controls.Add(this.textBoxNewPath);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonGetFile);
            this.Controls.Add(this.buttonSendPath);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.textBox1);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonSendPath;
        private System.Windows.Forms.Button buttonGetFile;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxNewPath;
    }
}

