namespace QuanLyKhachSan
{
    partial class DSTaiKhoan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DSTaiKhoan));
            this.dgvNguoiDung = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSuagrv = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BtnXoagrv = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.gbNguoiDung = new System.Windows.Forms.GroupBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.cbQuyen = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenNgD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.labelThemSua = new System.Windows.Forms.Label();
            this.btnMoFormThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.gbNguoiDung.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNguoiDung
            // 
            this.dgvNguoiDung.AllowUserToAddRows = false;
            this.dgvNguoiDung.AllowUserToDeleteRows = false;
            this.dgvNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.IdQuyen,
            this.TaiKhoan,
            this.MatKhau,
            this.TenNguoiDung,
            this.DiaChi,
            this.Email,
            this.BtnSuagrv,
            this.BtnXoagrv});
            this.dgvNguoiDung.Location = new System.Drawing.Point(17, 50);
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.Size = new System.Drawing.Size(890, 222);
            this.dgvNguoiDung.TabIndex = 9;
            this.dgvNguoiDung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguoiDung_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle3;
            this.id.HeaderText = "Mã Tài Khoản";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 110;
            // 
            // IdQuyen
            // 
            this.IdQuyen.DataPropertyName = "IdQuyen";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.IdQuyen.DefaultCellStyle = dataGridViewCellStyle4;
            this.IdQuyen.HeaderText = "Quyền";
            this.IdQuyen.Name = "IdQuyen";
            this.IdQuyen.ReadOnly = true;
            this.IdQuyen.Visible = false;
            // 
            // TaiKhoan
            // 
            this.TaiKhoan.DataPropertyName = "TaiKhoan";
            this.TaiKhoan.HeaderText = "Tài Khoản";
            this.TaiKhoan.Name = "TaiKhoan";
            this.TaiKhoan.ReadOnly = true;
            this.TaiKhoan.Width = 145;
            // 
            // MatKhau
            // 
            this.MatKhau.DataPropertyName = "MatKhau";
            this.MatKhau.HeaderText = "Mật Khẩu";
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.ReadOnly = true;
            this.MatKhau.Width = 130;
            // 
            // TenNguoiDung
            // 
            this.TenNguoiDung.DataPropertyName = "TenNguoiDung";
            this.TenNguoiDung.HeaderText = "Tên Người Dùng";
            this.TenNguoiDung.Name = "TenNguoiDung";
            this.TenNguoiDung.ReadOnly = true;
            this.TenNguoiDung.Width = 160;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 150;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 120;
            // 
            // BtnSuagrv
            // 
            this.BtnSuagrv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnSuagrv.HeaderText = "Sửa";
            this.BtnSuagrv.Name = "BtnSuagrv";
            this.BtnSuagrv.Text = "Sửa";
            this.BtnSuagrv.UseColumnTextForButtonValue = true;
            this.BtnSuagrv.Width = 70;
            // 
            // BtnXoagrv
            // 
            this.BtnXoagrv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnXoagrv.HeaderText = "Xóa";
            this.BtnXoagrv.Name = "BtnXoagrv";
            this.BtnXoagrv.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BtnXoagrv.Text = "Xóa";
            this.BtnXoagrv.UseColumnTextForButtonValue = true;
            this.BtnXoagrv.Width = 70;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "DANH SÁCH NGƯỜI DÙNG";
            // 
            // gbNguoiDung
            // 
            this.gbNguoiDung.Controls.Add(this.btnLamMoi);
            this.gbNguoiDung.Controls.Add(this.cbQuyen);
            this.gbNguoiDung.Controls.Add(this.txtEmail);
            this.gbNguoiDung.Controls.Add(this.label8);
            this.gbNguoiDung.Controls.Add(this.txtDiaChi);
            this.gbNguoiDung.Controls.Add(this.label7);
            this.gbNguoiDung.Controls.Add(this.txtTenNgD);
            this.gbNguoiDung.Controls.Add(this.label6);
            this.gbNguoiDung.Controls.Add(this.txtMK);
            this.gbNguoiDung.Controls.Add(this.label5);
            this.gbNguoiDung.Controls.Add(this.txtTK);
            this.gbNguoiDung.Controls.Add(this.label4);
            this.gbNguoiDung.Controls.Add(this.btnSua);
            this.gbNguoiDung.Controls.Add(this.label3);
            this.gbNguoiDung.Controls.Add(this.btnThem);
            this.gbNguoiDung.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbNguoiDung.Location = new System.Drawing.Point(17, 339);
            this.gbNguoiDung.Name = "gbNguoiDung";
            this.gbNguoiDung.Size = new System.Drawing.Size(890, 289);
            this.gbNguoiDung.TabIndex = 12;
            this.gbNguoiDung.TabStop = false;
            this.gbNguoiDung.Text = "Thêm người dùng";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnLamMoi.Image")));
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(136, 229);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(75, 27);
            this.btnLamMoi.TabIndex = 16;
            this.btnLamMoi.Text = "Tẩy";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // cbQuyen
            // 
            this.cbQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuyen.FormattingEnabled = true;
            this.cbQuyen.Location = new System.Drawing.Point(136, 196);
            this.cbQuyen.Name = "cbQuyen";
            this.cbQuyen.Size = new System.Drawing.Size(748, 27);
            this.cbQuyen.TabIndex = 15;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(136, 164);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(748, 26);
            this.txtEmail.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 167);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "Email";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(136, 132);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(748, 26);
            this.txtDiaChi.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "Địa chỉ";
            // 
            // txtTenNgD
            // 
            this.txtTenNgD.Location = new System.Drawing.Point(136, 96);
            this.txtTenNgD.Name = "txtTenNgD";
            this.txtTenNgD.Size = new System.Drawing.Size(748, 26);
            this.txtTenNgD.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tên người dùng";
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(136, 61);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(748, 26);
            this.txtMK.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mật khẩu";
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(136, 25);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(748, 26);
            this.txtTK.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tài khoản";
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(809, 229);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 27);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Quyền";
            // 
            // btnThem
            // 
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(809, 229);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 27);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // labelThemSua
            // 
            this.labelThemSua.AutoSize = true;
            this.labelThemSua.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThemSua.Location = new System.Drawing.Point(349, 310);
            this.labelThemSua.Name = "labelThemSua";
            this.labelThemSua.Size = new System.Drawing.Size(248, 26);
            this.labelThemSua.TabIndex = 13;
            this.labelThemSua.Text = "THÊM NGƯỜI DÙNG";
            // 
            // btnMoFormThem
            // 
            this.btnMoFormThem.Image = ((System.Drawing.Image)(resources.GetObject("btnMoFormThem.Image")));
            this.btnMoFormThem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMoFormThem.Location = new System.Drawing.Point(770, 322);
            this.btnMoFormThem.Name = "btnMoFormThem";
            this.btnMoFormThem.Size = new System.Drawing.Size(137, 23);
            this.btnMoFormThem.TabIndex = 14;
            this.btnMoFormThem.Text = "Thêm người dùng";
            this.btnMoFormThem.UseVisualStyleBackColor = true;
            this.btnMoFormThem.Click += new System.EventHandler(this.btnMoFormThem_Click);
            // 
            // DSTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 645);
            this.Controls.Add(this.btnMoFormThem);
            this.Controls.Add(this.labelThemSua);
            this.Controls.Add(this.gbNguoiDung);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNguoiDung);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DSTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách người dùng";
            this.Load += new System.EventHandler(this.DSTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.gbNguoiDung.ResumeLayout(false);
            this.gbNguoiDung.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNguoiDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbNguoiDung;
        private System.Windows.Forms.ComboBox cbQuyen;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label labelThemSua;
        private System.Windows.Forms.TextBox txtTenNgD;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnMoFormThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNguoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewButtonColumn BtnSuagrv;
        private System.Windows.Forms.DataGridViewButtonColumn BtnXoagrv;
    }
}