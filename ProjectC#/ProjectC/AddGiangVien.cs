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
    public partial class AddGiangVien : Form
    {
        Admin a;
        public AddGiangVien(Admin ad)
        {
            a = ad;
            InitializeComponent();
        }

        private void AddGiangVien_Load(object sender, EventArgs e)
        {
            comboBoxMaKhoa.ValueMember = "MaKhoa1";
            comboBoxMaKhoa.DisplayMember = "TenKhoa1";
            comboBoxMaKhoa.DataSource = Khoa.GetKhoas();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string maGv = textBoxMaGv.Text;
            string tenGv = textBoxTenGv.Text;
            string chuyenNg = textBoxChuyenNganh.Text;
            string maKhoa = (string)comboBoxMaKhoa.SelectedValue;

            int adminID = Admin.getAdminIdByUser(a.User1);
            if (adminID == 0)
            {
                MessageBox.Show("Can't not find out " + a.User1);
                return;
            }
            if (maGv.Length!=0 && tenGv.Length!=0 && chuyenNg.Length!=0)
            {
                GiangVien gv = new GiangVien(maGv,tenGv,chuyenNg,maKhoa);

                if (GiangVien.insertGiangVien(gv))
                {
                    MessageBox.Show("Add Giang Vien "+ maGv+" successful!!!");
                }
                else
                {
                    MessageBox.Show("Can't not add giang vien "+ maGv );
                }
                DateTime d = DateTime.Now;
                if (HistoryAction.insertHistoryAction(adminID, "Insert", d, "Insert GiangVien with MaGiangVien: " + gv.MaGv1 + ", TenGiangVien: " + gv.TenGv1+" ,Chuyen Nganh: "+gv.ChuyenNganh1+" ,Ma Khoa: "+gv.MaKhoa1))
                {
                    MessageBox.Show("Add History Success");
                }
            }
            else
            {
                MessageBox.Show("You must input all data!!!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
