using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QuanLyKhachSanWebCustomers
{
    public partial class ChonPhong : System.Web.UI.Page
    {
        public void fillgrid()
        {

            String sql = String.Format(@"SELECT Phong.ID, Phong.SoPhong, LoaiPhong.TenLoaiPhong, LoaiPhong.SoGiuong, LoaiPhong.DonGia
                                         FROM LoaiPhong INNER JOIN Phong ON LoaiPhong.ID = Phong.IDLoaiPhong
                                         WHERE (((Phong.ID) Not In (Select DatPhong.IDPhong From DatPhong Where (DatPhong.NgayDen <= #{0}# AND DatPhong.NgayDi >= #{0}#)
                                         OR (DatPhong.NgayDen <= #{1}# AND DatPhong.NgayDi >= #{1}#) )) 
                                         AND ((LoaiPhong.SoGiuong)={2}));", Request.QueryString["NgayNhan"].ToString(), Request.QueryString["NgayTra"].ToString(), Request.QueryString["SoNguoi"].ToString());
            DataTable tbl = DungChung.XemQuery(sql);
            dgvPhong.DataSource = tbl;
            dgvPhong.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request.QueryString["NgayNhan"]) || String.IsNullOrEmpty(Request.QueryString["NgayTra"]) || String.IsNullOrEmpty(Request.QueryString["SDT"]) || String.IsNullOrEmpty(Request.QueryString["SoNguoi"]))
            {
                msgLoi.Visible = true;
                gridview.Visible = false;
                Label2.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            else
            {
                fillgrid();
                if (dgvPhong.Rows.Count == 0)
                {
                    msgLoi.Visible = true;
                    gridview.Visible = false;
                    Label2.Text = "Hiện không có phòng trống phù hợp";
                }
            }
        }

        protected void dgvPhong_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPhong.PageIndex = e.NewPageIndex;
            fillgrid();
        }

        protected void dgvPhong_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int _rowIndex = Convert.ToInt32(e.CommandArgument);
            String id = dgvPhong.Rows[_rowIndex].Cells[1].Text;
        }
    }
}