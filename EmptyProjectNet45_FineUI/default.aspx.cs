using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmptyProjectNet20
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
                String user_isgrade = Server.UrlDecode(Request.Cookies["Userisgrade"].Value);
                String user_position = Server.UrlDecode(Request.Cookies["Userposition"].Value);
                if (user_isgrade.Equals("七年级")|| user_isgrade.Equals("八年级")|| user_isgrade.Equals("九年级"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = "年级主任工作";
                    node.Expanded = false;
                    leftMenuTree.Nodes.Add(node);
                    FineUI.TreeNode node1 = new FineUI.TreeNode();
                    node1.Text = "教师工作目录";
                    node1.NavigateUrl = "~/GradeTeacher.aspx";
                    leftMenuTree.Nodes[1].Nodes.Add(node1);
                    FineUI.TreeNode node2 = new FineUI.TreeNode();
                    node2.Text = "教师工作调整";
                    node2.NavigateUrl = "~/ChooseManager.aspx";
                    leftMenuTree.Nodes[1].Nodes.Add(node2);
                    FineUI.TreeNode node3 = new FineUI.TreeNode();
                    node3.Text = "请假信息管理";
                    node3.NavigateUrl = "~/LeaveItem.aspx";
                    leftMenuTree.Nodes[1].Nodes.Add(node3);
                }
                else if(user_isgrade.Equals("后勤"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = "后勤工作";
                    node.Expanded = false;
                    leftMenuTree.Nodes.Add(node);
                    FineUI.TreeNode node1 = new FineUI.TreeNode();
                    node1.Text = "职务分配";
                    node1.NavigateUrl = "~/ServiceManager.aspx";
                    leftMenuTree.Nodes[1].Nodes.Add(node1);
                    FineUI.TreeNode node2 = new FineUI.TreeNode();
                    node2.Text = "请假审核";
                    node2.NavigateUrl = "~/LeaveItem.aspx";
                    leftMenuTree.Nodes[1].Nodes.Add(node2);
                }
                
                if(user_position.Equals("财务"))
                {
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = "财务工作";
                    node.NavigateUrl = "~/Fianace.aspx";
                    leftMenuTree.Nodes.Add(node);
                }
                else if(user_position.Equals("校长")||user_position.Equals("副校长"))
                {
                    int n=1;
                    if (leftMenuTree.Nodes.Count == 1)
                        n = 1;
                    if (leftMenuTree.Nodes.Count == 2)
                        n = 2;
                    FineUI.TreeNode node = new FineUI.TreeNode();
                    node.Text = "校务工作";
                    node.Expanded = false;
                    leftMenuTree.Nodes.Add(node);
                    FineUI.TreeNode node1 = new FineUI.TreeNode();
                    node1.Text = "教师信息管理";
                    node1.NavigateUrl = "~/Teacher_Manage.aspx";
                    leftMenuTree.Nodes[n].Nodes.Add(node1);
                    FineUI.TreeNode node2 = new FineUI.TreeNode();
                    node2.Text = "班级信息管理";
                    node2.NavigateUrl = "~/TeacherManager2.aspx";
                    leftMenuTree.Nodes[n].Nodes.Add(node2);
                    FineUI.TreeNode node3 = new FineUI.TreeNode();
                    node3.Text = "学期开始与关闭";
                    node3.NavigateUrl = "~/TermAdd.aspx";
                    leftMenuTree.Nodes[n].Nodes.Add(node3);
                }
            }
            
        }
    }
}