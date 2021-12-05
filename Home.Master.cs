using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mp
{
    public partial class Home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Name"] == null)
            {
                CartNav.Visible = false;
                AccountNav.Visible = false;
                Label1.Text = "LOG IN / SIGN UP";
            }
            else
            {
                CartNav.Visible = true;
                AccountNav.Visible = true;
                Label1.Text = "LOG OUT";
                Label2.Text = Session["Name"].ToString();
            }
        }


        protected void Unnamed_ServerClick5(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
                Session.Remove("Name");
            
            Response.Redirect("Sign in.aspx");
        }

        protected void Unnamed_ServerClick6(object sender, EventArgs e)
        {
            if (Session["Genre"] != null)
                Session.Remove("Genre");
            if (Session["FilterSelect"] != null)
                Session.Remove("FilterSelect");
            Response.Redirect("GenrePage.aspx");
        }
    }
}