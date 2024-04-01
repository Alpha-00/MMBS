namespace MMBS
{
    partial class TemplateToolForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateToolForm));
			this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
			this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
			this.groupController = new System.Windows.Forms.GroupBox();
			this.panelStatus = new System.Windows.Forms.Panel();
			this.textStatus = new System.Windows.Forms.Label();
			this.binder = new System.Windows.Forms.BindingSource(this.components);
			this.sp1 = new System.Windows.Forms.Panel();
			this.labelStatus = new System.Windows.Forms.Label();
			this.sp2 = new System.Windows.Forms.Panel();
			this.butForce = new System.Windows.Forms.Button();
			this.butStop = new System.Windows.Forms.Button();
			this.butStart = new System.Windows.Forms.Button();
			this.groupPath = new System.Windows.Forms.GroupBox();
			this.butOpenOutput = new System.Windows.Forms.Button();
			this.butOpenData = new System.Windows.Forms.Button();
			this.butOpenTemplate = new System.Windows.Forms.Button();
			this.compOutputPath = new System.Windows.Forms.GroupBox();
			this.butOutputPath = new System.Windows.Forms.Button();
			this.boxOutputPath = new System.Windows.Forms.TextBox();
			this.compDataPath = new System.Windows.Forms.GroupBox();
			this.butDataPath = new System.Windows.Forms.Button();
			this.boxDataPath = new System.Windows.Forms.TextBox();
			this.compTemplateFolder = new System.Windows.Forms.GroupBox();
			this.butTemplatePath = new System.Windows.Forms.Button();
			this.boxTemplatePath = new System.Windows.Forms.TextBox();
			this.groupTarget = new System.Windows.Forms.GroupBox();
			this.compSelectData = new System.Windows.Forms.GroupBox();
			this.boxSelectData = new System.Windows.Forms.ListView();
			this.compSelectTemplate = new System.Windows.Forms.GroupBox();
			this.boxSelectTemplate = new System.Windows.Forms.ComboBox();
			this.groupLogs = new System.Windows.Forms.GroupBox();
			this.boxActiviesLog = new System.Windows.Forms.RichTextBox();
			this.groupUtils = new System.Windows.Forms.GroupBox();
			this.butBackupTemplate = new System.Windows.Forms.Button();
			this.butImportDataZip = new System.Windows.Forms.Button();
			this.butClearLogs = new System.Windows.Forms.Button();
			this.butLoadDefaults = new System.Windows.Forms.Button();
			this.butOpenInBrowser = new System.Windows.Forms.Button();
			this.templateFilesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.templateFilesBinder = new System.Windows.Forms.BindingSource(this.components);
			this.flowLayout.SuspendLayout();
			this.groupController.SuspendLayout();
			this.panelStatus.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.binder)).BeginInit();
			this.groupPath.SuspendLayout();
			this.compOutputPath.SuspendLayout();
			this.compDataPath.SuspendLayout();
			this.compTemplateFolder.SuspendLayout();
			this.groupTarget.SuspendLayout();
			this.compSelectData.SuspendLayout();
			this.compSelectTemplate.SuspendLayout();
			this.groupLogs.SuspendLayout();
			this.groupUtils.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.templateFilesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.templateFilesBinder)).BeginInit();
			this.SuspendLayout();
			// 
			// folderBrowser
			// 
			this.folderBrowser.SelectedPath = "C:\\BloggerSupporter";
			// 
			// flowLayout
			// 
			this.flowLayout.Controls.Add(this.groupController);
			this.flowLayout.Controls.Add(this.groupPath);
			this.flowLayout.Controls.Add(this.groupTarget);
			this.flowLayout.Controls.Add(this.groupLogs);
			this.flowLayout.Controls.Add(this.groupUtils);
			this.flowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayout.Location = new System.Drawing.Point(0, 0);
			this.flowLayout.Name = "flowLayout";
			this.flowLayout.Size = new System.Drawing.Size(708, 530);
			this.flowLayout.TabIndex = 0;
			// 
			// groupController
			// 
			this.groupController.Controls.Add(this.panelStatus);
			this.groupController.Controls.Add(this.butForce);
			this.groupController.Controls.Add(this.butStop);
			this.groupController.Controls.Add(this.butStart);
			this.groupController.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupController.Location = new System.Drawing.Point(3, 3);
			this.groupController.Name = "groupController";
			this.groupController.Size = new System.Drawing.Size(200, 194);
			this.groupController.TabIndex = 0;
			this.groupController.TabStop = false;
			this.groupController.Text = "Controller";
			// 
			// panelStatus
			// 
			this.panelStatus.Controls.Add(this.textStatus);
			this.panelStatus.Controls.Add(this.sp1);
			this.panelStatus.Controls.Add(this.labelStatus);
			this.panelStatus.Controls.Add(this.sp2);
			this.panelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelStatus.Location = new System.Drawing.Point(3, 138);
			this.panelStatus.Name = "panelStatus";
			this.panelStatus.Size = new System.Drawing.Size(194, 53);
			this.panelStatus.TabIndex = 2;
			// 
			// textStatus
			// 
			this.textStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.binder, "isRunning", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.textStatus.Dock = System.Windows.Forms.DockStyle.Top;
			this.textStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textStatus.Location = new System.Drawing.Point(0, 32);
			this.textStatus.Name = "textStatus";
			this.textStatus.Size = new System.Drawing.Size(194, 16);
			this.textStatus.TabIndex = 2;
			this.textStatus.Text = "STOP";
			this.textStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.textStatus.TextChanged += new System.EventHandler(this.textStatus_TextChanged);
			// 
			// binder
			// 
			this.binder.AllowNew = false;
			this.binder.DataSource = typeof(MMBS.CustomPostTemplateModel);
			// 
			// sp1
			// 
			this.sp1.Dock = System.Windows.Forms.DockStyle.Top;
			this.sp1.Location = new System.Drawing.Point(0, 28);
			this.sp1.Name = "sp1";
			this.sp1.Size = new System.Drawing.Size(194, 4);
			this.sp1.TabIndex = 2;
			// 
			// labelStatus
			// 
			this.labelStatus.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelStatus.Location = new System.Drawing.Point(0, 12);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(194, 16);
			this.labelStatus.TabIndex = 0;
			this.labelStatus.Text = "STATUS";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// sp2
			// 
			this.sp2.Dock = System.Windows.Forms.DockStyle.Top;
			this.sp2.Location = new System.Drawing.Point(0, 0);
			this.sp2.Name = "sp2";
			this.sp2.Size = new System.Drawing.Size(194, 12);
			this.sp2.TabIndex = 1;
			// 
			// butForce
			// 
			this.butForce.Dock = System.Windows.Forms.DockStyle.Top;
			this.butForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.butForce.Location = new System.Drawing.Point(3, 98);
			this.butForce.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.butForce.MinimumSize = new System.Drawing.Size(0, 40);
			this.butForce.Name = "butForce";
			this.butForce.Size = new System.Drawing.Size(194, 40);
			this.butForce.TabIndex = 1;
			this.butForce.Text = "Force Update";
			this.butForce.UseVisualStyleBackColor = true;
			this.butForce.Click += new System.EventHandler(this.butForce_Click);
			// 
			// butStop
			// 
			this.butStop.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStop.Enabled = false;
			this.butStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.butStop.Location = new System.Drawing.Point(3, 58);
			this.butStop.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.butStop.MinimumSize = new System.Drawing.Size(0, 40);
			this.butStop.Name = "butStop";
			this.butStop.Size = new System.Drawing.Size(194, 40);
			this.butStop.TabIndex = 3;
			this.butStop.Text = "Stop";
			this.butStop.UseVisualStyleBackColor = true;
			this.butStop.Click += new System.EventHandler(this.butStop_Click);
			// 
			// butStart
			// 
			this.butStart.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.binder, "isNotRunning", true));
			this.butStart.Dock = System.Windows.Forms.DockStyle.Top;
			this.butStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.butStart.Location = new System.Drawing.Point(3, 18);
			this.butStart.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
			this.butStart.MinimumSize = new System.Drawing.Size(0, 40);
			this.butStart.Name = "butStart";
			this.butStart.Size = new System.Drawing.Size(194, 40);
			this.butStart.TabIndex = 0;
			this.butStart.Text = "Start";
			this.butStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.butStart.UseVisualStyleBackColor = true;
			this.butStart.EnabledChanged += new System.EventHandler(this.butStart_EnabledChanged);
			this.butStart.Click += new System.EventHandler(this.butStart_Click);
			// 
			// groupPath
			// 
			this.groupPath.Controls.Add(this.butOpenOutput);
			this.groupPath.Controls.Add(this.butOpenData);
			this.groupPath.Controls.Add(this.butOpenTemplate);
			this.groupPath.Controls.Add(this.compOutputPath);
			this.groupPath.Controls.Add(this.compDataPath);
			this.groupPath.Controls.Add(this.compTemplateFolder);
			this.groupPath.Location = new System.Drawing.Point(209, 3);
			this.groupPath.MinimumSize = new System.Drawing.Size(100, 20);
			this.groupPath.Name = "groupPath";
			this.groupPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.groupPath.Size = new System.Drawing.Size(493, 194);
			this.groupPath.TabIndex = 1;
			this.groupPath.TabStop = false;
			this.groupPath.Text = "Path";
			// 
			// butOpenOutput
			// 
			this.butOpenOutput.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.binder, "outputDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.butOpenOutput.Location = new System.Drawing.Point(368, 162);
			this.butOpenOutput.Name = "butOpenOutput";
			this.butOpenOutput.Size = new System.Drawing.Size(110, 26);
			this.butOpenOutput.TabIndex = 7;
			this.butOpenOutput.Text = "Open Output Folder";
			this.butOpenOutput.UseVisualStyleBackColor = true;
			this.butOpenOutput.Click += new System.EventHandler(this.butOpenOutput_Click);
			// 
			// butOpenData
			// 
			this.butOpenData.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.binder, "dataDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.butOpenData.Location = new System.Drawing.Point(187, 162);
			this.butOpenData.Name = "butOpenData";
			this.butOpenData.Size = new System.Drawing.Size(175, 26);
			this.butOpenData.TabIndex = 6;
			this.butOpenData.Text = "Open Data Folder";
			this.butOpenData.UseVisualStyleBackColor = true;
			this.butOpenData.Click += new System.EventHandler(this.butOpenData_Click);
			// 
			// butOpenTemplate
			// 
			this.butOpenTemplate.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.binder, "templateDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.butOpenTemplate.Location = new System.Drawing.Point(6, 162);
			this.butOpenTemplate.Name = "butOpenTemplate";
			this.butOpenTemplate.Size = new System.Drawing.Size(175, 26);
			this.butOpenTemplate.TabIndex = 1;
			this.butOpenTemplate.Text = "Open Template Folder";
			this.butOpenTemplate.UseVisualStyleBackColor = true;
			this.butOpenTemplate.Click += new System.EventHandler(this.butOpenTemplate_Click);
			// 
			// compOutputPath
			// 
			this.compOutputPath.Controls.Add(this.butOutputPath);
			this.compOutputPath.Controls.Add(this.boxOutputPath);
			this.compOutputPath.Dock = System.Windows.Forms.DockStyle.Top;
			this.compOutputPath.Location = new System.Drawing.Point(3, 110);
			this.compOutputPath.Name = "compOutputPath";
			this.compOutputPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.compOutputPath.Size = new System.Drawing.Size(487, 46);
			this.compOutputPath.TabIndex = 5;
			this.compOutputPath.TabStop = false;
			this.compOutputPath.Text = "Output Folder";
			// 
			// butOutputPath
			// 
			this.butOutputPath.Location = new System.Drawing.Point(435, 17);
			this.butOutputPath.Name = "butOutputPath";
			this.butOutputPath.Size = new System.Drawing.Size(40, 28);
			this.butOutputPath.TabIndex = 3;
			this.butOutputPath.Text = "...";
			this.butOutputPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.butOutputPath.UseVisualStyleBackColor = true;
			this.butOutputPath.Click += new System.EventHandler(this.butOutputPath_Click);
			// 
			// boxOutputPath
			// 
			this.boxOutputPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.binder, "outputDir", true));
			this.boxOutputPath.Dock = System.Windows.Forms.DockStyle.Left;
			this.boxOutputPath.Location = new System.Drawing.Point(3, 18);
			this.boxOutputPath.Name = "boxOutputPath";
			this.boxOutputPath.Size = new System.Drawing.Size(426, 22);
			this.boxOutputPath.TabIndex = 0;
			// 
			// compDataPath
			// 
			this.compDataPath.Controls.Add(this.butDataPath);
			this.compDataPath.Controls.Add(this.boxDataPath);
			this.compDataPath.Dock = System.Windows.Forms.DockStyle.Top;
			this.compDataPath.Location = new System.Drawing.Point(3, 64);
			this.compDataPath.Name = "compDataPath";
			this.compDataPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.compDataPath.Size = new System.Drawing.Size(487, 46);
			this.compDataPath.TabIndex = 4;
			this.compDataPath.TabStop = false;
			this.compDataPath.Text = "Data Folder";
			// 
			// butDataPath
			// 
			this.butDataPath.Location = new System.Drawing.Point(435, 17);
			this.butDataPath.Name = "butDataPath";
			this.butDataPath.Size = new System.Drawing.Size(40, 28);
			this.butDataPath.TabIndex = 3;
			this.butDataPath.Text = "...";
			this.butDataPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.butDataPath.UseVisualStyleBackColor = true;
			this.butDataPath.Click += new System.EventHandler(this.butDataPath_Click);
			// 
			// boxDataPath
			// 
			this.boxDataPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.binder, "dataDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.boxDataPath.Dock = System.Windows.Forms.DockStyle.Left;
			this.boxDataPath.Location = new System.Drawing.Point(3, 18);
			this.boxDataPath.Name = "boxDataPath";
			this.boxDataPath.Size = new System.Drawing.Size(426, 22);
			this.boxDataPath.TabIndex = 0;
			// 
			// compTemplateFolder
			// 
			this.compTemplateFolder.Controls.Add(this.butTemplatePath);
			this.compTemplateFolder.Controls.Add(this.boxTemplatePath);
			this.compTemplateFolder.Dock = System.Windows.Forms.DockStyle.Top;
			this.compTemplateFolder.Location = new System.Drawing.Point(3, 18);
			this.compTemplateFolder.Name = "compTemplateFolder";
			this.compTemplateFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.compTemplateFolder.Size = new System.Drawing.Size(487, 46);
			this.compTemplateFolder.TabIndex = 2;
			this.compTemplateFolder.TabStop = false;
			this.compTemplateFolder.Text = "Template Folder";
			// 
			// butTemplatePath
			// 
			this.butTemplatePath.Location = new System.Drawing.Point(435, 17);
			this.butTemplatePath.Name = "butTemplatePath";
			this.butTemplatePath.Size = new System.Drawing.Size(40, 28);
			this.butTemplatePath.TabIndex = 3;
			this.butTemplatePath.Text = "...";
			this.butTemplatePath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.butTemplatePath.UseVisualStyleBackColor = true;
			this.butTemplatePath.Click += new System.EventHandler(this.butTemplatePath_Click);
			// 
			// boxTemplatePath
			// 
			this.boxTemplatePath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.binder, "templateDir", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.boxTemplatePath.Dock = System.Windows.Forms.DockStyle.Left;
			this.boxTemplatePath.Location = new System.Drawing.Point(3, 18);
			this.boxTemplatePath.Name = "boxTemplatePath";
			this.boxTemplatePath.Size = new System.Drawing.Size(426, 22);
			this.boxTemplatePath.TabIndex = 0;
			this.boxTemplatePath.TextChanged += new System.EventHandler(this.boxTemplatePath_TextChanged);
			// 
			// groupTarget
			// 
			this.groupTarget.Controls.Add(this.compSelectData);
			this.groupTarget.Controls.Add(this.compSelectTemplate);
			this.groupTarget.Location = new System.Drawing.Point(3, 203);
			this.groupTarget.Name = "groupTarget";
			this.groupTarget.Size = new System.Drawing.Size(200, 319);
			this.groupTarget.TabIndex = 2;
			this.groupTarget.TabStop = false;
			this.groupTarget.Text = "Target";
			// 
			// compSelectData
			// 
			this.compSelectData.Controls.Add(this.boxSelectData);
			this.compSelectData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.compSelectData.Location = new System.Drawing.Point(3, 70);
			this.compSelectData.Name = "compSelectData";
			this.compSelectData.Size = new System.Drawing.Size(194, 246);
			this.compSelectData.TabIndex = 2;
			this.compSelectData.TabStop = false;
			this.compSelectData.Text = "Data";
			// 
			// boxSelectData
			// 
			this.boxSelectData.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.boxSelectData.BackColor = System.Drawing.SystemColors.Control;
			this.boxSelectData.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.boxSelectData.CausesValidation = false;
			this.boxSelectData.CheckBoxes = true;
			this.boxSelectData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.boxSelectData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.boxSelectData.HideSelection = false;
			this.boxSelectData.Location = new System.Drawing.Point(3, 18);
			this.boxSelectData.Name = "boxSelectData";
			this.boxSelectData.Size = new System.Drawing.Size(188, 225);
			this.boxSelectData.TabIndex = 0;
			this.boxSelectData.UseCompatibleStateImageBehavior = false;
			this.boxSelectData.View = System.Windows.Forms.View.List;
			this.boxSelectData.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.boxSelectData_ItemChecked);
			this.boxSelectData.SelectedIndexChanged += new System.EventHandler(this.boxSelectData_SelectedIndexChanged);
			// 
			// compSelectTemplate
			// 
			this.compSelectTemplate.Controls.Add(this.boxSelectTemplate);
			this.compSelectTemplate.Dock = System.Windows.Forms.DockStyle.Top;
			this.compSelectTemplate.Location = new System.Drawing.Point(3, 18);
			this.compSelectTemplate.Name = "compSelectTemplate";
			this.compSelectTemplate.Size = new System.Drawing.Size(194, 52);
			this.compSelectTemplate.TabIndex = 1;
			this.compSelectTemplate.TabStop = false;
			this.compSelectTemplate.Text = "Template";
			// 
			// boxSelectTemplate
			// 
			this.boxSelectTemplate.Dock = System.Windows.Forms.DockStyle.Top;
			this.boxSelectTemplate.Location = new System.Drawing.Point(3, 18);
			this.boxSelectTemplate.Name = "boxSelectTemplate";
			this.boxSelectTemplate.Size = new System.Drawing.Size(188, 24);
			this.boxSelectTemplate.TabIndex = 0;
			this.boxSelectTemplate.SelectedIndexChanged += new System.EventHandler(this.boxSelectTemplate_SelectedIndexChanged);
			// 
			// groupLogs
			// 
			this.groupLogs.Controls.Add(this.boxActiviesLog);
			this.groupLogs.Location = new System.Drawing.Point(209, 203);
			this.groupLogs.Name = "groupLogs";
			this.groupLogs.Size = new System.Drawing.Size(362, 319);
			this.groupLogs.TabIndex = 3;
			this.groupLogs.TabStop = false;
			this.groupLogs.Text = "Activity Logs";
			// 
			// boxActiviesLog
			// 
			this.boxActiviesLog.BackColor = System.Drawing.SystemColors.Control;
			this.boxActiviesLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.boxActiviesLog.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.boxActiviesLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.boxActiviesLog.Location = new System.Drawing.Point(3, 18);
			this.boxActiviesLog.Name = "boxActiviesLog";
			this.boxActiviesLog.ReadOnly = true;
			this.boxActiviesLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.boxActiviesLog.Size = new System.Drawing.Size(356, 298);
			this.boxActiviesLog.TabIndex = 0;
			this.boxActiviesLog.Text = "";
			this.boxActiviesLog.SelectionChanged += new System.EventHandler(this.boxActiviesLog_SelectionChanged);
			this.boxActiviesLog.TextChanged += new System.EventHandler(this.boxActiviesLog_TextChanged);
			// 
			// groupUtils
			// 
			this.groupUtils.Controls.Add(this.butBackupTemplate);
			this.groupUtils.Controls.Add(this.butImportDataZip);
			this.groupUtils.Controls.Add(this.butClearLogs);
			this.groupUtils.Controls.Add(this.butLoadDefaults);
			this.groupUtils.Controls.Add(this.butOpenInBrowser);
			this.groupUtils.Location = new System.Drawing.Point(577, 203);
			this.groupUtils.Name = "groupUtils";
			this.groupUtils.Size = new System.Drawing.Size(122, 319);
			this.groupUtils.TabIndex = 4;
			this.groupUtils.TabStop = false;
			this.groupUtils.Text = "Utilities";
			// 
			// butBackupTemplate
			// 
			this.butBackupTemplate.Dock = System.Windows.Forms.DockStyle.Top;
			this.butBackupTemplate.Location = new System.Drawing.Point(3, 190);
			this.butBackupTemplate.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
			this.butBackupTemplate.Name = "butBackupTemplate";
			this.butBackupTemplate.Size = new System.Drawing.Size(116, 51);
			this.butBackupTemplate.TabIndex = 4;
			this.butBackupTemplate.Text = "Backup Template";
			this.butBackupTemplate.UseVisualStyleBackColor = true;
			this.butBackupTemplate.Click += new System.EventHandler(this.butBackupTemplate_Click);
			// 
			// butImportDataZip
			// 
			this.butImportDataZip.Dock = System.Windows.Forms.DockStyle.Top;
			this.butImportDataZip.Enabled = false;
			this.butImportDataZip.Location = new System.Drawing.Point(3, 150);
			this.butImportDataZip.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
			this.butImportDataZip.Name = "butImportDataZip";
			this.butImportDataZip.Size = new System.Drawing.Size(116, 40);
			this.butImportDataZip.TabIndex = 3;
			this.butImportDataZip.Text = "Import Data Zip";
			this.butImportDataZip.UseVisualStyleBackColor = true;
			// 
			// butClearLogs
			// 
			this.butClearLogs.Dock = System.Windows.Forms.DockStyle.Top;
			this.butClearLogs.Location = new System.Drawing.Point(3, 110);
			this.butClearLogs.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
			this.butClearLogs.Name = "butClearLogs";
			this.butClearLogs.Size = new System.Drawing.Size(116, 40);
			this.butClearLogs.TabIndex = 2;
			this.butClearLogs.Text = "Clear Logs";
			this.butClearLogs.UseVisualStyleBackColor = true;
			this.butClearLogs.Click += new System.EventHandler(this.butClearLogs_Click);
			// 
			// butLoadDefaults
			// 
			this.butLoadDefaults.Dock = System.Windows.Forms.DockStyle.Top;
			this.butLoadDefaults.Location = new System.Drawing.Point(3, 70);
			this.butLoadDefaults.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
			this.butLoadDefaults.Name = "butLoadDefaults";
			this.butLoadDefaults.Size = new System.Drawing.Size(116, 40);
			this.butLoadDefaults.TabIndex = 1;
			this.butLoadDefaults.Text = "Load Defaults";
			this.butLoadDefaults.UseVisualStyleBackColor = true;
			this.butLoadDefaults.Click += new System.EventHandler(this.butLoadDefaults_Click);
			// 
			// butOpenInBrowser
			// 
			this.butOpenInBrowser.Dock = System.Windows.Forms.DockStyle.Top;
			this.butOpenInBrowser.Enabled = false;
			this.butOpenInBrowser.Location = new System.Drawing.Point(3, 18);
			this.butOpenInBrowser.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
			this.butOpenInBrowser.Name = "butOpenInBrowser";
			this.butOpenInBrowser.Size = new System.Drawing.Size(116, 52);
			this.butOpenInBrowser.TabIndex = 0;
			this.butOpenInBrowser.Text = "Open in Browser";
			this.butOpenInBrowser.UseVisualStyleBackColor = true;
			this.butOpenInBrowser.Click += new System.EventHandler(this.butOpenInBrowser_Click);
			// 
			// templateFilesBindingSource
			// 
			this.templateFilesBindingSource.DataMember = "templateFiles";
			this.templateFilesBindingSource.DataSource = this.binder;
			// 
			// templateFilesBinder
			// 
			this.templateFilesBinder.DataMember = "templateFiles";
			this.templateFilesBinder.DataSource = this.binder;
			// 
			// TemplateToolForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(708, 530);
			this.Controls.Add(this.flowLayout);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TemplateToolForm";
			this.Text = "Template Tool";
			this.flowLayout.ResumeLayout(false);
			this.groupController.ResumeLayout(false);
			this.panelStatus.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.binder)).EndInit();
			this.groupPath.ResumeLayout(false);
			this.compOutputPath.ResumeLayout(false);
			this.compOutputPath.PerformLayout();
			this.compDataPath.ResumeLayout(false);
			this.compDataPath.PerformLayout();
			this.compTemplateFolder.ResumeLayout(false);
			this.compTemplateFolder.PerformLayout();
			this.groupTarget.ResumeLayout(false);
			this.compSelectData.ResumeLayout(false);
			this.compSelectTemplate.ResumeLayout(false);
			this.groupLogs.ResumeLayout(false);
			this.groupUtils.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.templateFilesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.templateFilesBinder)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.GroupBox groupController;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.GroupBox groupPath;
        private System.Windows.Forms.TextBox boxTemplatePath;
        private System.Windows.Forms.Button butOpenTemplate;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button butForce;
        private System.Windows.Forms.Panel sp2;
        private System.Windows.Forms.Label textStatus;
        private System.Windows.Forms.Panel sp1;
        private System.Windows.Forms.GroupBox compTemplateFolder;
        private System.Windows.Forms.Button butTemplatePath;
        private System.Windows.Forms.GroupBox compOutputPath;
        private System.Windows.Forms.Button butOutputPath;
        private System.Windows.Forms.TextBox boxOutputPath;
        private System.Windows.Forms.GroupBox compDataPath;
        private System.Windows.Forms.Button butDataPath;
        private System.Windows.Forms.TextBox boxDataPath;
        private System.Windows.Forms.Button butOpenOutput;
        private System.Windows.Forms.Button butOpenData;
        private System.Windows.Forms.Button butStop;
        private System.Windows.Forms.GroupBox groupTarget;
        private System.Windows.Forms.GroupBox compSelectTemplate;
        private System.Windows.Forms.ComboBox boxSelectTemplate;
        private System.Windows.Forms.GroupBox compSelectData;
        private System.Windows.Forms.GroupBox groupLogs;
        private System.Windows.Forms.GroupBox groupUtils;
        private System.Windows.Forms.RichTextBox boxActiviesLog;
        private System.Windows.Forms.Button butImportDataZip;
        private System.Windows.Forms.Button butClearLogs;
        private System.Windows.Forms.Button butLoadDefaults;
        private System.Windows.Forms.Button butOpenInBrowser;
        private System.Windows.Forms.Button butBackupTemplate;
        private System.Windows.Forms.BindingSource binder;
        private System.Windows.Forms.BindingSource templateFilesBinder;
        private System.Windows.Forms.ListView boxSelectData;
        private System.Windows.Forms.BindingSource templateFilesBindingSource;
    }
}