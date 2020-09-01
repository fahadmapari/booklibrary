<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="bookupload.aspx.cs" Inherits="onlinebooklibary.bookupload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/frontend/css/upload.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="book-upload-container">
        <div class="book-upload-item">
            <h3>Book:<span style="font-size: 0.8rem; font-weight: 400">(pdf)</span></h3>
            <asp:FileUpload ID="bookIn" runat="server" CssClass="uploadInput" accept=".pdf"/>
            <br />
            <asp:Label ID="bookErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
        </div>
        <div class="book-upload-item">
            <h3>Book Cover:<span style="font-size: 0.8rem; font-weight: 400">(images)</span></h3>
            <asp:FileUpload ID="coverIn" runat="server" CssClass="uploadInput" accept=".jpg, .png, .jpeg"/>
            <br />
            <asp:Label ID="coverErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
        </div>
        <div class="book-upload-item">
            <h3>Category:</h3>
            <asp:DropDownList ID="categoryIn" runat="server" CssClass="uploadInput uploadFont">
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
            <br />
            <asp:Label ID="categoryErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
        </div>
        <div class="book-upload-item">
            <h3>Title:</h3>
            <asp:TextBox ID="titleIn" runat="server" CssClass="uploadInput uploadFont"></asp:TextBox>
            <br />
            <asp:Label ID="titleErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
        </div>

        <div class="book-upload-item">
            <h3>Author:</h3>
            <asp:TextBox ID="authorIn" runat="server" CssClass="uploadInput uploadFont"></asp:TextBox>
            <br />
            <asp:Label ID="authorErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
        </div>
        <div class="book-upload-item">
            <h3>Description:</h3>
            <asp:TextBox ID="descriptionIn" runat="server" TextMode="MultiLine" CssClass="uploadInput uploadFont"></asp:TextBox>
            <br />
            <asp:Label ID="descriptionErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
        </div>
        <div class="book-upload-item">
            <h3>Price:</h3>
            <asp:TextBox ID="priceIn" runat="server" TextMode="Number" CssClass="uploadInput uploadFont"></asp:TextBox>
            <br />
            <asp:Label ID="priceErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
        </div>
        <div class="book-upload-item">
            <asp:Button ID="uploadbtn" runat="server" Text="Upload" CssClass="uploadbtn" OnClick="uploadbtn_Click"/>
        </div>
    </section>
</asp:Content>
