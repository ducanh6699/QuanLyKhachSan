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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            layChucNang();
           
        }

        private void layChucNang()
        {
            String sql = "select * from ChucNang";
            DataTable dt = DungChung.XemQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Button btn = new Button();
                btn.Tag = dt.Rows[i]["TenChucNang"].ToString();
                btn.Text = dt.Rows[i]["MoTa"].ToString();
                btn.Height = 100;
                btn.Width = 150;
                btn.Click += btnflp_Click;
                btn.Enabled = (DungChung.ChucNangCuaNguoiDung.IndexOf(dt.Rows[i]["TenChucNang"].ToString()) > -1);
                flpbutton.Controls.Add(btn);
            }
        }

        private void btnflp_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            switch (btn.Text)
            {
                case "Danh sách khách hàng":
                    DSKhachHang DSKhachHang = new DSKhachHang();
                    DSKhachHang.ShowDialog();
                    break;

                case "Danh sách người dùng":
                    DSTaiKhoan DSTaiKhoan = new DSTaiKhoan();
                    DSTaiKhoan.ShowDialog();
                    break;

                case "Danh sách phòng":
                    DSPhong DSPhong = new DSPhong();
                    DSPhong.ShowDialog();
                    break;

                default:
                    MessageBox.Show("Chức năng này đang phát triển", "Thông báo");
                    break;
            }
        }

        private void userToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Đăng xuất":
                    DungChung.ChucNangCuaNguoiDung = "";
                    DangNhap DangNhap = new DangNhap();
                    DangNhap.Show();
                    this.Close();
                    break;

                case "Thoát chương trình":
                    DungChung.Thoat();
                    break;

                default:
                    MessageBox.Show("Chức năng này đang phát triển", "Thông báo");
                    break;
            } 
        }
    }
}
