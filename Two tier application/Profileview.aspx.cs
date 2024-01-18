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
    public partial class Profileview : System.Web.UI.Page
    {
        COnnectionClass obj = new COnnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = "select name,age,address,photo from Reg where id=" + Session["userid"] + "";
            SqlDataReader dr = obj.Fn_Reader(s);
            while(dr.Read())
            {
                TextBox1.Text = dr["name"].ToString();
                TextBox2.Text = dr["Age"].ToString();
                TextBox3.Text = dr["Address"].ToString();
                Image1.ImageUrl = dr["photo"].ToString();
            }
            //gridview using dataset
            DataSet ds = obj.Fn_Dataset(s);
            GridView1.DataSource = ds;
            GridView1.DataBind();

            ////datalist using datatable
            DataTable dt = obj.Fn_DataTable(s);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }
    }
}