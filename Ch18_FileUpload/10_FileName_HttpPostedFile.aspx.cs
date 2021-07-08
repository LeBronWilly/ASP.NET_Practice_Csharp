using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch18_FileUpload_10_FileName_HttpPostedFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "FileUpload1.FileName -- " + FileUpload1.FileName + "<hr>";

        Label1.Text += "FileUpload1.PostedFile.FileName -- " + FileUpload1.PostedFile.FileName;
        Label1.Text += "<br><font color=red>為什麼出現「完整路徑與檔名」？？？？</font>而且只有IE 11與Edge瀏覽器會出錯";
    }
}