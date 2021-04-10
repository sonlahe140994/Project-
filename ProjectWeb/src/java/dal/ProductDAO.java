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
import java.util.ArrayList;
import object.Product;

/**
 *
 * @author admin
 */
public class ProductDAO extends DBContext {

    public ArrayList<Product> getAllProduct() {
        ArrayList<Product> listProduct = new ArrayList<>();
        try {
            String query = "select * from Product";
            PreparedStatement ps = connection.prepareStatement(query);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                Product p = new Product(rs.getString(1), rs.getString(2), rs.getDouble(3), rs.getString(4));
                listProduct.add(p);
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return listProduct;
    }

    public ArrayList<Product> getListByPage(ArrayList<Product> list,
            int start, int end) {
        ArrayList<Product> arr = new ArrayList<>();
        for (int i = start; i < end; i++) {
            arr.add(list.get(i));
        }
        return arr;
    }

    public Product getProductByID(String id) {
        Product p = null;
        try {
            String query = "select * from Product where product_id =?";
            PreparedStatement ps = connection.prepareStatement(query);
            ps.setString(1, id);
            ResultSet rs = ps.executeQuery();
            if (rs.next()) {
                p = new Product(rs.getString(1), rs.getString(2), rs.getDouble(3), rs.getString(4));
                return p;
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return p;
    }

    public ArrayList<Product> searchProduct(String s) {
        String sql = "select * from Product where product_id like '%" + s + "%' or product_name like '%" + s + "%'";
        ArrayList<Product> listProduct = new ArrayList<>();
        try {
            Statement st = connection.createStatement();
            ResultSet rs = st.executeQuery(sql);
            while (rs.next()) {
                Product p = new Product(rs.getString(1), rs.getString(2), rs.getDouble(3), rs.getString(4));
                listProduct.add(p);
            }
        } catch (SQLException e) {
            System.out.println(e.getMessage());
        }
        return listProduct;
    }

    public static void main(String[] args) {
        ProductDAO pd = new ProductDAO();
        ArrayList<Product> p = pd.searchProduct("DH");
        for (Product i : p) {
            System.out.println(i.getProduct_id());
            System.out.println(i.getProduct_name());
            System.out.println(i.getProduct_images());
        }
    }
}
