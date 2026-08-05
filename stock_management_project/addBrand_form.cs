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
using System.Xml.Linq;

namespace stock_management_project
{
    public partial class addBrand_form : Form
    {
        stock_managementEntities sm = new stock_managementEntities();
        brands_table bt = new brands_table();
        int rowindex;
        public addBrand_form()
        {
            InitializeComponent();
        }
        void load()
        {
            using (var context = new stock_managementEntities())
            {
                var guary = from brands_table in context.brands_table
                            select new
                            {
                                brands_table.brand_id,
                                brands_table.brand_name
                            };
                dgv_brand.DataSource = guary.ToList();
            }
            dgv_brand.Columns[0].HeaderText = "الرقم";
            dgv_brand.Columns[0].Width = 200;
            dgv_brand.Columns[1].HeaderText = "البراند";
            dgv_brand.Columns[1].Width = 550;
        }
        void reset()
        {
            txt_brandName.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_brandName.Text))
            {
                MessageBox.Show(" يرجى ادخال اسم البراند  ", "ادخال الاسم مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_brandName.Focus();
            }
            else
            {
                bt.brand_name = txt_brandName.Text;
                sm.brands_table.Add(bt);
                int check = sm.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show("تمت عملية الحفظ بنجاح", "حفظ الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    reset();
                    txt_brandName.Focus();
                }
                else
                {
                    MessageBox.Show("لم يتم حفظ الادخال", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void addBrand_form_Load(object sender, EventArgs e)
        {
            load();
            btn_update.Enabled = false;
            btn_del.Enabled = false;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            bt.brand_id = rowindex;
            bt.brand_name = txt_brandName.Text;
            sm.Entry(bt).State = EntityState.Modified;
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

        private void dgv_brand_Click(object sender, EventArgs e)
        {
            rowindex = Convert.ToInt32(dgv_brand.CurrentRow.Cells[0].Value);
            bt = sm.brands_table.Where(x => x.brand_id == rowindex).FirstOrDefault();
            txt_brandName.Text = bt.brand_name;
            btn_save.Enabled = false;
            btn_del.Enabled = true;
            btn_update.Enabled = true;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            bt.brand_id = rowindex;
            bt.brand_name = txt_brandName.Text;
            sm.Entry(bt).State = EntityState.Deleted;
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

        private void txt_brandName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
