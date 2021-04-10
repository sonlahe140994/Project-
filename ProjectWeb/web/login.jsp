<%-- 
    Document   : login
    Created on : Mar 15, 2021, 9:29:50 PM
    Author     : admin
--%>

<%@page import="object.Account"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!doctype html>
<html lang="zxx">
    <head>
        <meta charset="utf-8">
        <meta http-equiv="x-ua-compatible" content="ie=edge">
        <title>Watch shop | eCommers</title>
        <meta name="description" content="">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="manifest" href="site.webmanifest">
        <link rel="shortcut icon" type="image/x-icon" href="assets/img/favicon.ico">

        <!-- CSS here -->
        <link rel="stylesheet" href="assets/css/bootstrap.min.css">
        <link rel="stylesheet" href="assets/css/owl.carousel.min.css">
        <link rel="stylesheet" href="assets/css/flaticon.css">
        <link rel="stylesheet" href="assets/css/slicknav.css">
        <link rel="stylesheet" href="assets/css/animate.min.css">
        <link rel="stylesheet" href="assets/css/magnific-popup.css">
        <link rel="stylesheet" href="assets/css/fontawesome-all.min.css">
        <link rel="stylesheet" href="assets/css/themify-icons.css">
        <link rel="stylesheet" href="assets/css/slick.css">
        <link rel="stylesheet" href="assets/css/nice-select.css">
        <link rel="stylesheet" href="assets/css/style.css">
    </head>
    <body>
        <header>
            <!-- Header Start -->
            <div class="header-area">
                <div class="main-header header-sticky">
                    <div class="container-fluid">
                        <div class="menu-wrapper">
                            <!-- Logo -->
                            <div class="logo">
                                <a href="home.jsp"><img src="assets/img/logo/logo.png" alt=""></a>
                            </div>
                            <!-- Main-menu -->
                            <div class="main-menu d-none d-lg-block">
                                <nav>                                                
                                    <ul id="navigation">
                                        <li><a href="home.jsp">Home</a></li>
                                        <li class="hot"><a href="shopServlet">Shoping</a></li> 
                                        <li><a href="login.jsp">Login</a></li>
                                        <li><a href="contact.html">Contact</a></li>
                                    </ul>
                                </nav>
                            </div>
                            <!-- Header Right -->
                            <div class="header-right">
                                <ul>
                                    <li>
                                        <div class="nav-search search-switch">
                                            <span class="flaticon-search"></span>
                                        </div>
                                    </li>
                                    <%
                                        if (session.isNew()) {
                                    %>
                                    <li><a href="login.jsp"><span class="flaticon-user"></span></a></li>
                                            <%
                                            } else {
                                                if (session.getAttribute("a") != null) {
                                                    Account a = (Account) session.getAttribute("a");

                                            %>
                                    <li><a href="login.jsp"><span class="flaticon-user"><%=a.getUsername()%></span></a></li>

                                    <%} else {
                                    %>
                                    <li><a href="login.jsp"><span class="flaticon-user"></span></a></li>
                                            <%                                            }
                                                }
                                            %>
                                    <li><a href="cart.html"><span class="flaticon-shopping-cart"></span></a> </li>
                                </ul>
                            </div>
                        </div>
                        <!-- Mobile Menu -->
                        <div class="col-12">
                            <div class="mobile_menu d-block d-lg-none"></div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Header End -->
        </header>
        <main>
            <!-- Hero Area Start-->
            <div class="slider-area ">
                <div class="single-slider slider-height2 d-flex align-items-center">
                    <div class="container">
                        <div class="row">
                            <div class="col-xl-12">
                                <div class="hero-cap text-center">
                                    <h2>Login</h2>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Hero Area End-->
            <!--================login_part Area =================-->
            <%
                if (session.getAttribute("a") == null) {
                    Account a = (Account) session.getAttribute("a");
            %>
            <section class="login_part section_padding ">
                <div class="container">
                    <div class="row align-items-center">
                        <div class="col-lg-6 col-md-6">
                            <div class="login_part_text text-center">
                                <div class="login_part_text_iner">
                                    <h2>New to our Shop?</h2>
                                    <p>There are advances being made in science and technology
                                        everyday, and a good example of this is the</p>
                                    <a href="signIn.jsp" class="btn_3">Create an Account</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6">
                            <div class="login_part_form">
                                <div class="login_part_form_iner">
                                    <h3>Welcome Back ! <br>
                                        Please Sign in now</h3>
                                    <form class="row contact_form" action="LoginServlet" method="post" novalidate="novalidate">
                                        <div class="col-md-12 form-group p_star">
                                            <input type="text" class="form-control" id="name" name="name" value=""
                                                   placeholder="Username">
                                        </div>
                                        <div class="col-md-12 form-group p_star">
                                            <input type="password" class="form-control" id="password" name="password" value=""
                                                   placeholder="Password">
                                        </div>
                                        <div class="col-md-12 form-group">
                                            <div class="creat_account d-flex align-items-center">
                                                <%                                                    if (request.getAttribute("mess") != null) {
                                                        String mess = (String) request.getAttribute("mess");

                                                %>
                                                <label for="f-option" style="color: #ee3f0e"><%=mess%></label>
                                                <%
                                                    }
                                                %>
                                            </div>
                                            <button type="submit" value="submit" class="btn_3">
                                                log in
                                            </button>
                                            <a class="lost_pass" href="forgotPassWord.jsp">forget password?</a>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <%
            } else {

            %>
            <div class="container">
                <div class="row">
                    <div class="col-md-3 ">
                        <div class="list-group ">
                            <a href="#" class="list-group-item list-group-item-action active">Profile</a>

                        </div> 
                    </div>
                    <div class="col-md-9">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h4>Your Profile</h4>
                                        <hr>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <form action="logOutServlet" method="post">
                                            <div class="form-group row">
                                                <label for="username" class="col-4 col-form-label">User Name*</label> 
                                                <div class="col-8">
                                                    <input id="username" name="username" placeholder="Username" class="form-control here" required="required" type="text" disabled="true" />
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="name" class="col-4 col-form-label">First Name</label> 
                                                <div class="col-8">
                                                    <input id="name" name="name" placeholder="First Name" class="form-control here" type="text" disabled="true">
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="lastname" class="col-4 col-form-label">Last Name</label> 
                                                <div class="col-8">
                                                    <input id="lastname" name="lastname" placeholder="Last Name" class="form-control here" type="text" disabled="true">
                                                </div>
                                            </div>
                                            <div class="form-group row">
                                                <label for="text" class="col-4 col-form-label">Nick Name*</label> 
                                                <div class="col-8">
                                                    <input id="text" name="text" placeholder="Nick Name" class="form-control here" required="required" type="text" disabled="true">
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label for="email" class="col-4 col-form-label">Email*</label> 
                                                <div class="col-8">
                                                    <input id="email" name="email" placeholder="Email" class="form-control here" required="required" type="text" disabled="true">
                                                </div>
                                            </div>

                                            <div class="form-group row">
                                                <label for="newpass" class="col-4 col-form-label">Phone</label> 
                                                <div class="col-8">
                                                    <input id="newpass" name="newpass" placeholder="Phone" class="form-control here" type="text" disabled="true">
                                                </div>
                                            </div> 
                                            <div class="form-group row">
                                                <label for="newpass" class="col-4 col-form-label">Address</label> 
                                                <div class="col-8">
                                                    <input id="newpass" name="newpass" placeholder="Address" class="form-control here" type="text" disabled="true">
                                                </div>
                                            </div> 
                                            <div class="form-group row">
                                                <div class="offset-4 col-8">
                                                    <button  name="submit" type="submit" class="btn btn-primary">Log Out</button>
                                                </div>
                                            </div>
                                        </form>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%}%>
            <!--================login_part end =================-->
        </main>
        <footer>
            <!-- Footer Start-->
            <div class="footer-area footer-padding">
                <div class="container">
                    <div class="row d-flex justify-content-between">
                        <div class="col-xl-3 col-lg-3 col-md-5 col-sm-6">
                            <div class="single-footer-caption mb-50">
                                <div class="single-footer-caption mb-30">
                                    <!-- logo -->
                                    <div class="footer-logo">
                                        <a href="index.html"><img src="assets/img/logo/logo2_footer.png" alt=""></a>
                                    </div>
                                    <div class="footer-tittle">
                                        <div class="footer-pera">
                                            <p>Asorem ipsum adipolor sdit amet, consectetur adipisicing elitcf sed do eiusmod tem.</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-2 col-lg-3 col-md-3 col-sm-5">
                            <div class="single-footer-caption mb-50">
                                <div class="footer-tittle">
                                    <h4>Quick Links</h4>
                                    <ul>
                                        <li><a href="#">About</a></li>
                                        <li><a href="#"> Offers & Discounts</a></li>
                                        <li><a href="#"> Get Coupon</a></li>
                                        <li><a href="#">  Contact Us</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-3 col-lg-3 col-md-4 col-sm-7">
                            <div class="single-footer-caption mb-50">
                                <div class="footer-tittle">
                                    <h4>New Products</h4>
                                    <ul>
                                        <li><a href="#">Woman Cloth</a></li>
                                        <li><a href="#">Fashion Accessories</a></li>
                                        <li><a href="#"> Man Accessories</a></li>
                                        <li><a href="#"> Rubber made Toys</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-3 col-lg-3 col-md-5 col-sm-7">
                            <div class="single-footer-caption mb-50">
                                <div class="footer-tittle">
                                    <h4>Support</h4>
                                    <ul>
                                        <li><a href="#">Frequently Asked Questions</a></li>
                                        <li><a href="#">Terms & Conditions</a></li>
                                        <li><a href="#">Privacy Policy</a></li>
                                        <li><a href="#">Report a Payment Issue</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Footer bottom -->
                    <div class="row align-items-center">
                        <div class="col-xl-7 col-lg-8 col-md-7">
                            <div class="footer-copy-right">
                                <p><!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. -->
                                    Copyright &copy;<script>document.write(new Date().getFullYear());</script> All rights reserved | This template is made with <i class="fa fa-heart" aria-hidden="true"></i> by <a href="https://colorlib.com" target="_blank">Colorlib</a>
                                    <!-- Link back to Colorlib can't be removed. Template is licensed under CC BY 3.0. --></p>               
                            </div>
                        </div>
                        <div class="col-xl-5 col-lg-4 col-md-5">
                            <div class="footer-copy-right f-right">
                                <!-- social -->
                                <div class="footer-social">
                                    <a href="#"><i class="fab fa-twitter"></i></a>
                                    <a href="https://www.facebook.com/sai4ull"><i class="fab fa-facebook-f"></i></a>
                                    <a href="#"><i class="fab fa-behance"></i></a>
                                    <a href="#"><i class="fas fa-globe"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Footer End-->
        </footer>
        <!--? Search model Begin -->
        <div class="search-model-box">
            <div class="h-100 d-flex align-items-center justify-content-center">
                <div class="search-close-btn">+</div>
                <form class="search-model-form">
                    <input type="text" id="search-input" placeholder="Searching key.....">
                </form>
            </div>
        </div>
        <!-- Search model end -->

        <!-- JS here -->

        <script src="./assets/js/vendor/modernizr-3.5.0.min.js"></script>
        <!-- Jquery, Popper, Bootstrap -->
        <script src="./assets/js/vendor/jquery-1.12.4.min.js"></script>
        <script src="./assets/js/popper.min.js"></script>
        <script src="./assets/js/bootstrap.min.js"></script>
        <!-- Jquery Mobile Menu -->
        <script src="./assets/js/jquery.slicknav.min.js"></script>

        <!-- Jquery Slick , Owl-Carousel Plugins -->
        <script src="./assets/js/owl.carousel.min.js"></script>
        <script src="./assets/js/slick.min.js"></script>

        <!-- One Page, Animated-HeadLin -->
        <script src="./assets/js/wow.min.js"></script>
        <script src="./assets/js/animated.headline.js"></script>

        <!-- Scroll up, nice-select, sticky -->
        <script src="./assets/js/jquery.scrollUp.min.js"></script>
        <script src="./assets/js/jquery.nice-select.min.js"></script>
        <script src="./assets/js/jquery.sticky.js"></script>
        <script src="./assets/js/jquery.magnific-popup.js"></script>

        <!-- contact js -->
        <script src="./assets/js/contact.js"></script>
        <script src="./assets/js/jquery.form.js"></script>
        <script src="./assets/js/jquery.validate.min.js"></script>
        <script src="./assets/js/mail-script.js"></script>
        <script src="./assets/js/jquery.ajaxchimp.min.js"></script>

        <!-- Jquery Plugins, main Jquery -->	
        <script src="./assets/js/plugins.js"></script>
        <script src="./assets/js/main.js"></script>

    </body>

</html>