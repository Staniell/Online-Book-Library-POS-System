using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace mp
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        //Your connection string
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1N24CO\SQLEXPRESS;Initial Catalog=Zero;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (YearList.Visible == false)
                //    Button6.Visible = false;
                YearList.Items.Add(new ListItem("Year"));
                for (int yearx = 2020; yearx <= 2030; yearx++)
                    YearList.Items.Add(new ListItem(yearx.ToString()));

                MonthList.Items.Add(new ListItem("Month"));
                for (int monthx = 1; monthx <= 12; monthx++)
                {
                    if (monthx > 9)
                        MonthList.Items.Add(new ListItem(monthx.ToString()));
                    else
                        MonthList.Items.Add(new ListItem("0" + monthx.ToString()));
                }

                if (Session["Name"] != null)
                {
                    DataShow();
                }
            }
        }

        protected void DataShow()
        {
            SqlDataSource2.SelectCommand = "SELECT Order_ID,Book_Name, Quantity, Total_Price, Sales.Payment_Method, Date_Purchased, ETA, Status FROM Sales LEFT JOIN " +
                    "Registered on Sales.Username = Registered.Username RIGHT JOIN Book on Book.Book_ID = " +
                    "Sales.Book_ID WHERE Sales.Username =" + "'" + Session["Name"].ToString() + "'" + " ORDER BY Date_Purchased DESC";
            SqlDataSource1.SelectCommand = "SELECT * FROM [Registered] WHERE Username = '" + Session["Name"].ToString() + "'";
            //DataList1.DataBind();
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
           
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            con.Open();

            TextBox email = e.Item.FindControl("EmailTextBox") as TextBox;
            TextBox address = e.Item.FindControl("AddressTextBox") as TextBox;
            TextBox phone = e.Item.FindControl("PhoneTextBox") as TextBox;
            TextBox password = e.Item.FindControl("PasswordTextBox") as TextBox;

            List<TextBox> textBoxes = new List<TextBox>() {email,address,phone,password};

            Button emailUpdate = e.Item.FindControl("EmailUpdate") as Button;
            Button addressUpdate = e.Item.FindControl("AddressUpdate") as Button;
            Button phoneUpdate = e.Item.FindControl("PhoneUpdate") as Button;
            Button passwordUpdate = e.Item.FindControl("PasswordUpdate") as Button;

            Button cancel1 = e.Item.FindControl("Button1") as Button;
            Button cancel2 = e.Item.FindControl("Button2") as Button;
            Button cancel3 = e.Item.FindControl("Button3") as Button;
            Button cancel4 = e.Item.FindControl("Button4") as Button;

            
            if (e.CommandName == "Cancel1")
            {
                email.Visible = false;
                emailUpdate.Visible = false;
                cancel1.Visible = false;
            }

            if (e.CommandName == "Cancel2")
            {
                address.Visible = false;
                addressUpdate.Visible = false;
                cancel2.Visible = false;
            }

            if (e.CommandName == "Cancel3")
            {
                phone.Visible = false;
                phoneUpdate.Visible = false;
                cancel3.Visible = false;
            }

            if (e.CommandName == "Cancel4")
            {
                password.Visible = false;
                passwordUpdate.Visible = false;
                cancel4.Visible = false;
            }


            if (e.CommandName == "ChangeEmail")
            {
                email.Visible = true;
                emailUpdate.Visible = true;
                cancel1.Visible = true;
            }

            if (e.CommandName == "ChangeAddress")
            {
                address.Visible = true;
                addressUpdate.Visible = true;
                cancel2.Visible = true;
            }

            if (e.CommandName == "ChangePhone")
            {
                phone.Visible = true;
                phoneUpdate.Visible = true;
                cancel3.Visible = true;
            }

            if (e.CommandName == "ChangePassword")
            {
                password.Visible = true;
                passwordUpdate.Visible = true;
                cancel4.Visible = true;
            }

            if (e.CommandName == "ChangePayment")
            {
                PaymentList.Visible = true;
                PaymentUpdate.Visible = true;
                Button5.Visible = true;
            }


            if (e.CommandName == "EmailUpdate")
            {
                if (!isFilled(email))
                {
                    SqlCommand commx = new SqlCommand(@"UPDATE Registered SET Email =" + "'" + email.Text.ToString() + "'" +
                        @" FROM book WHERE Username =" + "'" + Session["Name"].ToString() + "'", con);

                    commx.ExecuteNonQuery();
                    con.Close();
                    DataShow();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Email updated!');", true);
                }
                
            }

            if (e.CommandName == "AddressUpdate")
            {
                if (!isFilled(address))
                {
                    SqlCommand commx = new SqlCommand(@"UPDATE Registered SET Address =" + "'" + address.Text.ToString() + "'" +
                        @" FROM book WHERE Username =" + "'" + Session["Name"].ToString() + "'", con);

                    commx.ExecuteNonQuery();
                    con.Close();
                    DataShow();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Address updated!');", true);
                }
            }

            if (e.CommandName == "PhoneUpdate")
            {
                if (!isFilled(phone) && !phone.Text.Any(x => char.IsLetter(x)))
                {
                    SqlCommand commx = new SqlCommand(@"UPDATE Registered SET Number =" + "'" + phone.Text.ToString() + "'" +
                        @" FROM book WHERE Username =" + "'" + Session["Name"].ToString() + "'", con);

                    commx.ExecuteNonQuery();
                    con.Close();
                    DataShow();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Phone/Telephone No. updated!');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Phone/Telephone No. is invalid! It may not contain letters');", true);
                }
            }

            if (e.CommandName == "PasswordUpdate")
            {
                if (!isFilled(password))
                {
                    SqlCommand commx = new SqlCommand(@"UPDATE Registered SET Passwordx =" + "'" + password.Text.ToString() + "'" +
                        @" FROM book WHERE Username =" + "'" + Session["Name"].ToString() + "'", con);

                    commx.ExecuteNonQuery();
                    con.Close();
                    DataShow();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Password Updated!');", true);
                }
            }



            bool isFilled(TextBox txtbox)
            {
                if (txtbox.Text.ToString() == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please insert a value');", true);
                    return true;
                }
                else
                    return false;
            }


        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand commx = new SqlCommand(@"UPDATE Registered SET Account_Status =" + "'Deactivation Request'" +
                        @" FROM Registered WHERE Username =" + "'" + Session["Name"].ToString() + "'", con);

            commx.ExecuteNonQuery();
            con.Close();
            ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert1", "alert('Your account deactivation request will be processed within a month. Please wait a while');", true);
        }



        protected void PaymentList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (PaymentList.SelectedIndex == 1)
            {
                showCredentials(true);
            }
            else
                showCredentials(false);

        }

        void showCredentials(bool x)
        {
            CCText1.Visible = x;
            SCText1.Visible = x;
            MonthList.Visible = x;
            YearList.Visible = x;
            Label2.Visible = x;
        }

        protected void PaymentUpdate_Click(object sender, EventArgs e)
        {
            con.Open();

            if (PaymentList.SelectedIndex == 0)
            {
                SqlCommand commx = new SqlCommand(@"UPDATE Registered SET Payment_Method =" + "'" + PaymentList.SelectedValue.ToString() + "'" +
                    @" FROM book WHERE Username =" + "'" + Session["Name"].ToString() + "'", con);

                commx.ExecuteNonQuery();
                showCredentials(false);
                PaymentList.Visible = false;
                Button5.Visible = false;
                PaymentUpdate.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Payment Method updated!');", true);
            }
            

            else if (PaymentList.SelectedIndex == 1)
            {
                bool success = true;
                try
                {
                    if (SCText1.Text.Length != 3 || !SCText1.Text.All(Char.IsDigit))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Security Code No. Length must be equal to 3 and must be digits only');", true);
                        success = false;
                    }
                    if (CCText1.Text.Length != 16 || !CCText1.Text.All(Char.IsDigit))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Credit Card No.Length must be equal to 16 and must be digits only');", true);
                        success = false;
                        success = false;
                    }
                    if (success)
                    {
                        SqlCommand commx = new SqlCommand(@"UPDATE Registered SET Payment_Method =" + "'" + PaymentList.SelectedValue.ToString() + "'," + "Credit_No =" + "'" + CCText1.Text.ToString() + "'" +
                       ",Security_Code =" + "'" + SCText1.Text.ToString() + "'," + "Expiry_Date =" + "'" + YearList.SelectedValue.ToString() + MonthList.SelectedValue.ToString()
                       + "01" + "'" + @" FROM book WHERE Username =" + "'" + Session["Name"].ToString() + "'", con);

                        commx.ExecuteNonQuery();
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Payment Method updated!');", true);
                        showCredentials(false);
                        PaymentList.Visible = false;
                        Button5.Visible = false;
                        PaymentUpdate.Visible = false;
                    }
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please select a valid year and month');", true);
                }
            }

            con.Close();
            DataShow();
            
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            PaymentList.Visible = false;
            Button5.Visible = false;
            PaymentUpdate.Visible = false;
            showCredentials(false);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                LinkButton link1 = (LinkButton)e.Row.FindControl("CancelButton");
                if (e.Row.Cells[7].Text == "Ongoing")
                {
                    link1.Visible = true;
                }

            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            cancellation_formx.Visible = true;
            int indexrow = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            OrderIDBox.Text = GridView1.Rows[indexrow].Cells[0].Text;
            BookNameBoxz.Text = GridView1.Rows[indexrow].Cells[1].Text;
            QuantityBoxz.Text = GridView1.Rows[indexrow].Cells[2].Text;
            PriceBoxz.Text = "₱" + GridView1.Rows[indexrow].Cells[3].Text;

        }

        protected void CancelOrderButton_Click(object sender, EventArgs e)
        {
            if (ReasonTxtBoxz.Text == "")
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please enter a reason for cancellation');", true);
            else
            {
                con.Open();
                SqlCommand com = new SqlCommand("UPDATE SALES Set Status ='Cancellation Request', Reason='" + ReasonTxtBoxz.Text + "'" + " WHERE Username='" + Session["Name"].ToString() + "'" +
                    " and Order_ID =" + OrderIDBox.Text, con);
                com.ExecuteNonQuery();
                con.Close();

                SqlDataSource2.SelectCommand = "SELECT Order_ID,Book_Name, Quantity, Total_Price, Sales.Payment_Method, Date_Purchased, ETA, Status FROM Sales LEFT JOIN " +
                        "Registered on Sales.Username = Registered.Username RIGHT JOIN Book on Book.Book_ID = " +
                        "Sales.Book_ID WHERE Sales.Username =" + "'" + Session["Name"].ToString() + "'" + " ORDER BY Date_Purchased DESC";
                cancellation_formx.Visible = false;
            }
        }
    }
}