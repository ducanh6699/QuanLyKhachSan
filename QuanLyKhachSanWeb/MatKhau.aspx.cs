using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QuanLyKhachSanWeb
{
    public partial class MatKhau : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["ten"] == null)
            {
                Response.Redirect("DangNhap.aspx");
            }
        }

        protected void ButtonDoi_Click(object sender, EventArgs e)
        {
            String sql = string.Format("Select * from NguoiDung where TaiKhoan ='{0}'", Session["ten"]);
            DataTable table = DungChung.XemQuery(sql);
            string sqlmatkhau;
            String matkhaucu = table.Rows[0]["matkhau"].ToString();
            if (TextBoxCu.Text != null && TextBoxMoi.Text != null && TextBoxNhapLai.Text != null)
            {
                if (TextBoxCu.Text == matkhaucu)
                {
                    if (TextBoxMoi.Text == TextBoxNhapLai.Text)
                    {
                        sqlmatkhau = String.Format("Update NguoiDung Set MatKhau = '{0}' where TaiKhoan = '{1}'", TextBoxMoi.Text,Session["ten"].ToString());
                        DungChung.ThemSuaXoaQuery(sqlmatkhau);
                        LabelBaoLoi.Visible = false;
                        Response.Write("<script>alert('Đổi thành công')</script>");
                    }
                    else LabelBaoLoi.Text = "Mật khẩu mới và nhập lại mật khẩu không khớp";
                }
                else LabelBaoLoi.Text = "Mật khẩu cũ không đúng";
            }
        }
    }
}