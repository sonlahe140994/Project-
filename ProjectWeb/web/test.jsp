<%-- 
    Document   : test
    Created on : Mar 22, 2021, 3:17:20 PM
    Author     : admin
--%>

<%@page import="object.Account"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <div class="product_count d-inline-block">
            <span class="product_count_item inumber-decrement"> <i class="ti-minus"></i></span>
            <input class="product_count_item input-number" type="text" value="1" min="0" max="10">
            <span class="product_count_item number-increment"> <i class="ti-plus"></i></span>
        </div>
    </body>
</html>
