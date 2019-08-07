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
    public partial class MyFirstWebForm : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("spGetAllStateName", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlState.Items.Clear();
                    ddlState.Items.Add("Select state");

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ddlState.Items.Add(ds.Tables[0].Rows[i][0].ToString());


                    }
            }
           
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
            
            string FirstName = firstName.Text;
            string LastName = lastName.Text;
            string UserName = userName.Text;
            string Password = password.Text;
            string EmailId= emailId.Text;
            string State = ddlState.SelectedValue;
            string City = ddlCity.SelectedValue;
            string Pincode = txtPinCode.Text;
            string Gender = string.Empty;
            string Programming=string.Empty;

            if (rdMale.Checked)
            {
                Gender = "Male";
            }
            else if(rdFemale.Checked) {
                Gender = "Female";
            }
            
                if(chkJava.Checked){
                    Programming = chkJava.Text + ",";
                }
                 if (chkdotNet.Checked) {
                    Programming = Programming + chkdotNet.Text + ",";

                }
                if (chkPython.Checked) {
                    Programming = Programming + chkPython.Text + ",";
                }
                if (chkCPlus.Checked) {
                    Programming = Programming + chkCPlus.Text + ",";
                }
                Programming = Programming.Substring(0, Programming.Length-1);
                


            if (string.IsNullOrEmpty(FirstName))
            {
                lblMessage.Text = "please insert first name";
                return;

            }

            else if (string.IsNullOrEmpty(LastName))
            {
                lblMessage.Text = "please insert last name";
                return;
            }

            if (string.IsNullOrEmpty(UserName))
            {
                lblMessage.Text = "please insert user name";
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                lblMessage.Text = "please insert password";
                return;
            }

            if (string.IsNullOrEmpty(EmailId))
            {
                lblMessage.Text = "please insert email id";
                return;
            }

          
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
        //    SqlCommand cmd = new SqlCommand("insert into registration values('" + FirstName + "','"+LastName+"','"+UserName+"','"+Password+"','"+EmailId + "')", conn);
         //Insert data using stored procedures
            SqlCommand cmd = new SqlCommand("spInsertRegistrationData", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@City",City);
            cmd.Parameters.AddWithValue("@Pincode",Pincode);
            cmd.Parameters.AddWithValue("@Gender",Gender);
            cmd.Parameters.AddWithValue("@Programming", Programming);


            int Result = cmd.ExecuteNonQuery();
            if (Result == 1)
            {
                lblMessage.Text = "Registration done successfully";
                ClearTextBox();
            }
            else
            {
                lblMessage.Text = "Any Error ,Please Check!!";
            }
            conn.Close();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
            }
                
            }
        /// <summary>
        /// This function is for clearing textbox values after form submission.
        /// </summary>
        public void ClearTextBox()
        {
            firstName.Text = string.Empty;
            lastName.Text = string.Empty;
            userName.Text = string.Empty;
            password.Text = string.Empty;
            emailId.Text = string.Empty;
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString; 
            string StateName = ddlState.SelectedValue;
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds= new DataSet(); 
            conn.Open();
            SqlCommand cmd = new SqlCommand("spGetAllCity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateName",StateName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlCity.Items.Clear();
                ddlCity.Items.Add("Select City");   
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                   
                    ddlCity.Items.Add(ds.Tables[0].Rows[i][0].ToString());


                }
            }
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e){
        string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString; 
            string CityName = ddlCity.SelectedValue;
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds= new DataSet(); 
            conn.Open();
            SqlCommand cmd = new SqlCommand("spGetPinCode", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityName",CityName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

               txtPinCode.Text=ds.Tables[0].Rows[0][0].ToString();
          
            }
        }      
        }
    }
 