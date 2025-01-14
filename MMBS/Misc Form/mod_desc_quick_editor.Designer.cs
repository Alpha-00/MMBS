namespace MMBS.Misc_Form
{
    partial class ModDescriptionQuickEditor
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
			this.contentList = new System.Windows.Forms.CheckedListBox();
			this.mainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.templateList = new System.Windows.Forms.ListBox();
			this.mainLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// contentList
			// 
			this.contentList.CheckOnClick = true;
			this.contentList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentList.FormattingEnabled = true;
			this.contentList.Items.AddRange(new object[] {
            "Vô hạn vàng",
            "Vô hạn xu",
            "Vô hạn tiền",
            "Vô hạn kim cương",
            "Vô hạn ngọc",
            "Vô hạn đạn",
            "Mở khóa súng",
            "Mở khóa nhân vật",
            "Xóa quảng cáo"});
			this.contentList.Location = new System.Drawing.Point(8, 8);
			this.contentList.Name = "contentList";
			this.contentList.ScrollAlwaysVisible = true;
			this.contentList.Size = new System.Drawing.Size(268, 284);
			this.contentList.TabIndex = 1;
			this.contentList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.contentList_ItemCheck);
			// 
			// mainLayoutPanel
			// 
			this.mainLayoutPanel.ColumnCount = 2;
			this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
			this.mainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
			this.mainLayoutPanel.Controls.Add(this.contentList, 0, 0);
			this.mainLayoutPanel.Controls.Add(this.templateList, 1, 0);
			this.mainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.mainLayoutPanel.Name = "mainLayoutPanel";
			this.mainLayoutPanel.Padding = new System.Windows.Forms.Padding(5);
			this.mainLayoutPanel.RowCount = 1;
			this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.mainLayoutPanel.Size = new System.Drawing.Size(419, 300);
			this.mainLayoutPanel.TabIndex = 2;
			this.mainLayoutPanel.MouseLeave += new System.EventHandler(this.mainLayoutPanel_MouseLeave);
			// 
			// templateList
			// 
			this.templateList.BackColor = System.Drawing.SystemColors.Control;
			this.templateList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.templateList.FormattingEnabled = true;
			this.templateList.ItemHeight = 16;
			this.templateList.Items.AddRange(new object[] {
            "- (content).\\n",
            "(content).\\n",
            "(content), "});
			this.templateList.Location = new System.Drawing.Point(282, 8);
			this.templateList.Name = "templateList";
			this.templateList.Size = new System.Drawing.Size(129, 284);
			this.templateList.TabIndex = 5;
			this.templateList.SelectedIndexChanged += new System.EventHandler(this.templateList_SelectedIndexChanged);
			// 
			// ModDescriptionQuickEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(419, 300);
			this.Controls.Add(this.mainLayoutPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximumSize = new System.Drawing.Size(419, 300);
			this.MinimumSize = new System.Drawing.Size(100, 100);
			this.Name = "ModDescriptionQuickEditor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "mod_desc_quick_editor";
			this.VisibleChanged += new System.EventHandler(this.ModDescriptionQuickEditor_VisibleChanged);
			this.MouseLeave += new System.EventHandler(this.mod_desc_quick_editor_MouseLeave);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ModDescriptionQuickEditor_MouseMove);
			this.mainLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel mainLayoutPanel;
        private System.Windows.Forms.ListBox templateList;
        private System.Windows.Forms.CheckedListBox contentList;
    }
}