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
    public partial class products_form : Form
    {
        public products_form()
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
                            join enter_opreation_table in context.enter_opreation_table
                            on products_table.pro_id equals enter_opreation_table.pro_id
                            select new
                            {
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                products_table.pro_quantity,
                                enter_opreation_table.price,
                            };
                dgv_product.DataSource = quary.ToList();
            }
            dgv_product.Columns[0].HeaderText = "اسم المنتج";
            dgv_product.Columns[0].Width = 200;
            dgv_product.Columns[1].HeaderText = "الوصف";
            dgv_product.Columns[1].Width = 170;
            dgv_product.Columns[2].HeaderText = "الفئة";
            dgv_product.Columns[2].Width = 150;
            dgv_product.Columns[3].HeaderText = "الموديل";
            dgv_product.Columns[3].Width = 150;
            dgv_product.Columns[4].HeaderText = "البراند";
            dgv_product.Columns[4].Width = 150;
            dgv_product.Columns[5].HeaderText = "الكمية";
            dgv_product.Columns[6].HeaderText = "سعر الوحدة";
        }
        private void products_form_Load(object sender, EventArgs e)
        {
            load();
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                load();
            }
            else
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
                                join enter_opreation_table in context.enter_opreation_table
                                on products_table.pro_id equals enter_opreation_table.pro_id
                                where (products_table.pro_name.StartsWith(txtname.Text.Trim()))
                                select new
                                {
                                    products_table.pro_name,
                                    products_table.pro_description,
                                    categories_table.cat_name,
                                    models_table.mod_name,
                                    brands_table.brand_name,
                                    products_table.pro_quantity,
                                    enter_opreation_table.price,
                                };
                    dgv_product.DataSource = quary.ToList();
                }
                dgv_product.Columns[0].HeaderText = "اسم المنتج";
                dgv_product.Columns[0].Width = 200;
                dgv_product.Columns[1].HeaderText = "الوصف";
                dgv_product.Columns[1].Width = 170;
                dgv_product.Columns[2].HeaderText = "الفئة";
                dgv_product.Columns[2].Width = 150;
                dgv_product.Columns[3].HeaderText = "الموديل";
                dgv_product.Columns[3].Width = 150;
                dgv_product.Columns[4].HeaderText = "البراند";
                dgv_product.Columns[4].Width = 150;
                dgv_product.Columns[5].HeaderText = "الكمية";
                dgv_product.Columns[6].HeaderText = "سعر الوحدة";
            }

        }

        private void txtmodel_TextChanged(object sender, EventArgs e)
        {
            if (txtmodel.Text == "")
            {
                load();
            }
            else
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
                                join enter_opreation_table in context.enter_opreation_table
                                on products_table.pro_id equals enter_opreation_table.pro_id
                                where (models_table.mod_name.StartsWith(txtmodel.Text.Trim()))
                                select new
                                {
                                    products_table.pro_name,
                                    products_table.pro_description,
                                    categories_table.cat_name,
                                    models_table.mod_name,
                                    brands_table.brand_name,
                                    products_table.pro_quantity,
                                    enter_opreation_table.price,
                                };
                    dgv_product.DataSource = quary.ToList();
                }
                dgv_product.Columns[0].HeaderText = "اسم المنتج";
                dgv_product.Columns[0].Width = 200;
                dgv_product.Columns[1].HeaderText = "الوصف";
                dgv_product.Columns[1].Width = 170;
                dgv_product.Columns[2].HeaderText = "الفئة";
                dgv_product.Columns[2].Width = 150;
                dgv_product.Columns[3].HeaderText = "الموديل";
                dgv_product.Columns[3].Width = 150;
                dgv_product.Columns[4].HeaderText = "البراند";
                dgv_product.Columns[4].Width = 150;
                dgv_product.Columns[5].HeaderText = "الكمية";
                dgv_product.Columns[6].HeaderText = "سعر الوحدة";
            }
        }

        private void txtbran_TextChanged(object sender, EventArgs e)
        {
            if (txtbran.Text == "")
            {
                load();
            }
            else
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
                                join enter_opreation_table in context.enter_opreation_table
                                on products_table.pro_id equals enter_opreation_table.pro_id
                                where (brands_table.brand_name.StartsWith(txtbran.Text.Trim()))
                                select new
                                {
                                    products_table.pro_name,
                                    products_table.pro_description,
                                    categories_table.cat_name,
                                    models_table.mod_name,
                                    brands_table.brand_name,
                                    products_table.pro_quantity,
                                    enter_opreation_table.price,
                                };
                    dgv_product.DataSource = quary.ToList();
                }
                dgv_product.Columns[0].HeaderText = "اسم المنتج";
                dgv_product.Columns[0].Width = 200;
                dgv_product.Columns[1].HeaderText = "الوصف";
                dgv_product.Columns[1].Width = 170;
                dgv_product.Columns[2].HeaderText = "الفئة";
                dgv_product.Columns[2].Width = 150;
                dgv_product.Columns[3].HeaderText = "الموديل";
                dgv_product.Columns[3].Width = 150;
                dgv_product.Columns[4].HeaderText = "البراند";
                dgv_product.Columns[4].Width = 150;
                dgv_product.Columns[5].HeaderText = "الكمية";
                dgv_product.Columns[6].HeaderText = "سعر الوحدة";
            }
        }

        private void txtcate_TextChanged(object sender, EventArgs e)
        {
            if (txtcate.Text == "")
            {
                load();
            }
            else
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
                                join enter_opreation_table in context.enter_opreation_table
                                on products_table.pro_id equals enter_opreation_table.pro_id
                                where (categories_table.cat_name.StartsWith(txtcate.Text.Trim()))
                                select new
                                {
                                    products_table.pro_name,
                                    products_table.pro_description,
                                    categories_table.cat_name,
                                    models_table.mod_name,
                                    brands_table.brand_name,
                                    products_table.pro_quantity,
                                    enter_opreation_table.price,
                                };
                    dgv_product.DataSource = quary.ToList();
                }
                dgv_product.Columns[0].HeaderText = "اسم المنتج";
                dgv_product.Columns[0].Width = 200;
                dgv_product.Columns[1].HeaderText = "الوصف";
                dgv_product.Columns[1].Width = 170;
                dgv_product.Columns[2].HeaderText = "الفئة";
                dgv_product.Columns[2].Width = 150;
                dgv_product.Columns[3].HeaderText = "الموديل";
                dgv_product.Columns[3].Width = 150;
                dgv_product.Columns[4].HeaderText = "البراند";
                dgv_product.Columns[4].Width = 150;
                dgv_product.Columns[5].HeaderText = "الكمية";
                dgv_product.Columns[6].HeaderText = "سعر الوحدة";
            }
        }
    }
    
}
