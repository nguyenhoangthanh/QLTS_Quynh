<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XemTaiSanTheoLoai.aspx.cs" Inherits="QLTS_Web.XemTaiSanTheoLoai" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Xem tài sản theo loại</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:ListBox ID="ListBox" runat="server" AutoPostBack="True" Height="300px" Width="300px" OnSelectedIndexChanged="ListBox_SelectedIndexChanged"></asp:ListBox></td>
                    <td>
                        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" Height="300px" Width="500px">
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
            </table>
        </div>
    </form>
</body>
</html>
