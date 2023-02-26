namespace MMBS
{
    partial class FormResult
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResult));
            this.butTitle = new System.Windows.Forms.Button();
            this.butPost = new System.Windows.Forms.Button();
            this.butSearch = new System.Windows.Forms.Button();
            this.butQuit = new System.Windows.Forms.Button();
            this.butAutoPost = new System.Windows.Forms.Button();
            this.resFormOption = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setAsDefaltLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whereIsThisFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.resFormOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // butTitle
            // 
            this.butTitle.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.butTitle.FlatAppearance.BorderSize = 3;
            this.butTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.butTitle.ForeColor = System.Drawing.Color.Transparent;
            this.butTitle.Location = new System.Drawing.Point(8, 12);
            this.butTitle.Name = "butTitle";
            this.butTitle.Size = new System.Drawing.Size(218, 109);
            this.butTitle.TabIndex = 1;
            this.butTitle.Text = "Title";
            this.butTitle.UseVisualStyleBackColor = true;
            this.butTitle.EnabledChanged += new System.EventHandler(this.butTitle_EnabledChanged);
            this.butTitle.Click += new System.EventHandler(this.butTitle_Click);
            // 
            // butPost
            // 
            this.butPost.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.butPost.FlatAppearance.BorderSize = 3;
            this.butPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.butPost.ForeColor = System.Drawing.Color.Transparent;
            this.butPost.Location = new System.Drawing.Point(8, 127);
            this.butPost.Name = "butPost";
            this.butPost.Size = new System.Drawing.Size(218, 109);
            this.butPost.TabIndex = 2;
            this.butPost.Text = "HTML Code";
            this.butPost.UseVisualStyleBackColor = true;
            this.butPost.Click += new System.EventHandler(this.butPost_Click);
            // 
            // butSearch
            // 
            this.butSearch.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.butSearch.FlatAppearance.BorderSize = 3;
            this.butSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.butSearch.ForeColor = System.Drawing.Color.Transparent;
            this.butSearch.Location = new System.Drawing.Point(8, 242);
            this.butSearch.Name = "butSearch";
            this.butSearch.Size = new System.Drawing.Size(218, 94);
            this.butSearch.TabIndex = 3;
            this.butSearch.Text = "Search Keywords";
            this.butSearch.UseVisualStyleBackColor = true;
            this.butSearch.EnabledChanged += new System.EventHandler(this.butSearch_EnabledChanged);
            this.butSearch.Click += new System.EventHandler(this.butSearch_Click);
            // 
            // butQuit
            // 
            this.butQuit.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.butQuit.FlatAppearance.BorderSize = 3;
            this.butQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.butQuit.ForeColor = System.Drawing.Color.Red;
            this.butQuit.Location = new System.Drawing.Point(8, 370);
            this.butQuit.Name = "butQuit";
            this.butQuit.Size = new System.Drawing.Size(218, 51);
            this.butQuit.TabIndex = 5;
            this.butQuit.Text = "Back";
            this.butQuit.UseVisualStyleBackColor = true;
            this.butQuit.Click += new System.EventHandler(this.butQuit_Click);
            // 
            // butAutoPost
            // 
            this.butAutoPost.BackColor = System.Drawing.Color.Black;
            this.butAutoPost.BackgroundImage = global::MMBS.Properties.Resources.offlinemods_logo_pns;
            this.butAutoPost.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butAutoPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAutoPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.butAutoPost.ForeColor = System.Drawing.Color.Yellow;
            this.butAutoPost.Location = new System.Drawing.Point(95, 334);
            this.butAutoPost.Name = "butAutoPost";
            this.butAutoPost.Size = new System.Drawing.Size(42, 39);
            this.butAutoPost.TabIndex = 4;
            this.butAutoPost.UseVisualStyleBackColor = false;
            this.butAutoPost.Click += new System.EventHandler(this.butAutoPost_Click);
            // 
            // resFormOption
            // 
            this.resFormOption.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.resFormOption.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setAsDefaltLocationToolStripMenuItem,
            this.whereIsThisFormToolStripMenuItem});
            this.resFormOption.Name = "contextMenuStrip1";
            this.resFormOption.Size = new System.Drawing.Size(226, 52);
            // 
            // setAsDefaltLocationToolStripMenuItem
            // 
            this.setAsDefaltLocationToolStripMenuItem.Name = "setAsDefaltLocationToolStripMenuItem";
            this.setAsDefaltLocationToolStripMenuItem.Size = new System.Drawing.Size(225, 24);
            this.setAsDefaltLocationToolStripMenuItem.Text = "Set As Defalt Location";
            this.setAsDefaltLocationToolStripMenuItem.Click += new System.EventHandler(this.setAsDefaltLocationToolStripMenuItem_Click);
            // 
            // whereIsThisFormToolStripMenuItem
            // 
            this.whereIsThisFormToolStripMenuItem.Name = "whereIsThisFormToolStripMenuItem";
            this.whereIsThisFormToolStripMenuItem.Size = new System.Drawing.Size(225, 24);
            this.whereIsThisFormToolStripMenuItem.Text = "Where is this Form?";
            this.whereIsThisFormToolStripMenuItem.Click += new System.EventHandler(this.whereIsThisFormToolStripMenuItem_Click);
            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(235, 433);
            this.ContextMenuStrip = this.resFormOption;
            this.Controls.Add(this.butTitle);
            this.Controls.Add(this.butQuit);
            this.Controls.Add(this.butSearch);
            this.Controls.Add(this.butPost);
            this.Controls.Add(this.butAutoPost);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::MMBS.Properties.Settings.Default, "newPostBlankPosition", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::MMBS.Properties.Settings.Default.newPostBlankPosition;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormResult";
            this.Text = "Export";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormResult_FormClosing);
            this.TextChanged += new System.EventHandler(this.FormResult_TextChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormResult_KeyDown);
            this.resFormOption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butTitle;
        private System.Windows.Forms.Button butPost;
        private System.Windows.Forms.Button butSearch;
        private System.Windows.Forms.Button butAutoPost;
        private System.Windows.Forms.Button butQuit;
        private System.Windows.Forms.ContextMenuStrip resFormOption;
        private System.Windows.Forms.ToolStripMenuItem setAsDefaltLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whereIsThisFormToolStripMenuItem;
        public System.Windows.Forms.ToolTip toolTip;
    }
}