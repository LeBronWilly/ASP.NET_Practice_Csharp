using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;  //註解：事先宣告System.IO這個 NameSpace！


public partial class Book_Sample_Ch18_FileUpload_02_3_ReName_Guid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {   
        //註解：先設定好檔案上傳的路徑，這是Web Server電腦上的硬碟「實際」目錄。
        string savePath = "d:\\temp\\uploads\\";

        if (FileUpload1.HasFile)
        {   //==================================================(Start)
            string ExtFilename = System.IO.Path.GetExtension(FileUpload1.FileName);  //取得上傳檔案的「.副檔名」。

            string fileName = Guid.NewGuid().ToString("N") + ExtFilename; 
            //-- 不管你上傳什麼，主檔名通通改成Guid 產生的字串！   .副檔名照舊。
            Response.Write(fileName);
            //==================================================(End)

            // 完成檔案上傳的動作。
            savePath = Path.Combine(savePath, fileName);
            FileUpload1.SaveAs(savePath);
            
            Label1.Text = "上傳成功，檔名---- " + fileName;
        }
        else   {
            Label1.Text = "請先挑選檔案之後，再來上傳";
        }
    }
}