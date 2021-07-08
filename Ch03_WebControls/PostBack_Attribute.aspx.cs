using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PostBack_Attribute : System.Web.UI.Page
{

    protected void Page_Init(object sender, EventArgs e)
    {
        DropDownList1.Items.Add("***動態加入，Page_Init事件***");
        DropDownList1.Items[2].Attributes.Add("onclick", "hello()");  

        TextBox1.TextMode = TextBoxMode.Password;
        TextBox1.Text = "123";     // 失敗！

        Button1.Attributes.Add("onclick", "hello()");
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}