using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace mp
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-G1N24CO\SQLEXPRESS;Initial Catalog=Zero;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpID"] != null)
            {
                if (!IsPostBack)
                    SqlDataSource2.SelectCommand = "SELECT * FROM SALES WHERE status LIKE '%Ongoing%' or status = 'Cancellation Request'";
            }
            else
                Response.Redirect("AdminLogin.aspx");

        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox checkItem = (CheckBox)GridView1.Rows[i].Cells[7].FindControl("CheckBoxItem");
               
                if (checkItem.Checked)
                {
                    con.Open();
                    int id = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                    SqlCommand commx = new SqlCommand(@"UPDATE Sales SET Status=" + "'Canceled'" + @" FROM Sales WHERE Order_ID =" + id + " " +
                        "and Username = '" + GridView1.Rows[i].Cells[2].Text + "'", con);

                    commx.ExecuteNonQuery();

                    //Add the no. of quantity to be delivered back to the stocks since it's cancelled
                    SqlCommand commy = new SqlCommand("UPDATE Book SET Stocks=Stocks+" + GridView1.Rows[i].Cells[3].Text +
                        " From Book WHERE Book_ID =" + GridView1.Rows[i].Cells[1].Text, con);
                    commy.ExecuteNonQuery();

                    con.Close();
                }
            }
            SqlDataSource2.SelectCommand = "SELECT * FROM SALES WHERE status LIKE '%Ongoing%' or status = 'Cancellation Request'";
        }

        protected void DeliveredButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox checkItem = (CheckBox)GridView1.Rows[i].Cells[7].FindControl("CheckBoxItem");
               
                if (checkItem.Checked)
                {
                    con.Open();
                    int id = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                    SqlCommand commx = new SqlCommand(@"UPDATE Sales SET Status=" + "'Delivered'" + @" FROM Sales WHERE Order_ID =" + id + " " +
                        "and Username = '" + GridView1.Rows[i].Cells[2].Text + "'", con);

                    commx.ExecuteNonQuery();

                    con.Close();
                }
            }
            SqlDataSource2.SelectCommand = "SELECT * FROM SALES WHERE status LIKE '%Ongoing%' or status = 'Cancellation Request'";

        }



        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
                SqlDataSource2.SelectCommand = "SELECT * FROM SALES WHERE status LIKE '%Ongoing%' or status = 'Cancellation Request'";
            else
                SqlDataSource2.SelectCommand = "SELECT * FROM SALES WHERE Username =" + "'" + NameTextBox.Text + "' AND status LIKE '%Ongoing%' or status ='Cancellation Request'";
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            SqlDataSource2.SelectCommand = "SELECT * FROM SALES WHERE status LIKE '%Ongoing%' or status = 'Cancellation Request'";
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            SqlDataSource2.SelectCommand = "SELECT * FROM SALES WHERE status LIKE '%Ongoing%' or status = 'Cancellation Request'";
        }

        protected void RejectButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox checkItem = (CheckBox)GridView1.Rows[i].Cells[7].FindControl("CheckBoxItem");
               
                if (checkItem.Checked)
                {
                    if (GridView1.Rows[i].Cells[8].Text != "Cancellation Request")
                    {
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "Alert1", "alert('Cannot update this row as it is not requesting for cancellation');", true);
                        break;
                    }

                    else
                    {
                        con.Open();
                        int id = Convert.ToInt32(GridView1.Rows[i].Cells[0].Text);
                        SqlCommand commx = new SqlCommand(@"UPDATE Sales SET Status=" + "'Ongoing(Request Rejected)'" + @" FROM Sales WHERE Order_ID =" + id + " " +
                            "and Username = '" + GridView1.Rows[i].Cells[2].Text + "'", con);

                        commx.ExecuteNonQuery();

                        con.Close();
                    }
                }
            }
            SqlDataSource2.SelectCommand = "SELECT * FROM SALES WHERE status LIKE '%Ongoing%' or status = 'Cancellation Request'";
        }
    }
}