using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wenzhangAdd : System.Web.UI.Page
{
    Operation op = new Operation();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string time = txtTime.Text;
        string text = TextArea1.Value;
        string type = txtType.Text;
        string tag = txtTag.Text;
        DataSet dr = op.wenzhangSelectAll();
        int cid = (Convert.ToInt32(dr.Tables[0].Rows[0][0])) + 1;
        op.wenzhangInsert(cid, time, text, type, tag);
        WebMessageBox.Show("添加成功", "admin.aspx");
    }
}