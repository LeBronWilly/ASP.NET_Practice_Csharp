<%@ Page Language="C#" AutoEventWireup="true" CodeFile="01_AutoPostBack_False.aspx.cs" Inherits="Book_Sample_Ch03_WebControls_01_AutoPostBack_False" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        欄位一： 
        <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged">預設值</asp:TextBox>
        &nbsp; (設定 AutoPostBack=&quot;False&quot; 。) 畫面上改用Button按鈕來作 Submit
        
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
