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
    public partial class stores_form : Form
    {
        stock_managementEntities sm = new stock_managementEntities();
        stores_table stt = new stores_table();
        int rowindex;
        public stores_form()
        {
            InitializeComponent();
            btn_remove.Enabled = false;
            btn_update.Enabled = false;
        }
        void load()
        {
            using (var context = new stock_managementEntities())
            {
                var guary = from stores_table in context.stores_table
                            select new
                            {
                                stores_table.store_id,
                                stores_table.store_name,
                                stores_table.store_email,
                                stores_table.store_address,
                                stores_table.store_phone
                            };
                dgv_store.DataSource = guary.ToList();
            }
            dgv_store.Columns[0].HeaderText = "الرقم";
            dgv_store.Columns[0].Width = 100;
            dgv_store.Columns[1].HeaderText = "اسم المتجر";
            dgv_store.Columns[1].Width = 250;
            dgv_store.Columns[2].HeaderText = "الايميل";
            dgv_store.Columns[2].Width = 250;
            dgv_store.Columns[3].HeaderText = "العنوان";
            dgv_store.Columns[3].Width = 250;
            dgv_store.Columns[4].HeaderText = "الهاتف";
            dgv_store.Columns[4].Width = 130;
        }
        void reset()
        {
            txtname.Text = "";
            txtadd.Text = "";
            txte.Text = "";
            txtp.Text = "";
        }
        private void stores_form_Load(object sender, EventArgs e)
        {
            load();
            txtname.Focus();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text))
            {
                MessageBox.Show("يرجى ادخال اسم المحل ", "ادخال الاسم مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtname.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txte.Text))
            {
                MessageBox.Show("يرجى ادخال ايميل المحل ", "ادخال الايميل مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txte.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtadd.Text))
            {
                MessageBox.Show("يرجى ادخال عنوان المحل ", "ادخال العنوان مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtadd.Focus();

            }

            else if (string.IsNullOrWhiteSpace(txtp.Text))
            {
                MessageBox.Show("يرجى ادخال هاتف المحل ", "ادخال رقم الهاتف مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtp.Focus();

            }
            else
            {
                stt.store_name = txtname.Text;
                stt.store_email = txte.Text;
                stt.store_phone = txtp.Text;
                stt.store_address = txtadd.Text;
                sm.stores_table.Add(stt);
                int check = sm.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show("تمت عملية الحفظ بنجاح", "حفظ الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    load();
                    reset();
                    txtname.Focus();
                }
                else
                {
                    MessageBox.Show("لم يتم حفظ الادخال", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            stt.store_id = rowindex;
            stt.store_name = txtname.Text;
            stt.store_email = txte.Text;
            stt.store_phone = txtp.Text;
            stt.store_address = txtadd.Text;
            sm.Entry(stt).State = EntityState.Modified;
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

        private void dgv_store_Click(object sender, EventArgs e)
        {
            rowindex = Convert.ToInt32(dgv_store.CurrentRow.Cells[0].Value);
            stt = sm.stores_table.Where(x => x.store_id == rowindex).FirstOrDefault();
            txtname.Text = stt.store_name;
            txtadd.Text = stt.store_address;
            txte.Text = stt.store_email;
            txtp.Text = stt.store_phone;
            btn_add.Enabled = false;
            btn_remove.Enabled = true;
            btn_update.Enabled = true;
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            stt.store_id = rowindex;
            stt.store_name = txtname.Text;
            stt.store_email = txte.Text;
            stt.store_phone = txtp.Text;
            stt.store_address = txtadd.Text;
            sm.Entry(stt).State = EntityState.Deleted;
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

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
            && e.KeyChar != '@' && e.KeyChar != '.' && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }

        private void txtp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
