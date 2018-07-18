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
    public partial class LeaveItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind();
            }
        }

        protected void GridviewDisplay_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        public void Bind()
        {
            String user_grade = Server.UrlDecode(Request.Cookies["Userisgrade"].Value);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str="";
            if (!user_grade.Equals("后勤"))
            {
                str = "select distinct Lnum,Ltnum,Lname,Ltime,Llong,Lstate from Leave,Work1,Class where Leave.Ltnum=Work1.Wtnum and Work1.Wclnum=Class.Clnum and Class.Clgrade='" + user_grade + "'";
            }
            else
            {
                str = "select * from Leave,Work2 where Leave.Ltnum=Work2.Wnum";
            }
            cmd.CommandText = str;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridviewDisplay.DataSource = ds;
            GridviewDisplay.DataBind();
            conn.Close();
            GridviewDisplay.Visible = true;
          
        }

        protected void seek_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.Parent.Parent as GridViewRow;
            string a = row.Cells[0].Text.ToString().Trim();
            string url= "LeaveInfo.aspx?num=" + a;
            Response.Redirect(url);

        }
        public int check(string s)
        {
            int i = 1;
            String user_num = Server.UrlDecode(Request.Cookies["Usernum"].Value);
            if (user_num.Equals(s))
                i = 0;
            return i;

        }

        protected void refuse_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.Parent.Parent as GridViewRow;
            string a = row.Cells[0].Text.ToString().Trim();
            string b = row.Cells[5].Text.ToString().Trim();
            if (b.Equals("拒绝") || b.Equals("已通过"))
            {
                Response.Write("<script language=javascript>alert('已操作过的')</script>");
                return;
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str = "update Leave set Lstate='拒绝' where Lnum='"+a+"'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            Response.Write("<script language=javascript>alert('操作成功')</script>");
            Bind();
        }

        protected void agree_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow row = btn.Parent.Parent as GridViewRow;
            string a = row.Cells[0].Text.ToString().Trim();
            string b = row.Cells[5].Text.ToString().Trim();
            if(b.Equals("拒绝")||b.Equals("已通过"))
            {
                Response.Write("<script language=javascript>alert('已操作过的')</script>");
                return;
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str = "update Leave set Lstate='已通过' where Lnum='" + a + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            Response.Write("<script language=javascript>alert('操作成功')</script>");
            Bind();
        }
    }
}