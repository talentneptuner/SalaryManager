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
    public partial class Teacher_Manage : System.Web.UI.Page
    {
        static string c;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            c= keyname.Text.Trim();
            bind(keyname.Text.Trim());
        }

        protected void GridViewDisplay_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String user_position = Server.UrlDecode(Request.Cookies["Userposition"].Value);
            String key = GridViewDisplay.Rows[e.RowIndex].Cells[0].Text.ToString().Trim();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str;
            str = "select * from Teacher where Tnum='" + key + "'";
            cmd.CommandText = str;
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string user_posi = sdr["Tposition"].ToString().Trim();
            if (user_posi.Equals(user_position)||user_posi.Equals("校长"))
            {
                Response.Write("<script language=javascript>alert('你不具备修改此人的条件')</script>");
                GridViewDisplay.EditIndex = -1;
                bind();
                return;
            }
            sdr.Close();
            str = "delete  from Work1 where Wtnum='"+key+"'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            str= "delete  from Teacher where Tnum='" + key + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            conn.Close();
            bind();
            Response.Write("<script language=javascript>alert('修改完毕,请尽快联系年级主任或后勤主管安排补充工作')</script>");
        }

        protected void GridViewDisplay_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewDisplay.EditIndex = e.NewEditIndex;
            if (keyname.Text.Trim().Equals("请输入姓名或者编号"))
                bind();
            else
                bind(c);
        }

        protected void GridViewDisplay_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String key = GridViewDisplay.Rows[e.RowIndex].Cells[0].Text.ToString().Trim();
            String s = ((TextBox)(GridViewDisplay.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            String n = ((TextBox)(GridViewDisplay.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
            String user_position = Server.UrlDecode(Request.Cookies["Userposition"].Value);
            if(s.Equals(user_position))
            {
                Response.Write("<script language=javascript>alert('只有校长才有此职务修改权利')</script>");
                GridViewDisplay.EditIndex = -1;
                bind();
                return;
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str;
            str = "select * from Teacher where Tnum='" + key + "'";
            cmd.CommandText = str;
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string user_posi = sdr["Tposition"].ToString().Trim();
            if(user_posi.Equals(user_position)||user_posi.Equals("校长"))
            {
                Response.Write("<script language=javascript>alert('你不具备修改此人的条件')</script>");
                GridViewDisplay.EditIndex = -1;
                bind();
                return;
            }
            sdr.Close();
            str = "update Teacher set Tposition='"+s+"',Tisgrade='"+n+"' where Tnum='"+key+"'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script language=javascript>alert('修改完毕')</script>");
            GridViewDisplay.EditIndex = -1;
            if (keyname.Text.Trim().Equals("请输入姓名或者编号"))
                bind();
            else
                bind(c);
        }

        protected void GridViewDisplay_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewDisplay.EditIndex = -1;
            if (keyname.Text.Trim().Equals("请输入姓名或者编号"))
                bind();
            else
                bind(c);
        }

        public void bind()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str;
            str = "select * from Teacher";
            cmd.CommandText = str;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridViewDisplay.DataSource = ds;
            GridViewDisplay.DataBind();
            conn.Close();
        }

        public void bind(String key)
        {
            key = keyname.Text.Trim();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str;
            str = "select * from Teacher where Tname='" + key + "' or Tnum='" + key + "'";
            cmd.CommandText = str;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridViewDisplay.DataSource = ds;
            GridViewDisplay.DataBind();
            conn.Close();
        }
    }
}