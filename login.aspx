<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="onlinebooklibary.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./frontend/css/login.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="login-section">
        <div class="login-container">
            <div class="login-item">
                <h3>Username:</h3>
                <asp:TextBox ID="usernameIn" runat="server" CssClass="login-input"></asp:TextBox>   
                <br />
                <asp:Label ID="usernameErr" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
                </div>
            
            <div class="login-item">
                <h3>Password:</h3>
                <asp:TextBox ID="passwordIn" runat="server" TextMode="Password" CssClass="login-input"></asp:TextBox>   
                <br />
                <asp:Label ID="passwordErr" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
            </div>
            <div class="login-item">
                <asp:Button ID="loginbtn" runat="server" Text="Login" CssClass="login-btn" OnClick="loginbtn_Click"/>  
            </div>
        </div>
        <a href="/adminlogin.aspx" style="display: block; text-align: center;">admin login</a>
    </section>

</asp:Content>
