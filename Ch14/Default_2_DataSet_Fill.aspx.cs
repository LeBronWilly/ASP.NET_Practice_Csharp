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
//*********************************


public partial class Book_Sample_Ch14_Default_2_DataSet_Fill : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //上面已經事先寫好Using System.Web.Configuration; 
        //資料庫的連線字串，已經事先寫好，存放在 Web.Config檔案裡。
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
        SqlDataAdapter myAdapter = new SqlDataAdapter("Select top 10 id,test_time,title,author From test; Select top 10 * from test_talk", Conn);

        DataSet ds = new DataSet();

        try  //==== 以下程式，只放「執行期間」的指令！====
        {
            //----(1). 連結資料庫----
            //Conn.Open();  //---- 這一行註解掉，不用寫，DataAdapter會自動開啟

            //// == 寫法一，正常運作 =============================
            ////----(2). 執行SQL指令（Select陳述句）----
            //myAdapter.Fill(ds);    //這時候執行SQL指令。取出資料，放進 DataSet。

            ////----(3). 自由發揮。由 GridView來呈現資料。----
            //GridView1.DataSource = ds.Tables[0].DefaultView;     //標準寫法
            //GridView1.DataBind();

            //GridView2.DataSource = ds.Tables[1].DefaultView;     //標準寫法
            //GridView2.DataBind();

            // == 寫法二，正常運作 =============================
            myAdapter.Fill(ds, "test");    //這時候執行SQL指令。取出資料，放進 DataSet。
            myAdapter.Fill(ds, "test_talk");    //這時候執行SQL指令。取出資料，放進 DataSet。

            GridView1.DataSource = ds.Tables["test"].DefaultView;     //標準寫法
            GridView1.DataBind();

            GridView2.DataSource = ds.Tables["test_talk"].DefaultView;     //標準寫法
            GridView2.DataBind();

            //---- 最後，不用寫 Conn.Close()，因為DataAdapter會自動關閉
        }
        catch (Exception ex)
        {
            Response.Write("<hr /> Exception Error Message----  " + ex.ToString());
        }
        //finally
        //{   
        //----(4). 釋放資源、關閉連結資料庫----
        //---- 不用寫，DataAdapter會自動關閉
        //    if (Conn.State == ConnectionState.Open)  {
        //          Conn.Close();
        //          Conn.Dispose();
        //    }  //使用SqlDataAdapter的時候，不需要寫程式去控制Conn.Open()與 Conn.Close()。
        //}
    }
}