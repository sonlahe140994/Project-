using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectC.DAO
{
    public class Lop
    {
        private string maLop;
        private string tenLop;
        private string maKhoa;

        private string MaGv;

        public string MaLop { get => maLop; set => maLop = value; }
        public string TenLop { get => tenLop; set => tenLop = value; }
        public string MaKhoa { get => maKhoa; set => maKhoa = value; }
        public string MaGv1 { get => MaGv; set => MaGv = value; }

        public Lop(string maLop, string tenLop, string maKhoa)
        {
            MaLop = maLop;
            TenLop = tenLop;
            MaKhoa = maKhoa;
        }

        public Lop(string maLop, string tenLop, string maKhoa, string maGv)
        {
            this.maLop = maLop;
            this.tenLop = tenLop;
            this.maKhoa = maKhoa;
            MaGv1 = maGv;
        }

        public static List<Lop> getAllClass()
        {
            
            List<Lop> listLop = new List<Lop>();
            try
            {
                string sql = "select * from Lop";
                DataTable dt = connect.getDataFromSQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    Lop l = new Lop(dr["MaLop"].ToString(),
                        dr["TenLop"].ToString(),
                        dr["MaKhoa"].ToString());
                    listLop.Add(l);
                }
            }
            catch (Exception e)
            {
                return null;
            }
            return listLop;
        }

        internal static bool insertLop(Lop l)
        {
            string sql = "insert into Lop values (@malop,@tenlop,@makhoa,@magv)";
            SqlConnection con = connect.getConnection();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@malop", l.MaLop);
                command.Parameters.AddWithValue("@tenlop", l.TenLop);
                command.Parameters.AddWithValue("@makhoa", l.MaKhoa);
                command.Parameters.AddWithValue("@magv", l.MaGv1);
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

        internal static bool checkLopExits(Lop l)
        {

            SqlConnection con = connect.getConnection();
            string sql = "select * from Lop where MaLop like @malop and TenLop like @tenlop and MaKhoa like @makhoa and MaGv like @magv";
            try
            {

                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@malop", l.MaLop);
                command.Parameters.AddWithValue("@tenlop",l.TenLop);
                command.Parameters.AddWithValue("@makhoa",l.MaKhoa);
                command.Parameters.AddWithValue("@magv",l.MaGv1);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
            finally
            {
                con.Close();
            }
            return false;
        }
    }
}
