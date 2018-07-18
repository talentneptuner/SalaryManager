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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register_Click(object sender, EventArgs e)
        {
            String num = Num.Text.Trim();
            String pass = Password.Text.Trim();
            if(num==""||pass=="")
            {
                Response.Write("<script language=javascript>alert('账号或密码不得为空')</script>");
                return;
            }
            else
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
                conn.Open();
                String str= "select count(*) from Teacher where Tnum = '" + num + "' and Tpass = '" + pass + "'";
                SqlCommand cmd = new SqlCommand(str, conn);
                int n = (int)cmd.ExecuteScalar();
                if(n==0)
                {
                    Response.Write("<script language=javascript>alert('账号或密码错误')</script>");
                    return;
                }
                str = "select * from Teacher where Tnum = '" + num + "' and Tpass = '" + pass + "'";
                cmd.CommandText = str;
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                string user_num= sdr["Tnum"].ToString().Trim();
                string user_name = sdr["Tname"].ToString().Trim();
                string user_position = sdr["Tposition"].ToString().Trim();
                string user_manager = sdr["Tisgrade"].ToString().Trim();
                Response.Cookies["Username"].Value = Server.UrlEncode(user_name);
                Response.Cookies["Usernum"].Value = Server.UrlEncode(user_num);
                Response.Cookies["Userposition"].Value = Server.UrlEncode(user_position);
                Response.Cookies["Userisgrade"].Value = Server.UrlEncode(user_manager);
                String s = "default.aspx";
                Response.Redirect(s);
            }
        }
    }
}