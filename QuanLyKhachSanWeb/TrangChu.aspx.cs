using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Configuration;

namespace QuanLyKhachSanWeb
{
    public partial class TrangChu : System.Web.UI.Page
    {
        DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["ten"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }
            String sql = "Select * from KhachHang";
            table = DungChung.XemQuery(sql);
            GridViewKhachHang.DataSource = table;
            GridViewKhachHang.DataBind();
            String doublequote = "\"'',''\"";
            String sqlincome = @"SELECT Sum(HoaDon.TongSoTien) AS SumOfTongSoTien, Format([NgayDi],'mm"+doublequote+@"yyyy') AS thoigian
                                FROM DatPhong INNER JOIN HoaDon ON DatPhong.ID = HoaDon.IDDatPhong
                                GROUP BY Format([NgayDi],'mm"+doublequote+@"yyyy');";
            DataTable tableincome = DungChung.XemQuery(sqlincome);
            Chart1.DataSource = tableincome;
            Chart1.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control) { }
        protected void ButtonXuat_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Khach_Hang.doc");
            Response.ContentType = "application/word";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            GridViewKhachHang.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        protected void GridViewKhachHang_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewKhachHang.PageIndex = e.NewPageIndex;
            GridViewKhachHang.DataSource = table;
            GridViewKhachHang.DataBind();
        }

    }
}