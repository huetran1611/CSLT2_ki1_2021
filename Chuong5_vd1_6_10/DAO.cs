using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using System.Windows.Forms;
namespace WindowsFormsApp5
{
    class DAO
    {
        static private SqlConnection con;
        static private string connectionstring = "Data Source=DESKTOP-4G918BK\\SQLEXPRESS;Initial Catalog=QuanLyBanHanh;Integrated Security=True";

        static public void OpenConnection()
        {
            con = new SqlConnection();
            con.ConnectionString = connectionstring;
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
         static public void CloseConnection()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        static public SqlConnection Con
        {
            get
            {
                return con;
            }
        }

        static public void fillCombo(string sql, ComboBox cmb, string value, string display)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, DAO.Con);
            DataTable tbl = new DataTable();
            adapter.Fill(tbl);
            cmb.DataSource = tbl;
            cmb.ValueMember = value;
            cmb.DisplayMember = display;

        }
    }
}
