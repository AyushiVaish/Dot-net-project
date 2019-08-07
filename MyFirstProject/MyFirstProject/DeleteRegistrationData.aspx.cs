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
    public partial class DeleteRegistrationData : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
        DataSet ds = new DataSet(); //as resultSet

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("spGetRegistrationDataWithId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblFirstName.Text = ds.Tables[0].Rows[0]["first_name"].ToString();
                    lblLastName.Text = ds.Tables[0].Rows[0]["last_name"].ToString();
                    lblUserName.Text = ds.Tables[0].Rows[0]["user_name"].ToString();
                    lblPassword.Text = ds.Tables[0].Rows[0]["password"].ToString();
                    lblEmailId.Text = ds.Tables[0].Rows[0]["email_id"].ToString();
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string EmailId = lblEmailId.Text;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spDeleteRegistrationData", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            if (result == 1)
            {
                Response.Redirect("~/RegistrationData.aspx");
            }
            else
            {
                lblMessage.Text = "There is some problem please check";
            }
        }
    }
}