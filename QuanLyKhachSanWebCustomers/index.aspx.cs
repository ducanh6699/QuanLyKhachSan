using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyKhachSanWebCustomers
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNgayNhan.Attributes.Add("readonly", "readonly");
            txtNgayTra.Attributes.Add("readonly", "readonly");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }
    }
}