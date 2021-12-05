<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="bestseller.aspx.cs" Inherits="mp.WebForm6" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .fixing_view{
            overflow-x:hidden; 
            overflow-y:auto; 
            removed:relative; 
            height: 500px;

        }
        .box {
            overflow-y: auto;
                background: rgba(200, 104, 42, 0.64);
        }
        .innerbox {
            width: 100%;
            height: 440px;
            box-sizing: border-box;
            background: rgba(27, 17, 5, 0.64);
            overflow-y: auto;
            columns:auto;
            background: rgba(0,0,0,0.5);
        }
        .buttonlink{
            font-size:16px;
            color: white;
            text-shadow: 0 0 10px #FFFFFF;
            font-family: Garamond, serif;
            font-size:22px;
        }
        .auto-style2 {
            width: 250px;
            height: 250px;
            text-align:center;
            box-shadow: 0px 0px 5px #fff;
        }
         .auto-style7{
             height:100px;
         }
         .auto-style8 {
             height: 78px;
         }
         .auto-style10 {
            Impact, fantasy;
            font-size:18px;
            color:deepskyblue;
            font-size:26px;
        }
        .auto-style11{
             height: 64px;
        }
        .autostyle12{
            overflow-y:hidden; 
            overflow-x:auto; 
            removed:relative; 
            width: 100%;
            text-align:center;
            scroll-padding:50px;
        }
        .autostyle13{
            font-family: Georgia, serif;
            color: #4cff00;
            text-shadow: 0 0 10px #FFFFFF;
            font-size:16px;
        }

     </style>
    <link href="bestsellersCSS.css" rel="stylesheet"/>

 <div class="fixing_view">

    <div class="box">
        <center>
        <img src="images/bestseller.png"alt="Alternate Text" class="auto-style7" /><img src="images/T1.png"alt="Alternate Text" class="auto-style11" /><img class="auto-style8" src="images/book.png" />
            </center>
        </div>
  
            <div class="innerbox">

                <div class="autostyle12">

            <asp:DataList ID="DataList3" OnItemCommand="DataList3_ItemCommand" OnItemDataBound="DataList3_ItemDataBound" DataSourceID="SqlDataSource2" runat="server" HorizontalAlign="Center" RepeatColumns="10" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <table>
                        <span class="auto-style10">
                         <strong>
                        <asp:Label ID="TopCount" runat="server"></asp:Label></span>
                        <tr>
                            <td>
                        <asp:LinkButton ID="LinkButton2" CssClass="buttonlink" CommandName="PassAuthor" CommandArgument='<%# Eval("Author_ID") %>' runat="server" Text='<%# Eval("Author_Name") %>'></asp:LinkButton>
                                </td>
                            </tr>
                        <tr>
                            <td>
                             <img src="images/<%# Eval("Author_Image") %>" class="auto-style2"/>
                                </td>
                        </tr>
                             <tr>
                                 <td>
                                     <span class="autostyle13">
                        <asp:Label ID="Label1" runat="server" Text="Books Sold:"></asp:Label><asp:Label ID="BookSoldCount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SalesCount").ToString() %>'></asp:Label>
                                            </strong></span></td>
                                 <td>
                        </td>
                        </tr>
                    </table>
                </ItemTemplate>

                <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />

            </asp:DataList>
                </div>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString2 %>"></asp:SqlDataSource>
        </div>


        <div class="box">
            <center>
            <img src="images/bestseller.png"alt="Alternate Text" class="auto-style7" /><img src="images/T2.png"alt="Alternate Text"class="auto-style11" /><img class="auto-style8" src="images/quill.png" />
                </center>
        </div>
            <div class="innerbox">
                                <div class="autostyle12">
            <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" DataSourceID="SqlDataSource1" OnItemDataBound="DataList1_ItemDataBound" HorizontalAlign="Center" RepeatColumns="10" RepeatDirection="Horizontal">
                <ItemTemplate>

                    <span class="auto-style10"><strong>
                    <asp:Label ID="lblTotal" runat="server"></asp:Label></span>
                    <br />
                        <asp:LinkButton ID="LinkButton1" CssClass="buttonlink" CommandName="SelectGenre" runat="server" Text='<%# Eval("Genre") %>' CommandArgument='<%# Eval("Genre") %>'></asp:LinkButton>
                        <br />
                    <img src="images/<%# Eval("Genre") %>.jpg" class="auto-style2"/>
                   
                    <br />
                        <span class="autostyle13">
                    <asp:Label ID="Label1" runat="server" Text="Books Sold:"></asp:Label>
                    <asp:Label ID="BookSoldCount" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BookCount") %>'></asp:Label></span>
                    <br />
                    </strong>
                </ItemTemplate>
            </asp:DataList>
                                    </div>
                </div>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString2 %>"></asp:SqlDataSource>

       
    </div>
</asp:Content>