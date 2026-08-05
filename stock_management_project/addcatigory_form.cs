using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stock_management_project
{
    public partial class addcatigory_form : Form
    {
        stock_managementEntities sm = new stock_managementEntities();
        categories_table ct = new categories_table();
        int rowindex;
        public addcatigory_form()
        {
            InitializeComponent();
        }
        void load()
        {
            using (var context = new stock_managementEntities())
            {
                var guary = from categories_table in context.categories_table
                            select new
                            {
                                categories_table.cat_id,
                                categories_table.cat_name
                            };
                dgv_cat.DataSource = guary.ToList();
            }
            dgv_cat.Columns[0].HeaderText = "الرقم";
            dgv_cat.Columns[0].Width = 200;
            dgv_cat.Columns[1].HeaderText = "الصنف";
            dgv_cat.Columns[1].Width = 550;
        }
        void reset()
        {
            txt_nameCat.Text = "";
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nameCat.Text))
            {
                MessageBox.Show(" يرجى ادخال اسم الصنف لاتمام عملية الادخال ", "ادخال الاسم مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nameCat.Focus();
            }
            else
            {
                ct.cat_name = txt_nameCat.Text;
                sm.categories_table.Add(ct);
                int check = sm.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show("تمت عملية الحفظ بنجاح", "حفظ الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    reset();
                    txt_nameCat.Focus();
                }
                else
                {
                    MessageBox.Show("لم يتم حفظ الادخال", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void addcatigory_form_Load(object sender, EventArgs e)
        {
            load();
            btn_update.Enabled = false;
            btn_del.Enabled = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            ct.cat_id = rowindex;
            ct.cat_name = txt_nameCat.Text;
            sm.Entry(ct).State = EntityState.Modified;
            int check = sm.SaveChanges();
            if (check > 0)
            {
                MessageBox.Show("تمت عملية التغيير بنجاح", "تعديل الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                reset();

                btn_del.Enabled = false;
                btn_update.Enabled = false;
            }
            else
            {
                MessageBox.Show("لم تتم عمليه التغيير", "خطأ في التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            ct.cat_id = rowindex;
            ct.cat_name = txt_nameCat.Text;
            sm.Entry(ct).State = EntityState.Deleted;
            int check = sm.SaveChanges();
            if (check > 0)
            {
                MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                reset();

                btn_del.Enabled = false;
                btn_update.Enabled = false;
            }
            else
            {
                MessageBox.Show("لم تتم عملية الحذف", "خطأ في الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_cat_Click(object sender, EventArgs e)
        {
            rowindex = Convert.ToInt32(dgv_cat.CurrentRow.Cells[0].Value);
            ct = sm.categories_table.Where(x => x.cat_id == rowindex).FirstOrDefault();
            txt_nameCat.Text = ct.cat_name;
            btn_add.Enabled = false;
            btn_del.Enabled = true;
            btn_update.Enabled = true;
        }

        private void txt_nameCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
