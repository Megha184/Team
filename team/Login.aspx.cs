using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace team
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\krish04\source\repos\team\team\App_Data\Logins.mdf;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com=new SqlCommand("select count(*) from User11 where Id="+TextBox1.Text+"",con);
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            if(temp==1)
            {
                SqlCommand comm = new SqlCommand("select Password from User11 where Id=" + TextBox1.Text + "", con);
                string pass = comm.ExecuteScalar().ToString().Replace(" ", "");
                if (pass == TextBox2.Text)
                {
                    Session["NEW"] = TextBox1.Text;
                    Response.Redirect("Normal.aspx");
                }
                else
                {
                    Response.Write("Password is incorrect\t Reenter  the password");
                }
            }
        }

       
    }
}