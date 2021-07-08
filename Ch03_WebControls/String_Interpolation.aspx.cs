using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch02_CS_60_2015_String_Interpolation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var a = 1.2345;

        Response.Write($"test {a}  <br>");
        Response.Write($"test {a} {a} {a}  <br>");
        Response.Write($"test {a + 10}  <br>");
        Response.Write($"test {a:00.00}  <br>");
        Response.Write($"test {a + 10:F2}  <br>");
        //Response.Write($"test {Get10():F2}, {Get0()}  <br>");
        //Response.Write($"test {(args.Length != 0 ? "0" : "1")}  <br>");
    }
}