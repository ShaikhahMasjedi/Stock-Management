using form_login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace stock_management_project
{
    public partial class home_form : Form
    {
        stock_managementEntities sm = new stock_managementEntities();
        products_table ptt = new products_table();
        enter_opreation_table ent = new enter_opreation_table();
        models_table mt = new models_table();
        categories_table ct = new categories_table();
        suppliers_table st = new suppliers_table();
        int rowindex;
        int proid;
        int modelselectid;
        int catselectid;
        int supselectid;
        public home_form()
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
                            join suppliers_table in context.suppliers_table
                            on enter_opreation_table.sup_id equals suppliers_table.sup_id
                            select new
                            {
                                products_table.pro_id,
                                products_table.pro_name,
                                products_table.pro_description,
                                categories_table.cat_name,
                                models_table.mod_name,
                                brands_table.brand_name,
                                suppliers_table.sup_name,
                                products_table.pro_quantity,
                                enter_opreation_table.price,
                            };
                dgv_pro.DataSource = quary.ToList();
            }
            dgv_pro.Columns[0].HeaderText = "الرقم";
            dgv_pro.Columns[1].HeaderText = "اسم المنتج";
            dgv_pro.Columns[1].Width = 150;
            dgv_pro.Columns[2].HeaderText = "الوصف";
            dgv_pro.Columns[2].Width = 150;
            dgv_pro.Columns[3].HeaderText = "الفئة";
            dgv_pro.Columns[4].HeaderText = "الموديل";
            dgv_pro.Columns[5].HeaderText = "البراند";
            dgv_pro.Columns[5].Width = 130;
            dgv_pro.Columns[6].HeaderText = "المورد";
            dgv_pro.Columns[7].HeaderText = "الكمية";
            dgv_pro.Columns[8].HeaderText = "سعر الوحدة";
        }
        void loadComboBoxcat()
        {
            using (var context = new stock_managementEntities())
            {
                var query = from categories_table in context.categories_table
                            select new
                            {
                                categories_table.cat_name, // Display member
                                categories_table.cat_id // Value member
                            };

                com_cat.DataSource = query.ToList();
                com_cat.DisplayMember = "cat_name";
                com_cat.ValueMember = "cat_id";
            }
        }
        void loadcomboboxmodel()
        {
            using (var context = new stock_managementEntities())
            {
                var query = from models_table in context.models_table
                            select new
                            {
                                models_table.mod_name, // Display member
                                models_table.mod_id // Value member
                            };

                com_model.DataSource = query.ToList();
                com_model.DisplayMember = "mod_name";
                com_model.ValueMember = "mod_id";
            }
        }
        void loadcombobboxsup()
        {
            using (var context = new stock_managementEntities())
            {
                var query = from suppliers_table in context.suppliers_table
                            select new
                            {
                                suppliers_table.sup_name, // Display member
                                suppliers_table.sup_id // Value member
                            };

                com_sup.DataSource = query.ToList();
                com_sup.DisplayMember = "sup_name";
                com_sup.ValueMember = "sup_id";
            }
        }
        private void home_form_Load(object sender, EventArgs e)
        {
            load();
            loadComboBoxcat();
            loadcomboboxmodel();
            loadcombobboxsup();
            com_model.SelectedIndex = -1;
            com_cat.SelectedIndex = -1;
            com_sup.SelectedIndex = -1;
        }

        private void txt_proname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txt_proprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        void reset()
        {
            txt_proname.Text = "";
            txt_prodes.Text = "";
            txt_proprice.Text = "";
            num_q.Value = 0;
            com_model.SelectedIndex = -1;
            com_cat.SelectedIndex = -1;
            com_sup.SelectedIndex = -1;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_proname.Text))
            {
                MessageBox.Show("يرجى ادخال اسم المنتج ", "ادخال المنتج مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_proname.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txt_prodes.Text))
            {
                MessageBox.Show("يرجى ادخال وصف المنتج ", "ادخال الوصف مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_prodes.Focus();

            }
            else if (com_cat.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى تحديد صنف المنتج ", "تحديد الصنف مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (com_sup.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى تحديدالمورد المنتج ", "تحديد المورد مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (com_model.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى تحديد الموديل المنتج ", "تحديد االمودل مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (string.IsNullOrWhiteSpace(num_q.Text) || num_q.Value == 0)
            {

                MessageBox.Show("يرجى ادخال كمية المنتج ", "ادخال الكمية مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                num_q.Focus();

            }
            else if (string.IsNullOrWhiteSpace(txt_proprice.Text))
            {
                MessageBox.Show("يرجى ادخال سعر المنتج ", "ادخال السعر مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_proprice.Focus();

            }
            else
            {
                ptt.pro_name = txt_proname.Text;
                ptt.pro_description = txt_prodes.Text;
                ptt.pro_quantity = (int)num_q.Value;
                ptt.id_model = modelselectid;
                ptt.id_category = catselectid;
                sm.products_table.Add(ptt);
                int check = sm.SaveChanges();
                using (var context = new stock_managementEntities())
                {
                    var quary = from products_table in context.products_table
                                join categories_table in context.categories_table
                                on products_table.id_category equals categories_table.cat_id
                                join models_table in context.models_table
                                on products_table.id_model equals models_table.mod_id
                                join brands_table in context.brands_table
                                on models_table.brand_id equals brands_table.brand_id
                                where (products_table.pro_name == txt_proname.Text && products_table.pro_description == txt_prodes.Text &&
                                products_table.pro_quantity == (int)num_q.Value && products_table.id_model == modelselectid
                                && products_table.id_category == catselectid)
                                select new
                                {
                                    products_table.pro_id
                                };
                    dgv_pro.DataSource = quary.ToList();
                    proid = Convert.ToInt32(dgv_pro.Rows[0].Cells[0].Value);
                }
                load();
                ent.pro_id = proid;
                ent.ent_quantity = (int)num_q.Value;
                ent.price = Convert.ToDouble(txt_proprice.Text);
                ent.sup_id = supselectid;
                ent.emp_id = login_form.emplogid;
                ent.ent_date = DateTime.Now;
                sm.enter_opreation_table.Add(ent);
                check = sm.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show("تمت عملية الحفظ بنجاح", "حفظ الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    reset();
                    btn_del.Enabled = false;
                    btn_update.Enabled = false;
                }
                else
                {
                    MessageBox.Show("لم يتم حفظ الادخال", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void com_model_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_model.SelectedIndex > 0)
            {
                modelselectid = Convert.ToInt32(com_model.SelectedValue.ToString());
            }
            else
            {
                modelselectid = 1;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            ptt.pro_name = txt_proname.Text;
            ptt.pro_description = txt_prodes.Text;
            ptt.pro_quantity = (int)num_q.Value;
            ptt.id_model = modelselectid;
            ptt.id_category = catselectid;
            sm.Entry(ptt).State = EntityState.Modified;
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

        private void dgv_pro_Click(object sender, EventArgs e)
        {
            rowindex = Convert.ToInt32(dgv_pro.CurrentRow.Cells[0].Value);
            ptt = sm.products_table.Where(x => x.pro_id == rowindex).FirstOrDefault();
            ent = sm.enter_opreation_table.Where(x => x.pro_id == rowindex).FirstOrDefault();
            mt = sm.models_table.Where(x => x.mod_id == ptt.id_model).FirstOrDefault();
            ct = sm.categories_table.Where(x => x.cat_id == ptt.id_category).FirstOrDefault();
            st = sm.suppliers_table.Where(x => x.sup_id == ent.sup_id).FirstOrDefault();
            txt_proname.Text = ptt.pro_name;
            txt_prodes.Text = ptt.pro_description;
            txt_proprice.Text = ent.price.ToString();
            num_q.Value = ptt.pro_quantity;
            com_cat.Text = ct.cat_name;
            com_model.Text = mt.mod_name;
            com_sup.Text = st.sup_name;
            btn_save.Enabled = false;
            btn_del.Enabled = true;
            btn_update.Enabled = true;
        }

        private void com_cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_cat.SelectedIndex > 0)
            {
                catselectid = Convert.ToInt32(com_cat.SelectedValue.ToString());
            }
            else
            {
                catselectid = 1;
            }
        }

        private void com_sup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (com_sup.SelectedIndex > 0)
            {
                supselectid = Convert.ToInt32(com_sup.SelectedValue.ToString());
            }
            else
            {
                supselectid = 1;
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            ent.pro_id = proid;
            ent.ent_quantity = (int)num_q.Value;
            ent.price = Convert.ToDouble(txt_proprice.Text);
            ent.sup_id = supselectid;
            ent.emp_id = login_form.emplogid;
            ent.ent_date = DateTime.Now;
            sm.enter_opreation_table.Add(ent);
            sm.Entry(ent).State = EntityState.Deleted;
            int check = sm.SaveChanges();
            ptt.pro_name = txt_proname.Text;
            ptt.pro_description = txt_prodes.Text;
            ptt.pro_quantity = (int)num_q.Value;
            ptt.id_model = modelselectid;
            ptt.id_category = catselectid;
            sm.Entry(ptt).State = EntityState.Deleted;
            check = sm.SaveChanges();
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
