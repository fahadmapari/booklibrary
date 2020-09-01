<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="books.aspx.cs" Inherits="onlinebooklibary.books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./frontend/css/books.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section class="popular-book-section">
        <h2>Books</h2>
        <div style="width: 20rem; height: 5px; background: var(--green); display: block; margin: auto; margin-bottom: 1.5rem; border-radius: 25px;"></div>
        
        <div class="category-box">
            <span class="category-label">Category: </span>
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>All</asp:ListItem>
                <asp:ListItem>Academic & Education</asp:ListItem>
                <asp:ListItem>Art</asp:ListItem>
                <asp:ListItem>Biography</asp:ListItem>
                <asp:ListItem>Business & Career</asp:ListItem>
                <asp:ListItem>Children & Youth</asp:ListItem>
                <asp:ListItem>Environment</asp:ListItem>
                <asp:ListItem>Fiction & Literature</asp:ListItem>
                <asp:ListItem>Health & Fitness</asp:ListItem>
                <asp:ListItem>Lifestyle</asp:ListItem>
                <asp:ListItem>Personal Growth</asp:ListItem>
                <asp:ListItem>Politics & Laws</asp:ListItem>
                <asp:ListItem>Religion</asp:ListItem>
                <asp:ListItem>Science & Research</asp:ListItem>
                <asp:ListItem>Technology</asp:ListItem>
            </asp:DropDownList>
        </div>
         
        <div class="books-container">

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="book">
                <div class="book-cover">
                    <img src="./<%#Eval("coverlocation") %>" alt="its a book" />
                </div>
                <div class="book-controls">
                    <h3><%#Eval("title").ToString().Length>=22?Eval("title").ToString().Substring(0,21):Eval("title").ToString() %>...</h3>
                    <a href="/buybook.aspx?bookid=<%#Eval("bookid")%>&price=<%#Eval("price")%>" class="buy-book-button">Buy Book</a>
                    <a href="/book.aspx?id=<%#Eval("bookid") %>" class="view-book-details">View Details</a>
                </div>
                </div>
                </ItemTemplate>
            </asp:Repeater>
            
        </div>


    </section>
</asp:Content>
