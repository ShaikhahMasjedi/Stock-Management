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
    public partial class addModel_form : Form
    {
        stock_managementEntities sm = new stock_managementEntities();
        models_table mt = new models_table();
        brands_table bt = new brands_table();
        int rowindex;
        int combrandid;
        public addModel_form()
        {
            InitializeComponent();
        }
        void loadcomboboxbrand()
        {
            using (var context = new stock_managementEntities())
            {
                var query = from brands_table in context.brands_table
                            select new
                            {
                                brands_table.brand_name, // Display member
                                brands_table.brand_id // Value member
                            };

                combrand.DataSource = query.ToList();
                combrand.DisplayMember = "brand_name";
                combrand.ValueMember = "brand_id";
            }
        }
        void load()
        {
            using (var context = new stock_managementEntities())
            {
                var guary = from models_table in context.models_table
                            join brands_table in context.brands_table
                            on models_table.brand_id equals brands_table.brand_id
                            select new
                            {
                                models_table.mod_id,
                                models_table.mod_name,
                                brands_table.brand_name
                            };
                dgv_model.DataSource = guary.ToList();
            }
            dgv_model.Columns[0].HeaderText = "الرقم";
            dgv_model.Columns[0].Width = 200;
            dgv_model.Columns[1].HeaderText = "الموديل";
            dgv_model.Columns[1].Width = 350;
            dgv_model.Columns[2].HeaderText = "البراند";
            dgv_model.Columns[2].Width = 200;
        }
        void reset()
        {
            txt_nameModel.Text = "";
            combrand.SelectedIndex = -1;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_nameModel.Text))
            {
                MessageBox.Show(" يرجى ادخال اسم الموديل  ", "ادخال الاسم مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_nameModel.Focus();
            }
            else if (combrand.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى تحديد البراند المنتج ", "تحديد البراند مطلوب ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                mt.mod_name = txt_nameModel.Text;
                mt.brand_id = combrandid;
                sm.models_table.Add(mt);
                int check = sm.SaveChanges();
                if (check > 0)
                {
                    MessageBox.Show("تمت عملية الحفظ بنجاح", "حفظ الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    load();
                    reset();
                    txt_nameModel.Focus();
                }
                else
                {
                    MessageBox.Show("لم يتم حفظ الادخال", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void addModel_form_Load(object sender, EventArgs e)
        {
            load();
            loadcomboboxbrand();
            combrand.SelectedIndex = -1;
            txt_nameModel.Focus();
            btn_update.Enabled = false;
            btn_del.Enabled = false;
        }

        private void combrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combrand.SelectedIndex > 0)
            {
                combrandid = Convert.ToInt32(combrand.SelectedValue.ToString());
            }
            else
            {
                combrandid = 1;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            mt.mod_name = txt_nameModel.Text;
            mt.brand_id = combrandid;
            sm.Entry(mt).State = EntityState.Modified;
            int check = sm.SaveChanges();
            if (check > 0)
            {
                MessageBox.Show("تمت عملية التغيير بنجاح", "تعديل الادخال", MessageBoxButtons.OK, MessageBoxIcon.Information);

                load();
                reset();
                txt_nameModel.Focus();
            }
            else
            {
                MessageBox.Show("لم تتم عمليه التغيير", "خطأ في التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            mt.mod_name = txt_nameModel.Text;
            mt.brand_id = combrandid;
            sm.Entry(mt).State = EntityState.Deleted;
            int check = sm.SaveChanges();
            if (check > 0)
            {
                MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                load();
                reset();
                txt_nameModel.Focus();
            }
            else
            {
                MessageBox.Show("لم تتم عملية الحذف", "خطأ في الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_model_Click(object sender, EventArgs e)
        {
            rowindex = Convert.ToInt32(dgv_model.CurrentRow.Cells[0].Value);
            mt = sm.models_table.Where(x => x.mod_id == rowindex).FirstOrDefault();
            bt = sm.brands_table.Where(x => x.brand_id == mt.brand_id).FirstOrDefault();
            txt_nameModel.Text = mt.mod_name;
            combrand.Text = bt.brand_name;
            btn_add.Enabled = false;
            btn_del.Enabled = true;
            btn_update.Enabled = true;
        }

        private void txt_nameModel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}