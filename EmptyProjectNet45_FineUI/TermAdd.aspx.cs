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
using System.Collections;

namespace EmptyProjectNet45_FineUI
{
    public partial class TermAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        protected void Open_Term_Click(object sender, EventArgs e)
        {
            String now_term = former.Text.Trim() + "-" + later.Text.Trim() + "-" + type.Text.Trim();
            string now_type = type.Text.Trim();
            Label1.Text = "正在进行必要操作，中途不要关闭";
            if (check(now_term) == 0)
            {
                Response.Write("<script language=javascript>alert('开始学期失败，原因可能是：\\n有学期没结束\\n存在相同的学期\\n学期格式不对\\日期不对')</script>");
                return;
            }
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            SqlTransaction transaction = conn.BeginTransaction();
            cmd.Transaction = transaction;

            //修改学期
            change_term(cmd, conn, now_term);
            if (int.Parse(now_type) == 2)
            {
                reset_Pay(conn, cmd, now_term, Convert.ToDateTime(begin.Text.Trim()).Month, Convert.ToDateTime(end.Text.Trim()).Month, int.Parse(now_type));
                transaction.Commit();
                conn.Close();
                Label1.Text = "修改结束";
                return;
            }

            //修改教师表中的年级主任

            exchange(conn, cmd, "Teacher", "九年级", "临时年级", "Tisgrade");
            exchange(conn, cmd, "Teacher", "八年级", "九年级", "Tisgrade");
            exchange(conn, cmd, "Teacher", "七年级", "八年级", "Tisgrade");
            exchange(conn, cmd, "Teacher", "临时年级", "七年级", "Tisgrade");
            
            

            //修改班级
            change_class(cmd, conn ,int.Parse(former.Text.Trim()));
            change_work1(conn, cmd,now_term);
            change_work2(conn, cmd, now_term);
            reset_Pay(conn, cmd, now_term, Convert.ToDateTime(begin.Text.Trim()).Month, Convert.ToDateTime(end.Text.Trim()).Month, int.Parse(now_type));
            reset_Leave(conn,cmd);
            transaction.Commit();
            conn.Close();
            Label1.Text = "开始完毕";
        }

        public int check(String now_term)
        {
            int i = 1;
            int n;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string str = "select count(*) from Termstate where Tename='" + now_term + "'";
            cmd.CommandText = str;
            n = (int)cmd.ExecuteScalar();
            if (n > 0)
            {
                i = 0;
            }
            str = "select count(*) from Termstate where Testate=1";
            cmd.CommandText = str;
            n = (int)cmd.ExecuteScalar();
            if (n > 0)
            {
                i = 0;
            }
            conn.Close();
            if (int.Parse(later.Text.Trim()) - int.Parse(former.Text.Trim()) != 1)
            {
                i = 0;
            }
            try
            {
                Convert.ToDateTime(begin.Text.Trim());
                Convert.ToDateTime(end.Text.Trim());
            }
            catch
            {
                i = 0;
            }
            try
            {
                if (Convert.ToDateTime(begin.Text.Trim()).CompareTo(Convert.ToDateTime(end.Text.Trim())) > 0)
                {
                    i = 0;
                }
            }
            catch
            {
                i = 0;
            }
            return i;
        }

