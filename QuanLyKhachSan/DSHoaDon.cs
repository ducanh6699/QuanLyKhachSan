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
    public partial class DSHoaDon : Form
    {
        public DSHoaDon()
        {
            InitializeComponent();
        }

        private void DSHoaDon_Load(object sender, EventArgs e)
        {
            layDSHoaDon();
        }

        String MaDP;

        private void layDSHoaDon()
        {
            DataTable dt = DungChung.XemQuery(@"SELECT HoaDon.ID, KhachHang.Ten, KhachHang.NgaySinh, KhachHang.GioiTinh, KhachHang.DiaChi, KhachHang.SDT, Phong.SoPhong, LoaiPhong.TenLoaiPhong, LoaiPhong.SoGiuong, LoaiPhong.DonGia, DatPhong.NgayDen, DatPhong.NgayDi, HoaDon.TongSoTien, HoaDon.IDDatPhong
                                                        FROM (LoaiPhong INNER JOIN Phong ON LoaiPhong.ID = Phong.IDLoaiPhong) INNER JOIN (KhachHang INNER JOIN (DatPhong INNER JOIN HoaDon ON DatPhong.ID = HoaDon.IDDatPhong) ON KhachHang.ID = DatPhong.IDKhachHang) ON Phong.ID = DatPhong.IDPhong;");
            dt.Columns.Add("TongTienPhong", typeof(String));
            dt.Columns.Add("TongTienDichVu", typeof(String));
            dt.Columns.Add("NgayMuon", typeof(DateTime));
            dt.Columns.Add("NgayTra", typeof(DateTime));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["TongTienDichVu"] = TienDichVu(dt.Rows[i]["IDDatPhong"].ToString()).ToString();
                dt.Rows[i]["TongTienPhong"] = (int.Parse(dt.Rows[i]["TongSoTien"].ToString()) - int.Parse(dt.Rows[i]["TongTienDichVu"].ToString())).ToString();
                int songaymuon = 0;
                int tienphong = int.Parse(dt.Rows[i]["TongTienPhong"].ToString());
                DateTime NgayMuon, NgayTra;
                if (tienphong % int.Parse(dt.Rows[i]["DonGia"].ToString()) == 0)
                {
                    songaymuon = tienphong / int.Parse(dt.Rows[i]["DonGia"].ToString());
                    if (songaymuon == 1)
                    {
                        NgayMuon = DateTime.Parse(dt.Rows[i]["NgayDen"].ToString()).AddDays(1);
                        NgayTra = DateTime.Parse(dt.Rows[i]["NgayDi"].ToString()).AddDays(1);
                    }
                    else
                    {
                        NgayMuon = DateTime.Parse(dt.Rows[i]["NgayDen"].ToString()).AddDays(-(songaymuon - 1));
                        NgayTra = NgayMuon.AddDays(songaymuon);
                    }
                }
                else
                {
                    NgayMuon = DateTime.Parse(dt.Rows[i]["NgayDen"].ToString()).AddDays(1);
                    NgayTra = DateTime.Parse(dt.Rows[i]["NgayDi"].ToString()).AddDays(1);
                }
                dt.Rows[i]["NgayMuon"] = NgayMuon.ToString();
                dt.Rows[i]["NgayTra"] = NgayTra.ToString();
            }
            dgvHoaDon.DataSource = dt;
        }

        private int TienDichVu(String IDDatPhong)
        {
            DataTable dt = DungChung.XemQuery(String.Format(@"SELECT Sum(DatPhong_DichVu.TongTien) AS SumOfTongTien
                                                                    FROM DatPhong_DichVu
                                                                    GROUP BY DatPhong_DichVu.idDatPhong
                                                                    HAVING (((DatPhong_DichVu.idDatPhong)={0}));", IDDatPhong));
            if (dt.Rows.Count > 0) return int.Parse(dt.Rows[0]["SumOfTongTien"].ToString());
            return 0;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1) // bấm nút in trên dgv
            {
                if (DungChung.confirm())
                {
                    String sql = String.Format(@"SELECT HoaDon.ID, KhachHang.Ten, KhachHang.NgaySinh, KhachHang.GioiTinh, KhachHang.DiaChi, KhachHang.SDT, Phong.SoPhong, LoaiPhong.TenLoaiPhong, LoaiPhong.SoGiuong, LoaiPhong.DonGia, DatPhong.NgayDen, DatPhong.NgayDi, HoaDon.TongSoTien, HoaDon.IDDatPhong
                                                        FROM (LoaiPhong INNER JOIN Phong ON LoaiPhong.ID = Phong.IDLoaiPhong) INNER JOIN (KhachHang INNER JOIN (DatPhong INNER JOIN HoaDon ON DatPhong.ID = HoaDon.IDDatPhong) ON KhachHang.ID = DatPhong.IDKhachHang) ON Phong.ID = DatPhong.IDPhong where HoaDon.ID = {0}", dgvHoaDon.Rows[e.RowIndex].Cells[2].Value.ToString());
                    System.Diagnostics.Process.Start("http://localhost:58742/hoadon.aspx?sql=" + sql);
                }
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1) // bấm nút xem trên dgv
            {
                MaDP = dgvHoaDon.Rows[e.RowIndex].Cells[14].Value.ToString();
                dgvDichVu.DataSource = DungChung.XemQuery(String.Format(@"SELECT DichVu.TenDichVu, DichVu.DonGia, DichVu.MoTa, DatPhong_DichVu.SoLuong, DatPhong_DichVu.TongTien
                                                                                FROM DichVu INNER JOIN DatPhong_DichVu ON DichVu.ID = DatPhong_DichVu.idDichVu
                                                                                WHERE (((DatPhong_DichVu.idDatPhong)={0}));
                                                                                ", MaDP));
            }
        }

    }
}
