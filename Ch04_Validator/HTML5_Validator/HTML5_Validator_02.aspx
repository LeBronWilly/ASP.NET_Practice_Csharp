<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HTML5_Validator_02.aspx.cs" Inherits="Book_Sample_Ch04_Validator_HTML5_Validator_HTML5_Validator_02" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <p>
        必填欄位，pattern關鍵字可使用正規表達式（正規運算式 / Regular Expression）
    </p>
    <p>
        &nbsp;
    </p>
    <p>
        <br />
        ASP.NET TextBox
    </p>
    <form id="form1" runat="server">
        <p>
            <asp:TextBox ID="TextBox1" runat="server" required title="只能輸入大寫英文字" pattern="[A-Z]+" TextMode="Number"></asp:TextBox>（必填欄位，請加入 required關鍵字 -- HTML5專用）
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </p>
        <p>
            &nbsp;
        </p>
        <p>
            =========================================
        </p>
        <p>
            HTML &lt;Input&gt;
        </p>
        <p>
            <input id="Text1" type="text" required title="只能輸入大寫英文字" pattern="[A-Z]+"  />（必填欄位，請加入 required關鍵字）
        </p>
        <div>

            <input id="Submit1" type="submit" value="submit" />
            <br />
            <br />
            =========================================
            <br />
            <br />
            <br />
            <strong>placeholder -- 浮水印</strong><br />
            <br />
            請看文章：<a href="http://www.dotblogs.com.tw/mis2000lab/archive/2013/10/09/html5_textbox_input_validator.aspx">http://www.dotblogs.com.tw/mis2000lab/archive/2013/10/09/html5_textbox_input_validator.aspx</a>
            <br />
            <br />
            請輸入E-Mail <asp:TextBox ID="TextBox2" runat="server" required placeholder="請輸入E-Mail address">
            </asp:TextBox>
            <asp:Button ID="Button2" runat="server" Text="Button" />
        </div>
    </form>
</body>
</html>
