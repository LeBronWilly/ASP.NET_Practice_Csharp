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
using System.Text;    //-- StringBuilder需要用到



public partial class Ch14_Advanced_Page_10_mis2000lab : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //=========   ASP.NET  DataSet 分頁程式 by MIS2000 Lab.   ==========        
        Boolean haveRec = false;

        //============  ADO.NET / DataSet ==(Start)======
        SqlConnection Conn = new SqlConnection("Data Source=.\\SQLExpress;Initial Catalog=test;Integrated Security=True");
        //Conn.Open();

        SqlDataAdapter da = new SqlDataAdapter("Select * From test Order by id", Conn);
        // 把所有紀錄通通撈出來，這是「假分頁」！瓶頸會卡在資料庫上！
        DataSet DS = new DataSet();
        da.Fill(DS);    // 把SQL指令執行完成的結果，填入DataSet裡面。

        DataTable DT = DS.Tables[0];   // 或是寫成 DataTable DT = DS.Tables["test"];
        //============  ADO.NET / DataSet ==(End)======

        //每頁展示 5筆紀錄
        int PageSize = 5;

        //SQL指令共撈到多少筆（列）紀錄。RecordCount 紀錄總筆（列）數
        int RecordCount = DT.Rows.Count;     // DataTable裡面共有幾列？幾筆記錄？

        //如果撈不到紀錄，程式就結束。-- Start --------------
        if (RecordCount == 0)   {
            Response.Write("<h2>抱歉！無法找到您需要的紀錄！</h2>");
            //Conn.Close();
            Response.End();
        }    //如果撈不到紀錄，程式就結束。-- End ----------

        //Pages 紀錄的總頁數。搜尋到的所有紀錄，共需「幾頁」才能全部呈現？
        int Pages = 0;
        //--方法A。
        //  Pages = ((RecordCount + PageSize) - 1) / (PageSize);    // 除法，取得「商」。

        //--方法B。
        if ((RecordCount % PageSize) > 0 )   {
            Pages = ((RecordCount / PageSize) + 1);   //-- ( / )除法。傳回整數
        }            
        else  {
            Pages = (RecordCount / PageSize);   //-- ( /)除法。傳回整數
        }



        #region  //  底下這一段IF判別式，是用來防呆，防止一些例外狀況。-- start --------------------              
        //---- 新的寫法（反向思考） ----
        int p;   // p 就是「目前在第幾頁?」

        //  可以改寫成  if (String.IsNullOrEmpty(Request["p"].ToString()))  
        if (Request["p"] == null)
        {
            p = 1; //有任何問題，就強制跳回第一頁（p=1）。
        }
        if (IsNumeric(Request["p"]) == false)
        {     // 或是寫成 int.TryParse()方法來檢測是否為整數？
            p = 1; //有任何問題，就強制跳回第一頁（p=1）。
        }
        else  {
            p = Convert.ToInt32(Request["p"]);
        }        

        if ((p <= 0) || (p > Pages))
        {   //頁數（p）務必是一個整數。而且需要大於零、比起「資料的總頁數」要少
            p = 1; //有任何問題，就強制跳回第一頁（p=1）。
        }
       #endregion  //上面這一段 if判別式，是用來防呆，防止一些例外狀況。-- end --------------------

        //  NowPageCount，目前這頁的紀錄，要從 DataSet裡面的第幾筆（列）開始撈資料？？
        int NowPageCount = 0;
        if (p > 0)   {
            NowPageCount = (p - 1) * PageSize;    // PageSize，每頁展示5筆紀錄（上面設定過了）
        }
        Response.Write("<h3>搜尋資料庫:&nbsp;&nbsp; (共計" + RecordCount + "筆 / 共需" + Pages + "頁)</h3>");
        Response.Write("<hr width='97%' size='1'>");


        #region   // 畫面呈現一個表格（資料展示）---------------------------(start)
        //rowNo，目前畫面出現的這一頁，要撈出幾筆（列）紀錄
        int rowNo = 0;

        // ---- 舊的寫法 ----
        //string html = null;
        //Response.Write("<table border=0 width='95%'>");

        // ---- 新的寫法 (StringBuilder，記得搭配 System.Text命名空間) ----
        StringBuilder html_sb = new StringBuilder();
        //-- StringBuilder的用法，請參考 http://msdn2.microsoft.com/zh-tw/library/system.text.stringbuilder(VS.80).aspx
        html_sb.Append("<table border=0 width='95%'>");

        while ((rowNo < PageSize) & (NowPageCount < RecordCount))   {
            haveRec = true;

            // ---- 舊的寫法 ---- // 以下是「資料呈現在畫面上」的HTML碼（註解掉的是舊版程式）
            //html = html + "<tr><td WIDTH='12%' valign=top><font size='2' color=#800000>★(" + DT.Rows[NowPageCount]["test_time"] + ")</font></td>";
            //html += "<td WIDTH='88%'><a href='/Ch09/Default_Disp.aspx?id=" + DT.Rows[NowPageCount]["id"] + "'><b>" + DT.Rows[NowPageCount]["title"] + "</b></a></td></tr>";
            //html += "<tr><td WIDTH='12%'></td><td WIDTH='88%'><font color='#666666' size='2'>" + DT.Rows[NowPageCount]["summary"] + "</font><br><br></td></tr>";
            //html += "<tr><td colspan='2' height='12'> </td></tr>";

            // ---- 新的寫法 (StringBuilder，記得搭配 System.Text命名空間) ----
            html_sb.Append("<tr><td WIDTH='12%' valign=top><font size='2' color=#800000>★(" + string.Format("{0:yyyy/MM/dd}", DT.Rows[NowPageCount]["test_time"]) + ")</font></td>");
            html_sb.Append("<td WIDTH='88%'><a href='/Ch09/Default_Disp.aspx?id=" + DT.Rows[NowPageCount]["id"] + "'><b>" + DT.Rows[NowPageCount]["title"] + "</b></a></td></tr>");
            html_sb.Append("<tr><td WIDTH='12%'></td><td WIDTH='88%'><font color='#666666' size='2'>" + DT.Rows[NowPageCount]["summary"] + "</font><br><br></td></tr>");
            html_sb.Append("<tr><td colspan='2' height='12'> </td></tr>");

            NowPageCount = (NowPageCount + 1);
            rowNo = (rowNo + 1);
        }
        // ---- 舊的寫法 ----
        //html = html + "</table>";   //（註解掉的是舊版程式）

        // ---- 新的寫法 (StringBuilder，記得搭配 System.Text命名空間) ----
        html_sb.Append("</table>");
        #endregion   // 畫面呈現一個表格（資料展示）---------------------------(end)



        #region  // 以下區塊，是畫面下方的分頁功能---------------------------------------------------------(start)
        if (haveRec)   {   
            // ---- 舊的寫法 ----
            //Response.Write(html);   //（註解掉的是舊版程式）

            // ---- 新的寫法 (StringBuilder，記得搭配 System.Text命名空間) ----
            Response.Write(html_sb.ToString()); 


            //** 可以把檔名刪除，只留下 ?P=  即可！一樣會運作，但IE 11會出現 JavaScript錯誤。**
            //** 抓到目前網頁的「檔名」。 System.IO.Path.GetFileName(Request.PhysicalPath) **

            if (Pages > 0)   {
                //有傳來「頁數(p)」，而且頁數正確（大於零），出現<上一頁>、<下一頁>這些功能
                Response.Write("<div align='center'>");

                if (p > 1)   {  //======== 分頁功能（上一頁 / 下一頁）=========start===
                    Response.Write("<a href='advanced_page_10_mis2000lab.aspx?p=" + (p - 1) + "'>[<<<上一頁]</a>");
                }
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><a href='http://127.0.0.1/'>[首頁]</a></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                if (p < Pages)   {
                    Response.Write("<a href='advanced_page_10_mis2000lab.aspx?p=" + (p + 1) + "'>[下一頁>>>]</a>");
                }                   //======== 分頁功能（上一頁 / 下一頁）=========end====

                
                //==========================================================
                //========= MIS2000 Lab.自製的「每十頁」一間隔，分頁功能=========start====
                Response.Write("<hr width='97%' size=1>");

                int block_page = 0;
                block_page = p / 10;   //--只取除法的整數成果（商），若有餘數也不去管它。

                if (block_page > 0)   {
                    Response.Write("<a href='advanced_page_10_mis2000lab.aspx?p=" + (((block_page - 1) * 10) + 9) + "'> [前十頁<<]  </a>&nbsp;&nbsp;");
                }

                for (int K = 0; K <= 10; K++)   {
                    if ((block_page * 10 + K) <= Pages)   //--- Pages 資料的總頁數。共需「幾頁」來呈現所有資料？
                    {
                        if (((block_page * 10) + K) == p)   //--- p 就是「目前在第幾頁」
                        {
                            Response.Write("[<b>" + p + "</b>]" + "&nbsp;&nbsp;&nbsp;");   }
                        else   {
                            if (((block_page * 10) + K) != 0)   {
                                Response.Write("<a href='advanced_page_10_mis2000lab.aspx?p=" + (block_page * 10 + K) + "'>" + (block_page * 10 + K) + "</a>");
                                Response.Write("&nbsp;&nbsp;&nbsp;");   
                            }
                        }                            
                    }
                }  //for迴圈 end

                if ((block_page < (Pages / 10)) & (Pages >= (((block_page+1)*10) + 1)))   {
                    Response.Write("&nbsp;&nbsp;<a href='advanced_page_10_mis2000lab.aspx?p=" + ((block_page + 1) * 10 + 1) + "'>  [>>後十頁]  </a>");
                }
                Response.Write("</div>");
                //========= MIS2000 Lab.自製的「每十頁」一間隔，分頁功能=========end====
            }
        }
        #endregion  // 以上區塊，是畫面下方的分頁功能---------------------------------------------------------(end)
    }



    // IsNumeric Function，檢查是否為整數型態？ return true or false
    // 資料來源：http://support.microsoft.com/kb/329488/zh-tw
    static bool IsNumeric(object Expression)
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
