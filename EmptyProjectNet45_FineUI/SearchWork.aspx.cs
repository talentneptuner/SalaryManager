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
    public partial class SearchWork : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String user_num= Server.UrlDecode(Request.Cookies["Usernum"].Value);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText= "select count(*) from Work1 where Wtnum = '" + user_num + "' ";
            int i= (int)cmd.ExecuteScalar();
            if(i>0)
            {
                cmd.CommandText = "select Wterm,Clgrade,Clno,Crname,Crtimes,Crself from Work1, Class, Crouse where Work1.Wclnum = Class.Clnum AND Work1.Wcrnum = Crouse.Crnum and Work1.Wtnum='"+user_num+"'";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                GridView1.Visible = true;
            }
            cmd.CommandText= "select count(*) from Work2 where Wnum = '" + user_num + "' ";
            int n = (int)cmd.ExecuteScalar();
            if(n>0)
            {
                cmd.CommandText = "select Wnterm,Wthing from Work2 where Wnum='"+user_num+"'";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView2.DataSource = ds;
                GridView2.DataBind();
                GridView2.Visible = true;
            }
            conn.Close();
            if(i==0&&n==0)
                Response.Write("<script language=javascript>alert('没有工作信息，请联系年级主任或后勤主管')</script>");
        }
    }
}