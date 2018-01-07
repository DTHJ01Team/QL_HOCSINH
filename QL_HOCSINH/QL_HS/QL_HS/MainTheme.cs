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
        //set dateformat dmy
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
                string them = "INSERT INTO HOCSINH VALUES('" + txtMS.Text + "',N'" + txtTen.Text + "','" + txtdate.Text + "',N'" + s + "','" + txtEmail.Text + "',N'" + txtDiaChi.Text + "')";
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
                string sua = "set dateformat dmy UPDATE HOCSINH SET HoTen=N'" + txtTen.Text + "', NgaySinh='" + txtdate.Text + "', GioiTinh=N'" + s + "', Email='" + txtEmail.Text + "', DiaChi=N'" + txtDiaChi.Text + "' WHERE MAHS='" + txtMS.Text + "'";
                SqlCommand command = new SqlCommand(sua, URL);
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
            KNThemHS();
            tabThemHS.Visible = true;
            tabMain.SelectedTab = tabThemHS;
        }

        private void btnLapDS_Click(object sender, EventArgs e)
        {
            LoadTab10();
            LoadTab11();
            LoadTab12();
            tabLapDS.Visible = true;
            tabMain.SelectedTab = tabLapDS;
        }

        private void btnTra_Click(object sender, EventArgs e)
        {
            loadTabTC();
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
            Nhapdiemmonhoc();
            tabNhapDiem.Visible = true;
            tabMain.SelectedTab = tabNhapDiem;
        }

        private void btnTinhDiem_Click(object sender, EventArgs e)
        {
            loadTabBdm();
            tabTinhTB.Visible = true;
            tabMain.SelectedTab = tabTinhTB;
        }

        private void btnBCTK_Click(object sender, EventArgs e)
        {
            loadtabTK();
            tabBCTK.Visible = true;
            tabMain.SelectedTab = tabBCTK;
        }

        private void btnMon_Click(object sender, EventArgs e)
        {
            loadTabMon();
            tabMon.Visible = true;
            tabMain.SelectedTab = tabMon;
        }

        private void btnDiem_Click(object sender, EventArgs e)
        {
            loadTabDiem();
            tabDiem.Visible = true;
            tabMain.SelectedTab = tabDiem;
        }

        private void btnSS_Click(object sender, EventArgs e)
        {
            loadTabSS();
            tabSS.Visible = true;
            tabMain.SelectedTab = tabSS;
        }

        private void btnTuoi_Click(object sender, EventArgs e)
        {
            loadTabTuoi();
            tabTuoi.Visible = true;
            tabMain.SelectedTab = tabTuoi;
        }
        //====================================================================

        //===========Thực hiện chức năng liên kết from cho 3 tab trong tab lập DS lớp====
        private void btnAdd10_Click(object sender, EventArgs e)
        {
            if ((dataTab10.Rows.Count - 1) < int.Parse(txtSS10.Text))
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
            SqlDataReader com = commandSql.ExecuteReader();
            if (com.Read())
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
                string sql = "select H.HoTen, L.MALOP, [HK1] = (select DTBHK from DIEMHOCKY D, HOCSINH H where D.MAHS = H.MAHS and MAHK like 'HK1'), [HK2] = (select DTBHK from DIEMHOCKY D, HOCSINH H where D.MAHS = H.MAHS and MAHK like 'HK2')\n" +
                                    "from LOP L, DIEMHOCKY D, HOCSINH H\n" +
                                    "where L.MALOP = D.MALOP and D.MAHS = H.MAHS\n" +
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
            int SD = (dataMon.Rows.Count - 1);
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
                string sua = "UPDATE DIEMDATMON SET DiemDat='" + txtDiemmon.Text + "' FROM MONHOC WHERE DIEMDATMON.MAMH = MONHOC.MAMH and MONHOC.Ten like N'" + cbDiemmon.SelectedValue.ToString() + "'";
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
                string sua = "UPDATE QUYDINH SET GiaTriQD = '" + txtDiemTK.Text + "' WHERE MAQD like 'DIDA'";
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
                string s = "";
                if (rbtKhoi10.Checked == true)
                    s = "K10";
                else if (rbtKhoi11.Checked == true)
                    s = "K11";
                else
                    s = "K12";
                string them = "INSERT INTO LOP VALUES('" + txtSSMa.Text + "','" + txtSSSL.Text + "','" + s + "')";
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
                string sua = "UPDATE LOP SET SL='" + txtSSSL.Text + "', MAKHOI='" + s + "' WHERE MALOP='" + txtSSMa.Text + "'";
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
                string sua = "UPDATE QUYDINH SET GiaTriQD='" + txtTuoiMin.Text + "' WHERE MAQD like 'TMIN'";
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
                string sua = "UPDATE QUYDINH SET GiaTriQD='" + txtTuoiMax.Text + "' WHERE MAQD like 'TMAX'";
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
            if (txtTuoiMin.Text.Length != 0 && txtTuoiMax.Text.Length != 0)
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

        //===========Thực hiện chức năng Tab Nhap diem mon hoc ==================
        private void loadMSSV()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string sql2 = "select MAMH from MONHOC";
            string sql3 = "select MAHS from HOCSINH";
            SqlDataAdapter ad2 = new SqlDataAdapter(sql2, URL);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            cbndMamon.DataSource = dt2;
            cbndMamon.ValueMember = "MAMH";
            SqlDataAdapter ad3 = new SqlDataAdapter(sql3, URL);
            DataTable dt3 = new DataTable();
            ad3.Fill(dt3);
            cbndMahocsinh.DataSource = dt3;
            cbndMahocsinh.ValueMember = "MAHS";
            URL.Close();
        }

        private void loadtabndmh()
        {
            try
            {
                SqlConnection sql = new SqlConnection(link);
                sql.Open();
                string loadtenn = "select * from HOCSINH where MAHS like '%" + cbndMahocsinh.SelectedValue.ToString() + "%'";
                SqlCommand commandsql = new SqlCommand(loadtenn, sql);
                SqlDataReader chim = commandsql.ExecuteReader();
                if (chim.Read())
                    txtndHoten.Text = chim["HoTen"].ToString();
            }
            catch
            {
                MessageBox.Show("Hiện chưa có dữ liệu !!!", "Thông báo lỗi !!!");
            }
            finally
            {
                SqlConnection sql = new SqlConnection(link);
                sql.Close();
            }
        }

        private void loadtabtxtlop()
        {
            try
            {
                SqlConnection sql = new SqlConnection(link);
                sql.Open();
                string loadten = "select * FROM CTLOP WHERE MAHS LIKE '%" + cbndMahocsinh.SelectedValue.ToString() + "%'";
                SqlCommand commandsqll = new SqlCommand(loadten, sql);
                SqlDataReader comm = commandsqll.ExecuteReader();
                if (comm.Read())
                    txtndLop.Text = comm["MALOP"].ToString();
            }
            catch
            {
                MessageBox.Show("Hiện chưa có dữ liệu !!!", "Thông báo lỗi !!!");
            }
            finally
            {
                SqlConnection sql = new SqlConnection(link);
                sql.Close();
            }
        }

        private void loadtablablelop()
        {
            SqlConnection sql = new SqlConnection(link);
            sql.Open();
            string loadten = "select * from MONHOC where MAMH like '%" + cbndMamon.SelectedValue.ToString() + "%'";
            SqlCommand commandsqll = new SqlCommand(loadten, sql);
            SqlDataReader comm = commandsqll.ExecuteReader();
            if (comm.Read())
                txtndTenmon.Text = comm["Ten"].ToString();
            sql.Close();
        }

        private void loadData()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sql = "select h.MAHS, h.HoTen, d.MAHK, m.MAMH, d.[15P], d.[45P], DTBM = CONVERT(decimal(5,2),D.DTBM) from HOCSINH H, DIEMKIEMTRA D, MONHOC M where h.MAHS = d.MAHS and D.MAMH = m.MAMH";
                SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                dataGridViewNhapdiem.DataSource = table;
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

        private void cbndMahocsinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadtabndmh();
            loadtabtxtlop();
        }

        private void cbndMamon_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadtablablelop();
        }
        //Viet ham update DTB
        private void DTB_Update()
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string DTB = "update DIEMKIEMTRA set DTBM = (select (([15P] + [45P]*2)/3))";
                SqlCommand command = new SqlCommand(DTB, URL);
                command.ExecuteNonQuery();
                loadData();
            }
            catch
            {
                MessageBox.Show("Update điểm không thành công!", "Thông báo lỗi");
            }
            finally
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Close();
            }
        }

        //Viet ham insert
        private void btndThem_Click(object sender, EventArgs e)
        {
            try
            {
                string HK = "";
                if (rbndHKI.Checked == true)
                    HK = "HK1";
                else
                    HK = "HK2";
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string insert = "INSERT INTO DIEMKIEMTRA VALUES('" + cbndMahocsinh.SelectedValue.ToString() + "','" + cbndMamon.SelectedValue.ToString() + "','" + HK + "','" + txtndDiem15.Text + "','" + txtndDiem45.Text + "',0)";
                SqlCommand command = new SqlCommand(insert, URL);
                command.ExecuteNonQuery();
                DTB_Update();
                loadData();
            }
            catch
            {

                MessageBox.Show("Thêm không thành công", "Thông báo lỗi");

            }
            finally
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Close();
            }
        }

        //Viet ham Edit
        private void btndSua_Click(object sender, EventArgs e)
        {
            try
            {
                string HK = "";
                if (rbndHKI.Checked == true)
                    HK = "HK1";
                else
                    HK = "HK2";
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string sua = "UPDATE DIEMKIEMTRA SET [15P]='" + txtndDiem15.Text + "', [45P] = '" + txtndDiem45.Text + "' WHERE MAHS='" + cbndMahocsinh.SelectedValue.ToString() + "' and MAMH ='" + cbndMamon.SelectedValue.ToString() + "' and MAHK='" + HK + "'";
                SqlCommand command = new SqlCommand(sua, URL);
                command.ExecuteNonQuery();
                DTB_Update();
                loadData();
            }
            catch
            {
                MessageBox.Show("Sửa không thành công!", "Thông báo lỗi");
            }
            finally
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Close();
            }
        }

        //Viet ham DELETE
        private void btndXoa_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Open();
                string HK = "";
                if (rbndHKI.Checked == true)
                    HK = "HK1";
                else
                    HK = "HK2";
                string xoa = "DELETE FROM DIEMKIEMTRA WHERE MAHS='" + cbndMahocsinh.SelectedValue.ToString() + "' and MAMH='" + cbndMamon.SelectedValue.ToString() + "' and MAHK='" + HK + "'";
                SqlCommand command = new SqlCommand(xoa, URL);
                command.ExecuteNonQuery();
                loadData();
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo lỗi");
            }
            finally
            {
                SqlConnection URL = new SqlConnection(link);
                URL.Close();
            }
        }

        //Viet ham nhap lai
        private void btndNhaplai_Click(object sender, EventArgs e)
        {
            //cbndMahocsinh.SelectedValue = "";       
            rbndHKI.Checked = true;
            //cbndMamon.SelectedValue = "";
            txtndDiem15.Text = "";
            txtndDiem45.Text = "";
        }

        //Viet ham push thong tin chi tiet
        private void dataGridViewNhapdiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridViewNhapdiem.CurrentRow.Index;
            cbndMahocsinh.SelectedValue = dataGridViewNhapdiem.Rows[index].Cells[0].Value.ToString();
            txtndHoten.Text = dataGridViewNhapdiem.Rows[index].Cells[1].Value.ToString();
            if (dataGridViewNhapdiem.Rows[index].Cells[2].Value.ToString().Equals("HK1"))
                rbndHKI.Checked = true;
            else
                rbndHKII.Checked = true;
            cbndMamon.SelectedValue = dataGridViewNhapdiem.Rows[index].Cells[3].Value.ToString();
            txtndDiem15.Text = dataGridViewNhapdiem.Rows[index].Cells[4].Value.ToString();
            txtndDiem45.Text = dataGridViewNhapdiem.Rows[index].Cells[5].Value.ToString();
        }

        private void txtndDiem15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtndDiem45_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
        private void Nhapdiemmonhoc()
        {
            loadData();
            loadMSSV();
            loadtabndmh();
            loadtabndmh();
            loadtablablelop();
            loadtabtxtlop();
            DTB_Update();
        }
        //=============================================================
        //===========Thực hiện chức năng Tab Tính điểm học kỳ==================
        private void loadcb()
        {
            SqlConnection ma = new SqlConnection(link);
            ma.Open();
            string load1 = "SELECT * from HOCSINH";
            SqlCommand commandSql1 = new SqlCommand(load1, ma); // Thực thi câu lệnh SQL
            SqlDataAdapter com1 = new SqlDataAdapter(commandSql1); //Vận chuyển dữ liệu
            DataTable table1 = new DataTable();
            com1.Fill(table1);
            cbMHS.DataSource = table1;
            cbMHS.ValueMember = "MAHS";
            ma.Close();
        }

        private void loadlop()
        {
            try
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Open();
                string load = "SELECT * from CTLOP where MAHS = '" + cbMHS.SelectedValue.ToString() + "'";
                SqlCommand commandSql = new SqlCommand(load, ma); // Thực thi câu lệnh SQL
                SqlDataReader com = commandSql.ExecuteReader(); //Vận chuyển dữ liệu
                if (com.Read())
                    txtLop.Text = com["MALOP"].ToString();
            }
            catch
            {
                MessageBox.Show("Hiện chưa có dữ liệu!!!", "Thông báo lỗi!!!");
            }
            finally
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Close();
            }
        }
        private void loadmahs()
        {
            try
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Open();
                string load = "Select * from HOCSINH where MAHS like '%" + cbMHS.SelectedValue.ToString() + "%'";
                SqlCommand commandSql = new SqlCommand(load, ma); // Thực thi câu lệnh SQL
                SqlDataReader com = commandSql.ExecuteReader();
                if (com.Read())
                    txtHoten.Text = com["HoTen"].ToString();
            }
            catch
            {
                MessageBox.Show("Hiện chưa có dữ liệu!!!", "Thông báo lỗi!!!");
            }
            finally
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Close();
            }
        }

        private void cbMHS_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadmahs();
            loadlop();
        }

        private void loadbdm()
        {
            try
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Open();
                string sql = "select H.MAHS , H.HoTen, D.MALOP, D.MAHK, DTBHK from DIEMHOCKY D, HOCSINH H where D.MAHS = H.MAHS";
                SqlCommand commandSql = new SqlCommand(sql, ma); // Thực thi câu lệnh SQL
                SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                DataTable table = new DataTable();
                com.Fill(table);
                dataBdm.DataSource = table;
            }
            catch
            {
                MessageBox.Show("Kết nối không thành công! Vui lòng kết nối lại!");
            }
            finally
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Close();
            }
        }

        private void Update_DTBHK()
        {
            try
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Open();
                string sua = "update DIEMHOCKY set DTBHK = (select CONVERT(decimal(5,2),sum(DTBM)/count(MAHS)) from DIEMKIEMTRA D where D.MAHS = DIEMHOCKY.MAHS and D.MAHK = DIEMHOCKY.MAHK group by MAHS, MAHK)";
                SqlCommand command = new SqlCommand(sua, ma);
                command.ExecuteNonQuery();
                loadbdm();
            }
            catch
            {
                MessageBox.Show("Sửa không thành công!!!");
            }
            finally
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Close();
            }
        }

        private void cbThembdm_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection ma = new SqlConnection(link);
                ma.Open();
                string hk = "";
                if (rbTDHK1.Checked == true)
                    hk = "HK1";
                else
                    hk = "HK2";
                string them = "INSERT INTO DIEMHOCKY VALUES(' " + cbMHS.SelectedValue.ToString() + "',' " + txtLop.Text + " ','" + hk + "')";
                SqlCommand command = new SqlCommand(them, ma);
                command.ExecuteNonQuery();
                Update_DTBHK();
                loadbdm();
            }
            catch
            {
                MessageBox.Show("Thêm không thành công!!!");
            }
            finally
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Close();
            }
        }


        private void cbXoabdm_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Open();
                string hk = "";
                if (rbTDHK1.Checked == true)
                    hk = "HK1";
                else
                    hk = "HK2";
                string xoa = "DELETE FROM DIEMHOCKY WHERE MAHS='" + cbMHS.SelectedValue.ToString() + "' and MALOP ='" + txtLop.Text + "' and MAHK= '" + hk + "'";
                SqlCommand command = new SqlCommand(xoa, ma);
                command.ExecuteNonQuery();
                loadbdm();
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!");
            }
            finally
            {
                SqlConnection ma = new SqlConnection(link);
                ma.Close();
            }
        }

        private void dataBdm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataBdm.CurrentRow.Index;
            cbMHS.SelectedValue = dataBdm.Rows[index].Cells[0].Value.ToString();
            txtLop.Text = dataBdm.Rows[index].Cells[2].Value.ToString();
        }

        private void loadTabBdm()
        {

            Update_DTBHK();
            loadcb();
            loadmahs();
            loadbdm();
            loadlop();
        }
        //=============================================================
        //===========Thực hiện chức năng Tab la bao cao tong ket==================
        private void loadcbloptk()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "SELECT * from LOP";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
            DataTable t = new DataTable();
            com.Fill(t);
            cblop.DataSource = t;
            cblop.ValueMember = "MALOP";
            URL.Close();
        }
        private void loadcbmontk()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();
            string load = "SELECT * from MONHOC";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
            DataTable t = new DataTable();
            com.Fill(t);
            cbmon.DataSource = t;
            cbmon.ValueMember = "TEN";
            URL.Close();
        }
        private void loadcbmontk1()
        {
            SqlConnection URL = new SqlConnection(link);
            URL.Open();

            string load = "SELECT * from LOP";
            SqlCommand commandSql = new SqlCommand(load, URL); // Thực thi câu lệnh SQL
            SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
            DataTable t = new DataTable();
            com.Fill(t);
            cblop1.DataSource = t;
            cblop1.ValueMember = "MALOP";
            URL.Close();
        }

        private void loadBCTKmon()
        {

            if (rdtkmon.Checked)
            {
                try
                {
                    SqlConnection URL = new SqlConnection(link);
                    URL.Open();
                    string sql = "select L.MALOP, L.SL, \n" +
                                 "[Dat] = (select count(D.MAHS) from DIEMKIEMTRA D, DIEMDATMON DD, CTLOP C where D.MAMH = DD.MAMH and D.MAHS = C.MAHS and D.DTBM>= DD.DiemDat  and D.MAMH like '%" + cbmon.SelectedValue.ToString() + "%' and C.MALOP like '%" + cblop.SelectedValue.ToString() + "%'),\n" +
                                 "[TL] = convert(varchar(50),((select count(D.MAHS) from DIEMKIEMTRA D, DIEMDATMON DD, CTLOP C where D.MAMH = DD.MAMH and D.MAHS = C.MAHS and D.DTBM>= DD.DiemDat and D.MAMH like '%" + cbmon.SelectedValue.ToString() + "%' and C.MALOP like '%" + cblop.SelectedValue.ToString() + "%') / convert(float,L.SL)*100)) + '%'\n" +
                                 "from LOP L, DIEMKIEMTRA D, CTLOP C\n" +
                                 "where L.MALOP = C.MALOP and C.MAHS = D.MAHS and C.MALOP like '%" +
                                 cblop.SelectedValue.ToString() +
                                 "%'\n" + "group by L.MALOP, L.SL";
                    SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                    SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                    DataTable table = new DataTable();
                    com.Fill(table);
                    DataGV.DataSource = table;
                }
                catch
                {
                    MessageBox.Show("Hiện không có dữ liệu!!!", "Thông báo lỗi");
                }
            }
            else if (rdtkhocky.Checked)
            {
                try
                {
                    SqlConnection URL = new SqlConnection(link);
                    URL.Open();
                    string sql = "select L.MALOP, L.SL,\n" +
                                 "[Dat] = (select count(D.MAHS) from  DIEMHOCKY D, QUYDINH Q where Q.MAQD like 'DIDA' and D.MALOP like '%" + cblop1.SelectedValue.ToString() + "%' group by Q.GiaTriQD having sum(DTBHK)/2 > Q.GiaTriQD)/2,\n" +
                                 "[TL] = convert(varchar(50),((select count(D.MAHS) from  DIEMHOCKY D, QUYDINH Q where Q.MAQD like 'DIDA' and D.MALOP like '%" + cblop1.SelectedValue.ToString() + "%' group by Q.GiaTriQD having sum(DTBHK)/2 > Q.GiaTriQD)/2) / convert(float,L.SL)*100) + '%'\n" +
                                 "from LOP L, DIEMHOCKY D, CTLOP C\n" +
                                 "where L.MALOP = D.MALOP and D.MAHS = C.MAHS and C.MALOP like '%" + cblop1.SelectedValue.ToString() + "%'\n" +
                                 "group by L.MALOP, L.SL";
                    SqlCommand commandSql = new SqlCommand(sql, URL); // Thực thi câu lệnh SQL
                    SqlDataAdapter com = new SqlDataAdapter(commandSql); //Vận chuyển dữ liệu
                    DataTable table = new DataTable();
                    com.Fill(table);
                    DataGV.DataSource = table;
                }
                catch
                {
                    MessageBox.Show("Hiện không có dữ liệu!!!", "Thông báo lỗi");
                }
            }
            else
                MessageBox.Show("Bạn phải chọn tổng kết học kỳ hoặc tổng kết môn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        // ===============hàm ẩn button nếu không click checkbox trong báo cáo tổng kết================
        private void rdtkmon_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtkmon.Checked)
            {

                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
            }

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            loadBCTKmon();
        }


        private void loadtabTK()
        {
            groupBox2.Enabled = false;
            loadcbloptk();
            loadcbmontk();
            loadcbmontk1();
        }

        //=============================================================

        //============MainTheme Load===================
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMainRef_Click(object sender, EventArgs e)
        {
            KNThemHS();
            LoadTab10();
            LoadTab11();
            LoadTab12();
            loadTabTC();
            loadTabMon();
            loadTabDiem();
            loadTabSS();
            loadTabTuoi();
            Nhapdiemmonhoc();
            loadTabBdm();
            loadtabTK();
        }
        private void MainTheme_Load(object sender, EventArgs e)
        {
            clock.AutomaticMode = true;
           
        }

        private void MainTheme_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
