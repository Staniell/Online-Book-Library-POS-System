using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1N24CO\SQLEXPRESS;Initial Catalog=Zero;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataSource2.SelectCommand = "SELECT TOP 10 Book.Book_ID, Author.Author_ID, Genre, Release_Date, Price_Status, Stocks, Book_url, Book_Name, Price, Author_Name, SUM(Quantity) FROM Book RIGHT JOIN Sales on Sales.Book_ID = Book.Book_ID LEFT JOIN Author on" +
    " Author.Author_ID = Book.Author_ID GROUP BY Book.Book_ID, Author.Author_ID, Price, Author_Name, Book_url, Genre, Release_Date, Price_Status, Stocks, Book_Name ORDER BY SUM(Quantity) DESC";
                SqlDataSource1.SelectCommand = "SELECT TOP 10 * FROM Book LEFT JOIN Author on Author.Author_ID = Book.Author_ID ORDER BY Release_Date DESC";
            }
        }


        //below
        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            System.Web.UI.WebControls.Button cartbut = e.Item.FindControl("AddToCart") as System.Web.UI.WebControls.Button;
            System.Web.UI.WebControls.Label StockNumber = e.Item.FindControl("StockLabel") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label quant = e.Item.FindControl("Label21") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label stock = e.Item.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label price = e.Item.FindControl("SaleLabel") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label price_display = e.Item.FindControl("PriceLabel") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label bookIDlabel = e.Item.FindControl("Label14") as System.Web.UI.WebControls.Label;

            DropDownList qty = e.Item.FindControl("DropDownList12") as DropDownList;

            price_display.ForeColor = System.Drawing.Color.Orange;
            if (StockNumber.Text == "0")
            {
                stock.Visible = false;
                quant.Visible = false;
                cartbut.Visible = false;
                StockNumber.Text = "Out Of Stock";
                StockNumber.ForeColor = System.Drawing.Color.Gray;
                qty.Visible = false;

            }

            if (price.Text != null)
            {
                price.Visible = true;
                price.ForeColor = System.Drawing.Color.Red;
            }

            if (Session["Name"] != null)
            {
                con.Open();
                SqlCommand commandx = new SqlCommand("SELECT COUNT(1) from Cart_Books WHERE Book_ID =" + "'" +
                    bookIDlabel.Text.ToString() + "'" + " and Username =" + "'" + Session["Name"].ToString() + "'", con);
                byte count = Convert.ToByte(commandx.ExecuteScalar());//Read the first result

                if (count == 1)
                {
                    cartbut.Text = "In Cart";
                    cartbut.BackColor = System.Drawing.Color.Gray;
                    cartbut.Enabled = false;
                    quant.Visible = false;
                    qty.Visible = false;
                }
                con.Close();
            }

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AuthorRedirect")
            {
                Session["Genre"] = "Select * FROM Author RIGHT JOIN Book on Book.Author_ID = Author.Author_ID WHERE Author.Author_ID =" + e.CommandArgument.ToString();
                Response.Redirect("GenrePage.aspx");
            }
            else if (Session["Name"] == null)
                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert1", "alert('Please login/register first');", true);
            else if (e.CommandName == "AddCart")
            {

                System.Web.UI.WebControls.Label StockNumber = e.Item.FindControl("StockLabel") as System.Web.UI.WebControls.Label;
                DropDownList qty = (DropDownList)(e.Item.FindControl("DropDownList12"));

                //CartandQty = Book_Name;Price;BookID;Quantity

                if (Int32.Parse(StockNumber.Text) - Byte.Parse(qty.SelectedValue) < 0)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('You have exceeded the number of stocks available! Try again later');", true);

                else
                {

                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO Cart_Books VALUES('" + e.CommandArgument.ToString().Split(';')[2] + "','" +
                    Session["Name"].ToString() + "','" + qty.SelectedValue + "')", con);
                    comm.ExecuteNonQuery();
                    SqlDataSource1.SelectCommand = "SELECT TOP 10 * FROM Book LEFT JOIN Author on Author.Author_ID = Book.Author_ID ORDER BY Release_Date DESC";
                    con.Close();
                }
            }
        }


        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "AuthorRedirect")
            {
                Session["Genre"] = "Select * FROM Author RIGHT JOIN Book on Book.Author_ID = Author.Author_ID WHERE Author.Author_ID =" + e.CommandArgument.ToString();
                Response.Redirect("GenrePage.aspx");
            }
            else if (Session["Name"] == null)
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please login/register first');", true);
            else if (e.CommandName == "AddCart")
            {

                System.Web.UI.WebControls.Label StockNumber = e.Item.FindControl("StockLabel") as System.Web.UI.WebControls.Label;
                DropDownList qty = (DropDownList)(e.Item.FindControl("DropDownList1"));

                //CartandQty = Book_Name;Price;BookID;Quantity

                if (Int32.Parse(StockNumber.Text) - Byte.Parse(qty.SelectedValue) < 0)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('You exceeded the number of stocks available. Please enter a new quantity');", true);

                else
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO Cart_Books VALUES('" + e.CommandArgument.ToString().Split(';')[2] + "','" +
                    Session["Name"].ToString() + "','" + qty.SelectedValue + "')", con);
                    comm.ExecuteNonQuery();

                    SqlDataSource2.SelectCommand = "SELECT TOP 10 Book.Book_ID, Author.Author_ID, Genre, Release_Date, Price_Status, Stocks, Book_url, Book_Name, Price, Author_Name, SUM(Quantity) FROM Book RIGHT JOIN Sales on Sales.Book_ID = Book.Book_ID LEFT JOIN Author on" +
" Author.Author_ID = Book.Author_ID GROUP BY Book.Book_ID, Author.Author_ID, Price, Author_Name, Book_url, Genre, Release_Date, Price_Status, Stocks, Book_Name ORDER BY SUM(Quantity) DESC";
                    con.Close();
                }
            }
        }

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            System.Web.UI.WebControls.Button cartbut = e.Item.FindControl("AddToCart2") as System.Web.UI.WebControls.Button;
            System.Web.UI.WebControls.Label StockNumber = e.Item.FindControl("StockLabel") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label quant = e.Item.FindControl("Label25") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label stock = e.Item.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label price = e.Item.FindControl("SaleLabel") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label price_display = e.Item.FindControl("PriceLabel") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label bookIDlabelx = e.Item.FindControl("bID") as System.Web.UI.WebControls.Label;
            DropDownList qty = e.Item.FindControl("DropDownList1") as DropDownList;

            price_display.ForeColor = System.Drawing.Color.Orange;

            if (StockNumber.Text == "0")
            {
                stock.Visible = false;
                quant.Visible = false;
                cartbut.Visible = false;
                StockNumber.Text = "Out Of Stock";
                StockNumber.ForeColor = System.Drawing.Color.Gray;
                qty.Visible = false;
            }

            if (price.Text != null)
            {
                price.Visible = true;
                price.ForeColor = System.Drawing.Color.Red;
            }

            if (Session["Name"] != null)
            {
                con.Open();
                SqlCommand commandx = new SqlCommand("SELECT COUNT(1) from Cart_Books WHERE Book_ID =" + "'" +
                    bookIDlabelx.Text.ToString() + "'" + " and Username =" + "'" + Session["Name"].ToString() + "'", con);
                byte count = Convert.ToByte(commandx.ExecuteScalar());//Read the first result

                if (count == 1)
                {
                    cartbut.Text = "In Cart";
                    cartbut.BackColor = System.Drawing.Color.Gray;
                    cartbut.Enabled = false;
                    quant.Visible = false;
                    qty.Visible = false;
                }
                con.Close();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("bestseller.aspx");
        }


        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("GenrePage.aspx");
            Session["Saled"] = "Sale";
        }
    }
}