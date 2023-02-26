namespace MMBS
{
    partial class LinkValidator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinkValidator));
            this.boxLinkname = new System.Windows.Forms.TextBox();
            this.boxLink = new System.Windows.Forms.TextBox();
            this.butContinue = new System.Windows.Forms.Button();
            this.labelValid = new System.Windows.Forms.Label();
            this.labelUn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // boxLinkname
            // 
            this.boxLinkname.BackColor = System.Drawing.Color.Black;
            this.boxLinkname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxLinkname.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxLinkname.ForeColor = System.Drawing.Color.White;
            this.boxLinkname.HideSelection = false;
            this.boxLinkname.Location = new System.Drawing.Point(12, 17);
            this.boxLinkname.MaximumSize = new System.Drawing.Size(535, 50);
            this.boxLinkname.MinimumSize = new System.Drawing.Size(120, 32);
            this.boxLinkname.Name = "boxLinkname";
            this.boxLinkname.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.boxLinkname.Size = new System.Drawing.Size(120, 25);
            this.boxLinkname.TabIndex = 2;
            this.boxLinkname.Text = "Link";
            this.boxLinkname.TextChanged += new System.EventHandler(this.boxLinkname_TextChanged);
            // 
            // boxLink
            // 
            this.boxLink.BackColor = System.Drawing.Color.Black;
            this.boxLink.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxLink.ForeColor = System.Drawing.Color.White;
            this.boxLink.HideSelection = false;
            this.boxLink.Location = new System.Drawing.Point(12, 50);
            this.boxLink.MaximumSize = new System.Drawing.Size(535, 50);
            this.boxLink.MinimumSize = new System.Drawing.Size(120, 32);
            this.boxLink.Name = "boxLink";
            this.boxLink.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.boxLink.Size = new System.Drawing.Size(471, 32);
            this.boxLink.TabIndex = 0;
            this.boxLink.TextChanged += new System.EventHandler(this.boxLink_TextChanged);
            // 
            // butContinue
            // 
            this.butContinue.BackColor = System.Drawing.Color.Black;
            this.butContinue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butContinue.FlatAppearance.BorderSize = 2;
            this.butContinue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.butContinue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.butContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butContinue.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butContinue.ForeColor = System.Drawing.Color.Lime;
            this.butContinue.Location = new System.Drawing.Point(348, 12);
            this.butContinue.Name = "butContinue";
            this.butContinue.Size = new System.Drawing.Size(135, 34);
            this.butContinue.TabIndex = 6;
            this.butContinue.Text = "Continue";
            this.butContinue.UseVisualStyleBackColor = false;
            this.butContinue.Click += new System.EventHandler(this.butContinue_Click);
            // 
            // labelValid
            // 
            this.labelValid.AutoSize = true;
            this.labelValid.BackColor = System.Drawing.Color.Transparent;
            this.labelValid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelValid.Font = new System.Drawing.Font("Product Sans", 15F);
            this.labelValid.ForeColor = System.Drawing.Color.Red;
            this.labelValid.Location = new System.Drawing.Point(279, 13);
            this.labelValid.Name = "labelValid";
            this.labelValid.Size = new System.Drawing.Size(68, 32);
            this.labelValid.TabIndex = 22;
            this.labelValid.Text = "Valid";
            this.labelValid.Visible = false;
            // 
            // labelUn
            // 
            this.labelUn.AutoSize = true;
            this.labelUn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelUn.Font = new System.Drawing.Font("Product Sans", 15F);
            this.labelUn.ForeColor = System.Drawing.Color.Red;
            this.labelUn.Location = new System.Drawing.Point(247, 13);
            this.labelUn.Name = "labelUn";
            this.labelUn.Size = new System.Drawing.Size(45, 32);
            this.labelUn.TabIndex = 22;
            this.labelUn.Text = "Un";
            this.labelUn.Visible = false;
            // 
            // LinkValidator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(495, 97);
            this.Controls.Add(this.labelValid);
            this.Controls.Add(this.labelUn);
            this.Controls.Add(this.butContinue);
            this.Controls.Add(this.boxLink);
            this.Controls.Add(this.boxLinkname);
            this.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LinkValidator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Link Validator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox boxLinkname;
        private System.Windows.Forms.TextBox boxLink;
        private System.Windows.Forms.Button butContinue;
        private System.Windows.Forms.Label labelValid;
        private System.Windows.Forms.Label labelUn;
    }
}