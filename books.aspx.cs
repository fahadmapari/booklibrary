using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace onlinebooklibary
{
    public partial class books : System.Web.UI.Page
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
                q = "select * from books order by bookid desc";
                con = new SqlConnection(s);
                con.Open();
                da = new SqlDataAdapter(q, con);
                da.Fill(dt);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedIndex != 0)
            {
                q = "select * from books where category = '" + DropDownList1.SelectedValue + "' order by bookid desc";
                con = new SqlConnection(s);
                con.Open();
                da = new SqlDataAdapter(q, con);
                da.Fill(dt);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            else
            {
               
                q = "select * from books order by bookid desc";
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