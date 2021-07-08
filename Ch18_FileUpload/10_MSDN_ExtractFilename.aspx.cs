using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class A10_MSDN_ExtractFilename : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string filename;

        filename = ExtractFilename(@"C:\temp\");
        Label1.Text = String.Format("C:\\temp\\ 結果是-- {0}", String.IsNullOrEmpty(filename) ? "<b>無檔名</b>" : filename);

        filename = ExtractFilename(@"C:\temp\delegate.txt");
        Label1.Text += String.Format("<br>C:\\temp\\delegate.txt 結果是-- {0}", String.IsNullOrEmpty(filename) ? "<b>無檔名</b>" : filename);

        filename = ExtractFilename("delegate.txt");
        Label1.Text += String.Format("<br>delegate.txt  結果是-- {0}", String.IsNullOrEmpty(filename) ? "<b>無檔名</b>" : filename);

        filename = ExtractFilename(@"C:\temp\notafile.txt");
        Label1.Text += String.Format("<br> C:\\temp\\notafile.txt 結果是-- {0}", String.IsNullOrEmpty(filename) ? "<b>無檔名</b>" : filename);
    }



    //================================================================
    // 微軟MSDN網站寫好的。請參閱範例 10_MSDN_ExtractFilename.aspx
    // 改寫自 https://msdn.microsoft.com/zh-tw/library/0w96zd3d(v=vs.110).aspx
    public static string ExtractFilename(string filepath)
    {
        // If path ends with a "\", it's a path only so return String.Empty.
        if (filepath.Trim().EndsWith(@"\"))
            return String.Empty;

        // Determine where last backslash is.
        int position = filepath.LastIndexOf('\\');

        // 如果都沒有反斜線，那麼就是上面的第一種、第三種狀況。
        if (position == -1)
        {
            // 預防上面第三種狀況，直接抓到「檔名」。
            if (filepath.IndexOf(".") >= 0)
                return filepath;
            else
                return String.Empty;
        }
        else
        {
                return filepath.Substring(position + 1);
        }
    }


}