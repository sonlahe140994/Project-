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
    public partial class AddPoint : Form
    {
        public AddPoint(Admin a)
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void AddPoint_Load(object sender, EventArgs e)
        {
            comboBoxMaMh.ValueMember = "MaMh1";
            comboBoxMaMh.DisplayMember = "TenMh1";
            comboBoxMaMh.DataSource = MonHoc.GetMonHocs();

            comboBoxMaMh.SelectedIndex = 0;




            for (int i =1; i <= 4 ; i++ )
            {
                comboBoxLanThi.Items.Add(i + "");
            }
            comboBoxLanThi.SelectedIndex = 0;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maSv = textBoxMaSv.Text;
            string maMh = (string)comboBoxMaMh.SelectedValue;
            string lanThi = (string)comboBoxLanThi.SelectedItem;
            string diemThi = textBoxDiemThi.Text;
            if (checkFormat(diemThi))
            {
                if (SinhVien.CheckSinhVienExits(maSv))
                {
                    DiemThi d = new DiemThi(maSv, maMh, Convert.ToInt32(lanThi), Convert.ToInt32(diemThi));
                    if (DiemThi.insertDiem(d))
                    {
                        MessageBox.Show("Them Diem Thanh Cong");    
                    }
                    else
                    {
                        MessageBox.Show("Them Diem That Bai", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Sinh Vien "+maSv+" khong ton tai!!!!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            
            
                
            
            

            
        }

        private bool checkFormat(string diemThi)
        {
           try
            {
                if (diemThi.Length == 0)
                {
                    MessageBox.Show("Vui Nhap Nhap Ma Sinh Vien Va Diem", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                int b = Convert.ToInt32(diemThi.ToString());
                if (b > 10 || b < 0)
                {
                    MessageBox.Show("Diem so nam trong khoang 0 -> 10", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
