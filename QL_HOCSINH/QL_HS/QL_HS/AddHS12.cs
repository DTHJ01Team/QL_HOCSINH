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
    public partial class AddHS12 : Form
    {
        public AddHS12()
        {
            InitializeComponent();
        }
        string link = @"Data Source=DESKTOP-LVM1F93;User ID=sa;Password=123456;Initial Catalog=QL_HOCSINH";

        private void LoadCB()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load1 = "SELECT * from HOCSINH";
            string load2 = "SELECT * from LOP WHERE MALOP LIKE '12%'";
            SqlCommand commandSql2 = new SqlCommand(load2, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com2 = new SqlDataAdapter(commandSql2); //Vận chuyển dữ liệu
            DataTable table2 = new DataTable();
            com2.Fill(table2);
            cbLop12.DataSource = table2;
            cbLop12.ValueMember = "MALOP";
            SqlCommand commandSql1 = new SqlCommand(load1, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com1 = new SqlDataAdapter(commandSql1); //Vận chuyển dữ liệu
            DataTable table1 = new DataTable();
            com1.Fill(table1);
            cbMS12.DataSource = table1;
            cbMS12.ValueMember = "MAHS";
            URL.Close();
        }

        private void loadTen()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "select * from HOCSINH where MAHS like '%" + cbMS12.SelectedValue.ToString() + "%'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataReader com = commandSql.ExecuteReader();
            if (com.Read())
                txtTen12.Text = com["HoTen"].ToString();
            URL.Close();
        }

        private void cbMS12_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTen();
        }

        private void loadData()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "select H.MAHS, h.HoTen, L.MALOP from LOP L, CTLOP C, HOCSINH H where l.MALOP = c.MALOP and c.MAHS = h.MAHS and l.MALOP like '12%'";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                dataThem12.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Kết nối không thành công! Vui lòng kết nối lại!");
            }
            finally
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Close();
            }
        }

        private void btnThem12_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string them = "INSERT INTO CTLOP VALUES('" + cbMS12.SelectedValue.ToString() + "','" + cbLop12.SelectedValue.ToString() + "')";
                SqlCommand command = new SqlCommand(them, URL);
                command.ExecuteNonQuery();
                loadData();
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!!!");
            }
            finally
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Close();
            }
        }

        private void btnSua12_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sua = "UPDATE CTLOP SET MALOP='" + cbLop12.SelectedValue.ToString() + "' WHERE MAHS='" + cbMS12.SelectedValue.ToString() + "'";
                SqlCommand command = new SqlCommand(sua, URL);
                command.ExecuteNonQuery();
                loadData();
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

        private void btnXoa12_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string xoa = "DELETE FROM CTLOP WHERE MAHS = '" + cbMS12.SelectedValue.ToString() + "'";
                SqlCommand command = new SqlCommand(xoa, URL);
                command.ExecuteNonQuery();
                loadData();
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!");
            }
            finally
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Close();
            }
        }



        //===========Main load============
        private void AddHS12_Load(object sender, EventArgs e)
        {
            loadData();
            LoadCB();
            loadTen();
        }

        private void dataThem12_Click(object sender, EventArgs e)
        {
            int index = dataThem12.CurrentRow.Index;
            cbMS12.SelectedValue = dataThem12.Rows[index].Cells[0].Value.ToString();
            cbLop12.SelectedValue = dataThem12.Rows[index].Cells[2].Value.ToString();
        }
    }
}
