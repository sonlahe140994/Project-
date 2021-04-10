/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dal;

import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import object.Account;
import object.Order;

/**
 *
 * @author admin
 */
public class OrderDAO extends DBContext {

    public boolean insertListOrder(ArrayList<Order> list) {
        String query = "insert into [Order] values (?,?,?,?)";
        try {
            connection.setAutoCommit(false);
            PreparedStatement ps = connection.prepareStatement(query);
            for (Order o : list) {
                ps.setString(1, o.getProduct_id());
                ps.setString(2, o.getUser());
                ps.setInt(3, o.getQuantity());
                ps.setDouble(4, o.getTotalPrice());
                ps.addBatch();
            }
            ps.executeBatch();
            ps.clearBatch();
            connection.commit();
            connection.close();
            return true;
        } catch (SQLException e) {
            System.out.println(e.getMessage());
            try {
                connection.rollback();
            } catch (SQLException ex) {
                Logger.getLogger(OrderDAO.class.getName()).log(Level.SEVERE, null, ex);
            }
            return false;
        }
    }

    public void insertListOrder(Order o) {
        String query = "insert into [Order] values (?,?,?,?)";
        try {
            PreparedStatement ps = connection.prepareStatement(query);
            ps.setString(1, o.getProduct_id());
            ps.setString(2, o.getUser());
            ps.setInt(3, o.getQuantity());
            ps.setDouble(4, o.getTotalPrice());
            ps.execute();
            connection.close();
        } catch (SQLException e) {

        }
    }

    public static void main(String[] args) {
        OrderDAO od = new OrderDAO();
        ArrayList<Order> listOD = new ArrayList<>();
        Order o = new Order("DH3", "sa", 4, 4.5);
        listOD.add(o);
        listOD.add(o);
        listOD.add(o);
        listOD.add(o);
        listOD.add(o);
        od.insertListOrder(listOD);

    }
}
