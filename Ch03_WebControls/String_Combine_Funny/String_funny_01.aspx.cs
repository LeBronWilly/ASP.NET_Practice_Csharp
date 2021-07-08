using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch03_WebControls_String_Combine_Funny_String_funny_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {   // 資料來源  https://dotblogs.com.tw/mis2000lab/2013/12/09/133007

        Label1.Text = Label1.Text + 1;

        Label2.Text = 1+1+"a" +1+1;

        Label3.Text = "a" + 1 + 1;
    }
}