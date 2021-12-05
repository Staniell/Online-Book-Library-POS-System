<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="mp.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .wholecontainer{
            overflow-y:auto;
            overflow-x:hidden
        }

        .fixing_view{
            overflow-x:hidden; 
            overflow-y:scroll; 
            removed:relative; 
            height: 560px;

        }
        .innerbox {
            width: 100%;
            height: 500px;
            box-sizing: border-box;
            background: rgba(27, 17, 5, 0.64);
            overflow-y: auto;
            overflow-x:hidden;
            columns:auto;
            background: rgba(0,0,0,0.5);
        }
        .auto-style1 {
            width: 100%;
            height: 500px;
            box-sizing: border-box;
            background: rgba(27, 17, 5, 0.64);
            overflow-y: hidden;
            columns:auto;
            background: rgba(0,0,0,0.5);
            overflow-x:hidden;
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
        .autostyle21{
            overflow-y:hidden; 
            overflow-x:scroll; 
            removed:relative; 
            width: 100%;
            text-align:center;
            height:97%;
        }

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <link href="HomeCSS.css" rel="stylesheet" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

<div class="fixing_view">

     <div class="container" >
        <div id="myCarousel" class="carousel slide" data-ride="carousel">
  <!-- Indicators -->
  <ol class="carousel-indicators" style="text-align: center; width: 100%;">
    <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
    <li data-target="#myCarousel" data-slide-to="1"></li>
    <li data-target="#myCarousel" data-slide-to="2"></li>
  </ol>


  <!-- Wrapper for slides -->
  <div class="carousel-inner" style="top: 10px">
    <div class="item active" >
        <center>
        <asp:ImageButton ID="ImageButton2" OnClick="ImageButton2_Click" src="images/new1.png" height ="60%" width ="60%" margin="auto" runat="server" />
            </center>
<%--      <img class="d-block mx-auto" src="images/new1.png" height="300" width ="533">--%>
    </div>

    <div class="item">
      <img class="d-block mx-auto" src="images/2.png" height ="300" width ="533">
    </div>

    <div class="item">
        <center>
        <asp:ImageButton class="d-block mx-auto" height ="60%" width ="60%" margin="auto" OnClick="ImageButton1_Click" ID="ImageButton1" ImageUrl="images/3.png" runat="server" />
            </center>
    </div>
  </div>
                
  <!-- Left and right controls -->
  <a class="left carousel-control" href="#myCarousel" data-slide="prev" style="height: 105%">
    <span class="glyphicon glyphicon-chevron-left"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="right carousel-control" href="#myCarousel" data-slide="next" style="height: 105%">
    <span class="glyphicon glyphicon-chevron-right"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
         
</div>

   
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js">
    </script>
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function (){
            $('#imageCarousel').carousel();
        });
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div>
      <center><asp:Label ID="Label4" runat="server" ForeColor="FloralWhite" Font-Size="22px" Text="FEATURED BOOKS"></asp:Label></center>
    <div class="innerbox">
        <div class="autostyle21">
        <%--RECENTLY RELEASED BOOKS--%>
    <asp:DataList ID="DataList2" runat="server" OnItemCommand="DataList2_ItemCommand" OnItemDataBound="DataList2_ItemDataBound" DataSourceID="SqlDataSource2" RepeatColumns="10" CellPadding="5" ForeColor="#003300" GridLines="Both" HorizontalAlign="Center" RepeatDirection="Horizontal" Width="3000px" CssClass="auto-style9" style="margin-bottom: 0">
        
               <ItemTemplate>
                <table>
                    <caption class="text-center">
                        <asp:Label ID="bID" runat="server" Visible="false" Text='<%# Eval("Book_ID") %>'></asp:Label>
                        <strong>
                            <asp:Label ID="Book_NameLabel" runat="server" Text='<%# Eval("Book_Name") %>' CssClass="auto-style17" />
                        </strong>
                        <br />
                            
                        <img src="images/<%# Eval("Book_Url") %>" class="auto-style2"/>
                        <caption class="text-center">
                            <tr>
                                <td class="auto-style19"><strong>Author:
                                    <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("Author_ID") %>' CommandName="AuthorRedirect" runat="server" Text='<%# Eval("Author_Name") %>'></asp:LinkButton>
                                    <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Author_Name") %>' />--%>
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
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                         <ContentTemplate>
                                     <strong>
                                     &nbsp;&nbsp;&nbsp;
                                     <asp:Label ID="Label25" runat="server" CssClass="auto-style16" ForeColor="White" Text="Quantity:"></asp:Label>
                                     <asp:DropDownList ID="DropDownList1" runat="server">
                                         <asp:ListItem>1</asp:ListItem>
                                         <asp:ListItem>2</asp:ListItem>
                                         <asp:ListItem>3</asp:ListItem>
                                         <asp:ListItem>4</asp:ListItem>
                                         <asp:ListItem>5</asp:ListItem>
                                     </asp:DropDownList>
                                     </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="AddToCart2" CssClass="auto-style20" CommandArgument='<%# Eval("Book_Name") + ";" + Eval("Price") + ";" + Eval("Book_ID")%>' runat="server" CommandName="AddCart" Text="Add To Cart"/>
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

        
                    </div>
            


    </div>

    <div>
        <center><asp:Label ID="Label5" runat="server" ForeColor="FloralWhite" Font-Size="22px" Text="RECENTLY RELEASED BOOKS"></asp:Label></center>
        <div class="innerbox">
            <div class="autostyle21">
                <asp:DataList ID="DataList1" runat="server" DataKeyField="Book_ID" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound" DataSourceID="SqlDataSource1" RepeatColumns="10" CellPadding="5" ForeColor="#003300" GridLines="Both" HorizontalAlign="Center" RepeatDirection="Horizontal" Width="3000px" CssClass="auto-style9" style="margin-bottom: 0">
       <ItemTemplate>
                <table>
                    <asp:Label ID="Label14" runat="server" Visible="false" Text='<%# Eval("Book_ID") %>'></asp:Label>
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
                                    <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("Author_Name") %>' />--%>
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
                                     <asp:Label ID="Label21" runat="server" CssClass="auto-style16" ForeColor="White" Text="Quantity:"></asp:Label>
                                     <asp:DropDownList ID="DropDownList12" runat="server">
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
        </div>
    </div>


     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString2 %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString2 %>"></asp:SqlDataSource>
       </div>
    
</asp:Content>
