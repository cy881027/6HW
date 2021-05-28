using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace _6HW
{
    public partial class _6HW : System.Web.UI.Page
    {
        SqlConnection o_connect = new SqlConnection(
                ConfigurationManager.ConnectionStrings["myCon"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                o_connect.Open();
                SqlCommand o_com = new SqlCommand("select * from Users",o_connect);
                SqlDataReader o_db = o_com.ExecuteReader();
                for (; o_db.Read();)
                {
                    for (int i = 0; i < o_db.FieldCount; i++)
                    {
                        Response.Write(o_db[i]);

                    }
                    Response.Write("<br />");
                }
                o_connect.Close();
            }
            catch (Exception error)
            {
                Response.Write(error.ToString());
            }
            tb_Name.Visible = true;
            btn_Del.Visible = true;
        }

        protected void btn_Del_Click(object sender, EventArgs e)
        {
            try
            {
                o_connect.Open();
                SqlCommand o_com = new SqlCommand("delete from Users where Name=N'" + tb_Name.Text + "';", o_connect);
                o_com.ExecuteNonQuery();
                Response.Redirect("./6HW.aspx");
                o_connect.Close();
            }
            catch(Exception error)
            {
                Response.Write(error.ToString());
            }
            
        }
    }
}