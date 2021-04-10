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
    public partial class AddKhoaForm : Form
    {
        Admin a;

        public AddKhoaForm(Admin ad)
        {
            a = ad;
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string maKh = textBoxMaKHoa.Text;
            string tenKh = textBoxTenKhoa.Text;
            int adminID = Admin.getAdminIdByUser(a.User1);
            if (adminID == 0)
            {
                MessageBox.Show("Can't not find out " + a.User1);
                return;
            }
            if (maKh.Length!=0&&tenKh.Length!=0)
            {
                Khoa k = new Khoa(maKh,tenKh);
                //add khoa
                if (Khoa.insertKhoa(k))
                {
                    MessageBox.Show("Add Khoa Success");

                }
                DateTime d = DateTime.Now;
                if (HistoryAction.insertHistoryAction(adminID, "Insert", d, "Insert Khoa with MaKhoa = " + k.MaKhoa1 + " and " + k.TenKhoa1))
                {
                    MessageBox.Show("Add History Success");
                }
            }
            else
            {
                MessageBox.Show("You must input Data!");
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
