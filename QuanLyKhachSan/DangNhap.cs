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
            DungChung.Quyen = int.Parse(tb.Rows[0]["idQuyen"].ToString());
            sql = String.Format("SELECT ChucNang.TenChucNang, ChucNang.MoTa FROM ChucNang_Quyen INNER JOIN ChucNang ON ChucNang_Quyen.idChucNang = ChucNang.ID WHERE (((ChucNang_Quyen.idQuyen)={0})); ", tb.Rows[0]["idQuyen"].ToString());
            tb = DungChung.XemQuery(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                DungChung.ChucNangCuaNguoiDung += tb.Rows[i]["TenChucNang"].ToString();
            }
            this.Hide();
            Menu Menu = new Menu();
            Menu.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DungChung.Thoat();
        }
    }
}
