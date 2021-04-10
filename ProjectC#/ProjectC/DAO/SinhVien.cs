using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectC.DAO
{
    public class SinhVien
    {
        private string maSv;
        private string tenSv;
        private bool gioiTinh;
        private DateTime ngaySinh;
        private string maLop;

        public SinhVien(string maSv, string tenSv, bool gioiTinh, DateTime ngaySinh, string maLop)
        {
            this.maSv = maSv;
            this.tenSv = tenSv;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            this.maLop = maLop;
        }

        public string MaSv { get => maSv; set => maSv = value; }
        public string TenSv { get => tenSv; set => tenSv = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }

        public static object getSinhVienByClass(string tenLop)
        {
            List<SinhVien> listSv = new List<SinhVien>();
            try
            {
                string sql = "select * from SinhVien where MaLop like '"+tenLop+"'";
                DataTable dt = connect.getDataFromSQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    SinhVien sv = new SinhVien(dr["MaSv"].ToString(),
                        dr["TenSv"].ToString(),
                        Convert.ToBoolean(dr["GioiTinh"].ToString()),
                        Convert.ToDateTime(dr["NgaySinh"].ToString()),
                        dr["MaLop"].ToString()

                        );
                    listSv.Add(sv);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return listSv;
        }

        public string MaLop { get => maLop; set => maLop = value; }


        public static List<SinhVien> getAllSinhVien()
        {
            List<SinhVien> listSv = new List<SinhVien>();
            try
            {
                string sql = "select * from SinhVien";
                DataTable dt = connect.getDataFromSQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    SinhVien sv = new SinhVien(dr["MaSv"].ToString(),
                        dr["TenSv"].ToString(),
                        Convert.ToBoolean(dr["GioiTinh"].ToString()),
                        Convert.ToDateTime(dr["NgaySinh"].ToString()),
                        dr["MaLop"].ToString()
                        
                        );
                    listSv.Add(sv);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return listSv;
        }

        internal static bool insertSinhVien(SinhVien s)
        {
            string sql = "insert into SinhVien values(@masv,@tensv,@gt,@date,@malop)";
            SqlConnection con = connect.getConnection();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@masv", s.MaSv);
                command.Parameters.AddWithValue("@tensv", s.TenSv);
                command.Parameters.AddWithValue("@gt", s.GioiTinh);
                command.Parameters.AddWithValue("@date", s.NgaySinh);
                command.Parameters.AddWithValue("@malop",s.MaLop);
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

        internal static bool CheckSinhVienExits(string maSv)
        {
            SqlConnection con = connect.getConnection();
            string sql = "select * from SinhVien where MaSv like @masv";
            try
            {
                
                con.Open();
                using (SqlCommand command = new SqlCommand(sql, con))
                {
                    command.Parameters.AddWithValue("@masv", maSv);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                MessageBox.Show("Closing Connection");
                con.Close();
            }
            return false;
        }
    }
    public class SinhVienAndPoint
    {
        private string MaLop;
        private string MaSv;
        private string TenSv;
        private string NgaySinh;
        private string MaMh;
        private int DiemThi;
        private int LanThi;

        public SinhVienAndPoint(string maLop, string maSv, string tenSv, string ngaySinh, string maMh, int diemThi, int lanThi)
        {
            MaLop = maLop;
            MaSv = maSv;
            TenSv = tenSv;
            NgaySinh = ngaySinh;
            MaMh = maMh;
            DiemThi = diemThi;
            LanThi = lanThi;
        }

        public string MaLop1 { get => MaLop; set => MaLop = value; }
        public string MaSv1 { get => MaSv; set => MaSv = value; }
        public string TenSv1 { get => TenSv; set => TenSv = value; }
        public string NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string MaMh1 { get => MaMh; set => MaMh = value; }
        public int DiemThi1 { get => DiemThi; set => DiemThi = value; }
        public int LanThi1 { get => LanThi; set => LanThi = value; }

        public static List<SinhVienAndPoint> getSinhVienAndPointByClassID(string ID)
        {
            List<SinhVienAndPoint> list = new List<SinhVienAndPoint>();
            try
            {
                string sql = "select l.MaLop,sv.MaSv,TenSv,GioiTinh,NgaySinh,d.MaMh, d.DiemThi,d.LanThi from Lop l join SinhVien sv on l.MaLop = sv.MaLop join DiemThi d on d.MaSv = sv.MaSv where l.MaLop = '"+ID+"'";
                DataTable dt = connect.getDataFromSQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    SinhVienAndPoint svap = new SinhVienAndPoint(dr["MaLop"].ToString(),
                        dr["MaSv"].ToString(),
                        dr["TenSv"].ToString(),
                        dr["NgaySinh"].ToString(),
                        dr["MaMh"].ToString(),
                        Convert.ToInt32(dr["DiemThi"].ToString()),
                        Convert.ToInt32(dr["LanThi"].ToString()));
                    list.Add(svap);
                }
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            
        }

        internal static bool removeListPointSinhVien(List<SinhVienAndPoint> list)
        {
            SqlConnection con = connect.getConnection();
            con.Open();
            string sql = "delete from DiemThi where MaSv = @masv and MaMh = @mamh and LanThi=@lthi";
            SqlCommand command = new SqlCommand(sql,con);
            try
            {
                foreach (SinhVienAndPoint sv in list)
                {
                    command.Parameters.AddWithValue("@masv",sv.MaSv1);
                    command.Parameters.AddWithValue("@mamh",sv.MaMh1);
                    command.Parameters.AddWithValue("@lthi",sv.LanThi1);
                    command.ExecuteNonQuery();
                }
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
    }
}
