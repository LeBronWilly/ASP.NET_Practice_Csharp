using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch03_HTML_Web_DropDownList_Select : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		 
	}

	protected void Button1_Click(object sender, EventArgs e)
	{
		Response.Write(Select1.Items[0].Value);
	}
}