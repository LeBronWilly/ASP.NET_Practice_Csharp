using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CS_10_Multi_Upload_Only45 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //--註解：網站上的目錄路徑。所以不寫磁碟名稱（不寫 “實體”路徑）。
        //--           上傳後的存檔目錄，請依照您的環境作修改。
        String saveDir= @"Book_Sample\Ch18_FileUpload\Uploads\";
        //-- 或是寫成  String saveDir= "Book_Sample\\Ch18_FileUpload\\Uploads\\";

        String appPath = Request.PhysicalApplicationPath;
        // appPath會列出網站（專案）的目錄路徑。例如： C:\Users\xxx\Documents\Visual Studio 201x\WebSites\網站名稱  

        System.Text.StringBuilder SB = new System.Text.StringBuilder();

        //===========================================
        //== Ony .NET 4.5有這個新的 AllowMultiPle屬性
        //===========================================

        String fileName, savePath;
        foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
        {
            //-- 修正版。  不用擔心瀏覽器版本不同，導致「檔名」的結果不同。
            fileName = ExtractFilename(postedFile.FileName);
            ////--  FileUpload1.PostedFile.FileName無法只抓到「檔名」，卻抓到「Client端的完整路徑＋檔名」
            ////--  因而出現錯誤，無法上傳檔案。錯誤訊息為「不支援指定的路徑格式」。
            ////--  只有微軟 IE11 / Edge瀏覽器這樣。Chrome / FireFox只抓到「檔名」，無路徑。關於此錯誤，請參閱範例 10_FileName_HttpPostedFile.aspx

            savePath = appPath + saveDir + fileName;
            SB.Append("<hr>檔名---- " + fileName);   // -- 請注意看最後的「檔案名稱」，是否出現問題？？

            //===========================================
            //-- 您可以將下面這一列註解掉，不執行。就能看見結果。
            postedFile.SaveAs(savePath);   //-- 完成檔案上傳。
            //===========================================            
        }

        Label1.Text = "上傳成功 -- " + SB.ToString();
    }


    //================================================================
    // 微軟MSDN網站寫好的。請參閱範例 10_MSDN_ExtractFilename.aspx
    // 改寫自 https://msdn.microsoft.com/zh-tw/library/0w96zd3d(v=vs.110).aspx
    public static string ExtractFilename(string filepath)
    {
        // If path ends with a "\", it's a path only so return String.Empty.
        if (filepath.Trim().EndsWith(@"\"))
            return String.Empty;

        // Determine where last backslash is.
        int position = filepath.LastIndexOf('\\');

        // 如果都沒有反斜線，那麼就是 (1)只有路徑（無檔名）、(2)只有檔名。
        if (position == -1)
        {    // 預防：只抓到「檔名」。
            if (filepath.IndexOf(".") >= 0)
                return filepath;
            else
                return String.Empty;
        }
        else
        {
            return filepath.Substring(position + 1);
        }
    }


}