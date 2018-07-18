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
    public partial class Fianace : System.Web.UI.Page
    {
        public static DataSet dsk;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind();
                bind2();

            }
        }

        protected void search_Click(object sender, EventArgs e)
        {
            String search_way = Way.SelectedItem.Value.Trim();
            String str="";
            String choose_item = choose.SelectedItem.Value.Trim();
            
            if (search_way.Equals("按年级查询"))
            {
                str = "select distinct Tnum,Tname,Pterm,Pmonth,Ptimes,Pposition,Pmanager,Paward,Pabsent,Paddelse,Preduceelse,Pservice from Teacher,Pay,Work1,Class where Teacher.Tnum=Pay.Ptnum and Teacher.Tnum=Work1.Wtnum and Work1.Wclnum=Class.Clnum and Class.Clgrade='" + choose_item + "'";
            }
            else if (search_way.Equals("按月份查询"))
            {
                int i = int.Parse(choose_item);
                str = "select distinct Tnum,Tname,Pterm,Pmonth,Ptimes,Pposition,Pmanager,Paward,Pabsent,Paddelse,Preduceelse,Pservice from Teacher,Pay where Pay.Ptnum=Teacher.Tnum and Pay.Pmonth='" + i + "'";
            }
            else if (search_way.Equals("按教师类型查询"))
            {
                if(choose.SelectedItem.Value.ToString().Equals("后勤"))
                str = "select distinct Tnum,Tname,Pterm,Pmonth,Ptimes,Pposition,Pmanager,Paward,Pabsent,Paddelse,Preduceelse,Pservice from Teacher,Pay,Work2 where Teacher.Tnum=Pay.Ptnum and Teacher.Tnum=Work2.Wnum ";
                else
                    str = "select distinct Tnum,Tname,Pterm,Pmonth,Ptimes,Pposition,Pmanager,Paward,Pabsent,Paddelse,Preduceelse,Pservice from Teacher,Pay,Work1 where Teacher.Tnum=Pay.Ptnum and Teacher.Tnum=Work1.Wtnum ";
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = str;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dsk = new DataSet();
            sda.Fill(dsk);
            GridViewDisplay.DataSource = dsk;
            GridViewDisplay.DataBind();
            conn.Close();
        }

        public void bind()
        {
            String search_way = Way.SelectedItem.Value.ToString();
        
            choose.Items.Clear();
            if(search_way.Equals("按年级查询"))
            {
                choose.Items.Add("七年级");
                choose.Items.Add("八年级");
                choose.Items.Add("九年级");
            }
            else if(search_way.Equals("按月份查询"))
            {
                choose.Items.Add("1");
                choose.Items.Add("2");
                choose.Items.Add("3");
                choose.Items.Add("4");
                choose.Items.Add("5");
                choose.Items.Add("6");
                choose.Items.Add("7");
                choose.Items.Add("8");
                choose.Items.Add("9");
                choose.Items.Add("10");
                choose.Items.Add("11");
                choose.Items.Add("12");
            }
            else if(search_way.Equals("按教师类型查询"))
            {
                choose.Items.Add("教师");
                choose.Items.Add("后勤");
            }
        }

        protected void Way_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind();
        }

        public void bind2()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str;
            str = "select distinct Tnum,Tname,Pterm,Pmonth,Ptimes,Pposition,Pmanager,Paward,Pabsent,Paddelse,Preduceelse,Pservice from Teacher,Pay where Teacher.Tnum=Pay.Ptnum";
            cmd.CommandText = str;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dsk = new DataSet();
            sda.Fill(dsk);
            GridViewDisplay.DataSource = dsk;
            GridViewDisplay.DataBind();
            conn.Close();
        }

        

        protected void GridViewDisplay_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewDisplay.EditIndex = e.NewEditIndex;
            search1();
        }

        protected void GridViewDisplay_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int award_in = 0;
            int add_in = 0;
            int reduce_in = 0;
            String award = ((TextBox)(GridViewDisplay.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();
            String add= ((TextBox)(GridViewDisplay.Rows[e.RowIndex].Cells[9].Controls[0])).Text.ToString().Trim();
            String reduce=((TextBox)(GridViewDisplay.Rows[e.RowIndex].Cells[10].Controls[0])).Text.ToString().Trim();
            string months = GridViewDisplay.Rows[e.RowIndex].Cells[3].Text.ToString();
            String key = GridViewDisplay.Rows[e.RowIndex].Cells[0].Text.ToString();
            int month =int.Parse (months);
            try
            {
                award_in = int.Parse(award);
                add_in = int.Parse(add);
                reduce_in = int.Parse(reduce);
            }
            catch
            {
                Response.Write("<script language=javascript>alert('请不要输入非数字')</script>");
                return;
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            String str;
            str = "update Pay set Paward=" + award_in + ",Paddelse=" + add_in + ",Preduceelse=" + reduce_in + " where Ptnum='" + key + "' and Pmonth='"+month+"'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script language=javascript>alert('修改完毕')</script>");
            GridViewDisplay.EditIndex = -1;
            bind2();
        }

        protected void GridViewDisplay_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewDisplay.EditIndex = -1;
            search1();
        }

        protected void export_Click(object sender, EventArgs e)
        {
            DataSet ds = dsk;
            String excelName = DateTime.Now.ToLongDateString().ToString()+"Income.xls";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.ContentType = "application/vnd.ms-xls";
            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

            DataGrid dg = new DataGrid();
            dg.DataSource = ds;
            dg.DataBind();
            dg.RenderControl(htmlWrite);
            HttpContext.Current.Response.AddHeader
            ("content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(excelName));

            HttpContext.Current.Response.Write(stringWrite.ToString());
            HttpContext.Current.Response.End();
        }

        public void search1()
        {
            String search_way = Way.SelectedItem.Value.Trim();
            String str = "";
            String choose_item = choose.SelectedItem.Value.Trim();

            if (search_way.Equals("按年级查询"))
            {
                str = "select distinct Tnum,Tname,Pterm,Pmonth,Ptimes,Pposition,Pmanager,Paward,Pabsent,Paddelse,Preduceelse,Pservice from Teacher,Pay,Work1,Class where Teacher.Tnum=Pay.Ptnum and Teacher.Tnum=Work1.Wtnum and Work1.Wclnum=Class.Clnum and Class.Clgrade='" + choose_item + "'";
            }
            else if (search_way.Equals("按月份查询"))
            {
                int i = int.Parse(choose_item);
                str = "select distinct Tnum,Tname,Pterm,Pmonth,Ptimes,Pposition,Pmanager,Paward,Pabsent,Paddelse,Preduceelse,Pservice from Teacher,Pay where Pay.Ptnum=Teacher.Tnum and Pay.Pmonth='" + i + "'";
            }
            else if (search_way.Equals("按教师类型查询"))
            {
                if (choose.SelectedItem.Value.ToString().Equals("后勤"))
                    str = "select distinct Tnum,Tname,Pterm,Pmonth,Ptimes,Pposition,Pmanager,Paward,Pabsent,Paddelse,Preduceelse,Pservice from Teacher,Pay,Work2 where Teacher.Tnum=Pay.Ptnum and Teacher.Tnum=Work2.Wnum ";
                else
                    str = "select distinct Tnum,Tname,Pterm,Pmonth,Ptimes,Pposition,Pmanager,Paward,Pabsent,Paddelse,Preduceelse,Pservice from Teacher,Pay,Work1 where Teacher.Tnum=Pay.Ptnum and Teacher.Tnum=Work1.Wtnum ";
            }
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = str;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dsk = new DataSet();
            sda.Fill(dsk);
            GridViewDisplay.DataSource = dsk;
            GridViewDisplay.DataBind();
            conn.Close();
        }

       
    }
}