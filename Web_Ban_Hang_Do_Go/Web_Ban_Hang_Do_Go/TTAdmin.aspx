<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="TTAdmin.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.TTAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="anhbia">
            <img src="./img/Slide.jpg" width="787" height="350"/>
        </div>
        <div class="ttAdmin">
            <img src="./img/avatar.jpg" class="ava-Ad"/>
            <div class="ttAdmin-Content">
                <asp:Label ID="lbTen" runat="server" Text="" CssClass="lbTen"></asp:Label>
                <br />
                <asp:Label ID="lbUsername" runat="server" Text="" CssClass="username"></asp:Label>
            </div>
        </div>
        <div class="content-Web">
            <p class="tt-web">Thông Tin Hosting: </p>
            <p class="tt-web">Ngày Khởi Tạo Website: 20-11-2021</p>
            <p class="tt-web">Ngày Khởi Chạy Website: 20-11-2021</p>
        </div>
    </div>
</asp:Content>
