using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace QuanLyKhachSan
{
    public partial class TimPhong : Form
    {
        public TimPhong()
        {
            InitializeComponent();
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dateTimePickerDi.Value > dateTimePickerDen.Value)
            {
                if (!String.IsNullOrEmpty(textBoxSoNguoi.Text))
                {
                    String NgayDen = dateTimePickerDen.Value.ToString("MM/dd/yyyy");
                    String NgayDi = dateTimePickerDi.Value.ToString("MM/dd/yyyy");
                    String sql = String.Format(@"SELECT Phong.ID, Phong.SoPhong, LoaiPhong.TenLoaiPhong, LoaiPhong.SoGiuong, LoaiPhong.DonGia
                                         FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.ID = Phong.IDLoaiPhong
                                         WHERE (((Phong.ID) Not In (Select DatPhong.IDPhong From DatPhong Where (DatPhong.NgayDen <= #{0}# AND DatPhong.NgayDi >= #{0}#)
                                         OR (DatPhong.NgayDen <= #{1}# AND DatPhong.NgayDi >= #{1}#) )) 
                                         AND ((LoaiPhong.SoGiuong)={2}));", NgayDen, NgayDi, textBoxSoNguoi.Text);
                    DataTable tbl = DungChung.XemQuery(sql);
                    if (tbl.Rows.Count == 0)
                    {
                        MessageBox.Show("Hiện không có phòng trống phù hợp!");
                    }
                    else
                    {
                        dgvPhong.DataSource = tbl;
                    }
                }
                else MessageBox.Show("Vui lòng nhập số người!");
            }
            else
            {
                MessageBox.Show("Dữ liệu vừa nhập không hợp lệ!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxSoNguoi.Text = "";
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                txtIDPhong.Text = dgvPhong.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoPhong.Text = dgvPhong.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDonGia.Text = dgvPhong.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtNgayDen.Text = dateTimePickerDen.Value.ToString("MM/dd/yyyy");
                txtNgayDi.Text = dateTimePickerDi.Value.ToString("MM/dd/yyyy");
                txtChiPhi.Text = (int.Parse(dgvPhong.Rows[e.RowIndex].Cells[5].Value.ToString()) * totalday(dateTimePickerDen.Value, dateTimePickerDi.Value)).ToString();
                gbDatPhong.Visible = true;
                label9.Visible = true;
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            String sql = String.Format("Select * from KhachHang where SDT = '{0}'", txtSDT.Text);
            DataTable tbl = DungChung.XemQuery(sql);
            if (tbl.Rows.Count != 0)
            {
                txtTenKhachHang.Text = tbl.Rows[0]["Ten"].ToString();
                txtTenKhachHang.ReadOnly = true;
                txtDiaChi.Text = tbl.Rows[0]["DiaChi"].ToString();
                txtDiaChi.ReadOnly = true;
                txtNgaySinh.Text = DateTime.Parse(tbl.Rows[0]["NgaySinh"].ToString()).ToString("MM/dd/yyyy");
                txtNgaySinh.ReadOnly = true;
                txtGioiTinh.Text = tbl.Rows[0]["GioiTinh"].ToString();
                txtGioiTinh.ReadOnly = true;
            }
            else
            {
                txtTenKhachHang.ReadOnly = false;
                txtDiaChi.ReadOnly = false;
                txtNgaySinh.ReadOnly = false;
                txtGioiTinh.ReadOnly = false;
                txtTenKhachHang.Text = "";
                txtDiaChi.Text = "";
                txtNgaySinh.Text = "";
                txtGioiTinh.Text = "";
            }
        }
        public void refreshDatPhong()
        {
            txtTenKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtNgaySinh.Text = "";
            txtGioiTinh.Text = "";
            txtNgayDen.Text = "";
            txtNgayDi.Text = "";
            txtDonGia.Text = "";
            txtChiPhi.Text = "";
            txtSoPhong.Text = "";
            txtSDT.Text = "";
        }

        private void btnLamMoiThem_Click(object sender, EventArgs e)
        {
            refreshDatPhong();
        }

        public static int totalday(DateTime dt1, DateTime dt2)
        {
            int days = (dt2 - dt1).Days;
            if (days == 0) return 1;
            else return days + 1;
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            String id;
            String sql = String.Format("Select * from KhachHang where sdt = '{0}'",txtSDT.Text);
            DataTable tbl = DungChung.XemQuery(sql);
            if (tbl.Rows.Count == 0 )
            {
                sql = String.Format("INSERT into KhachHang (Ten,NgaySinh,GioiTinh,DiaChi,SDT) VALUES('{0}',#{1}#,'{2}','{3}','{4}')", txtTenKhachHang.Text, txtNgaySinh.Text, txtGioiTinh.Text, txtDiaChi.Text, txtSDT.Text);
                DungChung.ThemSuaXoaQuery(sql);
                sql = "select ID from KhachHang Order by ID DESC";
                id = DungChung.XemQuery(sql).Rows[0]["ID"].ToString();
            }
            else
            {
                id = tbl.Rows[0]["ID"].ToString();
            }
            sql = String.Format("insert Into HoaDon (IDKhachHang,IDPhong,TongSoTien,DaThanhToan) Values({0},{1},'{2}',false)",id,txtIDPhong.Text,txtChiPhi.Text);
            DungChung.ThemSuaXoaQuery(sql);
            sql = String.Format("insert Into DatPhong (IDKhachHang,IDPhong,NgayDen,NgayDi) Values({0},{1},#{2}#,#{3}#)", id, txtIDPhong.Text, txtNgayDen.Text,txtNgayDi.Text);
            DungChung.ThemSuaXoaQuery(sql);
            MessageBox.Show("Đặt phòng thành công");
            button2_Click(sender, e);
        }

        private void TimPhong_Load(object sender, EventArgs e)
        {
            gbDatPhong.Visible = false;
            label9.Visible = false;
        }
    }
}
