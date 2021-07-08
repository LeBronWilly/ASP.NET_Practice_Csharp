<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataReader_Parameter_4.aspx.cs" Inherits="Book_Sample_Ch14_DataReader_Parameter_4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FF0066;
        }
        .auto-style2 {
            background-color: #FFFF00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        連續加入 test資料表，十筆記錄<br />
        <br />
        每筆記錄有四個欄位、四個參數！<br />
        <br />
        使用 <span class="auto-style2">cmd.Parameters<strong>.AddRange()</strong></span><br />
        <br />
        Insert Into test(<strong>test_time, title, summary, article, author)</strong> Values(<strong>getdate(), <span class="auto-style1">@parameter11, @parameter12, @parameter13, @parameter14</span></strong>);<br />
        <br />
    
    </div>
    </form>
</body>
</html>
