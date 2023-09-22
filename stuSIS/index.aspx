<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link href="css/index.css" rel="stylesheet" />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <title>219240155 Inori</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="app" class="all">
			<div class="header" ref="head">
				<div class="logo" @click="ydmenu">
					<img src="img/57394506_p0.jpg" />
				</div>
				<div class="nav" v-if="showPcn">
					<div class="user">
                        <a href="login.aspx"><i class="fa fa-user-circle-o"></i></a>
					</div>
					<div class="search" @click.stop="searchPlus">
						<i class="fa fa-search"></i>
					</div>
					<div class="iconflat" id="logo_menu" @click="icoN">
						<div :class="icon"></div>
					</div>
					<div class="menu" v-if="pcn">
						<ul>
							<li><a href="index.html">首页</a></li>
							<li><a href="inori.html">分类</a></li>
							<li><a href="vlog.html">标签</a></li>
							<li><a href="#">关于</a></li>
						</ul>
					</div>
				</div>
			</div>
			<div class="search-plus" v-if="search">
				<div class="search-plus-hide" @click="searchPlus">
					<div class="hide"></div>
				</div>
				<div class="pcssk">
					<div>
						<p>搜索</p>
						<i class="fa fa-search"></i>
                        <asp:TextBox ID="TextBox1" runat="server" class="ss" placeholder="请输入"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" class="ssb" Text="搜索" OnClick="Button1_Click" />
					</div>
				</div>
			</div>
			<div class="bg">
				<div class="star"></div>
				<div class="star star1"></div>
				<div class="star star2"></div>
				<div class="star star3"></div>
				<div class="star star4"></div>
				<div class="star star5"></div>
			</div>
			<div class="main">
				<div class="notice">
					<img src="img/sound.png" />
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
				</div>
                <%
                    if (drs != null)
                        {
                            foreach(System.Data.DataRow dr in drs)
                            {
                %>
				                <div class="content">
					                <div class="article">
						                <p><%=dr["text"] %></p>
					                </div>
					                <div class="info">
						                <div class="date">
							                <i class="fa fa-calendar"></i>
							                <span><%=dr["time"] %></span>
						                </div>
						                <div class="folder">
							                <i class="fa fa-folder"></i>
							                <span><%=dr["type"] %></span>
						                </div>
						                <div class="tag">
							                <i class="fa fa-tags"></i>
							                <span><%=dr["tag"] %></span>
						                </div>
					                </div>
				                </div>
                 <%
                            }
                    }
                 %>
			</div>
			<div class="foot">
				<p>inori asp.net期末</p>
			</div>
			<div class="ydmenu" v-if="showYdn" ref="ydN">
				<div class="hide" @click="closeYdn"></div>
				<div class="touxiang">
					<img src="img/57394506_p0.jpg">
				</div>
				<div class="sousuo">
					<input class="ydss" type="search" placeholder="搜索..."/>
				</div>
				<ul class="ydn">
					<li><a href="index.html">首 页</a></li>
					<li><a href="inori.html">语 录</a></li>
					<li><a href="vlog.html">记 录</a></li>
					<li><a href="#">关 于</a></li>
				</ul>
			</div>
			<div class="totop" ref="totop" @click="toTop"></div>
		</div>
    </form>
    <script src="js/vue.js"></script>
    <script src="js/index.js"></script>
</body>
</html>
