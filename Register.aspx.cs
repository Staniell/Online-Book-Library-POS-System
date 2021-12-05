using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace mp
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1N24CO\SQLEXPRESS;Initial Catalog=Zero;Integrated Security=True");
        protected Dictionary<System.Web.UI.WebControls.TextBox, string> user_inputs = new Dictionary<System.Web.UI.WebControls.TextBox, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
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
            }
            user_inputs = new Dictionary<System.Web.UI.WebControls.TextBox, string>(){
                { UserTextbox,"Username" },{ EmailTextBox,"Email" },{ PasswordTextBox,"Password" },
                {AddressTextBox, "Home Address" },{NumberTextBox, "Number"},{CCTextBox, "Credit Card No."},
                {SCTextBox, "Security Code No." }
            };
        }

        protected void PaymentMethodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PaymentMethodList.SelectedValue == "Credit Card")
            {
                CCLabel.Visible = true;
                CCTextBox.Visible = true;
                SCLabel.Visible = true;
                SCTextBox.Visible = true;
                ExpiryLabel.Visible = true;
                MonthList.Visible = true;
                YearList.Visible = true;
                
            }
            else
            {
                CCLabel.Visible = false;
                CCTextBox.Visible = false;
                SCLabel.Visible = false;
                SCTextBox.Visible = false;
                ExpiryLabel.Visible = false;
                MonthList.Visible = false;
                YearList.Visible = false;
            }
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            con.Open();
            bool registered = false;

            //Check for empty inputs
            for (int i = 0; i < user_inputs.Count; i++)
            {
                if (PaymentMethodList.SelectedValue != "Credit Card" && i == 5)
                {
                    registered = true;
                    break;
                }
                if (user_inputs.ElementAt(i).Key.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please fill out every fields');", true);
                    break;
                }
                //if (!user_inputs.ElementAt(4).Key.Text.Any(x => char.IsLetter(x)))
                //{
                //    break;
                //}

                if (i == 3 && AddressTextBox.Text.Length < 10)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please enter a valid address');", true);
                    break;
                }


                if (i > 4)
                {
                    if (CCTextBox.Text.Length != 16 || !CCTextBox.Text.All(Char.IsDigit))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Credit Card No.Length must be equal to 16 and must be digits only');", true);
                        break;
                    }
                    if (SCTextBox.Text.Length != 3 || !SCTextBox.Text.All(Char.IsDigit))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Security Code No. Length must be equal to 3 and must be digits only');", true);
                        break;
                    }
                    if (i == 6 && YearList.SelectedValue.ToString() == "Year" || i == 6 && MonthList.SelectedValue.ToString() == "Month")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please select a valid expiration year');", true);
                        break;
                    }
                    if (i == 6 && SCTextBox.Text.Length == 3 || i == 6 && !SCTextBox.Text.All(Char.IsDigit))
                        registered = true;
                }
            }

            try
            {
                if (registered)
                {
                    if (PaymentMethodList.SelectedValue.ToString() == "Credit Card")
                    {
                        SqlCommand comm = new SqlCommand("INSERT INTO Registered VALUES('" + UserTextbox.Text.Trim() + "','" + EmailTextBox.Text.Trim()
                            + "','" + PasswordTextBox.Text.Trim() + "','" + AddressTextBox.Text.Trim() + "','" + NumberTextBox.Text.Trim()
                            + "','" + PaymentMethodList.SelectedValue.ToString() + "','" + CCTextBox.Text.Trim() + "','" + SCTextBox.Text.Trim()
                            + "','" + YearList.SelectedValue.ToString() + MonthList.SelectedValue.ToString() + "01" + "','" + "ACTIVE"+ "')", con);
                        comm.ExecuteNonQuery();
                        con.Close();
                        Session["Name"] = UserTextbox.Text;
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Registration Successful');", true);
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        SqlCommand comm = new SqlCommand("INSERT INTO Registered VALUES('" + UserTextbox.Text.Trim() + "','" + EmailTextBox.Text.Trim()
                            + "','" + PasswordTextBox.Text.Trim() + "','" + AddressTextBox.Text.Trim() + "','" + NumberTextBox.Text.Trim()
                            + "','" + PaymentMethodList.SelectedValue.ToString() + "','" + DBNull.Value + "','" + DBNull.Value + "','" + DBNull.Value + "','" + "ACTIVE" + "')", con);
                        comm.ExecuteNonQuery();
                        con.Close();
                        Session["Name"] = UserTextbox.Text;
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Registration Successful');", true);
                        Response.Redirect("Home.aspx");
                    }
                }
                
                
            }

            catch (SqlException x)
            {
                if (x.Number == 2627)
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Username or email already exists');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('One of your input fields is too long! Shorten it');", true);
            }
        }

        protected void UserTextbox_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            var comm = new SqlCommand("SELECT COUNT(1) FROM Registered WHERE username='" +UserTextbox.Text+"'", con);
            byte count = Convert.ToByte(comm.ExecuteScalar());//Read the first result

            if (count == 1)
                Label2.Visible = true;
            else
                Label2.Visible = false;
            con.Close();
        }

        protected void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            var comm = new SqlCommand("SELECT COUNT(1) FROM Registered WHERE email='" + EmailTextBox.Text + "'", con);
            byte count = Convert.ToByte(comm.ExecuteScalar());//Read the first result

            if (count == 1)
                Label1.Visible = true;
            else
                Label1.Visible = false;
            con.Close();
        }
    }
}