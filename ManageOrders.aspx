<%@ Page Title="" Language="C#" MasterPageFile="~/backend_master.Master" AutoEventWireup="true" CodeBehind="ManageOrders.aspx.cs" Inherits="mp.WebForm11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
              <table class="tableCenter">
                 <tr>
                     <td>
                         <asp:Label ID="Historylbl" runat="server" Text="Ongoing Orders" Font-Size="32px" ForeColor="Black" Font-Bold="True"></asp:Label>
                     </td>
                 </tr>


                 <tr>

                     <td>

                         <strong>
            <asp:TextBox ID="NameTextBox" runat="server" Placeholder="Search by username..."></asp:TextBox><asp:Button ID="SearchButton" OnClick="SearchButton_Click" runat="server" Text="Search" CssClass="btnsubmit" Height="30px" Width="80px" />
                </strong>

                     </td>
                 </tr>
                 <tr>
                     <td>
                         

                         <asp:GridView ID="GridView1" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" HorizontalAlign="Center" runat="server" AllowSorting="True" AutoGenerateColumns="False" Horizontal-Align="Center" DataSourceID="SqlDataSource2" Height="229px" Width="1105px" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="2" ForeColor="Black" AllowPaging="True">
                 <Columns>
                     <asp:BoundField DataField="Order_ID" HeaderText="Order ID" SortExpression="Order_ID" />
                     <asp:BoundField DataField="Book_ID" HeaderText="Book ID" SortExpression="Book_ID" />
                     <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                     <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                     <asp:BoundField DataField="Total_Price" HeaderText="Total Price" SortExpression="Total_Price" />
                     <asp:BoundField DataField="Payment_Method" HeaderText="Payment Method" SortExpression="Payment_Method" />
                     <asp:BoundField DataField="Date_Purchased" HeaderText="Date Purchased" SortExpression="Date_Purchased" />
                     <asp:BoundField DataField="ETA" HeaderText="ETA" SortExpression="ETA" />
                     <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                     <asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="Reason" />
                  <asp:TemplateField HeaderStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxItem" runat="server" />
                    </ItemTemplate>
                 </asp:TemplateField>
                 </Columns>

                    <FooterStyle BackColor="#CCCCCC" />
                             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                 <HeaderStyle BackColor="DarkOrange" Font-Bold="True" ForeColor="Black" />
                 <RowStyle BackColor="White" />
                 <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                 <SortedAscendingHeaderStyle BackColor="#808080" />
                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                 <SortedDescendingHeaderStyle BackColor="#383838" />

                    </asp:GridView>

                     </td>
                 </tr>

                 <tr>

                     <td>
                         <br />
                    <strong>
                    <asp:Button ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Canceled" BackColor="#FF6600" CssClass="btnsubmit" Width="200px" />
                        <asp:Button ID="RejectButton" runat="server" OnClick="RejectButton_Click" Text="Reject Request" BackColor="orange" CssClass="btnsubmit" Width="200px" />
                    <asp:Button ID="DeliveredButton" runat="server" OnClick="DeliveredButton_Click" Text="Delivered" BackColor="#66FF99" CssClass="btnsubmit" Width="200px" />
                    </strong>

                     </td>

                 </tr>
             </table>
    </ContentTemplate>
   </asp:UpdatePanel>
             <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>"></asp:SqlDataSource> 
</asp:Content>