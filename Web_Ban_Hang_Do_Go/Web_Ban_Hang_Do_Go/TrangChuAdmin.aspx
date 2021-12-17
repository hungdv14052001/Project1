<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="TrangChuAdmin.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.TrangChuAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="HomePage-Ad">
        <div class="overview-HomePage-Ad">
            <div class="overview-It" style="background: #61D270;">
                <i class="fas fa-couch" style="margin-right: 10px;"></i>
                <div>
                    <asp:Label ID="lbTongSP" runat="server" Text="1" CssClass="Num-Ov"></asp:Label>
                    <p class="Content-Ov">Tổng Sản Phẩm</p>
                </div>
            </div>
            <div class="overview-It" style="background: #FBA026;">
                <i class="fas fa-file-invoice-dollar" style="margin-right: 10px;"></i>
                <div>
                    <asp:Label ID="lbTongDH" runat="server" Text="1" CssClass="Num-Ov" ></asp:Label>
                    <p class="Content-Ov">Tổng Đơn Hàng</p>
                </div>
            </div>
            <div class="overview-It" style="background: #E25041;">
                <i class="fas fa-users" style="margin-right: 10px;"></i>
                <div>
                    <asp:Label ID="lbTongTV" runat="server" Text="1" CssClass="Num-Ov" ></asp:Label>
                    <p class="Content-Ov">Tổng Thành Viên</p>
                </div>
            </div>
            <div class="overview-It" style="background: #26B7FB;">
                <i class="fas fa-comment-dots" style="margin-right: 10px;"></i>
                <div>
                    <asp:Label ID="lbTongLH" runat="server" Text="..." CssClass="Num-Ov" ></asp:Label>
                    <p class="Content-Ov">Tổng Liên Lạc</p>
                </div>
            </div>
        </div>
        <div class="Contairner-HomePage-Ad">
            <div class="Contairner-HP-Ad-List">
                <div class="Item">
                    <a href="QLspPage.aspx" class="nav-Item-HP-Ad">
                        <img src="./img/product-management.png" width="100" style="margin-left: calc( 50% - 50px) ;"/>
                        <p style="font-size: 20px; font-weight: 600; margin-left: 10px;">Quản lý Sản Phẩm</p>
                    </a>
                    <a href="QLDH.aspx" class="nav-Item-HP-Ad">
                        <img src="./img/Oder.png" width="100" style="margin-left: calc( 50% - 50px) ;"/>
                        <p style="font-size: 20px; font-weight: 600; margin-left: 10px;">Quản lý Đơn Hàng</p>
                    </a>
                </div>
                <div class="Item">
                    <a href="QLTV.aspx" class="nav-Item-HP-Ad">
                        <img src="./img/employee.png" width="100" style="margin-left: calc( 50% - 50px) ;"/>
                        <p style="font-size: 20px; font-weight: 600; margin-left: 10px;">Quản lý Thành Viên</p>
                    </a>
                    <a href="TTAdmin.aspx" class="nav-Item-HP-Ad">
                        <img src="./img/Admin-If.png" width="100" style="margin-left: calc( 50% - 50px) ;"/>
                        <p style="font-size: 20px; font-weight: 600; margin-left: 10px;">Thông Tin Quản Trị</p>
                    </a>
                </div>
            </div>
            <div class="Web-Infor">
                <p class="Title-Web-Infor">Thông Tin Website</p>
                <p>Thông Tin Hosting: </p>
                <p>Ngày Khởi Tạo Website: 20-11-2021</p>
                <p>Ngày Khởi Chạy Website: 20-11-2021</p>
            </div>
        </div>
    </div>
</asp:Content>
