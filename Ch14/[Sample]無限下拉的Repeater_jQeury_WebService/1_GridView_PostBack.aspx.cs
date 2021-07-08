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

public partial class Book_Sample_GridView_PostBack : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)  // 第一次執行
        {   
            GridView1.DataSource = MIS2000Lab_GetPageData(0);   // 自己寫的副程式，從第一頁開始
            GridView1.DataBind();
        }
    }


    // ***** 分頁。使用SQL指令進行分頁 *****
    // 請使用 public static
    protected DataSet MIS2000Lab_GetPageData(int currentPage)
    {
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);

        String SqlStr = "Select test_time, id, title from test Order By id ";
        SqlStr += " OFFSET " + (currentPage * GridView1.PageSize) + " ROWS FETCH NEXT " + GridView1.PageSize + " ROWS ONLY";
        //==SQL 2012 指令的 Offset...Fetch。參考資料： http://sharedderrick.blogspot.tw/2012/06/t-sql-offset-fetch.html  

        SqlDataAdapter myAdapter = new SqlDataAdapter(SqlStr, Conn);
        DataSet ds = new DataSet();
        myAdapter.Fill(ds, "test");

        return ds;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView GV = new GridView();
        GV.DataSource = MIS2000Lab_GetPageData(1);   // 自己寫的副程式，從第二頁開始
        GV.DataBind();
        Page.Form.Controls.Add(GV);

        Button BTN = new Button();
        BTN.Text = "按下去，繼續產生GridView";
        BTN.Click += new System.EventHandler(this.Button1_Click);   // 新加入的按鈕，按下去仍會執行 Button1_Click事件
        // 請參閱 https://dotblogs.com.tw/mis2000lab/archive/2011/11/05/eventhandler_addhandler_addressof_method.aspx
        Page.Form.Controls.Add(BTN);
    }


}