<%@ Page Title="" Language="C#" MasterPageFile="~/backend_master.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="mp.WebForm12" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<table class="productList" style="width: 100%;">
        <tr>
            <td>
                <h1>Product List</h1>
            </td>
        </tr>
        <tr>
            <td>
                <table class="productList">

                    <tr>

                        <td>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
<asp:GridView ID="GridViewProductList" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyNames="Book_ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="Book_ID" HeaderText="Book ID" ReadOnly="True" SortExpression="Book_ID" />
                    <asp:BoundField DataField="Book_Name" HeaderText="Book Name" SortExpression="Book_Name" />
                    <asp:BoundField DataField="Author_ID" HeaderText="Author ID" SortExpression="Author_ID" />
                    <asp:BoundField DataField="Genre" HeaderText="Genre" SortExpression="Genre" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Release_Date" HeaderText="Release Date" SortExpression="Release_Date" DataFormatString = "{0:yyyy-MM-dd}"/>
                    <asp:BoundField DataField="Stocks" HeaderText="Stocks" SortExpression="Stocks" />
                    <asp:BoundField DataField="Price_Status" HeaderText="Price Status" SortExpression="Price_Status" />
                    <asp:BoundField DataField="Sold_Books" HeaderText="Sales" SortExpression="Sold_Books" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBoxItem" runat="server" />
                                <asp:Button ID="LinkButton1" style="height: 20px; font-size: 16px;" OnClick="LinkButton1_Click" CssClass="btnsubmit" Width="80" Height="20" runat="server" Text="Update"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <RowStyle Height="20"/>
                <HeaderStyle BackColor="DarkOrange" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True"  />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
            </ContentTemplate>
            </asp:UpdatePanel>
            
                        </td>
                        <td>

                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                    <div runat="server" id="updateBooks" visible="false">
                        <h2>Update Book</h2>
                    <table>
                        <tr>
                            <td style="text-align: right"><strong><asp:Label ID="Label4" runat="server" Text="Book ID" ></asp:Label></strong></td>
                            <td style="text-align: justify"><asp:TextBox ID="bookIDtxt" runat="server" Enabled="False"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align: right"><strong><asp:Label ID="Label5" runat="server" Text="Book Name" ></asp:Label></strong></td>
                            <td style="text-align: justify"><asp:TextBox ID="booknametxt" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="booknametxtRFV" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ValidationGroup="updateBookInfo" Display="Dynamic" ControlToValidate="booknametxt"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right"><strong><asp:Label ID="Label6" runat="server" Text="Author ID" ></asp:Label></strong></td>
                            <td style="text-align: justify"><asp:TextBox ID="authoridtxtbox" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="authoridtxtboxRFV" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ValidationGroup="updateBookInfo" Display="Dynamic" ControlToValidate="authoridtxtbox"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right"><strong><asp:Label ID="Label7" runat="server" Text="Genre" ></asp:Label></strong></td>
                            <td style="text-align: justify">
                                <asp:Panel runat="server" ID="genreCheckbox1">
                                    <asp:CheckBox ID="action1" runat="server" Text="Action" />
                                    <br />
                                    <asp:CheckBox ID="mystery1" runat="server" Text="Mystery" />
                                    <br />
                                    <asp:CheckBox ID="drama1" runat="server" Text="Drama" />
                                    <br />
                                    <asp:CheckBox ID="fantasy1" runat="server" Text="Fantasy" />
                                    <br />
                                    <asp:CheckBox ID="horror1" runat="server" Text="Horror" /> 
                                    </asp:Panel>
                                    <asp:Label ID="genreError1" runat="server" CssClass="errorMessage"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right"><strong><asp:Label ID="Label8" runat="server" Text="Price" ></asp:Label></strong></td>
                            <td style="text-align: justify"><asp:TextBox ID="pricebox" runat="server" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="priceboxRFV" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ValidationGroup="updateBookInfo" Display="Dynamic" ControlToValidate="pricebox"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right"><strong><asp:Label ID="Label9" runat="server" Text="Release Date" ></asp:Label></strong></td>
                            <td style="text-align: justify"><asp:TextBox ID="reldatebox" runat="server" TextMode="Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reldateboxRFV" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ValidationGroup="updateBookInfo" Display="Dynamic" ControlToValidate="reldatebox"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right"><strong><asp:Label ID="Label10" runat="server" Text="Stocks" ></asp:Label></strong></td>
                            <td style="text-align: justify"><asp:TextBox ID="stocks" runat="server" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="stocksRFV" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ValidationGroup="updateBookInfo" Display="Dynamic" ControlToValidate="stocks"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align: justify">
                                <asp:Button ID="UpdateBookButton" runat="server" CssClass="btnsubmit" Text="Update" OnClick="UpdateBookButton_Click" Width="80px" ValidationGroup="updateBookInfo" />
                                <asp:Button ID="updateBookCancel" runat="server" Text="Cancel" CssClass="btnsubmit" Width="100px" OnClick="updateBookCancel_Click"/>
                            </td>
                        </tr>
                    </table>  
                        
                </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                           
                        </td>
                        
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <asp:Label ID="successMessage" runat="server" Text="" Font-Size="Large" ForeColor="#339933"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="DeleteBooks" runat="server" Text="Delete Book" BackColor="red" CssClass="btnsubmit" Width="140px" OnClick="DeleteBooks_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="DiscountButton" runat="server" Text="Add Discount" BackColor="#33CC33" CssClass="btnsubmit" OnClick="DiscountButton_Click" Width="140px"/>
                <asp:DropDownList ID="DiscountList" runat="server">
                </asp:DropDownList>
                <br />
                             </ContentTemplate>
                    </asp:UpdatePanel>
                <asp:Button ID="addnewbook" runat="server" Text="Add New Book" CssClass="btnsubmit" Width="150px" OnClick="Button2_Click" Visible="true" />

