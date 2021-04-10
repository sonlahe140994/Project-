using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectC.DAO
{
    public class GiangVien
    {
        private string MaGv;
        private string TenGv;
        private string ChuyenNganh;
        private string MaKhoa;

        public GiangVien(string maGv, string tenGv, string chuyenNganh, string maKhoa)
        {
            MaGv = maGv;
            TenGv = tenGv;
            ChuyenNganh = chuyenNganh;
            MaKhoa = maKhoa;
        }

        public string MaGv1 { get => MaGv; set => MaGv = value; }
        public string TenGv1 { get => TenGv; set => TenGv = value; }
        public string ChuyenNganh1 { get => ChuyenNganh; set => ChuyenNganh = value; }
        public string MaKhoa1 { get => MaKhoa; set => MaKhoa = value; }

        public static List<GiangVien> getResultSearch(string searchT)
        {
            List<GiangVien> list = new List<GiangVien>();
            string sql = "select * from GiangVien where TenGv like '%"+searchT+"%' or MaGv like '%"+searchT+"%' ";
            try
            {
                DataTable dt = connect.getDataFromSQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    GiangVien gv = new GiangVien(
                        dr["MaGv"].ToString(),
                        dr["TenGv"].ToString(),
                        dr["ChuyenNganh"].ToString(),
                        dr["MaKhoa"].ToString()
                        );
                    list.Add(gv);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return list;
        }

        public static bool insertGiangVien(GiangVien gv)
        {
            string sql = "insert into GiangVien values (@magv,@tengv,@cn,@makhoa)";
            SqlConnection con = connect.getConnection();
            try
            {

                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@magv", gv.MaGv1 );
                command.Parameters.AddWithValue("@tengv",gv.TenGv1);
                command.Parameters.AddWithValue("@cn",gv.ChuyenNganh1);
                command.Parameters.AddWithValue("@makhoa",gv.MaKhoa1);
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

        public static List<GiangVien> GetGiangViens()
        {
            List<GiangVien> list = new List<GiangVien>();
            string sql = "select * from GiangVien";
            try
            {
                DataTable dt = connect.getDataFromSQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    GiangVien gv = new GiangVien(
                        dr["MaGv"].ToString(),
                        dr["TenGv"].ToString(),
                        dr["ChuyenNganh"].ToString(),
                        dr["MaKhoa"].ToString()
                        );
                    list.Add(gv);
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
