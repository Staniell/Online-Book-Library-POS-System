<%@ Page Title="" Language="C#" MasterPageFile="~/backend_master.Master" AutoEventWireup="true" CodeBehind="ManageAccount.aspx.cs" Inherits="mp.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 63px;
        }
        .auto-style2 {
            width: 4%;
        }
        .auto-style3 {
            width: 32px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
     <table class="tableCenter">
                 <tr>
                     <td style="width: 20%;">
                         <h1>Deactivation Requests</h1>
                     </td>
                     <td class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                     <td class="auto-style2"><h1>Forgotten Password</h1></td>
                     <td class="auto-style3"></td>
                     <td style="width: 20%;">
                         <h1>Accounts To Be Deleted</h1>
                     </td>
                 </tr>
                 <tr>
                     <td style="margin-left:auto; margin-right:auto;">
             <asp:GridView ID="GridView1" runat="server" PageSize="10" OnSorting="GridView1_Sorting" OnPageIndexChanging="GridView1_PageIndexChanging" HorizontalAlign="Center" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="Username" DataSourceID="SqlDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                 <Columns>
                     <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
                     <asp:BoundField DataField="Payment_Method" HeaderText="Payment_Method" SortExpression="Payment_Method" />
                     <asp:BoundField DataField="Account_Status" HeaderText="Account_Status" SortExpression="Account_Status" />
                     <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxItem" runat="server" />
                    </ItemTemplate>
                 </asp:TemplateField>
                 </Columns>

                 <FooterStyle BackColor="DarkOrange" />
                 <HeaderStyle BackColor="DarkOrange" Font-Bold="True" ForeColor="Black" />
                 <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" />
                 <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                 <SortedAscendingHeaderStyle BackColor="#808080" />
                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                 <SortedDescendingHeaderStyle BackColor="#383838" />

             </asp:GridView>
                         <td class="auto-style1"></td>
                         </td>
                     <td class="auto-style2">
                         <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                             <Columns>
                                 <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                 <asp:BoundField DataField="Passwordx" HeaderText="Passwordx" SortExpression="Passwordx" />
                                 <asp:BoundField DataField="Account_Status" HeaderText="Account_Status" SortExpression="Account_Status" />
                                                              <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="checkItems" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                             </Columns>
                                            <FooterStyle BackColor="DarkOrange" />
                 <HeaderStyle BackColor="DarkOrange" Font-Bold="True" ForeColor="Black" />
                 <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                 <RowStyle BackColor="White" />
                 <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#F1F1F1" />
                 <SortedAscendingHeaderStyle BackColor="#808080" />
                 <SortedDescendingCellStyle BackColor="#CAC9C9" />
                 <SortedDescendingHeaderStyle BackColor="#383838" />
                         </asp:GridView>


                         
                     </td>

                     <td class="auto-style3">&nbsp; &nbsp;</td>
                     <td><asp:GridView ID="GridView2" OnSorting="GridView2_Sorting" OnPageIndexChanging="GridView2_PageIndexChanging" HorizontalAlign="Center" PageSize="10" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" DataKeyNames="Username" CellPadding="4" CellSpacing="2" ForeColor="Black">
                         <Columns>
                             <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" SortExpression="Username" />
                             <asp:BoundField DataField="Account_Status" HeaderText="Account_Status" SortExpression="Account_Status" />
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxItem" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                         </Columns>

                         <FooterStyle BackColor="#CCCCCC" />
                         <HeaderStyle BackColor="DarkOrange" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
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
                    <strong>
                    <asp:Button ID="CancelButton" runat="server" OnClick="CancelButton_Click" Text="Process Account" CssClass="btnsubmit" Width="300px" />
                    </strong>
                     </td>
                     <td class="auto-style1"></td>
                     <td class="auto-style2">
                         <asp:Button ID="passwordsentbutton" OnClick="passwordsentbutton_Click" CssClass="btnsubmit" runat="server" Text="Password Sent" />
                     </td>
                     <td class="auto-style3"></td>
                     <td><strong>
                         <asp:Button ID="DeleteButton" runat="server" CssClass="btnsubmit" OnClick="DeleteButton_Click" Text="Delete Account" Width="300px" />
                         </strong></td>
                 </tr>
                 </table>
            </ContentTemplate>
        </asp:UpdatePanel>
             <br />
             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>"></asp:SqlDataSource>
              <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>"></asp:SqlDataSource>
</asp:Content>

