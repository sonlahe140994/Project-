using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectC.DAO
{
    public class Admin
    {
        private string User;
        private string Password;
        private string MaGv;

        public Admin(string user, string password, string maGv)
        {
            User = user;
            Password = password;
            MaGv = maGv;
        }

        public string User1 { get => User; set => User = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string MaGv1 { get => MaGv; set => MaGv = value; }

        public static int getAdminIdByUser(string user)
        {
            SqlConnection con = connect.getConnection();
            string sql = "select AdminID from [Admin] where UserName =@user";
            try
            {
                
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@user", user);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    int a = Convert.ToInt32(reader["AdminID"].ToString());
                    return a;
                }
            }
            catch (Exception)
            {
                con.Close();
                return 0;
            }
            finally
            {
                con.Close();
            }
            return 0;
        }

        internal static bool checkAdminExits(string user)
        {
            SqlConnection con = connect.getConnection();
            string sql = "select * from [Admin] where UserName =@user";
            try
            {

                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@user", user);
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

        internal static bool insertAdmin(Admin ad)
        {
            string sql = "insert into [Admin] values (@user,@pass,@magv)";
            SqlConnection con = connect.getConnection();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@user", ad.User1);
                command.Parameters.AddWithValue("@pass", ad.Password1);
                command.Parameters.AddWithValue("@magv", ad.MaGv1);
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

        public static int getAdminIdByUserID(string user)
        {
            SqlConnection con = connect.getConnection();
            string sql = "select AdminID from [Admin] where UserName =@user";
            try
            {

                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@user", user);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {

                    int a = Convert.ToInt32(reader["AdminID"].ToString());
                    return a;
                }
            }
            catch (Exception)
            {
                con.Close();
                return -1;
            }
            finally
            {
                con.Close();
            }
            return -1;
        }
        public static Admin GetAdmin(string user,string password)
        {
            SqlConnection con = connect.getConnection();
            Admin a = null;
            string sql = "select * from [Admin] where UserName =@user and [PassWord] = @pass";
            try
            {
                
                con.Open();
                SqlCommand command = new SqlCommand(sql,con);
                command.Parameters.AddWithValue("@user",user);
                command.Parameters.AddWithValue("@pass",password);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    a = new Admin(reader["UserName"].ToString(),reader["PassWord"].ToString(),reader["MaGv"].ToString());
                    con.Close();
                    return a;
                }
            }
            catch (Exception)
            {
                
                return null;
            }
            finally
            {
                con.Close();
            }
            return a;
        }
    }
}
