using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMBS.Misc_Form
{
    public partial class ModDescriptionQuickEditor : Form
    {
        public ModDescriptionQuickEditor()
        {
            InitializeComponent();
        }

        private void mod_desc_quick_editor_Leave(object sender, EventArgs e)
        {
        }

        private void mod_desc_quick_editor_Deactivate(object sender, EventArgs e)
        {
        }

        private void mod_desc_quick_editor_MouseLeave(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
