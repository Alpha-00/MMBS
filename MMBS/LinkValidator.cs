using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBS
{
    public partial class LinkValidator : Form
    {
        public DefineInfoPack.Linker FormData;
        public LinkValidator()
        {
            InitializeComponent();
            FormData = new DefineInfoPack.Linker();
        }
        public LinkValidator(string boxname,string linkname, string link)
        {
            InitializeComponent();
            FormData = new DefineInfoPack.Linker();
            FormData.link = link;
            FormData.linkalias = linkname;
            this.Text = boxname;
            boxLinkname.Text = linkname;
            boxLink.Text = link;
        }
        public void ValidChecker(string link)
        {
            // TODO: Convert to setting option
            labelValid.Visible = true;
            labelValid.ForeColor = System.Drawing.Color.Lime;
            FormData.check = true;
            FormData.host = "";
            FormData.link = link;
            return;
            OldProcessor.ProcessDownloadLinkTextBox check = new OldProcessor.ProcessDownloadLinkTextBox(link,OldProcessor.ProcessDownloadLinkTextBox.request_code.SimpleInfo);
            labelUn.Visible = check.valid == 2;
            labelValid.Visible = check.valid > 0;
            labelValid.ForeColor = check.valid == 1 ? System.Drawing.Color.Lime : Color.Red;
            FormData.check = check.valid == 1;
            FormData.host = check.host;
            FormData.link = link;
        }
        public DefineInfoPack.Linker GetData()
        {
            return FormData;
        }

        private void boxLink_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(boxLink.Text))
            {
                labelUn.Visible = false;
                labelValid.Visible = false;

                FormData.check = false;
                FormData.host = "";
                FormData.link = "";
            }
            else ValidChecker(boxLink.Text);
        }

        private void boxLinkname_TextChanged(object sender, EventArgs e)
        {
            FormData.linkalias = boxLinkname.Text;
        }

        private void butContinue_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
