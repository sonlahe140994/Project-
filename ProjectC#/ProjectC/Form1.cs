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
    public partial class Form1 : Form
    {
        DiemThiForm d;
        Admin a;
        KhoaForm kf;
        GiangVienForm gvf;
        AddPoint ap;
        ThemMon tm;
        Login l;
        LopHocForm lop;
        ThemSinhVienForm tsvf;
        public Form1(Admin ad)
        {
            a = ad;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelMaGv.Text = a.MaGv1;
            labelUser.Text = a.User1;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (d==null)
            {
                d = new DiemThiForm(a);
                d.Show();
                d = null;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (kf==null)
            {
                kf = new KhoaForm(a);
                kf.Show();
                kf = null;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (gvf==null)
            {
                gvf = new GiangVienForm(a);
                gvf.Show();
                gvf = null;
            }
        }

        private void buttonAddDiem_Click(object sender, EventArgs e)
        {
            if (ap==null)
            {
                ap = new AddPoint(a);
                ap.Show();
                ap = null;
            }
        }

        private void buttonThemMon_Click(object sender, EventArgs e)
        {
            if (tm==null)
            {
                tm = new ThemMon(a);
                tm.Show();
                tm = null;
            }
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (checkOptionLogout())
            {
                a = null;
                this.Close();
                l = new Login();
                l.Show();
            }
        }

        private bool checkOptionLogout()
        {
            var result = MessageBox.Show("Do you want to log out ?","Notification",MessageBoxButtons.YesNo);
            if (result==DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        private void buttonThemSv_Click(object sender, EventArgs e)
        {
            if (tsvf==null)
            {
                tsvf = new ThemSinhVienForm(a);
                tsvf.Show();
                tsvf = null;
            }
        }

        private void buttonLopHoc_Click(object sender, EventArgs e)
        {
            if (lop == null)
            {
                lop = new LopHocForm(a);
                lop.Show();
                lop = null;
            }
        }
    }
}
