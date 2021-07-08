using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//======================
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
//======================

public partial class Book_Sample_Ch14_Default_1_DataReader_BeginExecuteReader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //==第一，連結資料庫==
        //==連線字串最後，請加上 Asynchronous Processing=true
        //SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString.ToString);
            SqlConnection Conn = new SqlConnection("Data Source=.\\SqlExpress;Initial Catalog=test;Integrated Security=True;Asynchronous Processing=true");
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                Conn.Open();  //==DB連線

                //==第二，設定並執行SQL指令
                cmd = new SqlCommand("SELECT id, title FROM test", Conn);

                //*** 非同步（Async） ***
                IAsyncResult result = cmd.BeginExecuteReader();
                //int count;   //==這一段非必要
                //while (!result.IsCompleted)   {   //==以「輪詢」的方式，詢問狀態是否已經完成？
                //    count ++;
                //    Response.Write("<br>Waiting ..." + count);
                //}
                ////==IAsyncResult.IsCompleted 屬性     http://msdn.microsoft.com/zh-tw/library/system.iasyncresult.iscompleted.aspx
                ////==IAsyncResult.AsyncWaitHandle 屬性     http://msdn.microsoft.com/zh-tw/library/system.iasyncresult.asyncwaithandle.aspx

                dr = cmd.EndExecuteReader(result);

                //==第三，自由發揮，將資料呈現在畫面上==
                while (dr.Read())
                {
                    Response.Write("<hr />" + dr[0] + "<br />" + dr[1]);
                    //-- 用 . GetSqlxxx方法來擷取資料，效率會更好。
                }

                //---- 如果程式有錯誤或是例外狀況，將執行 catch這一段
            }
            catch (SqlException ex1)  {
                Response.Write("<br>SqlException :" + ex1.Number + " -- " + ex1.Message);
            }
            catch (InvalidOperationException ex2)  {
                Response.Write("<br>InvalidOperationException: " + ex2.Message);
            }
            catch (Exception ex3)  {
                Response.Write("<b>Exception --  </b>" + ex3.ToString() + "<HR/>");

            }
            finally
            {   //==第四，關閉資源＆資料庫的連線==
                //---- Always call Close when done reading.
                if ((dr != null))  {
                    cmd.Cancel();
                    //----關閉DataReader之前，一定要先「取消」SqlCommand
                    //參考資料： http://blog.darkthread.net/blogs/darkthreadtw/archive/2007/04/23/737.aspx
                    dr.Close();
                }
                //---- Close the connection when done with it.
                if ((Conn.State == ConnectionState.Open))  {
                    Conn.Close();
                    Conn.Dispose();
                    //---- 一開始宣告有用到 New的,最後必須以 .Dispose()結束
                }
            }
        

    }
}