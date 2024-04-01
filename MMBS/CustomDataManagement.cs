using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.Expressions;
using System.Windows.Forms;

namespace MMBS
{
    public partial class CustomDataManager : Form
    {
        
        public CustomDataManager()
        {
            InitializeComponent();
            
        }
        public CustomDataManager(Dictionary<string,string> customdat)
        {
            InitializeComponent();
            if (customdat != null)
                foreach (var x in customdat)
                {
                    datatable.Rows.Add(x.Key, x.Value);
                }

        }

        private void boxRAW_TextChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void datatable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            datatable.Rows.Add("ABC","xyz");
        }
    }
}
