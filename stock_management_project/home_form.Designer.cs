namespace stock_management_project
{
    partial class home_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pro_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_cat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_sup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pro_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_pro = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.num_q = new System.Windows.Forms.NumericUpDown();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.com_sup = new System.Windows.Forms.ComboBox();
            this.com_model = new System.Windows.Forms.ComboBox();
            this.com_cat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_proprice = new System.Windows.Forms.TextBox();
            this.txt_prodes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_proname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pro)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_q)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 14.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pro_name,
            this.pro_description,
            this.pro_cat,
            this.pro_model,
            this.pro_brand,
            this.pro_sup,
            this.pro_quantity,
            this.pro_price,
            this.pro_date});
            this.dataGridView1.Location = new System.Drawing.Point(6, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1095, 205);
            this.dataGridView1.TabIndex = 0;
            // 
            // pro_name
            // 
            this.pro_name.HeaderText = "اسم المنتج";
            this.pro_name.Name = "pro_name";
            this.pro_name.ReadOnly = true;
            this.pro_name.Width = 150;
            // 
            // pro_description
            // 
            this.pro_description.HeaderText = "الوصف";
            this.pro_description.Name = "pro_description";
            this.pro_description.ReadOnly = true;
            this.pro_description.Width = 150;
            // 
            // pro_cat
            // 
            this.pro_cat.HeaderText = "الفئة";
            this.pro_cat.Name = "pro_cat";
            this.pro_cat.ReadOnly = true;
            this.pro_cat.Width = 150;
            // 
            // pro_model
            // 
            this.pro_model.HeaderText = "الموديل";
            this.pro_model.Name = "pro_model";
            this.pro_model.ReadOnly = true;
            this.pro_model.Width = 150;
            // 
            // pro_brand
            // 
            this.pro_brand.HeaderText = "البراند";
            this.pro_brand.Name = "pro_brand";
            this.pro_brand.ReadOnly = true;
            // 
            // pro_sup
            // 
            this.pro_sup.HeaderText = "المورد";
            this.pro_sup.Name = "pro_sup";
            // 
            // pro_quantity
            // 
            this.pro_quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pro_quantity.HeaderText = "الكمية";
            this.pro_quantity.Name = "pro_quantity";
            this.pro_quantity.Width = 67;
            // 
            // pro_price
            // 
            this.pro_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pro_price.HeaderText = "سعر الواحدة";
            this.pro_price.Name = "pro_price";
            this.pro_price.Width = 103;
            // 
            // pro_date
            // 
            this.pro_date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pro_date.HeaderText = "التاريخ";
            this.pro_date.Name = "pro_date";
            this.pro_date.ReadOnly = true;
            this.pro_date.Width = 72;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_pro);
            this.groupBox3.Location = new System.Drawing.Point(12, 313);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1089, 273);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // dgv_pro
            // 
            this.dgv_pro.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 14.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_pro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_pro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_pro.Location = new System.Drawing.Point(6, 26);
            this.dgv_pro.Name = "dgv_pro";
            this.dgv_pro.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv_pro.Size = new System.Drawing.Size(1077, 240);
            this.dgv_pro.TabIndex = 0;
            this.dgv_pro.Click += new System.EventHandler(this.dgv_pro_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1081, 247);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.num_q);
            this.groupBox1.Controls.Add(this.btn_del);
            this.groupBox1.Controls.Add(this.btn_update);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.com_sup);
            this.groupBox1.Controls.Add(this.com_model);
            this.groupBox1.Controls.Add(this.com_cat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_proprice);
            this.groupBox1.Controls.Add(this.txt_prodes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_proname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, -7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1089, 313);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // num_q
            // 
            this.num_q.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Bold);
            this.num_q.Location = new System.Drawing.Point(634, 196);
            this.num_q.Name = "num_q";
            this.num_q.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.num_q.Size = new System.Drawing.Size(334, 32);
            this.num_q.TabIndex = 12;
            // 
            // btn_del
            // 
            this.btn_del.BackColor = System.Drawing.Color.Brown;
            this.btn_del.FlatAppearance.BorderSize = 0;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_del.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_del.ForeColor = System.Drawing.Color.White;
            this.btn_del.Location = new System.Drawing.Point(280, 257);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(126, 41);
            this.btn_del.TabIndex = 11;
            this.btn_del.Text = "حذف";
            this.btn_del.UseVisualStyleBackColor = false;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_update
            // 
            this.btn_update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.btn_update.FlatAppearance.BorderSize = 0;
            this.btn_update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_update.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_update.ForeColor = System.Drawing.Color.White;
            this.btn_update.Location = new System.Drawing.Point(462, 257);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(126, 41);
            this.btn_update.TabIndex = 11;
            this.btn_update.Text = "تعديل";
            this.btn_update.UseVisualStyleBackColor = false;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(100)))));
            this.btn_save.FlatAppearance.BorderSize = 0;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(645, 257);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(126, 41);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "حفظ";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // com_sup
            // 
            this.com_sup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_sup.FormattingEnabled = true;
            this.com_sup.Location = new System.Drawing.Point(49, 140);
            this.com_sup.Name = "com_sup";
            this.com_sup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.com_sup.Size = new System.Drawing.Size(334, 31);
            this.com_sup.TabIndex = 9;
            this.com_sup.SelectedIndexChanged += new System.EventHandler(this.com_sup_SelectedIndexChanged);
            // 
            // com_model
            // 
            this.com_model.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_model.FormattingEnabled = true;
            this.com_model.Location = new System.Drawing.Point(634, 140);
            this.com_model.Name = "com_model";
            this.com_model.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.com_model.Size = new System.Drawing.Size(334, 31);
            this.com_model.TabIndex = 8;
            this.com_model.SelectedIndexChanged += new System.EventHandler(this.com_model_SelectedIndexChanged);
            // 
            // com_cat
            // 
            this.com_cat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.com_cat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.com_cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.com_cat.FormattingEnabled = true;
            this.com_cat.Location = new System.Drawing.Point(634, 82);
            this.com_cat.Name = "com_cat";
            this.com_cat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.com_cat.Size = new System.Drawing.Size(334, 31);
            this.com_cat.TabIndex = 7;
            this.com_cat.SelectedIndexChanged += new System.EventHandler(this.com_cat_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(990, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "الموديل";
            // 
            // txt_proprice
            // 
            this.txt_proprice.Font = new System.Drawing.Font("Arial Narrow", 16F);
            this.txt_proprice.Location = new System.Drawing.Point(49, 199);
            this.txt_proprice.Multiline = true;
            this.txt_proprice.Name = "txt_proprice";
            this.txt_proprice.Size = new System.Drawing.Size(334, 30);
            this.txt_proprice.TabIndex = 5;
            this.txt_proprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_proprice_KeyPress);
            // 
            // txt_prodes
            // 
            this.txt_prodes.Location = new System.Drawing.Point(49, 28);
            this.txt_prodes.MaxLength = 100;
            this.txt_prodes.Multiline = true;
            this.txt_prodes.Name = "txt_prodes";
            this.txt_prodes.Size = new System.Drawing.Size(334, 85);
            this.txt_prodes.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(405, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "المورد";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(405, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "السعر";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(405, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "الوصف";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(990, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "الكمية";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(990, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "الفئة";
            // 
            // txt_proname
            // 
            this.txt_proname.Location = new System.Drawing.Point(634, 28);
            this.txt_proname.MaxLength = 50;
            this.txt_proname.Multiline = true;
            this.txt_proname.Name = "txt_proname";
            this.txt_proname.Size = new System.Drawing.Size(334, 30);
            this.txt_proname.TabIndex = 3;
            this.txt_proname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_proname_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(990, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "اسم المنتج";
            // 
            // home_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1113, 591);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial Narrow", 14.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "home_form";
            this.Text = "home_form";
            this.Load += new System.EventHandler(this.home_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_pro)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_q)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_description;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_cat;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_model;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_sup;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn pro_date;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_pro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown num_q;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox com_sup;
        private System.Windows.Forms.ComboBox com_model;
        private System.Windows.Forms.ComboBox com_cat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_proprice;
        private System.Windows.Forms.TextBox txt_prodes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_proname;
        private System.Windows.Forms.Label label1;
    }
}