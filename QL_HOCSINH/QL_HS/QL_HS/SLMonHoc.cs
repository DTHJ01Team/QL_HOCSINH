using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;

namespace QL_HS
{
    public partial class SLMonHoc : Form
    {
        public SLMonHoc()
        {
            InitializeComponent();
        }
        string link = @"Data Source=ANHQUOC-PC\ANHQUOC;User ID=anhquoc;Password=123;Initial Catalog=QL_HOCSINH";

        private void loadSLMon()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "select * from QUYDINH where MAQD like'SLMH'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataReader com = commandSql.ExecuteReader();
            if (com.Read())
                txtSLMon.Text = com["GiaTriQD"].ToString();
            URL.Close();
        }

        private void SLMonHoc_Load(object sender, EventArgs e)
        {
            loadSLMon();
        }

        private void Save()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sua = "UPDATE QUYDINH SET GiaTriQD='" + txtSLMon.Text + "' WHERE MAQD like 'SLMH'";
                SqlCommand command = new SqlCommand(sua, URL);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Sửa không thành công!!!");
            }
            finally
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Close();
            }
        }



        private void btnSLMSave_Click(object sender, EventArgs e)
        {
            if (txtSLMon.Text.Length != 0)
                Save();
            else
                MessageBox.Show("Vui lòng nhập số lượng!!!");
        }

        private void txtSLMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}
