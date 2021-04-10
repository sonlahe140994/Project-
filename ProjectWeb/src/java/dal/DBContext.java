package dal;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DBContext {

    protected Connection connection;

    public DBContext() {
        try {
            // Edit URL , username, password to authenticate with your MS SQL Server
            String url = "jdbc:sqlserver://DESKTOP-T36V0QP\\LEANHSON:1433;databaseName=ProjectWeb";
            String username = "sa";
            String password = "12345678";
            Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
            connection = DriverManager.getConnection(url, username, password);
        } catch (ClassNotFoundException | SQLException ex) {
            System.out.println(ex);
        }
        
    }
    public static void main(String[] args) throws Exception {
        DBContext db = new DBContext();
        if (db.connection != null) {
            System.out.println("win");
        }else{
            System.out.println("Lose");
        }
    }
}
