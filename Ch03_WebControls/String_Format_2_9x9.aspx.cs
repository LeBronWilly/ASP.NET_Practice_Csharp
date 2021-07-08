using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch02_For_School_02 : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		for (int i = 1; i <= 9; i++)
		{
			for (int j = 1; j <= 9; j++)
			{
				// 傳統字串相連的作法
				// Response.Write(i + " x " + j + "=" + (i*j) + "&nbsp; &nbsp;");

				Response.Write(String.Format("{0}x{1}={2} &nbsp; &nbsp;", i, j, (i*j)));
			}
			Response.Write("<br><hr><br>");
		}

	}
}