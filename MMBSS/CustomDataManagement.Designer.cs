namespace MMBS
{
    partial class CustomDataManager
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.datatable = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.butSave = new System.Windows.Forms.Button();
            this.table_addrow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datatable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Custom Data";
            // 
            // datatable
            // 
            this.datatable.AllowUserToOrderColumns = true;
            this.datatable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datatable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.datatable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.datatable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datatable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Data});
            this.datatable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.datatable.Location = new System.Drawing.Point(12, 72);
            this.datatable.Name = "datatable";
            this.datatable.RowHeadersWidth = 51;
            this.datatable.RowTemplate.Height = 24;
            this.datatable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.datatable.Size = new System.Drawing.Size(457, 357);
            this.datatable.TabIndex = 2;
            this.datatable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datatable_CellContentClick);
            // 
            // Name
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.DefaultCellStyle = dataGridViewCellStyle1;
            this.Name.HeaderText = "Properties";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.MinimumWidth = 6;
            this.Data.Name = "Data";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(295, 13);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(174, 45);
            this.butSave.TabIndex = 3;
            this.butSave.Text = "Save and Close";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // table_addrow
            // 
            this.table_addrow.Location = new System.Drawing.Point(366, 436);
            this.table_addrow.Name = "table_addrow";
            this.table_addrow.Size = new System.Drawing.Size(102, 33);
            this.table_addrow.TabIndex = 4;
            this.table_addrow.Text = "Add Row";
            this.table_addrow.UseVisualStyleBackColor = true;
            this.table_addrow.Click += new System.EventHandler(this.button2_Click);
            // 
            // CustomDataManager
            // 
            this.ClientSize = new System.Drawing.Size(481, 481);
            this.Controls.Add(this.table_addrow);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.datatable);
            this.Controls.Add(this.label1);
            this.Name.Name = "CustomDataManager";
            this.Text = "CDM";
            ((System.ComponentModel.ISupportInitialize)(this.datatable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Button table_addrow;
        public System.Windows.Forms.DataGridView datatable;
    }
}