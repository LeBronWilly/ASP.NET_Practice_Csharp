<%@ Page Language="C#" AutoEventWireup="true" CodeFile="String_funny_01.aspx.cs" Inherits="Book_Sample_Ch03_WebControls_String_Combine_Funny_String_funny_01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        有趣的字串相連&nbsp; -- <a href="https://dotblogs.com.tw/mis2000lab/2013/12/09/133007">https://dotblogs.com.tw/mis2000lab/2013/12/09/133007</a><br />
        <br />
        不同版本的 Visual Studio (.NET版本)，可能有不同結果<br />
        <br />        <br />
        Label1.Text = Label1.Text + 1;<br />
        <asp:Label ID="Label1" runat="server" style="font-weight: 700; font-size: large; color: #FF3300" Text="0"></asp:Label>
        <br />        <br />        <br />
        Label2.Text = 1+ 1+ <strong>&quot;a&quot;</strong> + 1 + 1;<br />
        <asp:Label ID="Label2" runat="server" style="font-weight: 700; font-size: large; color: #33CC33" Text="0"></asp:Label>
        <br />        <br />        <br />
        Label3.Text = <strong>&quot;a&quot;</strong> + 1 + 1;<br />
        <asp:Label ID="Label3" runat="server" style="font-weight: 700; font-size: large; color: #0000FF" Text="0"></asp:Label>
        <br />        <br />        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button_請您連續、重複按下按鈕" />
    
    </div>
    </form>
</body>
</html>
