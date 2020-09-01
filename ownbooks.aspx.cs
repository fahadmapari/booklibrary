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
    public partial class ownbooks : System.Web.UI.Page
    {
        String q = "";
        String username;
        String s = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if(Session["role"].ToString() == "admin") { Response.Redirect("/books.aspx"); }
                username = Session["username"].ToString();
                q = "select * from soldbooks, books where soldbooks.bookid = books.bookid and soldbooks.username = @username";
                con = new SqlConnection(s);
                con.Open();
                cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@username", username);
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
                }
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }

        
    }
}