        protected void Close_Term_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string str = "update Termstate set Testate=0";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script language=javascript>alert('学期结束')</script>");
            bind();
        }

        public void bind()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string str = "select * from Termstate where Testate=1";
            cmd.CommandText = str;
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            try
            {
                string now = sdr["Tename"].ToString().Trim();
                sdr.Close();
                Label1.Text = "当前学期：" + now;
            }
            catch
            {
                Label1.Text = "当前不处于学期内";
            }
            conn.Close();
        }

        public void exchange(SqlConnection conn,SqlCommand cmd,String tablename,String old_text,String new_text,String want)
        {
            string str = "update " + tablename.Trim() + " set " + want.Trim() + "='" + new_text.Trim() + "' where " + want.Trim() + "='" + old_text.Trim() + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
        }

        public void change_term(SqlCommand cmd, SqlConnection conn, String now_term)
        {

            string str = "insert into Termstate(Tename,Testate,Tbegin,Tend) values ('" + now_term + "',1,'" + Convert.ToDateTime(begin.Text.Trim()) + "','" + Convert.ToDateTime(end.Text.Trim()) + "')";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
        }

        public void change_class(SqlCommand cmd,SqlConnection conn,int years)
        {
            ArrayList seven = new ArrayList();
            ArrayList eight = new ArrayList();
            ArrayList nine = new ArrayList();
            int old_years = years - 3;
            exchange(conn, cmd, "Class", "九年级", "临时年级", "Clgrade");
            exchange(conn, cmd, "Class", "八年级", "九年级", "Clgrade");
            exchange(conn, cmd, "Class", "七年级", "八年级", "Clgrade");
            exchange(conn, cmd, "Class", "临时年级", "七年级", "Clgrade");
            exchange(conn, cmd, "Class",old_years+"01",years+"01", "Clnum");
            exchange(conn, cmd, "Class", old_years + "02", years + "02", "Clnum");
            exchange(conn, cmd, "Class", old_years + "03", years + "03", "Clnum");
            #region 取出年级各班
            cmd.CommandText = "select Clnum from Class where Clgrade='七年级'";
            SqlDataAdapter sqa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sqa.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                seven.Add(row[0].ToString().Trim());
            }
            cmd.CommandText = "select Clnum from Class where Clgrade='八年级'";
            sqa = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sqa.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                eight.Add(row[0].ToString().Trim());
            }
            cmd.CommandText = "select Clnum from Class where Clgrade='九年级'";
            sqa = new SqlDataAdapter(cmd);
            ds = new DataSet();
            sqa.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                nine.Add(row[0].ToString().Trim());
            }
            #endregion

            #region 特殊课程处理，如化学物理体育生物地理微机美术音乐
            #region 对美术的处理
            change_extracrouse(conn, cmd, eight[0].ToString(), seven[0].ToString(), "0711");
            change_extracrouse(conn, cmd, eight[1].ToString(), seven[1].ToString(), "0711");
            change_extracrouse(conn, cmd, eight[2].ToString(), seven[2].ToString(), "0711");
            #endregion
            #region 对音乐的处理
            change_extracrouse(conn, cmd, eight[0].ToString(), seven[0].ToString(), "0712");
            change_extracrouse(conn, cmd, eight[1].ToString(), seven[1].ToString(), "0712");
            change_extracrouse(conn, cmd, eight[2].ToString(), seven[2].ToString(), "0712");
            #endregion
            #region 对微机的处理
            change_extracrouse(conn, cmd, eight[0].ToString(), seven[0].ToString(), "0713");
            change_extracrouse(conn, cmd, eight[1].ToString(), seven[1].ToString(), "0713");
            change_extracrouse(conn, cmd, eight[2].ToString(), seven[2].ToString(), "0713");
            #endregion
            #region 对化学的处理
            change_extracrouse(conn, cmd, seven[0].ToString(), nine[0].ToString(), "0905");
            change_extracrouse(conn, cmd, seven[1].ToString(), nine[1].ToString(), "0905");
            change_extracrouse(conn, cmd, seven[2].ToString(), nine[2].ToString(), "0905");
            #endregion
            #region 对物理的处理
            change_extracrouse(conn, cmd, seven[0].ToString(), eight[0].ToString(), "0904");
            change_extracrouse(conn, cmd, seven[1].ToString(), eight[1].ToString(), "0904");
            change_extracrouse(conn, cmd, seven[2].ToString(), eight[2].ToString(), "0904");
            #endregion
            #region 对地理的处理
            change_extracrouse(conn, cmd, nine[0].ToString(), seven[0].ToString(), "0809");
            change_extracrouse(conn, cmd, nine[1].ToString(), seven[1].ToString(), "0809");
            change_extracrouse(conn, cmd, nine[2].ToString(), seven[2].ToString(), "0809");
            #endregion
            #region 对生物的处理
            change_extracrouse(conn, cmd, nine[0].ToString(), seven[0].ToString(), "0806");
            change_extracrouse(conn, cmd, nine[1].ToString(), seven[1].ToString(), "0806");
            change_extracrouse(conn, cmd, nine[2].ToString(), seven[2].ToString(), "0806");
            #endregion
            #region 对体育的处理
            change_extracrouse(conn, cmd, nine[0].ToString(), seven[0].ToString(), "0810");
            change_extracrouse(conn, cmd, nine[1].ToString(), seven[1].ToString(), "0810");
            change_extracrouse(conn, cmd, nine[2].ToString(), seven[2].ToString(), "0810");
            #endregion
            #endregion

        }

        public void change_extracrouse(SqlConnection conn,SqlCommand cmd,String old_text,String new_text,String course)
        {
            string str = "update Work1 set Wclnum='" + new_text + "' where Wcrnum='" + course + "' and Wclnum='" + old_text + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
        }

        public void change_work1(SqlConnection conn,SqlCommand cmd,String now_term)
        {
            string str = "update Work1 set Wterm='" + now_term + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            #region 处理正常的课程
            #region 处理语文
            exchange(conn, cmd, "Work1", "0901", "0000", "Wcrnum");
            exchange(conn, cmd, "Work1", "0801", "0901", "Wcrnum");
            exchange(conn, cmd, "Work1", "0701", "0801", "Wcrnum");
            exchange(conn, cmd, "Work1", "0000", "0701", "Wcrnum");
            #endregion
            #region 处理数学
            exchange(conn, cmd, "Work1", "0902", "0000", "Wcrnum");
            exchange(conn, cmd, "Work1", "0802", "0902", "Wcrnum");
            exchange(conn, cmd, "Work1", "0702", "0802", "Wcrnum");
            exchange(conn, cmd, "Work1", "0000", "0702", "Wcrnum");
            #endregion
            #region 处理英语
            exchange(conn, cmd, "Work1", "0903", "0000", "Wcrnum");
            exchange(conn, cmd, "Work1", "0803", "0903", "Wcrnum");
            exchange(conn, cmd, "Work1", "0703", "0803", "Wcrnum");
            exchange(conn, cmd, "Work1", "0000", "0703", "Wcrnum");
            #endregion
            #region 处理物理
            exchange(conn, cmd, "Work1", "0904", "0000", "Wcrnum");
            exchange(conn, cmd, "Work1", "0804", "0904", "Wcrnum");
            exchange(conn, cmd, "Work1", "0000", "0804", "Wcrnum");
            #endregion
            #region 处理生物
            exchange(conn, cmd, "Work1", "0806", "0000", "Wcrnum");
            exchange(conn, cmd, "Work1", "0706", "0806", "Wcrnum");
            exchange(conn, cmd, "Work1", "0000", "0706", "Wcrnum");
            #endregion
            #region 处理历史
            exchange(conn, cmd, "Work1", "0907", "0000", "Wcrnum");
            exchange(conn, cmd, "Work1", "0807", "0907", "Wcrnum");
            exchange(conn, cmd, "Work1", "0707", "0807", "Wcrnum");
            exchange(conn, cmd, "Work1", "0000", "0707", "Wcrnum");
            #endregion
            #region 处理政治
            exchange(conn, cmd, "Work1", "0908", "0000", "Wcrnum");
            exchange(conn, cmd, "Work1", "0808", "0908", "Wcrnum");
            exchange(conn, cmd, "Work1", "0708", "0808", "Wcrnum");
            exchange(conn, cmd, "Work1", "0000", "0708", "Wcrnum");
            #endregion
            #region 处理地理
            exchange(conn, cmd, "Work1", "0809", "0000", "Wcrnum");
            exchange(conn, cmd, "Work1", "0709", "0809", "Wcrnum");
            exchange(conn, cmd, "Work1", "0000", "0709", "Wcrnum");
            #endregion
            #region 处理体育
            exchange(conn, cmd, "Work1", "0810", "0000", "Wcrnum");
            exchange(conn, cmd, "Work1", "0710", "0810", "Wcrnum");
            exchange(conn, cmd, "Work1", "0000", "0710", "Wcrnum");
            #endregion
            #endregion
        }
        
        public void change_work2(SqlConnection conn, SqlCommand cmd, String now_term)
        {
            string str = "update Work2 set Wnterm='" + now_term + "'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
        }

        public void reset_Pay(SqlConnection conn, SqlCommand cmd, String now_term,int begin_month,int end_month,int type)
        {
            int temp = 0;
            String num;
            int k = begin_month;
            string str = "delete  from Pay";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            if(type==2)
            {
                cmd.CommandText = "select * from Teacher";
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqa.Fill(ds);
                for (; k <=end_month; k++)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        num = row[0].ToString().Trim();
                        if (!num.Equals("000000"))
                        {
                            cmd.CommandText = "insert into Pay(Ptnum,Pterm,Pmonth,Paward,Paddelse,Preduceelse) Values('" + num + "','"+now_term+"','" + k + "','" + temp + "','" + temp + "','" + temp + "')";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            else if(type==1)
            {
                cmd.CommandText = "select * from Teacher";
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqa.Fill(ds);
                for (; k <= 12; k++)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        num = row[0].ToString().Trim();
                        if (!num.Equals("000000"))
                        {
                            cmd.CommandText = "insert into Pay(Ptnum,Pterm,Pmonth,Paward,Paddelse,Preduceelse) Values('" + num + "','" + now_term + "','" + k + "','" + temp + "','" + temp + "','" + temp + "')";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                for (k=1; k <=end_month; k++)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        num = row[0].ToString().Trim();
                        if (!num.Equals("000000"))
                        {
                            cmd.CommandText = "insert into Pay(Ptnum,Pterm,Pmonth,Paward,Paddelse,Preduceelse) Values('" + num + "','" + now_term + "','" + k + "','" + temp + "','" + temp + "','" + temp + "')";
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void reset_Leave(SqlConnection conn, SqlCommand cmd)
        {
            string str = "delete  from Leave";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
        }

    }
}