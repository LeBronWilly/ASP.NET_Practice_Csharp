using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GridView_RowDataBound_2_CaseStudy_PreRender : System.Web.UI.Page
{
    int sum1 = 0;
    int sum2 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        // 在控制項呈現到畫面「之前」，做最後的處理
        int sum = 0;
               
        foreach (GridViewRow GV_Row in GridView1.Rows)
        {   // 參考範例  http://www.dotblogs.com.tw/mis2000lab/archive/2012/01/13/gridview_multi_row_updating_20120113.aspx

            sum += Convert.ToInt32(GV_Row.Cells[5].Text);
        }

        Label1.Text = "PreRender事件 ** 數學成績的加總 = " + sum;
    }


    //************************************************************
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {   //我跟 RowDataBound事件是雙胞胎兄弟，但我比較早執行。我是哥哥！
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Text != "")
            {   // 如果這時候抓得到數值，我就累加！
                //sum1 += Convert.ToInt32(e.Row.Cells[5].Text);
                //Label2.Text = "RowCreated ** 數學成績的加總 = " + sum1;
                Label2.Text = "RowCreated ** e.Row.Cells[5].Text的內容是：" + e.Row.Cells[5].Text;
            }
            else {
                Label2.Text = "RowCreated ** 抱歉，我抓不到數值。";
            }
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {            
            sum2 += Convert.ToInt32(e.Row.Cells[5].Text);
            Label3.Text = "RowDataBound事件 ** 數學成績的加總 = " + sum2;
        }            
    }


}