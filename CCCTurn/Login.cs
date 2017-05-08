using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCCTurn
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.ToLower() == "admin" && txtPassword.Text.ToLower() == "admin123")
            {
                this.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
