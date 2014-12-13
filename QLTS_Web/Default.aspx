<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QLTS_Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Quản lý tài sản</title>
    <style type="text/css">
        body {
            font-family: "Segoe WPC","Segoe UI",Helvetica, Arial, "Arial Unicode MS", Sans-Serif;
        }
    </style>
</head>
<body>
    <form id="form" runat="server">
        <table border="0" style="width: 800px; vertical-align: central; text-align: center; margin: auto;">
            <tr>
                <td colspan="2" style="text-align: left; color: blue; font-size: xx-large">Quản lý tài sản</td>
                <td style="text-align: right"><b id="HoTen" runat="server"></b></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonDangKySuDungPhong" runat="server" Text="Đăng ký sử dụng phòng" BackColor="#ff66ff" BorderColor="Transparent" Font-Names="Segoe WPC,Segoe UI,Helvetica,Arial,Arial Unicode MS,Sans-Serif" Font-Overline="False" Font-Size="Large" ForeColor="White" OnClick="ButtonDangKySuDungPhong_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtonXemTaiSanTheoLoaiTaiSan" runat="server" Text="Xem tài sản theo loại tài sản" BackColor="#3399ff" BorderColor="Transparent" Font-Names="Segoe WPC,Segoe UI,Helvetica,Arial,Arial Unicode MS,Sans-Serif" Font-Overline="False" Font-Size="Large" ForeColor="White" OnClick="ButtonXemTaiSanTheoLoaiTaiSan_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtonXemTaiSanTheoPhong" runat="server" Text="Xem tài sản theo phòng" BackColor="#33cc33" BorderColor="Transparent" Font-Names="Segoe WPC,Segoe UI,Helvetica,Arial,Arial Unicode MS,Sans-Serif" Font-Overline="False" Font-Size="Large" ForeColor="White" OnClick="ButtonXemTaiSanTheoPhong_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table id="TableDangNhap" visible="false" runat="server" border="0" style="width: 300px; text-align: left; margin: auto;">
                        <tr>
                            <td colspan="2" style="text-align: left">
                                <asp:Label ID="LabelThongBaoDangNhap" runat="server" Text="" ForeColor="#ff0000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Tài khoản:</td>
                            <td>
                                <asp:TextBox ID="TextBoxTaiKhoan" runat="server" placeholder="Tài khoản" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Mật khẩu:</td>
                            <td>
                                <asp:TextBox ID="TextBoxMatKhau" runat="server" placeholder="Mật khẩu" Width="200px" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Button ID="ButtonDangNhap" runat="server" Text="Đăng nhập" OnClick="ButtonDangNhap_Click" BackColor="#ff9900" BorderColor="Transparent" Font-Names="Segoe WPC,Segoe UI,Helvetica,Arial,Arial Unicode MS,Sans-Serif" Font-Overline="False" Font-Size="Medium" ForeColor="White" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <table id="TableDangKySuDungPhong" visible="false" runat="server" border="0" style="width: 500px; text-align: left; margin: auto;">
                        <tr>
                            <td colspan="2" style="text-align: left">
                                <asp:Label ID="LabelThongBaoDangKySuDungPhong" runat="server" Text="" ForeColor="#ff0000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Khoa/ Phòng mượn(*):</td>
                            <td>
                                <asp:TextBox ID="TextBoxKhoaPhongMuon" runat="server" placeholder="Khoa Công nghệ thông tin" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Ngày mượn(*):</td>
                            <td>
                                <asp:TextBox ID="TextBoxNgayMuon" runat="server" placeholder="01/01/2015" Width="200px" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Từ giờ(*):</td>
                            <td>
                                <asp:TextBox ID="TextBoxTuGio" runat="server" placeholder="07:00" Width="200px" TextMode="Time"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Đến giờ(*):</td>
                            <td>
                                <asp:TextBox ID="TextBoxDenGio" runat="server" placeholder="11:30" Width="200px" TextMode="Time"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Số lượng sinh viên(*):</td>
                            <td>
                                <asp:TextBox ID="TextBoxSoLuongSinhVien" runat="server" placeholder="50" Width="200px" TextMode="Number"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Lý do mượn(*):</td>
                            <td>
                                <asp:TextBox ID="TextBoxLyDoMuon" TextMode="MultiLine" runat="server" placeholder="Dạy bù" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Button ID="ButtonMuonPhong" runat="server" Text="Mượn phòng" OnClick="ButtonMuonPhong_Click" BackColor="#ff9900" BorderColor="Transparent" Font-Names="Segoe WPC,Segoe UI,Helvetica,Arial,Arial Unicode MS,Sans-Serif" Font-Overline="False" Font-Size="Medium" ForeColor="White" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <asp:Panel ID="PanelTaiSanTheoLoaiTaiSan" Visible="false" runat="server">
                <tr style="text-align: left">
                    <td>Danh sách loại tài sản</td>
                    <td colspan="2">Danh sách tài sản của loại tài sản <b id="tenloaitaisan" runat="server"></b></td>
                </tr>
                <tr style="text-align: left; width: 600px;">
                    <td style="vertical-align: top;">
                        <asp:ListBox ID="ListBoxLoaiTaiSan" runat="server" Width="200px" Height="300px" AutoPostBack="true" OnSelectedIndexChanged="ListBoxLoaiTaiSan_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td colspan="2" style="vertical-align: top; width: 600px;">
                        <asp:GridView ID="GridViewTaiSanTheoLoai" runat="server" Width="590px" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                <asp:BoundField DataField="SUBID" HeaderText="Mã tài sản" />
                                <asp:BoundField DataField="TENTAISAN" HeaderText="Tên tài sản" />
                                <asp:BoundField DataField="NGAYMUA" HeaderText="Ngày mua" />
                                <asp:CheckBoxField DataField="TAISANKHONGGIOIHAN" HeaderText="Không giới hạn" />
                                <asp:BoundField DataField="MOTA" HeaderText="Mô tả" />
                                <asp:BoundField DataField="NGAYTAO" HeaderText="Ngày tạo" />
                                <asp:BoundField DataField="NGAYSUA" HeaderText="Ngày sửa" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="PanelTaiSanTheoPhong" Visible="false" runat="server">
                <tr style="text-align: left">
                    <td>Danh sách phòng</td>
                    <td colspan="2">Danh sách tài sản của phòng <b id="tenphong" runat="server"></b></td>
                </tr>
                <tr style="text-align: left; width: 600px;">
                    <td>
                        <asp:ListBox ID="ListBoxPhong" runat="server" Width="240px" Height="300px" OnSelectedIndexChanged="ListBoxPhong_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                    </td>
                    <td colspan="2" style="vertical-align: top; width: 600px;">
                        <asp:GridView ID="GridViewTaiSanTheoPhong" runat="server" Width="550px" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False" />
                                <asp:BoundField DataField="SUBID" HeaderText="Mã tài sản" />
                                <asp:BoundField DataField="TEN" HeaderText="Tên tài sản" />
                                <asp:BoundField DataField="SOLUONG" HeaderText="Số lượng" />
                                <asp:BoundField DataField="TINHTRANG" HeaderText="Tình trạng" />
                                <asp:BoundField DataField="NGAYNHAP" HeaderText="Ngày nhập" />
                                <asp:BoundField DataField="MOTA" HeaderText="Mô tả" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </asp:Panel>
        </table>
    </form>
</body>
</html>
