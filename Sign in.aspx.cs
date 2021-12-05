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
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1N24CO\SQLEXPRESS;Initial Catalog=Zero;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signInBtn_Click(object sender, EventArgs e)
        {
            con.Open();
            var comm = new SqlCommand("SELECT COUNT(1) FROM Registered WHERE username=@username AND" +
                " passwordx=@password", con); //Count all rows that are not null if credentials are equal
            comm.Parameters.AddWithValue("@username", EmailTxtbox.Text.Trim());
            comm.Parameters.AddWithValue("@password", passwordtxtbox.Text.Trim());

            byte count = Convert.ToByte(comm.ExecuteScalar());//Read the first result
           
            SqlDataReader dr;
            var commy = new SqlCommand("SELECT Account_Status FROM Registered WHERE username ='"+EmailTxtbox.Text+"'", con);
            dr = commy.ExecuteReader();

            string acc_status = "";
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    acc_status = dr[0].ToString();
                }
            }

            if (count == 1 && acc_status!="To Be Deleted")
            {
                Session["Name"] = EmailTxtbox.Text.Trim();
                Response.Redirect("Home.aspx");
            }

            else
            {
                if(acc_status == "To Be Deleted")
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('This account has been deactivated');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Login fail! Invalid username or password');", true);
            }
            con.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (EmailTxtbox.Text == "")
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Please enter your username');", true);
            else
            {
                con.Open();
                var commc = new SqlCommand("SELECT COUNT(1) FROM Registered WHERE username='"+ EmailTxtbox.Text.Trim()+"'", con);
                byte count = Convert.ToByte(commc.ExecuteScalar());//Read the first result

                if (count == 1)
                {
                    con.Close();
                    con.Open();
                    var comm = new SqlCommand("UPDATE Registered SET Account_Status = 'Forgotten Password'" +
                        " FROM Registered WHERE Username = '" + EmailTxtbox.Text.Trim() + "'", con);
                    comm.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Your current password will be sent to your email');", true);
                }

                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('Username does not exist');", true);
                con.Close();
            }
        }

    }
}