using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QuanLyKhachSanWeb
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonDangNhap_Click(object sender, EventArgs e)
        {
            String sql = String.Format("Select * from NguoiDung where TaiKhoan = '{0}' and MatKhau = '{1}'",TXTTenDangNhap.Text, TXTPassword.Text);
            DataTable tbl = DungChung.XemQuery(sql);
            if (tbl.Rows.Count > 0)
            {
                Session["Ten"] = TXTTenDangNhap.Text;
                Response.Redirect("TrangChu.aspx");
            }
            else { LabelStatus.Text = "Sai tài khoản hoặc mật khẩu!"; }
        }
    }
}