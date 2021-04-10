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
    public partial class ThemSinhVienForm : Form
    {
        Admin a;
        public ThemSinhVienForm(Admin ad)
        {
            a = ad;
            InitializeComponent();
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {

            comboBoxMaLOp.DisplayMember = "TenLop";
            comboBoxMaLOp.ValueMember = "MaLop";
            comboBoxMaLOp.DataSource = Lop.getAllClass();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int adminID = Admin.getAdminIdByUser(a.User1);
            if (adminID == 0)
            {
                MessageBox.Show("Can't not find out " + a.User1);
                return;
            }
            string maSV = textBoxMSSV.Text;
            string tenSv = textBoxTenSV.Text;
            if (!checkFormat(maSV, tenSv))
            {
                return;
            }
            if (SinhVien.CheckSinhVienExits(maSV))
            {
                MessageBox.Show("Ma Sinh Vien Da Ton Tai!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool GioiTinh = getGioiTinh();
            DateTime d = dateTimePicker1.Value;
            string maLop =(string)comboBoxMaLOp.SelectedValue;
            SinhVien s = new SinhVien(maSV,tenSv,GioiTinh,d,maLop);
            if (!SinhVien.insertSinhVien(s))
            {
                MessageBox.Show("Add That Bai", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime dn = DateTime.Now;
            if (HistoryAction.insertHistoryAction(adminID, "Insert", dn, "Insert SinhVien with MaSv: " + s.MaSv)) ;
            {
                MessageBox.Show("Add History Success");
            }
        }

        private bool getGioiTinh()
        {
            if (checkBoxNam.Checked)
            {
                return true;
            }
            return false;
        }

        private bool checkFormat(string maSV, string tenSv)
        {
            if (maSV.Length==0||tenSv.Length==0)
            {
                MessageBox.Show("Vui Long Nhap Thong tin cho MaSv Va Ten Sv", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true; ;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
      
    
}
