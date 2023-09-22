<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tongzhiUpdate.aspx.cs" Inherits="tongzhiUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="css/admin.css" rel="stylesheet" />
    <title></title>
    <style>
        #Button1{
            background-color: #ddd;
            color: #000;
            font-size: 14px;
            width: 50px;
            height: 30px;
            outline: none;
            border: none;
            cursor: pointer;
            transition: .8s all;
        }
        #Button1:hover{
            background-color: #6495ed;
            color: #000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="add">
			<div class="addBox">
				<div class="contentAdd">
                    <asp:TextBox ID="txtTime" runat="server" placeholder="日期"></asp:TextBox>
                    <textarea id="TextArea1" runat="server" placeholder="内容"></textarea>
				</div>
                <div class="contentAddButton">
                    <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" />
				</div>
			</div>
		</div>
    </form>
</body>
</html>
