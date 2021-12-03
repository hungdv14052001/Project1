<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSite.Master" AutoEventWireup="true" CodeBehind="QLTV.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.QLTV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="Title-QL">
            <h1>Danh Sách Thành Viên</h1>
        </div>
        <div class="row-tblTV">
            <div class="col-tblTV">
                Mã TV
            </div>
            <div class="col-tblTV">
                Tên TV
            </div>
            <div class="col-tblTV">
                Số ĐT
            </div>
            <div class="col-tblTV">
                Email
            </div>
            <div class="col-tblTV">
                Địa Chỉ
            </div>
            <div class="col-tblTV">
                Ngày ĐK
            </div>
        </div>
        <div style="width: 100%;">
            <asp:DataList ID="DLThanhVien" runat="server" CssClass="bang">
                <ItemTemplate>
                    <div class="row-tblTV">
                        <div class="col-tblTV">
                            <%#Eval("MaTV") %>
                        </div>
                        <div class="col-tblTV">
                            <%#Eval("TenTV") %>
                        </div>
                        <div class="col-tblTV">
                            <%#Eval("SDT") %>
                        </div>
                        <div class="col-tblTV">
                            <%#Eval("Email") %>
                        </div>
                        <div class="col-tblTV">
                            <%#Eval("DiaChi") %>
                        </div>
                        <div class="col-tblTV">
                            <%#Eval("NgayTao") %>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        
    </div>
</asp:Content>
