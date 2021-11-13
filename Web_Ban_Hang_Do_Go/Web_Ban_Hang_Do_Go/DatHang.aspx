<%@ Page Title="" Language="C#" MasterPageFile="~/OtherSite.Master" AutoEventWireup="true" CodeBehind="DatHang.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.DatHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="DatHang-Page">
            <a class="back" href="HomePage.aspx">
                <i class="fas fa-chevron-left back-icon"></i>
                <i class="fas fa-chevron-left back-icon"></i>
                Trở Về Trang Chủ
            </a>
        <div class="contentDH">
            <p style="font-size: 25px; font-weight: 500; margin: 10px 0; padding: 0;color: saddlebrown;">ĐỒ GỖ NỘI THẤT VĂN HÙNG</p>
            <div class="body-DH">
                <p style="font-size: 25px; font-weight: 500; margin: 10px 0; padding: 0;">Thông Tin Đơn Hàng</p>
                <div class="tt-DH">
                    
                    <asp:DataList ID="DLGioHang" runat="server">
                        <ItemTemplate>
                            <div class="ChiTietGH">
                                <div class="hinhanh-GH">
                                    <img src="<%# Eval("AnhMH") %>" style="width: 60px; height: 60px;"/>
                                </div>
                                <div class="ChiTiet-GH">
                                    <a href="Detialsp.aspx?ID=<%# Eval("MaSP")%>" style="text-decoration: none; margin: 5px 0 0 5px; font-size: 20px; color: red;">
                                        <%# Eval("TenSP") %>-<%# Eval("MaSP") %>

                                    </a>
                                    <p style="margin: 5px 0 0 5px; color: #ccc;"><%# Eval("SL") %> x <%# Eval("Gia") %> ₫</p>
                                </div>
                                <asp:LinkButton ID="btnXoaGH" runat="server" CssClass="Xoa-GH" CommandArgument='<%# Eval("MaH") %>' OnClick="btnXoaGH_Click">
                                    <i class="fas fa-times" style="cursor: pointer;padding: 2px 4.5px;border: 1px solid black; border-radius: 50%;"></i>
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>    
                    </asp:DataList>
                    <asp:Label ID="Total" runat="server" CssClass="Total-GH" Text="Total: 0"></asp:Label>
                </div>
                <p style="font-size: 25px; font-weight: 500; margin: 10px 0; padding: 0;">Thông Tin Giao Hàng</p>
                <div class="tt-GiaoHang">
                    <input class="input-tt" placeholder="Họ Và Tên"/>
                    <input class="input-tt" placeholder="Địa Chỉ Giao Hàng"/>
                    <input class="input-tt" placeholder="Số Điện Thoại Người Nhận"/>
                    <input class="input-tt" placeholder="Email"/>
                    <div class="chuthich">
                        <p>Chi Phí Giao Hàng: </p>
                        <p>- Miễn phí đối với địa chỉ ở nội thành Hà Nội</p>
                        <p>Vùng ngoại thành Hà Nội: 100.000đ/đơn hàng</p>
                        <p>Các tỉnh thành khác: 100.000đ/đơn hàng</p>
                    </div>
                </div>
                <asp:Button ID="HTDatHang" CssClass="btnDatHang" runat="server" Text="Hoàn Thành Đặt Hàng" />
            </div>
        </div>

    </div>
</asp:Content>
