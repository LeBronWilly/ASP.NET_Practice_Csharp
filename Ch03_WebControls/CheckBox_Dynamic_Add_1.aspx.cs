using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch03_WebControls_CheckBox_Dynamic_Add : System.Web.UI.Page
{

    protected void Page_Init(object sender, EventArgs e)
    {
        CheckBox CB = new CheckBox();
        CB.ID = "CheckBox1";
        CB.AutoPostBack = true;
        CB.Text = "第一層";
        CB.CheckedChanged += new System.EventHandler(this.myCB_CheckedChanged);  // 動態加入事件，後面是「事件名稱」
        Page.Form.Controls.Add(CB);

        CheckBox CB2 = new CheckBox();
        CB2.ID = "CheckBox2";
        CB2.AutoPostBack = true;
        CB2.Text = "第二層";
        CB2.CheckedChanged += new System.EventHandler(this.myCB_CheckedChanged);  // 動態加入事件，後面是「事件名稱」
        Page.Form.Controls.Add(CB2);

        CheckBox CB3 = new CheckBox();
        CB3.ID = "CheckBox3";
        CB3.AutoPostBack = true;
        CB3.Text = "第三層";
        CB3.CheckedChanged += new System.EventHandler(this.myCB_CheckedChanged);  // 動態加入事件，後面是「事件名稱」
        Page.Form.Controls.Add(CB3);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //**** 三個 CheckBox可以共用同一個事件，使用了 sender的小技巧
    protected void myCB_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox CB = (CheckBox)sender;

        if(CB.Checked)
        {
            Response.Write("<h3>" + CB.ID + "......被點選了！！</h3>");
        }
        else
        {
            Response.Write("<h3>**" + CB.ID + "......「沒有」被點選**</h3>");
        }        
    }
}