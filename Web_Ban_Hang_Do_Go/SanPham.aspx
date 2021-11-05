<%@ Page Title="" Language="C#" MasterPageFile="~/MainWeb.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.SanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="SpPgae">
        <div class="TieuDe-Sp">
            <div class="TieuDe-Sp-item">
                <img src="./img/TieuDe.png" />
            </div>
            <div class="TieuDe-Sp-item">
                <asp:Label ID="lbTieuDe" runat="server" CssClass="lbTieuDe" Text="Sản Phẩm"></asp:Label>
            </div>
            <div class="TieuDe-Sp-item">
                <div class="sapxep">
                    <select name="cars" id="cars" style="height: 30px; width: 140px; float: right; margin-left: calc(100% - 142px);">
                        <option value="volvo">Sắp Xếp</option>
                        <option value="saab">Giá Từ Cao Xuống Thấp</option>
                        <option value="mercedes">Giá Từ thấp Lên Cao</option>
                        <option value="audi">Nổi Bật Nhất</option>
                     </select>
                </div>
            </div>
        </div>
        <div class="SP-container">
            <asp:DataList ID="DLSP" runat="server" CssClass="DS-SP" RepeatColumns="3">
                <ItemTemplate>
                    <div class="Item-SP">
                        <div class="anhsp">
                            <a href="Detialsp.aspx?ID=<%# Eval("MaSP")%>">
                                <img  style="width: 280px; height: 280px; transition: all 1s;" src="<%# Eval("AnhMH") %>" />

                            </a>
                        </div>
                        <a href="Detialsp.aspx?ID=<%# Eval("MaSP")%>" style="text-decoration: none;">
                            <div style="background: #C69C6D; height: 75px; width: 96%; margin-left: 2%; margin-top: 10px;">
                            <div style="display: flex; justify-content: center; height: 40px; align-items: center;">
                                <p style="color: white; font-size: 20px; padding: 0; margin: 0;"><%# Eval("TenSP") %></p>
                            </div>
                            <div style="display: flex; justify-content: center; height: 20px; align-items: center;">
                                <p style="color: #C31010; font-size: 18px; padding: 0; font-weight: 700; margin: 0; ">Giá: <%# Eval("Gia") %></p>
                            </div>
                        </div>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
