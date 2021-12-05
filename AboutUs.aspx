<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="mp.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderId="Head" runat="server">
    <style type="text/css">
        .auto-style1 
        {
            text-align: justify;
            color: #FFFFFF;
        }
        .box 
        {
            text-align: justify;
            font-size:large;
            color: #FFFFFF;
            background: rgba(0,0,0,0.5);
            width:50%;
            margin-left:auto;
            margin-right:auto;
            padding:1%;

        }
        div
        {
            text-align:center;
        }
        .image
        {
            height:20%;
            width:20%;
        }

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="box">
    
        <asp:Label ID="p1" runat="server" Text="<em>Greetings</em>. FoxTale books is an online retailer dedicated to providing customers 
            with a wide assortment of books of diverse genres and subject matters, affordable prices that 
            stay competitive with other online bookstores, and a convenient and stress-free purchasing experience.
            FoxTale Books was established to cater to markets of similar interests to its owners, 
            with an incredible passion for literature and fiction the owners strive to provide a service like none other, 
            that focuses on customer experience and fostering a community of satisfied customers."
            CssClass="auto-style1"></asp:Label>
        
        </div>
    <div>
        <img src="images/AboutUsImage.png" class="image">
    </div>
    <div>
        <asp:Label ID="p2" runat="server" Text="For more inquiries and announcements please visit our official Facebook page and Twitter account."
            CssClass="auto-style1"></asp:Label>
        <a href="https://www.facebook.com/FoxTale-Books-102256548567303" target="_blank">
        <asp:Image runat="server" ImageUrl="images/facebooklogo.png" Height="3%" Width="3%" ></asp:Image> 
            </a>
        <a href="https://twitter.com/FoxTaleBooks1" target="_blank">
        <asp:Image runat="server" Height="3%" Width="3%" ImageUrl="images/twitterlogo.png"></asp:Image>
            </a>
        
    </div>
</asp:Content>