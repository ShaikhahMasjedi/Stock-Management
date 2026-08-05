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
    public partial class suppliers_form : Form
    {
        stock_managementEntities sm = new stock_managementEntities();
        suppliers_table st = new suppliers_table();
        int rowindex;
        public suppliers_form()
        {
            InitializeComponent();
            btn_remove.Enabled = false;
            btn_update.Enabled = false;
        }
        void load()
        {
            using (var context = new stock_managementEntities())
            {
                var guary = from suppliers_table in context.suppliers_table
                            select new
                            {
                                suppliers_table.sup_id,
                                suppliers_table.sup_name,
                                suppliers_table.sup_email,
                                suppliers_table.sup_phone
                            };
                dgv_sup.DataSource = guary.ToList();
            }
            dgv_sup.Columns[0].HeaderText = "الرقم";
            dgv_sup.Columns[1].HeaderText = "اسم المورد";
            dgv_sup.Columns[1].Width = 300;
            dgv_sup.Columns[2].HeaderText = "الايميل";
            dgv_sup.Columns[2].Width = 300;
            dgv_sup.Columns[3].HeaderText = "الهاتف";
            dgv_sup.Columns[3].Width = 290;
        }
        void reset()
        {
            txtsupname.Text = "";
            txtsupphone.Text = "";
            txtsupemail.Text = "";
        }
        private void suppliers_form_Load(object sender, EventArgs e)
        {
            load();
            txtsupname.Focus();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtsupname.Text))
            {
                MessageBox.Show("يرجى ادخال اسم المورد ", "ادخال الاسم مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsupname.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtsupemail.Text))
            {
                MessageBox.Show("يرجى ادخال  ايميل المورد ", "ادخال الايميل مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsupemail.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtsupphone.Text))
            {
                MessageBox.Show("يرجى ادخال  هاتف المورد ", "ادخال رقم الهاتف مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsupphone.Focus();
            }
            else
            {
                st.sup_name = txtsupname.Text;
                st.sup_phone = txtsupphone.Text;
                st.sup_email = txtsupemail.Text;
                sm.suppliers_table.Add(st);
                int check = sm.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show("تمت عملية الحفظ بنجاح", "حفظ الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    reset();
                    txtsupname.Focus();
                }
                else
                {
                    MessageBox.Show("لم يتم حفظ الادخال", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            st.sup_id = rowindex;
            st.sup_name = txtsupname.Text;
            st.sup_phone = txtsupphone.Text;
            st.sup_email = txtsupemail.Text;
            sm.Entry(st).State = EntityState.Modified;

            int check = sm.SaveChanges();
            if (check > 0)
            {
                MessageBox.Show("تمت عملية التغيير بنجاح", "تعديل الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                reset();

                btn_remove.Enabled = false;
                btn_update.Enabled = false;
                btn_add.Enabled = true;
            }
            else
            {
                MessageBox.Show("لم تتم عمليه التغيير", "خطأ في التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_sup_Click(object sender, EventArgs e)
        {
            rowindex = Convert.ToInt32(dgv_sup.CurrentRow.Cells[0].Value);
            st = sm.suppliers_table.Where(x => x.sup_id == rowindex).FirstOrDefault();
            txtsupname.Text = st.sup_name;
            txtsupemail.Text = st.sup_email;
            txtsupphone.Text = st.sup_phone;
            btn_add.Enabled = false;
            btn_remove.Enabled = true;
            btn_update.Enabled = true;
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            st.sup_id = rowindex;
            st.sup_name = txtsupname.Text;
            st.sup_phone = txtsupphone.Text;
            st.sup_email = txtsupemail.Text;
            sm.Entry(st).State = EntityState.Deleted;

            int check = sm.SaveChanges();
            if (check > 0)
            {
                MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                reset();

                btn_remove.Enabled = false;
                btn_update.Enabled = false;
                btn_add.Enabled = true;
            }
            else
            {
                MessageBox.Show("لم تتم عملية الحذف", "خطأ في الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtsupname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtsupemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }

        private void txtsupphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
