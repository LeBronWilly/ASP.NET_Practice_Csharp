﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//===============================
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;    //-- StringBuilder需要用到



public partial class Book_Sample_Ch14_Advanced_Page_10_mis2000lab_DataReader_TOP : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //=========   ASP.NET  DataReader 分頁程式 by MIS2000 Lab.   ==========        
        Boolean haveRec = false;

        //============  ADO.NET / DataReader==(Start)======
        //SqlConnection Conn = new SqlConnection("server=localhost; uid=test; pwd=test; database=test");
        SqlConnection Conn = new SqlConnection("Data Source=.\\SqlExpress;Initial Catalog=test;Integrated Security=True");
        //-- 「不需要」使用多重結果集（MARS） ;MultipleActiveResultSets=True
        Conn.Open();

        SqlCommand cmd = new SqlCommand("select count(id) from test", Conn);

        //SQL指令共撈到多少筆（列）紀錄。RecordCount紀錄總筆（列）數
        int RecordCount = (int)cmd.ExecuteScalar();
        cmd.Cancel();
        //============  ADO.NET / DataReader ==(End)======

        //每頁展示 5筆紀錄
        int PageSize = 5;


        // 如果撈不到紀錄，程式就結束。-- Start --------------
        if (RecordCount == 0)   {
            Response.Write("<h2>抱歉！無法找到您需要的紀錄！</h2>");
            Conn.Close();
            Response.End();
        }    // 如果撈不到紀錄，程式就結束。-- End ----------


        // Pages 紀錄的總頁數。搜尋到的所有紀錄，共需「幾頁」才能全部呈現？
        int Pages = ((RecordCount + PageSize) - 1) / (PageSize);    // 除法，取得「商」。

        Response.Write("<h3>搜尋資料庫:&nbsp;&nbsp; (共計" + RecordCount + "筆 / 共需" + Pages + "頁)</h3>");
        Response.Write("<hr width='97%' size='1'>");

        //  底下這一段IF判別式，是用來防呆，防止一些例外狀況。-- start --------------------------      
        int p = Convert.ToInt32(Request["p"]);          // p 就是「目前在第幾頁?」

        //  可以改寫成  if (String.IsNullOrEmpty(Request["p"].ToString()))  
        if (p.ToString() == null)
        {   // 有任何問題，就強制跳回第一頁（p=1）。
            p = 1;            // p 就是「目前在第幾頁?」
            Session["lastRecord"] = 0;  //上一頁 的 最後一筆記錄（ID，主索引鍵）
        }
        if (IsNumeric(Request["p"]) == false)     // 或是寫成 int.TryParse()方法來檢測是否為整數？
        {       // 有任何問題，就強制跳回第一頁（p=1）。
            p = 1;        // p 就是「目前在第幾頁?」
            Session["lastRecord"] = 0;  //上一頁 的 最後一筆記錄（ID，主索引鍵）
        }

        // 頁數（p）務必是一個整數。而且需要大於零、比起「資料的總頁數」要少
        if ((p != 0) && (p >= Pages))  {
            p = 1;        // p 就是「目前在第幾頁?」
            Session["lastRecord"] = 0;  //上一頁 的 最後一筆記錄（ID，主索引鍵）
        }
        //上面這一段IF辦別式，是用來防呆，防止一些例外狀況。-- end --------------------------


        //========================
        //== 組合SQL指令 ============= SQL 2000或是 Access的SQL指令
        SqlDataReader dr = null;
        //動態組合字串，會受到SQL Injection或是XSS攻擊。建議改用「@參數」的寫法
        //string SqlStr = "Select TOP " + PageSize + " * From test ";
        //SqlStr += " Where id > " + Session["lastRecord"].ToString() + " Order By id";
        //==SQL指令的 TOP。參考資料： https://msdn.microsoft.com/zh-tw/library/tx1c9c2f(v=vs.110).aspx

        //參數的寫法
        string SqlStr = "Select TOP " + PageSize + " * From test  Where id > @lastRecord Order By id";

        SqlCommand cmd1 = new SqlCommand(SqlStr, Conn);
        cmd1.Parameters.AddWithValue("@lastRecord", Session["lastRecord"].ToString());

        dr = cmd1.ExecuteReader();

        //== 第三，自由發揮 ======================
        StringBuilder html_sb = new StringBuilder();
        //-- StringBuilder的用法，請參考 http://msdn2.microsoft.com/zh-tw/library/system.text.stringbuilder(VS.80).aspx
        html_sb.Append("<table border=0 width='95%'>");

        while (dr.Read())
        {
            haveRec = true;

			// 以下是「資料呈現在畫面上」的HTML碼（註解掉的是舊版程式）
			//html = html + "<tr><td WIDTH='12%' valign=top><font size='2' color=#800000>★(" + DT.Rows[NowPageCount]["test_time"] + ")</font></td>";
			//html = html + "<td WIDTH='88%'><a href='/Ch09/Default_Disp.aspx?id=" + DT.Rows[NowPageCount]["id"] + "'><b>" + DT.Rows[NowPageCount]["title"] + "</b></a></td></tr>";
			//html = html + "<tr><td WIDTH='12%'></td><td WIDTH='88%'><font color='#666666' size='2'>" + DT.Rows[NowPageCount]["summary"] + "</font><br><br></td></tr>";
			//html = html + "<tr><td colspan='2' height='12'> </td></tr>";
			html_sb.Append("<tr><td WIDTH='12%' valign=top><font size='2' color=#800000>★(" + dr["test_time"] + ")</font></td>");
            html_sb.Append("<td WIDTH='88%'><a href='/Ch09/Default_Disp.aspx?id=" + dr["id"] + "'><b>" + dr["title"] + "</b></a></td></tr>");
            html_sb.Append("<tr><td WIDTH='12%'></td><td WIDTH='88%'><font color='#666666' size='2'>" + dr["summary"] + "</font><br><br></td></tr>");
            html_sb.Append("<tr><td colspan='2' height='12'> </td></tr>");

            Session["lastRecord"] = dr["id"].ToString(); ;   // 上一頁 的 最後一筆記錄（ID，主索引鍵）
        }
        html_sb.Append("</table>");

        // == 第四，釋放資源、關閉資料庫的連結。
        cmd1.Cancel();
            dr.Close();
            Conn.Close();
            Conn.Dispose();


        if (haveRec)  // 以下區塊，是畫面下方的分頁功能---------------------------------------------------------
        {
            //Response.Write(html);   //（註解掉的是舊版程式）
            Response.Write(html_sb.ToString());

            if (Pages > 0)
            {    //有傳來「頁數(p)」，而且頁數正確（大於零），出現<上一頁>、<下一頁>這些功能
                Response.Write("<div align='center'>");

                //** 可以把檔名刪除，只留下 ?P=  即可！一樣會運作，但IE 11會出現 JavaScript錯誤。**
                //** 抓到目前網頁的「檔名」。 System.IO.Path.GetFileName(Request.PhysicalPath) **

                if (p > 1)  {   //======== 分頁功能（上一頁 / 下一頁）=========start===                
                    Response.Write("<a href='Advanced_Page_10_mis2000lab_DataReader_TOP.aspx?p=" + (p - 1) + "'>[<<<上一頁]</a>");
                }
                Response.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><a href='http://127.0.0.1/'>[首頁]</a></b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                if (p < Pages)  {
                    Response.Write("<a href='Advanced_Page_10_mis2000lab_DataReader_TOP.aspx?p=" + (p + 1) + "'>[下一頁>>>]</a>");
                }                 //======== 分頁功能（上一頁 / 下一頁）=========end====


                //=======================================================
                //========= MIS2000 Lab.自製的「每十頁」一間隔，分頁功能=========start====
                Response.Write("<hr width='97%' size=1>");

                int block_page = 0;
                block_page = p / 10;   //--只取除法的整數成果（商），若有餘數也不去管它。

                if (block_page > 0)  {
                    Response.Write("<a href='Advanced_Page_10_mis2000lab_DataReader_TOP.aspx?p=" + (((block_page - 1) * 10) + 9) + "'> [前十頁<<]  </a>&nbsp;&nbsp;");
                }

                for (int K = 0; K <= 10; K++)
                {
                    if ((block_page * 10 + K) <= Pages)  {   //--- Pages 資料的總頁數。共需「幾頁」來呈現所有資料？
                        if (((block_page * 10) + K) == p)  {   //--- p 就是「目前在第幾頁」
                                  Response.Write("[<b>" + p + "</b>]" + "&nbsp;&nbsp;&nbsp;");
                        }
                        else  {
                            if (((block_page * 10) + K) != 0)  {
                                Response.Write("<a href='Advanced_Page_10_mis2000lab_DataReader_TOP.aspx?p=" + (block_page * 10 + K) + "'>" + (block_page * 10 + K) + "</a>");
                                Response.Write("&nbsp;&nbsp;&nbsp;");
                            }
                        }
                    }
                }  //for迴圈 end

                if ((block_page < (Pages / 10)) & (Pages >= (((block_page + 1) * 10) + 1)))  {
                    Response.Write("&nbsp;&nbsp;<a href='Advanced_Page_10_mis2000lab_DataReader_TOP.aspx?p=" + ((block_page + 1) * 10 + 1) + "'>  [>>後十頁]  </a>");
                }
                Response.Write("</div>");
                //========= MIS2000 Lab.自製的「每十頁」一間隔，分頁功能=========end====
            }
        }
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