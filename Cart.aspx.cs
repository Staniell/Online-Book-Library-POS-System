using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace mp
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1N24CO\SQLEXPRESS;Initial Catalog=Zero;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["Name"] == null)
                {
                    empty_cart();
                }
                else
                {
                    Order.Visible = true;

                    DataShow();

                }
            }
        }

        protected void Order_Click(object sender, EventArgs e)
        {

            bool out_of_stock = false;

            foreach (GridViewRow G_Item in GridView1.Rows)
            {

                //Read stocks after pressing purchase button
                con.Open();
                SqlCommand command = new SqlCommand("SELECT Stocks,Book_Name from Book WHERE Book_ID =" + G_Item.Cells[1].Text, con);
                SqlDataReader reader = command.ExecuteReader();

                //Check if stocks is still viable to the quantity that'll be purchased
                while (reader.Read())
                {
                    if (Int32.Parse(reader["Stocks"].ToString()) - Byte.Parse(G_Item.Cells[4].Text.ToString()) < 0)
                    {
                        out_of_stock = true;
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert1", "alert('Cannot complete transaction as " + reader["Book_Name"] + " is currently out of stock');", true);
                        break;
                    }
                }
                con.Close();
            }


            //Proceed to checkout
            if (!out_of_stock)
            {
                con.Open();
                string pay_method ="";
                SqlCommand comxz = new SqlCommand("SELECT Payment_Method FROM Registered WHERE Username ='"+Session["Name"].ToString()+"'", con);
                SqlDataReader dx = comxz.ExecuteReader();
                while (dx.Read())
                {
                    pay_method = dx["Payment_Method"].ToString();
                }
                con.Close();
                //CRUD Happened in a single button
                foreach (GridViewRow G_Item in GridView1.Rows)
                {
                    con.Open();
                    double tprice = 0;
                    SqlCommand cmdw = new SqlCommand("Select (Quantity*Price) AS Total_Price " +
                    "FROM Cart_Books LEFT JOIN Book on Book.Book_ID = Cart_Books.Book_ID WHERE Username =" + "'" + Session["Name"].ToString() + "'" + " and" +" Cart_Books.Book_ID = "+G_Item.Cells[1].Text, con);

                    SqlDataReader dr = cmdw.ExecuteReader();


                    while (dr.Read())
                    {
                        tprice = Double.Parse(dr["Total_Price"].ToString());
                    }
                    con.Close();

                    con.Open();


                    SqlCommand comm = new SqlCommand("INSERT INTO Sales (Book_ID, Username, Total_Price, Payment_Method, Quantity, Date_Purchased, ETA, Status, Reason) VALUES" +
                        " (@Book_ID, @Username, @Total_Price, @Payment_Method, @Quantity, @Date_Purchased, @ETA, @Status, @Reason)", con);

                    comm.Parameters.AddWithValue("@Reason", "null");
                    comm.Parameters.AddWithValue("@Book_ID", G_Item.Cells[1].Text);
                    comm.Parameters.AddWithValue("@Username", Session["Name"].ToString());
                    comm.Parameters.AddWithValue("@Quantity", G_Item.Cells[4].Text);
                    comm.Parameters.AddWithValue("@Total_Price", tprice);
                    comm.Parameters.AddWithValue("@Payment_Method", pay_method);
                    comm.Parameters.AddWithValue("@Date_Purchased", DateTime.Now);
                    comm.Parameters.AddWithValue("@ETA", DateTime.Now.AddDays(7));
                    comm.Parameters.AddWithValue("@Status", "Ongoing");


                    comm.ExecuteNonQuery();


                    SqlCommand commx = new SqlCommand(@"UPDATE BOOK SET Stocks=Stocks-" + G_Item.Cells[4].Text + @" FROM book WHERE Book_ID =" + G_Item.Cells[1].Text, con);

                    commx.ExecuteNonQuery();
                    con.Close();
                }
                SqlCommand commy = new SqlCommand(@"DELETE FROM Cart_Books WHERE Username =" + "'" + Session["Name"].ToString() + "'", con);
                con.Open();
                commy.ExecuteNonQuery();
                con.Close();

                ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert1", "alert('Transaction Complete!');", true);

                GridView1.Columns.Clear();
                GridView1.DataSource = null;
                GridView1.DataBind();

                empty_cart();

            }

            //Session.Remove("CartandQty");

        }

        void empty_cart()
        {
            Label1.Visible = false;
            Label2.Visible = false;
            TextBox1.Text = "Your Cart Is Empty";
            TextBox2.Visible = false;
            Order.Visible = false;
        }

        protected void DataShow()
        {
            con.Open();
            double totalprice = 0;
            DataTable table = new DataTable();

            table.Columns.Add("Book_ID");
            table.Columns.Add("Book Name");
            table.Columns.Add("Price");
            table.Columns.Add("Quantity");
            table.Columns.Add("Total Price");

            SqlCommand cmd = new SqlCommand("Select Cart_Books.Book_ID, Book_Name, Price, Quantity, (Quantity*Price) AS Total_Price " +
                "FROM Cart_Books LEFT JOIN Book on Book.Book_ID = Cart_Books.Book_ID WHERE Username =" + "'" + Session["Name"].ToString() + "'", con);

            SqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                table.Rows.Add(dr["Book_ID"].ToString(), dr["Book_Name"].ToString(), "₱" + dr["Price"].ToString(), dr["Quantity"],
                    "₱" + dr["Total_Price"].ToString());

                totalprice += Byte.Parse(dr["Quantity"].ToString()) * Int16.Parse(dr["Price"].ToString());
            }

            GridView1.DataSource = table;
            GridView1.DataBind();
            if (GridView1.Rows.Count <= 0)
            {
                empty_cart();
            }

            else
            {
                TextBox1.Text = "₱" + totalprice.ToString();
                TextBox2.Text = DateTime.Today.AddDays(7).ToString().Split(Convert.ToChar(" "))[0];
            }
            con.Close();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataShow();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Cart_Books WHERE Book_ID =" +"'"+ GridView1.DataKeys[e.RowIndex].Value.ToString() + "'" + "and"+" Username = " + "'" + Session["Name"].ToString() + "'", con);

            command.ExecuteNonQuery();
            con.Close();
            DataShow();
        }
    }
}
