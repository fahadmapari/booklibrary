using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace onlinebooklibary
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["username"] == null)
            {
                loggedin.Visible = false;
                admin.Visible = false;
                newuser.Visible = true;
            }

            if(Session["username"] != null)
            {
                loggedin.Visible = true;
                admin.Visible = false;
                newuser.Visible = false;
                username.Text = "Hi, " + Session["username"].ToString();

                if(Session["role"].ToString() != "user")
                {   
                    adminname.Text = "Hi, " + Session["username"].ToString();
                    loggedin.Visible = false;
                    admin.Visible = true;
                    newuser.Visible = false;
                }
            }
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/home.aspx");
        }
    }
}