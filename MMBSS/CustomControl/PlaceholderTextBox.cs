using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBS.CustomControl
{
    [ToolboxItem(false)]
    public class PlaceholderTextBox : TextBox
    {
        //public string PlaceholderText;
        //public Color SubPrimaryColor;
        /*public PlaceholderTextBox()
        {
            PlaceholderText = "Enter your text...";

            SubPrimaryColor = new Color();
            SubPrimaryColor = Color.FromArgb(200, this.ForeColor);
            
        }*/
       /* protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            // Check if the text property is blank.
            if (this.Text.Length == 0)
            {
                // Draw the text hint.
                e.Graphics.DrawString( this.PlaceholderText, this.Font,new SolidBrush(SubPrimaryColor), new RectangleF(this.ClientRectangle.Location,this.ClientRectangle.Size));
            }
        }
       */
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PlaceholderTextBox
            // 
            this.CausesValidation = false;
            this.Size = new System.Drawing.Size(150, 22);
            this.Text = "Text";
            this.ResumeLayout(false);

        }
    }
}
