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
    public partial class TeacherManager2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind();
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            
            int k = 0;
            String teacher_num = add_ID.Text.Trim();
            String teacher_name = add_name.Text.Trim();
            String teacher_position = add_position.Text.Trim();
            String teacher_phone = add_phone.Text.Trim();
            int temp = 0;
            if (teacher_num.Length != 6 || int.Parse(teacher_num) / 10000 != 20)
            {
                Response.Write("<script language=javascript>alert('编号或班号不符合规则')</script>");
                return;
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                String str;
                str = "select * from Termstate where Testate=1";
                cmd.CommandText = str;
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                DateTime begin = Convert.ToDateTime(sdr["Tbegin"].ToString().Trim());
                DateTime end = Convert.ToDateTime(sdr["Tend"].ToString().Trim());
                string now_term = sdr["Tename"].ToString().Trim();
                sdr.Close();
                int beginmonth = begin.Month;
                int endmonth = end.Month;
                str = "insert into Teacher(Tnum,Tname,Tposition,Tphone,Tpass,Tisgrade) values('" + teacher_num + "','" + teacher_name + "','" + teacher_position + "','" + teacher_phone + "','" + teacher_num + "','无')";
                cmd.CommandText = str;
                cmd.ExecuteNonQuery();
                if (begin < end)
                {
                    for (k = beginmonth; k <= endmonth; k++)
                    {
                        str = "insert into Pay(Ptnum,Pterm,Pmonth,Paward,Paddelse,Preduceelse) Values('" + teacher_num + "','" + now_term + "','" + k + "','" + temp + "','" + temp + "','" + temp + "')";
                        cmd.CommandText = str;
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
                Response.Write("<script language=javascript>alert('添加完毕，请通知年级主任为之安排工作')</script>");
            }
            catch
            {
                Response.Write("<script language=javascript>alert('出错了，可能是编号已存在')</script>");
            }
        }

        protected void add_class_Click(object sender, EventArgs e)
        {
            String class_num = add_classnum.Text.Trim();
            String class_no = add_classno.Text.Trim();
            String class_grade = add_grade.Text.Trim();
            if(class_num.Length!=6||int.Parse(class_num)/10000!=20||class_no.Equals(""))
            {
                Response.Write("<script language=javascript>alert('编号或班号不符合规则')</script>");
                return;
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str;
            str = "select count(*) from Class where (Clnum='" + class_num + "')or(Clgrade='"+class_grade+"' and Clno='"+class_no+"')";
            cmd.CommandText = str;
            int n = (int)cmd.ExecuteScalar();
            if(n>0)
            {
                Response.Write("<script language=javascript>alert('班级重复')</script>");
                return;
            }
            str = "insert into Class(Clnum,Clgrade,Clno) values ('" + class_num + "','" + class_grade + "','"+class_no+"')";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script language=javascript>alert('加入成功')</script>");
        }

        public void Bind()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str;
            str = "select * from Class,Teacher where Clmanager=Teacher.Tnum ";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridViewDisplay.DataSource = ds;
            GridViewDisplay.DataBind();
            conn.Close();
        }

        protected void GridViewDisplay_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String key = GridViewDisplay.Rows[e.RowIndex].Cells[0].Text.ToString().Trim();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str;
            str = "delete  from Class where Clnum='" + key + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            conn.Close();
            Bind();
            Response.Write("<script language=javascript>alert('删除完毕，请通知年级主任，并为其他老师安排工作')</script>");
        }
    }
}