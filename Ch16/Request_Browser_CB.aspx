<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Request_Browser_CB.aspx.cs" Inherits="Book_Sample_Ch16_Request_Browser_CB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
 <%        
     HttpBrowserCapabilities rb = Request.Browser;

     Response.Write("<p>用戶端的瀏覽器支援功能：</p>");
     Response.Write("Type = " + rb.Type + "<br>");
     Response.Write("Name = " + rb.Browser + "<br>");
     Response.Write("Version = " + rb.Version + "<br>");
     Response.Write("Major Version = " + rb.MajorVersion + "<br>");
     Response.Write("Minor Version = " + rb.MinorVersion + "<br>");
     Response.Write("Platform 作業系統 = " + rb.Platform + "<br>");
     Response.Write("Is Beta = " + rb.Beta + "<br>");
     Response.Write("是否為 Web Crawler 搜尋引擎= " + rb.Crawler + "<br>");
     Response.Write("Is AOL = " + rb.AOL + "<br>");
     Response.Write("Is Win16 = " + rb.Win16 + "<br>");
     Response.Write("Is Win32 = " + rb.Win32 + "<br>");
     Response.Write("Supports Frames （網頁框架）= " + rb.Frames + "<br>");
     Response.Write("Supports Tables = " + rb.Tables + "<br>");
     Response.Write("Supports Cookies = " + rb.Cookies + "<br>");
     Response.Write("Supports VB Script = " + rb.VBScript + "<br>");
     Response.Write("Supports JavaScript = " + rb.JavaScript + "<br>");
     Response.Write("Supports Java Applets = " + rb.JavaApplets + "<br>");
     Response.Write("Supports ActiveX Controls = " + rb.ActiveXControls + "<br>");
     Response.Write("CDF（網路廣播，Webcasting） = " + rb.CDF + "<br>");
%>   

    </div>
    </form>
</body>
</html>
