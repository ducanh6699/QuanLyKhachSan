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
    public partial class DSKhachHang : Form
    {
        public DSKhachHang()
        {
            InitializeComponent();
        }

        String MaKH, MaSuaKH;

        private void TaoMaKhachHang()
        {
            String sql = "SELECT Top 1 * FROM KhachHang ORDER BY KhachHang.Id DESC";
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);
            if (tb.Rows.Count > 0)
                MaKH = (int.Parse(tb.Rows[0]["Id"].ToString()) + 1).ToString();
            else
                MaKH = "1";
        }

        protected bool KiemTraTonTaiTaiKhoan(String SDT)
        {
            String sql = String.Format("select * from KhachHang where SDT = '{0}'", SDT);
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);

            if (tb.Rows.Count > 0) return true;
            return false;
        }

        private void ClearForm()
        {
            txtTenKH.Text = "";
            cbNgay.SelectedIndex = 0;
            cbThang.SelectedIndex = 0;
            cbNamSinh.SelectedIndex = 0;
            cbNam.Checked = true;
            txtDiaChi.Text = "";
            txtSDT.Text = "";
        }

        private void LayBangKhachHang()
        {
            String sql = "select * from KhachHang";
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);

            dgvKhachHang.DataSource = tb;
        }

        private bool isDate(String str)
        {
            bool isDate = true;
            DateTime dt = new DateTime();

            try
            {
                dt = DateTime.Parse(str);
            }
            catch
            {
                isDate = false;
            }

            return isDate;
        }

        private void NgayThangNam()
        {
            for (int i = 1; i < 32; i++)
            {
                cbNgay.Items.Add(i.ToString());
            }

            for (int i = 1; i < 13; i++)
            {
                cbThang.Items.Add(i.ToString());
            }

            for (int i = 1900; i <= DateTime.Today.Year; i++)
            {
                cbNamSinh.Items.Add(i.ToString());
            }
        }

        private void DSKhachHang_Load(object sender, EventArgs e)
        {
            LayBangKhachHang();
            TaoMaKhachHang();
            NgayThangNam();
            btnSua.Hide();
            btnMoFormThem.Hide();
            ClearForm();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                String ngaysinh = cbNgay.SelectedItem.ToString() + "-" + cbThang.SelectedItem.ToString() + "-" + cbNamSinh.SelectedItem.ToString();
                if (txtTenKH.Text == "" || txtSDT.Text == "")
                {
                    MessageBox.Show("Bạn Không Thể Bỏ Trống tên khách hàng và số điện thoại", "Thông báo");
                    return;
                }
                else if (!isDate(ngaysinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo");
                    return;
                }
                String sql = String.Format("update KhachHang set Ten = '{0}', NgaySinh = '{1}', GioiTinh = '{2}', DiaChi = '{3}', SDT = '{4}' where Id = {5}", txtTenKH.Text, DateTime.Parse(ngaysinh).ToString(), (cbNam.Checked == true) ? "Nam" : "Nữ", txtDiaChi.Text, txtSDT.Text, MaSuaKH);
                DungChung.ThemSuaXoaQuery(sql);
                MessageBox.Show("Sửa Thành Công!", "Thông Báo");
                TaoMaKhachHang();
                LayBangKhachHang();
                btnMoFormThem_Click(sender, e);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                String ngaysinh = cbNgay.SelectedItem.ToString() + "-" + cbThang.SelectedItem.ToString() + "-" + cbNamSinh.SelectedItem.ToString();
                if (txtTenKH.Text == "" || txtSDT.Text == "")
                {
                    MessageBox.Show("Bạn Không Thể Bỏ Trống tên khách hàng và số điện thoại", "Thông báo");
                    return;
                }
                else if (KiemTraTonTaiTaiKhoan(txtSDT.Text))
                {
                    MessageBox.Show("Khách hàng Đã Tồn Tại Trong Hệ Thống", "Thông báo");
                    return;
                }
                else if (!isDate(ngaysinh))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo");
                    return;
                }
                String sql = String.Format("insert into KhachHang (Id,Ten,NgaySinh,Gioitinh,DiaChi,SDT) values({0},'{1}','{2}','{3}','{4}','{5}')", MaKH, txtTenKH.Text, DateTime.Parse(ngaysinh).ToString(), (cbNam.Checked == true) ? "Nam" : "Nữ", txtDiaChi.Text, txtSDT.Text);
                DungChung.ThemSuaXoaQuery(sql);
                MessageBox.Show("Đã Thêm Thành Công!", "Thông Báo");
                ClearForm();
                TaoMaKhachHang();
                LayBangKhachHang();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnMoFormThem_Click(object sender, EventArgs e)
        {
            labelThemSua.Text = "THÊM KHÁCH HÀNG";
            btnThem.Show();
            btnSua.Hide();
            ClearForm();
            btnMoFormThem.Hide();
            gbKhachHang.Text = "Thêm khách hàng";
        }

        private void cbNam_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNam.Checked == true)
                cbNu.Checked = false;
        }

        private void cbNu_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNu.Checked == true)
                cbNam.Checked = false;
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1) // bấm nút sửa trên dgv
            {
                MaSuaKH = dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtTenKH.Text = dgvKhachHang.Rows[e.RowIndex].Cells[3].Value.ToString();
                DateTime date = Convert.ToDateTime(dgvKhachHang.Rows[e.RowIndex].Cells[4].Value.ToString());
                cbNgay.SelectedItem = date.Day.ToString();
                cbThang.SelectedItem = date.Month.ToString();
                cbNamSinh.SelectedItem = date.Year.ToString();
                if (dgvKhachHang.Rows[e.RowIndex].Cells[5].Value.ToString() == "Nam") cbNam.Checked = true;
                else cbNu.Checked = true;
                
                txtDiaChi.Text = dgvKhachHang.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSDT.Text = dgvKhachHang.Rows[e.RowIndex].Cells[7].Value.ToString();

                labelThemSua.Text = "SỬA KHÁCH HÀNG";
                gbKhachHang.Text = "Sửa khách hàng";
                btnSua.Show();
                btnThem.Hide();
                btnMoFormThem.Show();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1) // bấm nút xóa trên dgv
            {
                if (DungChung.confirm())
                {
                    String sql = String.Format("delete from KhachHang where Id = {0}", dgvKhachHang.Rows[e.RowIndex].Cells[2].Value.ToString());
                    DungChung.ThemSuaXoaQuery(sql);
                    MessageBox.Show("Xóa Thành Công!", "Thông Báo");
                    TaoMaKhachHang();
                    LayBangKhachHang();
                    btnMoFormThem_Click(sender, e);
                }
            }
        }
    }
}
