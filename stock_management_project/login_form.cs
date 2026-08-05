using stock_management_project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_login
{
    public partial class login_form : Form
    {
        public static int emplogid;
        public login_form()
        {
            InitializeComponent();
        }

        public bool IsUserValid(string userName, string password)
        {
            using (var db = new stock_managementEntities())
            {
                var user = db.employees_table.FirstOrDefault(u => u.emp_name == userName && u.emp_pass == password);
                if (user != null)
                {
                    emplogid = user.emp_id;
                }
                return user != null;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void login_form_Load(object sender, EventArgs e)
        {
            txt_name.Focus();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("يرجى ادخال الاسم  لاتمام عملية الدخول  ", "ادخال الاسم مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_name.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txt_pass.Text))
            {
                MessageBox.Show("يرجى ادخال كلمة المرور لاتمام عملية الدخول  ", "ادخال كلمة المرور مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_pass.Focus();
            }
            else
            {
                bool log = IsUserValid(txt_name.Text, txt_pass.Text);
                if (log == true)
                {
                    nav_form nf = new nav_form();
                    nf.Show();
                    //hide or close login 
                    //this.Hide();
                }
            }
        }
    }
}
