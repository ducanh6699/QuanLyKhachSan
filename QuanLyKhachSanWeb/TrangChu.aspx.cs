using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace QuanLyKhachSanWeb
{
    public partial class TrangChu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["ten"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }
            String sql = "Select * from KhachHang";
            DataTable table = DungChung.XemQuery(sql);
            GridViewKhachHang.DataSource = table;
            GridViewKhachHang.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control) { }
        protected void ButtonXuat_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Khach_Hang.doc");
            Response.ContentType = "application/word";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            GridViewKhachHang.HeaderRow.Style.Add("background-color", "#000000");
            GridViewKhachHang.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
    }
}