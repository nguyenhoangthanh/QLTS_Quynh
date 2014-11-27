<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QLTS_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    Nguyễn Thị Quỳnh
    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="MACOSO" HeaderText="ID" Visible="False" />
            <asp:BoundField DataField="SUBID" HeaderText="Mã cơ sở" />
            <asp:BoundField DataField="TENCOSO" HeaderText="Tên cơ sở" />
            <asp:BoundField DataField="DIACHI" HeaderText="Địa chỉ" />
        </Columns>
    </asp:GridView>
&nbsp;
</asp:Content>
