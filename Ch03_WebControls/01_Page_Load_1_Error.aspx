<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01_Page_Load_1_Error.aspx.cs" Inherits="Book_Sample_Ch03_WebControls_1_Page_Load_1_Error" %>

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
           解釋 Page的Load事件 與&nbsp; PostBack（回傳）-- <span class="auto-style1">錯誤版</span><br />
        <br />
        <br />
        請輸入您的姓名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        <br />
           <asp:Label ID="Label1" runat="server" style="font-weight: 700; font-size: xx-large; color: #FF0000"></asp:Label>
        <br />
        <br />
        <br />
        (1)&nbsp;
        Page_Load事件裡面，已經事先寫好預設值。<br />
        <strong>TextBox1.Text = &quot;李小明&quot;</strong><br />
        <br />
        (2)
        重點來了！當您<strong>修改名字以後</strong>，按下 Button按鈕，<br />
        <br />
        為何還是出現 &quot;李小明&quot;？？？<br />
        為何沒有出現您寫的名字？？
 

    </div>
    </form>
</body>
</html>
