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
    public partial class LeaveInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind(Request.QueryString["num"]);
            }
        }

        public void bind(String s)
        {
            String user_num = Server.UrlDecode(Request.Cookies["Userisgrade"].Value);
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
            conn.Open();
            string str = "select * from Leave where Leave.Lnum='"+s+"'";
            SqlCommand cmd = new SqlCommand(str, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DetailsView1.DataSource = ds;
            DetailsView1.DataBind();
            DetailsView1.Visible = true;
            conn.Close();
        }

        
    }
}