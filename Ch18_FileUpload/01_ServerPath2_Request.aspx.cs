using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch18_FileUpload_01_ServerPath2_Request : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 資料來源：https://dotblogs.com.tw/atowngit/archive/2009/08/23/10198.aspx 
        //**********************************************************************************


        //傳回傳遞給方法之虛擬路徑的完整實體路徑
        //傳遞給 MapPath 方法的路徑必須是應用程式的相對路徑，而不是絕對路徑。
        Response.Write("Server.MapPath(\"~\") 「根」路徑 :<font color=blue> " + Server.MapPath("~") + "</font><br />");

        //抓取 ASP.NET 網頁程式，所在的目錄
        Response.Write("Server.MapPath(\".\") :<font color=blue> " + Server.MapPath(".") + "</font><br /><br /><br />");

        //**********************************************************************************
        //取得 asp.net 應用程式在伺服器上虛擬應用程式 "根"路徑
        Response.Write("Request.ApplicationPath（虛擬應用程式「根」路徑） :<font color=red> " + Request.ApplicationPath + "</font><br /><br><br>");

        //取得目前要求的虛擬路徑
        Response.Write("Request.CurrentExecutionFilePath（包含檔名） : <font color=red>" + Request.CurrentExecutionFilePath + "</font><br />");

        //取得目前要求的虛擬路徑，與 CurrentExecutionFilePath 屬性不同，FilePath 並不會反映伺服器端的傳輸。
        Response.Write("Request.FilePath（包含檔名） :<font color=red> " + Request.FilePath + "</font><br />");

        //取得目前要求的虛擬路徑
        Response.Write("Request.Path（包含檔名） : <font color=red>" + Request.Path + "</font><br /><br /><br />");

        //**********************************************************************************
        //取得目前執行應用程式之根目錄的實體檔案系統路徑
        Response.Write("Request.PhysicalApplicationPath : <font color=red>" + Request.PhysicalApplicationPath + "</font><br /><br><br>");

        //取得與要求的 URL 對應之實體檔案系統路徑
        Response.Write("Request.PhysicalPath （包含檔名）:<font color=red> " + Request.PhysicalPath + "</font><br />");

    }
}