namespace MMBS
{
    partial class AFForm
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
			this.groupDS = new System.Windows.Forms.GroupBox();
			this.comboSourceQuery = new System.Windows.Forms.ComboBox();
			this.labelUnvalidDS = new System.Windows.Forms.Label();
			this.labelValidDS = new System.Windows.Forms.Label();
			this.boxDSlink = new System.Windows.Forms.TextBox();
			this.menuClipboard = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.progressDS = new System.Windows.Forms.ProgressBar();
			this.groupDL = new System.Windows.Forms.GroupBox();
			this.checkSign = new System.Windows.Forms.CheckBox();
			this.linkDLname = new System.Windows.Forms.LinkLabel();
			this.butMDL = new System.Windows.Forms.Button();
			this.labelUnvalidDL = new System.Windows.Forms.Label();
			this.labelValidDL = new System.Windows.Forms.Label();
			this.boxDLlink = new System.Windows.Forms.TextBox();
			this.progressDL = new System.Windows.Forms.ProgressBar();
			this.groupAO = new System.Windows.Forms.GroupBox();
			this.linkAOname = new System.Windows.Forms.LinkLabel();
			this.checkAPK = new System.Windows.Forms.CheckBox();
			this.butMAO = new System.Windows.Forms.Button();
			this.labelUnvalidAO = new System.Windows.Forms.Label();
			this.labelValidAO = new System.Windows.Forms.Label();
			this.boxAOlink = new System.Windows.Forms.TextBox();
			this.progressAO = new System.Windows.Forms.ProgressBar();
			this.checkRoot = new System.Windows.Forms.CheckBox();
			this.checkInternet = new System.Windows.Forms.CheckBox();
			this.boxModInfo = new System.Windows.Forms.RichTextBox();
			this.butModInfo = new System.Windows.Forms.Button();
			this.dialogFile = new System.Windows.Forms.OpenFileDialog();
			this.butIcon = new System.Windows.Forms.PictureBox();
			this.menuNext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.skipFMFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stripNoDownImage = new System.Windows.Forms.ToolStripMenuItem();
			this.listCredit = new System.Windows.Forms.ComboBox();
			this.labelCredit = new System.Windows.Forms.Label();
			this.checkOBB = new System.Windows.Forms.CheckBox();
			this.checkExtPerms = new System.Windows.Forms.CheckBox();
			this.comboExportScript = new System.Windows.Forms.ComboBox();
			this.checkNoImgs_Syswarn = new System.Windows.Forms.CheckBox();
			this.tipOne = new System.Windows.Forms.ToolTip(this.components);
			this.progressOnProc = new System.Windows.Forms.ProgressBar();
			this.groupMirrorDL = new System.Windows.Forms.GroupBox();
			this.linkMirrorDownload = new System.Windows.Forms.LinkLabel();
			this.checkMirror = new System.Windows.Forms.CheckBox();
			this.butMirrorPlus = new System.Windows.Forms.Button();
			this.labelUnvalidMirrorDL = new System.Windows.Forms.Label();
			this.labelValidMirrorDL = new System.Windows.Forms.Label();
			this.boxMirrorDLlink = new System.Windows.Forms.TextBox();
			this.progMirrorDL = new System.Windows.Forms.ProgressBar();
			this.butCustomData = new System.Windows.Forms.Button();
			this.checkMenu = new System.Windows.Forms.CheckBox();
			this.groupDS.SuspendLayout();
			this.groupDL.SuspendLayout();
			this.groupAO.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.butIcon)).BeginInit();
			this.menuNext.SuspendLayout();
			this.groupMirrorDL.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupDS
			// 
			this.groupDS.Controls.Add(this.comboSourceQuery);
			this.groupDS.Controls.Add(this.labelUnvalidDS);
			this.groupDS.Controls.Add(this.labelValidDS);
			this.groupDS.Controls.Add(this.boxDSlink);
			this.groupDS.Controls.Add(this.progressDS);
			this.groupDS.ForeColor = System.Drawing.Color.White;
			this.groupDS.Location = new System.Drawing.Point(12, 12);
			this.groupDS.Name = "groupDS";
			this.groupDS.Size = new System.Drawing.Size(375, 67);
			this.groupDS.TabIndex = 1;
			this.groupDS.TabStop = false;
			this.groupDS.Text = "Data Source";
			// 
			// comboSourceQuery
			// 
			this.comboSourceQuery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboSourceQuery.ItemHeight = 20;
			this.comboSourceQuery.Items.AddRange(new object[] {
            "hl=en",
            "hl=vi"});
			this.comboSourceQuery.Location = new System.Drawing.Point(218, 0);
			this.comboSourceQuery.Name = "comboSourceQuery";
			this.comboSourceQuery.Size = new System.Drawing.Size(117, 28);
			this.comboSourceQuery.TabIndex = 4;
			this.comboSourceQuery.Visible = false;
			this.comboSourceQuery.SelectedIndexChanged += new System.EventHandler(this.comboSourceQuery_SelectedIndexChanged);
			// 
			// labelUnvalidDS
			// 
			this.labelUnvalidDS.AutoSize = true;
			this.labelUnvalidDS.BackColor = System.Drawing.Color.Transparent;
			this.labelUnvalidDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.labelUnvalidDS.ForeColor = System.Drawing.Color.Red;
			this.labelUnvalidDS.Location = new System.Drawing.Point(340, 30);
			this.labelUnvalidDS.Name = "labelUnvalidDS";
			this.labelUnvalidDS.Size = new System.Drawing.Size(21, 20);
			this.labelUnvalidDS.TabIndex = 2;
			this.labelUnvalidDS.Text = "✗";
			// 
			// labelValidDS
			// 
			this.labelValidDS.AutoSize = true;
			this.labelValidDS.BackColor = System.Drawing.Color.Transparent;
			this.labelValidDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.labelValidDS.ForeColor = System.Drawing.Color.Lime;
			this.labelValidDS.Location = new System.Drawing.Point(341, 30);
			this.labelValidDS.Name = "labelValidDS";
			this.labelValidDS.Size = new System.Drawing.Size(20, 20);
			this.labelValidDS.TabIndex = 1;
			this.labelValidDS.Text = "✓";
			// 
			// boxDSlink
			// 
			this.boxDSlink.BackColor = System.Drawing.Color.Black;
			this.boxDSlink.ContextMenuStrip = this.menuClipboard;
			this.boxDSlink.ForeColor = System.Drawing.Color.White;
			this.boxDSlink.Location = new System.Drawing.Point(6, 27);
			this.boxDSlink.Name = "boxDSlink";
			this.boxDSlink.Size = new System.Drawing.Size(329, 26);
			this.boxDSlink.TabIndex = 0;
			this.boxDSlink.Text = "PlayStore://com.entabridge.chatnovel3en";
			this.boxDSlink.TextChanged += new System.EventHandler(this.boxDSlink_TextChanged);
			// 
			// menuClipboard
			// 
			this.menuClipboard.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuClipboard.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.menuClipboard.Name = "menuClipboard";
			this.menuClipboard.Size = new System.Drawing.Size(61, 4);
			this.menuClipboard.Opening += new System.ComponentModel.CancelEventHandler(this.MenuClipboard_Opening);
			this.menuClipboard.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuClipboard_ItemClicked);
			// 
			// progressDS
			// 
			this.progressDS.BackColor = System.Drawing.Color.Black;
			this.progressDS.ForeColor = System.Drawing.Color.Lime;
			this.progressDS.Location = new System.Drawing.Point(3, 25);
			this.progressDS.Name = "progressDS";
			this.progressDS.Size = new System.Drawing.Size(332, 30);
			this.progressDS.Step = 1;
			this.progressDS.TabIndex = 3;
			this.progressDS.Visible = false;
			// 
			// groupDL
			// 
			this.groupDL.Controls.Add(this.checkSign);
			this.groupDL.Controls.Add(this.linkDLname);
			this.groupDL.Controls.Add(this.butMDL);
			this.groupDL.Controls.Add(this.labelUnvalidDL);
			this.groupDL.Controls.Add(this.labelValidDL);
			this.groupDL.Controls.Add(this.boxDLlink);
			this.groupDL.Controls.Add(this.progressDL);
			this.groupDL.ForeColor = System.Drawing.Color.White;
			this.groupDL.Location = new System.Drawing.Point(12, 88);
			this.groupDL.Name = "groupDL";
			this.groupDL.Size = new System.Drawing.Size(375, 67);
			this.groupDL.TabIndex = 4;
			this.groupDL.TabStop = false;
			this.groupDL.Text = "Download";
			this.groupDL.TextChanged += new System.EventHandler(this.groupDL_TextChanged);
			// 
			// checkSign
			// 
			this.checkSign.AutoSize = true;
			this.checkSign.Location = new System.Drawing.Point(90, 0);
			this.checkSign.Name = "checkSign";
			this.checkSign.Size = new System.Drawing.Size(18, 17);
			this.checkSign.TabIndex = 6;
			this.checkSign.UseVisualStyleBackColor = true;
			this.checkSign.CheckedChanged += new System.EventHandler(this.checkSign_CheckedChanged);
			// 
			// linkDLname
			// 
			this.linkDLname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkDLname.AutoSize = true;
			this.linkDLname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.linkDLname.ForeColor = System.Drawing.Color.White;
			this.linkDLname.LinkArea = new System.Windows.Forms.LinkArea(0, 11);
			this.linkDLname.LinkColor = System.Drawing.Color.Blue;
			this.linkDLname.Location = new System.Drawing.Point(239, -3);
			this.linkDLname.MaximumSize = new System.Drawing.Size(225, 23);
			this.linkDLname.Name = "linkDLname";
			this.linkDLname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.linkDLname.Size = new System.Drawing.Size(97, 20);
			this.linkDLname.TabIndex = 5;
			this.linkDLname.TabStop = true;
			this.linkDLname.Text = "example.zip";
			this.linkDLname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.linkDLname.UseMnemonic = false;
			this.linkDLname.VisitedLinkColor = System.Drawing.Color.White;
			this.linkDLname.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDLname_LinkClicked);
			this.linkDLname.TextChanged += new System.EventHandler(this.linkDLname_TextChanged);
			// 
			// butMDL
			// 
			this.butMDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butMDL.ForeColor = System.Drawing.Color.White;
			this.butMDL.Location = new System.Drawing.Point(344, 0);
			this.butMDL.Name = "butMDL";
			this.butMDL.Size = new System.Drawing.Size(25, 25);
			this.butMDL.TabIndex = 4;
			this.butMDL.Text = "+";
			this.butMDL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.butMDL.UseVisualStyleBackColor = true;
			this.butMDL.Click += new System.EventHandler(this.butMDL_Click);
			// 
			// labelUnvalidDL
			// 
			this.labelUnvalidDL.AutoSize = true;
			this.labelUnvalidDL.BackColor = System.Drawing.Color.Transparent;
			this.labelUnvalidDL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.labelUnvalidDL.ForeColor = System.Drawing.Color.Red;
			this.labelUnvalidDL.Location = new System.Drawing.Point(340, 30);
			this.labelUnvalidDL.Name = "labelUnvalidDL";
			this.labelUnvalidDL.Size = new System.Drawing.Size(21, 20);
			this.labelUnvalidDL.TabIndex = 2;
			this.labelUnvalidDL.Text = "✗";
			// 
			// labelValidDL
			// 
			this.labelValidDL.AutoSize = true;
			this.labelValidDL.BackColor = System.Drawing.Color.Transparent;
			this.labelValidDL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.labelValidDL.ForeColor = System.Drawing.Color.Lime;
			this.labelValidDL.Location = new System.Drawing.Point(341, 30);
			this.labelValidDL.Name = "labelValidDL";
			this.labelValidDL.Size = new System.Drawing.Size(20, 20);
			this.labelValidDL.TabIndex = 1;
			this.labelValidDL.Text = "✓";
			// 
			// boxDLlink
			// 
			this.boxDLlink.BackColor = System.Drawing.Color.Black;
			this.boxDLlink.ContextMenuStrip = this.menuClipboard;
			this.boxDLlink.ForeColor = System.Drawing.Color.White;
			this.boxDLlink.Location = new System.Drawing.Point(6, 27);
			this.boxDLlink.Name = "boxDLlink";
			this.boxDLlink.Size = new System.Drawing.Size(329, 26);
			this.boxDLlink.TabIndex = 0;
			this.boxDLlink.Text = "UsersCloud://abcdefghikl";
			this.boxDLlink.TextChanged += new System.EventHandler(this.boxDLlink_TextChanged);
			// 
			// progressDL
			// 
			this.progressDL.BackColor = System.Drawing.Color.White;
			this.progressDL.ForeColor = System.Drawing.Color.Lime;
			this.progressDL.Location = new System.Drawing.Point(3, 25);
			this.progressDL.Name = "progressDL";
			this.progressDL.Size = new System.Drawing.Size(332, 30);
			this.progressDL.Step = 1;
			this.progressDL.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressDL.TabIndex = 3;
			this.progressDL.Visible = false;
			// 
			// groupAO
			// 
			this.groupAO.Controls.Add(this.linkAOname);
			this.groupAO.Controls.Add(this.checkAPK);
			this.groupAO.Controls.Add(this.butMAO);
			this.groupAO.Controls.Add(this.labelUnvalidAO);
			this.groupAO.Controls.Add(this.labelValidAO);
			this.groupAO.Controls.Add(this.boxAOlink);
			this.groupAO.Controls.Add(this.progressAO);
			this.groupAO.ForeColor = System.Drawing.Color.White;
			this.groupAO.Location = new System.Drawing.Point(12, 164);
			this.groupAO.Name = "groupAO";
			this.groupAO.Size = new System.Drawing.Size(375, 67);
			this.groupAO.TabIndex = 5;
			this.groupAO.TabStop = false;
			this.groupAO.Text = "APK Only";
			this.groupAO.Enter += new System.EventHandler(this.groupAO_Enter);
			// 
			// linkAOname
			// 
			this.linkAOname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkAOname.AutoSize = true;
			this.linkAOname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.linkAOname.LinkColor = System.Drawing.Color.Blue;
			this.linkAOname.Location = new System.Drawing.Point(233, -4);
			this.linkAOname.MaximumSize = new System.Drawing.Size(181, 23);
			this.linkAOname.Name = "linkAOname";
			this.linkAOname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.linkAOname.Size = new System.Drawing.Size(101, 20);
			this.linkAOname.TabIndex = 5;
			this.linkAOname.TabStop = true;
			this.linkAOname.Text = "example.apk";
			this.linkAOname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.linkAOname.UseMnemonic = false;
			this.linkAOname.VisitedLinkColor = System.Drawing.Color.White;
			this.linkAOname.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAOname_LinkClicked);
			this.linkAOname.TextChanged += new System.EventHandler(this.linkAOname_TextChanged);
			// 
			// checkAPK
			// 
			this.checkAPK.AutoSize = true;
			this.checkAPK.Location = new System.Drawing.Point(90, -3);
			this.checkAPK.Name = "checkAPK";
			this.checkAPK.Size = new System.Drawing.Size(61, 24);
			this.checkAPK.TabIndex = 5;
			this.checkAPK.Text = "Use";
			this.checkAPK.UseVisualStyleBackColor = true;
			this.checkAPK.CheckedChanged += new System.EventHandler(this.checkAPK_CheckedChanged);
			// 
			// butMAO
			// 
			this.butMAO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butMAO.ForeColor = System.Drawing.Color.White;
			this.butMAO.Location = new System.Drawing.Point(344, 0);
			this.butMAO.Name = "butMAO";
			this.butMAO.Size = new System.Drawing.Size(25, 25);
			this.butMAO.TabIndex = 4;
			this.butMAO.Text = "+";
			this.butMAO.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.butMAO.UseVisualStyleBackColor = true;
			this.butMAO.Click += new System.EventHandler(this.butMAO_Click);
			// 
			// labelUnvalidAO
			// 
			this.labelUnvalidAO.AutoSize = true;
			this.labelUnvalidAO.BackColor = System.Drawing.Color.Transparent;
			this.labelUnvalidAO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.labelUnvalidAO.ForeColor = System.Drawing.Color.Red;
			this.labelUnvalidAO.Location = new System.Drawing.Point(340, 30);
			this.labelUnvalidAO.Name = "labelUnvalidAO";
			this.labelUnvalidAO.Size = new System.Drawing.Size(21, 20);
			this.labelUnvalidAO.TabIndex = 2;
			this.labelUnvalidAO.Text = "✗";
			// 
			// labelValidAO
			// 
			this.labelValidAO.AutoSize = true;
			this.labelValidAO.BackColor = System.Drawing.Color.Transparent;
			this.labelValidAO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.labelValidAO.ForeColor = System.Drawing.Color.Lime;
			this.labelValidAO.Location = new System.Drawing.Point(341, 30);
			this.labelValidAO.Name = "labelValidAO";
			this.labelValidAO.Size = new System.Drawing.Size(20, 20);
			this.labelValidAO.TabIndex = 1;
			this.labelValidAO.Text = "✓";
			// 
			// boxAOlink
			// 
			this.boxAOlink.BackColor = System.Drawing.Color.Black;
			this.boxAOlink.ContextMenuStrip = this.menuClipboard;
			this.boxAOlink.ForeColor = System.Drawing.Color.White;
			this.boxAOlink.Location = new System.Drawing.Point(6, 27);
			this.boxAOlink.Name = "boxAOlink";
			this.boxAOlink.Size = new System.Drawing.Size(329, 26);
			this.boxAOlink.TabIndex = 0;
			this.boxAOlink.Text = "GDrive://laksdfjosiabjaseoiweaf";
			this.boxAOlink.TextChanged += new System.EventHandler(this.boxAOlink_TextChanged);
			// 
			// progressAO
			// 
			this.progressAO.BackColor = System.Drawing.Color.White;
			this.progressAO.ForeColor = System.Drawing.Color.Lime;
			this.progressAO.Location = new System.Drawing.Point(3, 25);
			this.progressAO.Name = "progressAO";
			this.progressAO.Size = new System.Drawing.Size(332, 30);
			this.progressAO.Step = 1;
			this.progressAO.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressAO.TabIndex = 3;
			this.progressAO.Visible = false;
			// 
			// checkRoot
			// 
			this.checkRoot.AutoSize = true;
			this.checkRoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkRoot.Location = new System.Drawing.Point(230, 385);
			this.checkRoot.Name = "checkRoot";
			this.checkRoot.Size = new System.Drawing.Size(62, 24);
			this.checkRoot.TabIndex = 7;
			this.checkRoot.Text = "Root";
			this.checkRoot.UseVisualStyleBackColor = true;
			this.checkRoot.CheckedChanged += new System.EventHandler(this.checkRoot_CheckedChanged);
			this.checkRoot.CheckStateChanged += new System.EventHandler(this.checkRoot_CheckStateChanged);
			// 
			// checkInternet
			// 
			this.checkInternet.AutoSize = true;
			this.checkInternet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkInternet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkInternet.Location = new System.Drawing.Point(307, 355);
			this.checkInternet.Name = "checkInternet";
			this.checkInternet.Size = new System.Drawing.Size(83, 24);
			this.checkInternet.TabIndex = 6;
			this.checkInternet.Text = "Internet";
			this.checkInternet.UseVisualStyleBackColor = true;
			this.checkInternet.CheckedChanged += new System.EventHandler(this.checkInternet_CheckedChanged);
			// 
			// boxModInfo
			// 
			this.boxModInfo.BackColor = System.Drawing.Color.Black;
			this.boxModInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.boxModInfo.DetectUrls = false;
			this.boxModInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F);
			this.boxModInfo.ForeColor = System.Drawing.Color.White;
			this.boxModInfo.Location = new System.Drawing.Point(15, 392);
			this.boxModInfo.Name = "boxModInfo";
			this.boxModInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.boxModInfo.Size = new System.Drawing.Size(209, 191);
			this.boxModInfo.TabIndex = 9;
			this.boxModInfo.Text = "Hello";
			this.boxModInfo.TextChanged += new System.EventHandler(this.boxModInfo_TextChanged);
			// 
			// butModInfo
			// 
			this.butModInfo.BackColor = System.Drawing.Color.Black;
			this.butModInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.butModInfo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butModInfo.FlatAppearance.BorderSize = 2;
			this.butModInfo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.butModInfo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
			this.butModInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butModInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.butModInfo.ForeColor = System.Drawing.Color.Lime;
			this.butModInfo.Location = new System.Drawing.Point(15, 356);
			this.butModInfo.Name = "butModInfo";
			this.butModInfo.Size = new System.Drawing.Size(83, 37);
			this.butModInfo.TabIndex = 8;
			this.butModInfo.Text = "MOD";
			this.butModInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.butModInfo.UseVisualStyleBackColor = false;
			this.butModInfo.Click += new System.EventHandler(this.butModInfo_Click);
			// 
			// dialogFile
			// 
			this.dialogFile.Filter = "\"Screenshot|Screenshot *.*|All Files|*.*\"";
			this.dialogFile.Multiselect = true;
			this.dialogFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dialogFile_FileOk);
			// 
			// butIcon
			// 
			this.butIcon.ContextMenuStrip = this.menuNext;
			this.butIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.butIcon.Image = global::MMBS.Properties.Resources.offlinemods_logo_pns;
			this.butIcon.Location = new System.Drawing.Point(230, 452);
			this.butIcon.Name = "butIcon";
			this.butIcon.Size = new System.Drawing.Size(160, 160);
			this.butIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.butIcon.TabIndex = 0;
			this.butIcon.TabStop = false;
			this.butIcon.Click += new System.EventHandler(this.butIcon_Click);
			// 
			// menuNext
			// 
			this.menuNext.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuNext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skipFMFToolStripMenuItem,
            this.stripNoDownImage});
			this.menuNext.Name = "menuNext";
			this.menuNext.Size = new System.Drawing.Size(289, 52);
			// 
			// skipFMFToolStripMenuItem
			// 
			this.skipFMFToolStripMenuItem.Checked = global::MMBS.Properties.Settings.Default.AFFskipFMF;
			this.skipFMFToolStripMenuItem.CheckOnClick = true;
			this.skipFMFToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.skipFMFToolStripMenuItem.Name = "skipFMFToolStripMenuItem";
			this.skipFMFToolStripMenuItem.Size = new System.Drawing.Size(288, 24);
			this.skipFMFToolStripMenuItem.Text = "One (Beta)";
			this.skipFMFToolStripMenuItem.Click += new System.EventHandler(this.skipFMFToolStripMenuItem_Click_1);
			// 
			// stripNoDownImage
			// 
			this.stripNoDownImage.Checked = global::MMBS.Properties.Settings.Default.NoDownImage;
			this.stripNoDownImage.CheckOnClick = true;
			this.stripNoDownImage.Name = "stripNoDownImage";
			this.stripNoDownImage.Size = new System.Drawing.Size(288, 24);
			this.stripNoDownImage.Text = "Don\'t Download Image Preview";
			this.stripNoDownImage.Click += new System.EventHandler(this.stripNoDownImage_Click);
			// 
			// listCredit
			// 
			this.listCredit.Font = new System.Drawing.Font("Calibri", 10F);
			this.listCredit.FormattingEnabled = true;
			this.listCredit.Location = new System.Drawing.Point(13, 589);
			this.listCredit.Name = "listCredit";
			this.listCredit.Size = new System.Drawing.Size(190, 29);
			this.listCredit.TabIndex = 10;
			this.listCredit.Text = "Credit";
			this.listCredit.SelectedIndexChanged += new System.EventHandler(this.ListCredit_SelectedIndexChanged);
			// 
			// labelCredit
			// 
			this.labelCredit.AutoSize = true;
			this.labelCredit.Location = new System.Drawing.Point(203, 592);
			this.labelCredit.Name = "labelCredit";
			this.labelCredit.Size = new System.Drawing.Size(21, 20);
			this.labelCredit.TabIndex = 11;
			this.labelCredit.Text = "©";
			// 
			// checkOBB
			// 
			this.checkOBB.AutoSize = true;
			this.checkOBB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkOBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkOBB.Location = new System.Drawing.Point(230, 356);
			this.checkOBB.Name = "checkOBB";
			this.checkOBB.Size = new System.Drawing.Size(58, 24);
			this.checkOBB.TabIndex = 6;
			this.checkOBB.Text = "Obb";
			this.checkOBB.UseVisualStyleBackColor = true;
			this.checkOBB.CheckedChanged += new System.EventHandler(this.checkOBB_CheckedChanged);
			// 
			// checkExtPerms
			// 
			this.checkExtPerms.AutoSize = true;
			this.checkExtPerms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkExtPerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkExtPerms.Location = new System.Drawing.Point(230, 325);
			this.checkExtPerms.Name = "checkExtPerms";
			this.checkExtPerms.Size = new System.Drawing.Size(146, 24);
			this.checkExtPerms.TabIndex = 12;
			this.checkExtPerms.Text = "External Perms.";
			this.checkExtPerms.UseVisualStyleBackColor = true;
			this.checkExtPerms.CheckedChanged += new System.EventHandler(this.checkExtPerms_CheckedChanged);
			// 
			// comboExportScript
			// 
			this.comboExportScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.comboExportScript.FormattingEnabled = true;
			this.comboExportScript.Items.AddRange(new object[] {
            "Html Script",
            "PMT BBcode Script"});
			this.comboExportScript.Location = new System.Drawing.Point(15, 323);
			this.comboExportScript.Name = "comboExportScript";
			this.comboExportScript.Size = new System.Drawing.Size(209, 28);
			this.comboExportScript.TabIndex = 13;
			this.comboExportScript.Text = "Export Script Style";
			this.comboExportScript.SelectedIndexChanged += new System.EventHandler(this.comboExportScript_SelectedIndexChanged);
			// 
			// checkNoImgs_Syswarn
			// 
			this.checkNoImgs_Syswarn.AutoSize = true;
			this.checkNoImgs_Syswarn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkNoImgs_Syswarn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkNoImgs_Syswarn.ForeColor = System.Drawing.Color.Blue;
			this.checkNoImgs_Syswarn.Location = new System.Drawing.Point(307, 415);
			this.checkNoImgs_Syswarn.Name = "checkNoImgs_Syswarn";
			this.checkNoImgs_Syswarn.Size = new System.Drawing.Size(80, 24);
			this.checkNoImgs_Syswarn.TabIndex = 14;
			this.checkNoImgs_Syswarn.Text = "No Img";
			this.checkNoImgs_Syswarn.UseVisualStyleBackColor = true;
			this.checkNoImgs_Syswarn.CheckedChanged += new System.EventHandler(this.checkNoImgs_Syswarn_CheckedChanged);
			// 
			// tipOne
			// 
			this.tipOne.AutomaticDelay = 200;
			this.tipOne.AutoPopDelay = 1000;
			this.tipOne.InitialDelay = 200;
			this.tipOne.ReshowDelay = 40;
			// 
			// progressOnProc
			// 
			this.progressOnProc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressOnProc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(175)))), ((int)(((byte)(0)))));
			this.progressOnProc.Location = new System.Drawing.Point(0, 622);
			this.progressOnProc.MarqueeAnimationSpeed = 20;
			this.progressOnProc.Name = "progressOnProc";
			this.progressOnProc.Size = new System.Drawing.Size(403, 2);
			this.progressOnProc.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progressOnProc.TabIndex = 15;
			this.progressOnProc.UseWaitCursor = true;
			this.progressOnProc.Value = 50;
			this.progressOnProc.Visible = false;
			// 
			// groupMirrorDL
			// 
			this.groupMirrorDL.Controls.Add(this.linkMirrorDownload);
			this.groupMirrorDL.Controls.Add(this.checkMirror);
			this.groupMirrorDL.Controls.Add(this.butMirrorPlus);
			this.groupMirrorDL.Controls.Add(this.labelUnvalidMirrorDL);
			this.groupMirrorDL.Controls.Add(this.labelValidMirrorDL);
			this.groupMirrorDL.Controls.Add(this.boxMirrorDLlink);
			this.groupMirrorDL.Controls.Add(this.progMirrorDL);
			this.groupMirrorDL.ForeColor = System.Drawing.Color.White;
			this.groupMirrorDL.Location = new System.Drawing.Point(12, 240);
			this.groupMirrorDL.Name = "groupMirrorDL";
			this.groupMirrorDL.Size = new System.Drawing.Size(375, 67);
			this.groupMirrorDL.TabIndex = 6;
			this.groupMirrorDL.TabStop = false;
			this.groupMirrorDL.Text = "Mirror (WIP)";
			// 
			// linkMirrorDownload
			// 
			this.linkMirrorDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkMirrorDownload.AutoSize = true;
			this.linkMirrorDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.linkMirrorDownload.LinkColor = System.Drawing.Color.Blue;
			this.linkMirrorDownload.Location = new System.Drawing.Point(233, -4);
			this.linkMirrorDownload.MaximumSize = new System.Drawing.Size(181, 23);
			this.linkMirrorDownload.Name = "linkMirrorDownload";
			this.linkMirrorDownload.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.linkMirrorDownload.Size = new System.Drawing.Size(101, 20);
			this.linkMirrorDownload.TabIndex = 5;
			this.linkMirrorDownload.TabStop = true;
			this.linkMirrorDownload.Text = "example.apk";
			this.linkMirrorDownload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.linkMirrorDownload.UseMnemonic = false;
			this.linkMirrorDownload.VisitedLinkColor = System.Drawing.Color.White;
			// 
			// checkMirror
			// 
			this.checkMirror.AutoSize = true;
			this.checkMirror.Location = new System.Drawing.Point(90, -3);
			this.checkMirror.Name = "checkMirror";
			this.checkMirror.Size = new System.Drawing.Size(61, 24);
			this.checkMirror.TabIndex = 5;
			this.checkMirror.Text = "Use";
			this.checkMirror.UseVisualStyleBackColor = true;
			// 
			// butMirrorPlus
			// 
			this.butMirrorPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butMirrorPlus.ForeColor = System.Drawing.Color.White;
			this.butMirrorPlus.Location = new System.Drawing.Point(344, 0);
			this.butMirrorPlus.Name = "butMirrorPlus";
			this.butMirrorPlus.Size = new System.Drawing.Size(25, 25);
			this.butMirrorPlus.TabIndex = 4;
			this.butMirrorPlus.Text = "+";
			this.butMirrorPlus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.butMirrorPlus.UseVisualStyleBackColor = true;
			this.butMirrorPlus.Click += new System.EventHandler(this.button1_Click);
			// 
			// labelUnvalidMirrorDL
			// 
			this.labelUnvalidMirrorDL.AutoSize = true;
			this.labelUnvalidMirrorDL.BackColor = System.Drawing.Color.Transparent;
			this.labelUnvalidMirrorDL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.labelUnvalidMirrorDL.ForeColor = System.Drawing.Color.Red;
			this.labelUnvalidMirrorDL.Location = new System.Drawing.Point(340, 30);
			this.labelUnvalidMirrorDL.Name = "labelUnvalidMirrorDL";
			this.labelUnvalidMirrorDL.Size = new System.Drawing.Size(21, 20);
			this.labelUnvalidMirrorDL.TabIndex = 2;
			this.labelUnvalidMirrorDL.Text = "✗";
			// 
			// labelValidMirrorDL
			// 
			this.labelValidMirrorDL.AutoSize = true;
			this.labelValidMirrorDL.BackColor = System.Drawing.Color.Transparent;
			this.labelValidMirrorDL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			this.labelValidMirrorDL.ForeColor = System.Drawing.Color.Lime;
			this.labelValidMirrorDL.Location = new System.Drawing.Point(341, 30);
			this.labelValidMirrorDL.Name = "labelValidMirrorDL";
			this.labelValidMirrorDL.Size = new System.Drawing.Size(20, 20);
			this.labelValidMirrorDL.TabIndex = 1;
			this.labelValidMirrorDL.Text = "✓";
			// 
			// boxMirrorDLlink
			// 
			this.boxMirrorDLlink.BackColor = System.Drawing.Color.Black;
			this.boxMirrorDLlink.ContextMenuStrip = this.menuClipboard;
			this.boxMirrorDLlink.ForeColor = System.Drawing.Color.White;
			this.boxMirrorDLlink.Location = new System.Drawing.Point(6, 27);
			this.boxMirrorDLlink.Name = "boxMirrorDLlink";
			this.boxMirrorDLlink.Size = new System.Drawing.Size(329, 26);
			this.boxMirrorDLlink.TabIndex = 0;
			this.boxMirrorDLlink.Text = "GDrive://laksdfjosiabjaseoiweaf";
			this.boxMirrorDLlink.TextChanged += new System.EventHandler(this.boxMirrorDLlink_TextChanged);
			// 
			// progMirrorDL
			// 
			this.progMirrorDL.BackColor = System.Drawing.Color.White;
			this.progMirrorDL.ForeColor = System.Drawing.Color.Lime;
			this.progMirrorDL.Location = new System.Drawing.Point(3, 25);
			this.progMirrorDL.Name = "progMirrorDL";
			this.progMirrorDL.Size = new System.Drawing.Size(332, 30);
			this.progMirrorDL.Step = 1;
			this.progMirrorDL.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progMirrorDL.TabIndex = 3;
			this.progMirrorDL.Visible = false;
			// 
			// butCustomData
			// 
			this.butCustomData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.butCustomData.ForeColor = System.Drawing.Color.White;
			this.butCustomData.Location = new System.Drawing.Point(168, 355);
			this.butCustomData.Name = "butCustomData";
			this.butCustomData.Size = new System.Drawing.Size(56, 31);
			this.butCustomData.TabIndex = 6;
			this.butCustomData.Text = "⁉️";
			this.butCustomData.UseVisualStyleBackColor = true;
			this.butCustomData.Click += new System.EventHandler(this.butCustomData_Click);
			// 
			// checkMenu
			// 
			this.checkMenu.AutoSize = true;
			this.checkMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.checkMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.checkMenu.Location = new System.Drawing.Point(307, 385);
			this.checkMenu.Name = "checkMenu";
			this.checkMenu.Size = new System.Drawing.Size(68, 24);
			this.checkMenu.TabIndex = 16;
			this.checkMenu.Text = "Menu";
			this.checkMenu.UseVisualStyleBackColor = true;
			this.checkMenu.CheckedChanged += new System.EventHandler(this.checkMenu_CheckedChanged);
			// 
			// AFForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(401, 624);
			this.Controls.Add(this.checkMenu);
			this.Controls.Add(this.butCustomData);
			this.Controls.Add(this.groupMirrorDL);
			this.Controls.Add(this.progressOnProc);
			this.Controls.Add(this.checkNoImgs_Syswarn);
			this.Controls.Add(this.comboExportScript);
			this.Controls.Add(this.checkExtPerms);
			this.Controls.Add(this.labelCredit);
			this.Controls.Add(this.listCredit);
			this.Controls.Add(this.butModInfo);
			this.Controls.Add(this.checkRoot);
			this.Controls.Add(this.checkOBB);
			this.Controls.Add(this.checkInternet);
			this.Controls.Add(this.groupAO);
			this.Controls.Add(this.groupDL);
			this.Controls.Add(this.butIcon);
			this.Controls.Add(this.boxModInfo);
			this.Controls.Add(this.groupDS);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
			this.ForeColor = System.Drawing.Color.White;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "AFForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AFForm";
			this.Load += new System.EventHandler(this.AFForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AFForm_KeyDown);
			this.MouseEnter += new System.EventHandler(this.AFForm_MouseEnter);
			this.MouseHover += new System.EventHandler(this.AFForm_MouseHover);
			this.groupDS.ResumeLayout(false);
			this.groupDS.PerformLayout();
			this.groupDL.ResumeLayout(false);
			this.groupDL.PerformLayout();
			this.groupAO.ResumeLayout(false);
			this.groupAO.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.butIcon)).EndInit();
			this.menuNext.ResumeLayout(false);
			this.groupMirrorDL.ResumeLayout(false);
			this.groupMirrorDL.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox butIcon;
        private System.Windows.Forms.GroupBox groupDS;
        private System.Windows.Forms.Label labelUnvalidDS;
        private System.Windows.Forms.Label labelValidDS;
        private System.Windows.Forms.TextBox boxDSlink;
        private System.Windows.Forms.ProgressBar progressDS;
        private System.Windows.Forms.GroupBox groupDL;
        private System.Windows.Forms.Label labelUnvalidDL;
        private System.Windows.Forms.Label labelValidDL;
        private System.Windows.Forms.TextBox boxDLlink;
        private System.Windows.Forms.ProgressBar progressDL;
        private System.Windows.Forms.GroupBox groupAO;
        private System.Windows.Forms.Label labelUnvalidAO;
        private System.Windows.Forms.Label labelValidAO;
        private System.Windows.Forms.TextBox boxAOlink;
        private System.Windows.Forms.ProgressBar progressAO;
        private System.Windows.Forms.CheckBox checkRoot;
        private System.Windows.Forms.CheckBox checkInternet;
        private System.Windows.Forms.RichTextBox boxModInfo;
        private System.Windows.Forms.Button butModInfo;
        private System.Windows.Forms.Button butMDL;
        private System.Windows.Forms.Button butMAO;
        private System.Windows.Forms.CheckBox checkAPK;
        private System.Windows.Forms.LinkLabel linkDLname;
        private System.Windows.Forms.LinkLabel linkAOname;
        private System.Windows.Forms.OpenFileDialog dialogFile;
        private System.Windows.Forms.ContextMenuStrip menuNext;
        private System.Windows.Forms.ToolStripMenuItem skipFMFToolStripMenuItem;
        private System.Windows.Forms.ComboBox listCredit;
        private System.Windows.Forms.Label labelCredit;
        private System.Windows.Forms.ContextMenuStrip menuClipboard;
        private System.Windows.Forms.CheckBox checkOBB;
        private System.Windows.Forms.ToolStripMenuItem stripNoDownImage;
        private System.Windows.Forms.CheckBox checkExtPerms;
        private System.Windows.Forms.ComboBox comboExportScript;
        private System.Windows.Forms.CheckBox checkNoImgs_Syswarn;
        private System.Windows.Forms.ToolTip tipOne;
        private System.Windows.Forms.ProgressBar progressOnProc;
        private System.Windows.Forms.CheckBox checkSign;
        private System.Windows.Forms.GroupBox groupMirrorDL;
        private System.Windows.Forms.LinkLabel linkMirrorDownload;
        private System.Windows.Forms.CheckBox checkMirror;
        private System.Windows.Forms.Button butMirrorPlus;
        private System.Windows.Forms.Label labelUnvalidMirrorDL;
        private System.Windows.Forms.Label labelValidMirrorDL;
        private System.Windows.Forms.TextBox boxMirrorDLlink;
        private System.Windows.Forms.ProgressBar progMirrorDL;
        private System.Windows.Forms.Button butCustomData;
        public System.Windows.Forms.ComboBox comboSourceQuery;
        private System.Windows.Forms.CheckBox checkMenu;
    }
}