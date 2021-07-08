using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch11_jQuery_GridView_Header_Default_02_RowDataBound : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.Header)
        {
            // 請寫入表頭欄位（標題列）的CSS
            e.Row.Attributes.Add("class", "GridviewScrollHeader");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // 請寫入表頭欄位（標題列）的CSS
            e.Row.Attributes.Add("class", "GridviewScrollItem");
        }

    }
}