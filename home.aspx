<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="onlinebooklibary.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://unpkg.com/aos@2.3.1/dist/aos.css" rel="stylesheet">
    <link href="./frontend/css/home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <header>
        <div class="head-content" data-aos="fade-down-right">
            <div>
                <h1>Online Book Library</h1>
                <p>Best Collection Of books</p>
            </div>
        </div>
        <div class="head-image" data-aos="fade-down-left">
            <img src="./assets/book-logo.svg" alt="Book logo" />
        </div>
    </header>

    <section class="choose-section">
        <h2>Why Choose Us?</h2>
        <div style="width: 20rem; height: 5px; background: var(--green); display: block; margin: auto; margin-bottom: 1.5rem; border-radius: 25px;"></div>
    
        <div class="features">
            <div class="features-list">
            <div class="features-item" data-aos="fade-right">
                <div class="features-check">
                    <img src="./assets/check.svg" alt="Alternate Text" width="25"/>
                </div>
                <div class="features-info">
                    <p>Best collections of books</p>
                </div>
            </div>

            <div class="features-item" data-aos="fade-right">
                <div class="features-check">
                    <img src="./assets/check.svg" alt="Alternate Text" width="25"/>
                </div>
                <div class="features-info">
                    <p>Affordable Prices</p>
                </div>
            </div>
            
            <div class="features-item" data-aos="fade-right">
                <div class="features-check">
                    <img src="./assets/check.svg" alt="Alternate Text" width="25"/>
                </div>
                <div class="features-info">
                    <p>Easy to Use UI</p>
                </div>
            </div>
            </div>
            <div class="features-img" data-aos="fade-left">
                <img src="./assets/feature-section.svg" alt="feature section image" />
            </div>
        </div>

    </section>

    <section class="popular-book-section">
        <h2>Popular Books</h2>
        <div style="width: 20rem; height: 5px; background: var(--green); display: block; margin: auto; margin-bottom: 1.5rem; border-radius: 25px;"></div>
        <div class="books-container">
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div class="book" data-aos="flip-left">
                <div class="book-cover">
                    <img src="./<%#Eval("coverlocation")%>" alt="its a book" />
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

        <a href="/books.aspx" class="view-all-books">View All</a>

    </section>

    <footer>
        <p> Copyright &copy 2020. All Rights Reserved</p>
    </footer>

    
    <script src="https://unpkg.com/aos@2.3.1/dist/aos.js"></script>
    <script>
        AOS.init({once: true});
    </script>
</asp:Content>
