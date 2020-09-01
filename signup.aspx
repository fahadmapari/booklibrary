<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="onlinebooklibary.signup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="./frontend/css/signup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="signup-section">
        <div class="signup-container">
            <div class="signup-item">
                <h3>Username:</h3>
                <asp:TextBox ID="usernameIn" runat="server" CssClass="signup-input"></asp:TextBox>   
                <br />
                <asp:Label ID="usernameErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
            </div>
            <div class="signup-item">
                <h3>Email:</h3>
                <asp:TextBox ID="emailIn" runat="server" TextMode="Email" CssClass="signup-input"></asp:TextBox>   
                <br />
                <asp:Label ID="emailErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
            </div>
             <div class="signup-item">
                <h3>Phone:</h3>
                <asp:TextBox ID="mobilenumberIn" runat="server" TextMode="Number" CssClass="signup-input" ></asp:TextBox>   
                <br />
                <asp:Label ID="mobilenumberErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
             </div>
            <div class="signup-item">
                <h3>Password:</h3>
                <asp:TextBox ID="passwordIn" runat="server" TextMode="Password" CssClass="signup-input"></asp:TextBox>   
                <br />
                <asp:Label ID="passwordErr" runat="server" Text="Label" ForeColor="Red" Visible="False"></asp:Label>
            </div>
            <div class="signup-item">
                <asp:Button ID="signupbtn" runat="server" Text="Sign up" CssClass="signup-btn" OnClick="signupbtn_Click"/>  
            </div>
        </div>
    </section>
</asp:Content>
