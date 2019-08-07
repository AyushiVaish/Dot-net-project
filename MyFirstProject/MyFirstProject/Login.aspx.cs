using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFirstProject
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnlogin_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
            DataSet ds = new DataSet(); //as resultSet
            string EmailId = txtEmailId.Text;
            string Password = txtPassword.Text;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetLogInData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmailID", EmailId);
            cmd.Parameters.AddWithValue("@Password", Password);
              SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["EmailId"] = EmailId;
                    Response.Redirect("~/RegistrationData.aspx");
                }
                else {
                    Lblmsg.Text = "Email or password wrong";
                }
        }
    }
}