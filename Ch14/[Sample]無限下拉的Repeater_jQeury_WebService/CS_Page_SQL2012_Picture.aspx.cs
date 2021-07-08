using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
//----自己寫的（宣告)----
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;  //*** Web Service 會用到 ***********************
using System.Web.Configuration;
//----自己寫的（宣告)----


public partial class CS_ListView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  // 第一次執行
        {   // 自己寫的副程式，從第一頁開始。
            // 為了配合前端的jQeury，這裡的第一頁不可以是"零"，需是一。
            Repeater1.DataSource = MIS2000Lab_GetPageData(1);
            Repeater1.DataBind();
        }
    }

    // *** 自己寫的副程式 **************************（分頁）
    // ***** 分頁。使用SQL指令進行分頁 *****
    // 請使用 public static
    public static DataSet MIS2000Lab_GetPageData(int currentPage)
    {
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);

        String SqlStr = "SELECT [FileUpload_FileName] FROM [FileUpload_DB] ORDER BY [FileUpload_DB_id] ASC";
        SqlStr += " OFFSET @A ROWS FETCH NEXT 4 ROWS ONLY";
        // 為了配合前端的jQeury，這裡的第一頁不可以是"零"，需是一。程式改成 ((currentPage-1) * 10)
        //==SQL 2012 指令的 Offset...Fetch。參考資料： http://sharedderrick.blogspot.tw/2012/06/t-sql-offset-fetch.html  

        SqlDataAdapter myAdapter = new SqlDataAdapter(SqlStr, Conn);
        myAdapter.SelectCommand.Parameters.AddWithValue("@A", ((currentPage - 1) * 4));


        DataSet ds = new DataSet();
        myAdapter.Fill(ds, "Customers");

        //-- 用來計算分頁的「總頁數」 ---------------------------------------(start)        
        SqlCommand cmd = new SqlCommand("SELECT Count(FileUpload_DB_id) FROM [FileUpload_DB]", Conn);
        Conn.Open();  //== 第一，連結資料庫。           
        int myTotalCount = (int)cmd.ExecuteScalar();   //== 第二，執行SQL指令。

        // 少了底下這一段，畫面只會出現20筆記錄（第一次十筆，第二次十筆，然後就停止了）
        DataTable dt = new DataTable("DT_PageCount");  // 建立一個DataTable，名為DT_PageCount
        dt.Columns.Add("Field_PageCount");  // 有一個欄位名為Field_PageCount
        dt.Rows.Add();
        dt.Rows[0][0] = myTotalCount;  // 全部的紀錄需要「幾頁」才能呈現完畢？
        ds.Tables.Add(dt);

        if (Conn.State == ConnectionState.Open)
        {
            Conn.Close();
            Conn.Dispose();
        }
        //-- 用來計算分頁的「總頁數」 ---------------------------------------(end)

        return ds;
    }

    //***************************************************************************
    [WebMethod]
    public static string GetCustomers(int pageIndex)
    {
        return MIS2000Lab_GetPageData(pageIndex).GetXml();
    }


}