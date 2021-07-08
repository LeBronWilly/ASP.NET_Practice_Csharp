<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01_Page_Load_3.aspx.cs" Inherits="Book_Sample_Ch03_WebControls_01_Page_Load_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #0066FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        解釋 Page的Load事件 與&nbsp; PostBack（回傳）-- <span class="auto-style1">成功版</span><br />
        <br />
        <br />
        請輸入您的姓名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #3366FF; font-size: x-large;"></asp:Label>
        <br />
        <br />
        <br />
        <div style="font-weight: 700; color: #009900">*** 事件執行的順序 ***<br />
        </div>
        <asp:Label ID="Label2" runat="server" style="font-weight: 700; color: #009900"></asp:Label>
        <br />
        <br />
        </div>
    </form>
</body>
</html>
