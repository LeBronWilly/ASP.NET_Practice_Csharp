using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch03_WebControls_DropDownList_PostBack_Calculator : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // 防呆
        if(DropDownList1.SelectedValue == "0")        {
            Label2.Text = "您選錯啦！！！";
            //Response.End();    // ***比較一下*** 使用 Response.End() 與 return來中斷程式，兩者有何差異？？
            return;
        }

        // 計算
        int result = Convert.ToInt32(Label1.Text) + Convert.ToInt32(DropDownList1.SelectedValue);
        Label1.Text = result.ToString();

        Label2.Text = "";
        Label3.Text += DropDownList1.SelectedValue + " + ";   // 將計算過程，呈現出來
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Text = "最後的結果 ---" + Label1.Text;
    }
}