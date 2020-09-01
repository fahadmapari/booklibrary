<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ownbooks.aspx.cs" Inherits="onlinebooklibary.ownbooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./frontend/css/ownbooks.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<section class="popular-book-section">
        <h2>My Books</h2>
        <div style="width: 20rem; height: 5px; background: var(--green); display: block; margin: auto; margin-bottom: 1.5rem; border-radius: 25px;"></div>
        
        
        <div class="books-container">

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="book">
                <div class="book-cover">
                    <img src="./<%#Eval("coverlocation") %>" alt="its a book" />
                </div>
                <div class="book-controls">
                    <h3><%#Eval("title").ToString().Length>=22?Eval("title").ToString().Substring(0,21):Eval("title").ToString() %>...</h3>
                    <a href="/<%#Eval("booklocation")%>" class="buy-book-button">Read Book</a>
                    <a href="/<%#Eval("booklocation")%>" class="view-book-details" style="display: block; margin-top: 0.8rem; margin-bottom: 0.8rem;" download>Download Book</a>
                    <a href="/book.aspx?id=<%#Eval("bookid") %>" class="view-book-details">View Details</a>

                </div>
                </div>
                </ItemTemplate>
            </asp:Repeater>
            
        </div>


    </section>
</asp:Content>
