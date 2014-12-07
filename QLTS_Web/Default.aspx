<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QLTS_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Quản lý tài sản</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <a href="XemTaiSanTheoLoai.aspx">Xem tài sản theo loại</a>
    <a href="XemTaiSanTheoPhong.aspx">Xem tài sản theo phòng</a>
    <a href="DangKySuDungPhong.aspx">Đăng ký sử dụng phòng</a>
</asp:Content>
