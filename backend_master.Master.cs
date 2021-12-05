using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mp
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// ManageProducts.aspx
            //    / Statistics.aspx
            //    / ManageOrders.aspx
            //    / ManageAccount.aspx
            /// AdminLogin.aspx

            if (HttpContext.Current.Request.Url.AbsolutePath == "/AdminLogin.aspx")
                navbarx.Visible = false;
            else
                navbarx.Visible = true;

        }
        protected void btnManageProducts_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageProducts.aspx");
        }

        protected void btnManageOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageOrders.aspx");
        }

        protected void btnManageCustomers_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageCustomers.aspx");
        }

        protected void btnManageAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageAccount.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogIn.aspx");
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Statistics.aspx");
        }
    }
}