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
    public partial class DiemThiForm : Form
    {
        UpdatePoint p;
        Admin a;
        public DiemThiForm(Admin ad)
        {
            a = ad;
            InitializeComponent();
        }

        private void comboBoxClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void DiemThi_Load(object sender, EventArgs e)
        {
            loadForm();            
            
        }

        private void loadForm()
        {
            comboBoxClass.DisplayMember = "MaLop";
            comboBoxClass.ValueMember = "MaLop";
            comboBoxClass.DataSource = Lop.getAllClass();
            comboBoxClass.SelectedIndex = 0;



            dataGridViewClass.AutoGenerateColumns = false;
            DataGridViewCheckBoxColumn checkBoxColum = new DataGridViewCheckBoxColumn();
            checkBoxColum.Name = "Select";
            checkBoxColum.HeaderText="Choose";
            dataGridViewClass.Columns.Add(checkBoxColum);

            DataGridViewTextBoxColumn MaLop = new DataGridViewTextBoxColumn();
            MaLop.Name = "malop";
            MaLop.HeaderText = "Ma Lop";
            dataGridViewClass.Columns.Add(MaLop);

            DataGridViewTextBoxColumn MaSv = new DataGridViewTextBoxColumn();
            MaSv.Name = "masv";
            MaSv.HeaderText = "Ma Sinh Vien";
           dataGridViewClass.Columns.Add(MaSv);

            DataGridViewTextBoxColumn TenSv = new DataGridViewTextBoxColumn();
            TenSv.Name = "tensv";
            TenSv.HeaderText = "Ten Sinh Vien";
            
            dataGridViewClass.Columns.Add(TenSv);

            DataGridViewTextBoxColumn NgaySinh = new DataGridViewTextBoxColumn();
            NgaySinh.Name = "ngaysinh";
            NgaySinh.HeaderText = "Ngay Sinh";
            dataGridViewClass.Columns.Add(NgaySinh);

            DataGridViewTextBoxColumn MaMh = new DataGridViewTextBoxColumn();
            MaMh.Name = "mamh";
            MaMh.HeaderText = "Ma Mon Hoc";
            dataGridViewClass.Columns.Add(MaMh);

            DataGridViewTextBoxColumn DiemThi = new DataGridViewTextBoxColumn();
            DiemThi.Name = "diem";
            DiemThi.HeaderText = "Diem Thi";
            dataGridViewClass.Columns.Add(DiemThi);

            DataGridViewTextBoxColumn LanThi = new DataGridViewTextBoxColumn();
            LanThi.Name = "lanthi";
            LanThi.HeaderText = "Lan Thi";
            dataGridViewClass.Columns.Add(LanThi);

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "updateButton";
            buttonColumn.HeaderText = "Action";
            buttonColumn.Text = "Update";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridViewClass.Columns.Add(buttonColumn);
            


        }

        

        private void RefreshData(DataGridView dataGridViewClass)
        {
                string classID = (string)comboBoxClass.SelectedValue.ToString();
                dataGridViewClass.DataSource = SinhVienAndPoint.getSinhVienAndPointByClassID(classID);
                dataGridViewClass.Columns[1].DataPropertyName = "MaLop1";
                dataGridViewClass.Columns[2].DataPropertyName = "MaSv1";
                dataGridViewClass.Columns[3].DataPropertyName = "TenSv1";
                dataGridViewClass.Columns[4].DataPropertyName = "NgaySinh1";
                dataGridViewClass.Columns[5].DataPropertyName = "MaMh1";
                dataGridViewClass.Columns[6].DataPropertyName = "DiemThi1";
                dataGridViewClass.Columns[7].DataPropertyName = "LanThi1";
        }

        private void comboBoxClass_SelectedValueChanged(object sender, EventArgs e)
        {
            

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string Notes = "Remove DiemThi with MaSv: ";
            int adminID = Admin.getAdminIdByUser(a.User1);
            if (adminID == 0)
            {
                MessageBox.Show("Can't not find out " + a.User1);
                return;
            }
            int count = 0;
            List<SinhVienAndPoint> list = new List<SinhVienAndPoint>();
            for (int i = 0; i < dataGridViewClass.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dataGridViewClass.Rows[i].Cells["Select"].Value) == true)
                {
                    count++;
                    string MaSv = (String)dataGridViewClass[2, i].Value;
                    string MaMh = dataGridViewClass.Rows[i].Cells["mamh"].Value.ToString();
                    int LanThi = Convert.ToInt32(dataGridViewClass.Rows[i].Cells["lanthi"].Value.ToString());
                    SinhVienAndPoint svap = new SinhVienAndPoint(null, MaSv, null, null, MaMh, 0, LanThi);
                    list.Add(svap);
                    Notes += MaSv + " \nMaSv";
                }
            }

            foreach (SinhVienAndPoint sv in list)
            {
                MessageBox.Show("List Sinh vien " + sv.MaSv1 + " " + sv.MaMh1);
            }

            if (count == 0)
            {
                MessageBox.Show("You must choose at least one");
            }
            if (SinhVienAndPoint.removeListPointSinhVien(list))
            {
                MessageBox.Show("Remove success");
            }
            else
            {
                return;
            }
            DateTime d = DateTime.Now;
            if (HistoryAction.insertHistoryAction(adminID, "Delete", d, Notes))
            {
                MessageBox.Show("Add History Success");
            }


        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            
            RefreshData(dataGridViewClass);
        }

        private void dataGridViewClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewClass.Columns[e.ColumnIndex]==dataGridViewClass.Columns["updateButton"])
            {
                string maSv = (string)dataGridViewClass.Rows[e.RowIndex].Cells["masv"].Value;
                string maMh = (string)dataGridViewClass.Rows[e.RowIndex].Cells["mamh"].Value;
                int lanThi = Convert.ToInt32(dataGridViewClass.Rows[e.RowIndex].Cells["lanthi"].Value);
                int diem = Convert.ToInt32(dataGridViewClass.Rows[e.RowIndex].Cells["diem"].Value);
                SinhVienAndPoint sv = new SinhVienAndPoint(null,maSv,null,null,maMh,diem,lanThi);
                if (p==null)
                {
                    p = new UpdatePoint(sv, a);
                    p.Show();
                    p = null;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
