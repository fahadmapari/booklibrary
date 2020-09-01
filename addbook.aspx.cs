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
    public partial class addbook : System.Web.UI.Page
    {
        String q = "";
        String bookid, orderid;
        String s = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {


            String merchantKey = "PZ9wz50UQ9b4gExq"; // Replace the with the Merchant Key provided by Paytm at the time of registration.

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string paytmChecksum = "";
            foreach (string key in Request.Form.Keys)
            {
                parameters.Add(key.Trim(), Request.Form[key].Trim());
            }

            if (parameters.ContainsKey("CHECKSUMHASH"))
            {
                paytmChecksum = parameters["CHECKSUMHASH"];
                parameters.Remove("CHECKSUMHASH");
            }


   

            if (CheckSum.verifyCheckSum(merchantKey, parameters, paytmChecksum))
            {
                if (Request.QueryString.Count > 0 && parameters["STATUS"] == "TXN_SUCCESS")
                {
                    Session["username"] = Request.QueryString.Get("username");
                    Session["role"] = "user";
                    bookid = Request.QueryString.Get("bookid");
                    orderid = Request.QueryString.Get("orderid");

                    q = "select * from soldbooks where username = @username and bookid = @bookid";
                    con = new SqlConnection(s);
                    con.Open();
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                    cmd.Parameters.AddWithValue("@bookid", bookid);

                    dr = cmd.ExecuteReader();

                    dr.Read();

                    if (dr.HasRows)
                    {
                        Response.Redirect("/ownbooks.aspx");
                    }
                    else
                    {

                        q = "insert into soldbooks values(@orderid , @username, @bookid)";
                        con = new SqlConnection(s);
                        con.Open();
                        cmd = new SqlCommand(q, con);
                        cmd.Parameters.AddWithValue("@orderid", orderid);
                        cmd.Parameters.AddWithValue("@username", Session["username"].ToString());
                        cmd.Parameters.AddWithValue("bookid", Convert.ToInt32(bookid));

                        cmd.ExecuteNonQuery();
                        Response.Redirect("/ownbooks.aspx");
                    }

                }
                else
                {
                    Response.Redirect("/ownbooks.aspx");
                }
            }
            else
            {
                Response.Redirect("/ownbooks.aspx");
            }


            
            }
        }
    
}