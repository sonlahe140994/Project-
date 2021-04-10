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
    public partial class UpdatePoint : Form
    {
        SinhVienAndPoint s;
        Admin a;
        public UpdatePoint(SinhVienAndPoint sv, Admin ad)
        {
            a = ad;
            s = sv;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int adminID = Admin.getAdminIdByUser(a.User1);
            if (adminID == 0)
            {
                MessageBox.Show("Can't not find out " + a.User1);
                return;
            }
            string lanThi = textBoxLanThi.Text;
            string diem = textBoxDiemThi.Text;
            if (lanThi.Length==0||diem.Length==0)
            {
                MessageBox.Show("You must enter value for Lan thi and  Diem");
            }
            else if(checkNumber(lanThi)&&checkNumber(diem))
            {
                    var result = MessageBox.Show("Do you want to update ?", "Notification",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result==DialogResult.OK)
                {
                    int lThi = Convert.ToInt32(lanThi);
                    int diemTh = Convert.ToInt32(diem);

                    //update diem thi
                    if (DiemThi.updateDiem(s,lThi,diemTh))
                    {
                        MessageBox.Show("Update success");
                    }
                    else
                    {
                        MessageBox.Show("Update faill");
                        return;
                    }
                    DateTime d = DateTime.Now;
                    if (HistoryAction.insertHistoryAction(adminID, "Update", d, "Update DiemThi with MaSv " + s.MaSv1 + " Diem Thi Lan Cu: " + s.DiemThi1 + " -> Diem Thi Moi: " + diemTh + " Lan Thi Cu: " + s.LanThi1+" -> Lan Thi Moi: "+lanThi))
                    {
                        MessageBox.Show("Add History Success");
                    }


                }

            }
            else
            {
                MessageBox.Show("Please Input Againt");
            }
        }

        private bool checkNumber(string s)
        {
            try
            {
                int output = Convert.ToInt32(s.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void UpdatePoint_Load(object sender, EventArgs e)
        {
            labelLop.Text = s.MaLop1;
            labelMasoSV.Text = s.MaSv1;
            labelMaMonHoc.Text = s.MaMh1;
            textBoxLanThi.Text = s.LanThi1.ToString();
            textBoxDiemThi.Text = s.DiemThi1.ToString();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
