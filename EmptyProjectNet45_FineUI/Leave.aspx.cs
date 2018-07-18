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
using System.IO;

namespace EmptyProjectNet45_FineUI
{
    public partial class Leave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind();
            }
        }

        protected void Deliver_Click(object sender, EventArgs e)
        {
            if(check()==0)
            {
                Response.Write("<script language=javascript>alert('无输入')</script>");
                return;
            }
            String apply_tnum= Server.UrlDecode(Request.Cookies["Usernum"].Value).Trim();
            String apply_num= DateTime.Now.Date.ToShortDateString().Replace("/","")+apply_tnum;
            String applay_day = applyday.Text.Trim();
            int apply_long = int.Parse(applylong.Text.Trim());
            String apply_state = "待审核";
            String apply_deal = "暂无";
            String apply_name= Server.UrlDecode(Request.Cookies["Username"].Value);
            String apply_reason = applyreason.Text.Trim();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str = "insert into Leave(Lnum,Ltnum,Ltime,Llong,Lstate,Ldeal,Lname,Lreason) Values('" + apply_num + "','" + apply_tnum + "','" + applay_day + "','" + apply_long + "','" + apply_state + "','" + apply_deal + "','" + apply_name + "','" + apply_reason + "')";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script language=javascript>alert('成功，请拨打年级主任或校务处电话确认')</script>");
            bind();
        }

        public int check()
        {
            int i = 1;
            if (applyday.Text.Equals("") || applylong.Text.Equals("") || applyreason.Text.Equals(""))
                i = 0;
            return i;
        }

        public void bind()
        {
            applyreason.Attributes.Add("Value", "不要超过20字");
            applyreason.Attributes.Add("OnFocus", "if(this.value=='不要超过20字') {this.value=''}");
            applyreason.Attributes.Add("OnBlur", "if(this.value==''){this.value='不要超过20字'}");
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String apply_tnum = Server.UrlDecode(Request.Cookies["Usernum"].Value).Trim();
            String str = "select * from Leave where Ltnum='" + apply_tnum + "'";
            cmd.CommandText = str;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridviewDisplay.DataSource = ds;
            GridviewDisplay.DataBind();
            conn.Close();
            GridviewDisplay.Visible = true;
        }
    }
}