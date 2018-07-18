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
    public partial class PassModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        public int check()
        {
            String user_num = Server.UrlDecode(Request.Cookies["Usernum"].Value);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            String str = "select count(*) from Teacher where Tpass = '" + oldpass.Text.Trim() + "' and Tnum = '" + user_num + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            int n = (int)cmd.ExecuteScalar();
            conn.Close();
            return n;
        }

        protected void modify_Click(object sender, EventArgs e)
        {
            if(check()==0)
            {
                Response.Write("<script language=javascript>alert('原密码错误')</script>");
                return;
            }
            String user_num = Server.UrlDecode(Request.Cookies["Usernum"].Value);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            String str = "update Teacher set Tpass='"+newpass.Text.Trim()+"' where Tnum='"+user_num+"'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            Response.Write("<script language=javascript>alert('修改成功')</script>");
        }
    }
}