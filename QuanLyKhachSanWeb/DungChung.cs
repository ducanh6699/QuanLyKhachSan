using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;

namespace QuanLyKhachSanWeb
{
    public class DungChung
    {
        protected static String strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\QLKS.mdb";
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

        public static void ThemSuaXoaQuery(String sql)
        {
            OleDbConnection con = new OleDbConnection(strcon);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}