<table class="productList" style="width:50%;">
<tr>
<td style="vertical-align: top; width: auto;">      


<div runat="server" id="addBooks" visible="false">
    <h2>Add New Book</h2>
        <table> 
        <tr>
            <td style="text-align: right">
                <asp:Label ID="lblBookName" runat="server" Text="Book Title" Font-Bold="True" Font-Size="Large"  CssClass="label"></asp:Label>
            </td>
            <td style="text-align: justify;">
                <asp:TextBox ID="txtBookName" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="bookTitleRFV" runat="server" ControlToValidate="txtBookName" CssClass="errorMessage" ErrorMessage="*Required Field" Display="Dynamic" ValidationGroup="addBookInfo"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="lblPicture" runat="server" Text="Book Cover" Font-Bold="True" Font-Size="Large"  CssClass="label"></asp:Label>
            </td>
            <td  style="text-align: justify">
                <asp:FileUpload ID="BookImageUpload" runat="server" />
            </td> 
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="AuthorIDLbl" runat="server" Text="Author ID" Font-Bold="True" Font-Size="Large"  CssClass="label"></asp:Label>
            </td>
            <td style="text-align: justify">
                <asp:TextBox ID="AuthorIDTxt" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="authoridrfv" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ControlToValidate="AuthorIDTxt" Display="Dynamic" ValidationGroup="addBookInfo"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="lblGenre" runat="server" Text="Genre" Font-Bold="True" Font-Size="Large"  CssClass="label"></asp:Label>
            </td>
            <td style="text-align: justify">
                <asp:Panel runat="server" ID="genreCheckbox">
                <asp:CheckBox ID="action" runat="server" Text="Action" />
                <br />
                <asp:CheckBox ID="mystery" runat="server" Text="Mystery" />
                <br />
                <asp:CheckBox ID="drama" runat="server" Text="Drama" />
                <br />
                <asp:CheckBox ID="fantasy" runat="server" Text="Fantasy" />
                <br />
                <asp:CheckBox ID="horror" runat="server" Text="Horror" /> 
                </asp:Panel>
                <asp:Label ID="genreError" runat="server" CssClass="errorMessage"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="Label1" runat="server" Text="Release Date" Font-Bold="True" Font-Size="Large"  CssClass="label"></asp:Label>
            </td>

            <td style="text-align:justify" >
                <asp:TextBox ID="RelDateTxt" runat="server" Width="125px" Height="19px" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RelDateTxtRFV" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ControlToValidate="RelDateTxt" ValidationGroup="addBookInfo" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="lblStock" runat="server" Text="Stock Available" Font-Bold="True" Font-Size="Large"  CssClass="label"></asp:Label>
            </td>
            <td style="text-align: justify">
                <asp:TextBox ID="txtStock" runat="server" Width="100px" TextMode="Number" min="0"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtStockRFV" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ControlToValidate="txtStock" ValidationGroup="addBookInfo" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="lblPrice" runat="server" Text="Price" Font-Bold="True" Font-Size="Large"  CssClass="label"></asp:Label>
            </td>
            <td style="text-align: justify">
                <asp:TextBox ID="txtPrice" runat="server" Width="100px" TextMode="Number" min="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtPriceRFV" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ControlToValidate="txtPrice" ValidationGroup="addBookInfo" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Label ID="lblDiscount" runat="server" Text="Discount (Optional)" Font-Bold="True" Font-Size="Large"  CssClass="label"></asp:Label>
            </td>
            <td style="text-align: justify">
                <asp:TextBox ID="txtDiscount" runat="server" Width="100px" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td ></td>
            <td style="text-align: justify">
                <asp:Button ID="Button1" runat="server" Text="Add Book" CssClass="btnsubmit" OnClick="Button1_Click" Width="100px" ValidationGroup="addBookInfo" />
                <asp:Button ID="addCancel" runat="server" Text="Cancel" CssClass="btnsubmit" Width="100px" OnClick="addCancel_Click" />
            </td>
        </tr>
    </table>

    </div>
