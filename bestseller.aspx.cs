using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mp
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT Genre,SUM(Quantity) as BookCount FROM SALES LEFT JOIN Book on Book.Book_ID = " +
                "Sales.Book_ID WHERE Status = 'Delivered' Group By Genre Order BY BookCount Desc";
            SqlDataSource2.SelectCommand = "SELECT TOP 10 Author.Author_ID, Author_Image, Author_Name, SUM(Quantity) as SalesCount FROM BOOK LEFT JOIN Author on Author.Author_ID =" +
                "Book.Author_ID RIGHT JOIN Sales on Book.Book_ID = Sales.Book_ID WHERE Status = 'Delivered' " +
                "GROUP BY Author_Name, Author_Image, Author.Author_ID ORDER BY SalesCount DESC";
            //"SELECT TOP 10 Author_Name, Count(Quantity) FROM BOOK LEFT JOIN Author on Author.Author_ID =" +
            //    " Book.Author_ID RIGHT JOIN Sales on Book.Book_ID = Sales.Book_ID GROUP BY Author_Name ORDER BY SUM(Price* Quantity) DESC";
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label topcount = e.Item.FindControl("lblTotal") as Label;
            topcount.Text = "Top "+(DataList1.Items.Count + 1).ToString();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "SelectGenre")
            {
                Session["Genre"] = e.CommandArgument.ToString();
                Response.Redirect("GenrePage.aspx");
            }
        }

        protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label topcount = e.Item.FindControl("TopCount") as Label;
            topcount.Text = "Top " + (DataList3.Items.Count + 1).ToString();
        }

        protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "PassAuthor")
            {
                Session["Genre"] = "Select * FROM Author RIGHT JOIN Book on Book.Author_ID = Author.Author_ID WHERE Author.Author_ID =" + e.CommandArgument.ToString();
                Response.Redirect("GenrePage.aspx");
            }
        }
    }
}