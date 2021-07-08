<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sender_Page_Load.aspx.cs" Inherits="Book_Sample_Ch03_WebControls_sender_Page_Load" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        資料來源：<a href="http://geekswithblogs.net/mahesh/archive/2006/06/27/83264.aspx">http://geekswithblogs.net/mahesh/archive/2006/06/27/83264.aspx</a>
        <br />
        <br />
        在 Page_Load事件裡面，如何知道哪個Web控制項被按下？<br /><br />
        <asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button1" />
        <br /><br />
        <asp:LinkButton ID="LinkButton2" runat="server" Text="Button2" />
        <br /><br />
        <asp:Button ID="Button3" runat="server" Text="Button3" />
        <br />                    
    </div>

    </form>
</body>
</html>
