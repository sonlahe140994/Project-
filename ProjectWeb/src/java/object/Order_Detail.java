/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package object;

/**
 *
 * @author admin
 */
public class Order_Detail {

    private String userName;
    private String FirstName;
    private String LastName;
    private String Email;
    private String Phone;
    private double shipPay;
    private String country;
    private String city;
    private String homenumber;

    public Order_Detail(String userName, String FirstName, String LastName, String Email, String Phone, double shipPay, String country, String city, String homenumber) {
        this.userName = userName;
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Email = Email;
        this.Phone = Phone;
        this.shipPay = shipPay;
        this.country = country;
        this.city = city;
        this.homenumber = homenumber;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getFirstName() {
        return FirstName;
    }

    public void setFirstName(String FirstName) {
        this.FirstName = FirstName;
    }

    public String getLastName() {
        return LastName;
    }

    public void setLastName(String LastName) {
        this.LastName = LastName;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String Email) {
        this.Email = Email;
    }

    public String getPhone() {
        return Phone;
    }

    public void setPhone(String Phone) {
        this.Phone = Phone;
    }

    public double getShipPay() {
        return shipPay;
    }

    public void setShipPay(double shipPay) {
        this.shipPay = shipPay;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public String getCity() {
        return city;
    }

    public void setCity(String city) {
        this.city = city;
    }

    public String getHomenumber() {
        return homenumber;
    }

    public void setHomenumber(String homenumber) {
        this.homenumber = homenumber;
    }

}
