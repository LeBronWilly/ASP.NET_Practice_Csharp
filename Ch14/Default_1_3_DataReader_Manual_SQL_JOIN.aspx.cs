using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

//----自己寫的----
using System.Web.Configuration;
using System.Data.SqlClient;
//----自己寫的----

public partial class Ch14_Default_1_3_DataReader_SQL_JOIN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //----上面已經事先寫好NameSpace --  Using System.Web.Configuration; ----     
        //----或是寫成下面這一行 (連結資料庫)----
        SqlConnection Conn = new SqlConnection("Data Source=.\\SqlExpress;Initial Catalog=test;Integrated Security=True");
        //---- 本範例「不」用 多重結果集（MARS）  ;MultipleActiveResultSets=True

        SqlDataReader dr = null;
        SqlCommand cmd = new SqlCommand("Select A.id, A.title, B.test_id, B.article From test A, test_talk B Where A.id = B.test_id Order by A.id", Conn);
        //----使用SQL指令的 JOIN

        try     //==== 以下程式，只放「執行期間」的指令！=====================
        {
            Conn.Open();   //---- 這時候才連結DB
            dr = cmd.ExecuteReader();   //---- 這時候執行SQL指令，取出資料

            int TableID = 0;

            if (dr.HasRows)
            {
                while (dr.Read())   //====列出test資料表的每一篇新聞====
                {
                    // （test資料表）文章、新聞若有重複的部分，只列出一次即可。
                    if (TableID != Convert.ToInt32(dr["id"]))
                    {
                        Response.Write("<p>" + dr["id"] + "  /  <b>" + dr["title"] + "</b></p>");
                    }

                    //====列出每一篇新聞的「讀者留言（test_talk資料表）」====
                    Response.Write("<blockquote><font size=2 color=gray>");
                    Response.Write("==讀者留言==<br>");
                    Response.Write(dr["test_id"] + "  /  " + dr["article"] + "<br>");
                    Response.Write("</font></blockquote>");

                    TableID = Convert.ToInt32(dr["id"]);
                } 
            }
        }
        catch (Exception ex)
        {  //---- 如果程式有錯誤或是例外狀況，將執行這一段
            Response.Write("<b>Error Message----  </b>" + ex.ToString() + "<HR/>");
        }
        finally
        {   //---- Always call Close when done reading.
            if (dr != null)   {
                cmd.Cancel();
                //----關閉DataReader之前，一定要先「取消」SqlCommand
                dr.Close();
            }

            //---- Close the connection when done with it.
            if (Conn.State == ConnectionState.Open)   {
                Conn.Close();
                Conn.Dispose(); //---- 一開始宣告有用到 New的,最後必須以 .Dispose()結束
            }
        }

//== 註解： =======================================
//本程式運用到幾個很簡單的HTML碼，稍作說明。
//	<p>…</p> 區分段落
//	<b>…</b> 粗體字
//	<font>…</font> 控制字體的大小、顏色等等。
//	<blockquote>…</blockquote> 段落向內縮排
//	<br /> 換行
//	<hr /> 在畫面上，畫一條水平線。

    }
}
