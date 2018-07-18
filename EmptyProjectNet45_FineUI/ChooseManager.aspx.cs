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
    public partial class ChooseManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind1();
                bind2();
            }
        }

        protected void Change_Click(object sender, EventArgs e)
        {
            String class_name = Class.SelectedItem.Value.Trim();
            String teacher_name = Teacher.SelectedItem.Value.Trim();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string str = "update Class set Clmanager='" + teacher_name + "' where Clnum='" + class_name + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            Response.Write("<script language=javascript>alert('更新成功')</script>");
            conn.Close();
        }

        protected void Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            String str;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            str = "select DISTINCT Teacher.* from Teacher,Work1 where Teacher.Tnum=Work1.Wtnum and Work1.Wclnum='" + Class.SelectedItem.Value.Trim() + "'";
            cmd.CommandText = str;
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1);
            Teacher.DataSource = ds1.Tables[0].DefaultView;
            Teacher.DataTextField = "Tname";
            Teacher.DataValueField = "Tnum";
            Teacher.DataBind();
            conn.Close();

        }

        public void bind1()
        {
            String user_isgrade = Server.UrlDecode(Request.Cookies["Userisgrade"].Value); 
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str = "select * from Class where Clgrade='" + user_isgrade + "'";
            cmd.CommandText = str;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Class.DataSource = ds.Tables[0].DefaultView;
            Class.DataTextField = "Clno";
            Class.DataValueField = "Clnum";
            Class.DataBind();
            Classname.DataSource = ds.Tables[0].DefaultView;
            Classname.DataTextField = "Clno";
            Classname.DataValueField = "Clnum";
            Classname.DataBind();
            str = "select DISTINCT Teacher.* from Teacher,Work1 where Teacher.Tnum=Work1.Wtnum and Work1.Wclnum='" + Class.SelectedItem.Value.Trim() + "'";
            cmd.CommandText = str;
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1);
            Teacher.Items.Clear();
            Teacher.DataSource = ds1.Tables[0].DefaultView;
            Teacher.DataTextField = "Tname";
            Teacher.DataValueField = "Tnum";
            Teacher.DataBind();
            conn.Close();
        }

        public void bind2()
        {
            String user_isgrade = Server.UrlDecode(Request.Cookies["Userisgrade"].Value); 
            String str;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            str = "select * from Crouse where Crgrade='" + user_isgrade + "'";
            cmd.CommandText = str;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            Crousename.DataSource = ds.Tables[0].DefaultView;
            Crousename.DataTextField = "Crname";
            Crousename.DataValueField = "Crnum";
            Crousename.DataBind();
            str = "select DISTINCT Tnum,Tname from Teacher,Work1,Class where(Tnum not in( select Wtnum from Work1 ) and Tnum not in( select Wnum from Work2 )) or(Teacher.Tnum = Work1.Wtnum and Work1.Wclnum = Class.Clnum and Class.Clgrade = '" + user_isgrade + "') ";
            cmd.CommandText = str;
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            sda1.Fill(ds1);
            Teachernum.DataSource = ds1.Tables[0].DefaultView;
            Teachernum.DataTextField = "Tnum";
            Teachernum.DataValueField = "Tnum";
            Teachernum.DataBind();
            Teachernum.Items.RemoveAt(0);
            Teachernum.Items.RemoveAt(0);
            str = "select * from Teacher where Tnum='" + Teachernum.SelectedItem.Value.Trim() + "'";
            cmd.CommandText = str;
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string name = sdr["Tname"].ToString().Trim();
            Teachername.Text = name;
            sdr.Close();
            conn.Close();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                String teacher_num = Teachernum.SelectedItem.Value.Trim();
                String Class_num = Classname.SelectedItem.Value.Trim();
                String Crouse_num = Crousename.SelectedItem.Value.Trim();
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
                str = "insert into Work1(Wtnum,Wclnum,Wcrnum,Wterm) values ('" + teacher_num + "','" + Class_num + "','" + Crouse_num + "','" + now_term + "')";
                cmd.CommandText = str;
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script language=javascript>alert('加入成功')</script>");
            }
            catch(Exception ex)
            {
                Response.Write("<script language=javascript>alert('出错了，可能是这个班这节课有人上，请前往删除再做操作')</script>");
            }


        }

        protected void Teachernum_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str;
            str = "select * from Teacher where Tnum='" + Teachernum.SelectedItem.Value.Trim() + "'";
            cmd.CommandText = str;
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string name = sdr["Tname"].ToString().Trim();
            Teachername.Text = name;
            sdr.Close();
            conn.Close();
        }
    }
}
