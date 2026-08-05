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

namespace stock_management_project
{
    public partial class retrieve_form : Form
    {
        stock_managementEntities sm = new stock_managementEntities();
        products_table ptt = new products_table();
        retrievals_table rt = new retrievals_table();
        retrieval_details_table rdt = new retrieval_details_table();
        employees_table emt = new employees_table();
        stores_table st = new stores_table();
        int proselectid;
        int storeselectid;
        int rowindex;
        int retid;
        public retrieve_form()
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

                com_name.DataSource = query.ToList();
                com_name.DisplayMember = "pro_name";
                com_name.ValueMember = "pro_id";
            }
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
                                retrievals_table.re_id,
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                stores_table.store_name,
                                retrieval_details_table.re_quantity,
                                retrievals_table.re_date
                            };
                dgv_retieve.DataSource = quary.ToList();
            }
            dgv_retieve.Columns[0].HeaderText = "رقم الراجع";
            dgv_retieve.Columns[1].HeaderText = "اسم المنتج";
            dgv_retieve.Columns[1].Width = 200;
            dgv_retieve.Columns[2].HeaderText = "الوصف";
            dgv_retieve.Columns[2].Width = 160;
            dgv_retieve.Columns[3].HeaderText = "الفئة";
            dgv_retieve.Columns[4].HeaderText = "الموديل";
            dgv_retieve.Columns[5].HeaderText = "البراند";
            dgv_retieve.Columns[6].HeaderText = "المحل";
            dgv_retieve.Columns[7].HeaderText = "الكمية";
            dgv_retieve.Columns[8].HeaderText = "التاريخ";
        }
        void reset()
        {
            com_name.SelectedIndex = -1;
            com_store.SelectedIndex = -1;
            num_q.Value = 0;
        }
        private void retrieve_form_Load(object sender, EventArgs e)
        {
            reset();
            load();
            loadcombobboxst();
            loadcombobboxpro();
        }

        private void com_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_name.SelectedIndex > 0)
            {
                proselectid = Convert.ToInt32(com_name.SelectedValue.ToString());
            }
            else
            {
                proselectid = 4;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (com_name.SelectedIndex == -1)
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
            else
            {
                rt.re_date = DateTime.Now;
                rt.emp_id = login_form.emplogid;
                rt.store_id = storeselectid;
                sm.retrievals_table.Add(rt);
                int ch = sm.SaveChanges();
                using (var context = new stock_managementEntities())
                {
                    var quary = from retrievals_table in context.retrievals_table
                                select new
                                {
                                    retrievals_table.re_id,
                                };
                    dgv_retieve.DataSource = quary.ToList();
                    retid = Convert.ToInt32(dgv_retieve.Rows[dgv_retieve.RowCount - 1].Cells[0].Value);
                }
                load();
                rdt.re_id = retid;
                rdt.re_quantity = (int)num_q.Value;
                rdt.pro_id = proselectid;
                sm.retrieval_details_table.Add(rdt);
                ch = sm.SaveChanges();
                if (ch > 0)
                {
                    MessageBox.Show("تمت عملية الحفظ بنجاح", "حفظ الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    reset();
                    btn_del.Enabled = false;
                    btn_update.Enabled = false;
                    btn_save.Enabled = true;
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
            rt.re_date = DateTime.Now;
            rt.emp_id = login_form.emplogid;
            rt.store_id = storeselectid;
            rdt.re_quantity = (int)num_q.Value;
            rdt.pro_id = proselectid;
            sm.Entry(rt).State = EntityState.Modified;
            sm.Entry(rdt).State = EntityState.Modified;
            int check = sm.SaveChanges();
            if (check > 0)
            {
                MessageBox.Show("تمت عملية التغيير بنجاح", "تعديل الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                reset();
                btn_del.Enabled = false;
                btn_update.Enabled = false;
                btn_save.Enabled = true;
            }
            else
            {
                MessageBox.Show("لم تتم عمليه التغيير", "خطأ في التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_retieve_Click(object sender, EventArgs e)
        {
            rowindex = Convert.ToInt32(dgv_retieve.CurrentRow.Cells[0].Value);
            rt = sm.retrievals_table.Where(x => x.re_id == rowindex).FirstOrDefault();
            rdt = sm.retrieval_details_table.Where(x => x.re_id == rowindex).FirstOrDefault();
            st = sm.stores_table.Where(x => x.store_id == rt.store_id).FirstOrDefault();
            emt = sm.employees_table.Where(x => x.emp_id == rt.emp_id).FirstOrDefault();
            ptt = sm.products_table.Where(x => x.pro_id == rdt.pro_id).FirstOrDefault();
            com_store.Text = st.store_name;
            num_q.Value = rdt.re_quantity;
            com_name.Text = ptt.pro_name;
            btn_save.Enabled = false;
            btn_del.Enabled = true;
            btn_update.Enabled = true;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            rt.re_date = DateTime.Now;
            rt.emp_id = login_form.emplogid;
            rt.store_id = storeselectid;
            rdt.re_id = retid;
            rdt.re_quantity = (int)num_q.Value;
            rdt.pro_id = proselectid;
            sm.Entry(rdt).State = EntityState.Deleted;
            sm.Entry(rt).State = EntityState.Deleted;
            int check = sm.SaveChanges();
            if (check > 0)
            {
                MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                reset();
                btn_del.Enabled = false;
                btn_update.Enabled = false;
                btn_save.Enabled = true;
            }
            else
            {
                MessageBox.Show("لم تتم عملية الحذف", "خطأ في الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
