using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectC.DAO
{
    public class HistoryAction
    {
        private int HisId;
        private int AdminID;
        private string Action;
        private string Time;
        private string Note;

        public HistoryAction(int hisId, int adminID, string action, string time, string note)
        {
            HisId = hisId;
            AdminID = adminID;
            Action = action;
            Time = time;
            Note = note;
        }

        public int HisId1 { get => HisId; set => HisId = value; }
        public int AdminID1 { get => AdminID; set => AdminID = value; }
        public string Action1 { get => Action; set => Action = value; }
        public string Time1 { get => Time; set => Time = value; }
        public string Note1 { get => Note; set => Note = value; }

        public static bool insertHistoryAction(int AdminID,string Action,DateTime time,string Notes)
        {
            string sql = "insert into HistoryAction values(@adminID,@action,@date,@note)";
            SqlConnection con = connect.getConnection();
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(sql, con);
                command.Parameters.AddWithValue("@adminID", AdminID);
                command.Parameters.AddWithValue("@action", Action);
                command.Parameters.AddWithValue("@date", time);
                command.Parameters.AddWithValue("@note", Notes);
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
