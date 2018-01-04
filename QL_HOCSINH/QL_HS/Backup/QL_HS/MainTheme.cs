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
    public partial class MainTheme : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public MainTheme()
        {
            InitializeComponent();
        }
        //=========Thực hiện chức năng đóng bằng chuột phải======================
        private void close_this()
        {
            TabItem selectedTab = tabMain.SelectedTab;
            if (MessageBox.Show("Bạn có muốn tắt trang \"" + selectedTab.Text + "\"?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (tabMain.SelectedTabIndex != 0)
                    selectedTab.Visible = false;
        }

        private void tabControl1_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            close_this();
        }

        private void đóngTrangNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close_this();
        }

        private void contextMenuTab_Opening(object sender, CancelEventArgs e)
        {
            if (tabMain.SelectedTabIndex == 0)
                đóngTrangNàyToolStripMenuItem.Enabled = false;
            else
                đóngTrangNàyToolStripMenuItem.Enabled = true;
        }

        //private void đóngCácTrangKhácToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    TabItem selectedTab = tabMain.SelectedTab;
        //    int index = tabMain.SelectedTabIndex;
        //    for (int i = tabMain.Tabs.Count - 1; i >= 0; i--)
        //        if (index != i)
                    
        //    tabMain.Refresh();
        //}

        //private void đóngTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    TabItem selectedTab = tabMain.SelectedTab;
        //    int index = tabMain.SelectedTabIndex;
        //    for (int i = tabMain.Tabs.Count - 1; i > 0; i--)
        //        selectedTab.Visible = false;
        //    tabMain.Refresh();
        //}
        //===========================================================================

        //================Thực hiện chức năng cho tab tiếp nhận sinh viên=============
        string link = @"Data Source=ANHQUOC-PC\ANHQUOC;User ID=anhquoc;Password=123;Initial Catalog=QL_HOCSINH";

        private void KNThemHS()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "select * from HOCSINH";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                dataGridViewX1.DataSource = table;
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

        private void dataGridViewX1_Click(object sender, EventArgs e)
        {
            int index = dataGridViewX1.CurrentRow.Index;
            txtMS.Text = dataGridViewX1.Rows[index].Cells[0].Value.ToString();
            txtTen.Text = dataGridViewX1.Rows[index].Cells[1].Value.ToString();
            txtdate.Text = dataGridViewX1.Rows[index].Cells[2].Value.ToString();
            if (dataGridViewX1.Rows[index].Cells[3].Value.ToString().Equals("Nam"))
                rbtnNam.Checked = true;
            else
                rbtnNu.Checked = true;
            txtEmail.Text = dataGridViewX1.Rows[index].Cells[4].Value.ToString();
            txtDiaChi.Text = dataGridViewX1.Rows[index].Cells[5].Value.ToString();
        }

        private void ThemHS()
        {
            try
            {
                string s = "";
                if (rbtnNam.Checked == true)
                    s = "Nam";
                else
                    s = "Nữ";
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string them = "set dateformat dmy INSERT INTO HOCSINH VALUES('" + txtMS.Text + "',N'" + txtTen.Text + "','" + txtdate.Text + "',N'" + s + "','" + txtEmail.Text + "',N'" + txtDiaChi.Text + "')";
                SqlCommand command = new SqlCommand(them, URL);
                command.ExecuteNonQuery();
                KNThemHS();
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

        private Boolean NgaySinh()
        {
            int min = int.Parse(txtTuoiMin.Text);
            int max = int.Parse(txtTuoiMax.Text);
            if ((DateTime.Now.Year - txtdate.Value.Year) > min && (DateTime.Now.Year - txtdate.Value.Year) < max)
                return true;
            else
                return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMS.Text.Length != 0 && txtTen.Text.Length != 0 && txtEmail.Text.Length != 0 && txtDiaChi.Text.Length != 0)
            {
                if (NgaySinh() == true)
                    ThemHS();
                else
                    MessageBox.Show("Vượt quá số tuổi cho phép học!!!");
            }
            else
                MessageBox.Show("Không thể thêm học sinh!!!\nXin nhập đầy đủ thông tin!");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                if (rbtnNam.Checked == true)
                    s = "Nam";
                else
                    s = "Nữ";
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sua = "set dateformat dmy UPDATE HOCSINH SET HoTen=N'"+txtTen.Text+"', NgaySinh='"+txtdate.Text+"', GioiTinh=N'"+s+"', Email='"+txtEmail.Text+"', DiaChi=N'"+txtDiaChi.Text+"' WHERE MAHS='"+txtMS.Text+"'";
                SqlCommand command = new SqlCommand(sua,URL);
                command.ExecuteNonQuery();
                KNThemHS();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string xoa = "DELETE FROM HOCSINH WHERE MAHS = '" + txtMS.Text + "'";
                SqlCommand command = new SqlCommand(xoa, URL);
                command.ExecuteNonQuery();
                KNThemHS();
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

        private void txtMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            txtMS.Text = "";
            txtTen.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            rbtnNam.Checked = true;
        }
        //====================================================================

        //===========Thực hiện chức năng mở các tab===========================
        private void btnThemHS_Click(object sender, EventArgs e)
        {
            tabThemHS.Visible = true;
            tabMain.SelectedTab = tabThemHS;
        }

        private void btnLapDS_Click(object sender, EventArgs e)
        {
            tabLapDS.Visible = true;
            tabMain.SelectedTab = tabLapDS;
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            tabTra.Visible = true;
            tabMain.SelectedTab = tabTra;
        }

        private void btnTroGiup_Click(object sender, EventArgs e)
        {
            tabTroGiup.Visible = true;
            tabMain.SelectedTab = tabTroGiup;
        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            tabNhapDiem.Visible = true;
            tabMain.SelectedTab = tabNhapDiem;
        }

        private void btnTinhDiem_Click(object sender, EventArgs e)
        {
            tabTinhTB.Visible = true;
            tabMain.SelectedTab = tabTinhTB;
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            tabBCTK.Visible = true;
            tabMain.SelectedTab = tabBCTK;
        }

        private void btnMon_Click(object sender, EventArgs e)
        {
            tabMon.Visible = true;
            tabMain.SelectedTab = tabMon;
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            tabDiem.Visible = true;
            tabMain.SelectedTab = tabDiem;
        }

        private void btnSS_Click(object sender, EventArgs e)
        {
            tabSS.Visible = true;
            tabMain.SelectedTab = tabSS;
        }

        private void btnTuoi_Click(object sender, EventArgs e)
        {
            tabTuoi.Visible = true;
            tabMain.SelectedTab = tabTuoi;
        }
        //====================================================================

        //===========Thực hiện chức năng liên kết from cho 3 tab trong tab lập DS lớp====
        private void btnAdd10_Click(object sender, EventArgs e)
        {
            if ((dataTab10.Rows.Count-1) < int.Parse(txtSS10.Text))
            {
                AddHS10 frm = new AddHS10();
                frm.Show();
            }
            else
                MessageBox.Show("Vượt quá sỉ số của lớp!!!\n Vui lòng xem quy định!!!");
        }

        private void btnAdd11_Click(object sender, EventArgs e)
        {
            if ((datatab11.Rows.Count - 1) < int.Parse(txtSS11.Text))
            {
                AddHS11 frm = new AddHS11();
                frm.Show();
            }
            else
                MessageBox.Show("Vượt quá sỉ số của lớp!!!\n Vui lòng xem quy định!!!");
        }

        private void btnAdd12_Click(object sender, EventArgs e)
        {
            if ((datatab12.Rows.Count - 1) < int.Parse(txtSS12.Text))
            {
                AddHS12 frm = new AddHS12();
                frm.Show();
            }
            else
                MessageBox.Show("Vượt quá sỉ số của lớp!!!\n Vui lòng xem quy định!!!");
        }

        //=========================================================================

        //============Thực hiện các chức năng trong tab Thêm học sinh khối 10======
        private void loadCB10()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "SELECT * from LOP WHERE MALOP LIKE '10%'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
            DataTable t = new DataTable();
            com.Fill(t);
            cb10.DataSource = t;
            cb10.ValueMember = "MALOP";
            URL.Close();
        }
        private void loadtxtSS10()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "select * from LOP where MALOP like '%" + cb10.SelectedValue.ToString() + "%'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataReader com = commandSql.ExecuteReader() ;
            if(com.Read())
                txtSS10.Text = com["SL"].ToString();
            URL.Close();
        }

        private void cb10_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadtxtSS10();
            loadDatatab10();
        }

        private void loadDatatab10()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "select h.HoTen, h.GioiTinh, h.NgaySinh,h.DiaChi from LOP L, CTLOP C, HOCSINH H where l.MALOP = c.MALOP and c.MAHS = h.MAHS and c.MALOP like '%" + cb10.SelectedValue.ToString() + "%'";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                dataTab10.DataSource = table;
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

        private void LoadTab10()
        {
            loadCB10();
            loadtxtSS10();
            loadDatatab10();
        }

        //========================================================================

        //============Thực hiện các chức năng trong tab Thêm học sinh khối 11======
        private void loadCB11()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "SELECT * from LOP WHERE MALOP LIKE '11%'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
            DataTable t = new DataTable();
            com.Fill(t);
            cb11.DataSource = t;
            cb11.ValueMember = "MALOP";
            URL.Close();
        }
        private void loadtxtSS11()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "select * from LOP where MALOP like '%" + cb11.SelectedValue.ToString() + "%'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataReader com = commandSql.ExecuteReader();
            if (com.Read())
                txtSS11.Text = com["SL"].ToString();
            URL.Close();
        }

        private void cb11_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadtxtSS11();
            loadDatatab11();
        }

        private void loadDatatab11()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "select h.HoTen, h.GioiTinh, h.NgaySinh,h.DiaChi from LOP L, CTLOP C, HOCSINH H where l.MALOP = c.MALOP and c.MAHS = h.MAHS and c.MALOP like '%" + cb11.SelectedValue.ToString() + "%'";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                datatab11.DataSource = table;
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

        private void LoadTab11()
        {
            loadCB11();
            loadtxtSS11();
            loadDatatab11();
        }
        //========================================================================

        //============Thực hiện các chức năng trong tab Thêm học sinh khối 12======
        private void loadCB12()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "SELECT * from LOP WHERE MALOP LIKE '12%'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
            DataTable t = new DataTable();
            com.Fill(t);
            cb12.DataSource = t;
            cb12.ValueMember = "MALOP";
            URL.Close();
        }
        private void loadtxtSS12()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "select * from LOP where MALOP like '%" + cb12.SelectedValue.ToString() + "%'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataReader com = commandSql.ExecuteReader();
            if (com.Read())
                txtSS12.Text = com["SL"].ToString();
            URL.Close();
        }

        private void cb12_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadtxtSS12();
            loadDatatab12();
        }

        private void loadDatatab12()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "select h.HoTen, h.GioiTinh, h.NgaySinh,h.DiaChi from LOP L, CTLOP C, HOCSINH H where l.MALOP = c.MALOP and c.MAHS = h.MAHS and c.MALOP like '%" + cb12.SelectedValue.ToString() + "%'";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                datatab12.DataSource = table;
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

        private void LoadTab12()
        {
            loadCB12();
            loadtxtSS12();
            loadDatatab12();
        }
        //========================================================================

        //========Thực hiện chức năng tab Tra cứu học sinh=======================
        private void loadDataTC()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "select H.HoTen, L.MALOP, [HK1] = (select DTBHK from DIEMHOCKY D, HOCSINH H where D.MAHS = H.MAHS and H.HoTen like N'%" + txtHTTC.Text + "%' and MAHK like 'HK1'), [HK2] = (select DTBHK from DIEMHOCKY D, HOCSINH H where D.MAHS = H.MAHS and H.HoTen like N'%" + txtHTTC.Text + "%' and MAHK like 'HK2')\n" +
                                    "from LOP L, DIEMHOCKY D, HOCSINH H\n" +
                                    "where L.MALOP = D.MALOP and D.MAHS = H.MAHS and H.HoTen like N'%" + txtHTTC.Text + "%'\n" +
                                    "group by H.HoTen, L.MALOP";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                dataTC.DataSource = table;
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

        private void loadDataTCFirst()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "select H.HoTen, L.MALOP, [HK1] = (select DTBHK from DIEMHOCKY D, HOCSINH H where D.MAHS = H.MAHS and MAHK like 'HK1'), [HK2] = (select DTBHK from DIEMHOCKY D, HOCSINH H where D.MAHS = H.MAHS and MAHK like 'HK2')\n"+
                                    "from LOP L, DIEMHOCKY D, HOCSINH H\n"+
                                    "where L.MALOP = D.MALOP and D.MAHS = H.MAHS\n"+
                                    "group by H.HoTen, L.MALOP";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                dataTC.DataSource = table;
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


        private void txtHTTC_TextChanged(object sender, EventArgs e)
        {
            loadDataTC();
        }

        private void loadTabTC()
        {
            loadDataTCFirst();
        }
        //====================================================================

        //===========Thực hiện chức năng tab Thay đổi môn học=================
        private void loadDataMon()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "SELECT * FROM MONHOC";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                dataMon.DataSource = table;
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

        private void ThemMon()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string them = "INSERT INTO MONHOC VALUES('" + txtMonMS.Text + "',N'" + txtMonTen.Text + "')";
                SqlCommand command = new SqlCommand(them, URL);
                command.ExecuteNonQuery();
                loadDataMon();
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

        private void btnMonAdd_Click(object sender, EventArgs e)
        {
            int GH = int.Parse(txtSLMon.Text);
            int SD = (dataMon.Rows.Count -1);
            if (SD < GH)
            {
                ThemMon();
            }
            else
            {
                MessageBox.Show("Vượt quá số lượng môn!\n Vui lòng xem quy định!");
            }
            if (txtMonMS.Text.Length > 0 && txtMonTen.Text.Length > 0)
            {
                ThemMon();
            }
            else
            {
                MessageBox.Show("Thiếu thông tin!!!\n Không thể thêm!!!");
            }
        }

        private void btnMonSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sua = "UPDATE MONHOC SET Ten='" + txtMonTen.Text + "' WHERE MAMH='" + txtMonMS.Text + "'";
                SqlCommand command = new SqlCommand(sua, URL);
                command.ExecuteNonQuery();
                loadDataMon();
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

        private void btnMonDel_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string xoa = "DELETE FROM MONHOC WHERE MAMH = '" + txtMonMS.Text + "'";
                SqlCommand command = new SqlCommand(xoa, URL);
                command.ExecuteNonQuery();
                loadDataMon();
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

        private void btnMonUndo_Click(object sender, EventArgs e)
        {
            txtMonMS.Text = "";
            txtMonTen.Text = "";
        }

        private void btnCmon_Click(object sender, EventArgs e)
        {
            SLMonHoc frm = new SLMonHoc();
            frm.Show();
        }

        private void loadTabMon()
        {
            loadDataMon();
            loadSLMon();
        }
        //===============================================================

        //==========Thực hiện chức năng cho tab Thay đổi điểm chuẩn======
        private void loadCBDiem()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "SELECT * from MONHOC";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
            DataTable t = new DataTable();
            com.Fill(t);
            cbDiemmon.DataSource = t;
            cbDiemmon.ValueMember = "Ten";
            URL.Close();
        }

        private void loadTxtDiem()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "SELECT MH.TEN, DD.DIEMDAT FROM MONHOC MH INNER JOIN DIEMDATMON DD ON MH.MAMH = DD.MAMH WHERE MH.TEN LIKE N'%" + cbDiemmon.SelectedValue.ToString() + "%'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataReader com = commandSql.ExecuteReader();
            if (com.Read())
                txtDiemmon.Text = com["DIEMDAT"].ToString();
            URL.Close();
        }

        private void cbDiemmon_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTxtDiem();
        }

        private void DiemSave()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sua = "UPDATE DIEMDATMON SET DiemDat='"+txtDiemmon.Text+"' FROM MONHOC WHERE DIEMDATMON.MAMH = MONHOC.MAMH and MONHOC.Ten like N'"+cbDiemmon.SelectedValue.ToString()+"'";
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

        private void btnDiemSua_Click(object sender, EventArgs e)
        {
            if (txtDiemmon.Text.Length != 0)
                DiemSave();
            else
                MessageBox.Show("Vui lòng nhập điểm!!!");
        }

        private void loadTxtDiemTK()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "select * from QUYDINH where MAQD like'DIDA'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataReader com = commandSql.ExecuteReader();
            if (com.Read())
                txtDiemTK.Text = com["GiaTriQD"].ToString();
            URL.Close();
        }

        private void DiemSaveTK()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sua = "UPDATE QUYDINH SET GiaTriQD = '"+txtDiemTK.Text+"' WHERE MAQD like 'DIDA'";
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


        private void btnDiemSuaTK_Click(object sender, EventArgs e)
        {
            if (txtDiemTK.Text.Length != 0)
                DiemSaveTK();
            else
                MessageBox.Show("Vui lòng nhập điểm!!!");
        }

        private void txtDiemmon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void txtDiemTK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void loadTabDiem()
        {
            loadCBDiem();
            loadTxtDiem();
            loadTxtDiemTK();
        }

        //===============================================================

        //==========Thực hiện chức năng Tab Thay đổi chi tiết lớp======
        private void loadDataSSLop()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "SELECT * FROM LOP";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                dataSS.DataSource = table;
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

        private void dataSS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataSS.CurrentRow.Index;
            txtSSMa.Text = dataSS.Rows[index].Cells[0].Value.ToString();
            txtSSSL.Text = dataSS.Rows[index].Cells[1].Value.ToString();
            if (dataSS.Rows[index].Cells[2].Value.ToString().Equals("K10"))
                rbtKhoi10.Checked = true;
            else if (dataSS.Rows[index].Cells[2].Value.ToString().Equals("K11"))
                rbtKhoi11.Checked = true;
            else
                rbtKhoi12.Checked = true;
        }

        private void ThemLop()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string s ="";
                if(rbtKhoi10.Checked == true)
                    s = "K10";
                else if (rbtKhoi11.Checked == true)
                    s = "K11";
                else
                    s = "K12";
                string them = "INSERT INTO LOP VALUES('" + txtSSMa.Text + "','" + txtSSSL.Text + "','"+s+"')";
                SqlCommand command = new SqlCommand(them, URL);
                command.ExecuteNonQuery();
                loadDataSSLop();
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

        private void btnSSAdd_Click(object sender, EventArgs e)
        {
            if (txtSSMa.Text.Length > 0 && txtSSSL.Text.Length > 0)
            {
                ThemLop();
            }
            else
            {
                MessageBox.Show("Thiếu thông tin!!!\n Không thể thêm!!!");
            }
        }

        private void btnSSSua_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string s = "";
                if (rbtKhoi10.Checked == true)
                    s = "K10";
                else if (rbtKhoi11.Checked == true)
                    s = "K11";
                else
                    s = "K12";
                string sua = "UPDATE LOP SET SL='" + txtSSSL.Text + "', MAKHOI='"+s+"' WHERE MALOP='" + txtSSMa.Text + "'";
                SqlCommand command = new SqlCommand(sua, URL);
                command.ExecuteNonQuery();
                loadDataSSLop();
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

        private void btnSSDel_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string xoa = "DELETE FROM LOP WHERE MALOP = '" + txtSSMa.Text + "'";
                SqlCommand command = new SqlCommand(xoa, URL);
                command.ExecuteNonQuery();
                loadDataSSLop();
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

        private void btnSSUndo_Click(object sender, EventArgs e)
        {
            txtSSMa.Text = "";
            txtSSSL.Text = "";
            rbtKhoi10.Checked = true;
        }

        private void loadTabSS()
        {
            loadDataSSLop();
        }

        //=============================================================

        //=========Thực hiện các chức năng tab Thay đổi độ tuổi========
        private void loadTxtTuoiMin()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "select * from QUYDINH where MAQD like'TMIN'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataReader com = commandSql.ExecuteReader();
            if (com.Read())
                txtTuoiMin.Text = com["GiaTriQD"].ToString();
            URL.Close();
        }

        private void loadTxtTuoiMax()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "select * from QUYDINH where MAQD like'TMAX'";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataReader com = commandSql.ExecuteReader();
            if (com.Read())
                txtTuoiMax.Text = com["GiaTriQD"].ToString();
            URL.Close();
        }

        private void TuoiMinSave()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sua = "UPDATE QUYDINH SET GiaTriQD='"+txtTuoiMin.Text+"' WHERE MAQD like 'TMIN'";
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
        private void TuoiMaxSave()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sua = "UPDATE QUYDINH SET GiaTriQD='"+txtTuoiMax.Text+"' WHERE MAQD like 'TMAX'";
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

        private void btnTuoiSua_Click(object sender, EventArgs e)
        {
            if (txtTuoiMin.Text.Length != 0 && txtTuoiMax.Text.Length !=0)
            {
                TuoiMinSave();
                TuoiMaxSave();
            }
            else
                MessageBox.Show("Vui lòng nhập tuổi!!!");
        }

        private void txtTuoiMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTuoiMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void loadTabTuoi()
        {
            loadTxtTuoiMin();
            loadTxtTuoiMax();
        }

        //=============================================================

        //===========Thực hiện chức năng Tab ==================
       
        //=============================================================

        //============MainTheme Load===================
        private void MainTheme_Load(object sender, EventArgs e)
        {
            KNThemHS();
            clock.AutomaticMode = true;
            LoadTab10();
            LoadTab11();
            LoadTab12();
            loadTabTC();
            loadTabMon();
            loadTabDiem();
            loadTabSS();
            loadTabTuoi();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
