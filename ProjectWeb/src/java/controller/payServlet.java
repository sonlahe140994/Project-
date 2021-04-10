/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import dal.OrderDAO;
import dal.Order_DetailDAO;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import object.Account;
import object.Cart;
import object.Item;
import object.Order;
import object.Order_Detail;

/**
 *
 * @author admin
 */
public class payServlet extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet payServlet</title>");
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet payServlet at " + request.getContextPath() + "</h1>");
            out.println("</body>");
            out.println("</html>");
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        HttpSession session = request.getSession();
        PrintWriter pw = response.getWriter();
        OrderDAO od = new OrderDAO();
        Order_DetailDAO ordd = new Order_DetailDAO();
        Cart c = null;
        ArrayList<Order> listOr = new ArrayList<>();
        ArrayList<Order_Detail> listOrDt = new ArrayList<>();
        Account a = null;
        
        String FName = request.getParameter("FName");
        String LName = request.getParameter("LName");
        String Phone = request.getParameter("PhoneNumber");
        String Email = request.getParameter("Email");
        String Country = request.getParameter("Country");
        String City = request.getParameter("City");
        String HomeNumber = request.getParameter("HomeNumber");
        if (session.getAttribute("c") != null && session.getAttribute("a") != null) {
            c = (Cart) session.getAttribute("c");
            a = (Account) session.getAttribute("a");
        } else {
            response.sendRedirect("login.jsp");
        }
        if (c != null && a != null) {
            String user = a.getUsername();
            for (Item i : c.getListItem()) {
                Order o = new Order(i.getProduct().getProduct_id(), user, i.getQuantity(), i.getProduct().getProduct_price() * i.getQuantity());
                listOr.add(o);
                Order_Detail ord = new Order_Detail(user, FName, LName, Email, Phone, 50, Country, City, HomeNumber);
                listOrDt.add(ord);
            }
        } else {
            pw.print("Cart null");
        }
        if (!listOr.isEmpty()) {
            if (od.insertListOrder(listOr)) {
                session.removeAttribute("c");
                
            } else {
                pw.print("insert order fail");
            }
        } else {
            pw.print("Fail");
        }
        if (!listOrDt.isEmpty()) {
           if(ordd.insertListOrder(listOrDt)){
               response.sendRedirect("home.jsp");
           }else{
               pw.print("Order Detail fail");
           }
        } else {
            pw.print("fail order detail");
        }
       
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
