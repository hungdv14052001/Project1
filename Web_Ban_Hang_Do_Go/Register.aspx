<%@ Page Title="" Language="C#" MasterPageFile="~/OtherSite.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="bg">
            <img class="bg-img" src="./img/bgR.jpg" />
        </div>
        <div class="modal-Resgister">
        <div class="container-R">
            <div class="header-R">
                <h1>Register</h1>
            </div>
            <div class="body-R">
                <label class="modal-R-lable">
                    <i class="fas fa-user-circle"></i>
                    ACCOUNT
                </label>
                <input type="text" runat="server" name="txtAccount" id="txtAccount" class="modal-R-text" placeholder="Number Phone"/>
                <label class="modal-R-lable">
                    <i class="fas fa-key"></i>
                    PASSWORD
                </label>
                <input type="password" runat="server" name="txtPassword" id="txtPassword" class="modal-R-text" placeholder="Password"/>
                <label class="modal-R-lable">
                    <i class="far fa-envelope"></i>
                    E-MAIL
                </label>
                <input type="text" class="modal-R-text" runat="server" name="txtEmail" id="txtEmail" placeholder="E-Mail Address"/>
                <asp:Button ID="btnRegister" runat="server" CssClass="modal-R-but" Text="REGISTER" OnClick="btnRegister_Click" />
            </div>
            <div class="footer-R">
                <asp:Label ID="lbThongBao" runat="server" CssClass="ThongBao" Text=""></asp:Label>
            </div>
        </div>
    </div>
    </div>
    
</asp:Content>
