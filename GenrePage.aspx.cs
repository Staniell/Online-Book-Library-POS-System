using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace mp
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1N24CO\SQLEXPRESS;Initial Catalog=Zero;Integrated Security=True");
        //protected List<string> CartItems = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                    "Book.Author_ID";
                if (Session["Genre"] != null)
                    //Author Redirection
                    if (Session["Genre"].ToString().Length > 30)
                    {
                        SqlDataSource1.SelectCommand = Session["Genre"].ToString();
                        CheckBoxList1.Visible = false;
                        TextBox1.Visible = false;
                        Button1.Visible = false;
                        Label1.Visible = false;
                        SaleRadio.Visible = false;
                    }
                    else
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = Book.Author_ID WHERE Genre LIKE" + "'%" + Session["Genre"] + "%'";

                //else
                //    SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                //    "Book.Author_ID";
            }
            //var CartItems = new List<string> { };
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "AuthorRedirect")
            {
                Session["Genre"] = "Select * FROM Author RIGHT JOIN Book on Book.Author_ID = Author.Author_ID WHERE Author.Author_ID =" + e.CommandArgument.ToString();
                Response.Redirect("GenrePage.aspx");
            }

            else if (Session["Name"] == null)
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please register/login first');", true);

            else if (e.CommandName == "AddCart")
            {
                System.Web.UI.WebControls.Label StockNumber = e.Item.FindControl("StockLabel") as System.Web.UI.WebControls.Label;
                DropDownList qty = (DropDownList)(e.Item.FindControl("DropDownList1"));

                //CartandQty = Book_Name;Price;BookID;Quantity

                if (Int32.Parse(StockNumber.Text) - Byte.Parse(qty.SelectedValue) < 0)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('You have exceeded the number of stocks available. Try again later');", true);

                else
                {
                    con.Open();
                    SqlCommand comm = new SqlCommand("INSERT INTO Cart_Books VALUES('" + e.CommandArgument.ToString().Split(';')[2] + "','" +
                    Session["Name"].ToString() + "','" + qty.SelectedValue + "')", con);
                    comm.ExecuteNonQuery();

                    if (Session["FilterSelect"] != null)
                        SqlDataSource1.SelectCommand = Session["FilterSelect"].ToString();
                    else
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                            "Book.Author_ID";

                    if (Session["Genre"] != null)
                    //Author Redirection
                        if (Session["Genre"].ToString().Length > 30)
                        {
                            SqlDataSource1.SelectCommand = Session["Genre"].ToString();
                            CheckBoxList1.Visible = false;
                            TextBox1.Visible = false;
                            Button1.Visible = false;
                            Label1.Visible = false;
                            SaleRadio.Visible = false;
                        }
                        else
                            SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                                "Book.Author_ID";
                    con.Close();


                }

            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            System.Web.UI.WebControls.Button cartbut = e.Item.FindControl("AddToCart") as System.Web.UI.WebControls.Button;
            System.Web.UI.WebControls.Label StockNumber = e.Item.FindControl("StockLabel") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label quant = e.Item.FindControl("Label2") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label stock = e.Item.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label price = e.Item.FindControl("SaleLabel") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label price_display = e.Item.FindControl("PriceLabel") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label bookIDlabel = e.Item.FindControl("Label4") as System.Web.UI.WebControls.Label;

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


            if (price.Text!=null)
            {
                price.Visible = true;
                price.ForeColor = System.Drawing.Color.Red;
            }

            if (Session["Name"] != null)
            {
                con.Open();
                SqlCommand commandx = new SqlCommand("SELECT COUNT(1) from Cart_Books WHERE Book_ID ="  +
                    bookIDlabel.Text  + " and Username =" + "'" + Session["Name"].ToString() + "'", con);
                byte count = Convert.ToByte(commandx.ExecuteScalar());//Read the first result

                if (count > 0)
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = Book.Author_ID WHERE Book_Name LIKE" + "'%" + TextBox1.Text + "%'";
            foreach(ListItem itemx in CheckBoxList1.Items)
            {
                itemx.Selected = false;
                
            }
            foreach(ListItem item in SaleRadio.Items)
            {
                item.Selected = false;
            }
            Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = Book.Author_ID WHERE Book_Name LIKE" + "'%" + TextBox1.Text + "%'";

        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            List<ListItem> selected = CheckBoxList1.Items.Cast<ListItem>()
                    .Where(li => li.Selected)
                    .ToList();
            if (SaleRadio.SelectedIndex == 0)
            {
                switch (selected.Count)
                {
                    case 0:
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Price_Status IS NULL";
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Price_Status IS NULL";
                        break;
                    case 1:
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%' AND Price_Status IS NULL";
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%' AND Price_Status IS NULL";
                        break;
                    case 2:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NULL ";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NULL ";
                        break;
                    case 3:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NULL " + "OR " +
                        "Genre LIKE " + "'%" + selected[2].ToString() + "%'" + " AND Price_Status IS NULL ";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NULL " + "OR " +
                        "Genre LIKE " + "'%" + selected[2].ToString() + "%'" + " AND Price_Status IS NULL ";
                        break;
                    case 4:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NULL " + "OR " +
                        "Genre LIKE " + "'%" + " AND Price_Status IS NULL " + selected[2].ToString() + "%'" + " OR " + "Genre LIKE " + "'%" + selected[3].ToString() + "%'" + " AND Price_Status IS NULL ";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NULL " + "OR " +
                        "Genre LIKE " + "'%" + " AND Price_Status IS NULL " + selected[2].ToString() + "%'" + " OR " + "Genre LIKE " + "'%" + selected[3].ToString() + "%'" + " AND Price_Status IS NULL ";
                        break;
                    case 5:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NULL " + "OR " +
                        "Genre LIKE " + " '%" + selected[2].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + "Genre LIKE " + "'%" + selected[3].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + "Genre LIKE " + "'%" +
                        selected[4].ToString() + "%'" + " AND Price_Status IS NULL ";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NULL " + "OR " +
                        "Genre LIKE " + " '%" + selected[2].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + "Genre LIKE " + "'%" + selected[3].ToString() + "%'" + " AND Price_Status IS NULL " + " OR " + "Genre LIKE " + "'%" +
                        selected[4].ToString() + "%'" + " AND Price_Status IS NULL ";
                        break;
                }
            }

            else if(SaleRadio.SelectedIndex == 1)
            {
                switch (selected.Count)
                {
                    case 0:
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Price_Status IS NOT NULL";
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Price_Status IS NOT NULL";
                        break;
                    case 1:
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%' AND Price_Status IS NOT NULL";
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%' AND Price_Status IS NOT NULL";
                        break;
                    case 2:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NOT NULL ";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NOT NULL ";
                        break;
                    case 3:
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NOT NULL " + "OR " +
                        "Genre LIKE " + "'%" + selected[2].ToString() + "%'" + " AND Price_Status IS NOT NULL ";
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NOT NULL " + "OR " +
                        "Genre LIKE " + "'%" + selected[2].ToString() + "%'" + " AND Price_Status IS NOT NULL ";
                        break;
                    case 4:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NOT NULL " + "OR " +
                        "Genre LIKE " + "'%" + selected[2].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + "Genre LIKE " + "'%" + selected[3].ToString() + "%'" + " AND Price_Status IS NOT NULL ";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + " Genre LIKE " + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NOT NULL " + "OR " +
                        "Genre LIKE " + "'%" + selected[2].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + "Genre LIKE " + "'%" + selected[3].ToString() + "%'" + " AND Price_Status IS NOT NULL ";
                        break;
                    case 5:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NOT NULL " + "OR " +
                        "Genre LIKE " + " '%" + selected[2].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + "Genre LIKE " + "'%" + selected[3].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + "Genre LIKE " + "'%" +
                        selected[4].ToString() + "%'" + " AND Price_Status IS NOT NULL ";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE " + "'%" + selected[0].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + " AND Price_Status IS NOT NULL " + "OR " +
                        "Genre LIKE " + " '%" + selected[2].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + "Genre LIKE " + "'%" + selected[3].ToString() + "%'" + " AND Price_Status IS NOT NULL " + " OR " + "Genre LIKE " + "'%" +
                        selected[4].ToString() + "%'" + " AND Price_Status IS NOT NULL ";
                        break;
                }
            }
            else
            {
                switch (selected.Count)
                {
                    case 0:
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID";
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID";
                        break;
                    case 1:
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE" + "'%" + selected[0].ToString() + "%'";
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE" + "'%" + selected[0].ToString() + "%'";
                        break;
                    case 2:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE" + "'%" + selected[0].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE" + "'%" + selected[0].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'";
                        break;
                    case 3:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE" + "'%" + selected[0].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + "OR " +
                        "Genre LIKE" + "'%" + selected[2].ToString() + "%'";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE" + "'%" + selected[0].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + "OR " +
                        "Genre LIKE" + "'%" + selected[2].ToString() + "%'";
                        break;
                    case 4:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE" + "'%" + selected[0].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + "OR " +
                        "Genre LIKE" + "'%" + selected[2].ToString() + "%'" + " OR " + "Genre LIKE" + "'%" + selected[3].ToString() + "%'";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE" + "'%" + selected[0].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + "OR " +
                        "Genre LIKE" + "'%" + selected[2].ToString() + "%'" + " OR " + "Genre LIKE" + "'%" + selected[3].ToString() + "%'";
                        break;
                    case 5:
                        Session["FilterSelect"] = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE" + "'%" + selected[0].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + "OR " +
                        "Genre LIKE" + "'%" + selected[2].ToString() + "%'" + " OR " + "Genre LIKE" + "'%" + selected[3].ToString() + "%'" + " OR " + "Genre LIKE" + "'%" +
                        selected[4].ToString() + "%'";
                        SqlDataSource1.SelectCommand = "SELECT * FROM[Book] LEFT JOIN[Author] on Author.Author_ID = " +
                        "Book.Author_ID WHERE Genre LIKE" + "'%" + selected[0].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + "OR " +
                        "Genre LIKE" + "'%" + selected[2].ToString() + "%'" + " OR " + "Genre LIKE" + "'%" + selected[3].ToString() + "%'" + " OR " + "Genre LIKE" + "'%" +
                        selected[4].ToString() + "%'";
                        break;
                }
            }
            
        }

        protected void SaleRadio_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ListItem> selected = CheckBoxList1.Items.Cast<ListItem>()
            .Where(li => li.Selected)
            .ToList();
            TextBox1.Text = "";
            //Saled Items
            switch (selected.Count)
            {
                case 0:
                    if (SaleRadio.SelectedIndex == 1)
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL";
                    }
                    else if (SaleRadio.SelectedIndex == 0)
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL";
                    }
                    else
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID";
                    }
                    break;
                case 1:
                    if (SaleRadio.SelectedIndex == 1)
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL AND Genre LIKE '%" +
                            selected[0] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL AND Genre LIKE '%" +
                            selected[0] + "%'";
                    }
                    else if (SaleRadio.SelectedIndex == 0)
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL AND Genre LIKE '%" +
                            selected[0] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL AND Genre LIKE '%" +
                            selected[0] + "%'";
                    }
                    else
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Genre LIKE '%" +
                            selected[0] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Genre LIKE '%" +
                            selected[0] + "%'";
                    }
                    break;
                case 2:
                    if (SaleRadio.SelectedIndex == 1)
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[1] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[1] + "%'";
                    }
                    else if (SaleRadio.SelectedIndex == 0)
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[1] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[1] + "%'";
                    }
                    else
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Genre LIKE '%" +
                            selected[0] + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Genre LIKE '%" +
                            selected[0] + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'";
                    }
                    break;
                case 3:
                    if (SaleRadio.SelectedIndex == 1)
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[2] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[2] + "%'";
                    }
                    else if (SaleRadio.SelectedIndex == 0)
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[2] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[2] + "%'";
                    }
                    else
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Genre LIKE '%" +
                            selected[0] + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[2].ToString() + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Genre LIKE '%" +
                            selected[0] + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[2].ToString() + "%'";
                    }
                    break;
                case 4:
                    if (SaleRadio.SelectedIndex == 1)
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[2] + "%'" +
                            " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[3] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[2] + "%'" +
                            " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[3] + "%'";
                    }
                    else if (SaleRadio.SelectedIndex == 0)
                    {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[2] + "%'" +
                            " OR Price_Status IS NULL AND Genre LIKE '%" + selected[3] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[2] + "%'" +
                            " OR Price_Status IS NULL AND Genre LIKE '%" + selected[3] + "%'";
                    }
                    else {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Genre LIKE '%" +
                            selected[0] + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[2].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[3].ToString() + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Genre LIKE '%" +
                            selected[0] + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[2].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[3].ToString() + "%'";
                    }
                    break;
                case 5:
                    if (SaleRadio.SelectedIndex == 1) {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[2] + "%'" +
                            " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[3] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[4] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NOT NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[2] + "%'" +
                            " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[3] + "%'" + " OR Price_Status IS NOT NULL AND Genre LIKE '%" + selected[4] + "%'";
                    }
                    else if (SaleRadio.SelectedIndex == 0) {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[2] + "%'" +
                            " OR Price_Status IS NULL AND Genre LIKE '%" + selected[3] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[4] + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Price_Status IS NULL AND Genre LIKE '%" +
                            selected[0] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[1] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[2] + "%'" +
                            " OR Price_Status IS NULL AND Genre LIKE '%" + selected[3] + "%'" + " OR Price_Status IS NULL AND Genre LIKE '%" + selected[4] + "%'";
                    }
                    else {
                        SqlDataSource1.SelectCommand = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Genre LIKE '%" +
                            selected[0] + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[2].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[3].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[4].ToString() + "%'";
                        Session["FilterSelect"] = "SELECT * FROM Book LEFT JOIN Author on Book.Author_ID = Author.Author_ID WHERE Genre LIKE '%" +
                            selected[0] + "%'" + " OR " + " Genre LIKE" + "'%" + selected[1].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[2].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[3].ToString() + "%'" + " OR " + " Genre LIKE" + "'%" + selected[4].ToString() + "%'";
                    }
                    break;
           
            }
        }
    }
}