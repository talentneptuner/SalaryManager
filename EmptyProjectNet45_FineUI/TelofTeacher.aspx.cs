using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace EmptyProjectNet45_FineUI
{
    public partial class TelofTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str = "select * from Teacher";
            SqlCommand cmd = new SqlCommand(str,conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView2.DataSource = ds;
            GridView2.DataBind();
        }

        protected void Search_But_Click(object sender, EventArgs e)
        {
            String name = txtName.Text.Trim();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str = "select * from Teacher where Tname='"+name+"'";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script language=javascript>alert('不存在此人')</script>");
                return;
            }
            GridView2.DataSource = ds;
            GridView2.DataBind();
            
        }
    }
}