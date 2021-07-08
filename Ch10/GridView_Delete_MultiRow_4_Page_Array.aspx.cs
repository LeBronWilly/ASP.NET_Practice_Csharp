using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch10_GridView_Delete_MultiRow_4_Page : System.Web.UI.Page
{   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {   // 第一次執行。
            List<string> myArray = new List<string>();    // 初始化。建立一個新的 List
            Session["myArray"] = myArray;
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {   //== 重複的、大量的程式，就抽離出去，獨自成為一個函數、副程式。
        Checkbox_Process();
        // 如果您希望按下 "分頁" 就自動記錄勾選的那幾筆，請把這段程式寫在底下的GridView "分頁"事件即可。
    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //    //GridView1.PageIndex = e.NewPageIndex;
        //    ////== 在此不用作 DataBinding。
        //    ////      因為HTML畫面裡面， GridView已經有設定 DataSourceID。
        //    ////      這個事件不寫也行。因為GridView + SqlDataSource精靈會處理分頁。
    }


    //**** 請看上集，第十一章 *******************************************
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {   //-- 參考資料： [習題]GridView樣版內部，改用CheckBox/Radio/DropDownList（單/複選）控制項，取代TextBox
        //-- 請看我的BLOG與習題 -- http://www.dotblogs.com.tw/mis2000lab/archive/2008/12/26/gridview_template_radiobuttonlist_1225.aspx

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox myCheckbox = (CheckBox)e.Row.FindControl("CheckBox1");
            Label myID = (Label)e.Row.FindControl("Label1");

            //*** 方法二 ****************************************************************
            //*** 把字串（A1,A2,A3.....）轉成陣列會更好，就可以不用在數字前面加上「A」了！
            //*** http://msdn.microsoft.com/zh-tw/library/b873y76a(v=vs.110).aspx

            List<string> myArray = (List<string>)Session["myArray"];
            if (myArray.IndexOf(myID.Text) >= 0)   //-- 已經有資料在內
            {    //-- 檢查一下，如果文章編號已經記錄在裡面了，那麼 CheckBox就要被勾選。
                myCheckbox.Checked = true;
            }
            else    {
                myCheckbox.Checked = false;
            }
        }
    }


    protected void Checkbox_Process()
    {
        List<string> myArray = (List<string>)Session["myArray"];
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox myCheckbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
            Label myID = (Label)GridView1.Rows[i].FindControl("Label1");

            if (myCheckbox.Checked == true)
            {   //====================
                //==  被點選的某一筆資料。 ==
                //====================

                //註解：VB語法的 Instr()，在C#裡面改為 .IndexOf("字串", 0)
                //    找不到的話， 會傳回「-1」。
                //    找到的話，回傳一個Integer數字（從零算起）。表示在字串裡面第幾個字，符合條件。
                //  請看 http://www.dotblogs.com.tw/mis2000lab/archive/2009/01/14/instr_function_090114.aspx
                
                if (myArray.IndexOf(myID.Text) == -1)
                {   //-- 檢查一下，如果相同的文章編號已經記錄在 List了，就不要重複記憶！
                    myArray.Add(myID.Text);
                }
            }
            else
            {   //====================================
                //== 「沒有」被點選的某一筆資料。 必須從 List裡面刪除 ==
                //====================================
                if (myArray.IndexOf(myID.Text) >= 0)  //--已經有資料在內              
                {
                    myArray.Remove(myID.Text);
                }
            }   // if -- End
        }  // for loop -- End


        if (myArray.Count == 0)  {   // List沒有 Length，只能用 Count
            Label2.Text = "您尚未點選任何一筆資料（沒有刪除任何一筆）";
        }
        else    {
            // Debug用的，把資料列在畫面上。
            Label2.Text = "";
            foreach (string str in myArray)     {
                Label2.Text += str + "，";
            }
            //== 您可以使用這些文章的ID來進行SQL指令「刪除」的動作 ==
        }
    }

}