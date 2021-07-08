using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Services;  //*** Web Service 會用到 ***********************
//----自己寫的（宣告)----
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
//----自己寫的（宣告)----

public partial class Book_Sample_GridView_jQuery : System.Web.UI.Page
{
    public static int myPageSize;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {  
            myPageSize = GridView1.PageSize;

            GridView1.DataSource = MIS2000Lab_GetPageData(1);   // 自己寫的副程式，從第一頁開始
            // 自己寫的副程式，從第一頁開始。
            // 為了配合前端的jQeury，這裡的第一頁不可以是"零"，需是一。
            GridView1.DataBind();
        }
    }

    // ***** 分頁。使用SQL指令進行分頁 *****
    // 請使用 public static
    public static DataSet MIS2000Lab_GetPageData(int currentPage)
    {
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);

        String SqlStr = "Select test_time, id, title from test Order By id ";
        SqlStr += " OFFSET " + ((currentPage-1) * myPageSize) + " ROWS FETCH NEXT " + myPageSize + " ROWS ONLY";
        //==SQL 2012 指令的 Offset...Fetch。參考資料： http://sharedderrick.blogspot.tw/2012/06/t-sql-offset-fetch.html  
        // 為了配合前端的jQeury，這裡的第一頁不可以是"零"，需是一。程式改成 ((currentPage-1) * 10)

        SqlDataAdapter myAdapter = new SqlDataAdapter(SqlStr, Conn);
        DataSet ds = new DataSet();
        myAdapter.Fill(ds, "test");

        //-- 用來計算分頁的「總頁數」 ---------------------------------------(start)
        SqlCommand cmd = new SqlCommand("select Count(id) from test", Conn);
            Conn.Open();  //== 第一，連結資料庫。           
            int myTotalCount = (int)cmd.ExecuteScalar();   //== 第二，執行SQL指令。

        if (Conn.State == ConnectionState.Open)        {
            Conn.Close();
            Conn.Dispose(); //---- 一開始宣告有用到 New的,最後必須以 .Dispose()結束
        }

        // 少了底下這一段，畫面只會出現20筆記錄（第一次十筆，第二次十筆，然後就停止了）
        DataTable dt = new DataTable("DT_PageCount");  // 建立一個DataTable，名為DT_PageCount
        dt.Columns.Add("Field_PageCount");  // 有一個欄位名為Field_PageCount
        dt.Rows.Add();
        dt.Rows[0][0] = myTotalCount;  // 全部的紀錄需要「幾頁」才能呈現完畢？
        ds.Tables.Add(dt);
        //-- 用來計算分頁的「總頁數」 ---------------------------------------(end)

        return ds;
    }

    //***************************************************************************
    [WebMethod]
    public static string GetNewRecord(int pageIndex)
    {
        return MIS2000Lab_GetPageData(pageIndex).GetXml();
    }
}