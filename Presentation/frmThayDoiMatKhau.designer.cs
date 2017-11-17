namespace RUP
{
    partial class frmThayDoiMatKhau
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
            this.txtMatKhauCu = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtMatKhauMoi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtNhapLaiMatKhau = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.txtLoiMatKhauCu = new System.Windows.Forms.Label();
            this.txtLoiMatKhauMoiNhapLai = new System.Windows.Forms.Label();
            this.txtLoiMatKhauMoi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMatKhauCu
            // 
            // 
            // 
            // 
            this.txtMatKhauCu.Border.Class = "TextBoxBorder";
            this.txtMatKhauCu.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMatKhauCu.Location = new System.Drawing.Point(166, 40);
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.PasswordChar = '*';
            this.txtMatKhauCu.PreventEnterBeep = true;
            this.txtMatKhauCu.Size = new System.Drawing.Size(170, 20);
            this.txtMatKhauCu.TabIndex = 0;
            // 
            // txtMatKhauMoi
            // 
            // 
            // 
            // 
            this.txtMatKhauMoi.Border.Class = "TextBoxBorder";
            this.txtMatKhauMoi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMatKhauMoi.Location = new System.Drawing.Point(166, 72);
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.PasswordChar = '*';
            this.txtMatKhauMoi.PreventEnterBeep = true;
            this.txtMatKhauMoi.Size = new System.Drawing.Size(170, 20);
            this.txtMatKhauMoi.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(30, 40);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(105, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Nhập Mật Khẩu Cũ :";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(30, 72);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(105, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Nhập Mật Khẩu Mới :";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(30, 101);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(105, 23);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "Nhập Lại Mật Khẩu";
            // 
            // txtNhapLaiMatKhau
            // 
            // 
            // 
            // 
            this.txtNhapLaiMatKhau.Border.Class = "TextBoxBorder";
            this.txtNhapLaiMatKhau.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNhapLaiMatKhau.Location = new System.Drawing.Point(166, 98);
            this.txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            this.txtNhapLaiMatKhau.PasswordChar = '*';
            this.txtNhapLaiMatKhau.PreventEnterBeep = true;
            this.txtNhapLaiMatKhau.Size = new System.Drawing.Size(170, 20);
            this.txtNhapLaiMatKhau.TabIndex = 1;
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Location = new System.Drawing.Point(105, 152);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(249, 152);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // txtLoiMatKhauCu
            // 
            this.txtLoiMatKhauCu.AutoSize = true;
            this.txtLoiMatKhauCu.Location = new System.Drawing.Point(342, 45);
            this.txtLoiMatKhauCu.Name = "txtLoiMatKhauCu";
            this.txtLoiMatKhauCu.Size = new System.Drawing.Size(0, 13);
            this.txtLoiMatKhauCu.TabIndex = 5;
            // 
            // txtLoiMatKhauMoiNhapLai
            // 
            this.txtLoiMatKhauMoiNhapLai.AutoSize = true;
            this.txtLoiMatKhauMoiNhapLai.Location = new System.Drawing.Point(342, 101);
            this.txtLoiMatKhauMoiNhapLai.Name = "txtLoiMatKhauMoiNhapLai";
            this.txtLoiMatKhauMoiNhapLai.Size = new System.Drawing.Size(0, 13);
            this.txtLoiMatKhauMoiNhapLai.TabIndex = 5;
            // 
            // txtLoiMatKhauMoi
            // 
            this.txtLoiMatKhauMoi.AutoSize = true;
            this.txtLoiMatKhauMoi.Location = new System.Drawing.Point(342, 74);
            this.txtLoiMatKhauMoi.Name = "txtLoiMatKhauMoi";
            this.txtLoiMatKhauMoi.Size = new System.Drawing.Size(0, 13);
            this.txtLoiMatKhauMoi.TabIndex = 5;
            // 
            // frmThayDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(459, 202);
            this.Controls.Add(this.txtLoiMatKhauMoi);
            this.Controls.Add(this.txtLoiMatKhauMoiNhapLai);
            this.Controls.Add(this.txtLoiMatKhauCu);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtNhapLaiMatKhau);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.txtMatKhauCu);
            this.Name = "frmThayDoiMatKhau";
            this.Text = "Thay đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmThayDoiMatKhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtMatKhauCu;
        private DevComponents.DotNetBar.Controls.TextBoxX txtMatKhauMoi;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNhapLaiMatKhau;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private System.Windows.Forms.Label txtLoiMatKhauCu;
        private System.Windows.Forms.Label txtLoiMatKhauMoiNhapLai;
        private System.Windows.Forms.Label txtLoiMatKhauMoi;
    }
}