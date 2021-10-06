using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class FrmInsertData : Form
    {
        SqlConnection con = new SqlConnection();

        public FrmInsertData()
        {
            InitializeComponent();
        }

        private void FrmInsertData_Load(object sender, EventArgs e)
        {
            con.ConnectionString = "Data Source=DESKTOP-4G918BK\\SQLEXPRESS;Initial Catalog=QuanLyBanHanh;Integrated Security=True";

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
                MessageBox.Show("chúc mừng bạn mở kết nối thành công");
            }
        }

        private void btnInsertData_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            Random r = new Random();
            for (int i = 0; i <= 1000; i++)
            {
                string masp = i.ToString();
                string tensp = "Loại bánh " + i.ToString();
                string soluong = r.Next(1, 10000).ToString();
                // cmd.CommandText = "insert into SanPham values ('002', N'Bánh hạnh nhân', 1000, 50, null)";
                cmd.CommandText = "insert into SanPham values ('" + masp + "', N'" + tensp + "'," + soluong + ", 50, null)";
                try
                {
                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("chèn thành công dữ liệu vào cơ sở dữ liệu");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            MessageBox.Show("chèn thành công dữ liệu vào cơ sở dữ liệu");

        }
    }
}
