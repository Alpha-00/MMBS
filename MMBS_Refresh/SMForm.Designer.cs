namespace MMBS
{
    partial class SMForm
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
            this.boxAppName = new System.Windows.Forms.TextBox();
            this.boxSize = new System.Windows.Forms.TextBox();
            this.boxDataSource = new System.Windows.Forms.TextBox();
            this.boxAreq = new System.Windows.Forms.ComboBox();
            this.boxDesc = new System.Windows.Forms.RichTextBox();
            this.boxDownloadlink = new System.Windows.Forms.TextBox();
            this.boxAPKlink = new System.Windows.Forms.TextBox();
            this.butImage = new System.Windows.Forms.Button();
            this.boxVideo = new System.Windows.Forms.TextBox();
            this.boxMod = new System.Windows.Forms.RichTextBox();
            this.butPost = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.butCover = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boxAppName
            // 
            this.boxAppName.BackColor = System.Drawing.Color.Black;
            this.boxAppName.ForeColor = System.Drawing.Color.White;
            this.boxAppName.Location = new System.Drawing.Point(1, 3);
            this.boxAppName.Name = "boxAppName";
            this.boxAppName.Size = new System.Drawing.Size(215, 28);
            this.boxAppName.TabIndex = 0;
            this.boxAppName.Text = "App Name";
            this.boxAppName.TextChanged += new System.EventHandler(this.boxAppName_TextChanged);
            this.boxAppName.Enter += new System.EventHandler(this.boxAppName_Enter);
            // 
            // boxSize
            // 
            this.boxSize.BackColor = System.Drawing.Color.Black;
            this.boxSize.ForeColor = System.Drawing.Color.White;
            this.boxSize.Location = new System.Drawing.Point(1, 37);
            this.boxSize.Name = "boxSize";
            this.boxSize.Size = new System.Drawing.Size(103, 28);
            this.boxSize.TabIndex = 0;
            this.boxSize.Text = "Size";
            this.boxSize.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // boxDataSource
            // 
            this.boxDataSource.BackColor = System.Drawing.Color.Black;
            this.boxDataSource.ForeColor = System.Drawing.Color.White;
            this.boxDataSource.Location = new System.Drawing.Point(1, 71);
            this.boxDataSource.Name = "boxDataSource";
            this.boxDataSource.Size = new System.Drawing.Size(215, 28);
            this.boxDataSource.TabIndex = 0;
            this.boxDataSource.Text = "Data Source";
            this.boxDataSource.TextChanged += new System.EventHandler(this.boxDataSource_TextChanged);
            // 
            // boxAreq
            // 
            this.boxAreq.FormattingEnabled = true;
            this.boxAreq.Items.AddRange(new object[] {
            "1.0",
            "2.0",
            "2.1",
            "2.2",
            "2.3",
            "2.4",
            "3.0",
            "3.1",
            "4.0",
            "4.1",
            "4.2",
            "4.3",
            "4.4",
            "5.0",
            "5.1",
            "6.0",
            "6.1",
            "7.0",
            "8.0",
            "9.0",
            "Vary"});
            this.boxAreq.Location = new System.Drawing.Point(110, 37);
            this.boxAreq.Name = "boxAreq";
            this.boxAreq.Size = new System.Drawing.Size(106, 29);
            this.boxAreq.TabIndex = 1;
            this.boxAreq.Text = "A Requires";
            this.boxAreq.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // boxDesc
            // 
            this.boxDesc.BackColor = System.Drawing.Color.Black;
            this.boxDesc.ForeColor = System.Drawing.Color.White;
            this.boxDesc.Location = new System.Drawing.Point(3, 106);
            this.boxDesc.Name = "boxDesc";
            this.boxDesc.Size = new System.Drawing.Size(213, 68);
            this.boxDesc.TabIndex = 2;
            this.boxDesc.Text = "description";
            this.boxDesc.TextChanged += new System.EventHandler(this.boxDesc_TextChanged);
            // 
            // boxDownloadlink
            // 
            this.boxDownloadlink.BackColor = System.Drawing.Color.Black;
            this.boxDownloadlink.ForeColor = System.Drawing.Color.White;
            this.boxDownloadlink.Location = new System.Drawing.Point(3, 180);
            this.boxDownloadlink.Name = "boxDownloadlink";
            this.boxDownloadlink.Size = new System.Drawing.Size(213, 28);
            this.boxDownloadlink.TabIndex = 0;
            this.boxDownloadlink.Text = "Download Link";
            this.boxDownloadlink.TextChanged += new System.EventHandler(this.boxDownloadlink_TextChanged);
            // 
            // boxAPKlink
            // 
            this.boxAPKlink.BackColor = System.Drawing.Color.Black;
            this.boxAPKlink.ForeColor = System.Drawing.Color.White;
            this.boxAPKlink.Location = new System.Drawing.Point(3, 214);
            this.boxAPKlink.Name = "boxAPKlink";
            this.boxAPKlink.Size = new System.Drawing.Size(213, 28);
            this.boxAPKlink.TabIndex = 0;
            this.boxAPKlink.Text = "APKonly link";
            this.boxAPKlink.TextChanged += new System.EventHandler(this.boxAPKlink_TextChanged);
            // 
            // butImage
            // 
            this.butImage.ForeColor = System.Drawing.Color.Black;
            this.butImage.Location = new System.Drawing.Point(230, 38);
            this.butImage.Name = "butImage";
            this.butImage.Size = new System.Drawing.Size(131, 27);
            this.butImage.TabIndex = 3;
            this.butImage.Text = "Image";
            this.butImage.UseVisualStyleBackColor = true;
            this.butImage.Click += new System.EventHandler(this.butImage_Click);
            // 
            // boxVideo
            // 
            this.boxVideo.BackColor = System.Drawing.Color.Black;
            this.boxVideo.ForeColor = System.Drawing.Color.White;
            this.boxVideo.Location = new System.Drawing.Point(230, 71);
            this.boxVideo.Name = "boxVideo";
            this.boxVideo.Size = new System.Drawing.Size(131, 28);
            this.boxVideo.TabIndex = 0;
            this.boxVideo.Text = "Video Link";
            this.boxVideo.TextChanged += new System.EventHandler(this.boxVideo_TextChanged);
            // 
            // boxMod
            // 
            this.boxMod.BackColor = System.Drawing.Color.Black;
            this.boxMod.ForeColor = System.Drawing.Color.White;
            this.boxMod.Location = new System.Drawing.Point(230, 106);
            this.boxMod.Name = "boxMod";
            this.boxMod.Size = new System.Drawing.Size(131, 68);
            this.boxMod.TabIndex = 2;
            this.boxMod.Text = "Mod";
            this.boxMod.TextChanged += new System.EventHandler(this.boxMod_TextChanged);
            // 
            // butPost
            // 
            this.butPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPost.Font = new System.Drawing.Font("Product Sans", 15F);
            this.butPost.ForeColor = System.Drawing.Color.Yellow;
            this.butPost.Location = new System.Drawing.Point(230, 180);
            this.butPost.Name = "butPost";
            this.butPost.Size = new System.Drawing.Size(131, 62);
            this.butPost.TabIndex = 4;
            this.butPost.Text = "POST";
            this.butPost.UseVisualStyleBackColor = true;
            this.butPost.Click += new System.EventHandler(this.butPost_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "dialogFile";
            this.openFileDialog1.Multiselect = true;
            // 
            // butCover
            // 
            this.butCover.ForeColor = System.Drawing.Color.Black;
            this.butCover.Location = new System.Drawing.Point(230, 4);
            this.butCover.Name = "butCover";
            this.butCover.Size = new System.Drawing.Size(131, 27);
            this.butCover.TabIndex = 5;
            this.butCover.Text = "Cover";
            this.butCover.UseVisualStyleBackColor = true;
            this.butCover.Click += new System.EventHandler(this.butCover_Click);
            // 
            // SMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(369, 246);
            this.Controls.Add(this.butCover);
            this.Controls.Add(this.butPost);
            this.Controls.Add(this.butImage);
            this.Controls.Add(this.boxMod);
            this.Controls.Add(this.boxDesc);
            this.Controls.Add(this.boxAreq);
            this.Controls.Add(this.boxDownloadlink);
            this.Controls.Add(this.boxAPKlink);
            this.Controls.Add(this.boxVideo);
            this.Controls.Add(this.boxDataSource);
            this.Controls.Add(this.boxSize);
            this.Controls.Add(this.boxAppName);
            this.Font = new System.Drawing.Font("Product Sans", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SMForm";
            this.Text = "SMForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox boxAppName;
        private System.Windows.Forms.TextBox boxSize;
        private System.Windows.Forms.TextBox boxDataSource;
        private System.Windows.Forms.ComboBox boxAreq;
        private System.Windows.Forms.RichTextBox boxDesc;
        private System.Windows.Forms.TextBox boxDownloadlink;
        private System.Windows.Forms.TextBox boxAPKlink;
        private System.Windows.Forms.Button butImage;
        private System.Windows.Forms.TextBox boxVideo;
        private System.Windows.Forms.RichTextBox boxMod;
        private System.Windows.Forms.Button butPost;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button butCover;
    }
}