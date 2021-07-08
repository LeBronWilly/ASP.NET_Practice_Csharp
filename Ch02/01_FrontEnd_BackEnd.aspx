<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01_FrontEnd_BackEnd.aspx.cs" Inherits="Book_Sample_Ch02_01_FrontEnd_BackEnd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script>window.alert("前端 JavaScript程式碼，由瀏覽器來執行");</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <%  Response.Write(" <br> 寫在網頁畫面中的「ASP.NET程式碼」<br>"); %>

    </div>
    </form>
</body>
</html>
