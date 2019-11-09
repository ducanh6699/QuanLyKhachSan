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
    public partial class DSTaiKhoan : Form
    {
        public DSTaiKhoan()
        {
            InitializeComponent();
        }

        String MaND,MaSuaND;

        private void DSTaiKhoan_Load(object sender, EventArgs e)
        {
            LayBangNguoiDung();
            LayQuyen();
            TaoMaNguoiDung();
            btnSua.Hide();
            btnMoFormThem.Hide();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                if (txtTK.Text == "" || txtMK.Text == "")
                {
                    MessageBox.Show("Bạn Không Thể Bỏ Trống Tài Khoản Hoặc Mật Khẩu", "Thông báo");
                    return;
                }
                else if (KiemTraTonTaiTaiKhoan(txtTK.Text))
                {
                    MessageBox.Show("Tài Khoản Đã Tồn Tại Trong Hệ Thống", "Thông báo");
                    return;
                }
                String sql = String.Format("insert into NguoiDung (Id,idQuyen,TaiKhoan,MatKhau,TenNguoiDung,DiaChi,Email) values({0},{1},'{2}','{3}','{4}','{5}','{6}')", MaND, cbQuyen.SelectedValue.ToString(), txtTK.Text, txtMK.Text, txtTenNgD.Text, txtDiaChi.Text, txtEmail.Text);
                DungChung.ThemSuaXoaQuery(sql);
                MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo");
                ClearForm();
                TaoMaNguoiDung();
                LayBangNguoiDung();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                if (txtTK.Text == "" || txtMK.Text == "")
                {
                    MessageBox.Show("Bạn Không Thể Bỏ Trống Tài Khoản Hoặc Mật Khẩu", "Thông báo");
                    return;
                }
                String sql = String.Format("update NguoiDung set IdQuyen = {0}, TaiKhoan = '{1}', MatKhau = '{2}', TenNguoiDung = '{3}', DiaChi = '{4}', Email = '{5}' where Id = {6}", cbQuyen.SelectedValue.ToString(), txtTK.Text, txtMK.Text, txtTenNgD.Text, txtDiaChi.Text, txtEmail.Text, MaSuaND);
                DungChung.ThemSuaXoaQuery(sql);
                MessageBox.Show("Sửa Thành Công!", "Thông Báo");
                TaoMaNguoiDung();
                LayBangNguoiDung();
                btnMoFormThem_Click(sender, e);
            }
        }

        private void TaoMaNguoiDung()
        {
            String sql = "SELECT Top 1 * FROM NguoiDung ORDER BY NguoiDung.Id DESC";
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);
            if (tb.Rows.Count > 0)
                MaND = (int.Parse(tb.Rows[0]["Id"].ToString()) + 1).ToString();
            else
                MaND = "1";
        }

        private void ClearForm()
        {
            if (labelThemSua.Text == "THÊM NGƯỜI DÙNG")
            {
                txtTK.Enabled = true;
                txtDiaChi.Text = "";
                txtEmail.Text = "";
                txtMK.Text = "";
                txtTenNgD.Text = "";
                txtTK.Text = "";
            }
            else
            {
                txtDiaChi.Text = "";
                txtEmail.Text = "";
                txtMK.Text = "";
                txtTenNgD.Text = "";
                cbQuyen.SelectedText = "";
            }
            
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void LayBangNguoiDung()
        {
            String sql = "select * from NguoiDung";
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);

            dgvNguoiDung.DataSource = tb;
        }

        private void LayQuyen()
        {
            String sql = "select * from Quyen";
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);

            cbQuyen.DataSource = tb;
            cbQuyen.DisplayMember = "TenQuyen";
            cbQuyen.ValueMember = "Id";

        }


        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1) // bấm nút sửa trên dgv
            {
                txtTK.Enabled = false;
                MaSuaND = dgvNguoiDung.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbQuyen.SelectedValue = dgvNguoiDung.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtTK.Text = dgvNguoiDung.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtMK.Text = dgvNguoiDung.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtTenNgD.Text = dgvNguoiDung.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtDiaChi.Text = dgvNguoiDung.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtEmail.Text = dgvNguoiDung.Rows[e.RowIndex].Cells[8].Value.ToString();
                
                labelThemSua.Text = "SỬA NGƯỜI DÙNG";
                gbNguoiDung.Text = "Sửa người dùng";
                btnSua.Show();
                btnThem.Hide();
                btnMoFormThem.Show();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1) // bấm nút xóa trên dgv
            {
                if (DungChung.confirm())
                {
                    if (int.Parse(dgvNguoiDung.Rows[e.RowIndex].Cells[2].Value.ToString()) == DungChung.MaNguoiDung)
                    {
                        MessageBox.Show("Bạn Không Thể Xóa Tài Khoản Chính Mình", "Thông báo");
                        return;
                    }
                    String sql = String.Format("delete from NguoiDung where Id = {0}", dgvNguoiDung.Rows[e.RowIndex].Cells[2].Value.ToString());
                    DungChung.ThemSuaXoaQuery(sql);
                    MessageBox.Show("Xóa Thành Công!", "Thông Báo");
                    TaoMaNguoiDung();
                    LayBangNguoiDung();
                    btnMoFormThem_Click(sender, e);
                }
            }
        }

        protected bool KiemTraTonTaiTaiKhoan(String TK)
        {
            String sql = String.Format("select * from NguoiDung where TaiKhoan ='{0}'", TK);
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);

            if (tb.Rows.Count > 0) return true;
            return false;
        }

        private void btnMoFormThem_Click(object sender, EventArgs e)
        {
            labelThemSua.Text = "THÊM NGƯỜI DÙNG";
            btnThem.Show();
            btnSua.Hide();
            ClearForm();
            btnMoFormThem.Hide();
            gbNguoiDung.Text = "Thêm người dùng";
        }
    }
}
