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
    public partial class RegistrationData : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
        DataSet ds= new DataSet(); //as resultSet
       protected List<registration> regListObj = new List<registration>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string EmailId = string.Empty;
            if (Session["EmailId"] != null)
            {
                EmailId = Session["EmailId"].ToString();

            }
            else {
                Response.Redirect("~/Login.aspx");
            }

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
           //SqlCommand cmd = new SqlCommand("select * from Registration " ,con);
            SqlCommand cmd = new SqlCommand("spDisplayRegistrationData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmailId",EmailId);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count>0)
            {
                lblMessage.Text = "Welcome" + ds.Tables[0].Rows[0] ["first_name"] .ToString();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++) {
                    regListObj.Add(new registration { 
                    Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString()),
                    FirstName = ds.Tables[0].Rows[i]["first_name"].ToString(),
                    LastName = ds.Tables[0].Rows[i]["last_name"].ToString(),
                    UserName = ds.Tables[0].Rows[i]["user_name"].ToString(),
                    Password = ds.Tables[0].Rows[i]["password"].ToString(),
                    EmailId= ds.Tables[0].Rows[i]["email_id"].ToString(),
                    State = ds.Tables[0].Rows[i]["state"].ToString(),
                    City = ds.Tables[0].Rows[i]["city"].ToString(),
                     Pincode= ds.Tables[0].Rows[i]["pincode"].ToString(),
                      Gender= ds.Tables[0].Rows[i]["gender"].ToString(),
                       Programming= ds.Tables[0].Rows[i]["programming"].ToString()

                   
                    
                   

                    });
                }
            }
            else {}
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MyFirstWebForm.aspx");
        }
    }
}