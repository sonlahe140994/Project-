using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ProjectC.DAO;

namespace ProjectC
{
    public partial class Login : Form
    {
        Form1 f;
        SignIn s;
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string user = textBoxUserName.Text;
            string pass = textBoxPassWord.Text;
            Admin a = Admin.GetAdmin(user,pass);
            if (a!=null)
            {
                f = new Form1(a);
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("UserName or PassWord is wrong!!!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if (s ==null)
            {
                s = new SignIn();
                s.Show();
                s = null;
            }
        }
    }
}
