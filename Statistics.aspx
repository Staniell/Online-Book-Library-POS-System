<%@ Page Title="" Language="C#" MasterPageFile="~/backend_master.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="mp.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            color: #000000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="text-align:center">Current Statistics</h1>
    <h2 style="text-align:center">Orders</h2>
    <table class="tableCenter">
        <tr>
            <td>
                <table class="tableCenter">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Total Revenue:" CssClass="auto-style3"></asp:Label> 
                            <br />
                            <asp:Label ID="Label3" runat="server" Text="Total Books Sold:" CssClass="auto-style3"></asp:Label>
                            <br />
                            <asp:Label ID="Label5" runat="server" Text="Total Successful Orders:" CssClass="auto-style3"></asp:Label>
                            <br />
                            <asp:Label ID="Label7" runat="server" Text="Total Unique Orders:" CssClass="auto-style3"></asp:Label>
                            <br />
                            <asp:Label ID="Label9" runat="server" Text="Total Cancelled Items:" CssClass="auto-style3"></asp:Label>
                            <br />
                            <asp:Label ID="Label10" runat="server" Text="Total Price of Cancelled Items:" CssClass="auto-style3"></asp:Label>
                            <br />
                            <asp:Label ID="Label11" runat="server" Text="Total Cancelled Orders:" CssClass="auto-style3"></asp:Label>
                            <br />
                            <asp:Label ID="Label12" runat="server" Text="Total Unique Cancelled Orders:" CssClass="auto-style3"></asp:Label>
                            <br />
                            <asp:Label ID="Label13" runat="server" Text="Total Books to be Delivered:" CssClass="auto-style3"></asp:Label>
                            <br />
                            <asp:Label ID="Label14" runat="server" Text="Total Price of Ongoing Deliveries:" CssClass="auto-style3"></asp:Label>
                            <br />
                            <asp:Label ID="Label15" runat="server" Text="Total Ongoing Orders:" CssClass="auto-style3"></asp:Label>
                            <br />
                            <asp:Label ID="Label16" runat="server" Text="Total Unique Ongoing Orders:" CssClass="auto-style3"></asp:Label>


                            </td>
                       <td>                <strong>
                <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#"₱"+ DataBinder.Eval(Container.DataItem, "Total_Pricex").ToString() %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Quantityx").ToString() %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("Counterx") %>'></asp:Label>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("uniquecounter") %>'></asp:Label>
                    </ItemTemplate>
                </asp:DataList>
                           <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource2">
                               <ItemTemplate>
                                   <asp:Label ID="Column1Label" runat="server" Text='<%# Eval("lostqty") %>' />
                                   <br />
                                   <asp:Label ID="Column2Label" runat="server" Text='<%# Eval("lostrev") %>' />
                                   <br />
                                   <asp:Label ID="CounterxLabel" runat="server" Text='<%# Eval("lostorder") %>' />
                                   <br />
                                   <asp:Label ID="Column3Label" runat="server" Text='<%# Eval("lostunique") %>' />
                                   <br />

                               </ItemTemplate>
                           </asp:DataList>
                           <asp:DataList ID="DataList3" runat="server" DataSourceID="SqlDataSource3">
                               <ItemTemplate>
                                   <asp:Label ID="Column1Label" runat="server" Text='<%# Eval("Column1") %>' />
                                   <br />
                                   <asp:Label ID="Column2Label" runat="server" Text='<%# Eval("Column2") %>' />
                                   <br />
                                   <asp:Label ID="CounterxLabel" runat="server" Text='<%# Eval("Counterx") %>' />
                                   <br />
                                   <asp:Label ID="Column3Label" runat="server" Text='<%# Eval("Column3") %>' />
                                   <br />
                               </ItemTemplate>
                           </asp:DataList>

                           <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>"></asp:SqlDataSource>

                </strong></td>
                        </tr>
                    <tr>
                          <td>
                <h2>Books</h2></td>
                        </tr>
                    <tr>
                        <td>
                <asp:Label ID="Label17" runat="server" Text="Total Books:"></asp:Label>
                            <br />
                            <asp:Label ID="Label19" runat="server" Text="Total Authors:"></asp:Label>
            </td>
            <td>
                <asp:DataList ID="DataList4" runat="server" DataSourceID="SqlDataSource4" CssClass="auto-style3">
                    <ItemTemplate>
                        <strong>
                        <asp:Label ID="counterxLabel" runat="server" Text='<%# Eval("counterx") %>' />
                        <br />
                        <asp:Label ID="Label18" runat="server" Text='<%# Eval("countery") %>'></asp:Label>
                            </strong>
                        <br />
                    </ItemTemplate>
                </asp:DataList>
         

            </td>
                    </tr>
                    <tr>
                          <td>
                <h2>Accounts</h2></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="Active Accounts:"></asp:Label>
                            <br />
                            <asp:Label ID="Label21" runat="server" Text="Deactivation Requests:"></asp:Label>
                        </td>
                        <td>
                            <asp:DataList ID="DataList5" runat="server" DataSourceID="SqlDataSource5">
                                <ItemTemplate>
                                    <strong>
                                    <asp:Label ID="counterxLabel" runat="server" Text='<%# Eval("counterx") %>' /></strong>
                                    <br />
                                </ItemTemplate>
                            </asp:DataList>
                            <asp:DataList ID="DataList6" runat="server" DataSourceID="SqlDataSource6">
                                <ItemTemplate>
                                  <strong><asp:Label ID="counterxLabel" runat="server" Text='<%# Eval("counterx") %>' /></strong>
                                    <br />                        </ItemTemplate>
                            </asp:DataList>
                            <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>" SelectCommand="SELECT Count(1) as counterx FROM REGistered where Account_Status ='To Be Deactivated'"></asp:SqlDataSource>
                        </td>
                    </tr>
                    </table>
            </td>

        </table>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>" SelectCommand="SELECT Count(1) as counterx FROM REGistered where Account_Status ='Active'"></asp:SqlDataSource>
</asp:Content>
