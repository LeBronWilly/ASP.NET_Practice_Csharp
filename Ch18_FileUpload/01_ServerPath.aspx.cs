using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Ch18_FileUpload_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //*********************************************************************
        //*** 方法一 *****
        //-- 註解：先設定好檔案上傳的路徑，這是Web Server電腦上的硬碟「實體」目錄。
        //       C#語法在撰寫磁碟的目錄位置時，請留意以下的寫法：
        //string savePath = "d:\\temp\\uploads\\";
        //      或是寫成  string savePath = @"d:\temp\uploads\";

        //*** 方法二 *****
        //--網站上的 URL路徑。 Server.MapPath() 轉換成Web Server電腦上的硬碟「實體」目錄。
        string savePath = Server.MapPath("Uploads/");   // 後面的「反斜線」，千萬不要忘記！

        //*** 方法三 *****
        //--註解：網站上的目錄路徑。所以不寫磁碟名稱（不寫 “實體”路徑）。
        //--以下的 URL路徑，請依照實際狀況，進行修改。否則程式會報錯！

        //string appPath  = Request.PhysicalApplicationPath;
        ////-- appPath是網站 "根"目錄「轉換成」Server端硬碟路徑。
        ////-- appPath會列出網站（專案）的目錄路徑。例如： C:\Users\xxx\Documents\Visual Studio 201x\WebSites\網站名稱
        
        //string saveDir = "Ch18_FileUpload\\Uploads\\";    // 或是寫成 string saveDir = @"Ch18_FileUpload\Uploads\"; 
        ////-- 路徑的一開始「不可」寫「\\」，否則存檔時，會出現兩個 「\\」符號
        ////-- 此問題可以透過 Path.Combine()方法解決。

        ////--  下一個範例 ( 01_ServerPath2_Request ) 會展示 Request的各種路徑寫法
        //string savePath   = appPath + saveDir;
        //*********************************************************************

        if (FileUpload1.HasFile) 
        {
            string fileName = FileUpload1.FileName;  //-- User上傳的完整檔名（不包含 Client端的路徑！）

            //string saveResult = savePath + fileName;
            string saveResult = System.IO.Path.Combine(savePath, fileName);

            //-- 重點！！必須包含 Server端的「目錄」與「檔名」，才能使用 .SaveAs()方法！
            FileUpload1.SaveAs(saveResult);

            Label1.Text = "<b>上傳成功</b>，檔名---- " + fileName;
            Label1.Text += "<br />路徑檔名---- " + savePath;
        }
        else  {
            Label1.Text = "請先挑選檔案之後，再來上傳";
        }

        //另外一種寫法，可以參考 http://jengting.blogspot.tw/2014/10/fileupload.html
    }
}
