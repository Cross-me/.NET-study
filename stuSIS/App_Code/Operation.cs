using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Operation 网站业务流程类（封装所有业务方法）
/// </summary>
public class Operation
{
    public Operation()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    DataBase data = new DataBase();

    public DataSet wenzhangSelectAll()
    {
        return data.RunProcReturn("select * from contents order by cid desc", "contents");
    }


    public DataSet Login(string user, string pwd)
    {
        SqlParameter[] parms =
        {
            data.MakeInParam("@name", SqlDbType.VarChar, 50, user),
            data.MakeInParam("@password", SqlDbType.VarChar, 50, pwd)
        };
        return data.RunProcReturn("select * from admin where name=@name and password=@password", parms, "admin");
    }


    public DataSet wenzhangSelectInfo(int cid)
    {
        return data.RunProcReturn("select * from contents where cid='" + cid + "'", "contents");
    }


    public void wenzhangInsert(int cid, string time, string text, string type, string tag)
    {
        SqlParameter[] parms = {
            data.MakeInParam("@cid",SqlDbType.Int,50,cid),
            data.MakeInParam("@time",SqlDbType.VarChar,50,time),
            data.MakeInParam("@text",SqlDbType.VarChar,500,text),
            data.MakeInParam("@type",SqlDbType.VarChar,50,type),
            data.MakeInParam("@tag",SqlDbType.VarChar,50,tag)
        };
        int i = data.RunProc("insert into contents(cid,time,text,type,tag) values(@cid,@time,@text,@type,@tag)", parms);
    }


    public void wenzhangUpdate(int cid, string time, string text, string type, string tag)
    {
        SqlParameter[] parms = {
            data.MakeInParam("@cid",SqlDbType.Int,50,cid),
            data.MakeInParam("@time",SqlDbType.VarChar,50,time),
            data.MakeInParam("@text",SqlDbType.VarChar,500,text),
            data.MakeInParam("@type",SqlDbType.VarChar,50,type),
            data.MakeInParam("@tag",SqlDbType.VarChar,50,tag)
        };
        int i = data.RunProc("update contents set time=@time,text=@text,type=@type,tag=@tag where cid=@cid", parms);
    }


    public void wenzhangDelete(int cid)
    {
        int i = data.RunProc("delete from contents where cid='" + cid + "'");
    }


    public DataSet wenzhangSelectInfo(string time, string text, string type, string tag)
    {
        return data.RunProcReturn("select * from contents where time like " + "'%" + time + "%'" + " and text like " + "'%" + text + "%'" + " and type like " + "'%" + type + "%'" + " and tag like " + "'%" + tag + "%'", "contents");
    }
    
    public DataSet wenzhangSelectTime(string time)
    {
        return data.RunProcReturn("select * from contents where time like " + "'%" + time + "%'", "contents");
    }


    public DataSet wenzhangSelectText(string text)
    {
        return data.RunProcReturn("select * from contents where text like " + "'%" + text + "%'", "contents");
    }


    public DataSet wenzhangSelectType(string type)
    {
        return data.RunProcReturn("select * from contents where type like " + "'%" + type + "%'", "contents");
    }


    public DataSet wenzhangSelectTag(string tag)
    {
        return data.RunProcReturn("select * from contents where tag like " + "'%" + tag + "%'", "contents");
    }

    public DataSet wenzhangSelectInfo(int pageIndex, int pageSize)
    {
        int StartIndex = ((pageIndex - 1) * pageSize) + 1;
        int EndIndex = pageIndex * pageSize;
        return data.RunProcReturn("select count(1) from contents;" +
            "select * from (SELECT cid, time, text, type, tag,Row_Number() over(ORDER BY cid DESC) as rowIndex " +
            "FROM contents) as Tab " +
            "where rowIndex between " + StartIndex + " and " + EndIndex, "contents");
    }




    public DataSet tongzhiSelectAll()
    {
        return data.RunProcReturn("select * from notic order by nid desc", "notic");
    }

    public DataSet tongzhiSelectInfo(int nid)
    {
        return data.RunProcReturn("select * from notic where nid='" + nid + "'", "notic");
    }

    public DataSet tongzhiSelectTime(string time)
    {
        return data.RunProcReturn("select * from notic where time like " + "'%" + time + "%'", "notic");
    }

    public DataSet tongzhiSelectText(string text)
    {
        return data.RunProcReturn("select * from notic where text like " + "'%" + text + "%'", "notic");
    }

    public DataSet tongzhiSelectInfo(string time, string text)
    {
        return data.RunProcReturn("select * from notic where time like " + "'%" + time + "%'" + " and text like " + "'%" + text + "%'", "notic");
    }

    public void tongzhiInsert(int nid, string time, string text)
    {
        SqlParameter[] parms = {
            data.MakeInParam("@nid",SqlDbType.Int,50,nid),
            data.MakeInParam("@time",SqlDbType.VarChar,50,time),
            data.MakeInParam("@text",SqlDbType.VarChar,500,text)
        };
        int i = data.RunProc("insert into notic(nid,time,text) values(@nid,@time,@text)", parms);
    }

    public void tongzhiDelete(int nid)
    {
        int i = data.RunProc("delete from notic where nid='" + nid + "'");
    }

    public void tongzhiUpdate(int nid, string time, string text)
    {
        SqlParameter[] parms = {
            data.MakeInParam("@nid",SqlDbType.Int,50,nid),
            data.MakeInParam("@time",SqlDbType.VarChar,50,time),
            data.MakeInParam("@text",SqlDbType.VarChar,500,text)
        };
        int i = data.RunProc("update notic set time=@time,text=@text where nid=@nid", parms);
    }
}