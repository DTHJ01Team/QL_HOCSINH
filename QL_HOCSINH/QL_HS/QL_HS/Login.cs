using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace QL_HS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void mainCall ()
        {
            
            Login.ActiveForm.Hide();
            MainTheme frm = new MainTheme();
            frm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int code = int.Parse(txtCode.Text);
            switch(code)
            {
                case 0206:
                case 2009:
                case 1511:
                case 1009:
                    mainCall();
                    break;
                default:
                    lbTT.Text = "Đăng nhập thất bại!!!";
                    txtCode.Text = "";
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
            if (txtCode.Text.Length > 3)
                e.Handled = true;
            if (e.KeyChar == 13)
                btnLogin.PerformClick();
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
    }
}
