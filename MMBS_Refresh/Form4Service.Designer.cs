namespace MMBS
{
    partial class Form4Service
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
            this.WebCService = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WebCService
            // 
            this.WebCService.Location = new System.Drawing.Point(12, 12);
            this.WebCService.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebCService.Name = "WebCService";
            this.WebCService.Size = new System.Drawing.Size(80, 45);
            this.WebCService.TabIndex = 0;
            // 
            // Form4Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.WebCService);
            this.Name = "Form4Service";
            this.Text = "Form4Service";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebCService;
    }
}