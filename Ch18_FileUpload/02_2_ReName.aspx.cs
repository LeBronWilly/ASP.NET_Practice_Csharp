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
        string savePath = "d:\\temp\\uploads\\";    //或是寫成  string savePath = @"d:\temp\uploads\";

        if (FileUpload1.HasFile)
        {   //==================================================(Start)
            string fileName = FileUpload1.FileName;  //-- User上傳的完整檔名（不包含 Client端的路徑！）

            string pathToCheck = Path.Combine(savePath, fileName);   // --新的路徑與檔名，透過迴圈繼續檢查檔名是否有重複？
            string tempfileName = "";     //-- 檔名重複，修改後的檔名

            if (File.Exists(pathToCheck))
            {
                int my_counter = 2;
                string OnlyFileName = Path.GetFileNameWithoutExtension(fileName);  // 註解：擷取上傳檔案的「主檔名」。
                string fileExtension = Path.GetExtension(fileName);   // 註解：擷取上傳檔案的「.副檔名」。
                // 想抓到「主檔名」，請寫成 System.IO.Path.GetFileNameWithoutExtension(fileName);
                // 想抓到「副檔名」，請寫成 System.IO.Path.GetExtension(fileName);

                while (File.Exists(pathToCheck))
                {   //*************************************************************************************
                    // 路徑與檔名都相同的話，目前上傳的檔名（改成 tempfileName），後面會用數字來代替。
                    tempfileName = OnlyFileName + "_" + my_counter.ToString() + fileExtension;
                    //-- 完成後的新檔案名稱：   正檔名_數字.副檔名  (fileExtension會提供  ".副檔名" )
                    //*************************************************************************************

                    pathToCheck = Path.Combine(savePath, tempfileName);   // --新的路徑與檔名，透過迴圈繼續檢查檔名是否有重複？
                    my_counter ++;
                }                
                Label1.Text = "抱歉，您上傳的檔名發生衝突，檔名修改如下<br />" + tempfileName;
            }
            //==================================================(End)

            // 完成檔案上傳。
            FileUpload1.SaveAs(pathToCheck);
            Label1.Text = "<br />上傳成功，檔名---- " + tempfileName;
        }
        else   {
            Label1.Text = "請先挑選檔案之後，再來上傳";
        }

        //另外一種寫法，可以參考 http://jengting.blogspot.tw/2014/10/fileupload.html
    }
}