using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectC.DAO
{
    public class Khoa
    {
        private string MaKhoa;
        private string TenKhoa;

        public Khoa(string maKhoa, string tenKhoa)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
        }

        public string MaKhoa1 { get => MaKhoa; set => MaKhoa = value; }
        public string TenKhoa1 { get => TenKhoa; set => TenKhoa = value; }
        public static List<Khoa> GetKhoas()
        {
            List<Khoa> list = new List<Khoa>();
            string sql = "select * from Khoa";
            try
            {
                DataTable dt = connect.getDataFromSQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    Khoa k = new Khoa(dr["MaKhoa"].ToString(),
                        dr["TenKhoa"].ToString());
                    list.Add(k);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return list;
        }

        internal static bool insertKhoa(Khoa k)
        {
            string sql = "insert into Khoa values(@makh,@tenkhoa)";
            SqlConnection con = connect.getConnection();
            try
            {
                
                con.Open();
                SqlCommand command = new SqlCommand(sql,con);
                command.Parameters.AddWithValue("@makh",k.MaKhoa1);
                command.Parameters.AddWithValue("@tenkhoa", k.TenKhoa1);
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

        internal static List<Khoa> getKhoaBySearch(string search)
        {
            List<Khoa> list = new List<Khoa>();
            string sql = "select * from Khoa where MaKhoa like '%"+search+"%' or TenKhoa like '"+search+"'";
            try
            {
                DataTable dt = connect.getDataFromSQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    Khoa k = new Khoa(dr["MaKhoa"].ToString(),
                        dr["TenKhoa"].ToString());
                    list.Add(k);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return list;
        }
    }
}
