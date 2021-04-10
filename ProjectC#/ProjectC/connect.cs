using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ProjectC
{
    class connect
    {
        //public static string connectPath = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        public static string connectPath = @"Data Source=DESKTOP-T36V0QP\LEANHSON;Initial Catalog=ProjectPRN292;Integrated Security=True";
        public static SqlConnection getConnection()
        {
            return new SqlConnection(connectPath);
        }

        public static DataTable getDataFromSQL(string sql)
        {
            SqlCommand command = new SqlCommand(sql, getConnection());
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            return ds.Tables[0];
        }

       

    }
}
