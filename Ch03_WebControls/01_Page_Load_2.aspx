<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01_Page_Load_2.aspx.cs" Inherits="Book_Sample_Ch03_WebControls_01_Page_Load_2" %>

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
        (1)&nbsp;
        後置程式碼 -- Page的Load事件裡面，已經事先寫好預設值。<br />
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; TextBox1.Text = &quot;李小明&quot;</strong><br />
        <br />
        (2)
        重點來了！當您<strong>修改名字以後</strong>，按下 Button按鈕，<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        為何還是出現 &quot;李小明&quot;？？？<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        為何沒有出現您寫的名字？？<br />
        <br />
        (3)&nbsp; Page的Load事件裡面，加上 <strong class="auto-style1">if (!Page.IsPostBack) </strong>這一段程式，就能解決</div>
    </form>
</body>
</html>
