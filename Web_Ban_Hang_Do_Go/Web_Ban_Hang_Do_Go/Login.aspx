<%@ Page Title="" Language="C#" MasterPageFile="~/OtherSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="LoginPage">
        <div class="contairner-Login">
            <div class="header-Login">
                <img src="./img/MainLogo.png" width="100"/>
            </div>
            <div class="body-Login">
                <label for="" class="Login-Label">
                    <i class="fas fa-user-circle"></i>
                    ACCOUNT
                </label>
                <input id="txtAcc" runat="server" class="Login-Input" placeholder="Your Account or Email"/>
                <label for="" class="Login-Label">
                    <i class="fas fa-key"></i>  
                    PASSWORD
                </label>
                <input type="password" id="txtPass" runat="server" class="Login-Input" placeholder="Your Password"/>
                <asp:Button ID="Button1" runat="server" Text="LOGIN" CssClass="Login-Button" OnClick="Button1_Click"/>
                <div class="footer-R">
                    <asp:Label ID="lbThongBao" runat="server" Text="" CssClass="lbTB-Login"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
