using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class index : System.Web.UI.Page
{
    Operation op = new Operation();
    protected DataRowCollection drs = null;
    protected DataRowCollection drn = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = op.wenzhangSelectAll();
            drs = ds.Tables[0].Rows;
        }
        DataSet dn = op.tongzhiSelectAll();
        drn = dn.Tables[0].Rows;
        Label1.Text = drn[0][2].ToString();
    }

    protected void search(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string text = TextBox1.Text.Trim();
        if (text != "")
        {
            DataSet ds = op.wenzhangSelectText(text);
            drs = ds.Tables[0].Rows;
        }
        else
        {
            DataSet ds = op.wenzhangSelectAll();
            drs = ds.Tables[0].Rows;
        }
        TextBox1.Text = "";
    }
}