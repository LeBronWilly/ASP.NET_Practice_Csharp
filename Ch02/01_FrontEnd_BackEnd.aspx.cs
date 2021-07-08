using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch02_01_FrontEnd_BackEnd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(" <br> 後置程式碼，寫在 Page_Load事件裡面！ASP.NET程式碼<br>");
    }
}