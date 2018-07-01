using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace team
{
    public partial class Create2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\krish04\source\repos\team\team\App_Data\TeamAs.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            Guid newGuild = Guid.NewGuid();
            string s = "insert into Team12 (Id,Name,Email,About) values (@Id,@uname,@email,@about)";
            SqlCommand com = new SqlCommand(s, con);
            com.Parameters.AddWithValue("@Id", newGuild);
            com.Parameters.AddWithValue("@uname", TextBox2.Text);
            com.Parameters.AddWithValue("@email", TextBox3.Text);
            com.Parameters.AddWithValue("@about", TextBox4.Text);
            com.ExecuteNonQuery();

            Response.Redirect("saved2.aspx");

            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Logout Successful');window.open('Login.aspx');", true);
        }
    }
}