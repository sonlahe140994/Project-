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
    public partial class ThemMon : Form
    {
        Admin a;
        public ThemMon(Admin ad)
        {
            a = ad;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maMon = (string)textBoxMaMon.Text;
            string tenMon = (string)textBoxTenMon.Text;
            string slot = (string)textBoxSlot.Text;
            if (!checkFormat(maMon,tenMon,slot))
            {
                return;
            }
            int adminID = Admin.getAdminIdByUser(a.User1);
            if (adminID == 0)
            {
                MessageBox.Show("Can't not find out " + a.User1);
                return;
            }
            MonHoc m = new MonHoc(maMon,tenMon,Convert.ToInt32(slot));
            if (!MonHoc.insertMonHoc(m))
            {
                return;
            }
            DateTime d = DateTime.Now;
            if (HistoryAction.insertHistoryAction(adminID, "Insert", d, "Insert MonHoc with MaMonHoc: " +m.MaMh1+", TenMh: "+m.TenMh1+" ,slot: "+m.Slot1 ))
            {
                MessageBox.Show("Add Success");
            }

        }

        private bool checkFormat(string maMon, string tenMon, string slot)
        {
            
            if (maMon.Length>6||maMon.Length==0)
            {
                MessageBox.Show("Ma Mon Hoc nhieu nhat 6 ky tu");
                return false;
               
            }
            if (tenMon.Length==0)
            {
                MessageBox.Show("Nhap Ten Mon Hoc");
                return false;
            }
            try
            {
                int slotNum = Convert.ToInt32(slot);
                if (slotNum<10||slotNum>40)
                {
                    MessageBox.Show("Slot nhieu hon 10 va it hon 40");
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
