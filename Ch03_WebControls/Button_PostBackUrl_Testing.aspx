<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Button_PostBackUrl_Testing.aspx.cs" Inherits="Book_Sample_Ch03_WebControls_Button_PostBackUrl_Testing" %>

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
    
        測試 Button的「PostBackUrl屬性」<br />
        <br />
        當我們設定 PostBackUrl屬性以後，是否還會執行 <strong>Button_Click事件</strong>的內容？<br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" PostBackUrl="0.aspx" Text="Button" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" style="background-color: #CCFF33"></asp:Label>
        <br />
        <br />
        <br />
        答案是：<strong><span class="auto-style1">不會</span>執行 Click事件</strong></div>
    </form>
</body>
</html>
