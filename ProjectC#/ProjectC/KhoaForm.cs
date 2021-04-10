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
    public partial class KhoaForm : Form
    {
        AddKhoaForm akf;
        Admin a;
        public KhoaForm(Admin ad)
        {
            a = ad;
            InitializeComponent();
        }

        private void Khoa_Load(object sender, EventArgs e)
        {
           
            dataGridViewKhoa.DataSource =Khoa.GetKhoas();
        }

       

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string search = textBoxSearch.Text;
                dataGridViewKhoa.DataSource = Khoa.getKhoaBySearch(search);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            akf = new AddKhoaForm(a);
            akf.Show();
            
        }
    }
}
