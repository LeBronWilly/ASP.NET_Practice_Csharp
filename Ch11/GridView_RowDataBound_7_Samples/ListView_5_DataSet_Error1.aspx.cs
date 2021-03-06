using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//----自己寫的（宣告） NameSpace----
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
//----自己寫的（宣告） NameSpace----


public partial class Book_Sample_Ch12_ListView_ListView_5_DataSet_Error : System.Web.UI.Page
{
    protected void DBInit()   //--註解：這一段程式是自己手寫的。Dataset版。
    {
        //----連結資料庫---
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
        SqlDataAdapter myAdapter = new SqlDataAdapter("select top 10 * from test order by id DESC", Conn);
        DataSet ds = new DataSet();

        try
        {
            myAdapter.Fill(ds, "test");    //---- 這時候執行SQL指令。取出資料，放進 DataSet。

            ListView1.DataSource = ds;
            //----標準寫法 ListView1.DataSource = ds.Tables("test").DefaultView ----
            ListView1.DataBind();
        }
        catch (Exception ex)  //---- 如果程式有錯誤或是例外狀況，將執行這一段
        {
            Response.Write("<b>Error Message----  </b>" + ex.ToString() + "<HR/>");
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //--註解：只有第一次執行本程式，才會執行這一段。
            DBInit();
            Response.Write("<br><br>--==Page_Load事件，第一次觸發！==--" + DateTime.Now.ToLongTimeString());
        }
        else
        {
            Response.Write("<br><br>** Page_Load事件，第 N 次觸發！**" + DateTime.Now.ToLongTimeString());
        }
    }


    protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "my_Detail")
        {
            ListView1.SelectedIndex = -1;
            //--註解：「-1」代表離開「選取(Select)」按鈕的狀態！

            //DBInit();  //錯誤發生在這裡，去除「註解」就是正確的範例了。
        }
    }


    protected void ListView1_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
    {
        ListView1.SelectedIndex = e.NewSelectedIndex;
        //--註解：點選某一篇文章後可以看見這一篇文章的細部內容。

        //DBInit();  //錯誤發生在這裡，去除「註解」就是正確的範例了。
    }


    //****************************************************************
    //***  為了測試，加入這兩個事件，您可以發現 ItemCreated事件 比 Page_Load還早出現！
    protected void ListView1_ItemCreated(object sender, ListViewItemEventArgs e)
    {
        Response.Write("<br>ItemCreated事件--" + DateTime.Now.ToLongTimeString());
    }

    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        Response.Write("<br>ItemDataBound事件--" + DateTime.Now.ToLongTimeString());
    }


}