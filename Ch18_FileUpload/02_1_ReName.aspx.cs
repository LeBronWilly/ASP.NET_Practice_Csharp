using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;  //註解：事先宣告System.IO這個 NameSpace！


public partial class Book_Sample_Ch18_FileUpload_02 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {  //參考資料：http://msdn.microsoft.com/zh-tw/library/system.web.ui.webcontrols.fileupload.saveas.aspx
        //註解：先設定好檔案上傳的路徑，這是Web Server電腦上的硬碟「實際」目錄。
        string savePath = "d:\\temp\\uploads\\";

        if (FileUpload1.HasFile)
        {
            //==================================================(Start)
            string fileName = FileUpload1.FileName;  //-- User上傳的完整檔名（不包含 Client端的路徑！）
            // 想抓到「主檔名」，請寫成 System.IO.Path.GetFileNameWithoutExtension(fileName);
            // 想抓到「副檔名」，請寫成 System.IO.Path.GetExtension(fileName);

            string pathToCheck = Path.Combine(savePath, fileName);   // --新的路徑與檔名，透過迴圈繼續檢查檔名是否有重複？
            string tempfileName = "";

            if (System.IO.File.Exists(pathToCheck))
            {
                int my_counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {    //路徑與檔名都相同的話，目前上傳的檔名（改成 tempfileName），主檔名 "前面" 用數字代替。
                    tempfileName = my_counter.ToString() + "_" + fileName;   // 修正後的「新檔名」
                    // ************************************************************************************

                    pathToCheck = Path.Combine(savePath, tempfileName);   // --路徑 與 新檔名，透過迴圈繼續檢查檔名是否有重複？
                    my_counter++;
                }                
                Label1.Text = "抱歉，您上傳的檔名發生衝突，檔名修改如下" + "<br />" + tempfileName;
            }
            else   {
                 tempfileName = fileName;
            }
            //==================================================(End)

            //完成檔案上傳。
            FileUpload1.SaveAs(pathToCheck);
            Label1.Text = "上傳成功，檔名---- " + tempfileName;
        }
        else   {
            Label1.Text = "請先挑選檔案之後，再來上傳";
        }

        //另外一種寫法，可以參考 http://jengting.blogspot.tw/2014/10/fileupload.html
    }
}