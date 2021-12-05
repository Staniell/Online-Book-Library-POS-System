<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="mp.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .GridStyle {
            border:none;
            border-bottom:3px solid #fff;
            outline:none;
            height:40px;
            color:#fff;
            font-size:16px;
            font-weight:bold;
            background-color:transparent;
            padding-top:10px;
        }
        .auto-style8 {
            color: #FFFFFF;
            font-size: large;
        }
        .auto-style9 {
            border:none;
            outline:none;
            height:40px;
            font-size:16px;
            font-family:'Lucida Calligraphy';
            font-weight:bold;
            color:rgb(58, 3, 3);
            background-color: rgb(255, 106, 0);
            cursor:pointer;
            border-radius:20px;
            transition:.3s ease-in-out;
        }
        .auto-style11 {
            font-size: 8pt;
        }
        .container-fluid#My_Cart{
            background-color: rgba(200, 104, 42, 0.64);
        }
        .container-fluid#box{
            background-color: rgba(27, 17, 5, 0.64);
            overflow-y:auto;
        }
        .GrandStyle, .ETAStyle{
            border:none;
            border-bottom:3px solid #fff;
            outline:none;
            height:40px;
            color:#fff;
            font-size:16px;
            font-weight:bold;
            background-color:transparent;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div id="My_Cart" class="container-fluid">
        <img src="images/cart.png" style="height:100px"><img src="images/My_Cart.png" style="height:100px">
    </div>
    

    <div id="box" class="container-fluid">
    <div class="text-center">
    <center>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:GridView ID="GridView1" DataKeyNames="Book_ID" runat="server" CssClass="GridStyle" Height="186px" Width="458px" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" PageSize="5" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowDeleting="GridView1_RowDeleting" >
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" DeleteText="Remove" >
            <ControlStyle BackColor="#CC0000" ForeColor="White" />
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />

    </asp:GridView>
                                        </ContentTemplate>
    </asp:UpdatePanel>
        </center>

    </div>


        <center>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>

    &nbsp;&nbsp; <strong>
    <asp:Label ID="Label2" runat="server" CssClass="auto-style8" Text="ETA:"></asp:Label>
    </strong>
    <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" CssClass="ETAStyle"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>
    <asp:Label ID="Label1" runat="server" CssClass="auto-style8" Text="Grand Total:"></asp:Label>
    </strong>

    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" CssClass="GrandStyle"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Order" runat="server" CssClass="auto-style9" OnClick="Order_Click" Text="Complete Order" />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="auto-style11">\</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>

</asp:Content>