</td>


<td style="vertical-align: top; width: auto;">
<div runat="server" id="addAuthors" visible="false">
<h2>Add Author</h2>
            <table>
                                                     <tr>
                <td style="text-align: right"><asp:Label ID="Label2" runat="server" Text="Author Name" Font-Bold="True" Font-Size="Large"  CssClass="label"></asp:Label></td>
                 <td style="text-align: justify"><asp:TextBox ID="AuthorNameText" runat="server" Width="300px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="AuthorNameTextRFV" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ControlToValidate="AuthorNameText" ValidationGroup="addAuthorInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                                                         </td>
            </tr>
            <tr>
                <td  style="text-align: right">
                    <asp:Label ID="Label3" runat="server" Text="Author Image" Font-Bold="True" Font-Size="Large"  CssClass="label"></asp:Label>
                </td>
                <td  style="text-align: justify">
                    <asp:FileUpload ID="AuthorImageUpload" runat="server" />
                </td>
            </tr>
            <tr>
                <td></td>
                 <td style="text-align: justify">
                <asp:Button ID="AuthorButton" OnClick="AuthorButton_Click" runat="server" Text="Add Author" CssClass="btnsubmit" Width="100px" ValidationGroup="addAuthorInfo" />
            </td>
            </tr>
            </table>
</div>


    <table>
        <tr>
            <td style="width: 100%;">
                <h1>Author List</h1>

                <%--<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>"></asp:SqlDataSource>--%>
                <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Author_ID" DataSourceID="SqlDataSource2" PageSize="5" Height="211px"  Width="420px" AllowSorting="True" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="RemoveAuthor" style="height: 20px; font-size: 16px;" Width="80" Height="20" OnClick="RemoveAuthor_Click" CssClass="btnsubmit" runat="server" Text="Delete"></asp:Button>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Author_ID" HeaderText="Author_ID" InsertVisible="False" ReadOnly="True" SortExpression="Author_ID" />
                    <asp:BoundField DataField="Author_Name" HeaderText="Author_Name" SortExpression="Author_Name" />
                    <asp:BoundField DataField="Author_Image" HeaderText="Author_Image" SortExpression="Author_Image" />
                    <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="AuthorUpdateLink" style="height: 20px; font-size: 16px;" OnClick="AuthorUpdateLink_Click" Width="80" Height="20" CssClass="btnsubmit" runat="server" Text="Update"></asp:Button>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                    <RowStyle Height="20" />
                    <FooterStyle BackColor="#CCCCCC" />
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
                <div id="updateAuthors" runat="server" visible="false">
                    <h2>Update Author</h2>
                    <table class="tableCenter">
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label13" Font-Bold="True" Font-Size="Large" runat="server" Text="Author ID"></asp:Label>
                        </td>
                        <td style="text-align: justify">
                            <asp:TextBox ID="AuthorIDTextBox" runat="server" Enabled="False" Height="22px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label11" Font-Bold="True" Font-Size="Large" runat="server" Text="Author Name"></asp:Label>
                        </td>
                        <td style="text-align: justify">
                            <asp:TextBox ID="AuthNameBox" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="AuthNameBoxRFV" runat="server" CssClass="errorMessage" ErrorMessage="*Required Field" ControlToValidate="AuthNameBox" ValidationGroup="updateAuthorInfo" Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Label ID="Label12" Font-Bold="True" Font-Size="Large" runat="server" Text="Author Image"></asp:Label>
                        </td>
                        <td style="text-align: justify">
                            <asp:FileUpload ID="UpdateImg" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="text-align: justify">&nbsp;<asp:Button ID="UpdateAuthorButton" runat="server" CssClass="btnsubmit" Text="Update" OnClick="UpdateAuthorButton_Click" Width="80px" ValidationGroup="updateAuthorInfo" />
                                <asp:Button ID="updateAuthorCancel" runat="server" Text="Cancel" CssClass="btnsubmit" Width="100px" OnClick="updateAuthorCancel_Click"/>
                        </td>
                        
                    </tr>
                        
                    </table>
                    
                </div>
            </td>
        </tr>
</table>

</td>
</tr>
</table>
</td>
</tr>
</table>



<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>" SelectCommand="SELECT Book.Book_ID,Book_name, 
    Author_ID,Genre,Price, Release_Date,Stocks,Price_Status, SUM(Quantity) as Sold_Books FROM BOOK FULL OUTER JOIN SALES on Sales.Book_ID = 
    Book.Book_ID Group by book_Name,Book.Book_ID,Author_ID,Genre,Price,Release_Date,Stocks,Price_Status"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ZeroConnectionString %>" SelectCommand="SELECT * FROM Author"></asp:SqlDataSource>
</asp:Content>
