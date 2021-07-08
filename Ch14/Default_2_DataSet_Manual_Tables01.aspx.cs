using System;
using System.Collections;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
//*********************************自己加寫（宣告）的NameSpace
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
//*********************************


public partial class Ch10_Default_2_DataSet_Manual : System.Web.UI.Page
{

    //==== 這一段程式很常被用到，所以獨立寫成一個 DBInit副程式。
    //==== 這樣會讓程式的可讀性提高！
    protected void DBInit()   //====自己手寫的程式碼， DataAdapter / DataSet ====(Start)
    {
        //上面已經事先寫好Using System.Web.Configuration; 
        //資料庫的連線字串，已經事先寫好，存放在 Web.Config檔案裡。
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);

        // 兩段SQL指令--Select，用分號（;）區隔
        SqlDataAdapter myAdapter = new SqlDataAdapter("Select top 10 id,test_time,title,author From test; Select top 10 * From test_talk; ", Conn);

        DataSet ds = new DataSet();

        try  //==== 以下程式，只放「執行期間」的指令！====
        {
            //----(1). 連結資料庫----
            //Conn.Open();  //---- 這一行註解掉，不用寫，DataAdapter會自動開啟

            //----(2). 執行SQL指令（Select陳述句）----
            myAdapter.Fill(ds);    // 執行SQL指令。取出資料，放進 DataSet。
            //---- DataSet是由許多 DataTable組成的。

            //----(3). 自由發揮。由 GridView來呈現資料。----
            GridView1.DataSource = ds.Tables[0];     //標準寫法 GridView1.DataSource = ds.Tables[0].DefaultView
            GridView1.DataBind();
            GridView2.DataSource = ds.Tables[1];
            GridView2.DataBind();

        }
        catch (Exception ex)      {
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
    //====自己手寫的程式碼， DataAdapter / DataSet ====(End)



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DBInit();   //---只有[第一次]執行本程式，才會進入 if判別式內部。
        }
    }
    
}
