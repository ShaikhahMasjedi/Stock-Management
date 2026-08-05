using form_login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace stock_management_project
{
    public partial class order_form : Form
    {
        stock_managementEntities sm = new stock_managementEntities();
        products_table ptt = new products_table();
        orders_table ordt = new orders_table();
        order_details_table odt = new order_details_table();
        employees_table emt = new employees_table();
        stores_table st = new stores_table();
        int proselectid;
        int storeselectid;
        int ordid;
        int rowindex;
        public order_form()
        {
            InitializeComponent();
        }
        void loadcombobboxst()
        {
            using (var context = new stock_managementEntities())
            {
                var query = from stores_table in context.stores_table
                            select new
                            {
                                stores_table.store_name, // Display member
                                stores_table.store_id // Value member
                            };

                com_store.DataSource = query.ToList();
                com_store.DisplayMember = "store_name";
                com_store.ValueMember = "store_id";
            }
        }
        void loadcombobboxpro()
        {
            using (var context = new stock_managementEntities())
            {
                var query = from products_table in context.products_table
                            select new
                            {
                                products_table.pro_name, // Display member
                                products_table.pro_id // Value member
                            };

                comname.DataSource = query.ToList();
                comname.DisplayMember = "pro_name";
                comname.ValueMember = "pro_id";
            }
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
                                orders_table.ord_id,
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                stores_table.store_name,
                                order_details_table.ord_detail_quantity,
                                orders_table.total_price,
                                orders_table.ord_date
                            };
                dgv_ord.DataSource = quary.ToList();
            }
            dgv_ord.Columns[0].HeaderText = "رقم الطلب";
            dgv_ord.Columns[1].HeaderText = "اسم المنتج";
            dgv_ord.Columns[1].Width = 170;
            dgv_ord.Columns[2].HeaderText = "الوصف";
            dgv_ord.Columns[2].Width = 160;
            dgv_ord.Columns[3].HeaderText = "الفئة";
            dgv_ord.Columns[4].HeaderText = "الموديل";
            dgv_ord.Columns[5].HeaderText = "البراند";
            dgv_ord.Columns[6].HeaderText = "المحل";
            dgv_ord.Columns[7].HeaderText = "الكمية";
            dgv_ord.Columns[8].HeaderText = "سعر الوحدة";
            dgv_ord.Columns[9].HeaderText = "التاريخ";

        }
        void reset()
        {
            comname.SelectedIndex = -1;
            com_store.SelectedIndex = -1;
            num_q.Value = 0;
            txtprice.Text = "";
        }
        private void order_form_Load(object sender, EventArgs e)
        {
            load();
            loadcombobboxst();
            loadcombobboxpro();
            comname.SelectedIndex = -1;
            com_store.SelectedIndex = -1;
        }

        private void comname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comname.SelectedIndex > 0)
            {
                proselectid = Convert.ToInt32(comname.SelectedValue.ToString());
            }
            else
            {
                proselectid = 4;
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (comname.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى تحديد اسم المنتج ", "تحديد اسم مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (com_store.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى تحديداسم المحل ", "تحديد المحل مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(num_q.Text) || num_q.Value == 0)
            {

                MessageBox.Show("يرجى ادخال كمية المنتج ", "ادخال الكمية مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                num_q.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtprice.Text))
            {
                MessageBox.Show("يرجى ادخال سعر المنتج ", "ادخال السعر مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtprice.Focus();
            }
            else
            {
                ordt.ord_date = DateTime.Now;
                ordt.emp_id = login_form.emplogid;
                ordt.store_id = storeselectid;
                ordt.ord_state = "1";
                ordt.total_price = Convert.ToDouble(txtprice.Text);
                sm.orders_table.Add(ordt);
                int check = sm.SaveChanges();
                using (var context = new stock_managementEntities())
                {
                    var quary = from orders_table in context.orders_table
                                select new
                                {
                                    orders_table.ord_id,
                                };
                    dgv_ord.DataSource = quary.ToList();
                    ordid = Convert.ToInt32(dgv_ord.Rows[dgv_ord.RowCount - 1].Cells[0].Value);
                }
                load();
                odt.ord_id = ordid;
                odt.ord_price = Convert.ToDouble(txtprice.Text);
                odt.ord_detail_quantity = (int)num_q.Value;
                odt.pro_id = proselectid;
                sm.order_details_table.Add(odt);
                check = sm.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show("تمت عملية الحفظ بنجاح", "حفظ الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    reset();
                    btn_del.Enabled = false;
                    btn_update.Enabled = false;
                    btnsave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("لم يتم حفظ الادخال", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void com_store_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_store.SelectedIndex > 0)
            {
                storeselectid = Convert.ToInt32(com_store.SelectedValue.ToString());
            }
            else
            {
                storeselectid = 1;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            ordt.ord_date = DateTime.Now;
            ordt.emp_id = login_form.emplogid;
            ordt.store_id = storeselectid;
            ordt.total_price = Convert.ToDouble(txtprice.Text);
            odt.pro_id = proselectid;
            odt.ord_detail_quantity = (int)num_q.Value;
            sm.Entry(ordt).State = EntityState.Modified;
            sm.Entry(odt).State = EntityState.Modified;
            int check = sm.SaveChanges();
            if (check > 0)
            {
                MessageBox.Show("تمت عملية التغيير بنجاح", "تعديل الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                reset();
                btn_del.Enabled = false;
                btn_update.Enabled = false;
                btnsave.Enabled = true;
            }
            else
            {
                MessageBox.Show("لم تتم عمليه التغيير", "خطأ في التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_ord_Click(object sender, EventArgs e)
        {
            rowindex = Convert.ToInt32(dgv_ord.CurrentRow.Cells[0].Value);
            ordt = sm.orders_table.Where(x => x.ord_id == rowindex).FirstOrDefault();
            odt = sm.order_details_table.Where(x => x.ord_id == rowindex).FirstOrDefault();
            st = sm.stores_table.Where(x => x.store_id == ordt.store_id).FirstOrDefault();
            emt = sm.employees_table.Where(x => x.emp_id == ordt.emp_id).FirstOrDefault();
            ptt = sm.products_table.Where(x => x.pro_id== odt.pro_id).FirstOrDefault();
            com_store.Text = st.store_name;
            num_q.Value = odt.ord_detail_quantity;
            comname.Text = ptt.pro_name;
            txtprice.Text = ordt.total_price.ToString();
            btnsave.Enabled = false;
            btn_del.Enabled = true;
            btn_update.Enabled = true;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            ordt.ord_date = DateTime.Now;
            ordt.emp_id = login_form.emplogid;
            ordt.store_id = storeselectid;
            ordt.total_price = Convert.ToDouble(txtprice.Text);
            odt.pro_id = proselectid;
            odt.ord_detail_quantity = (int)num_q.Value;
            sm.Entry(ordt).State = EntityState.Deleted;
            sm.Entry(odt).State = EntityState.Deleted;
            int check = sm.SaveChanges();
            if (check > 0)
            {
                MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                reset();
                btn_del.Enabled = false;
                btn_update.Enabled = false;
                btnsave.Enabled = true;
            }
            else
            {
                MessageBox.Show("لم تتم عملية الحذف", "خطأ في الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
