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


public partial class Book_Sample_Ch18_FileUpload_FileUpload_DB_Image_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //*** 不需要存檔的 Web Server「硬碟路徑」，因為要把圖片（二進位）存入DB ***

        if (FileUpload1.HasFile)
        {
            //********************************************* (start)***
            //== (1). 開啟資料庫的連結。
            //----上面已經事先寫好NameSpace --  using System.Web.Configuration; ----     
            //----或是寫成下面這一行 (連結資料庫)----
            SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);
            Conn.Open();   //---- 這時候才連結DB


            //== (2). 執行SQL指令。或是查詢、撈取資料。
            String sqlstr = "Insert Into FileUpload_DB2(FileUpload_time, FileUpload_FileName, FileUpload_MIME) Values(getdate(), @FileUpload_FileName, @FileUpload_MIME)";
            SqlCommand cmd = new SqlCommand(sqlstr, Conn);

            //== @參數 ==
            // 讀取上傳的二進位（IO Stream） http://msdn.microsoft.com/zh-tw/library/system.web.httppostedfile.inputstream(v=vs.110).aspx
            byte[] ImgByte = new byte[FileUpload1.PostedFile.InputStream.Length];
            // 使用 HttpPostedFile，以上傳圖片的Stream大小，當作陣列大小。
            FileUpload1.PostedFile.InputStream.Read(ImgByte, 0, ImgByte.Length);            
            // IO Stream的 .Read()方法  http://msdn.microsoft.com/zh-tw/library/system.io.stream.read(v=vs.110).aspx
            
            cmd.Parameters.AddWithValue("@FileUpload_FileName", ImgByte);

            //== @參數 ==
            //必須以上傳的「附檔名」當作MIME名稱，將來讀取二進位圖檔出來，Response會用到這個關鍵資料！
            String fileExtension = System.IO.Path.GetExtension( FileUpload1.FileName);
            cmd.Parameters.AddWithValue("@FileUpload_MIME", fileExtension);


            //== (3). 自由發揮。
            cmd.ExecuteNonQuery();
            //== (4). 釋放資源、關閉資料庫的連結。
            cmd.Cancel();
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
            }
            //********************************************* (end) ***
            
            Label1.Text = "上傳成功。並存入資料庫（圖片的二進位）。";
        }
        else
        {
            Label1.Text = "請先挑選檔案之後，再來上傳";
        }
    }
}