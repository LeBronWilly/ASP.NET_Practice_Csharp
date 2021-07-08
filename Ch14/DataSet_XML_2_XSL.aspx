<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataSet_XML_2_XSL.aspx.cs" Inherits="Ch17_File_DataSet_XML_2_XSL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>DataSet轉成XML檔案 #2 (透過 .xsl 檔轉換)</title>
    <style type="text/css">
        .style1
        {
            background-color: #FFCC66;
        }
    </style>
</head>
<body>
    <p>
        手寫版的程式，把 DataSet轉成XML檔案 #2。<br />
        ......<span class="style1">透過 .xsl 檔，進行轉換</span>。
    </p>
    <form id="form1" runat="server">
    <div>

        <asp:Button ID="Button1" runat="server" Text="Export To Excel-File"
            OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>

    </div>
    </form>

</body>
</html>
