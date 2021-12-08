<%@ Page Title="" Language="C#" MasterPageFile="~/MainWeb.Master" AutoEventWireup="true" CodeBehind="MessageTV.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.MessageTV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="TieuDe-Mess">
        <img src="./img/MainLogo.png" width="50"; height="50" />
        <p style="margin-top: 14px;">Nhân Viên Hỗ Trợ</p>
    </div>
    <div class="bang">
        <div class="messageBox">
            
        </div>
    </div>
    <div class="TieuDe-Mess">
        <asp:TextBox ID="txtMess" runat="server" CssClass="txtMess"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" CssClass="btnSend" Text="Gửi" />
    </div>
</asp:Content>
