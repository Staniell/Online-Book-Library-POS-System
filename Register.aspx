<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="mp.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style7 {
            position: absolute;
            left: 48%;
            transform: translate(-40%,-15%);
            width: 382px;
            height: 1300px;
            padding: 80px 40px;
            padding-bottom:110%;
            box-sizing: border-box;
            background: rgba(0,0,0,0.5);
        }
        .user{
            width:100px;
            height:100px;
            overflow:hidden;
            padding-top:110px;
            left:calc(50% - 50px);
            position:absolute;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="loginCSS.css" rel="stylesheet"/>
    <div class="auto-style7">

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <img src="images/User.png"alt="Alternate Text" class="user"/>
        <h2>Register Here</h2>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <asp:Label text="Username" CssClass="lblemail" runat="server" ID="UsernameLabel" />
                        <asp:Label ID="Label2" runat="server" Text="Username is already taken" Visible="false" ForeColor="red"></asp:Label>
        <asp:TextBox runat="server" CssClass="txtemail" OnTextChanged="UserTextbox_TextChanged" AutoPostBack="true" placeholder="Enter Username" ID="UserTextbox"/>
        <asp:Label Text="Email" CssClass="lblpass" runat="server" ID="EmailLabel" />

                <asp:Label ID="Label1" runat="server" Text="Email is already taken" Visible="false" ForeColor="red"></asp:Label>
        <asp:TextBox runat="server" CssClass="txtemail" OnTextChanged="EmailTextBox_TextChanged" AutoPostBack="true" placeholder="Enter Email" ID="EmailTextBox" TextMode="Email"/>

        <asp:Label Text="Password" CssClass="lblpass" runat="server" ID="PassLabel" />
        <asp:TextBox runat="server" CssClass="txtpass" placeholder="********" ID="PasswordTextBox"/>
        <asp:Label Text="Address" CssClass="lblemail" runat="server" ID="AddressLabel" />
        <asp:TextBox runat="server" CssClass="txtemail" placeholder="Enter Address" ID="AddressTextBox"/>
        <asp:Label Text="Phone/Telephone Number" CssClass="lblemail" runat="server" ID="NumberLabel" />
        <asp:TextBox runat="server" CssClass="txtemail" placeholder="Enter Phone/Telephone Number" ID="NumberTextBox"/>
        <asp:Label Text="Payment Method" CssClass="lblemail" runat="server" ID="PaymentLabel" />
        <asp:DropDownList ID="PaymentMethodList" runat="server" OnSelectedIndexChanged="PaymentMethodList_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem>Cash On Delivery</asp:ListItem>
            <asp:ListItem>Credit Card</asp:ListItem>
        </asp:DropDownList>
        <asp:Label Text="Credit Card Number" CssClass="lblemail" runat="server" ID="CCLabel" Visible="false"/>
        <asp:TextBox runat="server" CssClass="txtemail" placeholder="Enter Credit Card Number" ID="CCTextBox" Visible="false"/>
        <asp:Label Text="3-Digit Security Code" CssClass="lblemail" runat="server" ID="SCLabel" Visible="false" />
        <asp:TextBox runat="server" CssClass="txtemail" placeholder="Enter 3-Digit Security Code" ID="SCTextBox" Visible="false"/>
        <asp:Label Text="Expiry Date" CssClass="lblemail" runat="server" ID="ExpiryLabel" Visible="false" />
        <asp:DropDownList ID="MonthList" runat="server" Visible="false">
        </asp:DropDownList>
        <asp:DropDownList ID="YearList" runat="server" Visible="false">
        </asp:DropDownList>
        <asp:Button Text="Register" CssClass="btnsubmit" runat="server" ID="RegisterButton" OnClick="RegisterButton_Click"/>

   </ContentTemplate>
            </asp:UpdatePanel>
    </div>
    <div class="text-center">
     </div>




&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 




</asp:Content>
