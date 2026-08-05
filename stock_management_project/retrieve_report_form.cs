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
    public partial class retrieve_report_form : Form
    {
        public retrieve_report_form()
        {
            InitializeComponent();
        }
        void load()
        {
            using (var context = new stock_managementEntities())
            {
                var quary = from retrieval_details_table in context.retrieval_details_table
                            join products_table in context.products_table
                            on retrieval_details_table.pro_id equals products_table.pro_id
                            join models_table in context.models_table
                            on products_table.id_model equals models_table.mod_id
                            join brands_table in context.brands_table
                            on models_table.brand_id equals brands_table.brand_id
                            join categories_table in context.categories_table
                            on products_table.id_category equals categories_table.cat_id
                            join retrievals_table in context.retrievals_table
                            on retrieval_details_table.re_id equals retrievals_table.re_id
                            join stores_table in context.stores_table
                            on retrievals_table.store_id equals stores_table.store_id
                            select new
                            {
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                stores_table.store_name,
                                retrieval_details_table.re_quantity,
                                retrievals_table.re_date
                            };
                dgv_ret.DataSource = quary.ToList();
            }
            dgv_ret.Columns[0].HeaderText = "اسم المنتج";
            dgv_ret.Columns[0].Width = 200;
            dgv_ret.Columns[1].HeaderText = "الوصف";
            dgv_ret.Columns[1].Width = 200;
            dgv_ret.Columns[2].HeaderText = "الفئة";
            dgv_ret.Columns[3].HeaderText = "الموديل";
            dgv_ret.Columns[4].HeaderText = "البراند";
            dgv_ret.Columns[5].HeaderText = "المحل";
            dgv_ret.Columns[6].HeaderText = "الكمية";
            dgv_ret.Columns[7].HeaderText = "التاريخ";
            dgv_ret.Columns[7].Width = 120;
        }

        private void retrieve_report_form_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dtp_from_ValueChanged(object sender, EventArgs e)
        {
            using (var context = new stock_managementEntities())
            {
                var quary = from retrieval_details_table in context.retrieval_details_table
                            join products_table in context.products_table
                            on retrieval_details_table.pro_id equals products_table.pro_id
                            join models_table in context.models_table
                            on products_table.id_model equals models_table.mod_id
                            join brands_table in context.brands_table
                            on models_table.brand_id equals brands_table.brand_id
                            join categories_table in context.categories_table
                            on products_table.id_category equals categories_table.cat_id
                            join retrievals_table in context.retrievals_table
                            on retrieval_details_table.re_id equals retrievals_table.re_id
                            join stores_table in context.stores_table
                            on retrievals_table.store_id equals stores_table.store_id
                            where(retrievals_table.re_date >= dtp_from.Value)
                            select new
                            {
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                stores_table.store_name,
                                retrieval_details_table.re_quantity,
                                retrievals_table.re_date
                            };
                dgv_ret.DataSource = quary.ToList();
            }
            dgv_ret.Columns[0].HeaderText = "اسم المنتج";
            dgv_ret.Columns[0].Width = 200;
            dgv_ret.Columns[1].HeaderText = "الوصف";
            dgv_ret.Columns[1].Width = 200;
            dgv_ret.Columns[2].HeaderText = "الفئة";
            dgv_ret.Columns[3].HeaderText = "الموديل";
            dgv_ret.Columns[4].HeaderText = "البراند";
            dgv_ret.Columns[5].HeaderText = "المحل";
            dgv_ret.Columns[6].HeaderText = "الكمية";
            dgv_ret.Columns[7].HeaderText = "التاريخ";
            dgv_ret.Columns[7].Width = 120;
        }

        private void dtp_to_ValueChanged(object sender, EventArgs e)
        {
            using (var context = new stock_managementEntities())
            {
                var quary = from retrieval_details_table in context.retrieval_details_table
                            join products_table in context.products_table
                            on retrieval_details_table.pro_id equals products_table.pro_id
                            join models_table in context.models_table
                            on products_table.id_model equals models_table.mod_id
                            join brands_table in context.brands_table
                            on models_table.brand_id equals brands_table.brand_id
                            join categories_table in context.categories_table
                            on products_table.id_category equals categories_table.cat_id
                            join retrievals_table in context.retrievals_table
                            on retrieval_details_table.re_id equals retrievals_table.re_id
                            join stores_table in context.stores_table
                            on retrievals_table.store_id equals stores_table.store_id
                            where (retrievals_table.re_date <= dtp_to.Value)
                            select new
                            {
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                stores_table.store_name,
                                retrieval_details_table.re_quantity,
                                retrievals_table.re_date
                            };
                dgv_ret.DataSource = quary.ToList();
            }
            dgv_ret.Columns[0].HeaderText = "اسم المنتج";
            dgv_ret.Columns[0].Width = 200;
            dgv_ret.Columns[1].HeaderText = "الوصف";
            dgv_ret.Columns[1].Width = 200;
            dgv_ret.Columns[2].HeaderText = "الفئة";
            dgv_ret.Columns[3].HeaderText = "الموديل";
            dgv_ret.Columns[4].HeaderText = "البراند";
            dgv_ret.Columns[5].HeaderText = "المحل";
            dgv_ret.Columns[6].HeaderText = "الكمية";
            dgv_ret.Columns[7].HeaderText = "التاريخ";
            dgv_ret.Columns[7].Width = 120;
        }
    }
}
