using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mp
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpID"] != null)
            {
                if (!IsPostBack)
                {
                    SqlDataSource4.SelectCommand = "SELECT Count(1) as counterx, Count(DISTINCT Author_ID) as countery FROM Book";
                    SqlDataSource1.SelectCommand = "SELECT SUM(Total_Price) as Total_Pricex,SUM(Quantity) as Quantityx,COUNT(1) as Counterx,count(distinct username) as" +
                        " uniquecounter FROM [Sales] WHERE Status ='Delivered'";
                    SqlDataSource3.SelectCommand = "SELECT SUM(Quantity), SUM(Total_Price), COUNT(1) as Counterx, count(distinct username) FROM Sales WHERE Status = 'Ongoing'";
                    SqlDataSource2.SelectCommand = "SELECT SUM(Quantity) as lostqty, SUM(Total_Price) as lostrev, COUNT(1) as lostorder, count(distinct username) as lostunique FROM Sales WHERE Status = 'Canceled'";
                }
            }
            else
                Response.Redirect("AdminLogin.aspx");
        }
    }
}