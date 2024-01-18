using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Two_tier_application
{
    public partial class Login : System.Web.UI.Page
    {
        COnnectionClass obj = new COnnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string s = "select count(id) from Reg where username='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
            string i = obj.Fn_Scalar(s);
            if (i == "1")
            {
                string selid= "select id from Reg where username = '" + TextBox1.Text + "'and password = '" + TextBox2.Text + "'";
                SqlDataReader dr = obj.Fn_Reader(selid);
                while(dr.Read())
                {
                    Session["userid"] = dr["id"].ToString();
                }
                Response.Redirect("Profileview.aspx");
            }
            else
                Label1.Text = "invalid username and password";
        }
    }
}