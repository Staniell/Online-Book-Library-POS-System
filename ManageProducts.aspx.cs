using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace mp
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1N24CO\SQLEXPRESS;Initial Catalog=Zero;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpID"] != null)
            {
                if (!IsPostBack)
                {
                    ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

                    SqlDataSource1.SelectCommand = "SELECT Book.Book_ID,Book_name, Author_ID,Genre,Price," +
                        "Release_Date,Stocks,Price_Status, SUM(Quantity) as Sold_Books FROM BOOK FULL OUTER JOIN SALES on Sales.Book_ID = Book.Book_ID " +
                        "Group by book_Name,Book.Book_ID,Author_ID,Genre,Price,Release_Date,Stocks,Price_Status";
                    SqlDataSource2.SelectCommand = "SELECT * FROM [Author]";

                    DiscountList.Items.Add(new ListItem("0"));
                    for (int disc = 5; disc <= 90; disc += 5)
                    {
                        DiscountList.Items.Add(new ListItem(disc.ToString()));
                    }
                }
            }
            else
                Response.Redirect("AdminLogin.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string genreList = "";
                if (action.Checked == false && mystery.Checked == false && drama.Checked == false && fantasy.Checked == false && horror.Checked == false)
                {
                    genreError.Text = "*Check at least one.";
                }
                else
                {
                    foreach (CheckBox checkBox in genreCheckbox.Controls.OfType<CheckBox>())
                    {
                        if (checkBox.Checked)
                        {
                            genreList += checkBox.Text.ToString() + ",";
                        }
                    }

                    if (BookImageUpload.HasFile)
                    {
                        string fileName = Path.GetFileName(BookImageUpload.PostedFile.FileName);
                        SqlCommand com = new SqlCommand("INSERT INTO Book VALUES (@Book_Name,@Author_ID,@Genre,@Price,@Release_Date,@Book_Url,@Stocks,@Price_Status)", con);
                    
                        com.Parameters.AddWithValue("@Book_Url", fileName);
                        com.Parameters.AddWithValue("@Book_Name", txtBookName.Text);
                        com.Parameters.AddWithValue("@Author_ID", AuthorIDTxt.Text);
                        com.Parameters.AddWithValue("@Genre", genreList.Trim(',').ToString());
                        com.Parameters.AddWithValue("@Price", Int32.Parse(txtPrice.Text));
                        com.Parameters.AddWithValue("@Release_Date", RelDateTxt.Text);
                        com.Parameters.AddWithValue("@Stocks", Int32.Parse(txtStock.Text));
                        if (txtDiscount.Text == "")
                            com.Parameters.AddWithValue("@Price_Status", DBNull.Value);
                        else
                            com.Parameters.AddWithValue("@Price_Status", txtDiscount.Text);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();

                        BookImageUpload.PostedFile.SaveAs(Server.MapPath("~/images/"+fileName));
                    }
                    else
                    {
                        SqlCommand com = new SqlCommand("INSERT INTO Book VALUES (@Book_Name,@Author_ID,@Genre,@Price,@Release_Date,@Book_Url,@Stocks,@Price_Status)", con);
                       
                        com.Parameters.AddWithValue("@Book_Url", "");
                        com.Parameters.AddWithValue("@Book_Name", txtBookName.Text);
                        com.Parameters.AddWithValue("@Author_ID", AuthorIDTxt.Text);
                        com.Parameters.AddWithValue("@Genre", genreList.Trim(',').ToString());
                        com.Parameters.AddWithValue("@Price", Int32.Parse(txtPrice.Text));
                        com.Parameters.AddWithValue("@Release_Date", RelDateTxt.Text);
                        com.Parameters.AddWithValue("@Stocks", Int32.Parse(txtStock.Text));
                        if (txtDiscount.Text == "")
                            com.Parameters.AddWithValue("@Price_Status", DBNull.Value);
                        else
                            com.Parameters.AddWithValue("@Price_Status", txtDiscount.Text);
                        con.Open();
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                    addnewbook.Visible = true;
                }
                successMessage.Text = txtBookName.Text + " has been successfully added.";
                clearAddBookField();
            }
            catch
            {
                successMessage.Text = "Author ID Does not exist";
            }
        }




        protected void AuthorButton_Click(object sender, EventArgs e)
        {
            if (AuthorImageUpload.HasFile)
            {
                string fileName = Path.GetFileName(AuthorImageUpload.PostedFile.FileName);
                AuthorImageUpload.PostedFile.SaveAs(Server.MapPath("~/images/" + fileName));
                SqlCommand comx = new SqlCommand("INSERT INTO Author VALUES (@Author_Name, @Author_Image)", con);
                comx.Parameters.AddWithValue("@Author_Name", AuthorNameText.Text);
                comx.Parameters.AddWithValue("@Author_Image", fileName);
                con.Open();
                comx.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                SqlCommand comx = new SqlCommand("INSERT INTO Author VALUES (@Author_Name, @Author_Image)", con);
                comx.Parameters.AddWithValue("@Author_Name", AuthorNameText.Text);
                comx.Parameters.AddWithValue("@Author_Image", "");
                con.Open();
                comx.ExecuteNonQuery();
                con.Close();
            }
            SqlDataSource2.SelectCommand = "SELECT * FROM [Author]";
            successMessage.Text = AuthorNameText.Text + " has been successfully added.";
            clearAddAuthorField();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            updateBooks.Visible = true;
            int indexrow = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            string genreList3 = GridViewProductList.Rows[indexrow].Cells[3].Text;
            string[] genreListt = genreList3.Split(',').ToArray();
            foreach (string genre in genreListt)
            {
                if (genre == "Action")
                {
                    action1.Checked = true;
                }
                if (genre == "Mystery")
                {
                    mystery1.Checked = true;
                }
                if (genre == "Drama")
                {
                    drama1.Checked = true;
                }
                if (genre == "Fantasy")
                {
                    fantasy1.Checked = true;
                }
                if (genre == "Horror")
                {
                    horror1.Checked = true;
                }
            }

            bookIDtxt.Text = GridViewProductList.Rows[indexrow].Cells[0].Text;
            booknametxt.Text = GridViewProductList.Rows[indexrow].Cells[1].Text;
            authoridtxtbox.Text = GridViewProductList.Rows[indexrow].Cells[2].Text;
            pricebox.Text = GridViewProductList.Rows[indexrow].Cells[4].Text;
            reldatebox.Text = GridViewProductList.Rows[indexrow].Cells[5].Text;
            stocks.Text = GridViewProductList.Rows[indexrow].Cells[6].Text;
        }

        protected void UpdateBookButton_Click(object sender, EventArgs e)
        {
            string genreList2 = "";
            if (action1.Checked == false && mystery1.Checked == false && drama1.Checked == false && fantasy1.Checked == false && horror1.Checked == false)
            {
                genreError1.Text = "*Check at least one.";
            }
            else
            {
                foreach (CheckBox checkBox in genreCheckbox1.Controls.OfType<CheckBox>())
                {
                    if (checkBox.Checked)
                    {
                        genreList2 += checkBox.Text + ",";
                    }
                }
                SqlCommand com = new SqlCommand("UPDATE Book SET" + " Book_Name='" + booknametxt.Text.ToString() + "', Author_ID ='" +
                authoridtxtbox.Text + "', Genre ='" + genreList2.Trim(',') + "', Price ='" + pricebox.Text + "', Release_Date ='" + reldatebox.Text + "', Stocks ='" + stocks.Text + "'" +
                " WHERE Book_ID ='" + bookIDtxt.Text + "'", con);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();

                SqlDataSource1.SelectCommand = "SELECT Book.Book_ID,Book_name, Author_ID,Genre,Price," +
                        "Release_Date,Stocks,Price_Status, SUM(Quantity) as Sold_Books FROM BOOK FULL OUTER JOIN SALES on Sales.Book_ID = Book.Book_ID " +
                        "Group by book_Name,Book.Book_ID,Author_ID,Genre,Price,Release_Date,Stocks,Price_Status";
                updateBooks.Visible = false;
            }
            successMessage.Text = booknametxt.Text + " has been updated successfully.";
            clearUpdateBookField();
        }


        protected void DiscountButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridViewProductList.Rows.Count; i++)
            {
                CheckBox checkItem = (CheckBox)GridViewProductList.Rows[i].Cells[9].FindControl("CheckBoxItem");
                if (checkItem.Checked)
                {
                    con.Open();
                    int id = Convert.ToInt32(GridViewProductList.Rows[i].Cells[0].Text);

                    if (DiscountList.SelectedValue == "0")
                    {
                        SqlCommand commx = new SqlCommand(@"UPDATE Book SET Price_Status=" + "NULL" +
                            " WHERE Book_ID =" + id, con);
                        commx.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand commx = new SqlCommand(@"UPDATE Book SET Price_Status=" + "'" + DiscountList.SelectedValue.ToString() + "% OFF" + "'" +
                            @" FROM Book WHERE Book_ID =" + id, con);
                        commx.ExecuteNonQuery();
                    }


                    con.Close();
                }
            }
            SqlDataSource1.SelectCommand = "SELECT Book.Book_ID,Book_name, Author_ID,Genre,Price," +
                    "Release_Date,Stocks,Price_Status, SUM(Quantity) as Sold_Books FROM BOOK FULL OUTER JOIN SALES on Sales.Book_ID = Book.Book_ID " +
                    "Group by book_Name,Book.Book_ID,Author_ID,Genre,Price,Release_Date,Stocks,Price_Status";
            successMessage.Text = "Added discount.";
        }

        protected void AuthorUpdateLink_Click(object sender, EventArgs e)
        {
            updateAuthors.Visible = true;
            int indexrow = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            AuthorIDTextBox.Text = GridView1.Rows[indexrow].Cells[1].Text;
            AuthNameBox.Text = GridView1.Rows[indexrow].Cells[2].Text;
        }

        protected void UpdateAuthorButton_Click(object sender, EventArgs e)
        {
            if (AuthorIDTextBox.Text != "")
            {
                con.Open();
                if (!UpdateImg.HasFile)
                {
                    SqlCommand com = new SqlCommand("UPDATE Author SET Author_Name ='" + AuthNameBox.Text + "'" + " WHERE Author_ID =" + AuthorIDTextBox.Text, con);
                    com.ExecuteNonQuery();
                }
                else
                {
                    string fileName = Path.GetFileName(UpdateImg.PostedFile.FileName);
                    SqlCommand com = new SqlCommand("UPDATE Author SET Author_Name ='" + AuthNameBox.Text + "'" +
                        ",Author_Image ='" + fileName + "'" + " WHERE Author_ID =" + AuthorIDTextBox.Text, con);
                    com.ExecuteNonQuery();
                    UpdateImg.PostedFile.SaveAs(Server.MapPath("~/images/" + fileName));
                }
                con.Close();
                successMessage.Text = AuthNameBox.Text + " has been updated successfully.";
                clearUpdateAuthorField();
                SqlDataSource2.SelectCommand = "SELECT * FROM [Author]";
            }
            else
                successMessage.Text = "Please select an author to update";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            SqlDataSource2.SelectCommand = "SELECT * FROM [Author]";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            addBooks.Visible = true;
            addnewbook.Visible = false;
            addAuthors.Visible = true;
        }

        protected void addCancel_Click(object sender, EventArgs e)
        {
            addBooks.Visible = false;
            addnewbook.Visible = true;
            addAuthors.Visible = false;
            clearAddBookField();
            clearAddAuthorField();
        }

        protected void updateBookCancel_Click(object sender, EventArgs e)
        {
            updateBooks.Visible = false;
            clearUpdateBookField();
        }

        protected void updateAuthorCancel_Click(object sender, EventArgs e)
        {
            updateAuthors.Visible = false;
        }
        void clearUpdateBookField()
        {
            booknametxt.Text = "";
            authoridtxtbox.Text = "";
            pricebox.Text = "";
            reldatebox.Text = "";
            stocks.Text = "";
            action1.Checked = false;
            mystery1.Checked = false;
            drama1.Checked = false;
            fantasy1.Checked = false;
            horror1.Checked = false;
        }
        void clearAddBookField()
        {
            txtBookName.Text = "";
            AuthorIDTxt.Text = "";
            txtPrice.Text = "";
            RelDateTxt.Text = "";
            txtStock.Text = "";
            txtDiscount.Text = "";
            action.Checked = false;
            mystery.Checked = false;
            drama.Checked = false;
            fantasy.Checked = false;
            horror.Checked = false;
            addnewbook.Visible = true;
            addBooks.Visible = false;
            addAuthors.Visible = false;
            BookImageUpload.Dispose();
        }
        void clearAddAuthorField()
        {
            AuthorNameText.Text = "";
            AuthorImageUpload.Dispose();
        }
        void clearUpdateAuthorField()
        {
            AuthorIDTextBox.Text = "";
            AuthNameBox.Text = "";
            UpdateImg.Dispose();
        }

        protected void DeleteBooks_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < GridViewProductList.Rows.Count; i++)
                {
                    CheckBox checkItem = (CheckBox)GridViewProductList.Rows[i].Cells[9].FindControl("CheckBoxItem");
                    if (checkItem.Checked)
                    {
                        con.Open();
                        int id = Convert.ToInt32(GridViewProductList.Rows[i].Cells[0].Text);

                        SqlCommand commx = new SqlCommand(@"DELETE FROM BOOK WHERE Book_ID =" + id, con);
                        commx.ExecuteNonQuery();
                        con.Close();
                    }
                }
                SqlDataSource1.SelectCommand = "SELECT Book.Book_ID,Book_name, Author_ID,Genre,Price," +
                        "Release_Date,Stocks,Price_Status, SUM(Quantity) as Sold_Books FROM BOOK FULL OUTER JOIN SALES on Sales.Book_ID = Book.Book_ID " +
                        "Group by book_Name,Book.Book_ID,Author_ID,Genre,Price,Release_Date,Stocks,Price_Status";
                successMessage.Text = "Deleted Selected Books.";
            }
            catch
            {
                successMessage.Text = "Cannot Delete the book due to reference integrity";
            }
        }

        protected void RemoveAuthor_Click(object sender, EventArgs e)
        {
            try
            {
                int indexrow = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
                con.Open();
                SqlCommand com = new SqlCommand("DELETE FROM Author WHERE Author_ID =" + GridView1.Rows[indexrow].Cells[1].Text, con);
                com.ExecuteNonQuery();
                con.Close();
                successMessage.Text = GridView1.Rows[indexrow].Cells[2].Text + " has been successfully deleted";
                SqlDataSource2.SelectCommand = "SELECT * FROM [Author]";
            }
            catch
            {
                int indexrow = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
                successMessage.Text = "Cannot delete " + GridView1.Rows[indexrow].Cells[2].Text + " due to reference integrity";
            }
        }

    }
}