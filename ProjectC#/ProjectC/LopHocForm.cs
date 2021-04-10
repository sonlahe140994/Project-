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
    public partial class LopHocForm : Form
    {
        Admin a;
        public LopHocForm(Admin ad)
        {
            a = ad;
            InitializeComponent();
        }

        private void LopHocForm_Load(object sender, EventArgs e)
        {
            dataGridViewLop.DataSource = Lop.getAllClass();

            comboBoxKhoa.DisplayMember = "TenKhoa1";
            comboBoxKhoa.ValueMember = "MaKhoa1";
            comboBoxKhoa.DataSource = Khoa.GetKhoas();

            comboBoxMaGV.DisplayMember = "TenGv1";
            comboBoxMaGV.ValueMember = "MaGv1";
            comboBoxMaGV.DataSource = GiangVien.GetGiangViens();
        }
        
        private void comboBoxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maLop =(string)comboBoxKhoa.SelectedValue;
            string tenLop = (string)comboBoxKhoa.Text;
            labelMaLop.Text = maLop;
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int adminID = Admin.getAdminIdByUser(a.User1);
            if (adminID == 0)
            {
                MessageBox.Show("Can't not find out " + a.User1);
                return;
            }
            string maLop = (string)comboBoxKhoa.SelectedValue;
            string tenLop = (string)comboBoxKhoa.Text;
            string numLop = textBoxMaLop.Text.Trim();
            string maKhoa = (string)comboBoxKhoa.SelectedValue;
            string maGv = (string)comboBoxMaGV.SelectedValue;

            if (checkNumLop(numLop))
            {
                maLop += numLop;
                tenLop += numLop;
                Lop l = new Lop(maLop,tenLop,maKhoa,maGv);
                if (Lop.checkLopExits(l))
                {
                    MessageBox.Show("Lop Da Ton Tai!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Lop.insertLop(l))
                {
                    MessageBox.Show("Add lop success");
                }
                else
                {
                    return;
                }
                DateTime d = DateTime.Now;
                if (HistoryAction.insertHistoryAction(adminID, "Insert", d, "Insert Lop with MaLop: "+maLop+", TenLop: "+tenLop+", MaKhoa: "+maKhoa+", MaGv: "+maGv))
                {
                    MessageBox.Show("Add History Success");
                }
            }
        }

        

        private bool checkNumLop(string numLop)
        {
            if (numLop.Length==0)
            {
                MessageBox.Show("Vui long nhap ten lop!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numLop.Length>4||numLop.Length<4)
            {
                MessageBox.Show("Ma lop co 4 chu so", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            try
            {
                int soLop = Convert.ToInt32(numLop);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewLop.DataSource = Lop.getAllClass();
        }
    }
}
