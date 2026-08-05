namespace stock_management_project
{
    partial class report_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(report_form));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_pro_go = new System.Windows.Forms.PictureBox();
            this.pic_ord_go = new System.Windows.Forms.PictureBox();
            this.pic_ret_go = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pro_go)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ord_go)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ret_go)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pic_pro_go);
            this.panel1.Controls.Add(this.pic_ord_go);
            this.panel1.Controls.Add(this.pic_ret_go);
            this.panel1.Location = new System.Drawing.Point(13, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 558);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 19F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(193, 390);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "الراجع";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(803, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "المنتجات";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(469, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "الطلبات";
            // 
            // pic_pro_go
            // 
            this.pic_pro_go.Image = ((System.Drawing.Image)(resources.GetObject("pic_pro_go.Image")));
            this.pic_pro_go.Location = new System.Drawing.Point(736, 189);
            this.pic_pro_go.Name = "pic_pro_go";
            this.pic_pro_go.Size = new System.Drawing.Size(223, 178);
            this.pic_pro_go.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_pro_go.TabIndex = 0;
            this.pic_pro_go.TabStop = false;
            this.pic_pro_go.Click += new System.EventHandler(this.pic_pro_go_Click);
            // 
            // pic_ord_go
            // 
            this.pic_ord_go.Image = ((System.Drawing.Image)(resources.GetObject("pic_ord_go.Image")));
            this.pic_ord_go.Location = new System.Drawing.Point(419, 189);
            this.pic_ord_go.Name = "pic_ord_go";
            this.pic_ord_go.Size = new System.Drawing.Size(218, 178);
            this.pic_ord_go.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ord_go.TabIndex = 0;
            this.pic_ord_go.TabStop = false;
            this.pic_ord_go.Click += new System.EventHandler(this.pic_ord_go_Click);
            // 
            // pic_ret_go
            // 
            this.pic_ret_go.Image = ((System.Drawing.Image)(resources.GetObject("pic_ret_go.Image")));
            this.pic_ret_go.Location = new System.Drawing.Point(122, 160);
            this.pic_ret_go.Name = "pic_ret_go";
            this.pic_ret_go.Size = new System.Drawing.Size(225, 207);
            this.pic_ret_go.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ret_go.TabIndex = 0;
            this.pic_ret_go.TabStop = false;
            this.pic_ret_go.Click += new System.EventHandler(this.pic_ret_go_Click);
            // 
            // report_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 591);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "report_form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "report_form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pro_go)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ord_go)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ret_go)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pic_pro_go;
        private System.Windows.Forms.PictureBox pic_ord_go;
        private System.Windows.Forms.PictureBox pic_ret_go;
    }
}