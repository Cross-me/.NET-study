using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tongzhiUpdate : System.Web.UI.Page
{
    Operation op = new Operation();

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (!IsPostBack)
        {
            if (int.TryParse(Request.QueryString["id"], out id))
            {
                DataSet ds = op.tongzhiSelectInfo(Convert.ToInt32(id.ToString()));
                txtTime.Text = ds.Tables[0].Rows[0][1].ToString();
                TextArea1.Value = ds.Tables[0].Rows[0][2].ToString();
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int cid = Convert.ToInt32(Request.QueryString["id"]);
        string time = txtTime.Text.Trim();
        string text = TextArea1.Value;
        op.tongzhiUpdate(cid, time, text);
        WebMessageBox.Show("修改成功", "admin.aspx");
    }
}