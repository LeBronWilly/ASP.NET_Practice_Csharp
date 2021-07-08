<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostBack_Attribute.aspx.cs" Inherits="PostBack_Attribute" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        function hello() {
            window.alert("Hello! The World!");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="111Value">111</asp:ListItem>
            <asp:ListItem Value="112Value">112</asp:ListItem>
            <asp:ListItem Value="113Value">113（請選我，會出現 JavaScript視窗）</asp:ListItem>
        </asp:DropDownList>
    
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />

        <asp:Button ID="Button1" runat="server" Text="Button1_JavaScript" />

        <asp:Button ID="Button2" runat="server" Text="Button2_Submit" />
    
        
    
    </div>
    </form>
</body>
</html>
