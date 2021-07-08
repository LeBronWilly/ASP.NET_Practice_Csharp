using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
//=================
using System.Data.SqlClient;


public partial class Ch14_Advanced_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //=========   ASP.NET  DataSet 分頁程式 by MIS2000 Lab.   ==========        
        Boolean haveRec = false;

        #region  // SQL指令共撈到多少筆（列）資料。RecordCount資料總筆（列）數
        //============  ADO.NET / DataSet ==(Start)======
        // 第一，連結資料庫
        SqlConnection Conn = new SqlConnection("Data Source=.\\SqlExpress;Initial Catalog=test;Integrated Security=True");
        //Conn.Open();

        SqlDataAdapter da = new SqlDataAdapter("select * from test order by id", Conn);
        DataSet DS = new DataSet();
        da.Fill(DS, "test");    // 把SQL指令執行完成的結果，填入DataSet裡面。

        DataTable DT = DS.Tables[0];   // 或是寫成 DataTable DT = DS.Tables["test"];

        // SQL指令共撈到多少筆（列）資料。RecordCount資料總筆（列）數
        int RecordCount = DT.Rows.Count;    // DataTable裡面共有幾列？幾筆記錄？

        // 如果撈不到資料，程式就結束。-- Start --------------
        if (RecordCount == 0)
        {
            Response.Write("<h2>抱歉！無法找到您需要的資料！</h2>");
            // Conn.Close();
            Response.End();
        }    // 如果撈不到資料，程式就結束。-- End ----------
        //============  ADO.NET / DataSet ==(End)======
        #endregion

        // 每頁展示 5筆資料
        int PageSize = 5;



        //Pages 紀錄的總頁數。搜尋到的所有紀錄，共需「幾頁」才能全部呈現？
        int Pages = 0;
        //--方法A。
        //  Pages = ((RecordCount + PageSize) - 1) / (PageSize);    // 除法，取得「商」。

        //--方法B。
        if ((RecordCount % PageSize) > 0)
        {
            Pages = ((RecordCount / PageSize) + 1);   //-- ( / )除法。傳回整數
        }
        else
        {
            Pages = (RecordCount / PageSize);   //-- ( /)除法。傳回整數
        }

        Response.Write("<h3>搜尋資料庫:&nbsp;&nbsp; (共計" + RecordCount + "筆 / 共需" + Pages + "頁)</h3>");
        Response.Write("<hr width='97%' size='1'>");


        #region  //  底下這一段 if判別式，是用來防呆，防止一些例外狀況。-- start ---------------------------------              
        int p;   // p 就是「目前在第幾頁?」

        //---- 新的寫法  ----  自己寫一個函數檢查頁數是否有例外狀況？
        p = ValidatePageNumber(Pages);

        ////---- 舊的寫法 (3) ----
        ////  可以改寫成  if (String.IsNullOrEmpty(Request["p"].ToString()))  
        //if ((Request["p"] == null) || (IsNumeric(Request["p"]) == false))
        //{
        //    p = 1; // 有任何問題，就強制跳回第一頁（p=1）。
        //}        
        //else  {
        //    p = Convert.ToInt32(Request["p"]);
        //}

        //if ((p <= 0) || (p > Pages))
        //{   // 頁數（p）務必是一個整數。而且需要大於零、比起「資料的總頁數」要少
        //    p = 1; // 有任何問題，就強制跳回第一頁（p=1）。
        //}    


        ////---- 舊的寫法 (2) ---- 反向思考
        ////  可以改寫成  if (String.IsNullOrEmpty(Request["p"].ToString()))  
        //if (Request["p"] == null)  {
        //    p = 1; // 有任何問題，就強制跳回第一頁（p=1）。
        //}

        //if (IsNumeric(Request["p"]) == false)
        //{     // 或是寫成 int.TryParse()方法來檢測是否為整數？
        //    p = 1; // 有任何問題，就強制跳回第一頁（p=1）。
        //}
        //else  {
        //    p = Convert.ToInt32(Request["p"]);
        //}

        //if ((p <= 0) || (p > Pages))
        //{   // 頁數（p）務必是一個整數。而且需要大於零、比起「資料的總頁數」要少
        //    p = 1; // 有任何問題，就強制跳回第一頁（p=1）。
        //}       


        ////---- 舊的寫法 (1) ----
        //int p = Convert.ToInt32(Request["p"]);   // p 就是「目前在第幾頁?」

        ////  可以改寫成  if (String.IsNullOrEmpty(Request["p"].ToString()))  
        //if (Request["p"] == null)   {
        //    p = 1;
        //}
        //else  {
        //    if (IsNumeric(Request["p"]))     // 或是寫成 int.TryParse()方法來檢測是否為整數？
        //    {   // 有任何問題，就強制跳回第一頁（p=1）。
        //        // 頁數（p）務必是一個整數。而且需要大於零、比起「資料的總頁數」要少
        //        if ((p > 0) && (p <= Pages))   {
        //            p = Convert.ToInt32(Request["p"]);
        //        }
        //        else  {
        //            p = 1;
        //        }
        //    }
        //    else  {
        //        p = 1;
        //    }
        //}
        #endregion  //上面這一段 if判別式，是用來防呆，防止一些例外狀況。-- end ---------------------------------



        //NowPageCount，目前這頁的資料，要從 DataSet裡面 DataTable的 第幾筆（列）開始撈資料？？
        int NowPageCount = NowPageCount = (p - 1) * PageSize;    //PageSize，每頁展示5筆資料（上面設定過了）

        ////---- 舊的寫法 ---- 如果您 100%確定頁數(p)不會有例外狀況，上面的檢驗都已排除，下面的 IF 可以取消
        //int NowPageCount = 0;
        //if (p > 0)    {
        //    NowPageCount = (p - 1) * PageSize;    //PageSize，每頁展示5筆資料（上面設定過了）
        //}


        #region   // 畫面呈現一個表格（資料展示）---------------------------(start)
        //rowNo，目前畫面出現的這一頁，要撈出幾筆（列）資料
        int rowNo = 0;

        string html = null;
        Response.Write("<table border=0 width='95%'>");

        while ((rowNo < PageSize) & (NowPageCount < RecordCount))
        {
            haveRec = true;

            // 以下是「資料呈現在畫面上」的HTML碼
            // 這一小段程式，也不完美。下一個範例將會用 StringBuilder來改善之。
            html = html + "<tr><td WIDTH='12%' valign=top><font size='2' color=#800000>★(" + DT.Rows[NowPageCount]["test_time"] + ")</font></td>";
            html += "<td WIDTH='88%'><a href='/Ch09/Default_Disp.aspx?id=" + DT.Rows[NowPageCount]["id"] + "'><b>" + DT.Rows[NowPageCount]["title"] + "</b></a></td></tr>";
            html += "<tr><td WIDTH='12%'></td><td WIDTH='88%'><br><font color='#666666' size='2'>" + DT.Rows[NowPageCount]["summary"] + "</font><br><br></td></tr>";
            html += "<tr><td colspan='2' height='12'> </td></tr>";

            NowPageCount = (NowPageCount + 1);
            rowNo = (rowNo + 1);
        }
        Response.Write("</table>");
        #endregion   // 畫面呈現一個表格（資料展示）---------------------------(end)

        #region        // 以下區塊，是畫面下方的「分頁」功能---------------------------------------------------------(start)
        if (haveRec)  
        {
            Response.Write(html);

            //** 可以把檔名刪除，只留下 ?P=  即可！一樣會運作，但IE 11會出現 JavaScript錯誤。**
            //** 抓到目前網頁的「檔名」。 System.IO.Path.GetFileName(Request.PhysicalPath) **

            if (Pages > 0)            {
                //有傳來「頁數(p)」，而且頁數正確（大於零），出現<上一頁>、<下一頁>這些功能
                Response.Write("<div align='center'>");

                if (p > 1)   //======== 分頁功能（上一頁 / 下一頁）=========start===
                {
                    Response.Write("<a href='advanced_page.aspx?p=" + (p - 1) + "'>[<<<上一頁]</a>");
                }
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><a href='http://127.0.0.1/'>[首頁]</a></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                if (p < Pages)
                {
                    Response.Write("<a href='advanced_page.aspx?p=" + (p + 1) + "'>[下一頁>>>]</a>");
                }             //======== 分頁功能（上一頁 / 下一頁）=========end====

                
                //======== 分頁功能（列出 所有頁數）=========start====
                Response.Write("<hr width='97%' size=1>");
                for (int i = 1; i <= Pages; i++)   //Pages 資料的總頁數
                {
                    if (p == i)   {
                        Response.Write("[" + p + "]&nbsp;&nbsp;");
                        // 畫面目前所在的頁數，沒有超連結，以 [ ]符號來註明。
                    }
                    else  {
                        Response.Write("<a href='advanced_page.aspx?p=" + i + "'>" + i + "</a>&nbsp;&nbsp;");
                        // 列出每一頁的頁數，而且可以超連結。
                    }
                }
                //======== 分頁功能（列出所有頁數）=========end====
                Response.Write("</div>");  
            }
            #endregion  // 以上區塊，是畫面下方的分頁功能---------------------------------------------------------(end)

        }

    }


    // 驗證頁數（p）是否為整數？有輸入值？介於 1 ~ 最大頁數之間？
    protected int ValidatePageNumber(int Pages)
    {
        //  可以改寫成  if (String.IsNullOrEmpty(Request["p"].ToString()))  
        if ((Request["p"] == null) || (IsNumeric(Request["p"]) == false))
        {
            return 1;  //有任何問題，就強制跳回第一頁（p=1）。
        }

        if ((Convert.ToInt32(Request["p"]) <= 0) || (Convert.ToInt32(Request["p"]) > Pages))
        {   //頁數（p）務必是一個整數。而且需要大於零、比起「資料的總頁數」要少
            return 1;  //有任何問題，就強制跳回第一頁（p=1）。
        }
                
        return Convert.ToInt32(Request["p"]);
    }


    // IsNumeric Function，檢查是否為整數型態？ return true or false
    // 資料來源：http://support.microsoft.com/kb/329488/zh-tw
    protected bool IsNumeric(object Expression)
    {   // Variable to collect the Return value of the TryParse method.
        bool isNum;

        // Define variable to collect out parameter of the TryParse method. If the conversion fails, the out parameter is zero.
        double retNum;

        // The TryParse method converts a string in a specified style and culture-specific format to its double-precision floating point number equivalent.
        // The TryParse method does not generate an exception if the conversion fails. If the conversion passes, True is returned. If it does not, False is returned.
        isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

        return isNum;
    }

}
