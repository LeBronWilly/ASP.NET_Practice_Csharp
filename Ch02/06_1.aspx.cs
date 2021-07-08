using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Ch02_6_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //*************************************************
        if (Response.IsClientConnected);   //==這裡有錯！！！！
        {
           /* 註解：請特別注意，if這一行程式，後面沒有分號（；）結尾。
           *  因為整個 if判別式，是同一區塊。倘若您在if這一行程式加上分，如：
           *   if (Response.IsClientConnected);  
           *      那麼底下的內容就不會被執行囉！
           */
            Response.Write("連線中….");
        }
        else     
        {    //註解：看吧！else 這裡出現紅色底線，表示有錯誤！

            Response.Write("已經離線了….掰掰！");
            //本程式是錯誤的，不能執行。只是當成範例，提醒讀者。
        }
    
    }
}
