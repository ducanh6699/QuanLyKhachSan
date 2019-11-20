<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChonPhong.aspx.cs" Inherits="QuanLyKhachSanWebCustomers.ChonPhong" %>

<!DOCTYPE html>

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
    <style>
        .hiddencol { display: none; }

        .Grid {
            background-color: #fff;
            margin: 5px 0 10px 0;
            border: solid 1px #525252;
            border-collapse: collapse;
            font-family: Calibri;
            color: #474747;
            width:100%;
        }

            .Grid td {
                padding: 2px;
                border: solid 1px #c1c1c1;
            }

            .Grid th {
                padding: 4px 2px;
                color: #fff;
                background: #363670 url(Images/grid-header.png) repeat-x top;
                border-left: solid 1px #525252;
                font-size: 0.9em;
                text-align:center;
            }

            .Grid .alt {
                background: #fcfcfc url(Images/grid-alt.png) repeat-x top;
            }

            .Grid .pgr {
                background: #363670 url(Images/grid-pgr.png) repeat-x top;
            }

                .Grid .pgr table {
                    margin: 3px 0;
                }

                .Grid .pgr td {
                    border-width: 0;
                    padding: 0 6px;
                    border-left: solid 1px #666;
                    font-weight: bold;
                    color: #fff;
                    line-height: 12px;
                }

                .Grid .pgr a {
                    color: Gray;
                    text-decoration: none;
                }

                    .Grid .pgr a:hover {
                        color: #000;
                        text-decoration: none;
                    }
    </style>
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
                    <h2 class="page-cover-tittle f_48">Chọn phòng</h2>
                    <ol class="breadcrumb">
                        <li><a href="index.aspx">Trang chủ</a></li>
                        <li class="active">Chọn phòng</li>
                    </ol>
                </div>
            </div>
        </section>

        <div class="whole-wrap">

            <h3 class="text-heading title_color container">Vui lòng chọn phòng trống</h3>

            <div id="msgLoi" visible="false" class="container" runat="server" style="padding-bottom: 300px;">
                <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red" Font-Names="Times New Roman"></asp:Label>
            </div>

            <div id="gridview" class="container" runat="server">
                <asp:GridView ID="dgvPhong" runat="server" AutoGenerateColumns="false" style="table-layout: fixed;"

                      AllowPaging="true"

                      CssClass="Grid"                    

                      AlternatingRowStyle-CssClass="alt"

                      OnRowCommand="dgvPhong_RowCommand"

                      PagerStyle-CssClass="pgr" OnPageIndexChanging="dgvPhong_PageIndexChanging">   
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField DataField="SoPhong" HeaderText="Số phòng" />
                        <asp:BoundField DataField="TenLoaiPhong" HeaderText="Tên loại phòng" />
                        <asp:BoundField DataField="DonGia" HeaderText="Đơn giá (1 đêm)" />
                        <asp:ButtonField Text="Đặt phòng" HeaderText="Đặt"/>
                    </Columns>
                </asp:GridView>
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
</body>
</html>
