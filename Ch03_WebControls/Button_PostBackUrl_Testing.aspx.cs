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

public partial class Book_Sample_Ch03_WebControls_Button_PostBackUrl_Testing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        // 1. 如果這列程式被執行，表示有執行到Button_Click事件
        //Response.Redirect("www.yahoo.com.tw");


        // 2. 如果這筆記錄寫入DB，表示有執行到Button_Click事件
        //== (1). 開啟資料庫的連結。 (連結資料庫)
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
        Conn.Open();  
        //== (2). 執行SQL指令。或是查詢、撈取資料。
        string sqlstr = "Update test set title = '真珠草萃取物可以治療肝炎 韓國技轉錦鴻', test_time = getdate() where id =3";
        SqlCommand cmd = new SqlCommand(sqlstr, Conn);
        //== (3). 自由發揮。
        int RecordsAffected = cmd.ExecuteNonQuery();
        Label1.Text = "執行 Update的SQL指令以後，影響了" + RecordsAffected + "列的紀錄。";
        //-- 或者是，您可以這樣寫，代表有更動到一些紀錄。
        //if (RecordsAffected > 0)  {
        //    Response.Write("資料更動成功。共有" + RecordsAffected + "列紀錄被影響。");
        // }
        //== (4). 釋放資源、關閉資料庫的連結。
        cmd.Cancel();
        if (Conn.State == ConnectionState.Open)        {
            Conn.Close();
            Conn.Dispose(); 
        }

    }
}