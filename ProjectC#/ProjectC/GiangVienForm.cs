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
    public partial class GiangVienForm : Form
    {
        AddGiangVien agv;
        Admin a;
        public GiangVienForm(Admin ad)
        {
            a = ad;
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchT = textBoxSearch.Text;
                dataGridView1.DataSource = GiangVien.getResultSearch(searchT);
                
            }
        }

        private void GiangVienForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GiangVien.GetGiangViens();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (agv==null)
            {
                agv = new AddGiangVien(a);
                agv.Show();
                agv = null;
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GiangVien.GetGiangViens();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            if (agv!=null)
            {
                agv.Close();
                agv = null;
            }
        }
    }
}
