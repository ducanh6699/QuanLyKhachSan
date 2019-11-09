using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QuanLyKhachSanWeb
{
    public partial class HoSo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (System.Web.HttpContext.Current.Session["ten"] == null)
                {
                    Response.Redirect("DangNhap.aspx");
                }
                String sql = String.Format("Select * from NguoiDung where TaiKhoan ='{0}'", Session["ten"].ToString());
                DataTable tbl = DungChung.XemQuery(sql);
                TextBoxTen.Text = tbl.Rows[0]["TenNguoiDung"].ToString();
                TextBoxEmail.Text = tbl.Rows[0]["Email"].ToString();
                TextBoxDiaChi.Text = tbl.Rows[0]["DiaChi"].ToString();
            }
        }

        protected void ButtonDoi_Click(object sender, EventArgs e)
        {
            String sql = String.Format("Update NguoiDung set TenNguoiDung = '{0}', Email = '{1}', DiaChi = '{2}' Where TaiKhoan = '{3}'", TextBoxTen.Text, TextBoxEmail.Text, TextBoxDiaChi.Text, Session["ten"].ToString());
            DungChung.ThemSuaXoaQuery(sql);
        }
    }
}