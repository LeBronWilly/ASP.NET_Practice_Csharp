using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch03_WebControls_11_Focus : System.Web.UI.Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        for (int i = 0; i < 3; i++)
        {
            TextBox txt = new TextBox();
            txt.ID = "TextBox" + i.ToString();

            PlaceHolder1.Controls.Add(txt);
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //TextBox txt = (TextBox)Page.Form.FindControl("TextBox0");
        // 也可以寫成  
        TextBox txt = (TextBox)PlaceHolder1.FindControl("TextBox0");

        txt.Text = "focus";
                txt.Focus();
    }
}