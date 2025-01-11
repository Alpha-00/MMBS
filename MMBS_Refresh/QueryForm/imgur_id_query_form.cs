using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBS.QueryForm
{
    public partial class ImgurIdQueryForm : Form
    {
        public ImgurIdQueryForm()
        {
            InitializeComponent();
            CustomInit();
        }
        public void CustomInit()
        {
            
        }

        private void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://apidocs.imgur.com/#authorization-and-oauth");
        }

        private void butAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public string imgurID = "";
        private void boxID_TextChanged(object sender, EventArgs e)
        {
            imgurID = boxID.Text;
        }
        public string imgurSecret = "";

        private void boxSecret_TextChanged(object sender, EventArgs e)
        {
            imgurSecret = boxSecret.Text;
        }
    }
}
