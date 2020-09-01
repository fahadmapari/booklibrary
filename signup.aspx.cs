using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Globalization;

namespace onlinebooklibary
{
    public partial class signup : System.Web.UI.Page
    {
        String username, email, password;
        int? phone;
        String s = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        String q = "";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public void signupUser()
        {
            
            if(!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(email)  && phone != null && !String.IsNullOrWhiteSpace(password) )
            {
                q = "select * from users where username = @username";
                con = new SqlConnection(s);
                con.Open();
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@username", username);
                dr = cmd.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    usernameErr.Text = "username already exists";
                    usernameErr.Visible = true;
                }
                else
                {
                    q = "insert into users values(@username , @email , @phone , @pass)";
                    con = new SqlConnection(s);
                    con.Open();
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.ExecuteNonQuery();

                    Response.Redirect("/login.aspx");
                        
                }
            }
            else
            {
                if(username == "")
                {
                    usernameErr.Visible = true;
                    usernameErr.Text = "username is required";
                }

                if(String.IsNullOrWhiteSpace(email))
                {
                    emailErr.Visible = true;
                    emailErr.Text = "email is required";
                }

                if(phone == null)
                {
                    mobilenumberErr.Visible = true;
                    mobilenumberErr.Text = "mobile number is required";
                }

                if(String.IsNullOrWhiteSpace(password))
                {
                    passwordErr.Visible = true;
                    passwordErr.Text = "password is required";
                }
            }
        }

        protected void signupbtn_Click(object sender, EventArgs e)
        {
            try
            {
                username = usernameIn.Text.ToString().Trim().Replace(" ", "").ToLower();
                phone = Convert.ToInt32(mobilenumberIn.Text.ToString().Trim());
                email = emailIn.Text.ToString().Trim();
                password = passwordIn.Text.ToString().Trim();
            }catch(Exception err)
            {
                Trace.Write(err.Message);
            }
            usernameErr.Visible = false;
            emailErr.Visible = false;
            mobilenumberErr.Visible = false;
            passwordErr.Visible = false;

            signupUser();
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"] != null)
            {
                Response.Redirect("/books.aspx");
            }
        }
    }
}