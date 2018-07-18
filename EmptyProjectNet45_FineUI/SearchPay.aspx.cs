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
    public partial class SearchPay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //month.Text = DateTime.Now.Date.ToShortDateString();
        }

        protected void Search_But_Click(object sender, EventArgs e)
        {
            if(month.Text==""||month.Equals(""))
            {
                Response.Write("<script language=javascript>alert('日期不得为空')</script>");
                return;
            }
            
                DateTime key = Convert.ToDateTime(month.Text.Trim());
            String user_num = Server.UrlDecode(Request.Cookies["Usernum"].Value);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string str = "select Tbegin,Tend from Termstate where Testate=1";
            cmd.CommandText = str;
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            DateTime begin =Convert.ToDateTime( sdr["Tbegin"].ToString().Trim());
            DateTime end =Convert.ToDateTime( sdr["Tend"].ToString().Trim());
            if(key.CompareTo(begin)<0||key.CompareTo(end)>0)
            {
                Response.Write("<script language=javascript>alert('时间不处于学期内,如要其他学期工资情况，请联系财务处')</script>");
                return;
            }
            sdr.Close();
            int key_month = key.Month;
            str = "select * from Pay where Ptnum = '" + user_num + "' and Pmonth = '" + key_month + "'";
            cmd.CommandText = str;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            GridView1.Visible = true;
        }

        protected void month_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}