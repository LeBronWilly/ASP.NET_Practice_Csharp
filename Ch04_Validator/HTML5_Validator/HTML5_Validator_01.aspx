<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HTML5_Validator_01.aspx.cs" Inherits="Book_Sample_Ch04_Validator_HTML5_Validator_HTML5_Validator_01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <p>
        必填欄位，請加入 required關鍵字</p>
    <p>
        請看文章：<a href="http://www.dotblogs.com.tw/mis2000lab/archive/2013/10/09/html5_textbox_input_validator.aspx">http://www.dotblogs.com.tw/mis2000lab/archive/2013/10/09/html5_textbox_input_validator.aspx</a> </p>
    <p>
        <br />
        ASP.NET TextBox</p>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="TextBox1" runat="server" required title="ASP.NET TextBox也可以使用required">
            </asp:TextBox>（必填欄位，請加入 required關鍵字 -- HTML5專用）
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            =========================================</p>
        <p>
            HTML &lt;Input&gt;</p>
        <p>
            <input id="Text1" type="text" required title="請自己填寫，必填欄位的警告提示語" />（必填欄位，請加入 required關鍵字）</p>
    <div>
    
        <input id="Submit1" type="submit" value="submit" /><br />
        <br />
        <br />
        作者在YouTube錄製的教學影片：<a href="https://youtu.be/MBCU9ZS4rFU">https://youtu.be/MBCU9ZS4rFU</a>
        <br /><iframe width="560" height="315" src="https://www.youtube.com/embed/MBCU9ZS4rFU" frameborder="0" allowfullscreen></iframe>
        <br />
        </div>
    </form>
</body>
</html>
