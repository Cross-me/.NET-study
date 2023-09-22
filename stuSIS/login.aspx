<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<meta name="viewport" content="width=device-width,initial-scale=1,minimum-scale=1,maximum-scale=1,user-scalable=no" />
    <link href="css/login.css" rel="stylesheet" />
    <title>219240155 Inori</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="all">
			<div class="bg"></div>
			<div class="login">
				<h1>登 陆</h1>
                <asp:TextBox ID="txtUser" runat="server" placeholder="账号"></asp:TextBox>
                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" placeholder="密码"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" class="button" Text="登录" OnClick="Button1_Click" />
			</div>
		</div>
    </form>
</body>
</html>
