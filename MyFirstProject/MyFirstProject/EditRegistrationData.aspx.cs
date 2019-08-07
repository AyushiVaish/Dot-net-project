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
    public partial class EditRegistrationData : System.Web.UI.Page
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
                    txtfirstName.Text = ds.Tables[0].Rows[0]["first_name"].ToString();
                    txtlastName.Text = ds.Tables[0].Rows[0]["last_name"].ToString();
                    txtuserName.Text = ds.Tables[0].Rows[0]["user_name"].ToString();
                    txtpassword.Text = ds.Tables[0].Rows[0]["password"].ToString();
                    txtemailId.Text = ds.Tables[0].Rows[0]["email_id"].ToString();
                    txtPinCode.Text = ds.Tables[0].Rows[0]["pincode"].ToString();
                    //Filling state dropdown

                    if (ds.Tables[1].Rows.Count > 0) {
                        ddlState.Items.Add("Select State");
                        for (int i = 0; i < ds.Tables[1].Rows.Count;i++ ) {
                            ddlState.Items.Add(ds.Tables[1].Rows[i][0].ToString());
                        }
                    
                    }
                    string StateName = ds.Tables[0].Rows[0]["state"].ToString();
                    string CityName = ds.Tables[0].Rows[0]["city"].ToString();
                    string Gender=ds.Tables[0].Rows[0]["gender"].ToString();
                    string programming=ds.Tables[0].Rows[0]["programming"].ToString();
                    ddlState.SelectedValue = StateName;
                        ds.Tables.Clear();
                    cmd = new SqlCommand("spGetAllCity", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StateName",StateName);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    
                    if(ds.Tables[0].Rows.Count>0)
                    {
                    ddlCity.Items.Add("Select city");
                        for(int i=0;i<ds.Tables[0].Rows.Count;i++)
                        {
                        ddlCity.Items.Add(ds.Tables[0].Rows[i][0].ToString());

                        }
                    }
                    ddlCity.SelectedValue = CityName;

                    if (Gender == "Male")
                    {
                        rdMale.Checked = true;
                    }
                    else {
                        rdFemale.Checked = true;
                    }

           string[] str= programming.Split(',');

                    for (int i = 0; i < str.Count();i++ )
                    {
                        if(str[i]=="Java"){
                            chkJava.Checked = true;
                        }
                        if (str[i] == "Dot Net") {
                            chkdotNet.Checked = true;
                        }
                        if (str[i] == "Python") {
                            chkPython.Checked = true;
                        }
                        if (str[i] == "C++") {
                            chkCPlus.Checked = true;
                        }
                    }
                }
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string FirstName = txtfirstName.Text;
            string LastName = txtlastName.Text;
            string UserName = txtuserName.Text;
            string Password = txtpassword.Text;
            string EmailId = txtemailId.Text;
            string State = ddlState.SelectedValue;
            string City = ddlCity.SelectedValue;
            string Pincode = txtPinCode.Text;
            string Gender = string.Empty;
            string Programming = string.Empty;

            if (rdMale.Checked)
            {
                Gender = "Male";
            }
            else if (rdFemale.Checked)
            {
                Gender = "Female";
            }

            if (chkJava.Checked)
            {
                Programming = chkJava.Text + ",";
            }
            if (chkdotNet.Checked)
            {
                Programming = Programming + chkdotNet.Text + ",";

            }
            if (chkPython.Checked)
            {
                Programming = Programming + chkPython.Text + ",";
            }
            if (chkCPlus.Checked)
            {
                Programming = Programming + chkCPlus.Text + ",";
            }
            Programming = Programming.Substring(0, Programming.Length - 1);
                

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spEditRegistrationData", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", FirstName);
            cmd.Parameters.AddWithValue("@LastName", LastName);
            cmd.Parameters.AddWithValue("@UserName", UserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@EmailId", EmailId);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Pincode", Pincode);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Programming", Programming);

            int result = cmd.ExecuteNonQuery();
            con.Close();
             if (result == 1){
             Response.Redirect("~/RegistrationData.aspx");
             }
             else {
             lblMessage.Text="There is some problem please check";
             }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
            string StateName = ddlState.SelectedValue;
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("spGetAllCity", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateName", StateName);
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

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CSE"].ConnectionString;
            string CityName = ddlCity.SelectedValue;
            SqlConnection conn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            conn.Open();
            SqlCommand cmd = new SqlCommand("spGetPinCode", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CityName", CityName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                txtPinCode.Text = ds.Tables[0].Rows[0][0].ToString();

            }
        }

     
    }
}