namespace MMBS.QueryForm
{
    partial class ImgurIdQueryForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImgurIdQueryForm));
			this.butAccept = new System.Windows.Forms.Button();
			this.linkHelp = new System.Windows.Forms.LinkLabel();
			this.labelID = new System.Windows.Forms.Label();
			this.labelSecret = new System.Windows.Forms.Label();
			this.boxID = new System.Windows.Forms.TextBox();
			this.boxSecret = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// butAccept
			// 
			this.butAccept.Location = new System.Drawing.Point(264, 84);
			this.butAccept.Name = "butAccept";
			this.butAccept.Size = new System.Drawing.Size(75, 23);
			this.butAccept.TabIndex = 0;
			this.butAccept.Text = "Save";
			this.butAccept.UseVisualStyleBackColor = true;
			this.butAccept.Click += new System.EventHandler(this.butAccept_Click);
			// 
			// linkHelp
			// 
			this.linkHelp.AutoSize = true;
			this.linkHelp.LinkArea = new System.Windows.Forms.LinkArea(0, 20);
			this.linkHelp.Location = new System.Drawing.Point(12, 87);
			this.linkHelp.Name = "linkHelp";
			this.linkHelp.Size = new System.Drawing.Size(129, 16);
			this.linkHelp.TabIndex = 1;
			this.linkHelp.TabStop = true;
			this.linkHelp.Text = "How to get Imgur ID?";
			this.linkHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHelp_LinkClicked);
			// 
			// labelID
			// 
			this.labelID.AutoSize = true;
			this.labelID.Location = new System.Drawing.Point(12, 15);
			this.labelID.Name = "labelID";
			this.labelID.Size = new System.Drawing.Size(56, 16);
			this.labelID.TabIndex = 2;
			this.labelID.Text = "Imgur ID";
			// 
			// labelSecret
			// 
			this.labelSecret.AutoSize = true;
			this.labelSecret.Location = new System.Drawing.Point(12, 51);
			this.labelSecret.Name = "labelSecret";
			this.labelSecret.Size = new System.Drawing.Size(82, 16);
			this.labelSecret.TabIndex = 3;
			this.labelSecret.Text = "Imgur Secret";
			// 
			// boxID
			// 
			this.boxID.Location = new System.Drawing.Point(111, 12);
			this.boxID.Name = "boxID";
			this.boxID.Size = new System.Drawing.Size(228, 22);
			this.boxID.TabIndex = 4;
			this.boxID.TextChanged += new System.EventHandler(this.boxID_TextChanged);
			// 
			// boxSecret
			// 
			this.boxSecret.Location = new System.Drawing.Point(111, 45);
			this.boxSecret.Name = "boxSecret";
			this.boxSecret.Size = new System.Drawing.Size(228, 22);
			this.boxSecret.TabIndex = 5;
			this.boxSecret.TextChanged += new System.EventHandler(this.boxSecret_TextChanged);
			// 
			// ImgurIdQueryForm
			// 
			this.AcceptButton = this.butAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(351, 126);
			this.Controls.Add(this.boxSecret);
			this.Controls.Add(this.boxID);
			this.Controls.Add(this.labelSecret);
			this.Controls.Add(this.labelID);
			this.Controls.Add(this.linkHelp);
			this.Controls.Add(this.butAccept);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ImgurIdQueryForm";
			this.ShowInTaskbar = false;
			this.Text = "Imgur ID";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butAccept;
        private System.Windows.Forms.LinkLabel linkHelp;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label labelSecret;
        private System.Windows.Forms.TextBox boxID;
        private System.Windows.Forms.TextBox boxSecret;
    }
}