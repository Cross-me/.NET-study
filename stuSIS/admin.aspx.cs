using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.Page
{
    Operation op = new Operation();
    protected DataRowCollection drs = null;
    protected DataRowCollection drn = null;
    protected int d = 0;
    protected int n = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["username"] == null)
            {
                WebMessageBox.Show("请先登录！", "login.aspx");
            }
            else
            {
                Label1.Text = Session["username"].ToString();
            }

            DataSet ds = op.wenzhangSelectInfo(1, 10);
            drs = ds.Tables[1].Rows;
            d = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

            DataSet dn = op.tongzhiSelectAll();
            drn = dn.Tables[0].Rows;
            n = Convert.ToInt32(dn.Tables[0].Rows[0][0]);
        }
    }

    private void DataBind(int PageIndex)
    {
        int PageSize = 10;
        DataSet ds = op.wenzhangSelectInfo(PageIndex, PageSize);
        if (ds != null && ds.Tables.Count > 0)
        {
            int Count = 0;
            int.TryParse(ds.Tables[0].Rows[0][0].ToString(), out Count);
            drs = ds.Tables[1].Rows;
            int GetTotalPageIndex = (Count / PageSize) + ((Count % PageSize) > 0 ? 1 : 0);
            this.TotalPageIndex.Text = GetTotalPageIndex.ToString();
            this.CurPageIndex.Text = PageIndex.ToString();
            if (PageIndex == 1 && PageIndex == GetTotalPageIndex)
            {
                SetPageState(0);
            }
            else if (PageIndex == 1)
            {
                SetPageState(1);
            }
            else if (PageIndex == GetTotalPageIndex)
            {
                SetPageState(2);
            }
            else
            {
                SetPageState(3);
            }
        }
    }

    protected void UpPage_Click(object sender, EventArgs e)
    {
        int CurIndex = Convert.ToInt32(this.CurPageIndex.Text);
        CurIndex--;
        DataBind(CurIndex);
    }

    protected void DownPage_Click(object sender, EventArgs e)
    {
        int CurIndex = Convert.ToInt32(this.CurPageIndex.Text);
        CurIndex++;
        DataBind(CurIndex);
    }

    public void SetPageState(int SetIndex)
    {
        if (SetIndex == 0)
        {
            this.UpPage.Enabled = false;
            this.DownPage.Enabled = false;
            this.UpPage.Style["color"] = "#808080";
            this.DownPage.Style["color"] = "#808080";
        }
        else if (SetIndex == 1)
        {
            this.UpPage.Enabled = false;
            this.DownPage.Enabled = true;
            this.UpPage.Style["color"] = "#808080";
            this.DownPage.Style["color"] = "#23527c";
        }
        else if (SetIndex == 2)
        {
            this.UpPage.Enabled = true;
            this.DownPage.Enabled = false;
            this.UpPage.Style["color"] = "#23527c";
            this.DownPage.Style["color"] = "#808080";
        }
        else
        {
            this.UpPage.Enabled = true;
            this.DownPage.Enabled = true;
            this.UpPage.Style["color"] = "#23527c";
            this.DownPage.Style["color"] = "#23527c";
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Session["username"] = "";
        Response.Redirect("login.aspx");
    }

    protected void Button1_Click2(object sender, EventArgs e)
    {
        if (txtTime.Text == "" && txtText.Text == "" && txtType.Text == "" && txtTag.Text == "")
        {
            DataBind(1);
        }
        else if (txtTime.Text != "" && txtText.Text == "" && txtType.Text == "" && txtTag.Text == "")
        {
            DataSet ds = op.wenzhangSelectTime(txtTime.Text);
            drs = ds.Tables[0].Rows;
        }
        else if (txtTime.Text == "" && txtText.Text != "" && txtType.Text == "" && txtTag.Text == "")
        {
            DataSet ds = op.wenzhangSelectText(txtText.Text);
            drs = ds.Tables[0].Rows;
        }
        else if (txtTime.Text == "" && txtText.Text == "" && txtType.Text != "" && txtTag.Text == "")
        {
            DataSet ds = op.wenzhangSelectType(txtType.Text);
            drs = ds.Tables[0].Rows;
        }
        else if (txtTime.Text == "" && txtText.Text == "" && txtType.Text == "" && txtTag.Text != "")
        {
            DataSet ds = op.wenzhangSelectTag(txtTag.Text);
            drs = ds.Tables[0].Rows;
        }
        else if (txtTime.Text != "" && txtText.Text != "" && txtType.Text != "" && txtTag.Text != "")
        {
            DataSet ds = op.wenzhangSelectInfo(txtTime.Text, txtText.Text, txtType.Text, txtTag.Text);
            drs = ds.Tables[0].Rows;
        }
        txtTime.Text = "";
        txtText.Text = "";
        txtType.Text = "";
        txtTag.Text = "";
        DataSet dn = op.tongzhiSelectAll();
        drn = dn.Tables[0].Rows;
    }




    protected void Button1_Click3(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" && TextBox2.Text == "")
        {
            DataSet dn = op.tongzhiSelectAll();
            drn = dn.Tables[0].Rows;
        }
        else if (TextBox1.Text != "" && TextBox2.Text == "")
        {
            DataSet dn = op.tongzhiSelectTime(TextBox1.Text);
            drn = dn.Tables[0].Rows;
        }
        else if (TextBox1.Text == "" && TextBox2.Text != "")
        {
            DataSet dn = op.tongzhiSelectText(TextBox2.Text);
            drn = dn.Tables[0].Rows;
        }
        else if (TextBox1.Text != "" && TextBox2.Text != "")
        {
            DataSet dn = op.tongzhiSelectInfo(TextBox1.Text, TextBox2.Text);
            drn = dn.Tables[0].Rows;
        }
        TextBox1.Text = "";
        TextBox2.Text = "";
        DataSet ds = op.wenzhangSelectInfo(1, 10);
        drs = ds.Tables[1].Rows;
    }
}