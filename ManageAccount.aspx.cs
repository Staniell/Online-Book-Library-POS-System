using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace mp
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1N24CO\SQLEXPRESS;Initial Catalog=Zero;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpID"] != null)
            {
                if (!IsPostBack)
                {
                    SqlDataSource1.SelectCommand = "SELECT [Username], [Payment_Method], [Account_Status] FROM [Registered] WHERE Account_Status ='Deactivation Request'";
                    SqlDataSource2.SelectCommand = "SELECT [Username], Account_Status FROM [Registered] WHERE Account_Status ='To Be Deleted'";
                    SqlDataSource3.SelectCommand = "SELECT Email, Passwordx, Account_Status FROM REGISTERED WHERE Account_Status = 'Forgotten Password'";
                    if (GridView2.Rows.Count == 0)
                        DeleteButton.Visible = false;
                    if (GridView1.Rows.Count == 0)
                        CancelButton.Visible = false;
                    if (GridView3.Rows.Count == 0)
                        passwordsentbutton.Visible = false;
                }
            }
            else
                Response.Redirect("AdminLogin.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox checkItem = (CheckBox)GridView1.Rows[i].Cells[3].FindControl("CheckBoxItem");
                if (checkItem.Checked)
                {
                    con.Open();
                    SqlCommand commx = new SqlCommand(@"UPDATE Registered SET Account_Status=" + "'To Be Deleted'" + @" FROM Registered WHERE Username = '" + GridView1.Rows[i].Cells[0].Text + "'", con);

                    commx.ExecuteNonQuery();

                    con.Close();
                }
            }
            SqlDataSource1.SelectCommand = "SELECT [Username], [Payment_Method], [Account_Status] FROM [Registered] WHERE Account_Status ='Deactivation Request'";
            SqlDataSource2.SelectCommand = "SELECT [Username], Account_Status FROM [Registered] WHERE Account_Status ='To Be Deleted'";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            SqlDataSource1.SelectCommand = "SELECT [Username], [Payment_Method], [Account_Status] FROM [Registered] WHERE Account_Status ='Deactivation Request'";
        }



        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                CheckBox checkItem = (CheckBox)GridView2.Rows[i].Cells[2].FindControl("CheckBoxItem");
       
                if (checkItem.Checked)
                {
                    con.Open();
                    SqlCommand commy = new SqlCommand(@"DELETE FROM Cart_Books " + "WHERE Username = '" + GridView2.Rows[i].Cells[0].Text + "'", con);
                    commy.ExecuteNonQuery();

                    SqlCommand commx = new SqlCommand(@"DELETE FROM Sales " + "WHERE Username = '" + GridView2.Rows[i].Cells[0].Text + "'", con);

                    commx.ExecuteNonQuery();

                    SqlCommand commz = new SqlCommand(@"DELETE FROM Registered " + "WHERE Username = '" + GridView2.Rows[i].Cells[0].Text + "'", con);

                    commz.ExecuteNonQuery();

                    con.Close();
                }
            }
            SqlDataSource2.SelectCommand = "SELECT [Username], Account_Status FROM [Registered] WHERE Account_Status ='To Be Deleted'";
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            SqlDataSource2.SelectCommand = "SELECT [Username], Account_Status FROM [Registered] WHERE Account_Status ='To Be Deleted'";
        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlDataSource2.SelectCommand = "SELECT [Username], Account_Status FROM [Registered] WHERE Account_Status ='To Be Deleted'";
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT [Username], [Payment_Method], [Account_Status] FROM [Registered] WHERE Account_Status ='Deactivation Request'";
        }

        protected void passwordsentbutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView3.Rows.Count; i++)
            {
              
                CheckBox checkItem = (CheckBox)GridView3.Rows[i].Cells[3].FindControl("checkItems");
                if (checkItem.Checked)
                {
                    con.Open();
                    SqlCommand commx = new SqlCommand(@"UPDATE Registered SET Account_Status=" + "'Active'" + @" FROM Registered WHERE Email = '" + GridView3.Rows[i].Cells[0].Text + "'", con);

                    commx.ExecuteNonQuery();

                    con.Close();
                }
            }
            SqlDataSource3.SelectCommand = "SELECT Email, Passwordx, Account_Status FROM REGISTERED WHERE Account_Status = 'Forgotten Password'";
        }
    }
}