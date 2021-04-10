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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            comboBoxMaGv.DisplayMember = "MaGv1";
            comboBoxMaGv.ValueMember = "MaGv1";
            comboBoxMaGv.DataSource = GiangVien.GetGiangViens();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBoxUserName.Text;
            string pass = textBoxPassWord.Text;
            string maGv = (string)comboBoxMaGv.SelectedValue;
            if (!checkFormat(user,pass))
            {
                return;
            }
            
            if (Admin.checkAdminExits(user))
            {
                MessageBox.Show("UserName Da Ton Tai!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Admin ad = new Admin(user,pass,maGv);
            if (Admin.insertAdmin(ad))
            {
                MessageBox.Show("Tao Thanh Cong User "+ad.User1);
            }
            else
            {
                MessageBox.Show("Tao That Bai User " + ad.User1);

            }
        }

        private bool checkFormat(string user, string pass)
        {
            if (user.Length==0||pass.Length==0)
            {
                MessageBox.Show("Vui Long Nhap Du Thong Tin!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false ;
            }
            if (user.Length<=4||pass.Length<=4)
            {
                MessageBox.Show("UserName va Password phai co it nhat 8 ky tu", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
