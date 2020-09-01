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
    public partial class WebForm1 : System.Web.UI.Page
    {
        String q = "";
        String s = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                q = "select  top(6) * from books order by newid()  ";
                con = new SqlConnection(s);
                con.Open();
                da = new SqlDataAdapter(q, con);
                da.Fill(dt);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
    }
}