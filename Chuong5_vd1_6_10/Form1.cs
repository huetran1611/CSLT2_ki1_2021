using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKetNoi_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-4G918BK\\SQLEXPRESS;Initial Catalog=QuanLyBanHanh;Integrated Security=True";

            if(con.State == ConnectionState.Closed)
            {
                con.Open();
                MessageBox.Show("chúc mừng bạn mở kết nối thành công");
            }
        }
    }
}
