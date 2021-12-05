<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GenrePage.aspx.cs" Inherits="mp.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            margin-left:auto;
            margin-right:auto;
            margin-top:0%;
            /*overflow-y:hidden; 
            overflow-x:scroll; 
            removed:relative; 
            width: 50%;*/
            overflow-x:hidden; 
            overflow-y:scroll; 
            removed:relative; 
            height: 520px;
            background: rgba(0,0,0,0.5);
        }

        .auto-style2 {
            width: 159px;
            height: 180px;
            text-align:center;
            box-shadow: 0px 0px 5px #fff;
        }
        
        .auto-style3 {
            width: 339px;
        }
        .auto-style9 {
            left: 0px;
            top: -50px;
            color: #FFFFFF;
        }
        .auto-style12 {
            width: 339px;
            left: 0px;
            top: -50px;
            height: 27px;
            font-size: 16px;
        }
        .auto-style13 {
            color: #000000;
            font-size: 16px;
        }
        .auto-style14 {
            color: #FFFFFF;
        }
        .auto-style15 {
            width: 339px;
            left: 0px;
            top: -50px;
            height: 56px;
            text-align: left;
        }
        .auto-style16 {
            font-size: medium;
        }

        .auto-style17 {
            color: #FFFFFF;
            font-size: large;
        }

        .auto-style18 {
            width: 339px;
            left: 0px;
            top: -50px;
            height: 27px;
            color: #FFFFFF;
            font-size: 16px;
        }

        .auto-style19 {
            color: #FFFFFF;
            font-size: 16px;
        }

        .auto-style20{
            background-color:lawngreen;
            font-family:'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
            
        }
        .topright {
          text-align:right;
          right:600px;
        }
        .checkboxstyle{
                        position:relative;
            top:120%;
            left:40%;
            right:30%;
        }
        .auto-style21 {
            text-align: center;
            right: 600px;
            font-size: small;
            color: #FFFFFF;
            background-color: #0066FF;
        }
        .auto-style22 {
            color: #FFFFCC;
        }
        .auto-style23 {
            color: #FFFFCC;
            font-size: 16px;
        }
        .tabstyle{
            background: rgba(0,0,0,0.5);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table class="tabstyle">
    <tr>
        <td>
                <strong>
                    <asp:Label ID="Label1" runat="server" Text="Filter By:" ForeColor="White" Font-Size="16px" CssClass="auto-style22"></asp:Label>&nbsp;</strong></td>
            <td><asp:CheckBoxList OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" ID="CheckBoxList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" CssClass="auto-style23">
                <asp:ListItem>Action</asp:ListItem>
                <asp:ListItem>Drama</asp:ListItem>
                <asp:ListItem>Fantasy</asp:ListItem>
                <asp:ListItem>Horror</asp:ListItem>
                <asp:ListItem>Mystery</asp:ListItem>
            </asp:CheckBoxList>
                </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
        <td>
                    <asp:RadioButtonList OnSelectedIndexChanged="SaleRadio_SelectedIndexChanged" ID="SaleRadio" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CssClass="auto-style19">
                        <asp:ListItem>Regular Price</asp:ListItem>
                        <asp:ListItem>On Sale</asp:ListItem>
                        <asp:ListItem Selected="True">Both</asp:ListItem>
        </asp:RadioButtonList>
            </td>
        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox CssClass="topright" ID="TextBox1" runat="server" Placeholder="Search by book title..." Width="145px"></asp:TextBox><strong><asp:Button CssClass="auto-style21"  ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" Width="85px" /></strong></td>
    </tr>
    </table>

        <div class="auto-style1">

        <asp:DataList ID="DataList1" runat="server" DataKeyField="Book_ID" OnItemDataBound="DataList1_ItemDataBound" OnItemCommand="DataList1_ItemCommand" DataSourceID="SqlDataSource1" RepeatColumns="5" CellPadding="5" ForeColor="#003300" GridLines="Both" HorizontalAlign="Center" RepeatDirection="Horizontal" Width="1480px" CssClass="auto-style9" style="margin-bottom: 0">
            <ItemTemplate>
                <table>
                    <asp:Label ID="Label4" runat="server" Visible="false" Text='<%# Eval("Book_ID") %>'></asp:Label>
                    <caption class="text-center">
                        <strong>
                            <asp:Label ID="Book_NameLabel" runat="server" Text='<%# Eval("Book_Name") %>' CssClass="auto-style17" />
                        </strong>
                        <br />
                            
                        <img src="images/<%# Eval("Book_Url") %>" class="auto-style2"/>
                        <caption class="text-center">
                            <tr>
                                <td class="auto-style19"><strong>Author:
                                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("Author_ID") %>' CommandName="AuthorRedirect" runat="server" Text='<%# Eval("Author_Name") %>'></asp:LinkButton>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style18"><strong>Genre:
                                    <asp:Label ID="GenreLabel" runat="server" Text='<%# Eval("Genre") %>' />
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style18"><strong>Price:
                                    <asp:Label ID="PriceLabel" runat="server" Text='<%#"₱"+Eval("Price").ToString() %>' />
                                    <asp:Label ID="SaleLabel" runat="server" Text='<%# Eval("Price_Status") %>' Visible="false"></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12"><strong><span class="auto-style14">Release Date: </span>
                                    <asp:Label ID="Release_DateLabel" runat="server" Text='<%# Eval("Release_Date").ToString().Split(Convert.ToChar(" "))[0] %>' CssClass="auto-style14" />
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style13">
                                    <strong>
                                    <asp:Label ID="Label3" runat="server" CssClass="auto-style14" Text="Stock:"></asp:Label>
&nbsp;<asp:Label CssClass="auto-style14" ID="StockLabel" runat="server" Text='<%# Eval("Stocks") %>'></asp:Label>
                                    </strong>
                                </td>
                            </tr>
                            <tr>
                                 <td class="auto-style15">
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                             <ContentTemplate>
                                     <strong>
                                     &nbsp;&nbsp;&nbsp;
                                     <asp:Label ID="Label2" runat="server" CssClass="auto-style16" ForeColor="White" Text="Quantity:"></asp:Label>
                                     <asp:DropDownList ID="DropDownList1" runat="server">
                                         <asp:ListItem>1</asp:ListItem>
                                         <asp:ListItem>2</asp:ListItem>
                                         <asp:ListItem>3</asp:ListItem>
                                         <asp:ListItem>4</asp:ListItem>
                                         <asp:ListItem>5</asp:ListItem>
                                     </asp:DropDownList>
                                       

                                     </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="AddToCart" CssClass="auto-style20" CommandArgument='<%# Eval("Book_Name") + ";" + Eval("Price") + ";" + Eval("Book_ID")%>' runat="server" CommandName="AddCart" Text="Add To Cart"/>
                                     </ContentTemplate>
                                     </asp:UpdatePanel>
                                </td>
                                
                            </tr>
                            
                        </caption>
                    </caption>
                        
                </table>
<br />
            </ItemTemplate>
        </asp:DataList>

           
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"  ConnectionString="<%$ ConnectionStrings:ZeroConnectionString2 %>"></asp:SqlDataSource>
        
</asp:Content>
