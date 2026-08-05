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
    public partial class report_form : Form
    {
        public report_form()
        {
            InitializeComponent();
        }
        private void pic_pro_go_Click(object sender, EventArgs e)
        {
            product_report_form orf = new product_report_form();
            orf.Show();
        }

        private void pic_ord_go_Click(object sender, EventArgs e)
        {
            order_report_form orf = new order_report_form();
            orf.Show();
        }

        private void pic_ret_go_Click(object sender, EventArgs e)
        {
            retrieve_report_form orf = new retrieve_report_form();
            orf.Show();
        }
    }
}
