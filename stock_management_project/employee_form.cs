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
    public partial class employee_form : Form
    {
        stock_managementEntities sm = new stock_managementEntities();
        employees_table emt = new employees_table();
        int rowindex;
        public employee_form()
        {
            InitializeComponent();
        }
        void load()
        {
            using (var context = new stock_managementEntities())
            {
                var guary = from employees_table in context.employees_table
                            select new
                            {
                                employees_table.emp_id,
                                employees_table.emp_name,
                                employees_table.emp_pass,
                                employees_table.emp_email,
                                employees_table.emp_phone,
                                employees_table.admin_id,
                            };
                dgv_emp.DataSource = guary.ToList();
            }
            dgv_emp.Columns[0].HeaderText = "الرقم";
            dgv_emp.Columns[0].Width = 100;
            dgv_emp.Columns[1].HeaderText = "اسم الموظف";
            dgv_emp.Columns[1].Width = 200;
            dgv_emp.Columns[2].HeaderText = "كلمة المرور";
            dgv_emp.Columns[2].Width = 200;
            dgv_emp.Columns[3].HeaderText = "الايميل";
            dgv_emp.Columns[3].Width = 200;
            dgv_emp.Columns[4].HeaderText = "الهاتف";
            dgv_emp.Columns[4].Width = 200;
            dgv_emp.Columns[5].HeaderText = "مسؤول";
            dgv_emp.Columns[5].Width = 90;
        }
        void reset()
        {
            txtname.Text = "";
            txtpass.Text = "";
            txte.Text = "";
            txtp.Text = "";
        }
        private void employee_form_Load(object sender, EventArgs e)
        {
            load();
            txtname.Focus();
            btn_add.Enabled = true;
            btn_remove.Enabled = false;
            btn_update.Enabled = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text))
            {
                MessageBox.Show("يرجى ادخال اسم الموظف ", "ادخال الاسم مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtname.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txte.Text))
            {
                MessageBox.Show("يرجى ادخال ايميل الموظف ", "ادخال الايميل مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txte.Focus();
            }
            else if (string.IsNullOrWhiteSpace(txtpass.Text))
            {
                MessageBox.Show("يرجى ادخال كلمة مرور الموظف ", "ادخال كلمة المرور مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.Focus();

            }
            else if (m.Checked == false && em.Checked == false)
            {
                MessageBox.Show("يرجى تحديد حالة الموظف ", "تحديد الحالة مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (string.IsNullOrWhiteSpace(txtp.Text))
            {
                MessageBox.Show("يرجى ادخال هاتف الموظف ", "ادخال رقم الهاتف مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtp.Focus();

            }

            else
            {
                emt.emp_name = txtname.Text;
                emt.emp_email = txte.Text;
                emt.emp_phone = txtp.Text;
                emt.emp_pass = txtpass.Text;
                int adm;
                if (m.Checked)
                {
                    adm = 1;
                }
                else
                {
                    adm = 0;
                }
                emt.admin_id = adm;
                sm.employees_table.Add(emt);
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
            emt.emp_id = rowindex;
            emt.emp_name = txtname.Text;
            emt.emp_email = txte.Text;
            emt.emp_phone = txtp.Text;
            emt.emp_pass = txtpass.Text;
            int adm;
            if (m.Checked)
            {
                adm = 1;
            }
            else
            {
                adm = 0;
            }
            emt.admin_id = adm;
            sm.Entry(emt).State = EntityState.Modified;
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

        private void dgv_emp_Click(object sender, EventArgs e)
        {
            rowindex = Convert.ToInt32(dgv_emp.CurrentRow.Cells[0].Value);
            emt = sm.employees_table.Where(x => x.emp_id == rowindex).FirstOrDefault();
            txtname.Text = emt.emp_name;
            txtpass.Text = emt.emp_pass;
            txte.Text = emt.emp_email;
            txtp.Text = emt.emp_phone;
            if (emt.admin_id == 1)
            {
                m.Checked = true;
            }
            else
            {
                em.Checked = true;
            }
            btn_add.Enabled = false;
            btn_remove.Enabled = true;
            btn_update.Enabled = true;
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            emt.emp_id = rowindex;
            emt.emp_name = txtname.Text;
            emt.emp_email = txte.Text;
            emt.emp_phone = txtp.Text;
            emt.emp_pass = txtpass.Text;
            int adm;
            if (m.Checked)
            {
                adm = 1;
            }
            else
            {
                adm = 0;
            }
            emt.admin_id = adm;
            sm.Entry(emt).State = EntityState.Deleted;
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
