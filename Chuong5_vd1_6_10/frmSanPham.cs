using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class frmSanPham : Form
    {
        
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            try
            {
                DAO.OpenConnection();
                string sql = "select masp, tensp, gia, soluong, anh from SanPham";

                //SqlDataAdapter mydata = new SqlDataAdapter();
                //SqlCommand cmd = new SqlCommand(sql, DAO.Con);
                //mydata.SelectCommand = cmd;
                SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.Con);

                DataTable tblSanPham = new DataTable();
                // Do du lieu vao datatable tblSanPham
                mydata.Fill(tblSanPham);
                // gan du lieu hien thi cho dataGriviewSanPham
                dataGriviewSanPham.DataSource = tblSanPham;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "xuat hien loi");
            }



        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGia.Text = "";
            txtSoLuong.Text = "";
            txtLinkAnh.Text = "";
            btnCapNhat.Enabled = false;
            btnXoa.Enabled = false;
            btnTimKiem.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //kiem tra du lieu
            // neu du trong cac textbox bat buoc nhap tt trong --> yêu cầu bổ xung
            if (txtMaSP.Text.Trim() == "")
            {
                MessageBox.Show("không được bỏ trống mã sản phẩm");
                txtMaSP.Focus();
            }
            // làm tương tự với các textbox còn lại

            // insert into sanpham values ('masp', N'tensp', gia, soluong, N'anh')
            // insert into sanpham values ('masp', N'tensp', gia, soluong, null)
            string sql = "insert into sanpham values ('" + txtMaSP.Text.Trim() + "', N'" +
                        txtTenSP.Text.Trim() + "', " +
                        txtGia.Text.Trim() + "," +
                        txtSoLuong.Text.Trim() + ",";
            if(txtLinkAnh.Text.Trim() == "")
            {
                sql = sql + "null )";
            }
            else
            {
                sql = sql + "N'" + txtLinkAnh.Text.Trim() + "')";
            }
            try
            {
                SqlCommand cmd = new SqlCommand(sql, DAO.Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dữ liệu được thêm mới thành công");
                // hiển thị dòng dữ liệu vừa mới được thêm lên trên datagridview 
                //...
                // cho phép người dùng truy cập lại các nút
                btnCapNhat.Enabled = true;
                btnXoa.Enabled = true;
                btnTimKiem.Enabled = true;
            }
            catch (Exception ex) {
                MessageBox.Show("Không thể chèn được dữ liệu vào do lỗi " + ex.ToString());
            }
        }

        private void dataGriviewSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // hiển thị dữ liệu tại dòng tương ứng lên các textbox
            txtMaSP.Text = dataGriviewSanPham.CurrentRow.Cells[0].Value.ToString();
            txtTenSP.Text = dataGriviewSanPham.CurrentRow.Cells[1].Value.ToString();
            txtGia.Text = dataGriviewSanPham.CurrentRow.Cells[2].Value.ToString();
            txtSoLuong.Text = dataGriviewSanPham.CurrentRow.Cells[3].Value.ToString();
            txtLinkAnh.Text = dataGriviewSanPham.CurrentRow.Cells[4].Value.ToString();
            txtMaSP.Enabled = false;

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Tạo 1 câu truy vấn để cập nhật thông tin sản phẩm có mã = mã đã xác nhận

            // update tenbang set colume 1= value , colume2 = value2 where ...

            string sql = "update SanPham set tensp = N'" + txtTenSP.Text.Trim() + "'," +
                         "gia = " + txtGia.Text.Trim() + ", " +
                         "soluong = " + txtSoLuong.Text.Trim();
            if(txtLinkAnh.Text.Trim() == "")
            {
                sql = sql + ", anh = null ";
            }
            else
            {
                sql = sql + ", anh = N'" + txtLinkAnh.Text + "' ";
            }
            sql = sql + "where masp = '" +txtMaSP.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, DAO.Con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Dữ liệu đã được sửa thành cồng");
                // viết đoạn lệnh thể hiện bản ghi vừa được sửa trên data gridview?
            }
            catch(Exception ex)
            {
                MessageBox.Show("Dữ liệu không được cập nhật vì " + ex.ToString());
            }


        }
    }
}
