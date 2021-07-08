using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;     //==別忘了寫喔！==


public partial class Book_Sample_Ch17_File_count_02_DynaAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //====讀取檔案 (務必修改這個檔案的權限，需要「寫入」的權限)====
        StreamReader sr = new StreamReader(Server.MapPath("counter.txt"));

        //--把檔案內, 原本的訪客人數[加一]
        string visitors = sr.ReadLine();
        sr.Close();   // 檔案讀取，結束！
        sr.Dispose();

        visitors = Convert.ToString(Convert.ToInt32(visitors) + 1);

        //--把訪客人數[加一]之後，轉換成圖片
        int Length = visitors.Length;  //--計算訪客人數[加一]之後的 "字串長度"


        //***************************************************
        for(int i =1; i <= Length; i++)
        {   //--訪客人數的每一位數字，都用圖片來呈現。          
            // 因為 C#語法沒有VB的 Mid()函數，
            // 程式碼 strURL = "<img src='image/" & Mid(visitors, i, 1) + "lcdb0.gif' />" & strURL
           //  所以C#語法裡面，改寫成 --
            Image img = new Image();
            img.ImageUrl = "image/" + visitors.Substring((i-1), 1) + "lcdb0.gif";

            Page.Form.Controls.Add(img);   //動態加入控制項。
            // 動態加入控制項，不能像上一個範例那樣，把數字「反著」加入畫面。
             // 必須由大到小，依序加入畫面才行。
        }
        //***************************************************


        //====寫入檔案，紀錄最新的訪客人數==================
        StreamWriter sw = new StreamWriter(Server.MapPath("counter.txt"));
        sw.WriteLine(visitors);   //--找不到檔案也不會出現錯誤訊息，而且會自動新增一個檔案。
        sw.Close();
        sw.Dispose();
    }
}