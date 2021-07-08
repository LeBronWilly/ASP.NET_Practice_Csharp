using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch03_WebControls_11_Button_Event : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //  動態加入事件！！
        //  資料來源。 http://www.dotblogs.com.tw/mis2000lab/archive/2011/11/05/eventhandler_addhandler_addressof_method.aspx

        ////***** 錯誤版！！ *********************************
        //if (!Page.IsPostBack)    //不懂第一次執行，不懂 PostBack
        //{
        //    Button btn = new Button();
        //    btn.Click += new System.EventHandler(HelloClick);
        //    btn.Text = "我是ASP.NET Button按鈕，動態加入的！";

        //    Placeholder1.Controls.Add(btn);            
        //}


        //***** 成功版 *********************************************
        Button btn = new Button();
        btn.Click += new System.EventHandler(HelloClick);
        btn.Text = "我是ASP.NET Button按鈕，動態加入的！";

        Placeholder1.Controls.Add(btn);

    }

        protected void HelloClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Response.Write(btn.Text);
        }
        
    
}