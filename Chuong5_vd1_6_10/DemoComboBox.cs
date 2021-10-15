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
    public partial class DemoComboBox : Form
    {
        public DemoComboBox()
        {
            InitializeComponent();
        }

        private void DemoComboBox_Load(object sender, EventArgs e)
        {
            string sql = "select macl, tencl from chatlieu";
            //SqlDataAdapter chatlieu = new SqlDataAdapter(sql, DAO.Con);
            //DataTable tblChatLieu = new DataTable();
            //chatlieu.Fill(tblChatLieu);
            //cmbChatLieu.DataSource = tblChatLieu;
            //cmbChatLieu.ValueMember = "macl";
            //cmbChatLieu.DisplayMember = "tencl";

            DAO.fillCombo(sql, cmbChatLieu, "macl", "tencl");
            cmbChatLieu.SelectedIndex = -1;

        }

        private void cmbChatLieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("giá trị được bạn chọn là \n: giá trị " + cmbChatLieu.SelectedValue);
        }
    }
}
