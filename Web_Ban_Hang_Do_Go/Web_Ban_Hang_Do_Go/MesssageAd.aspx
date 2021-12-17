<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="MesssageAd.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.MesssageAd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="Title-QL">
            <h1>Tư Vấn Khác Hàng</h1>
        </div>
        <div class="Contairner-MessPage">
            <div class="DSKH">
                <div class="Title-QL">
                    <h1>Danh Sách Khách </h1>
                </div>
                <asp:DataList ID="DLKhachHang" runat="server">
                    <ItemTemplate>
                        <div class="khachHang">
                            <div style="border: 1px solid #ccc; font-size: 30px; border-radius: 50%; display: flex; justify-content: center;align-items:center; width: 40px; height: 40px; color: #E25041;">
                                <i class="fas fa-user-tie" ></i>
                            </div>
                            <asp:LinkButton ID="lbtnKH" CssClass="lbtnKH" runat="server" CommandArgument='<%# Eval("MaTV") %>' OnClick="lbtnKH_Click"><%# Eval("TenTV") %></asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div class="Con-Mess">
                <div class="MessBox">
                    <asp:DataList ID="DLMess" runat="server">
                        <ItemTemplate>
                            <div class='<%# Eval("isAd") %>'>
                                <p class='<%# Eval("isAd")+"Mess" %>'><%# Eval("MessContent") %></p>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="Mess-Control">
                    <asp:TextBox ID="txtMess" CssClass="txtMessAd" runat="server" autocomplete="off" ></asp:TextBox>
                    <asp:Button ID="btnSend" CssClass="btnSendAd" runat="server" Text="Gửi" OnClick="btnSend_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
