namespace MMBS.CustomControl
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.theBox = new System.Windows.Forms.TextBox();
            this.theLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // theBox
            // 
            this.theBox.Location = new System.Drawing.Point(3, 25);
            this.theBox.Name = "theBox";
            this.theBox.Size = new System.Drawing.Size(794, 22);
            this.theBox.TabIndex = 0;
            // 
            // theLabel
            // 
            this.theLabel.AutoSize = true;
            this.theLabel.BackColor = System.Drawing.Color.Transparent;
            this.theLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.theLabel.Location = new System.Drawing.Point(3, 25);
            this.theLabel.Name = "theLabel";
            this.theLabel.Size = new System.Drawing.Size(55, 16);
            this.theLabel.TabIndex = 1;
            this.theLabel.Text = "thelabel";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.theLabel);
            this.Controls.Add(this.theBox);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(800, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox theBox;
        private System.Windows.Forms.Label theLabel;
    }
}
