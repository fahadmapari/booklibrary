using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace onlinebooklibary
{
    public partial class adminlogin : System.Web.UI.Page
    {
        String username, password;
        String s = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        String q = "";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public void loginuser()
        {
            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                q = "select * from admins where username = @username";
                con = new SqlConnection(s);
                con.Open();
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@username", username);
                dr = cmd.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    if (password == dr["pass"].ToString())
                    {
                        Session["username"] = dr["username"].ToString();
                        Session["role"] = "admin";
                        Response.Redirect("/bookupload.aspx");
                    }
                }
                else
                {
                    usernameErr.Visible = true;
                    usernameErr.Text = "user does not exist";
                }
            }
            else
            {
                if (String.IsNullOrWhiteSpace(username))
                {
                    usernameErr.Visible = true;
                    usernameErr.Text = "username is required";
                }

                if (String.IsNullOrWhiteSpace(password))
                {
                    passwordErr.Visible = true;
                    passwordErr.Text = "password is required";
                }
            }
        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            username = usernameIn.Text.ToString().Trim().Replace(" ", "").ToLower();
            password = passwordIn.Text.ToString().Trim();

            usernameErr.Visible = false;
            passwordErr.Visible = false;

            loginuser();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("/books.aspx");
            }
        }
    }
}