using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectC.DAO
{
    public class MonHoc
    {
        private string MaMh;
        private string TenMh;
        private int Slot;

        public MonHoc(string maMh, string tenMh, int slot)
        {
            MaMh = maMh;
            TenMh = tenMh;
            Slot = slot;
        }

        public string MaMh1 { get => MaMh; set => MaMh = value; }
        public string TenMh1 { get => TenMh; set => TenMh = value; }
        public int Slot1 { get => Slot; set => Slot = value; }

        public static List<MonHoc> GetMonHocs()
        {
            List<MonHoc> list = new List<MonHoc>();
            string sql = "select * from MonHoc";
            try
            {
                DataTable dt = connect.getDataFromSQL(sql);
                foreach (DataRow dr in dt.Rows)
                {
                    MonHoc mh = new MonHoc(
                        dr["MaMh"].ToString(),
                        dr["TenMh"].ToString(),
                        Convert.ToInt32(dr["Slot"].ToString())
                        );
                    list.Add(mh);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return list;
        }

        public static bool insertMonHoc(MonHoc m)
        {
            string sql = "insert into MonHoc values(@mamh,@tenmh,@slot)";
            SqlConnection con = connect.getConnection();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@mamh", m.MaMh1);
                command.Parameters.AddWithValue("@tenmh", m.TenMh1);
                command.Parameters.AddWithValue("@slot", m.Slot1);
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
