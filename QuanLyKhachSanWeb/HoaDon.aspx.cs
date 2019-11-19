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
    public partial class HoaDon : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(Control control) { }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["sql"]))
            {
                String sql = Request.QueryString["sql"].ToString();
                DataTable tbl = DungChung.XemQuery(sql);
                GridViewHoaDon.DataSource = tbl;
                GridViewHoaDon.DataBind();
                //xuat docx
                Response.ClearContent();
                Response.AppendHeader("content-disposition", "attachment; filename=Khach_Hang.doc");
                Response.ContentType = "application/word";
                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
                GridViewHoaDon.RenderControl(htw);
                Response.Write(stringWriter.ToString());
                Response.End();
            }
        }
    }
}