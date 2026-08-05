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
    public partial class nav_form : Form
    {
        public nav_form()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
            {
                this.mainpanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void nav_form_Load(object sender, EventArgs e)
        {
            loadform(new home_form());
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            loadform(new home_form());
        }

        private void btn_products_Click(object sender, EventArgs e)
        {
            loadform(new products_form());
        }

        private void btn_orders_Click(object sender, EventArgs e)
        {
            loadform(new order_form());
        }

        private void btn_stores_Click(object sender, EventArgs e)
        {
            loadform(new logTostore());
        }

        private void btn_suppliers_Click(object sender, EventArgs e)
        {
            loadform(new logTosup());
        }

        private void btn_employee_Click(object sender, EventArgs e)
        {
            loadform(new logToemp());
        }

        private void btn_retrieve_Click(object sender, EventArgs e)
        {
            loadform(new retrieve_form());
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            loadform(new report_form());
        }

        private void pic_note_Click(object sender, EventArgs e)
        {
            loadform(new notification_form());
        }

        private void lab_addCat_Click(object sender, EventArgs e)
        {
            addcatigory_form f = new addcatigory_form();
            f.ShowDialog();
        }

        private void lab_addModel_Click(object sender, EventArgs e)
        {
            addModel_form f = new addModel_form();
            f.ShowDialog();
        }

        private void lab_addBrand_Click(object sender, EventArgs e)
        {
            addBrand_form f = new addBrand_form();
            f.ShowDialog();
        }
    }
}
