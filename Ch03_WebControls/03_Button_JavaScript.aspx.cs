using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch03_WebControls_3_Button_JavaScript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Button3.Attributes.Add("onclick", "alert(\"Button3_JavaScript\")");
        }
        
    }

    protected void Button3_Click(object sender, EventArgs e)
    {

    }
}