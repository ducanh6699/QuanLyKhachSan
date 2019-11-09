using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    class DungChung
    {
        public static int MaNguoiDung;
        public static String ChucNangCuaNguoiDung;
        protected static String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\QLKS.mdb";

        public static void ThemSuaXoaQuery(String sql)
        {
            OleDbConnection con = new OleDbConnection(strcon);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable XemQuery(String sql)
        {
            OleDbConnection con = new OleDbConnection(strcon);
            con.Open();
            OleDbDataAdapter ada = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ada.Fill(tb);
            con.Close();
            return tb;
        }

        public static bool confirm()
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public static void Thoat()
        {
            if (confirm())
            {
                Application.Exit();
            }
        }
    }
}
