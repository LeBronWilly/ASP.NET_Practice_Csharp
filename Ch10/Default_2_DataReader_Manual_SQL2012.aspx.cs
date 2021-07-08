using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//*********************************自己加寫（宣告）的NameSpace
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;  //程式裡面用到 IsNumeric()函數
//*********************************


public partial class Book_Sample_Ch10_Default_2_DataReader_Manual : System.Web.UI.Page
{

    //==== 這一段程式很常被用到，所以獨立寫成一個 DBInit副程式。
    //==== 這樣會讓程式的可讀性提高！
    protected void DBInit()   //====自己手寫的程式碼， Datareader / SqlCommand ====(Start)
    {        
        //=========   ASP.NET  DataReader 分頁程式 by MIS2000 Lab.   ==========        
        Boolean haveRec = false;

        // p 就是「目前在第幾頁?」
        int p = Convert.ToInt32(Request["p"]);


        //============  ADO.NET / DataReader==(Start)======
        //SqlConnection Conn = new SqlConnection("server=localhost; uid=test; pwd=test; database=test");
        SqlConnection Conn = new SqlConnection("Data Source=.\\SqlExpress;Initial Catalog=test;Integrated Security=True");
        //-- 不需要使用多重結果集（MARS）  ;MultipleActiveResultSets=True
        Conn.Open();

        SqlCommand cmd = new SqlCommand("select count(id) from test", Conn);

        //SQL指令共撈到多少筆（列）紀錄。RecordCount資料總筆（列）數
        int RecordCount = (int)cmd.ExecuteScalar();
        cmd.Cancel();
        //============  ADO.NET / DataReader ==(End)======

        
        //int PageSize = 5;    // 每頁展示 5筆紀錄
        int PageSize = GridView1.PageSize;   // 每頁展示 幾筆紀錄？直接給 GridView的 PageSize屬性決定。

        //如果撈不到紀錄，程式就結束。-- Start --------------
        if (RecordCount == 0)
        {
            Response.Write("<h2>抱歉！無法找到您需要的紀錄！</h2>");
            Conn.Close();
            Response.End();
        }    //如果撈不到紀錄，程式就結束。-- End ----------

        //Pages 紀錄的總頁數。搜尋到的所有紀錄，共需「幾頁」才能全部呈現？
        int Pages = ((RecordCount + PageSize) - 1) / (PageSize);    //除法，取得「商」。

        //  底下這一段IF判別式，是用來防呆，防止一些例外狀況。-- start --        
        if (Request["p"] == null)   {
            p = 1;
        }
        else   {
            if (IsNumeric(Request["p"]))
            {   // 有任何問題，就強制跳回第一頁（p=1）。
                // 頁數（p）務必是一個整數。而且需要大於零、比起「紀錄的總頁數」要少
                if ((p > 0) & (p <= Pages))   {
                    p = Convert.ToInt32(Request["p"]);
                }
                else   {
                    p = 1;
                }
            }
            else   {
                p = 1;
            }
        }  //上面這一段IF辦別式，是用來防呆，防止一些例外狀況。-- end --

        //NowPageCount，目前這頁的紀錄
        int NowPageCount = 0;
        if (p > 0)   {
            NowPageCount = (p - 1) * PageSize;    //PageSize，每頁展示幾筆紀錄（上面設定過了）
        }
        Response.Write("<h3>搜尋資料庫:&nbsp;&nbsp; (共計" + RecordCount + "筆 / 共需" + Pages + "頁)</h3>");
        Response.Write("<hr width='97%' size='1'>");



        //========================
        //== 組合SQL指令 =============
        SqlDataReader dr = null;

        String SqlStr = "Select test_time, id, title, summary from test Order By id ";   // 需要搭配Order By
        SqlStr += " OFFSET " + (NowPageCount) + " ROWS FETCH NEXT " + (PageSize) + " ROWS ONLY";
        //==SQL 2012 指令的 Offset...Fetch。參考資料： http://sharedderrick.blogspot.tw/2012/06/t-sql-offset-fetch.html  
        Response.Write(SqlStr + "<br />");

        SqlCommand cmd1 = new SqlCommand(SqlStr, Conn);
        dr = cmd1.ExecuteReader();

        //== 第三，自由發揮 ======================
        //while (dr.Read())
        //{
            haveRec = true;

            GridView1.DataSource = dr;
            GridView1.DataBind();

        //}


        // == 第四，釋放資源、關閉資料庫的連結。
        cmd1.Cancel();
        dr.Close();
        Conn.Close();
        Conn.Dispose();



        if (haveRec)  // 以下區塊，是畫面下方的分頁功能---------------------------------------------------------
        {
            if (Pages > 0)
            {   //有傳來「頁數(p)」，而且頁數正確（大於零），出現<上一頁>、<下一頁>這些功能
                Label1.Text = "<div align='center'>";

                //** 可以把檔名刪除，只留下 ?P=  即可！一樣會運作，但IE 11會出現 JavaScript錯誤。**
                //** 抓到目前網頁的「檔名」。 System.IO.Path.GetFileName(Request.PhysicalPath) **

                if (p > 1)
                {   //======== 分頁功能（上一頁 / 下一頁）=========start===                
                    Label1.Text += "<a href='?p=" + (p - 1) + "'>[<<<上一頁]</a>";
                }
                Label1.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><a href='http://127.0.0.1/'>[首頁]</a></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                if (p < Pages)
                {
                    Label1.Text += "<a href='?p=" + (p + 1) + "'>[下一頁>>>]</a>";
                }   //======== 分頁功能（上一頁 / 下一頁）=========end====


                //==========================================================
                //========= MIS2000 Lab.自製的「每十頁」一間隔，分頁功能=========start====
                Label1.Text += "<hr width='97%' size=1>";

                int block_page = 0;
                block_page = p / 10;   //--只取除法的整數成果（商），若有餘數也不去管它。

                if (block_page > 0)
                {
                    Label1.Text += "<a href='?p=" + (((block_page - 1) * 10) + 9) + "'> [前十頁<<]  </a>&nbsp;&nbsp;";
                }

                for (int K = 0; K <= 10; K++)
                {
                    if ((block_page * 10 + K) <= Pages)
                    {   //--- Pages 資料的總頁數。共需「幾頁」來呈現所有資料？
                        if (((block_page * 10) + K) == p)
                        {   //--- p 就是「目前在第幾頁」
                            Label1.Text += "[<b>" + p + "</b>]" + "&nbsp;&nbsp;&nbsp;";
                        }
                        else
                        {
                            if (((block_page * 10) + K) != 0)
                            {
                                Label1.Text += "<a href='?p=" + (block_page * 10 + K) + "'>" + (block_page * 10 + K) + "</a>";
                                Label1.Text += "&nbsp;&nbsp;&nbsp;";
                            }
                        }
                    }
                }  //for迴圈 end

                if ((block_page < (Pages / 10)) & (Pages >= (((block_page + 1) * 10) + 1)))
                {
                    Label1.Text += "&nbsp;&nbsp;<a href='?p=" + ((block_page + 1) * 10 + 1) + "'>  [>>後十頁]  </a>";
                }
                Label1.Text += "</div>";
                //========= MIS2000 Lab.自製的「每十頁」一間隔，分頁功能=========end====
            }
        }
    }


