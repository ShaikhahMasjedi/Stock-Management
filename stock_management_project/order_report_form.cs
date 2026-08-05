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
    public partial class order_report_form : Form
    {
        public order_report_form()
        {
            InitializeComponent();
        }
        void load()
        {
            using (var context = new stock_managementEntities())
            {
                var quary = from order_details_table in context.order_details_table
                            join products_table in context.products_table
                            on order_details_table.pro_id equals products_table.pro_id
                            join models_table in context.models_table
                            on products_table.id_model equals models_table.mod_id
                            join brands_table in context.brands_table
                            on models_table.brand_id equals brands_table.brand_id
                            join categories_table in context.categories_table
                            on products_table.id_category equals categories_table.cat_id
                            join orders_table in context.orders_table
                            on order_details_table.ord_id equals orders_table.ord_id
                            join stores_table in context.stores_table
                            on orders_table.store_id equals stores_table.store_id
                            join enter_opreation_table in context.enter_opreation_table
                            on products_table.pro_id equals enter_opreation_table.pro_id
                            select new
                            {
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                stores_table.store_name,
                                order_details_table.ord_detail_quantity,
                                enter_opreation_table.price,
                                orders_table.ord_date
                            };
                dgv_or.DataSource = quary.ToList();
            }
            dgv_or.Columns[0].HeaderText = "اسم المنتج";
            dgv_or.Columns[0].Width = 170;
            dgv_or.Columns[1].HeaderText = "الوصف";
            dgv_or.Columns[1].Width = 160;
            dgv_or.Columns[2].HeaderText = "الفئة";
            dgv_or.Columns[3].HeaderText = "الموديل";
            dgv_or.Columns[4].HeaderText = "البراند";
            dgv_or.Columns[5].HeaderText = "المحل";
            dgv_or.Columns[6].HeaderText = "الكمية";
            dgv_or.Columns[7].HeaderText = "سعر الوحدة";
            dgv_or.Columns[8].HeaderText = "التاريخ";

        }

        private void order_report_form_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dtp_from_ValueChanged(object sender, EventArgs e)
        {
            using (var context = new stock_managementEntities())
            {
                var quary = from order_details_table in context.order_details_table
                            join products_table in context.products_table
                            on order_details_table.pro_id equals products_table.pro_id
                            join models_table in context.models_table
                            on products_table.id_model equals models_table.mod_id
                            join brands_table in context.brands_table
                            on models_table.brand_id equals brands_table.brand_id
                            join categories_table in context.categories_table
                            on products_table.id_category equals categories_table.cat_id
                            join orders_table in context.orders_table
                            on order_details_table.ord_id equals orders_table.ord_id
                            join stores_table in context.stores_table
                            on orders_table.store_id equals stores_table.store_id
                            join enter_opreation_table in context.enter_opreation_table
                            on products_table.pro_id equals enter_opreation_table.pro_id
                            where(orders_table.ord_date >= dtp_from.Value)
                            select new
                            {
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                stores_table.store_name,
                                order_details_table.ord_detail_quantity,
                                enter_opreation_table.price,
                                orders_table.ord_date
                            };
                dgv_or.DataSource = quary.ToList();
            }
            dgv_or.Columns[0].HeaderText = "اسم المنتج";
            dgv_or.Columns[0].Width = 170;
            dgv_or.Columns[1].HeaderText = "الوصف";
            dgv_or.Columns[1].Width = 160;
            dgv_or.Columns[2].HeaderText = "الفئة";
            dgv_or.Columns[3].HeaderText = "الموديل";
            dgv_or.Columns[4].HeaderText = "البراند";
            dgv_or.Columns[5].HeaderText = "المحل";
            dgv_or.Columns[6].HeaderText = "الكمية";
            dgv_or.Columns[7].HeaderText = "سعر الوحدة";
            dgv_or.Columns[8].HeaderText = "التاريخ";
        }

        private void dtp_to_ValueChanged(object sender, EventArgs e)
        {
            using (var context = new stock_managementEntities())
            {
                var quary = from order_details_table in context.order_details_table
                            join products_table in context.products_table
                            on order_details_table.pro_id equals products_table.pro_id
                            join models_table in context.models_table
                            on products_table.id_model equals models_table.mod_id
                            join brands_table in context.brands_table
                            on models_table.brand_id equals brands_table.brand_id
                            join categories_table in context.categories_table
                            on products_table.id_category equals categories_table.cat_id
                            join orders_table in context.orders_table
                            on order_details_table.ord_id equals orders_table.ord_id
                            join stores_table in context.stores_table
                            on orders_table.store_id equals stores_table.store_id
                            join enter_opreation_table in context.enter_opreation_table
                            on products_table.pro_id equals enter_opreation_table.pro_id
                            where (orders_table.ord_date <= dtp_to.Value)
                            select new
                            {
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                stores_table.store_name,
                                order_details_table.ord_detail_quantity,
                                enter_opreation_table.price,
                                orders_table.ord_date
                            };
                dgv_or.DataSource = quary.ToList();
            }
            dgv_or.Columns[0].HeaderText = "اسم المنتج";
            dgv_or.Columns[0].Width = 170;
            dgv_or.Columns[1].HeaderText = "الوصف";
            dgv_or.Columns[1].Width = 160;
            dgv_or.Columns[2].HeaderText = "الفئة";
            dgv_or.Columns[3].HeaderText = "الموديل";
            dgv_or.Columns[4].HeaderText = "البراند";
            dgv_or.Columns[5].HeaderText = "المحل";
            dgv_or.Columns[6].HeaderText = "الكمية";
            dgv_or.Columns[7].HeaderText = "سعر الوحدة";
            dgv_or.Columns[8].HeaderText = "التاريخ";
        }
    }
}
