﻿namespace T02_Source_Code.Presentation
{
    partial class Frm_Them_QuanHuyen
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaQuanHuyen = new System.Windows.Forms.TextBox();
            this.txtTenQuanHuyen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Huy = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_TenTinhThanh = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_TenTinhThanh = new System.Windows.Forms.Label();
            this.lbl_TenPhuongXa = new System.Windows.Forms.Label();
            this.lbl_MaPhuongXa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã quận huyện:";
            // 
            // txtMaQuanHuyen
            // 
            this.txtMaQuanHuyen.Location = new System.Drawing.Point(103, 8);
            this.txtMaQuanHuyen.Name = "txtMaQuanHuyen";
            this.txtMaQuanHuyen.Size = new System.Drawing.Size(187, 20);
            this.txtMaQuanHuyen.TabIndex = 1;
            // 
            // txtTenQuanHuyen
            // 
            this.txtTenQuanHuyen.Location = new System.Drawing.Point(103, 47);
            this.txtTenQuanHuyen.Name = "txtTenQuanHuyen";
            this.txtTenQuanHuyen.Size = new System.Drawing.Size(187, 20);
            this.txtTenQuanHuyen.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên quận huyện:";
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Location = new System.Drawing.Point(46, 123);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 28);
            this.btn_Them.TabIndex = 4;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btn_Huy
            // 
            this.btn_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Huy.Location = new System.Drawing.Point(174, 123);
            this.btn_Huy.Name = "btn_Huy";
            this.btn_Huy.Size = new System.Drawing.Size(75, 28);
            this.btn_Huy.TabIndex = 5;
            this.btn_Huy.Text = "Hủy";
            this.btn_Huy.UseVisualStyleBackColor = true;
            this.btn_Huy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(98, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(99, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = " ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tên tỉnh thành:";
            // 
            // comboBox_TenTinhThanh
            // 
            this.comboBox_TenTinhThanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TenTinhThanh.FormattingEnabled = true;
            this.comboBox_TenTinhThanh.Location = new System.Drawing.Point(101, 89);
            this.comboBox_TenTinhThanh.Name = "comboBox_TenTinhThanh";
            this.comboBox_TenTinhThanh.Size = new System.Drawing.Size(186, 21);
            this.comboBox_TenTinhThanh.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(99, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 10;
            // 
            // lbl_TenTinhThanh
            // 
            this.lbl_TenTinhThanh.AutoSize = true;
            this.lbl_TenTinhThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenTinhThanh.ForeColor = System.Drawing.Color.Red;
            this.lbl_TenTinhThanh.Location = new System.Drawing.Point(100, 110);
            this.lbl_TenTinhThanh.Name = "lbl_TenTinhThanh";
            this.lbl_TenTinhThanh.Size = new System.Drawing.Size(0, 13);
            this.lbl_TenTinhThanh.TabIndex = 14;
            // 
            // lbl_TenPhuongXa
            // 
            this.lbl_TenPhuongXa.AutoSize = true;
            this.lbl_TenPhuongXa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenPhuongXa.ForeColor = System.Drawing.Color.Red;
            this.lbl_TenPhuongXa.Location = new System.Drawing.Point(100, 67);
            this.lbl_TenPhuongXa.Name = "lbl_TenPhuongXa";
            this.lbl_TenPhuongXa.Size = new System.Drawing.Size(0, 13);
            this.lbl_TenPhuongXa.TabIndex = 15;
            // 
            // lbl_MaPhuongXa
            // 
            this.lbl_MaPhuongXa.AutoSize = true;
            this.lbl_MaPhuongXa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaPhuongXa.ForeColor = System.Drawing.Color.Red;
            this.lbl_MaPhuongXa.Location = new System.Drawing.Point(101, 28);
            this.lbl_MaPhuongXa.Name = "lbl_MaPhuongXa";
            this.lbl_MaPhuongXa.Size = new System.Drawing.Size(0, 13);
            this.lbl_MaPhuongXa.TabIndex = 16;
            // 
            // Frm_Them_QuanHuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 157);
            this.Controls.Add(this.lbl_MaPhuongXa);
            this.Controls.Add(this.lbl_TenPhuongXa);
            this.Controls.Add(this.lbl_TenTinhThanh);
            this.Controls.Add(this.comboBox_TenTinhThanh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTenQuanHuyen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaQuanHuyen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Huy);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Them_QuanHuyen";
            this.Text = "Thêm quận huyện";
            this.Load += new System.EventHandler(this.Frm_Them_QuanHuyen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaQuanHuyen;
        private System.Windows.Forms.TextBox txtTenQuanHuyen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Huy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_TenTinhThanh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_TenTinhThanh;
        private System.Windows.Forms.Label lbl_TenPhuongXa;
        private System.Windows.Forms.Label lbl_MaPhuongXa;
    }
}