<%@ Page Language="C#" AutoEventWireup="true" CodeFile="10_MSDN_ExtractFilename.aspx.cs" Inherits="A10_MSDN_ExtractFilename" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            微軟MSDN寫好的，改寫自&nbsp; <a href="https://msdn.microsoft.com/zh-tw/library/0w96zd3d(v=vs.110).aspx">https://msdn.microsoft.com/zh-tw/library/0w96zd3d(v=vs.110).aspx</a>
            <br />
            <br />
            可以抓到使用者（Client端）上傳檔案，<br />
            完整路徑中（如<span class="auto-style1"><strong>C:\temp\delegate.txt</strong></span>），最後的「檔名」（如<span class="auto-style1"><strong>delegate.txt</strong></span>）<br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" style="color: #3366FF"></asp:Label>
        </div>
    </form>
</body>
</html>