    // IsNumeric Function，檢查是否為整數型態？ return true or false
    // 資料來源：http://support.microsoft.com/kb/329488/zh-tw
    static bool IsNumeric(object Expression)
    {
        // Variable to collect the Return value of the TryParse method.
        bool isNum;
        // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
        double retNum;
        // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
        // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
        isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

        return isNum;
    }

    //*********************************************************************************************

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DBInit();   //---只有[第一次]執行本程式，才會進入 if判別式內部。
            // 第一次執行本程式，請從「GridView 第一頁（0）」看起。
        }
    }


    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {   //==========================================================
        //----修改、更新
        //==========================================================
        //----因為前面有三個「功能鍵(編輯、選取、刪除)」，所以Cells[ ]從零算起，需扣掉前三個功能鍵與 id欄位。
        TextBox my_test_time, my_title, my_author;
        //先定義三個 TextBox物件！
        my_test_time = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];   // 抓到「Text控制項」。
        my_title = (TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0];
        my_author = (TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0];

        //=== DataReader的寫法 ==========================================
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
        Conn.Open();   //---- 這時候才連結DB
        
        //== (2). 執行SQL指令。或是查詢、撈取資料。
        SqlCommand cmd = new SqlCommand("update [test] set [test_time] = @test_time, [title] = @title, [author] = @author where [id] = @id", Conn);
        cmd.Parameters.AddWithValue("@test_time", Convert.ToDateTime(my_test_time.Text));
        cmd.Parameters.AddWithValue("@title", my_title.Text);
        cmd.Parameters.AddWithValue("@author", my_author.Text);

        cmd.Parameters.AddWithValue("@id", (int)GridView1.DataKeys[e.RowIndex].Value);
        //---- GridView1.DataKeys[e.RowIndex].Value 是指：「使用者點選的那一列」資料，所對應的資料表「主索引鍵（Primary Key）值」。

        //== (3). 自由發揮。
        int RecordsAffected = cmd.ExecuteNonQuery();
        //Response.Write("執行 Update的SQL指令以後，影響了" + RecordsAffected + "列的紀錄。)";

        //-- 或者是，您可以這樣寫，代表有更動到一些紀錄。
        //if (RecordsAffected > 0)  {
        //    Response.Write("資料更動成功。共有" + RecordsAffected + "列紀錄被影響。");
        // }

        //== (4). 釋放資源、關閉資料庫的連結。
        cmd.Cancel();

        if (Conn.State == ConnectionState.Open)   {
            Conn.Close();
            Conn.Dispose(); //---- 一開始宣告有用到 New的,最後必須以 .Dispose()結束
        }
        //==========================================================


        //----修改、更新完成！！離開「編輯」模式  ----
        GridView1.EditIndex = -1;
        DBInit();
    }


    //==============================================
    //== GridView的分頁，無法搭配 DataReader。所以要自己寫分頁！
    //== 可以參考作者另一篇文章  http://www.dotblogs.com.tw/mis2000lab/archive/2014/11/18/gridview_allowcustompaging_virtualitemcount.aspx
    //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{   //----分頁 Start----
    //    GridView1.PageIndex = e.NewPageIndex;
    //    DBInit();
    //}


    //==============================================
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {   //----編輯模式----
        GridView1.EditIndex = e.NewEditIndex;
        DBInit();
        //----畫面上的GridView，已經事先設定好「DataKeyName」屬性 = id ----
        //----所以編輯時，主索引鍵id 欄位會自動變成「唯讀」----
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {   //---離開「編輯」模式----
        GridView1.EditIndex = -1;
        DBInit();
    }


    //==============================================
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {   //======================================================
        //----刪除一筆資料
        //======================================================

        //=== DataReader的寫法 ==========================================
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
        Conn.Open();   //---- 這時候才連結DB

        //== (2). 執行SQL指令。
        SqlCommand cmd = new SqlCommand("delete from [test] where [id] = @id", Conn);
        cmd.Parameters.AddWithValue("@id",(int)GridView1.DataKeys[e.RowIndex].Value);
        //---- GridView1.DataKeys[e.RowIndex].Value 是指：「使用者點選的那一列」資料，所對應的資料表「主索引鍵（Primary Key）值」。

        //== (3). 自由發揮。
        int RecordsAffected = cmd.ExecuteNonQuery();
        //Response.Write("執行 Delete的SQL指令以後，影響了" + RecordsAffected + "列的紀錄。)";
        //-- 或者是，您可以這樣寫，代表有更動到一些紀錄。
        //if (RecordsAffected > 0)  {
        //    Response.Write("資料更動成功。共有" + RecordsAffected + "列紀錄被影響。");
        // }

        //== (4). 釋放資源、關閉資料庫的連結。
        cmd.Cancel();
        if (Conn.State == ConnectionState.Open)
        {
            Conn.Close();
            Conn.Dispose(); //---- 一開始宣告有用到 New的,最後必須以 .Dispose()結束
        }
        //==========================================================

        //----「刪除」已經完成！！記得重新整理畫面，重新載入資料----
        DBInit();
    }
}