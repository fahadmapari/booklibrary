<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="onlinebooklibary.book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./frontend/css/book.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="book-details-section">
        <div class="book-cover-box">
            <asp:Image ID="cover" runat="server" CssClass="img"/>
        </div>
        <div class="book-details-box">
            <div class="book-details-item">
                <span class="heads">Title: </span>
                <asp:Label ID="title" runat="server" Text="-" CssClass="labels"></asp:Label>
                <div class="author-box" style="margin-top: 1rem; margin-bottom: 1rem;">
                    <span class="heads">Author: </span>
                    <asp:Label ID="author" runat="server" Text="-" CssClass="labels"></asp:Label>
                </div>
            </div>

            <div class="book-details-item">
                <span class="heads">Category: </span>
                <asp:Label ID="category" runat="server" Text="-" CssClass="labels"></asp:Label>
            </div>

            <div class="book-details-item">
                <span class="heads">Description: </span>
                <asp:Label ID="description" runat="server" Text="-" CssClass="labels"></asp:Label>
            </div>
        </div>
        <div class="book-buy-box">
            <div class="float-buy">
            <div class="book-buy-item">
                <span class="heads">Price:</span>
                 <asp:Label ID="price" runat="server" Text="₹ -" CssClass="labels"></asp:Label>
            </div>
            <div class="book-buy-item">
                <asp:Button ID="buybtn" runat="server" Text="Buy Now" CssClass="buybtn" Enabled="True" OnClick="btnBuy_Click"/>
            </div>
            </div>
            </div>

    </section>

</asp:Content>
