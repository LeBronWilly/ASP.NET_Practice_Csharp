<%@ Page Language="C#" AutoEventWireup="true" CodeFile="10_FileName_HttpPostedFile.aspx.cs" Inherits="Book_Sample_Ch18_FileUpload_10_FileName_HttpPostedFile" %>

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
            VS 2017時，讀者來信發現了一個 bug。之前的版本，在上課時並未發現此事。<br />
            <br />
            目前，問題（Bug）<span class="auto-style1"><strong>鎖定在 Win 10 + IE瀏覽器（IE 11或 Edge瀏覽器）</strong></span><br />
            <br />
            Chrome 或 FireFox瀏覽器一切正常。<br />
            <br />
            <br />
            <br />
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
