using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectC.DAO
{
    public class DiemThi
    {
        private string MaSv;
        private string MaMh;
        private int LanThi;
        private int Diem;

        public DiemThi(string maSv, string maMh, int lanThi, int diem)
        {
            MaSv = maSv;
            MaMh = maMh;
            LanThi = lanThi;
            Diem = diem;
        }

        public string MaSv1 { get => MaSv; set => MaSv = value; }
        public string MaMh1 { get => MaMh; set => MaMh = value; }
        public int LanThi1 { get => LanThi; set => LanThi = value; }
        public int Diem1 { get => Diem; set => Diem = value; }
        public static bool updateDiem(SinhVienAndPoint sv,int lanThiMoi,int DiemMoi)
        {
            string sql = "update DiemThi set LanThi = @lanthi, DiemThi = @diem where MaSv = @masv and MaMh=@mamh and LanThi = @lanThiCu and DiemThi = @DiemCu ";
            //string sql = "update DiemThi set LanThi = 1, DiemThi =3 where MaSv = 'SE123465' and MaMh='LAB221' and LanThi = 1 and DiemThi = 10";
            SqlConnection con = connect.getConnection();
            con.Open();
            try
            {
                SqlCommand command = new SqlCommand(sql,con);
                command.Parameters.AddWithValue("@lanthi", lanThiMoi );
                command.Parameters.AddWithValue("@diem", DiemMoi);
                command.Parameters.AddWithValue("@masv", sv.MaSv1);
                command.Parameters.AddWithValue("@mamh", sv.MaMh1);
                command.Parameters.AddWithValue("@lanThiCu", sv.LanThi1);
                command.Parameters.AddWithValue("@DiemCu", sv.DiemThi1);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public static bool insertDiem(DiemThi d)
        {
            string sql = "insert into DiemThi values (@masv,@mamh,@lanthi,@diemthi)";
            SqlConnection con = connect.getConnection();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@masv", d.MaSv1);
                command.Parameters.AddWithValue("@mamh", d.MaMh1);
                command.Parameters.AddWithValue("@lanthi", d.LanThi1);
                command.Parameters.AddWithValue("@diemthi",d.Diem1);
                command.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                con.Close();
                return false;
            }
            finally
            {
                con.Close();
            }
            
        }
    }
}
