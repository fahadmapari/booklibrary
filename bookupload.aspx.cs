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
    public partial class bookupload : System.Web.UI.Page
    {
        String book, cover, title, author, description, category;
        int? price;
        String s = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        String q = "";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public void uploadbook()
        {
            if (bookIn.HasFile && coverIn.HasFile && !String.IsNullOrWhiteSpace(title) && !String.IsNullOrWhiteSpace(author) && !String.IsNullOrWhiteSpace(description) && price != null)
            {
             
                if (
                    System.IO.Path.GetExtension(bookIn.PostedFile.FileName).ToLower() == ".pdf"
                    && System.IO.Path.GetExtension(coverIn.PostedFile.FileName).ToLower() == ".jpg"
                    || System.IO.Path.GetExtension(coverIn.PostedFile.FileName).ToLower() == ".jpeg"
                    || System.IO.Path.GetExtension(coverIn.PostedFile.FileName).ToLower() == ".png"
                    
                    )
                {
                 
                    book = "books/" + DateTime.Now.ToString("yyyymmddMMss") + bookIn.FileName;
                    bookIn.SaveAs(Server.MapPath(book));

                    cover = "bookcovers/" + DateTime.Now.ToString("yyyymmddMMss") + coverIn.FileName;
                    coverIn.SaveAs(Server.MapPath(cover));

                    q = "insert into books values(@title, @author, @details, @book, @cover, @price, @category)";
                    con = new SqlConnection(s);
                    con.Open();
                    cmd = new SqlCommand(q, con);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@details", description);
                    cmd.Parameters.AddWithValue("@book", book);
                    cmd.Parameters.AddWithValue("@cover", cover);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@category", category);

                    cmd.ExecuteNonQuery();
                    Response.Redirect("/books.aspx");
                }
                else
                {
                    
                    
                    if (System.IO.Path.GetExtension(bookIn.PostedFile.FileName).ToLower() != ".pdf")
                    {
                        bookErr.Visible = true;
                        bookErr.Text = "please select pdf file";
                    }
                    if (System.IO.Path.GetExtension(coverIn.PostedFile.FileName).ToLower() != ".jpg" || System.IO.Path.GetExtension(coverIn.PostedFile.FileName) != ".jpeg"
                    || System.IO.Path.GetExtension(coverIn.PostedFile.FileName).ToLower() != ".png")
                    {
                        coverErr.Visible = true;
                        coverErr.Text = "Please select an valid image";
                    }
                }
            }
            else
            {
                
                if (!bookIn.HasFile)
                {
                    bookErr.Visible = true;
                    bookErr.Text = "select an file";
                }

                if (!coverIn.HasFile)
                {
                    coverErr.Visible = true;
                    coverErr.Text = "select an image";
                }

                if (String.IsNullOrWhiteSpace(title))
                {
                    titleErr.Visible = true;
                    titleErr.Text = "title is required";
                }

                if (String.IsNullOrWhiteSpace(author))
                {
                    authorErr.Visible = true;
                    authorErr.Text = "author is required";
                }

                if (String.IsNullOrWhiteSpace(description))
                {
                    descriptionErr.Visible = true;
                    descriptionErr.Text = "description is required";
                }

                if (price == null)
                {
                    priceErr.Visible = true;
                    priceErr.Text = "price is required";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "admin")
                {
                    Response.Redirect("/home.aspx");
                }
            }
            else
            {
                Response.Redirect("/home.aspx");
            }
        }

        protected void uploadbtn_Click(object sender, EventArgs e)
        {
            
            try
            {
                title = titleIn.Text.ToString().Trim();
                author = authorIn.Text.ToString().Trim();
                description = descriptionIn.Text.ToString().Trim();
                category = categoryIn.SelectedValue;
                price = Convert.ToInt32(priceIn.Text.ToString().Trim());
                
            }
            catch(Exception err)
            {
                Trace.Write(err.Message);
            }
            bookErr.Visible = false;
            coverErr.Visible = false;
            titleErr.Visible = false;
            authorErr.Visible = false;
            descriptionErr.Visible = false;
            categoryErr.Visible = false;
            priceErr.Visible = false;

            uploadbook();
        }
    }
}