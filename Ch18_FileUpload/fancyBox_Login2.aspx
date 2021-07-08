<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fancyBox_Login2.aspx.cs" Inherits="Book_Sample_Ch18_FileUpload_fancyBox_Login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>請搭配 fancyBox一號範例</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        帳號：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        密碼：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br /><br />
        
        <asp:Button ID="Button1" runat="server" Text="ASP_NET的Button_會員登入" OnClick="Button1_Click" />
        <br /><br />

        <button>傳統HTML按鈕，這種寫法也會觸發PostBack</button>
        <br /><br />

        <input type="button" value="傳統HTML按鈕 -- OK" />
    
    </div>
    </form>
</body>
</html>
