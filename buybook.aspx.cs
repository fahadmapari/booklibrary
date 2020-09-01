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
    public partial class buybook : System.Web.UI.Page
    {
        String q = "";
        String bookid, bookprice;
        String s = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if(Session["role"].ToString() == "admin") { Response.Redirect("/books.aspx"); }

                if (Request.QueryString.Count > 0)
                {
                    bookid = Request.QueryString.Get("bookid").ToString();
                    bookprice = Request.QueryString.Get("price").ToString();

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
                        bookid = Request.QueryString.Get("bookid").ToString();
                        bookprice = Request.QueryString.Get("price").ToString();
                        String orderid = "id_" + DateTime.Now.ToString("yyyymmddMMss");
                        String url = Request.Url.ToString().Substring(0, Request.Url.ToString().LastIndexOf('/')) + "/addbook.aspx?bookid=" + bookid + "&orderid=" + orderid + "&username=" + Session["username"].ToString();
                        String merchantKey = "PZ9wz50UQ9b4gExq";
                        Dictionary<string, string> parameters = new Dictionary<string, string>();
                        parameters.Add("MID", "OhzoXE08065587710708");
                        parameters.Add("CHANNEL_ID", "WEB");
                        parameters.Add("INDUSTRY_TYPE_ID", "Retail");
                        parameters.Add("WEBSITE", "WEBSTAGING");
                        parameters.Add("EMAIL", "customer@gmail.com");
                        parameters.Add("MOBILE_NO", "9769598669");
                        parameters.Add("CUST_ID", "custid");
                        parameters.Add("ORDER_ID", orderid);
                        parameters.Add("TXN_AMOUNT", bookprice.ToString());
                        parameters.Add("CALLBACK_URL", url); //This parameter is not mandatory. Use this to pass the callback url dynamically.

                        string checksum = CheckSum.generateCheckSum(merchantKey, parameters);

                        string paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction";

                        string outputHTML = "<html>";
                        outputHTML += "<head>";
                        outputHTML += "<title>Merchant Check Out Page</title>";
                        outputHTML += "</head>";
                        outputHTML += "<body>";
                        outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
                        outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
                        outputHTML += "<table border='1'>";
                        outputHTML += "<tbody>";
                        foreach (string key in parameters.Keys)
                        {
                            outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
                        }
                        outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
                        outputHTML += "</tbody>";
                        outputHTML += "</table>";
                        outputHTML += "<script type='text/javascript'>";
                        outputHTML += "document.f1.submit();";
                        outputHTML += "</script>";
                        outputHTML += "</form>";
                        outputHTML += "</body>";
                        outputHTML += "</html>";
                        Response.Write(outputHTML);
                    }


                }//end if

            }
            else
            {
                Response.Redirect("/login.aspx");
            }
        }
    }
}