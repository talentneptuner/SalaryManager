<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="EmptyProjectNet20._default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>湖北省XX中学教师绩效管理系统</title>
    <style>
        #header table {
            width: 100%;
            border-spacing: 0;
            border-collapse: separate;
        }

            #header table td {
                padding: 0;
            }

        #header .title a,
        #header .pro a {
            font-weight: bold;
            font-size: 24px;
            text-decoration: none;
            line-height: 50px;
            margin-left: 10px;
        }

        #header .pro {
            position: absolute;
            top: 0;
            right: 10px;
        }

        .bottomtable {
            width: 100%;
            font-size: 12px;
        }


        /* 主题相关样式 - neptune */
        .f-theme-neptune #header,
        .f-theme-neptune .bottomtable,
        .f-theme-neptune .x-splitter {
            background-color: #1475BB;
            color: #fff;
        }

            .f-theme-neptune #header a,
            .f-theme-neptune .bottomtable a {
                color: #fff;
            }

            .f-theme-neptune #header .x-btn-over.x-btn-default-small {
                background-color: #3487c3;
            }


        /* 主题相关样式 - blue/classic */
        .f-theme-classic #header,
        .f-theme-classic .bottomtable {
            background-color: #DFE8F6;
            color: #000;
        }

            .f-theme-classic #header a,
            .f-theme-classic .bottomtable a {
                color: #000;
            }

            .f-theme-classic #header .x-btn-over.x-btn-default-small {
                background-color: #e4f3ff;
            }


        /* 主题相关样式 - gray */
        .f-theme-gray #header,
        .f-theme-gray .bottomtable {
            background-color: #E0E0E0;
            color: #333;
        }

            .f-theme-gray #header a,
            .f-theme-gray .bottomtable a {
                color: #333;
            }

            .f-theme-gray #header .x-btn-over.x-btn-default-small {
                background-color: #f3f3f3;
            }


        /* 主题相关样式 - crisp */
        .f-theme-crisp #header,
        .f-theme-crisp .bottomtable,
        .f-theme-crisp .x-splitter {
            background-color: #E1E1E1;
            color: #000;
        }

            .f-theme-crisp #header a,
            .f-theme-crisp .bottomtable a {
                color: #000;
            }

            .f-theme-crisp #header .x-btn-inner-default-small {
                color: #000;
            }

            .f-theme-crisp #header .x-btn-over.x-btn-default-small .x-btn-inner-default-small {
                color: #fff;
            }

            .f-theme-crisp #header .x-btn-over.x-btn-default-small {
                background-color: #3487c3;
            }


        /* 主题相关样式 - triton */
        .f-theme-triton #header,
        .f-theme-triton .bottomtable,
        .f-theme-triton .x-splitter {
            background-color: #477aa6;
            color: #fff;
        }

            .f-theme-triton #header a,
            .f-theme-triton .bottomtable a {
                color: #fff;
            }

            .f-theme-triton #header .x-btn-over.x-btn-default-small {
                background-color: #5795cb;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <f:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></f:PageManager>
        <f:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
            <Regions>
                <f:Region ID="Region1" ShowBorder="false" Height="50px" ShowHeader="false"
                    Position="Top" Layout="Fit" runat="server">
                    <Content>
                        <div id="header">
                            <table>
                                <tr>
                                    <td>
                                        <div class="title">
                                            <a href="./default.aspx">湖北省xxx中学教职工管理系统</a>
                                        </div>
                                    </td>
                                    <td style="text-align: right;">
                                        <div class="pro">
                                            <a href="./Index.aspx"  target="_self">回到登录</a>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </Content>
                </f:Region>
                <f:Region ID="Region2" Split="true" Width="200px" ShowHeader="true" Title="菜单"
                    EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                    <Items>
                        <f:Tree runat="server" ShowBorder="false" ShowHeader="false" EnableArrows="true" EnableLines="true" ID="leftMenuTree">
                            <Nodes>
                                <f:TreeNode Text="教师查询" Expanded="true">
                                    <f:TreeNode Text="查询工作" NavigateUrl="~/SearchWork.aspx"></f:TreeNode>
                                    <f:TreeNode Text="查询绩效" NavigateUrl="~/SearchPay.aspx"></f:TreeNode>
                                    <f:TreeNode Text="请假" NavigateUrl="~/Leave.aspx"></f:TreeNode>
                                    <f:TreeNode Text="教师通讯录" NavigateUrl="~/TelofTeacher.aspx"></f:TreeNode>
                                    <f:TreeNode Text="密码修改" NavigateUrl="~/PassModify.aspx"></f:TreeNode>
                                </f:TreeNode>
                            </Nodes>
                        </f:Tree>
                    </Items>
                </f:Region>
                <f:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Position="Center"
                    runat="server">
                    <Items>
                        <f:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <f:Tab ID="Tab1" Title="首页" Layout="Fit" Icon="House" runat="server">
                                    <Items>
                                        <f:ContentPanel ID="ContentPanel2" ShowBorder="false" BodyPadding="10px" ShowHeader="false" AutoScroll="true"
                                            runat="server">
                                            <h2>湖北省xxx中学教职工管理</h2>
                                            提供职务管理，工资管理以及请假管理
                                        
                                            <br />
                                            <h2>操作方法</h2>
                                            请按照左边菜单栏选择功能进行操作
                                        
                                            <br />
                                            <h2>说明</h2>
                                            系统操作需要按照严格的人员操作顺序
                                        
                                            <br />
                                            <h2>说明</h2>
                                            本系统只是Demo版，最后得出的工资结果若与实际不符请按照实际工资为准
                                            
                                            <br />
                                            <h2>作者：海王星人zj</h2>
                                            电话：151****2133
                                            <br />
                                            邮箱：151****2133@163.com
                                            <br />
                                            QQ&nbsp：1141764044
                                            <br />
                                            微博：<a target="_blank" style="color:black" href="http://weibo.com/577443032/home?wvr=5&sudaref=www.hao123.com&retcode=6102&sudaref=passport.weibo.com">点击查看</a>
                                            <br />
                                            <br />
                                            <br />
                                            <br />

                                            <hr />
                                            <br />
                                            <a target="_blank" href="http://fineui.com/pro/">框架;FineUI</a>

                                        </f:ContentPanel>
                                    </Items>
                                </f:Tab>
                            </Tabs>
                        </f:TabStrip>
                    </Items>
                </f:Region>
                <f:Region ID="bottomPanel" RegionPosition="Bottom" ShowBorder="false" ShowHeader="false" EnableCollapse="false" runat="server" Layout="Fit">
                    <Items>
                        <f:ContentPanel ID="ContentPanel3" runat="server" ShowBorder="false" ShowHeader="false">
                            <table class="bottomtable">
                                <tr>
                                    <td style="width: 300px;">&nbsp;版本：<a target="_blank" href="http://fineui.com/version">v0.1</a>
                                        &nbsp;&nbsp; <a target="_blank" href="http://wp.qq.com/wpa/qunwpa?idkey=5a98eb42b742a1edaf22826648d5f61bc16ed08e0253976bc8d30f97508c09c7"></a></td>
                                    <td style="text-align: center;">Copyright &copy; 湖北省xxx中学教职工管理系统</td>
                                    <td style="width: 300px; text-align: right;">&nbsp;</td>
                                </tr>
                            </table>
                        </f:ContentPanel>
                    </Items>
                </f:Region>
            </Regions>
        </f:RegionPanel>
    </form>
    <script>
        var menuClientID = '<%= leftMenuTree.ClientID %>';
        var tabStripClientID = '<%= mainTabStrip.ClientID %>';

        // 页面控件初始化完毕后，会调用用户自定义的onReady函数
        F.ready(function () {

            var treeMenu = F(menuClientID);
            var mainTabStrip = F(tabStripClientID);

            // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
            // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
            // mainTabStrip： 选项卡实例
            // updateHash: 切换Tab时，是否更新地址栏Hash值（默认值：true）
            // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame（默认值：false）
            // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame（默认值：false）
            // maxTabCount: 最大允许打开的选项卡数量
            // maxTabMessage: 超过最大允许打开选项卡数量时的提示信息
            F.initTreeTabStrip(treeMenu, mainTabStrip, {
                maxTabCount: 10,
                maxTabMessage: '请先关闭一些选项卡（最多允许打开 10 个）！'
            });

        });
    </script>
</body>
</html>
