<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Sign in.aspx.cs" Inherits="mp.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
   
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="loginCSS.css" rel="stylesheet"/>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div class="loginbox">
        <img src="images/User.png"alt="Alternate Text" class="user"/>
        <h2>Log In Here</h2>
        
        <asp:Label text="Username" CssClass="lblemail" runat="server" ID="EmailLabel" />
        <asp:TextBox runat="server" CssClass="txtemail" placeholder="Enter email" ID="EmailTxtbox"/>
        <asp:Label Text="Password" CssClass="lblpass" runat="server" ID="PassLabel" />
        <asp:TextBox runat="server" CssClass="txtpass" placeholder="********" ID="passwordtxtbox" TextMode="Password"/>
        <asp:Button Text="Sign In" CssClass="btnsubmit" runat="server" ID="signInBtn" OnClick="signInBtn_Click" />
        <asp:LinkButton Text="Register New Account" CssClass="btnforget" runat="server" ID="Registerbuttonx" PostBackUrl="~/Register.aspx" />
        <br />
        <asp:LinkButton Text="Forgot Password" CssClass="btnforget" runat="server" ID="LinkButton1" OnClick="LinkButton1_Click"/>
        
    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
