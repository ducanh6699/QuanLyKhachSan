<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="DangNhap.aspx.cs" Inherits="QuanLyKhachSanWeb.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Đăng nhập</title>

    <!-- CSS -->
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Roboto:400,100,300,500"/>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="assets/css/form-elements.css" />
    <link rel="stylesheet" href="assets/css/style.css" />


    <link rel="shortcut icon" href="assets/ico/favicon.png" />
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png"/>
    <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png"/>
    >
</head>
<body>
        <div class="top-content">

            <div class="inner-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-sm-8 col-sm-offset-2 text">
                            <h1><strong>QUẢN LÝ</strong> khách sạn</h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-sm-offset-3 form-box">
                            <div class="form-top">
                                <div class="form-top-left">
                                    <h3>Bạn cần đăng nhập</h3>
                                    <p>Điền tài khoản và mật khẩu:</p>
                                </div>
                                <div class="form-top-right">
                                    <i class="fa fa-lock"></i>
                                </div>
                            </div>
                            <div class="form-bottom">
                                <form role="form" class="login-form" runat=server>
                                    <div class="form-group">
                                        <label class="sr-only" for="TXTTenDangNhap">Username</label>
                                        <asp:TextBox required="true" ID="TXTTenDangNhap" placeholder="Tên đăng nhập" class="form-username form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label class="sr-only" for="TXTPassword">Password</label>
                                        <asp:TextBox required="true" TextMode="Password" ID="TXTPassword" placeholder="Mật khẩu" class="form-password form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <asp:Button ID="ButtonDangNhap" runat="server" Text="Đăng nhập" class="form-control btn-danger" OnClick="ButtonDangNhap_Click" />
                                    <asp:Label ID="LabelStatus" runat="server" ForeColor="White"></asp:Label>
                                </form>
                            </div>
                        </div>
                    </div>

                </div>

            </div>


            <!-- Javascript -->
            <script src="assets/js/jquery-1.11.1.min.js"></script>
            <script src="assets/bootstrap/js/bootstrap.min.js"></script>
            <script src="assets/js/jquery.backstretch.min.js"></script>
            <script src="assets/js/scripts.js"></script>

            <!--[if lt IE 10]>
            <script src="assets/js/placeholder.js"></script>
        <![endif]-->
        </div>
</body>
</html>
