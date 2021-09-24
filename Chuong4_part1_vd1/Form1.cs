using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Chuong4_part1_vd1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTinhTong_Click(object sender, EventArgs e)
        {
            // ai xong rồi thì viết thêm phần check dữ liệu ở các text box
            // : ko đc trống, ko được nhập ký tự
            if (check_dlIsOK())
            {
                float a = Convert.ToSingle(txta.Text);
                float b = Convert.ToSingle(txtb.Text);
                float tong = a + b;
                lableTong.Text = "Tổng của 2 số a và b là: " + tong.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("chào mừng bạn đến với ct winform đầu tiên");
        }

        private bool check_dlIsOK()
        {
            bool kq = false;
            float gt;
            
            if (txta.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu cho số a");
                txta.Focus();
                return kq;
            }
            
            if (!Single.TryParse(txta.Text.Trim(),out gt))
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lê");
                txta.Text = "";
                txta.Focus();
                return kq;
            }

            if (txtb.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập dữ liệu cho số a");
                txtb.Focus();
                return kq;
            }
            
            if (!Single.TryParse(txtb.Text.Trim(), out gt))
            {
                MessageBox.Show("Dữ liệu nhập vào không hợp lê");
                txtb.Text = "";
                txtb.Focus();
                return kq;
            }
            // tương tự check cho b
            kq = true;
            return kq;           

        }
    }
}
