namespace MMBS
{
    partial class FMForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Hello", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Bye Bye");
            this.boxAppname = new System.Windows.Forms.TextBox();
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.checkNoLine = new System.Windows.Forms.CheckBox();
            this.labelDesc = new System.Windows.Forms.Label();
            this.boxDescription = new System.Windows.Forms.RichTextBox();
            this.labelSource = new System.Windows.Forms.Label();
            this.boxSource = new System.Windows.Forms.TextBox();
            this.checkRoot = new System.Windows.Forms.CheckBox();
            this.checkInternet = new System.Windows.Forms.CheckBox();
            this.labelAReq = new System.Windows.Forms.Label();
            this.boxAReq = new System.Windows.Forms.TextBox();
            this.labelSize = new System.Windows.Forms.Label();
            this.boxSize = new System.Windows.Forms.TextBox();
            this.labelVersion = new System.Windows.Forms.Label();
            this.boxVersion = new System.Windows.Forms.TextBox();
            this.boxIcon = new System.Windows.Forms.PictureBox();
            this.checkABold = new System.Windows.Forms.CheckBox();
            this.groupLink = new System.Windows.Forms.GroupBox();
            this.butMAPK = new System.Windows.Forms.Button();
            this.butMDown = new System.Windows.Forms.Button();
            this.butAddMLink = new System.Windows.Forms.Button();
            this.checkAPKLink = new System.Windows.Forms.CheckBox();
            this.labelMirrorLink = new System.Windows.Forms.Label();
            this.clistMirrorlink = new System.Windows.Forms.CheckedListBox();
            this.labelAPKlink = new System.Windows.Forms.Label();
            this.boxAPKlink = new System.Windows.Forms.TextBox();
            this.labelDownload = new System.Windows.Forms.Label();
            this.boxDownLink = new System.Windows.Forms.TextBox();
            this.boxSearchKey = new System.Windows.Forms.RichTextBox();
            this.labelSearchKey = new System.Windows.Forms.Label();
            this.butModInfo = new System.Windows.Forms.Button();
            this.boxModInfo = new System.Windows.Forms.RichTextBox();
            this.ilistScreenShot = new System.Windows.Forms.ImageList(this.components);
            this.listImageReview = new System.Windows.Forms.ListView();
            this.butDone = new System.Windows.Forms.Button();
            this.boxVreview = new System.Windows.Forms.PictureBox();
            this.boxVideoLink = new System.Windows.Forms.TextBox();
            this.labelVideo = new System.Windows.Forms.LinkLabel();
            this.butCacheFolder = new System.Windows.Forms.Button();
            this.checkVideo = new System.Windows.Forms.CheckBox();
            this.groupImage = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.labelImageName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkImageinScript = new System.Windows.Forms.CheckBox();
            this.checkImageUse = new System.Windows.Forms.CheckBox();
            this.labelDuplicated = new System.Windows.Forms.Label();
            this.boxImageLink = new System.Windows.Forms.TextBox();
            this.boxImage = new System.Windows.Forms.PictureBox();
            this.groupInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxIcon)).BeginInit();
            this.groupLink.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxVreview)).BeginInit();
            this.groupImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // boxAppname
            // 
            this.boxAppname.BackColor = System.Drawing.Color.Black;
            this.boxAppname.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxAppname.ForeColor = System.Drawing.Color.White;
            this.boxAppname.HideSelection = false;
            this.boxAppname.Location = new System.Drawing.Point(6, 0);
            this.boxAppname.MaximumSize = new System.Drawing.Size(535, 50);
            this.boxAppname.MinimumSize = new System.Drawing.Size(120, 32);
            this.boxAppname.Name = "boxAppname";
            this.boxAppname.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.boxAppname.Size = new System.Drawing.Size(120, 32);
            this.boxAppname.TabIndex = 1;
            this.boxAppname.Text = "App Name";
            this.boxAppname.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.boxAppname.Enter += new System.EventHandler(this.boxAppname_Enter);
            this.boxAppname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boxAppname_KeyDown);
            this.boxAppname.Leave += new System.EventHandler(this.boxAppname_Leave);
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.boxAppname);
            this.groupInfo.Controls.Add(this.checkNoLine);
            this.groupInfo.Controls.Add(this.labelDesc);
            this.groupInfo.Controls.Add(this.boxDescription);
            this.groupInfo.Controls.Add(this.labelSource);
            this.groupInfo.Controls.Add(this.boxSource);
            this.groupInfo.Controls.Add(this.checkRoot);
            this.groupInfo.Controls.Add(this.checkInternet);
            this.groupInfo.Controls.Add(this.labelAReq);
            this.groupInfo.Controls.Add(this.boxAReq);
            this.groupInfo.Controls.Add(this.labelSize);
            this.groupInfo.Controls.Add(this.boxSize);
            this.groupInfo.Controls.Add(this.labelVersion);
            this.groupInfo.Controls.Add(this.boxVersion);
            this.groupInfo.Controls.Add(this.boxIcon);
            this.groupInfo.Controls.Add(this.checkABold);
            this.groupInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupInfo.Location = new System.Drawing.Point(12, 12);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(547, 383);
            this.groupInfo.TabIndex = 2;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "App Information";
            // 
            // checkNoLine
            // 
            this.checkNoLine.AutoSize = true;
            this.checkNoLine.Checked = true;
            this.checkNoLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkNoLine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkNoLine.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.checkNoLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkNoLine.Font = new System.Drawing.Font("Product Sans", 10F);
            this.checkNoLine.ForeColor = System.Drawing.Color.Lime;
            this.checkNoLine.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkNoLine.Location = new System.Drawing.Point(408, 163);
            this.checkNoLine.Name = "checkNoLine";
            this.checkNoLine.Size = new System.Drawing.Size(133, 25);
            this.checkNoLine.TabIndex = 26;
            this.checkNoLine.TabStop = false;
            this.checkNoLine.Text = "No Space Line";
            this.checkNoLine.UseMnemonic = false;
            this.checkNoLine.UseVisualStyleBackColor = true;
            this.checkNoLine.CheckedChanged += new System.EventHandler(this.checkNoLine_CheckedChanged);
            // 
            // labelDesc
            // 
            this.labelDesc.AutoSize = true;
            this.labelDesc.Font = new System.Drawing.Font("Product Sans", 10F);
            this.labelDesc.Location = new System.Drawing.Point(6, 165);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(97, 21);
            this.labelDesc.TabIndex = 13;
            this.labelDesc.Text = "Description";
            // 
            // boxDescription
            // 
            this.boxDescription.BackColor = System.Drawing.Color.Black;
            this.boxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.boxDescription.ForeColor = System.Drawing.Color.White;
            this.boxDescription.Location = new System.Drawing.Point(6, 189);
            this.boxDescription.Name = "boxDescription";
            this.boxDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.boxDescription.Size = new System.Drawing.Size(535, 148);
            this.boxDescription.TabIndex = 6;
            this.boxDescription.Text = "";
            this.boxDescription.TextChanged += new System.EventHandler(this.boxDescription_TextChanged);
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Font = new System.Drawing.Font("Product Sans", 10F);
            this.labelSource.Location = new System.Drawing.Point(2, 345);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(100, 21);
            this.labelSource.TabIndex = 11;
            this.labelSource.Text = "Data Source";
            // 
            // boxSource
            // 
            this.boxSource.AutoCompleteCustomSource.AddRange(new string[] {
            "Android 2.3+",
            "Android 4.0+",
            "Android 4.1+",
            "Android 5.0+",
            "Android 6.0+"});
            this.boxSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.boxSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxSource.BackColor = System.Drawing.Color.Black;
            this.boxSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxSource.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.boxSource.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSource.ForeColor = System.Drawing.Color.White;
            this.boxSource.Location = new System.Drawing.Point(108, 343);
            this.boxSource.Name = "boxSource";
            this.boxSource.Size = new System.Drawing.Size(433, 28);
            this.boxSource.TabIndex = 7;
            this.boxSource.TextChanged += new System.EventHandler(this.boxSource_TextChanged);
            this.boxSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boxSource_KeyDown);
            // 
            // checkRoot
            // 
            this.checkRoot.AutoSize = true;
            this.checkRoot.Font = new System.Drawing.Font("Product Sans", 10F);
            this.checkRoot.Location = new System.Drawing.Point(145, 137);
            this.checkRoot.Name = "checkRoot";
            this.checkRoot.Size = new System.Drawing.Size(68, 25);
            this.checkRoot.TabIndex = 5;
            this.checkRoot.Text = "Root";
            this.checkRoot.UseVisualStyleBackColor = true;
            this.checkRoot.CheckedChanged += new System.EventHandler(this.checkRoot_CheckedChanged);
            this.checkRoot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkRoot_KeyDown);
            // 
            // checkInternet
            // 
            this.checkInternet.AutoSize = true;
            this.checkInternet.Font = new System.Drawing.Font("Product Sans", 10F);
            this.checkInternet.Location = new System.Drawing.Point(145, 106);
            this.checkInternet.Name = "checkInternet";
            this.checkInternet.Size = new System.Drawing.Size(90, 25);
            this.checkInternet.TabIndex = 4;
            this.checkInternet.Text = "Internet";
            this.checkInternet.UseVisualStyleBackColor = true;
            this.checkInternet.CheckedChanged += new System.EventHandler(this.checkInternet_CheckedChanged);
            this.checkInternet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.checkInternet_KeyDown);
            // 
            // labelAReq
            // 
            this.labelAReq.AutoSize = true;
            this.labelAReq.Font = new System.Drawing.Font("Product Sans", 10F);
            this.labelAReq.Location = new System.Drawing.Point(2, 74);
            this.labelAReq.Name = "labelAReq";
            this.labelAReq.Size = new System.Drawing.Size(137, 21);
            this.labelAReq.TabIndex = 7;
            this.labelAReq.Text = "Android Requires";
            // 
            // boxAReq
            // 
            this.boxAReq.AutoCompleteCustomSource.AddRange(new string[] {
            "2.3",
            "4.0",
            "4.1",
            "5.0",
            "6.0"});
            this.boxAReq.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.boxAReq.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxAReq.BackColor = System.Drawing.Color.Black;
            this.boxAReq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxAReq.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.boxAReq.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxAReq.ForeColor = System.Drawing.Color.White;
            this.boxAReq.Location = new System.Drawing.Point(145, 72);
            this.boxAReq.Name = "boxAReq";
            this.boxAReq.Size = new System.Drawing.Size(250, 28);
            this.boxAReq.TabIndex = 3;
            this.boxAReq.TextChanged += new System.EventHandler(this.boxAReq_TextChanged);
            this.boxAReq.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boxAReq_KeyDown);
            this.boxAReq.Leave += new System.EventHandler(this.boxAReq_Leave);
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Font = new System.Drawing.Font("Product Sans", 10F);
            this.labelSize.Location = new System.Drawing.Point(215, 40);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(40, 21);
            this.labelSize.TabIndex = 5;
            this.labelSize.Text = "Size";
            // 
            // boxSize
            // 
            this.boxSize.BackColor = System.Drawing.Color.Black;
            this.boxSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxSize.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.boxSize.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxSize.ForeColor = System.Drawing.Color.White;
            this.boxSize.Location = new System.Drawing.Point(261, 38);
            this.boxSize.Name = "boxSize";
            this.boxSize.Size = new System.Drawing.Size(134, 28);
            this.boxSize.TabIndex = 2;
            this.boxSize.TextChanged += new System.EventHandler(this.boxSize_TextChanged);
            this.boxSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boxSize_KeyDown);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Product Sans", 10F);
            this.labelVersion.Location = new System.Drawing.Point(2, 40);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(66, 21);
            this.labelVersion.TabIndex = 3;
            this.labelVersion.Text = "Version";
            // 
            // boxVersion
            // 
            this.boxVersion.BackColor = System.Drawing.Color.Black;
            this.boxVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxVersion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.boxVersion.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxVersion.ForeColor = System.Drawing.Color.White;
            this.boxVersion.Location = new System.Drawing.Point(74, 38);
            this.boxVersion.Name = "boxVersion";
            this.boxVersion.Size = new System.Drawing.Size(135, 28);
            this.boxVersion.TabIndex = 1;
            this.boxVersion.TextChanged += new System.EventHandler(this.boxVersion_TextChanged);
            this.boxVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boxVersion_KeyDown);
            this.boxVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.boxVersion_KeyPress);
            // 
            // boxIcon
            // 
            this.boxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.boxIcon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxIcon.ErrorImage = global::MMBS.Properties.Resources.offlinemods_logo_pns;
            this.boxIcon.Image = global::MMBS.Properties.Resources.offlinemods_logo_pns;
            this.boxIcon.InitialImage = global::MMBS.Properties.Resources.offlinemods_logo_pns;
            this.boxIcon.Location = new System.Drawing.Point(401, 22);
            this.boxIcon.Name = "boxIcon";
            this.boxIcon.Size = new System.Drawing.Size(140, 140);
            this.boxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boxIcon.TabIndex = 1;
            this.boxIcon.TabStop = false;
            // 
            // checkABold
            // 
            this.checkABold.AutoSize = true;
            this.checkABold.Checked = true;
            this.checkABold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkABold.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkABold.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.checkABold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkABold.Font = new System.Drawing.Font("Product Sans", 10F);
            this.checkABold.ForeColor = System.Drawing.Color.Lime;
            this.checkABold.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkABold.Location = new System.Drawing.Point(301, 163);
            this.checkABold.Name = "checkABold";
            this.checkABold.Size = new System.Drawing.Size(101, 25);
            this.checkABold.TabIndex = 25;
            this.checkABold.TabStop = false;
            this.checkABold.Text = "Auto Bold";
            this.checkABold.UseMnemonic = false;
            this.checkABold.UseVisualStyleBackColor = true;
            this.checkABold.CheckedChanged += new System.EventHandler(this.checkABold_CheckedChanged);
            // 
            // groupLink
            // 
            this.groupLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupLink.Controls.Add(this.butMAPK);
            this.groupLink.Controls.Add(this.butMDown);
            this.groupLink.Controls.Add(this.butAddMLink);
            this.groupLink.Controls.Add(this.checkAPKLink);
            this.groupLink.Controls.Add(this.labelMirrorLink);
            this.groupLink.Controls.Add(this.clistMirrorlink);
            this.groupLink.Controls.Add(this.labelAPKlink);
            this.groupLink.Controls.Add(this.boxAPKlink);
            this.groupLink.Controls.Add(this.labelDownload);
            this.groupLink.Controls.Add(this.boxDownLink);
            this.groupLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupLink.Font = new System.Drawing.Font("Product Sans", 10F);
            this.groupLink.ForeColor = System.Drawing.Color.White;
            this.groupLink.Location = new System.Drawing.Point(12, 405);
            this.groupLink.Name = "groupLink";
            this.groupLink.Size = new System.Drawing.Size(295, 298);
            this.groupLink.TabIndex = 3;
            this.groupLink.TabStop = false;
            this.groupLink.Text = "Link";
            // 
            // butMAPK
            // 
            this.butMAPK.BackColor = System.Drawing.Color.Black;
            this.butMAPK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMAPK.Font = new System.Drawing.Font("Product Sans", 10F);
            this.butMAPK.ForeColor = System.Drawing.Color.White;
            this.butMAPK.Location = new System.Drawing.Point(261, 106);
            this.butMAPK.Name = "butMAPK";
            this.butMAPK.Size = new System.Drawing.Size(28, 28);
            this.butMAPK.TabIndex = 28;
            this.butMAPK.Text = "+";
            this.butMAPK.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butMAPK.UseVisualStyleBackColor = false;
            this.butMAPK.Click += new System.EventHandler(this.butMAPK_Click);
            // 
            // butMDown
            // 
            this.butMDown.BackColor = System.Drawing.Color.Black;
            this.butMDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMDown.Font = new System.Drawing.Font("Product Sans", 10F);
            this.butMDown.ForeColor = System.Drawing.Color.White;
            this.butMDown.Location = new System.Drawing.Point(261, 50);
            this.butMDown.Name = "butMDown";
            this.butMDown.Size = new System.Drawing.Size(28, 28);
            this.butMDown.TabIndex = 28;
            this.butMDown.Text = "+";
            this.butMDown.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butMDown.UseVisualStyleBackColor = false;
            this.butMDown.Click += new System.EventHandler(this.butMDown_Click);
            // 
            // butAddMLink
            // 
            this.butAddMLink.BackColor = System.Drawing.Color.White;
            this.butAddMLink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.butAddMLink.Font = new System.Drawing.Font("Product Sans", 10F);
            this.butAddMLink.ForeColor = System.Drawing.Color.Black;
            this.butAddMLink.Location = new System.Drawing.Point(261, 140);
            this.butAddMLink.Name = "butAddMLink";
            this.butAddMLink.Size = new System.Drawing.Size(28, 28);
            this.butAddMLink.TabIndex = 28;
            this.butAddMLink.Text = "+";
            this.butAddMLink.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.butAddMLink.UseVisualStyleBackColor = false;
            this.butAddMLink.Visible = false;
            // 
            // checkAPKLink
            // 
            this.checkAPKLink.AutoSize = true;
            this.checkAPKLink.Checked = true;
            this.checkAPKLink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkAPKLink.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkAPKLink.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.checkAPKLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkAPKLink.Font = new System.Drawing.Font("Product Sans", 10F);
            this.checkAPKLink.ForeColor = System.Drawing.Color.Lime;
            this.checkAPKLink.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkAPKLink.Location = new System.Drawing.Point(275, 86);
            this.checkAPKLink.Name = "checkAPKLink";
            this.checkAPKLink.Size = new System.Drawing.Size(14, 13);
            this.checkAPKLink.TabIndex = 27;
            this.checkAPKLink.UseMnemonic = false;
            this.checkAPKLink.UseVisualStyleBackColor = true;
            this.checkAPKLink.CheckedChanged += new System.EventHandler(this.checkAPKLink_CheckedChanged);
            // 
            // labelMirrorLink
            // 
            this.labelMirrorLink.AutoSize = true;
            this.labelMirrorLink.Font = new System.Drawing.Font("Product Sans", 10F);
            this.labelMirrorLink.ForeColor = System.Drawing.Color.White;
            this.labelMirrorLink.Location = new System.Drawing.Point(5, 144);
            this.labelMirrorLink.Name = "labelMirrorLink";
            this.labelMirrorLink.Size = new System.Drawing.Size(86, 26);
            this.labelMirrorLink.TabIndex = 19;
            this.labelMirrorLink.Text = "Mirror Link";
            this.labelMirrorLink.UseCompatibleTextRendering = true;
            // 
            // clistMirrorlink
            // 
            this.clistMirrorlink.BackColor = System.Drawing.Color.Black;
            this.clistMirrorlink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clistMirrorlink.ForeColor = System.Drawing.Color.White;
            this.clistMirrorlink.FormattingEnabled = true;
            this.clistMirrorlink.Items.AddRange(new object[] {
            "Test 1 Có dài quá không cho một hàng dài \\n /n Hello",
            "Test 2"});
            this.clistMirrorlink.Location = new System.Drawing.Point(5, 173);
            this.clistMirrorlink.Name = "clistMirrorlink";
            this.clistMirrorlink.Size = new System.Drawing.Size(284, 117);
            this.clistMirrorlink.TabIndex = 18;
            this.clistMirrorlink.TabStop = false;
            // 
            // labelAPKlink
            // 
            this.labelAPKlink.AutoSize = true;
            this.labelAPKlink.Font = new System.Drawing.Font("Product Sans", 10F);
            this.labelAPKlink.Location = new System.Drawing.Point(6, 82);
            this.labelAPKlink.Name = "labelAPKlink";
            this.labelAPKlink.Size = new System.Drawing.Size(76, 21);
            this.labelAPKlink.TabIndex = 17;
            this.labelAPKlink.Text = "APK only";
            // 
            // boxAPKlink
            // 
            this.boxAPKlink.AutoCompleteCustomSource.AddRange(new string[] {
            "Android 2.3+",
            "Android 4.0+",
            "Android 4.1+",
            "Android 5.0+",
            "Android 6.0+"});
            this.boxAPKlink.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.boxAPKlink.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxAPKlink.BackColor = System.Drawing.Color.Black;
            this.boxAPKlink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxAPKlink.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.boxAPKlink.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxAPKlink.ForeColor = System.Drawing.Color.White;
            this.boxAPKlink.Location = new System.Drawing.Point(5, 106);
            this.boxAPKlink.Name = "boxAPKlink";
            this.boxAPKlink.Size = new System.Drawing.Size(250, 28);
            this.boxAPKlink.TabIndex = 16;
            this.boxAPKlink.TextChanged += new System.EventHandler(this.boxAPKlink_TextChanged);
            this.boxAPKlink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boxAPKlink_KeyDown);
            this.boxAPKlink.Leave += new System.EventHandler(this.boxAPKlink_Leave);
            // 
            // labelDownload
            // 
            this.labelDownload.AutoSize = true;
            this.labelDownload.Font = new System.Drawing.Font("Product Sans", 10F);
            this.labelDownload.Location = new System.Drawing.Point(6, 26);
            this.labelDownload.Name = "labelDownload";
            this.labelDownload.Size = new System.Drawing.Size(86, 21);
            this.labelDownload.TabIndex = 15;
            this.labelDownload.Text = "Download";
            // 
            // boxDownLink
            // 
            this.boxDownLink.AutoCompleteCustomSource.AddRange(new string[] {
            "Android 2.3+",
            "Android 4.0+",
            "Android 4.1+",
            "Android 5.0+",
            "Android 6.0+"});
            this.boxDownLink.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.boxDownLink.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.boxDownLink.BackColor = System.Drawing.Color.Black;
            this.boxDownLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxDownLink.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.boxDownLink.Font = new System.Drawing.Font("Product Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxDownLink.ForeColor = System.Drawing.Color.White;
            this.boxDownLink.Location = new System.Drawing.Point(5, 50);
            this.boxDownLink.Name = "boxDownLink";
            this.boxDownLink.Size = new System.Drawing.Size(250, 28);
            this.boxDownLink.TabIndex = 14;
            this.boxDownLink.TextChanged += new System.EventHandler(this.boxDownLink_TextChanged);
            this.boxDownLink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.boxDownLink_KeyDown);
            this.boxDownLink.Leave += new System.EventHandler(this.boxDownLink_Leave);
            // 
            // boxSearchKey
            // 
            this.boxSearchKey.BackColor = System.Drawing.Color.Black;
            this.boxSearchKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxSearchKey.DetectUrls = false;
            this.boxSearchKey.Font = new System.Drawing.Font("SansSerif", 10.1F);
            this.boxSearchKey.ForeColor = System.Drawing.Color.White;
            this.boxSearchKey.Location = new System.Drawing.Point(313, 432);
            this.boxSearchKey.Name = "boxSearchKey";
            this.boxSearchKey.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.boxSearchKey.Size = new System.Drawing.Size(239, 86);
            this.boxSearchKey.TabIndex = 4;
            this.boxSearchKey.Text = "Lỗi thiệt hả?";
            this.boxSearchKey.TextChanged += new System.EventHandler(this.boxSearchKey_TextChanged);
            // 
            // labelSearchKey
            // 
            this.labelSearchKey.AutoSize = true;
            this.labelSearchKey.Font = new System.Drawing.Font("Product Sans", 10F);
            this.labelSearchKey.Location = new System.Drawing.Point(313, 405);
            this.labelSearchKey.Name = "labelSearchKey";
            this.labelSearchKey.Size = new System.Drawing.Size(138, 21);
            this.labelSearchKey.TabIndex = 14;
            this.labelSearchKey.Text = "Search Keywords";
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
            this.butModInfo.Font = new System.Drawing.Font("Product Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butModInfo.ForeColor = System.Drawing.Color.Lime;
            this.butModInfo.Location = new System.Drawing.Point(369, 524);
            this.butModInfo.Name = "butModInfo";
            this.butModInfo.Size = new System.Drawing.Size(135, 34);
            this.butModInfo.TabIndex = 5;
            this.butModInfo.Text = "MOD";
            this.butModInfo.UseVisualStyleBackColor = false;
            this.butModInfo.Click += new System.EventHandler(this.butModInfo_Click);
            // 
            // boxModInfo
            // 
            this.boxModInfo.BackColor = System.Drawing.Color.Black;
            this.boxModInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxModInfo.DetectUrls = false;
            this.boxModInfo.Font = new System.Drawing.Font("SansSerif", 10.15F);
            this.boxModInfo.ForeColor = System.Drawing.Color.White;
            this.boxModInfo.Location = new System.Drawing.Point(313, 564);
            this.boxModInfo.Name = "boxModInfo";
            this.boxModInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.boxModInfo.Size = new System.Drawing.Size(239, 139);
            this.boxModInfo.TabIndex = 6;
            this.boxModInfo.Text = "";
            this.boxModInfo.EnabledChanged += new System.EventHandler(this.boxModInfo_EnabledChanged);
            this.boxModInfo.TextChanged += new System.EventHandler(this.boxModInfo_TextChanged);
            // 
            // ilistScreenShot
            // 
            this.ilistScreenShot.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilistScreenShot.ImageStream")));
            this.ilistScreenShot.TransparentColor = System.Drawing.Color.Transparent;
            this.ilistScreenShot.Images.SetKeyName(0, "Avata desu ka.png");
            this.ilistScreenShot.Images.SetKeyName(1, "bb2w.png");
            // 
            // listImageReview
            // 
            this.listImageReview.BackColor = System.Drawing.Color.Black;
            this.listImageReview.ForeColor = System.Drawing.Color.White;
            this.listImageReview.HideSelection = false;
            this.listImageReview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.listImageReview.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listImageReview.LargeImageList = this.ilistScreenShot;
            this.listImageReview.Location = new System.Drawing.Point(6, 23);
            this.listImageReview.MultiSelect = false;
            this.listImageReview.Name = "listImageReview";
            this.listImageReview.Size = new System.Drawing.Size(160, 441);
            this.listImageReview.SmallImageList = this.ilistScreenShot;
            this.listImageReview.TabIndex = 17;
            this.listImageReview.TileSize = new System.Drawing.Size(155, 155);
            this.listImageReview.UseCompatibleStateImageBehavior = false;
            this.listImageReview.SelectedIndexChanged += new System.EventHandler(this.listImageReview_SelectedIndexChanged);
            // 
            // butDone
            // 
            this.butDone.BackColor = System.Drawing.Color.Black;
            this.butDone.BackgroundImage = global::MMBS.Properties.Resources.offlinemods_logo_pns;
            this.butDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.butDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDone.Font = new System.Drawing.Font("Product Sans", 12F);
            this.butDone.ForeColor = System.Drawing.Color.Yellow;
            this.butDone.Location = new System.Drawing.Point(565, 616);
            this.butDone.Name = "butDone";
            this.butDone.Size = new System.Drawing.Size(527, 79);
            this.butDone.TabIndex = 0;
            this.butDone.Text = "DONE";
            this.butDone.UseVisualStyleBackColor = false;
            this.butDone.Click += new System.EventHandler(this.butDone_Click);
            // 
            // boxVreview
            // 
            this.boxVreview.Image = global::MMBS.Properties.Resources._2000px_YouTube_full_color_icon__2017__svg;
            this.boxVreview.InitialImage = null;
            this.boxVreview.Location = new System.Drawing.Point(565, 487);
            this.boxVreview.Name = "boxVreview";
            this.boxVreview.Size = new System.Drawing.Size(160, 120);
            this.boxVreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boxVreview.TabIndex = 18;
            this.boxVreview.TabStop = false;
            this.boxVreview.Click += new System.EventHandler(this.boxVreview_Click);
            // 
            // boxVideoLink
            // 
            this.boxVideoLink.BackColor = System.Drawing.Color.Black;
            this.boxVideoLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxVideoLink.Font = new System.Drawing.Font("Product Sans", 7.8F);
            this.boxVideoLink.ForeColor = System.Drawing.Color.White;
            this.boxVideoLink.Location = new System.Drawing.Point(731, 584);
            this.boxVideoLink.Name = "boxVideoLink";
            this.boxVideoLink.Size = new System.Drawing.Size(352, 23);
            this.boxVideoLink.TabIndex = 8;
            this.boxVideoLink.TextChanged += new System.EventHandler(this.boxVideoLink_TextChanged);
            // 
            // labelVideo
            // 
            this.labelVideo.ActiveLinkColor = System.Drawing.Color.Yellow;
            this.labelVideo.AutoSize = true;
            this.labelVideo.DisabledLinkColor = System.Drawing.Color.Gray;
            this.labelVideo.Font = new System.Drawing.Font("Product Sans", 10F);
            this.labelVideo.LinkColor = System.Drawing.Color.White;
            this.labelVideo.Location = new System.Drawing.Point(733, 554);
            this.labelVideo.Name = "labelVideo";
            this.labelVideo.Size = new System.Drawing.Size(110, 21);
            this.labelVideo.TabIndex = 20;
            this.labelVideo.TabStop = true;
            this.labelVideo.Text = "Review Video";
            this.labelVideo.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelVideo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelVideo_LinkClicked);
            // 
            // butCacheFolder
            // 
            this.butCacheFolder.BackColor = System.Drawing.Color.Black;
            this.butCacheFolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.butCacheFolder.FlatAppearance.BorderSize = 2;
            this.butCacheFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCacheFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.butCacheFolder.Location = new System.Drawing.Point(990, 487);
            this.butCacheFolder.Name = "butCacheFolder";
            this.butCacheFolder.Size = new System.Drawing.Size(102, 31);
            this.butCacheFolder.TabIndex = 21;
            this.butCacheFolder.TabStop = false;
            this.butCacheFolder.Text = "Open Folder";
            this.butCacheFolder.UseVisualStyleBackColor = false;
            this.butCacheFolder.Click += new System.EventHandler(this.butCacheFolder_Click);
            // 
            // checkVideo
            // 
            this.checkVideo.AutoSize = true;
            this.checkVideo.Checked = true;
            this.checkVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkVideo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkVideo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.checkVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkVideo.Font = new System.Drawing.Font("Product Sans", 10F);
            this.checkVideo.ForeColor = System.Drawing.Color.Lime;
            this.checkVideo.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkVideo.Location = new System.Drawing.Point(1065, 558);
            this.checkVideo.Name = "checkVideo";
            this.checkVideo.Size = new System.Drawing.Size(14, 13);
            this.checkVideo.TabIndex = 22;
            this.checkVideo.TabStop = false;
            this.checkVideo.UseMnemonic = false;
            this.checkVideo.UseVisualStyleBackColor = true;
            this.checkVideo.CheckedChanged += new System.EventHandler(this.checkVideo_CheckedChanged);
            // 
            // groupImage
            // 
            this.groupImage.Controls.Add(this.webBrowser1);
            this.groupImage.Controls.Add(this.labelImageName);
            this.groupImage.Controls.Add(this.button1);
            this.groupImage.Controls.Add(this.checkImageinScript);
            this.groupImage.Controls.Add(this.checkImageUse);
            this.groupImage.Controls.Add(this.labelDuplicated);
            this.groupImage.Controls.Add(this.boxImageLink);
            this.groupImage.Controls.Add(this.boxImage);
            this.groupImage.Controls.Add(this.listImageReview);
            this.groupImage.Font = new System.Drawing.Font("Product Sans", 10F);
            this.groupImage.ForeColor = System.Drawing.Color.White;
            this.groupImage.Location = new System.Drawing.Point(565, 11);
            this.groupImage.Name = "groupImage";
            this.groupImage.Size = new System.Drawing.Size(527, 470);
            this.groupImage.TabIndex = 7;
            this.groupImage.TabStop = false;
            this.groupImage.Text = "Image";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(15, 316);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(145, 138);
            this.webBrowser1.TabIndex = 30;
            this.webBrowser1.Visible = false;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1_DocumentCompleted);
            // 
            // labelImageName
            // 
            this.labelImageName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelImageName.AutoSize = true;
            this.labelImageName.Location = new System.Drawing.Point(414, 254);
            this.labelImageName.Name = "labelImageName";
            this.labelImageName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelImageName.Size = new System.Drawing.Size(104, 21);
            this.labelImageName.TabIndex = 29;
            this.labelImageName.Text = "Image Name";
            this.labelImageName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelImageName.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Product Sans", 10F);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(500, -4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 28);
            this.button1.TabIndex = 29;
            this.button1.Text = "+";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // checkImageinScript
            // 
            this.checkImageinScript.AutoSize = true;
            this.checkImageinScript.Checked = true;
            this.checkImageinScript.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkImageinScript.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.checkImageinScript.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.checkImageinScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkImageinScript.Font = new System.Drawing.Font("Product Sans", 10F);
            this.checkImageinScript.ForeColor = System.Drawing.Color.Lime;
            this.checkImageinScript.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkImageinScript.Location = new System.Drawing.Point(152, 4);
            this.checkImageinScript.Name = "checkImageinScript";
            this.checkImageinScript.Size = new System.Drawing.Size(14, 13);
            this.checkImageinScript.TabIndex = 24;
            this.checkImageinScript.TabStop = false;
            this.checkImageinScript.UseMnemonic = false;
            this.checkImageinScript.UseVisualStyleBackColor = true;
            this.checkImageinScript.CheckedChanged += new System.EventHandler(this.CheckImageinScript_CheckedChanged);
            // 
            // checkImageUse
            // 
            this.checkImageUse.AutoSize = true;
            this.checkImageUse.Location = new System.Drawing.Point(170, 313);
            this.checkImageUse.Name = "checkImageUse";
            this.checkImageUse.Size = new System.Drawing.Size(60, 25);
            this.checkImageUse.TabIndex = 22;
            this.checkImageUse.TabStop = false;
            this.checkImageUse.Text = "Use";
            this.checkImageUse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkImageUse.UseVisualStyleBackColor = true;
            // 
            // labelDuplicated
            // 
            this.labelDuplicated.AutoSize = true;
            this.labelDuplicated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelDuplicated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDuplicated.Font = new System.Drawing.Font("Product Sans", 15F);
            this.labelDuplicated.ForeColor = System.Drawing.Color.Red;
            this.labelDuplicated.Location = new System.Drawing.Point(267, 444);
            this.labelDuplicated.Name = "labelDuplicated";
            this.labelDuplicated.Size = new System.Drawing.Size(135, 34);
            this.labelDuplicated.TabIndex = 21;
            this.labelDuplicated.Text = "Duplicated";
            this.labelDuplicated.Visible = false;
            // 
            // boxImageLink
            // 
            this.boxImageLink.BackColor = System.Drawing.Color.Black;
            this.boxImageLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boxImageLink.Font = new System.Drawing.Font("Product Sans", 7.8F);
            this.boxImageLink.ForeColor = System.Drawing.Color.White;
            this.boxImageLink.Location = new System.Drawing.Point(170, 281);
            this.boxImageLink.Name = "boxImageLink";
            this.boxImageLink.Size = new System.Drawing.Size(348, 23);
            this.boxImageLink.TabIndex = 20;
            this.boxImageLink.TabStop = false;
            // 
            // boxImage
            // 
            this.boxImage.Location = new System.Drawing.Point(172, 23);
            this.boxImage.Name = "boxImage";
            this.boxImage.Size = new System.Drawing.Size(346, 252);
            this.boxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.boxImage.TabIndex = 18;
            this.boxImage.TabStop = false;
            // 
            // FMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1104, 715);
            this.Controls.Add(this.groupImage);
            this.Controls.Add(this.checkVideo);
            this.Controls.Add(this.butCacheFolder);
            this.Controls.Add(this.labelVideo);
            this.Controls.Add(this.boxVideoLink);
            this.Controls.Add(this.boxVreview);
            this.Controls.Add(this.butDone);
            this.Controls.Add(this.boxModInfo);
            this.Controls.Add(this.butModInfo);
            this.Controls.Add(this.labelSearchKey);
            this.Controls.Add(this.boxSearchKey);
            this.Controls.Add(this.groupLink);
            this.Controls.Add(this.groupInfo);
            this.Font = new System.Drawing.Font("Product Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FMForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Full Manual Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FMForm_FormClosed);
            this.Load += new System.EventHandler(this.FMForm_Load);
            this.VisibleChanged += new System.EventHandler(this.FMForm_VisibleChanged);
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxIcon)).EndInit();
            this.groupLink.ResumeLayout(false);
            this.groupLink.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxVreview)).EndInit();
            this.groupImage.ResumeLayout(false);
            this.groupImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.boxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox boxAppname;
        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.PictureBox boxIcon;
        private System.Windows.Forms.TextBox boxVersion;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.TextBox boxSize;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.RichTextBox boxDescription;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.TextBox boxSource;
        private System.Windows.Forms.CheckBox checkRoot;
        private System.Windows.Forms.CheckBox checkInternet;
        private System.Windows.Forms.Label labelAReq;
        private System.Windows.Forms.TextBox boxAReq;
        private System.Windows.Forms.GroupBox groupLink;
        private System.Windows.Forms.RichTextBox boxSearchKey;
        private System.Windows.Forms.Label labelSearchKey;
        private System.Windows.Forms.Button butModInfo;
        private System.Windows.Forms.RichTextBox boxModInfo;
        private System.Windows.Forms.Label labelMirrorLink;
        private System.Windows.Forms.CheckedListBox clistMirrorlink;
        private System.Windows.Forms.Label labelAPKlink;
        private System.Windows.Forms.TextBox boxAPKlink;
        private System.Windows.Forms.Label labelDownload;
        private System.Windows.Forms.TextBox boxDownLink;
        private System.Windows.Forms.ImageList ilistScreenShot;
        private System.Windows.Forms.ListView listImageReview;
        private System.Windows.Forms.Button butDone;
        private System.Windows.Forms.PictureBox boxVreview;
        private System.Windows.Forms.TextBox boxVideoLink;
        private System.Windows.Forms.LinkLabel labelVideo;
        private System.Windows.Forms.Button butCacheFolder;
        private System.Windows.Forms.CheckBox checkVideo;
        private System.Windows.Forms.GroupBox groupImage;
        private System.Windows.Forms.TextBox boxImageLink;
        private System.Windows.Forms.PictureBox boxImage;
        private System.Windows.Forms.CheckBox checkImageinScript;
        private System.Windows.Forms.CheckBox checkImageUse;
        private System.Windows.Forms.Label labelDuplicated;
        private System.Windows.Forms.CheckBox checkNoLine;
        private System.Windows.Forms.CheckBox checkABold;
        private System.Windows.Forms.CheckBox checkAPKLink;
        private System.Windows.Forms.Button butAddMLink;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button butMAPK;
        private System.Windows.Forms.Button butMDown;
        private System.Windows.Forms.Label labelImageName;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}