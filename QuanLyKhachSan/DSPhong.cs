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
                int TrangThai = 1;
                for (int j = 0; j < dtDatPhong.Rows.Count; j++)
                {
                    // creating object of NgayDen
                    DateTime NgayDen = DateTime.Parse(dtDatPhong.Rows[j]["NgayDen"].ToString());
  
                    // creating object of NgayDi 
                    DateTime NgayDi = DateTime.Parse(dtDatPhong.Rows[j]["NgayDi"].ToString());
                     
                    DateTime HomNay = DateTime.Parse(DateTime.Today.ToString());

                    int valueNgayDen = DateTime.Compare(NgayDen, HomNay);
                    int valueNgayDi = DateTime.Compare(NgayDi, HomNay);

                    if (valueNgayDi < 0) TrangThai = 1; // phong trong
                    else if (valueNgayDen > 0) TrangThai = 0; // phong duoc dat nhung khach chua den
                    else if ((valueNgayDen <= 0) && (valueNgayDi >= 0)) TrangThai = -1; // phong dang co khach o
                }
                if (TrangThai == 1) btn.BackColor = Color.Green;
                else if (TrangThai == 0) btn.BackColor = Color.Yellow;
                else btn.BackColor = Color.Red;
                flpPhong.Controls.Add(btn);
            }
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {

        }
    }
}
