using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String sql = String.Format("select * from NguoiDung where TaiKhoan = '{0}' and MatKhau = '{1}'", txtTaiKhoan.Text, txtMatKhau.Text);
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);

            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Tài Khoản hoặc Mật Khẩu sai", "Thông Báo");
                return;
            }

            DungChung.MaNguoiDung = int.Parse(tb.Rows[0]["id"].ToString());
            this.Hide();
            DSTaiKhoan tk = new DSTaiKhoan();
            tk.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DungChung.Thoat();
        }
    }
}
