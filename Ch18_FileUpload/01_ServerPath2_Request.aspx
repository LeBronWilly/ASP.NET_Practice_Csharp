<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01_ServerPath2_Request.aspx.cs" Inherits="Book_Sample_Ch18_FileUpload_01_ServerPath2_Request" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        ===================================================================</p>
    <p>
        <strong>資料來源：</strong><a href="https://dotblogs.com.tw/atowngit/archive/2009/08/23/10198.aspx"><strong>https://dotblogs.com.tw/atowngit/archive/2009/08/23/10198.aspx</strong></a><strong> </strong>
    </p>
    <form id="form1" runat="server">
    <div>
    
        <strong>以下僅供參考</strong><br />
        Server.MapPath(&quot;~&quot;) 「根」路徑&nbsp; :<font color="blue"> C:\Users\mis2000lab\Documents\Visual Studio 2015\WebSites\WebSite2015_MIS2000Lab_CS\</font><br />
        Server.MapPath (&quot;.&quot;:<font color="blue"> C:\Users\mis2000lab\Documents\Visual Studio 2015\WebSites\WebSite2015_MIS2000Lab_CS\Book_Sample\Ch18_FileUpload</font><br />
        <br />
        <br />
        Request.ApplicationPath :<font color="red"> /</font><br />
        <br />
        <br />
        Request.CurrentExecutionFilePath（包含檔名） : <font color="red">/Book_Sample/Ch18_FileUpload/01_ServerPath2_Request.aspx</font><br />
        Request.FilePath（包含檔名） :<font color="red"> /Book_Sample/Ch18_FileUpload/01_ServerPath2_Request.aspx</font><br />
        Request.Path（包含檔名） : <font color="red">/Book_Sample/Ch18_FileUpload/01_ServerPath2_Request.aspx</font><br />
        <br />
        <br />
        Request.PhysicalApplicationPath : <font color="red">C:\Users\mis2000lab\Documents\Visual Studio 2015\WebSites\WebSite2015_MIS2000Lab_CS\<br />
        </font>
        <br />
        Request.PhysicalPath （包含檔名）:<font color="red"> C:\Users\mis2000lab\Documents\Visual Studio 2015\WebSites\WebSite2015_MIS2000Lab_CS\Book_Sample\Ch18_FileUpload\01_ServerPath2_Request.aspx</font></div>
    </form>
</body>
</html>
