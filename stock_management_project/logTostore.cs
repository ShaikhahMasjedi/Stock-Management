using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stock_management_project
{
    public partial class logTostore : Form
    {
        public logTostore()
        {
            InitializeComponent();
        }
        public bool IsUserValid(string userName, string password)
        {
            using (var db = new stock_managementEntities())
            {
                var user = db.employees_table.FirstOrDefault(u => u.emp_name == userName && u.emp_pass == password && u.admin_id == 1);
                return user != null;
            }
        }

        private void btn_logTostore_Click(object sender, EventArgs e)
        {
            bool log = IsUserValid(txt_name.Text, txt_pass.Text);
            if (log == true)
            {
                stores_form nf = new stores_form();
                nf.Show();
            }
        }

        private void txt_name_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
