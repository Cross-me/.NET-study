<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link href="css/admin.css" rel="stylesheet" />
    <script src="js/jquery-3.2.1.min.js"></script>
    <title>219240155 Inori</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="all">
		<div class="top">
			<div class="topLeft">
				<p>博客管理系统</p>
			</div>
			<div class="topRight">
                <asp:Label ID="Label1" runat="server"></asp:Label>
				<a href="index.aspx">返回首页</a>
                <asp:Button ID="Button1" runat="server" Text="退出登录" OnClick="Button1_Click1" />
			</div>
		</div>
		<div class="mid">
			<div class="midLeft">
				<div class="box" @click="wenzhang()">
					<p>文章管理</p>
				</div>
				<div class="box" @click="tongzhi()">
					<p>通知管理</p>
				</div>
			</div>
			

            <!-- 文章管理 -->
			<div class="midRight wenzhang" ref="wenzhang">
				<div class="midRightTop">
                    <asp:TextBox ID="txtTime" runat="server" placeholder="日期"></asp:TextBox>
                    <asp:TextBox ID="txtText" runat="server" placeholder="内容"></asp:TextBox>
                    <asp:TextBox ID="txtType" runat="server" placeholder="分类"></asp:TextBox>
                    <asp:TextBox ID="txtTag" runat="server" placeholder="标签"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="查询" OnClick="Button1_Click2" />
					<a href="wenzhangAdd.aspx?id=<%=d %>">添加</a>
				</div>
				<div class="midRightBottom">
					<div class="contents">
						<div class="title">
							<p>日期</p>
							<p style="width: 500px;">内容</p>
							<p>分类</p>
                            <p>标签</p>
							<p>操作</p>
							<p>删除</p>
						</div>
                        <%
                            if (drs != null)
                            {
                                foreach(System.Data.DataRow dr in drs)
                                {
                        %>
						            <div class="content">
							            <p><%=dr["time"] %></p>
							            <p style="width: 500px;"><%=dr["text"] %></p>
							            <p><%=dr["type"] %></p>
                                        <p><%=dr["tag"] %></p>
							            <a href="wenzhangUpdate.aspx?id=<%=dr["cid"] %>">修改</a>
							            <a href="wenzhangDelete.aspx?id=<%=dr["cid"] %>">删除</a>
						            </div>
                        <%
                                }
                            }
                        %>
					</div>
				</div>
                <div class="midRightFoot">
                    <p>共<asp:Label ID="TotalPageIndex" runat="server" Text="1"></asp:Label>页</p>
                    <p>当前第<asp:Label ID="CurPageIndex" runat="server" Text="1"></asp:Label>页</p>
                    <asp:LinkButton ID="UpPage" runat="server"  OnClick="UpPage_Click">上一页</asp:LinkButton>
                    <asp:LinkButton ID="DownPage" runat="server" OnClick="DownPage_Click">下一页</asp:LinkButton>
                </div>
			</div>


			<!-- 通知管理 -->
			<div class="midRight tongzhi" ref="tongzhi">
				<div class="midRightTop">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="日期"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="内容"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="查询" OnClick="Button1_Click3" />
					<a href="tongzhiAdd.aspx?id=<%=n %>">添加</a>
				</div>
				<div class="midRightBottom">
					<div class="contents">
						<div class="title">
							<p>日期</p>
							<p style="width: 500px;">内容</p>
							<p>操作</p>
                            <p>删除</p>
						</div>
                        <%
                            if (drn != null)
                            {
                                foreach(System.Data.DataRow dN in drn)
                                {
                        %>
						            <div class="content">
							            <p><%=dN["time"] %></p>
							            <p style="width: 500px;"><%=dN["text"] %></p>
							            <a href="tongzhiUpdate.aspx?id=<%=dN["nid"] %>">修改</a>
							            <a href="tongzhiDelete.aspx?id=<%=dN["nid"] %>">删除</a>
						            </div>
                        <%
                                }
                            }
                        %>
					</div>
				</div>
			</div>
		</div>
		<div class="bottom">
			<p>Inori asp.net期末作业 基于web的博客管理系统</p>
		</div>
	</div>
    <script type="text/javascript">
        function setOpear(setID, setStateValue) {
            $("#opearID").val(setID);
            $("#opearState").val(setStateValue);
        }
    </script>
    <input type="hidden" id="opearID" name="opearID" value=""/>
    <input type="hidden" id="opearState" name="opearState" value=""/>
    </form>
    <script src="js/vue.js"></script>
    <script src="js/admin.js"></script>
</body>
</html>
