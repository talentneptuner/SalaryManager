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
    public partial class ServiceManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind();
                bind2();
            }
        }

        protected void GridViewDisplay_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String key = GridViewDisplay.Rows[e.RowIndex].Cells[0].Text.ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str;
            str = "delete from Work2 where Wnum='"+key+"'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script language=javascript>alert('删除成功,请及时为这位员工安排工作')</script>");
            bind();
        }

        protected void GridViewDisplay_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewDisplay.EditIndex = e.NewEditIndex;
            bind();
           
        }

        protected void GridViewDisplay_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            String work = ((TextBox)(GridViewDisplay.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            String key = GridViewDisplay.Rows[e.RowIndex].Cells[0].Text.ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str;
            str = "update Work2 set Wthing='"+work+"' where Wnum='"+key+"'";
            SqlCommand cmd = new SqlCommand(str, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script language=javascript>alert('修改成功')</script>");
            GridViewDisplay.EditIndex = -1;
            bind();
        }

        protected void GridViewDisplay_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewDisplay.EditIndex = -1;
            bind();
        }

        public void bind()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str;
            str = "select * from Work2,Teacher where Work2.Wnum=Teacher.Tnum";
            SqlCommand cmd = new SqlCommand(str,conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridViewDisplay.DataSource = ds;
            GridViewDisplay.DataBind();
            conn.Close();
        }
        public void bind2()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str;
            str = "select * from Teacher where Tposition='后勤' or Tisgrade='后勤'";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            num.DataSource = ds.Tables[0].DefaultView;
            num.DataTextField = "Tnum";
            num.DataValueField = "Tnum";
            num.DataBind();
            str = "select * from Teacher where Tnum='" + num.SelectedItem.Value.Trim() + "'";
            cmd.CommandText = str;
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string sname = sdr["Tname"].ToString().Trim();
            name.Text = sname;
            sdr.Close();
            conn.Close();
        }

        protected void num_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str;
            str = "select * from Teacher where Tnum='" + num.SelectedItem.Value.Trim() + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string sname = sdr["Tname"].ToString().Trim();
            name.Text = sname;
            sdr.Close();
            conn.Close();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            string work = workname.Text;
            string Wnum = num.SelectedItem.Value.Trim();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str;
            str = "select * from Termstate where Testate=1";
            cmd.CommandText = str;
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string now_term = sdr["Tename"].ToString().Trim();
            sdr.Close();
            str = "insert into Work2(Wnum,Wthing,Wnterm) values('" + Wnum + "','" + work + "','" + now_term + "')";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script language=javascript>alert('加入成功')</script>");
            bind();
        }
    }
}