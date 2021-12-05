using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace mp
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }
        protected void signInBtn_Click(object sender, EventArgs e)
        {
            SqlConnection signIn = new SqlConnection(@"Data Source=DESKTOP-G1N24CO\SQLEXPRESS;Initial Catalog=Zero;Integrated Security=True");
            SqlCommand signInCMD = new SqlCommand("Select * from [Employee] where [Employee_ID]='" + EmployeeIDTextBox.Text + "' and [Employee_Password]='" + passwordTextBox.Text + "';", signIn);
            SqlDataAdapter signInAdapter = new SqlDataAdapter(signInCMD);
            DataTable signInDT = new DataTable();
            signInAdapter.Fill(signInDT);
            signIn.Open();
            signInCMD.ExecuteNonQuery();
            if (signInDT.Rows.Count > 0)
            {
                Session["EmpID"] = EmployeeIDTextBox.Text;
                Response.Redirect("ManageOrders.aspx");
            }
            else
            {
                signInError.Text = "Incorrect Employee ID or Password.";
            }
        }
    }
}