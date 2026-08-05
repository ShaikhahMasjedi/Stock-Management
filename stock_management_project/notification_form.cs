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
    public partial class notification_form : Form
    {
        public notification_form()
        {
            InitializeComponent();
        }
        void load()
        {
            using (var context = new stock_managementEntities())
            {
                var quary = from products_table in context.products_table
                            join categories_table in context.categories_table
                            on products_table.id_category equals categories_table.cat_id
                            join models_table in context.models_table
                            on products_table.id_model equals models_table.mod_id
                            join brands_table in context.brands_table
                            on models_table.brand_id equals brands_table.brand_id
                            where (products_table.pro_quantity < 10)
                            select new
                            {
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                products_table.pro_quantity,
                            };
                dgv_note.DataSource = quary.ToList();
            }
            dgv_note.Columns[0].HeaderText = "اسم المنتج";
            dgv_note.Columns[0].Width = 190;
            dgv_note.Columns[1].HeaderText = "الوصف";
            dgv_note.Columns[1].Width = 170;
            dgv_note.Columns[2].HeaderText = "الفئة";
            dgv_note.Columns[2].Width = 170;
            dgv_note.Columns[3].HeaderText = "الموديل";
            dgv_note.Columns[3].Width = 170;
            dgv_note.Columns[4].HeaderText = "البراند";
            dgv_note.Columns[4].Width = 170;
            dgv_note.Columns[5].HeaderText = "الكمية";
            dgv_note.Columns[5].Width = 170;
        }

        private void notification_form_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
