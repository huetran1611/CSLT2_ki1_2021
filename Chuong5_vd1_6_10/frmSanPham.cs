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
        private DataTable tblSanPham = new DataTable();
        
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
            resetValue();
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
                loadDataToGridview();
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

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|Gif(*.gif) |*.gif|All files(*.*)|*.*";
            dlgOpen.InitialDirectory = "D:\\Baigiang";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chon hinh anh de hien thi";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                picAnh.Image = Image.FromFile(dlgOpen.FileName);
            else
                MessageBox.Show("You clicked Cancel", "Open Dialog", MessageBoxButtons.OK,
 MessageBoxIcon.Information);        
        }

        private void resetValue()
        {
            txtGia.Text = "";
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            // Tự viết với các textbox còn lại
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetValue();
            btnCapNhat.Enabled = true;
            btnXoa.Enabled = true;
            btnTimKiem.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void loadDataToGridview()
        {
            // lấy hết dữ liệu trên bảng sản phẩm đẩy lên data gridview
            string sql = "select * from SanPham order by masp asc ";
            SqlDataAdapter mydata = new SqlDataAdapter(sql, DAO.Con);
            mydata.Fill(tblSanPham);
            dataGriviewSanPham.DataSource = tblSanPham;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from SanPham where masp = '" + txtMaSP.Text + "'";
            // nếu data griview ko có dữ liệu
            if(dataGriviewSanPham.RowCount == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa");
                return ;
            }

            if(txtMaSP.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa");
                return;
            }

            if (MessageBox.Show ("bạn có muốn xóa không","thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, DAO.Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("xóa thành công");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Xóa dữ liệu không thành công vì " + ex.ToString() );
                }
            }

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DAO.CloseConnection();
            Application.Exit();
            
        }
    }
}
