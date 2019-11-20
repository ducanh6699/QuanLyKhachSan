using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QuanLyKhachSanWebCustomers
{
    public partial class ThongTin : System.Web.UI.Page
    {
        bool newguess = true;
        String id;

        public static int totalday(DateTime dt1, DateTime dt2)
        {
            int days = (dt2 - dt1).Days;
            if (days == 0) return 1;
            else return days;
        }
        public static String lastid(String sql)
        {
            DataTable tb1 = DungChung.XemQuery(sql);
            return tb1.Rows[0]["id"].ToString();
        }

        public void baoloi()
        {
            msgLoi.Visible = true;
            thongtin.Visible = false;
            Label2.Text = "Không có thông tin hoặc thông tin lỗi! Vui lòng quay lại trang đặt phòng!";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                if (String.IsNullOrEmpty(Request.QueryString["NgayNhan"]) || String.IsNullOrEmpty(Request.QueryString["NgayTra"]) || String.IsNullOrEmpty(Request.QueryString["SDT"]) || String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    baoloi();
                }
                else
                {
                    String Sql = String.Format(@"SELECT Phong.ID
                                                 FROM Phong
                                                 Where Phong.ID = {2} AND Phong.ID NOT IN (Select IDPhong from DatPhong Where (NgayDen <= #{0}#  AND NgayDi >=  #{0}#) AND (NgayDen <= #{1}#  AND NgayDi >=  #{1}#))", Request.QueryString["NgayNhan"].ToString(), Request.QueryString["NgayTra"].ToString(), Request.QueryString["id"].ToString());
                    if (DungChung.XemQuery(Sql).Rows.Count == 0)
                    {
                        baoloi();

                    }
                    else
                    {
                        DateTime NgayNhan = DateTime.Parse(Request.QueryString["NgayNhan"].ToString());
                        DateTime NgayTra = DateTime.Parse(Request.QueryString["NgayTra"].ToString());
                        int totaldate = totalday(NgayNhan, NgayTra);
                        Sql = String.Format(@"SELECT Phong.SoPhong, LoaiPhong.DonGia * {0} as Gia, LoaiPhong.ID
                                                FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.ID = Phong.IDLoaiPhong
                                                WHERE(((Phong.ID) = {1}));", totaldate.ToString(), Request.QueryString["id"]);
                        DataTable tb1 = DungChung.XemQuery(Sql);
                        lbChiPhi.Text = tb1.Rows[0]["Gia"].ToString();
                        lbSoNgay.Text = totaldate.ToString();
                        lbSoPhong.Text = tb1.Rows[0]["SoPhong"].ToString();


                        Sql = String.Format("Select * From KhachHang where SDT = '{0}'", Request.QueryString["SDT"].ToString());
                        DataTable tb = DungChung.XemQuery(Sql);



                        if (tb.Rows.Count != 0)
                        {
                            id = tb.Rows[0]["ID"].ToString();
                            txtTen.Text = tb.Rows[0]["Ten"].ToString();
                            txtNgaySinh.Text = tb.Rows[0]["NgaySinh"].ToString();
                            txtDiaChi.Text = tb.Rows[0]["DiaChi"].ToString();
                            DropDownList1.SelectedItem.Text = tb.Rows[0]["GioiTinh"].ToString();
                            txtSDT.Text = tb.Rows[0]["SDT"].ToString();
                            txtTen.ReadOnly = true;
                            txtNgaySinh.ReadOnly = true;
                            txtDiaChi.ReadOnly = true;
                            DropDownList1.Enabled = false;
                            DropDownList1.CssClass = "form-control";
                            txtSDT.ReadOnly = true;
                            newguess = false;
                        }
                        else txtSDT.Text = Request.QueryString["SDT"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                baoloi();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            String sql;
            if (newguess)
            {
                sql = String.Format("Insert into KhachHang (Ten,NgaySinh,GioiTinh,DiaChi,SDT) values('{0}','{1}','{2}','{3}','{4}')", txtTen.Text, txtNgaySinh.Text,DropDownList1.SelectedItem.Text,txtDiaChi.Text ,txtSDT.Text);
                DungChung.ThemSuaXoaQuery(sql);
                sql = String.Format("select ID from KhachHang where SDT = '{0}'", txtSDT.Text);
                id = lastid(sql);
            }
            sql = String.Format("INSERT into DatPhong (IDKhachHang,IDPhong,NgayDen,NgayDI) values({0},{1},'{2}','{3}')", id, Request.QueryString["id"], Request.QueryString["NgayNhan"], Request.QueryString["NgayTra"]);
            DungChung.ThemSuaXoaQuery(sql);
            String lastidDatPhong = lastid("Select TOP 1 ID FROM DatPhong ORDER BY id DESC");
            sql = String.Format("INSERT into HoaDon (IDDatPhong,TongSoTien, DaThanhToan) values({0},{1},false)", lastidDatPhong, lbChiPhi.Text);
            DungChung.ThemSuaXoaQuery(sql);
            Response.Redirect("index.aspx");
        }
    }
}