using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PostBack_sender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
        else      {
            var btn = sender;   // 注意訊息！！
            Response.Write("Button被按下了(Page_Load事件)---" + btn.ToString());

            //***********************************************************
            // 方法一：// http://www.dotblogs.com.tw/robinson/archive/2011/10/28/47094.aspx

            string ctrlname = Request.Params["__EVENTTARGET"];
            Response.Write("<hr />Request.Params[\"__EVENTTARGET\"] ---" + ctrlname);   
            // Button沒有設定 UseSubmitBehavior="false" 就抓不到值

            //***********************************************************
            // 方法二：// http://www.dotblogs.com.tw/robinson/archive/2011/10/28/47094.aspx

            string ctrlname1 = Request.Params.Get("__EVENTTARGET");
            if (ctrlname1 != null && ctrlname1 != string.Empty)
            {   // Button沒有設定 UseSubmitBehavior="false" 就抓不到值
                Response.Write("<hr />Page.FindControl #1 ---" + Page.FindControl(ctrlname1));
            }
            else
            {
                foreach (string ctl in Request.Form)
                {
                    Control c = Page.FindControl(ctl);
                    if (c is System.Web.UI.WebControls.Button)   {
                        Response.Write("<hr />Page.FindControl #2 ---" + Page.FindControl(ctrlname1));
                        break;
                    }
                }
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Response.Write("<br><br>Button被按下了(Button1_Click事件)---" + btn.Text);
    }
}