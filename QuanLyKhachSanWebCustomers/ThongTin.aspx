<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThongTin.aspx.cs" Inherits="QuanLyKhachSanWebCustomers.ThongTin" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="icon" href="image/favicon.png" type="image/png">
    <title>Chọn phòng</title>
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="vendors/linericon/style.css">
    <link rel="stylesheet" href="css/font-awesome.min.css">
    <link rel="stylesheet" href="vendors/bootstrap-datepicker/bootstrap-datetimepicker.min.css">
    <link rel="stylesheet" href="vendors/nice-select/css/nice-select.css">
    <link rel="stylesheet" href="vendors/owl-carousel/owl.carousel.min.css">
    <!-- main css -->
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/responsive.css">

    <link rel="stylesheet" href="vendors/bootstrap-datepicker/bootstrap-datetimepicker.min.css">
</head>
<body>
    <form id="form1" runat="server">

        <header class="header_area">
            <div class="container">
                <nav class="navbar navbar-expand-lg navbar-light">
                    <!-- Brand and toggle get grouped for better mobile display -->
                    <a class="navbar-brand logo_h" href="index.aspx">
                        <img src="image/Logo.png" alt=""></a>
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <!-- Collect the nav links, forms, and other content for toggling -->
                    <div class="collapse navbar-collapse offset" id="navbarSupportedContent">
                        <ul class="nav navbar-nav menu_nav ml-auto">
                            <li class="nav-item active"><a class="nav-link" href="index.aspx">Trang chủ</a></li>
                            <li class="nav-item"><a class="nav-link" href="contact.html">Liên hệ</a></li>
                        </ul>
                    </div>
                </nav>
            </div>
        </header>


        <section class="breadcrumb_area blog_banner_two">
            <div class="overlay bg-parallax" data-stellar-ratio="0.8" data-stellar-vertical-offset="0" data-background=""></div>
            <div class="container">
                <div class="page-cover text-center">
                    <h2 class="page-cover-tittle f_48">Điền thông tin</h2>
                    <ol class="breadcrumb">
                        <li><a href="index.aspx">Trang chủ</a></li>
                        <li>Chọn phòng</li>
                        <li class="active">Điền thông tin</li>
                    </ol>
                </div>
            </div>
        </section>

        <div class="whole-wrap">


            <div id="msgLoi" visible="false" class="container" runat="server" style="padding-bottom: 300px;">
                <h3 class="text-heading title_color container row">Điền thông tin khách hàng</h3>
                <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red" Font-Names="Times New Roman"></asp:Label>
            </div>

            <div id="thongtin" class="container" runat="server">
                <h3 class="text-heading title_color row">Điền thông tin khách hàng</h3>
                <div class="row">
                    <div class="col-md-4 order-md-2 mb-4">
                        <h4 class="d-flex justify-content-between align-items-center mb-3">
                            <span class="text-muted">Thông tin chi phí</span>
                        </h4>
                        <ul class="list-group mb-3">
                            <li class="list-group-item d-flex justify-content-between lh-condensed">
                                <div>
                                    <h6 class="my-0">Số phòng</h6>
                                    <small class="text-muted">Số phòng trong khách sạn</small>
                                </div>
                                <span class="text-muted">
                                    <asp:Label ID="lbSoPhong" runat="server" Text="Không xác định"></asp:Label>

                                </span>
                            </li>

                            <li class="list-group-item d-flex justify-content-between lh-condensed">
                                <div>
                                    <h6 class="my-0">Số ngày</h6>
                                    <small class="text-muted">Số ngày ở khách sạn</small>
                                </div>
                                <span class="text-muted">
                                    <asp:Label ID="lbSoNgay" runat="server" Text="Không xác định"></asp:Label></span>
                            </li>

                            <li class="list-group-item d-flex justify-content-between lh-condensed">
                                <div>
                                    <h6 class="my-0">Thành tiền</h6>
                                    <small class="text-muted">Toàn bộ chi phí trong hóa đơn</small>
                                </div>
                                <span class="text-muted">
                                    <asp:Label ID="lbChiPhi" runat="server" Text="Không xác định"></asp:Label></span>
                            </li>
                        </ul>
                    </div>
                    <div class="col-md-8 order-md-1">
                        <h4 class="mb-3">Thông tin khách hàng</h4>

                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="txtTen">Họ và tên (*)</label>
                                <asp:TextBox ID="txtTen" class="form-control" runat="server" placeholder="Điền họ và tên" required></asp:TextBox>
                            </div>

                            <div class="col-md-6 mb-3">
                                <label for="txtNgaySinh">Ngày sinh (*)</label>
                                <asp:TextBox ID="txtNgaySinh" class="form-control" runat="server" placeholder="MM/dd/yyyy" required></asp:TextBox>
                            </div>

                        </div>

                        <div class="row">
                            <div class="mb-3 col-md-8">
                                <label for="txtDiaChi">Địa chỉ</label>
                                <asp:TextBox ID="txtDiaChi" runat="server" class="form-control" placeholder="Nhập địa chỉ"></asp:TextBox>
                            </div>

                            <div class="mb-3 col-md-4">
                                <label for="DropDownList1">Giới tính</label>

                                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server">
                                    <asp:ListItem>Nam</asp:ListItem>
                                    <asp:ListItem>Nữ</asp:ListItem>
                                    <asp:ListItem>Khác</asp:ListItem>
                                </asp:DropDownList>
                            </div>


                        </div>


                        <div class="mb-3">
                            <label for="txtSDT">Số điện thoại (*) </label>
                            <asp:TextBox ID="txtSDT" class="form-control" placeholder="Số điện thoại" runat="server"></asp:TextBox>
                        </div>



                        <hr class="mb-4">
                        <asp:Button ID="Submit" class="btn btn-primary btn-lg btn-block" OnClientClick="return confirm('Bạn chắc chắn chứ')" runat="server" Text="OK" OnClick="Submit_Click" />
                    </div>

                </div>


            </div>

            <div id="thongbao" runat="server" visible="false" class="container">
                <h3 class="text-heading title_color row">Đặt phòng thành công! <small><a href="index.aspx"> về trang chủ</a></small></h3>
                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-4 col-form-label">Tên khách hàng</label>
                    <div class="col-sm-8">
                        <asp:Label ID="Labeltenkhachhang" runat="server" Font-Names="Times New Roman"></asp:Label>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-4 col-form-label">Số điện thoại</label>
                    <div class="col-sm-8">
                        <asp:Label ID="labelSDT" runat="server" Font-Names="Times New Roman"></asp:Label>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-4 col-form-label">Ngày nhận</label>
                    <div class="col-sm-8">
                        <asp:Label ID="labelngaynhan" runat="server" Font-Names="Times New Roman"></asp:Label>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-4 col-form-label">Ngày trả</label>
                    <div class="col-sm-8">
                        <asp:Label ID="labelngaytra" runat="server" Font-Names="Times New Roman"></asp:Label>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-4 col-form-label">Số người</label>
                    <div class="col-sm-8">
                        <asp:Label ID="labelsonguoi" runat="server" Font-Names="Times New Roman"></asp:Label>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="inputPassword" class="col-sm-4 col-form-label">Thành tiền</label>
                    <div class="col-sm-8">
                        <asp:Label ID="labelthanhtien" runat="server" Font-Names="Times New Roman"></asp:Label>
                    </div>
                </div>

            </div>

            <footer class="footer-area section_gap">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12  col-md-12 col-sm-12">
                            <div class="single-footer-widget">
                                <h6 class="footer_title">Về chúng tôi</h6>
                                <p></p>
                            </div>
                        </div>

                    </div>
                    <div class="border_line"></div>
                </div>
            </footer>
    </form>
    <script src="js/jquery-3.2.1.min.js"></script>
    <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
</body>
</html>

