/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dal;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import object.Account;

/**
 *
 * @author admin
 */
public class AccountDAO extends DBContext {

    public Account getAccount(String username, String password) {
        try {
            String query = "select * from Account where UserName like ? and [PassWord] = ?";
            PreparedStatement ps = connection.prepareStatement(query);
            ps.setString(1, "%" + username + "%");
            ps.setString(2, password);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                String userN = rs.getString("UserName");
                String passW = rs.getString("PassWord");
                String email = rs.getString("Email");
                return new Account(userN, passW, email);
            }
        } catch (SQLException e) {
            System.out.println("Account " + e.getMessage());
        }
        return null;
    }

    public void insertAccount(Account a) {
        String query = "use ProjectWeb\n"
                + "\n"
                + "insert into Account\n"
                + "values(?,?,?)";
        try {
            PreparedStatement ps = connection.prepareStatement(query);
            ps.setString(1, a.getUsername());
            ps.setString(2, a.getPassword());
            ps.setString(3, a.getEmail());
            ps.execute();
        } catch (SQLException e) {
        }
    }

    public static void main(String[] args) {
        AccountDAO AD = new AccountDAO();
        String em = "sonlahe140994@fpt.edu.vn";
        if(AD.checkEmail(em)){
            System.out.println("win");
        }else{
            System.out.println("Lose");
        }
    }

    public Account checkUserName(String user) {
        try {
            String query = "select UserName from Account where UserName like ?";
            PreparedStatement ps = connection.prepareStatement(query);
            ps.setString(1, "%" + user + "%");
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                String userN = rs.getString("UserName");
                return new Account(userN, null, null);
            }
        } catch (SQLException e) {
            System.out.println("Account " + e.getMessage());
        }
        return null;
    }

    public boolean checkEmail(String email) {
        try {
            String query = "select Email from Account where Email like ?";
            PreparedStatement ps = connection.prepareStatement(query);
            ps.setString(1, "%" + email + "%");
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                return true;
            }
        } catch (SQLException e) {
            System.out.println("Account " + e.getMessage());
        }
        return false;
    }

}
