using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;  //*** Web Service 會用到 ***********************



public partial class CS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)  // 第一次執行
        {
            Repeater1.DataSource = GetCustomersData(1);   // 自己寫的副程式，從第一頁開始
            Repeater1.DataBind();
        }
    }

    // *** 自己寫的副程式 **************************（分頁）
    public static DataSet GetCustomersData(int pageIndex)
    {
        string query = "[GetCustomersPageWise]";   // 寫在DB裡面的預存程序
        SqlCommand cmd = new SqlCommand(query);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
        cmd.Parameters.AddWithValue("@PageSize", 10);
        cmd.Parameters.Add("@PageCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
        return GetData(cmd);   // 交給下面的副程式繼續運行
    }

    private static DataSet GetData(SqlCommand cmd)
    {
        string strConnString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(strConnString))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                cmd.Connection = conn;
                sda.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    sda.Fill(ds, "Customers");
                    
                    // 少了底下這一段，畫面只會出現20筆記錄（第一次十筆，第二次十筆，然後就停止了）
                    DataTable dt = new DataTable("PageCount");
                    dt.Columns.Add("PageCount");
                    dt.Rows.Add();
                    dt.Rows[0][0] = cmd.Parameters["@PageCount"].Value;
                    ds.Tables.Add(dt);

                    return ds;    // DataSet會自動關閉資料庫的連結
                }
            }
        }
    }

    //***************************************************************************
    [WebMethod]
    public static string GetCustomers(int pageIndex)
    {
        return GetCustomersData(pageIndex).GetXml();
    }


}