<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="mp.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 251px;
        }
        .auto-style4 {
            width: 443px;
        }
        .auto-style6 {
            width: 251px;
            height: 27px;
        }
        .auto-style7 {
            height: 27px;
        }
        .auto-style8 {
            width: 226px;
        }
        .auto-style9 {
            width: 226px;
            height: 27px;
        }
        .auto-stylel0{
            position:absolute;
            top:120%;
            left:20%;
            right:200%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="accountCSS.css" rel="stylesheet"/>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="box">

         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
         <div class="innerbox">
             <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" OnItemDataBound="DataList1_ItemDataBound" DataKeyField="Username" DataSourceID="SqlDataSource1">
                 <ItemTemplate>       
             <img src="images/act.png" alt="Alternate Text" class="user"/>
             <table style="font-family: 'Century Gothic'; font-size: medium; font-weight: bold; position: absolute; top: 35px; left:14%; text-align: center;">
            <tr><td style="font-family: 'Britannic Bold'; color: #CCFFCC; text-decoration: underline; font-size: large;">MY PROFILE</td></tr>
            <tr>
                <td  style="font-family: 'Britannic Bold'; color: #CCFF99;">Account Name:&nbsp; </td>
                <td >
                    <asp:Label ID="LabelName" runat="server" Text='<%# Eval("Username") %>' ForeColor="White"></asp:Label>
                </td>
                <td ></td>
                <td ></td>
            </tr>
            <tr>
                <td style="font-family: 'Britannic Bold'; color: #CCFF99;">Email:</td>
                <td >
                    <asp:Label ID="LabelEmail" runat="server" Text='<%# Eval("Email") %>' ForeColor="White"></asp:Label>
                </td>
                <td >
                    <asp:LinkButton ID="EmailButton" CommandName="ChangeEmail" runat="server" Text="Change Email"></asp:LinkButton>
                    <asp:TextBox ID="EmailTextBox" Visible="false" runat="server" Placeholder="Enter New Email Address" TextMode="Email"></asp:TextBox>
                </td>
                <td ><asp:Button ID="EmailUpdate" CommandName="EmailUpdate" runat="server" Visible="false" Text="Update" />
                    <asp:Button ID="Button1" CommandName="Cancel1" runat="server" Visible="false" Text="Cancel"/>
                </td>
            </tr>
            <tr>
                <td style="font-family: 'Britannic Bold'; color: #CCFF99;">Address:</td>
                <td ><asp:Label ID="LabelAddress" runat="server" Text='<%# Eval("Address") %>' ForeColor="White"></asp:Label></td>
                <td >
                    <asp:LinkButton ID="AddressButton" CommandName="ChangeAddress" runat="server" Text="Change Address"></asp:LinkButton>
                    <asp:TextBox ID="AddressTextBox" Visible="false" runat="server" Placeholder="Enter New Home Address"></asp:TextBox>
                </td>
                <td ><asp:Button ID="AddressUpdate" CommandName="AddressUpdate" runat="server" Visible="false" Text="Update" />
                    <asp:Button ID="Button2" CommandName="Cancel2" runat="server" Visible="false" Text="Cancel" />
                </td>
            </tr>
                      <tr>
                <td style="font-family: 'Britannic Bold'; color: #CCFF99;">Phone/Telephone No.:</td>
                <td ><asp:Label ID="Label1" runat="server" Text='<%# Eval("Number") %>' ForeColor="White"></asp:Label></td>
                <td >
                    <asp:LinkButton ID="PhoneButton" CommandName="ChangePhone" runat="server" Text="Change Number"></asp:LinkButton>
                    <asp:TextBox ID="PhoneTextBox" Visible="false" runat="server" Placeholder="Enter New Phone/Telephone No." TextMode="Phone"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="PhoneUpdate" CommandName="PhoneUpdate" runat="server" Text="Update" visible="false" />
                    <asp:Button ID="Button3" CommandName="Cancel3" runat="server" Visible="false" Text="Cancel"/>
                </td>
            </tr>
            <tr>
                <td style="font-family: 'Britannic Bold'; color: #CCFF99;">Password:</td>
                <td><asp:Label ID="Labelpass" runat="server" Text='<%# Eval("Passwordx") %>' ForeColor="White"></asp:Label></td>
                <td><asp:LinkButton ID="PasswordButton" CommandName="ChangePassword" runat="server" Text="Change Password"></asp:LinkButton>
                    <asp:TextBox ID="PasswordTextBox" Visible="false" runat="server" Placeholder="Enter New Password"></asp:TextBox></td>
                    <td><asp:Button ID="PasswordUpdate" CommandName="PasswordUpdate" runat="server" Text="Update" Visible="false"/>
                        <asp:Button ID="Button4" CommandName="Cancel4" runat="server" Visible="false" Text="Cancel"/>
                    </td>
            </tr>
            <tr>
                <td style="font-family: 'Britannic Bold'; color: #CCFFCC; text-decoration: underline; font-size: large;">BILLING INFORMATION</td>
            </tr>
            <tr>
                <td style="font-family: 'Britannic Bold'; color: #CCFF99;">Payment Method:</td>
                <td ><asp:Label ID="LabelPayment" runat="server" Text='<%# Eval("Payment_Method") %>' ForeColor="White"></asp:Label></td>
                <td>
                    <asp:LinkButton ID="PaymentButton" CommandName="ChangePayment" runat="server" Text="Change Payment Method"/>
                </td>
            </tr>

        </table>
            <%-- <img src="images/vines.png" alt="Alternate Text" style="width: 200px; height: 390px; top:-12% ;left: 800px; position: absolute;"/>--%>
      
                 </ItemTemplate>
             </asp:DataList>

            
             <table style="margin-top:15%;">
                 <tr>
                     <td>
            
             <asp:TextBox ID="CCText1" runat="server" Visible="false" Placeholder="Enter New Credit Card No."></asp:TextBox>
              <asp:TextBox ID="SCText1" runat="server" Visible="false" Placeholder="Enter New Security Card No."></asp:TextBox>

             <asp:DropDownList ID="PaymentList" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="PaymentList_SelectedIndexChanged" runat="server">
            <asp:ListItem Text="Cash On Delivery" Value="Cash On Delivery"></asp:ListItem>
            <asp:ListItem Text="Credit Card" Value="Credit Card"></asp:ListItem>
            </asp:DropDownList>
                         </td>
                     </tr>
                     <tr>
                     <td>
                         <asp:Label ID="Label2" runat="server" Text="Expiry Date" Visible="false" ForeColor="White" Font-Size="16px"></asp:Label>
             <asp:DropDownList ID="MonthList" runat="server" Visible="false"></asp:DropDownList>
             <asp:DropDownList ID="YearList" runat="server" Visible="false"></asp:DropDownList>
          <asp:Button ID="PaymentUpdate" OnClick="PaymentUpdate_Click" Visible="false" runat="server" Text="Update" /><asp:Button ID="Button5" OnClick="Button5_Click" Visible="false" runat="server" Text="Cancel" />
                         </td>
                         <td></td>
                         <td><asp:Button ID="Button6" OnClick="Button6_Click" runat="server" Text="Deactivate Account" /></td>
                     </tr>
                 </table>
             
                 

         </div>
                 </ContentTemplate>
             </asp:UpdatePanel>

         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString2 %>"></asp:SqlDataSource>

         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
             <ContentTemplate>

         <div style="position: absolute; top: 70%; padding-left:5%; padding-right:10%; padding-bottom:10%;">
             <table>
                 <tr>
                     <td>
             <center><asp:Label ID="Historylbl" runat="server" Text="ORDER HISTORY" Font-Size="32px" ForeColor="White" Font-Bold="True"></asp:Label></center>

             <asp:GridView ID="GridView1" runat="server" Height="100px" Width="1000px" OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                 <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="Order_ID" HeaderText="Order ID" ReadOnly="True" SortExpression="Order_ID" InsertVisible="False" />
                    <asp:BoundField DataField="Book_Name" HeaderText="Book Name" SortExpression="Book_Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:BoundField DataField="Total_Price" HeaderText="Total Price" SortExpression="Total_Price" />
                    <asp:BoundField DataField="Payment_Method" HeaderText="Payment Method" SortExpression="Payment_Method" />
                    <asp:BoundField DataField="Date_Purchased" HeaderText="Date Purchased" SortExpression="Date_Purchased" />
                    <asp:BoundField DataField="ETA" HeaderText="ETA" SortExpression="ETA"/>
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="CancelButton" OnClick="CancelButton_Click" Visible="false" runat="server" Text="Cancel"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <RowStyle Height="28"/>
                <HeaderStyle BackColor="DarkOrange" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True"  />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
             </asp:GridView>
                         </td>
                     <td>
                         <div runat="server" id="cancellation_formx" visible="false">
                         <table>

                             <tr>
                                 <td>
                                     <br />
                         <asp:Label ID="Label4" Font-Bold="true" Font-Size="14px" runat="server" ForeColor="White" Text="Order ID:"></asp:Label></td>
                         <td><asp:TextBox ID="OrderIDBox" Enabled="false"  runat="server"></asp:TextBox></td>
                         </tr>
                             <tr>
                        <td><asp:Label ID="Label5" Font-Bold="true" Font-Size="14px" runat="server" ForeColor="White" Text="Book Name:"></asp:Label></td>
                         <td><asp:TextBox ID="BookNameBoxz" runat="server" Enabled="false" Text="Label"></asp:TextBox></td>
                         </tr>
                                 <tr>
                       <td><asp:Label ID="Label6" Font-Bold="true" Font-Size="14px" runat="server" ForeColor="White" Text="Quantity:"></asp:Label></td>  
                         <td><asp:TextBox ID="QuantityBoxz" runat="server" Enabled="false" Text="Label"></asp:TextBox></td>  
                         </tr>
                                     <tr>
                         <td><asp:Label ID="Label7" Font-Bold="true" Font-Size="14px" runat="server" ForeColor="White" Text="Total Price:"></asp:Label></td> 
                      <td><asp:TextBox ID="PriceBoxz" runat="server" Enabled="false" Text="Label"></asp:TextBox></td>
                         </tr>
                     <tr>
                         <td>
                         <asp:Label ID="Label8" Font-Bold="true" Font-Size="14px" runat="server" ForeColor="White" Text="Reason for Cancellation:"></asp:Label></td>
                         <td><asp:TextBox ID="ReasonTxtBoxz" runat="server"></asp:TextBox></td>
                         </tr>
                 <tr>
                     <td></td>
                     <td>
                         <br />
                         <asp:Button ID="CancelOrderButton" OnClick="CancelOrderButton_Click" runat="server" ForeColor="White" BackColor="Red" Font-Bold="true" Font-Size="16px" CssClass="btnsubmit" Text="Cancel Order" /></td>
                       </tr>          
                             </table>
                             </div>
                     </td>
                     </tr>
                 </table>
         </div>
                 </ContentTemplate>
             </asp:UpdatePanel>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString2 %>" SelectCommand="SELECT Order_ID,Book_Name, Quantity, Total_Price, Sales.Payment_Method, Date_Purchased, ETA, Status FROM Sales LEFT JOIN Registered on Sales.Username = Registered.Username RIGHT JOIN Book on Book.Book_ID = Sales.Book_ID WHERE Sales.Username = @Name  ORDER BY Date_Purchased DESC">
        <SelectParameters>
            <asp:SessionParameter Name="Name" SessionField="Name" />
        </SelectParameters>
         </asp:SqlDataSource>

     </div>
</asp:Content>

