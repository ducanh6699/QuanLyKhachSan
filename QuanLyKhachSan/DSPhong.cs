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
    public partial class DSPhong : Form
    {
        public DSPhong()
        {
            InitializeComponent();
        }

        private void DSPhong_Load(object sender, EventArgs e)
        {
            layDSPhong();
            LayLoaiPhong();
            LayKhachHang();
            LayDichVu();
            TaoMaPhong();
            TaoMaDatPhong();
            TaoMaDP_DV();
            TaoMaHoaDon();
            btnHienThiThemP.Hide();
            btnHienThiThemDV.Hide();
            btnThemP.Show();
            btnSuaP.Hide();
            btnSuaDP.Hide();
            btnSuaDV.Hide();
            btnTraPhong.Hide();
            btnXoaP.Hide();
            btnThemDP.Hide();
            btnThemDV.Hide();
            cbLP.SelectedValue = 1;
            cbLP_SelectedIndexChanged(sender, e);
            cbKH.SelectedValue = 1;
            cbDV.SelectedValue = 1;
            cbDV_SelectedIndexChanged(sender, e);
            dtNgayDen.Value = DateTime.Today;
            dtNgayDi.Value = DateTime.Today;
            txtGiaPhong.Text = txtMoTaDV.Text = txtSoGiuong.Text = txtSoLuongDV.Text = txtSoPhong.Text = txtDonGiaDV.Text = "";
            txtSoGiuong.Enabled = txtDonGiaDV.Enabled = txtGiaPhong.Enabled = txtMoTaDV.Enabled = false;

            // lam cho dgv dich vu = null
            dgvDichVu.DataSource = DungChung.XemQuery(@"SELECT DatPhong_DichVu.ID, DichVu.ID, DichVu.TenDichVu, DichVu.DonGia, DatPhong_DichVu.SoLuong, DatPhong_DichVu.TongTien
                                            FROM DichVu INNER JOIN DatPhong_DichVu ON DichVu.ID = DatPhong_DichVu.idDichVu
                                            WHERE (((DatPhong_DichVu.idDatPhong)=0));");
        }

        String MaP, MaSuaP, MaDP, MaSuaDP, MaDP_DV, MaSuaDP_DV, MaHD;

        private void layDSPhong()
        {
            flpPhong.Controls.Clear();
            String sql = "SELECT * from Phong";
            DataTable dt = DungChung.XemQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Button btn = new Button();
                btn.Tag = dt.Rows[i]["ID"].ToString();
                btn.Height = 100;
                btn.Width = 100;
                btn.Text = dt.Rows[i]["SoPhong"].ToString();
                btn.Click += btnPhong_Click;
                sql = String.Format("SELECT DatPhong.ID, DatPhong.IDPhong, DatPhong.IDKhachHang, DatPhong.NgayDen, DatPhong.NgayDi FROM DatPhong WHERE (((DatPhong.IDPhong)={0})); ", dt.Rows[i]["ID"].ToString());
                DataTable dtDatPhong = DungChung.XemQuery(sql);
                int TrangThai = 1, DoHoacVang = 0;
                for (int j = 0; j < dtDatPhong.Rows.Count; j++)
                {
                    // creating object of NgayDen
                    DateTime NgayDen = DateTime.Parse(dtDatPhong.Rows[j]["NgayDen"].ToString());

                    // creating object of NgayDi 
                    DateTime NgayDi = DateTime.Parse(dtDatPhong.Rows[j]["NgayDi"].ToString());

                    int valueNgayDen = DateTime.Compare(NgayDen, DateTime.Today);
                    int valueNgayDi = DateTime.Compare(NgayDi, DateTime.Today);

                    if (valueNgayDi < 0) TrangThai = 1; // phong trong
                    else if (valueNgayDen > 0)
                    {
                        TrangThai = 0; // phong duoc dat nhung khach chua den
                        DoHoacVang = j;
                    }
                    else if (valueNgayDi >= 0)
                    {
                        TrangThai = -1; // phong dang co khach o
                        DoHoacVang = j;
                    }
                }

                if (TrangThai == 1) btn.BackColor = Color.Green;
                else if (TrangThai == 0)
                {
                    btn.BackColor = Color.Yellow;
                    btn.Tag = dtDatPhong.Rows[DoHoacVang]["ID"].ToString();
                }
                else
                {
                    btn.BackColor = Color.Red;
                    btn.Tag = dtDatPhong.Rows[DoHoacVang]["ID"].ToString();
                } 
                flpPhong.Controls.Add(btn);
            }
        }

        private void LayLoaiPhong()
        {
            String sql = "select * from LoaiPhong";
            DataTable dt = new DataTable();
            dt = DungChung.XemQuery(sql);

            cbLP.DataSource = dt;
            cbLP.DisplayMember = "TenLoaiPhong";
            cbLP.ValueMember = "ID";
            cbLP.SelectedIndexChanged += cbLP_SelectedIndexChanged;
        }

        private void LayKhachHang()
        {
            String sql = "select * from KhachHang";
            DataTable dt = new DataTable();
            dt = DungChung.XemQuery(sql);

            cbKH.DataSource = dt;
            cbKH.DisplayMember = "Ten";
            cbKH.ValueMember = "ID";
        }

        private void LayDichVu()
        {
            String sql = "select * from DichVu";
            DataTable dt = new DataTable();
            dt = DungChung.XemQuery(sql);

            cbDV.DataSource = dt;
            cbDV.DisplayMember = "TenDichVu";
            cbDV.ValueMember = "ID";
            cbDV.SelectedIndexChanged += cbDV_SelectedIndexChanged;
        }

        private void TaoMaPhong()
        {
            String sql = "SELECT Top 1 * FROM Phong ORDER BY Id DESC";
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);
            if (tb.Rows.Count > 0)
                MaP = (int.Parse(tb.Rows[0]["Id"].ToString()) + 1).ToString();
            else
                MaP = "1";
        }

        private void TaoMaDatPhong()
        {
            String sql = "SELECT Top 1 * FROM DatPhong ORDER BY Id DESC";
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);
            if (tb.Rows.Count > 0)
                MaDP = (int.Parse(tb.Rows[0]["Id"].ToString()) + 1).ToString();
            else
                MaDP = "1";
        }

        private void TaoMaDP_DV()
        {
            String sql = "SELECT Top 1 * FROM DatPhong_DichVu ORDER BY Id DESC";
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);
            if (tb.Rows.Count > 0)
                MaDP_DV = (int.Parse(tb.Rows[0]["Id"].ToString()) + 1).ToString();
            else
                MaDP_DV = "1";
        }

        private void TaoMaHoaDon()
        {
            String sql = "SELECT Top 1 * FROM HoaDon ORDER BY Id DESC";
            DataTable tb = new DataTable();
            tb = DungChung.XemQuery(sql);
            if (tb.Rows.Count > 0)
                MaHD = (int.Parse(tb.Rows[0]["Id"].ToString()) + 1).ToString();
            else
                MaHD = "1";
        }

        private void Clear()
        {
            btnHienThiThemP.Hide();
            btnHienThiThemDV.Hide();
            btnSuaP.Hide();
            btnSuaDP.Hide();
            btnSuaDV.Hide();
            btnThemP.Show();
            btnThemDP.Show();
            btnThemDV.Show();
            cbLP.SelectedValue = 1;
            cbKH.SelectedValue = 1;
            cbDV.SelectedValue = 1;
            dtNgayDen.Value = DateTime.Today;
            dtNgayDi.Value = DateTime.Today;
            txtGiaPhong.Text = txtMoTaDV.Text = txtSoGiuong.Text = txtSoLuongDV.Text = txtSoPhong.Text = txtDonGiaDV.Text = "";
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            Button btn = (Button) sender;
            String sql = "";
            DataTable dt = new DataTable();
            if (btn.BackColor == Color.Red || btn.BackColor == Color.Yellow)
            {
                sql = String.Format(@"SELECT LoaiPhong.ID, KhachHang.ID, Phong.ID, DatPhong.NgayDen, DatPhong.NgayDi
                                            FROM KhachHang INNER JOIN ((LoaiPhong INNER JOIN Phong ON LoaiPhong.ID = Phong.IDLoaiPhong) INNER JOIN DatPhong ON Phong.ID = DatPhong.IDPhong) ON KhachHang.ID = DatPhong.IDKhachHang
                                            WHERE (((DatPhong.ID)={0}));", btn.Tag.ToString());
                dt = DungChung.XemQuery(sql);
                MaSuaP = dt.Rows[0]["Phong.ID"].ToString();
                MaSuaDP = btn.Tag.ToString();
                txtSoPhong.Text = btn.Text;
                cbLP.SelectedValue = dt.Rows[0]["LoaiPhong.ID"].ToString();
                cbLP_SelectedIndexChanged(sender, e);
                cbKH.SelectedValue = dt.Rows[0]["KhachHang.ID"].ToString();
                dtNgayDen.Value = DateTime.Parse(dt.Rows[0]["NgayDen"].ToString());
                dtNgayDi.Value = DateTime.Parse(dt.Rows[0]["NgayDi"].ToString());
                sql = String.Format(@"SELECT DatPhong_DichVu.ID, DichVu.ID, DichVu.TenDichVu, DichVu.DonGia, DatPhong_DichVu.SoLuong, DatPhong_DichVu.TongTien
                                            FROM DichVu INNER JOIN DatPhong_DichVu ON DichVu.ID = DatPhong_DichVu.idDichVu
                                            WHERE (((DatPhong_DichVu.idDatPhong)={0}));", btn.Tag.ToString());
                dgvDichVu.DataSource = DungChung.XemQuery(sql);
                gbThemSuaP.Text = "Sửa phòng";
                gbThemSuaDP.Text = "Sửa đặt phòng";
                gbThemSuaDV.Text = "Thêm dịch vụ";
                btnHienThiThemP.Show();
                btnHienThiThemDV.Hide();
                btnThemDV.Show();
                btnSuaDV.Hide();
                btnSuaP.Show();
                btnThemP.Hide();
                btnSuaDP.Show();
                btnThemDP.Hide();
                btnTraPhong.Show();
                btnXoaP.Show();
            }
//            else if (btn.BackColor == Color.Yellow)
//            {
//                sql = String.Format(@"SELECT LoaiPhong.ID, KhachHang.ID, DatPhong.NgayDen, DatPhong.NgayDi
//                                            FROM KhachHang INNER JOIN ((LoaiPhong INNER JOIN Phong ON LoaiPhong.ID = Phong.IDLoaiPhong) INNER JOIN DatPhong ON Phong.ID = DatPhong.IDPhong) ON KhachHang.ID = DatPhong.IDKhachHang
//                                            WHERE (((DatPhong.ID)={0}));", btn.Tag.ToString());
//                dt = DungChung.XemQuery(sql);
//                txtSoPhong.Text = btn.Text;
//                cbLP.SelectedValue = dt.Rows[0]["LoaiPhong.ID"].ToString();
//                cbLP_SelectedIndexChanged(sender, e);
//                cbKH.SelectedValue = dt.Rows[0]["KhachHang.ID"].ToString();
//                dtNgayDen.Value = DateTime.Parse(dt.Rows[0]["NgayDen"].ToString());
//                dtNgayDi.Value = DateTime.Parse(dt.Rows[0]["NgayDi"].ToString());
//                sql = String.Format(@"SELECT DichVu.ID, DichVu.TenDichVu, DichVu.DonGia, DatPhong_DichVu.SoLuong, DatPhong_DichVu.TongTien
//                                            FROM DichVu INNER JOIN DatPhong_DichVu ON DichVu.ID = DatPhong_DichVu.idDichVu
//                                            WHERE (((DatPhong_DichVu.idDatPhong)={0}));", btn.Tag.ToString());
//                dt = DungChung.XemQuery(sql);
//                dgvDichVu.DataSource = dt;
//                gbThemSuaP.Text = "Sửa phòng";
//                gbThemSuaDP.Text = "Sửa đặt phòng";
//                gbThemSuaDV.Text = "Thêm dịch vụ";
//                btnHienThiThemP.Show();
//                btnSuaP.Show();
//                btnThemP.Hide();
//                btnSuaDP.Show();
//                btnThemDP.Hide();
//            }
            else
            {
                sql = String.Format(@"SELECT Phong.ID, LoaiPhong.ID, Phong.ID, LoaiPhong.TenLoaiPhong, LoaiPhong.SoGiuong, LoaiPhong.DonGia
                                            FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.ID = Phong.IDLoaiPhong
                                            WHERE (((Phong.ID)={0}));", btn.Tag.ToString());
                dt = DungChung.XemQuery(sql);
                MaSuaP = dt.Rows[0]["Phong.ID"].ToString();
                txtSoPhong.Text = btn.Text;
                cbLP.SelectedValue = dt.Rows[0]["LoaiPhong.ID"].ToString();
                cbLP_SelectedIndexChanged(sender, e);
                btnThemP.Hide();
                btnSuaP.Show();
                btnTraPhong.Hide();
                btnXoaP.Show();
                btnHienThiThemP.Show();
                btnHienThiThemDP_Click(sender, e);
                btnHienThiThemDV.Hide();
                btnSuaDP.Hide();
                btnSuaDV.Hide();
                btnThemDV.Hide();
                txtSoLuongDV.Text = "";
                cbDV.SelectedValue = 1;
                cbDV_SelectedIndexChanged(sender, e);

                // lam cho dgv dich vu = null
                dgvDichVu.DataSource = DungChung.XemQuery(@"SELECT DatPhong_DichVu.ID, DichVu.ID, DichVu.TenDichVu, DichVu.DonGia, DatPhong_DichVu.SoLuong, DatPhong_DichVu.TongTien
                                            FROM DichVu INNER JOIN DatPhong_DichVu ON DichVu.ID = DatPhong_DichVu.idDichVu
                                            WHERE (((DatPhong_DichVu.idDatPhong)=0));");
                
            }
        }

        private void btnHienThiThemP_Click(object sender, EventArgs e)
        {
            cbLP.SelectedValue = 1;
            cbLP_SelectedIndexChanged(sender, e);
            txtSoPhong.Text = "";
            btnThemP.Show();
            btnSuaP.Hide();
            btnXoaP.Hide();

            gbThemSuaDP.Text = "Thêm đặt phòng";
            cbKH.SelectedValue = 1;
            dtNgayDen.Value = DateTime.Today;
            dtNgayDi.Value = DateTime.Today;
            btnThemDP.Hide();
            btnSuaDP.Hide();
            btnTraPhong.Hide();

            cbDV.SelectedValue = 1;
            cbDV_SelectedIndexChanged(sender, e);
            txtSoLuongDV.Text = "";
            btnThemDV.Hide();
            btnSuaDV.Hide();
            btnHienThiThemDV.Hide();
            gbThemSuaDV.Text = "Thêm dịch vụ";

            // lam cho dgv dich vu = null
            dgvDichVu.DataSource = DungChung.XemQuery(@"SELECT DatPhong_DichVu.ID, DichVu.ID, DichVu.TenDichVu, DichVu.DonGia, DatPhong_DichVu.SoLuong, DatPhong_DichVu.TongTien
                                            FROM DichVu INNER JOIN DatPhong_DichVu ON DichVu.ID = DatPhong_DichVu.idDichVu
                                            WHERE (((DatPhong_DichVu.idDatPhong)=0));");

            btnHienThiThemP.Hide();
            gbThemSuaP.Text = "Thêm phòng";
        }

        private void btnSuaP_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                String sql = String.Format("update Phong set SoPhong = {0}, IDLoaiPhong = {1} where ID = {2}", txtSoPhong.Text, cbLP.SelectedValue.ToString(), MaSuaP);
                DungChung.ThemSuaXoaQuery(sql);
                MessageBox.Show("sửa thành công!", "Thông Báo");
                DSPhong_Load(sender, e);
            }
        }

        private void btnThemP_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                String sql = String.Format("insert into Phong (Id,SoPhong,IDLoaiPhong) values({0},{1},{2})", MaP, txtSoPhong.Text, cbLP.SelectedValue.ToString());
                DungChung.ThemSuaXoaQuery(sql);
                MessageBox.Show("Đã thêm thành công!", "Thông Báo");
                DSPhong_Load(sender, e);
            }
        }

        private void btnHienThiThemDP_Click(object sender, EventArgs e)
        {
            gbThemSuaDP.Text = "Thêm đặt phòng";
            cbKH.SelectedValue = 1;
            dtNgayDen.Value = DateTime.Today;
            dtNgayDi.Value = DateTime.Today;
            btnThemDP.Show();
            btnSuaDP.Hide();
            btnTraPhong.Hide();
        }

        private void btnSuaDP_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                if (DateTime.Compare(dtNgayDen.Value, dtNgayDi.Value) > 0)
                {
                    MessageBox.Show("Ngày đến hoặc ngày đi không hợp lệ!", "Thông báo");
                }
                else
                {
                    String sql = String.Format("update DatPhong set IDKhachHang = {0}, IDPhong = {1}, NgayDen = '{2}', NgayDi = '{3}'  where ID = {4}", cbKH.SelectedValue.ToString(), MaSuaP, dtNgayDen.Value.ToString(), dtNgayDi.Value.ToString(), MaSuaDP);
                    DungChung.ThemSuaXoaQuery(sql);
                    MessageBox.Show("sửa thành công!", "Thông Báo");
                    DSPhong_Load(sender, e);
                }
            }
        }

        private void btnThemDP_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                if (DateTime.Compare(dtNgayDen.Value, dtNgayDi.Value) > 0)
                {
                    MessageBox.Show("Ngày đến hoặc ngày đi không hợp lệ!", "Thông báo");
                }
                else
                {
                    String sql = String.Format("insert into DatPhong (ID,IDKhachHang,IDPhong,NgayDen,NgayDi) values({0},{1},{2},'{3}','{4}')", MaDP, cbKH.SelectedValue.ToString(), MaSuaP, dtNgayDen.Value.ToString(), dtNgayDi.Value.ToString());
                    DungChung.ThemSuaXoaQuery(sql);
                    MessageBox.Show("Đã thêm thành công!", "Thông Báo");
                    DSPhong_Load(sender, e);
                }
            }
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                if (DateTime.Compare(dtNgayDen.Value, DateTime.Today) > 0) // neu ngay den ma lon hon hom nay tuc phong nay la phong dat truoc
                {
                    String sql = String.Format("update DatPhong set IDKhachHang = {0}, IDPhong = {1}, NgayDen = '{2}', NgayDi = '{3}'  where ID = {4}", cbKH.SelectedValue.ToString(), MaSuaP, DateTime.Today.AddDays(-1).ToString(), DateTime.Today.AddDays(-1).ToString(), MaSuaDP); // sua ngay den va ngay di ve hôm trước ngày thanh toàn 1 ngày để trên DS phòng cập nhật trạng thái phòng
                    DungChung.ThemSuaXoaQuery(sql);
                    DataTable dt = DungChung.XemQuery(String.Format(@"SELECT DatPhong.*, Phong.IDLoaiPhong, LoaiPhong.DonGia , KhachHang.Ten, DatPhong_DichVu.ID, DatPhong_DichVu.idDichVu,  DatPhong_DichVu.TongTien,DichVu.DonGia from (((((DatPhong left join Phong on DatPhong.IDPhong = Phong.ID) left join LoaiPhong on Phong.IDLoaiPhong = LoaiPhong.ID) left join KhachHang on DatPhong.IDKhachHang = KhachHang.ID) left join DatPhong_DichVu on DatPhong.ID = DatPhong_DichVu.IDDatPhong) left join DichVu on DatPhong_DichVu.idDichVu = DichVu.ID) where DatPhong.ID = {0}", MaSuaDP));
                    int TongSoTien = int.Parse(dt.Rows[0]["LoaiPhong.DonGia"].ToString()); // tinh tien phong cho no mac dinh la o 1 ngay vi dat phong
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TongSoTien += (dt.Rows[i]["TongTien"].ToString() == "") ? 0 : int.Parse(dt.Rows[i]["TongTien"].ToString()); // cong them tien dich vu cho no vao hoa don
                    }
                    sql = String.Format("insert into HoaDon (ID,IDDatPhong,TongSoTien) values({0},{1},{2})", MaHD, MaSuaDP, TongSoTien);
                    DungChung.ThemSuaXoaQuery(sql);
                    MessageBox.Show("Trả phòng thành công!", "Thông Báo");
                    DSPhong_Load(sender, e);
                }
                else
                {
                    dtNgayDi.Value = DateTime.Today;
                    TimeSpan SoNgayThue = dtNgayDi.Value.Subtract(dtNgayDen.Value);
                    //int SoNgayThue = DateTime.Compare(, dtNgayDen.Value);TimeSpan ts = t1.Subtract(t2);
                    DataTable dt = DungChung.XemQuery(String.Format(@"SELECT DatPhong.*, Phong.IDLoaiPhong, LoaiPhong.DonGia , KhachHang.Ten, DatPhong_DichVu.ID, DatPhong_DichVu.idDichVu,  DatPhong_DichVu.TongTien,DichVu.DonGia from (((((DatPhong left join Phong on DatPhong.IDPhong = Phong.ID) left join LoaiPhong on Phong.IDLoaiPhong = LoaiPhong.ID) left join KhachHang on DatPhong.IDKhachHang = KhachHang.ID) left join DatPhong_DichVu on DatPhong.ID = DatPhong_DichVu.IDDatPhong) left join DichVu on DatPhong_DichVu.idDichVu = DichVu.ID) where DatPhong.ID = {0}", MaSuaDP));
                    int TongSoTien;
                    if (SoNgayThue.Days == 0) // neu nhu thue trong ngay thu nua gia 1 ngay
                    {
                        TongSoTien = int.Parse(dt.Rows[0]["LoaiPhong.DonGia"].ToString()) / 2;
                    }
                    else if (SoNgayThue.Days == 1) // neu nhu thue qua dem thu gia 1 ngay
                    {
                        TongSoTien = int.Parse(dt.Rows[0]["LoaiPhong.DonGia"].ToString());
                    }
                    else // neu o nhieu hon 1 ngay thi sẽ là đơn giá * ngày ở
                    {
                        TongSoTien = int.Parse(dt.Rows[0]["LoaiPhong.DonGia"].ToString()) * SoNgayThue.Days;
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TongSoTien += (dt.Rows[i]["TongTien"].ToString() == "") ? 0 : int.Parse(dt.Rows[i]["TongTien"].ToString());
                    }
                    String sql = String.Format("insert into HoaDon (ID,IDDatPhong,TongSoTien) values({0},{1},{2})", MaHD, MaSuaDP, TongSoTien);
                    DungChung.ThemSuaXoaQuery(sql);
                    sql = String.Format("update DatPhong set IDKhachHang = {0}, IDPhong = {1}, NgayDen = '{2}', NgayDi = '{3}'  where ID = {4}", cbKH.SelectedValue.ToString(), MaSuaP, DateTime.Today.AddDays(-1).ToString(), DateTime.Today.AddDays(-1).ToString(), MaSuaDP);
                    DungChung.ThemSuaXoaQuery(sql);
                    MessageBox.Show("Trả phòng thành công!", "Thông Báo");
                    DSPhong_Load(sender, e);
                }
            }
        }

        private void btnHienThiThemDV_Click(object sender, EventArgs e)
        {
            cbDV.SelectedValue = 1;
            cbDV_SelectedIndexChanged(sender, e);
            txtSoLuongDV.Text = "";
            btnThemDV.Show();
            btnSuaDV.Hide();
            btnHienThiThemDV.Hide();
            gbThemSuaDV.Text = "Thêm dịch vụ";
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                String sql = String.Format("update DatPhong_DichVu set idDichVu = {0}, SoLuong = {1}, TongTien = {2}  where ID = {3}", cbDV.SelectedValue.ToString(), txtSoLuongDV.Text, (int.Parse(txtDonGiaDV.Text) * int.Parse(txtSoLuongDV.Text)).ToString(), MaSuaDP_DV);
                DungChung.ThemSuaXoaQuery(sql);
                MessageBox.Show("sửa thành công!", "Thông Báo");
                dgvDichVu.DataSource = DungChung.XemQuery(String.Format(@"SELECT DatPhong_DichVu.ID, DichVu.ID, DichVu.TenDichVu, DichVu.DonGia, DatPhong_DichVu.SoLuong, DatPhong_DichVu.TongTien
                                            FROM DichVu INNER JOIN DatPhong_DichVu ON DichVu.ID = DatPhong_DichVu.idDichVu
                                            WHERE (((DatPhong_DichVu.idDatPhong)={0}));", MaSuaDP));
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                String sql = String.Format("insert into DatPhong_DichVu (ID,idDichVu,idDatPhong,SoLuong,TongTien) values({0},{1},{2},{3},{4})", MaDP_DV, cbDV.SelectedValue.ToString(), MaSuaDP, txtSoLuongDV.Text, (int.Parse(txtDonGiaDV.Text) * int.Parse(txtSoLuongDV.Text)).ToString());
                DungChung.ThemSuaXoaQuery(sql);
                MessageBox.Show("Đã thêm thành công!", "Thông Báo");
                TaoMaDP_DV();
                dgvDichVu.DataSource = DungChung.XemQuery(String.Format(@"SELECT DatPhong_DichVu.ID, DichVu.ID, DichVu.TenDichVu, DichVu.DonGia, DatPhong_DichVu.SoLuong, DatPhong_DichVu.TongTien
                                            FROM DichVu INNER JOIN DatPhong_DichVu ON DichVu.ID = DatPhong_DichVu.idDichVu
                                            WHERE (((DatPhong_DichVu.idDatPhong)={0}));", MaSuaDP));
            }
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1) // bấm nút sửa trên dgv
            {
                MaSuaDP_DV = dgvDichVu.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbDV.SelectedValue = dgvDichVu.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSoLuongDV.Text = dgvDichVu.Rows[e.RowIndex].Cells[6].Value.ToString();

                gbThemSuaDV.Text = "Sửa dịch vụ";
                btnSuaDV.Show();
                btnThemDV.Hide();
                btnHienThiThemDV.Show();
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1) // bấm nút xóa trên dgv
            {
                if (DungChung.confirm())
                {
                    String sql = String.Format("delete from DatPhong_DichVu where Id = {0}", dgvDichVu.Rows[e.RowIndex].Cells[2].Value.ToString());
                    DungChung.ThemSuaXoaQuery(sql);
                    MessageBox.Show("Xóa thành công!", "Thông Báo");
                    btnHienThiThemDV_Click(sender, e);
                    dgvDichVu.DataSource = DungChung.XemQuery(String.Format(@"SELECT DatPhong_DichVu.ID, DichVu.ID, DichVu.TenDichVu, DichVu.DonGia, DatPhong_DichVu.SoLuong, DatPhong_DichVu.TongTien
                                            FROM DichVu INNER JOIN DatPhong_DichVu ON DichVu.ID = DatPhong_DichVu.idDichVu
                                            WHERE (((DatPhong_DichVu.idDatPhong)={0}));", MaSuaDP));
                }
            }
        }

        private void cbLP_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DungChung.XemQuery(String.Format("select * from LoaiPhong where id = {0}", cbLP.SelectedValue.ToString()));
            txtSoGiuong.Text = dt.Rows[0]["SoGiuong"].ToString();
            txtGiaPhong.Text = dt.Rows[0]["DonGia"].ToString();
        }

        private void cbDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DungChung.XemQuery(String.Format("select * from DichVu where id = {0}", cbDV.SelectedValue.ToString()));
            txtDonGiaDV.Text = dt.Rows[0]["DonGia"].ToString();
            txtMoTaDV.Text = dt.Rows[0]["MoTa"].ToString();
        }

        private void btnXoaP_Click(object sender, EventArgs e)
        {
            if (DungChung.confirm())
            {
                String sql = String.Format("delete from Phong where ID = {0}", MaSuaP);
                DungChung.ThemSuaXoaQuery(sql);
                MessageBox.Show("Xóa thành công!", "Thông Báo");
                DSPhong_Load(sender, e);
            }
        }
    }
}
