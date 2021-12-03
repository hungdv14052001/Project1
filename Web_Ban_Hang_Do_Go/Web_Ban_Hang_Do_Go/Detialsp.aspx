<%@ Page Title="" Language="C#" MasterPageFile="~/MainWeb.Master" AutoEventWireup="true" CodeBehind="Detialsp.aspx.cs" Inherits="Web_Ban_Hang_Do_Go.Detialsp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="DetailSP">
        <div class="TieuDe-Dt">
            <div class="TieuDe-Sp-item">
                <img src="./img/TieuDe.png" style="width: 60%;"/>
            </div>
        </div>
        <div style="height: 35px; width: 80%;margin-top: 10px; margin-left: 10%; background: #921C24;"></div>
        <div class="Body-Dt">
            <div class="Dt-Item">
                <div class="img-spD">
                    <img src="./" runat="server" id="imgsp" style="width: 460px; height: 460px; margin-top: 10px; margin-left: 10px;"/>
                </div>
            </div>
            <div class="Dt-Item">
                <div>
                    <label style="text-transform: uppercase; font-size: 30px; font-weight: 500;">
                        <asp:Label ID="lbTen" runat="server" Text="Label"></asp:Label>
                    </label>
                </div>
                <div style="background: #ccc; height: 5px; width: 50px; margin: 10px 0;"></div>
                <asp:Label ID="lbGia" runat="server" CssClass="lbGiacs" Text="300"></asp:Label>
                <div class="thuoctinh">
                    <label class="thuoctinh-name">Chất Liệu</label>
                    <asp:Label ID="lbChatLieu" runat="server" CssClass="thuoctinh-D" Text="a"></asp:Label>
                </div>
                <div class="thuoctinh">
                    <label class="thuoctinh-name">Kích Thước</label>
                    <asp:Label ID="lbTSKT" runat="server" CssClass="thuoctinh-D" Text="a"></asp:Label>
                </div>
                <div class="thuoctinh">
                    <label class="thuoctinh-name">Bảo Hành</label>
                    <asp:Label ID="Label3" runat="server" CssClass="thuoctinh-D" Text="5 năm – Bảo Trì Trọn Đời"></asp:Label>
                </div>
                <div class="thuoctinh">
                    <label class="thuoctinh-name">Cam Kết</label>
                    <asp:Label ID="Label4" runat="server" CssClass="thuoctinh-D" Text="Hoàn tiền 100% nếu khách hàng không hài lòng"></asp:Label>
                </div>
                <div class="muahang">
                    <input aria-label="quantity" class="inputsl" max="10" min="1" type="number" value="1">
                    <asp:Button ID="btnMuaHang" CssClass="btnMuaHang" runat="server" Text="Thêm Vào GH" OnClick="btnMuaHang_Click" />
                </div>
                <div class="MuaNgay">
                    <div class="btnMuaNgay">
                        <div style="height: 35px; display: flex; justify-content: center; align-items: center;">
                            <p style="margin: 0; padding: 0; font-size: 23px; font-weight: 500;">Mua Ngay</p>
                        </div>
                        <div style="height: 25px; display: flex; justify-content: center; align-items: center;">
                            <p style="margin: 0; padding: 0;">Gọi điện và xác nhận giao ngay</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="motaD">
            <div class="motaD-item">
                <div style="color: red; font-size: 20px; font-weight: 600; padding-bottom: 10px; border-bottom: 3px solid red;">Mô Tả Chi Tiết:</div>
                <div style="margin-top: 10px; height: 80%; width: 100%; border: 1px solid #ccc;">
                    <div class="motaD-content">
                        <asp:Label ID="lbMota" runat="server"  Text="Label"></asp:Label>
                    </div>
                    
                </div>
            </div>
        </div>
        <script>
            function TBThemVaoGH() {
                alert("Thêm vào giỏ hàng thành công");
            }
        </script>
    </div>
    
</asp:Content>
