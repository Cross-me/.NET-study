using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class login : System.Web.UI.Page
{
    Operation op = new Operation();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (op.Login(txtUser.Text.Trim(), txtPwd.Text.Trim()).Tables[0].Rows.Count > 0)
        {
            Session.Add("username", txtUser.Text.Trim());
            Response.Redirect("admin.aspx");
        }
        else
        {
            WebMessageBox.Show("用户名或密码不正确！", "Login.aspx");
        }
    }
}