using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevComponents.DotNetBar;

namespace QL_HS
{
    public partial class AddHS10 : Form
    {
        public AddHS10()
        {
            InitializeComponent();
        }

        string link = @"Data Source=ANHQUOC-PC\ANHQUOC;User ID=anhquoc;Password=123;Initial Catalog=QL_HOCSINH";
        private void LoadCBThem()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load1 = "SELECT * from HOCSINH H where H.MAHS not in (select H.MAHS from HOCSINH H, CTLOP C where H.MAHS = c.MAHS)";
            string load2 = "SELECT * from LOP WHERE MALOP LIKE '10%'";
            SqlCommand commandSql2 = new SqlCommand(load2, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com2 = new SqlDataAdapter(commandSql2); //Vận chuyển dữ liệu
            DataTable table2 = new DataTable();
            com2.Fill(table2);
            cbLop10.DataSource = table2;
            cbLop10.ValueMember = "MALOP";
            SqlCommand commandSql1 = new SqlCommand(load1, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com1 = new SqlDataAdapter(commandSql1); //Vận chuyển dữ liệu
            DataTable table1 = new DataTable();
            com1.Fill(table1);
            cbMS10.DataSource = table1;
            cbMS10.ValueMember = "MAHS";
            URL.Close();
        }

        private void LoadCBSua()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load1 = "SELECT * from HOCSINH H";
            string load2 = "SELECT * from LOP WHERE MALOP LIKE '10%'";
            SqlCommand commandSql2 = new SqlCommand(load2, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com2 = new SqlDataAdapter(commandSql2); //Vận chuyển dữ liệu
            DataTable table2 = new DataTable();
            com2.Fill(table2);
            cbLop10.DataSource = table2;
            cbLop10.ValueMember = "MALOP";
            SqlCommand commandSql1 = new SqlCommand(load1, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com1 = new SqlDataAdapter(commandSql1); //Vận chuyển dữ liệu
            DataTable table1 = new DataTable();
            com1.Fill(table1);
            cbMS10.DataSource = table1;
            cbMS10.ValueMember = "MAHS";
            URL.Close();
        }

        private void loadTen()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "select * from HOCSINH where MAHS like '%" + cbMS10.SelectedValue.ToString() + "%'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataReader com = commandSql.ExecuteReader();
            if (com.Read())
                txtTen10.Text = com["HoTen"].ToString();
            URL.Close();
        }

        private void cbMS10_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTen();
        }

        private void loadData()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "select [Mã học sinh]=H.MAHS, [Tên]=h.HoTen, [Lớp]=L.MALOP from LOP L, CTLOP C, HOCSINH H where l.MALOP = c.MALOP and c.MAHS = h.MAHS and l.MALOP like '10%'";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                dataThem10.DataSource = table;
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

        private void btnThem10_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string them = "INSERT INTO CTLOP VALUES('" + cbMS10.SelectedValue.ToString() + "','" + cbLop10.SelectedValue.ToString() + "')";
                SqlCommand command = new SqlCommand(them, URL);
                command.ExecuteNonQuery();
                loadData();
                LoadCBThem();
                loadTen();
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

        private void btnSua10_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sua = "UPDATE CTLOP SET MALOP='" + cbLop10.SelectedValue.ToString() + "' WHERE MAHS='" + cbMS10.SelectedValue.ToString() + "'";
                SqlCommand command = new SqlCommand(sua, URL);
                command.ExecuteNonQuery();
                loadData();
                LoadCBThem();
                loadTen();
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

        private void btnXoa10_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string xoa = "DELETE FROM CTLOP WHERE MAHS = '" + cbMS10.SelectedValue.ToString() + "'";
                SqlCommand command = new SqlCommand(xoa, URL);
                command.ExecuteNonQuery();
                loadData();
                LoadCBThem();
                loadTen();
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
        private void AddHS10_Load(object sender, EventArgs e)
        {
            loadData();
            LoadCBThem();
            loadTen();
        }

        private void dataThem10_Click(object sender, EventArgs e)
        {
            LoadCBSua();
            loadTen();
            int index = dataThem10.CurrentRow.Index;
            cbMS10.SelectedValue = dataThem10.Rows[index].Cells[0].Value.ToString();
            cbLop10.SelectedValue = dataThem10.Rows[index].Cells[2].Value.ToString();
        }
    }
}
