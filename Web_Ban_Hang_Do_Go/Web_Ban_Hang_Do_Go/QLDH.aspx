<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="QLDH.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.QLDH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="Title-QL">
            <h1>Quản Lý Đơn Hàng</h1>
        </div>
        <div class="Contairner-QLDH">
            <div class="Ip-contairner-QLDH">
                <h3 style="margin: 9px 8px 0 10px;">CHI TIẾT ĐƠN HÀNG</h3>
                <div class="CTDH-List">
                    <asp:DataList ID="dlCTDH" runat="server" >
                        <ItemTemplate>
                            <div class="CTDH">
                                <img src="<%#Eval("AnhMH") %>" width="80" style="margin-left: 10px"/>
                                <div>
                                    <p style="margin-left: 3px; color: red; font-size: 17px; text-transform: uppercase;"><%#Eval("MaSP") %> - <%#Eval("TenSP") %></p>
                                    <p style="margin-left: 3px; color: #ccc; font-size: 15px;"><%#Eval("Gia")%> đ</p>
                                </div>  
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <div class="TongTien">
                        <asp:Label ID="lbTongTien" runat="server" Text="Tổng Tiền: 0đ"></asp:Label>
                    </div>
                </div>
                <h3 style="margin: 9px 8px 0 10px;">THÔNG TIN ĐƠN HÀNG</h3>
                <div class="TTDT">
                    <div class="TTDT-content">
                        <asp:Label ID="lbMaDH" runat="server" Text="Mã ĐH:" CssClass="lbTTDH"></asp:Label>
                        <asp:TextBox ID="txtMaDH" runat="server" CssClass="lbTTDH" autocomplete="off"></asp:TextBox>
                    </div>
                    <div class="TTDT-content">
                        <asp:Label ID="lbTen" runat="server" Text="Họ Tên: " CssClass="lbTTDH"></asp:Label>
                        <asp:Label ID="lbDiaChi" runat="server" Text="Địa Chỉ:" CssClass="lbTTDH"></asp:Label>
                    </div>
                    <div class="TTDT-content">
                        <asp:Label ID="lbSDT" runat="server" Text="SDT:" CssClass="lbTTDH"></asp:Label>
                        <asp:Label ID="lbEmail" runat="server" Text="Email:" CssClass="lbTTDH"></asp:Label>
                    </div>
                    <div class="TTDT-content">
                        <asp:Button ID="btnChapNhan" runat="server" Text="Chấp Nhận" CssClass="btnDH" OnClick="btnChapNhan_Click"/>
                        <asp:Button ID="btnTuChoi" runat="server" Text="Từ Chối" CssClass="btnDH" OnClick="btnTuChoi_Click"/>
                    </div>
                    <div class="TTDT-content">
                        <asp:Label ID="lbThongBao" runat="server" Text="Abc" CssClass="lbTB"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="DL-contairner-QLDH">
                <div class="list-btn">
                    <asp:Button ID="btnTatCa" runat="server" Text="Tất Cả DH" CssClass="btn" OnClick="btnTatCa_Click"/>
                    <asp:Button ID="btnDa" runat="server" Text="DH Đã XN " CssClass="btn" OnClick="btnDa_Click"/>
                    <asp:Button ID="bntChua" runat="server" Text="DH Chưa CN" CssClass="btn" OnClick="bntChua_Click"/>
                </div>
                <div class="Tile-tbl">
                    <div class="row-tbl">
                        <div class="col-tbl">
                            Mã ĐH
                        </div>
                        <div class="col-tbl">
                            Mã TV
                        </div>
                        <div class="col-tbl">
                            Tổng Tiền
                        </div>
                        <div class="col-tbl">
                            Trạng Thái
                        </div>
                        <div class="col-tbl">
                            Giao Hàng
                        </div>
                    </div>
                </div>
                <asp:DataList ID="DLDH" runat="server">
                    <ItemTemplate>
                        <div class="row-tbl-DL">
                            <div class="col-tbl">
                                <asp:LinkButton ID="btnDL" runat="server" CommandArgument='<%# Eval("MaDH") %>' OnClick="btnDoDL_Click">
                                    <i class="fas fa-arrow-left" style="cursor: pointer;padding: 2px 4.5px;border: 1px solid black; border-radius: 50%;"></i>
                                </asp:LinkButton>
                                <%#Eval("MaDH") %>
                            </div>
                            <div class="col-tbl">
                                <%#Eval("MaTV") %>
                            </div>
                            <div class="col-tbl">
                                <%#Eval("TongTien") %>
                            </div>
                            <div class="col-tbl">
                                <%#Eval("TrangThai") %>
                            </div>
                            <div class="col-tbl">
                                <%#Eval("GiaHang") %>
                            </div>
                         </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
