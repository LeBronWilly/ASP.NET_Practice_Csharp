using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch03_WebControls_01_Page_Load_2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {    // ***第一次執行才會運作這一段！！***

            TextBox1.Text = "李小明";      // 網頁一載入，就提供 TextBox 預設值
            Label2.Text = "「第一次」執行Page的Load事件 ......" + DateTime.Now.ToLongTimeString() + "<p>";
        }
        else
        {
            Label2.Text = "「PostBack」而執行Page的Load事件 ......" + DateTime.Now.ToLongTimeString() + "<p>";
        }       

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "您修改後的名字 -- " + TextBox1.Text;

        Label2.Text = Label2.Text + "執行Button1的Click事件 ......" + DateTime.Now.ToLongTimeString();
    }
}