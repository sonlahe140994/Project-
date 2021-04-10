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
import object.Order;
import object.Order_Detail;

/**
 *
 * @author admin
 */
public class Order_DetailDAO extends DBContext {

    public boolean insertListOrder(ArrayList<Order_Detail> list) {
        String query = "insert into Order_Detail\n"
                + "values(?,?,?,?,?,?,?,?,?)";

        try {
            connection.setAutoCommit(false);
            PreparedStatement ps = connection.prepareStatement(query);
            for (Order_Detail o : list) {
                ps.setString(1, o.getUserName());
                ps.setString(2, o.getFirstName());
                ps.setString(3, o.getLastName());
                ps.setString(4, o.getEmail());
                ps.setString(5, o.getPhone());
                ps.setDouble(6, o.getShipPay());
                ps.setString(7, o.getCountry());
                ps.setString(8, o.getCity());
                ps.setString(9, o.getHomenumber());
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

    public static void main(String[] args) {
        Order_DetailDAO odd = new Order_DetailDAO();
        OrderDAO od = new OrderDAO();
        ArrayList<Order_Detail> list = new ArrayList<>();
        ArrayList<Order> listOr = new ArrayList<>();
        list.add(new Order_Detail("sa", "test", "test", "sonlahe140994@fpt.edu.vn", "1", 30, "1", "1", "1"));
        list.add(new Order_Detail("sa", "test", "test", "sonlahe140994@fpt.edu.vn", "1", 30, "1", "1", "1"));
        list.add(new Order_Detail("sa", "test", "test", "sonlahe140994@fpt.edu.vn", "1", 30, "1", "1", "1"));

        listOr.add(new Order("DH1", "sa", 3, 40));
        listOr.add(new Order("DH1", "sa", 3, 40));
        listOr.add(new Order("DH1", "sa", 3, 40));

        if (od.insertListOrder(listOr)) {
            System.out.println("win");
            if(odd.insertListOrder(list)){
                System.out.println("win");
            }
        }

    }
}
