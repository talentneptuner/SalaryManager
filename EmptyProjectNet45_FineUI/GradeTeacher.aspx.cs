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
    public partial class GradeTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind();
            }
        }

        protected void GridViewDisplay_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String key = GridViewDisplay.Rows[e.RowIndex].Cells[0].Text.ToString();
            String key1 = GridViewDisplay.Rows[e.RowIndex].Cells[4].Text.ToString();
            String key2 = GridViewDisplay.Rows[e.RowIndex].Cells[2].Text.ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str;
            str = "select count(*) from Class where Clnum='" + key + "' and Clmanager ='" + key2 + "'";
            SqlCommand cmd = new SqlCommand(str, conn);
            int n = (int)cmd.ExecuteScalar();
            if(n!=0)
            {
                Response.Write("<script language=javascript>alert('请先修改班主任，然后方能删除')</script>");
                return;
            }
            str = "delete from Work1 where Wclnum='"+key+"' and Wcrnum ='"+key1+"'";
            cmd.CommandText = str;
            cmd.ExecuteNonQuery();
            Response.Write("<script language=javascript>alert('删除成功')</script>");
            conn.Close();
            bind();
        }

        public void bind()
        {
            String user_num = Server.UrlDecode(Request.Cookies["Userisgrade"].Value); 
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str = "select * from Teacher,Class,Crouse,Work1 where Teacher.Tnum = Work1.Wtnum AND Work1.Wclnum = Class.Clnum AND Work1.Wcrnum = Crouse.Crnum AND Class.Clgrade = '" + user_num + "' order by Class.Clnum , Crouse.Crnum";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            GridViewDisplay.DataSource = ds;
            GridViewDisplay.DataBind();
            GridViewDisplay.Visible = true;
            conn.Close();

        }
    }
}