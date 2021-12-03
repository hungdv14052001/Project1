<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="QLspPage.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.QLspPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="Title-QL">
            <h1>Quản Lý Sản Phẩm</h1>
        </div>
        <div class="contairner-QL">
            <div class="Input-Contairner-QL">
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label1" runat="server" Text="Mã SP: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtMaSP" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label2" runat="server" Text="Tên SP: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtTenSP" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label3" runat="server" Text="Loại DM: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtLoaiDM" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label4" runat="server" Text="Loại SP: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtLoaiSP" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label5" runat="server" Text="Chất Liệu: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtChatLieu" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label6" runat="server" Text="Giá Tiền: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtGia" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label7" runat="server" Text="Ảnh MH: " CssClass="lb-QL" ></asp:Label>
                    <asp:FileUpload ID="ful" runat="server" accept=".png,.jpg,.jpeg,.gif" CssClass="ful-Ip"/>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label8" runat="server" Text="Mô tả: " CssClass="lb-QL"></asp:Label>
                    <textarea id="txtMoTa" cols="28" rows="5" CssClass="ip-QLMT" autocomplete="off" runat="server"></textarea>
                </div>
                <div class="Input-Contairner-QL-Item">
                    <asp:Label ID="Label9" runat="server" Text="TSKT: " CssClass="lb-QL"></asp:Label>
                    <asp:TextBox ID="txtTSKT" runat="server" CssClass="ip-QL" autocomplete="off"></asp:TextBox>
                </div>
                <asp:Label ID="lbThongBao" runat="server" CssClass="lbTB-QL"></asp:Label>
                <div class="Input-Contairner-QL-Item" style="display: flex; justify-content: space-around; height: 70px;">
                    <asp:Button ID="Button2" runat="server" CssClass="btnIp" Text="Thêm SP" OnClick="Button2_Click" />
                    <asp:Button ID="Button3" runat="server" CssClass="btnIp" Text="Sửa SP" OnClick="Button3_Click" />
                    <asp:Button ID="Button4" runat="server" CssClass="btnIp" Text="Xóa SP" OnClick="Button4_Click" />
                    <asp:Button ID="Button1" runat="server" CssClass="btnIp" Text="Làm Tươi" OnClick="Button1_Click" />
                </div>
            </div>
            <div class="Tbl-Contairner-QL">
                <div class="row-tbl">
                    <div class="type-collumm1">
                        Mã SP
                    </div>
                    <div class="type-collumm2">
                        Tên SP
                    </div>
                    <div class="type-collumm3">
                        Loại DM
                    </div>
                    <div class="type-collumm3">
                        Loại SP
                    </div>
                    <div class="type-collumm3">
                        Chất Liệu
                    </div>
                    <div class="type-collumm3">
                        Giá Tiền
                    </div>
                    <div class="type-collumm4">
                        Ảnh MH
                    </div>
                    <div class="type-collumm5">
                        Mô Tả
                    </div>
                    <div class="type-collumm3">
                        TSKT
                    </div>
                </div>
                <asp:DataList ID="DLSanPham" runat="server">
                    <ItemTemplate>
                        <div class="row-tbl" style="background: white; height: 50px;">
                            <div class="type-collumm1 newheight">
                                <asp:LinkButton ID="btnDL" runat="server" CommandArgument='<%# Eval("MaSP") %>' OnClick="btnDoDL_Click">
                                    <i class="fas fa-arrow-left" style="cursor: pointer;padding: 2px 4.5px;border: 1px solid black; border-radius: 50%;"></i>
                                </asp:LinkButton>
                                <%#Eval("MaSP") %>
                            </div>
                            <div class="type-collumm2 newheight">
                                <%#Eval("TenSP") %>
                            </div>
                            <div class="type-collumm3 newheight">
                                <%#Eval("LoaiDM") %>
                            </div>
                            <div class="type-collumm3 newheight">
                                <%#Eval("LoaiSP") %>
                            </div>
                            <div class="type-collumm3 newheight">
                                <%#Eval("ChatLieu") %>
                            </div>
                            <div class="type-collumm3 newheight">
                                <%#Eval("Gia") %>
                            </div>
                            <div class="type-collumm4 newheight">
                                <img src="<%#Eval("AnhMH") %>" width="45"/>
                            </div>
                            <div class="type-collumm5 newheight">
                                <%#Eval("Mota") %>
                            </div>
                            <div class="type-collumm3 newheight">
                                <%#Eval("TSKT") %>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <div class="list-btnPage">
                    <asp:Button ID="bntPrev" runat="server" Text="<<" OnClick="bntPrev_Click" />
                    ...
                    <asp:Button ID="bntNext" runat="server" Text=">>" OnClick="bntNext_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
