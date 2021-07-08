using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//----自己寫的（宣告)----
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
//----自己寫的（宣告)----


public partial class Advanced_Page_GridView_AllowCustomPaging : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)   {
            //*****************************
            GridView1.VirtualItemCount = MIS2000Lab_GetPageCount();  // 取得總記錄的"數量"。
            //*****************************

            GridView1.DataSource = MIS2000Lab_GetPageData(0, 10);  // 傳回值 DataTable
            GridView1.DataBind();
        }
    }
    

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        GridView1.DataSource = MIS2000Lab_GetPageData(e.NewPageIndex, 10);   //*** 重點！！ ***
        GridView1.DataBind();
    }



    /// <summary>
    /// 分頁。使用SQL指令進行分頁
    /// </summary>
    /// <param name="currentPage">目前位於第幾頁？</param>
    /// <param name="myPageSize">所有數據，總共需要 幾頁來展示</param>
    /// <returns>傳回一個 DataTable</returns>
    protected DataTable MIS2000Lab_GetPageData(int currentPage, int myPageSize)
    {
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
        SqlDataReader dr = null;

        ////============================
        ////== 組合SQL指令(2012) =============
        //動態組合字串，會受到SQL Injection或是XSS攻擊。建議改用「@參數」的寫法
        //String SqlStr = "Select test_time, id, title, summary from test Order By id ";   // 需要搭配Order By
        //SqlStr += " OFFSET " + (currentPage * GridView1.PageSize) + " ROWS FETCH NEXT " + (myPageSize) + " ROWS ONLY";
        //==SQL 2012 指令的 Offset...Fetch。參考資料： http://sharedderrick.blogspot.tw/2012/06/t-sql-offset-fetch.html  

        //== 參數的寫法 ==
        String SqlStr = "Select test_time, id, title, summary from test Order By id OFFSET @Page1 ROWS FETCH NEXT @Page2 ROWS ONLY";

        SqlCommand cmd = new SqlCommand(SqlStr, Conn);
        cmd.Parameters.AddWithValue("@Page1", (currentPage * GridView1.PageSize));
        cmd.Parameters.AddWithValue("@Page2", myPageSize);

        DataTable DT = new DataTable();

        try
        {   //== 第一，連結資料庫。
            Conn.Open();
            //== 第二，執行SQL指令。
            dr = cmd.ExecuteReader();

            //==第三，自由發揮，把執行後的結果呈現到畫面上。
            //==自己寫迴圈==
            DT.Load(dr);    // 將DataReader的成果 "載入" DataTable裡面。
        }
        //catch (Exception ex)
        //{   //---- 如果程式有錯誤或是例外狀況，將執行這一段
        //    //Response.Write("<b>Error Message----  </b>" + ex.ToString() + "<hr />");
        //}
        finally
        {   // == 第四，釋放資源、關閉資料庫的連結。
            if (dr != null)   {
                cmd.Cancel();
                //----關閉DataReader之前，一定要先「取消」SqlCommand
                //參考資料： http://blog.darkthread.net/blogs/darkthreadtw/archive/2007/04/23/737.aspx
                dr.Close();
            }
            if (Conn.State == ConnectionState.Open)  {
                Conn.Close();
            }
        }

        return DT;
    }



    /// <summary>
    ///  取得總記錄的 "數量（總筆數）"。
    /// </summary>
    /// <returns>傳回一個整數 (int)</returns>
    protected int MIS2000Lab_GetPageCount()
    {
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select Count(id) from test", Conn);
        int myPageCount = 0;
        try
        {   //== 第一，連結資料庫。
            Conn.Open();

            //== 第二，執行SQL指令。
            myPageCount = (int)cmd.ExecuteScalar();

            //==第三，自由發揮，把執行後的結果呈現到畫面上。

        }
        //catch (Exception ex)
        //{   //---- 如果程式有錯誤或是例外狀況，將執行這一段
        //    //Response.Write("<b>Error Message----  </b>" + ex.ToString() + "<hr />");
        //}
        finally
        {   // == 第四，釋放資源、關閉資料庫的連結。
            if (Conn.State == ConnectionState.Open)  {
                Conn.Close();
            }
        }

        return myPageCount;
    }

}