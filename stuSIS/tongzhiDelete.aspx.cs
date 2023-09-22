using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class tongzhiDelete : System.Web.UI.Page
{
    Operation op = new Operation();

    protected void Page_Load(object sender, EventArgs e)
    {
        int id = 0;
        if (int.TryParse(Request.QueryString["id"], out id))
        {
            DataSet ds = op.tongzhiSelectInfo(Convert.ToInt32(id.ToString()));
            txtTime.Text = ds.Tables[0].Rows[0][1].ToString();
            TextArea1.Value = ds.Tables[0].Rows[0][2].ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        op.tongzhiDelete(Convert.ToInt32(Request.QueryString["id"]));
        WebMessageBox.Show("删除成功", "admin.aspx");
    }
}