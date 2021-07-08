using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch11_GridView_RowDataBound_7_Samples_GridView_RowDataBound_3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // 按下「編輯」按鈕之後，以前的版本會報錯。新版VS 2013 / 2015不會。
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Response.Write(e.Row.Cells[3].Text + "<br>");
        }

        //// 錯誤寫法 : 只會出現單數列（1/3/5/7/9），雙數列的標題消失了！！
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if(e.Row.RowState == DataControlRowState.Normal)
        //        Response.Write(e.Row.Cells[3].Text + "<br>");
        //}

        //// ***** 正確版本！！ **************************************
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.RowState != DataControlRowState.Edit)
        //        Response.Write(e.Row.Cells[3].Text + "<br>");
        //}

        ////  ***** 正確版本！！ **************************************
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
        //        Response.Write(e.Row.Cells[3].Text + "<br>");
        //}

    }
}