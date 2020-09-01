using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using paytm;

namespace onlinebooklibary
{
    public partial class book : System.Web.UI.Page
    {
        String q = "";
        int bookid;
        String bookprice;
        String s = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString.Count > 0)
            {
                bookid = Convert.ToInt32(Request.QueryString.Get("id"));
                q = "select * from books where bookid = " + bookid;
                con = new SqlConnection(s);
                con.Open();
                cmd = new SqlCommand(q, con);
                dr = cmd.ExecuteReader();

                dr.Read();

                if (dr.HasRows)
                {
                    title.Text = dr["title"].ToString();
                    author.Text = dr["author"].ToString();
                    category.Text = dr["category"].ToString();
                    description.Text = dr["details"].ToString();
                    price.Text = "₹ " + dr["price"].ToString();
                    bookprice =  dr["price"].ToString();
                    cover.ImageUrl = "./" + dr["coverlocation"].ToString();
                    try
                    {
                        bookid = Convert.ToInt32(dr["bookid"].ToString());
                    }catch(Exception err)
                    {

                    }
                    }
                else
                {
                    Response.Write("Error: No Book Found");
                }
            }
            else
            {
                Response.Write("Error: No Book Found");
                
            }
        }


        protected void btnBuy_Click(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("/buybook.aspx?bookid=" + bookid + "&price=" + bookprice);
            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }


    }
}