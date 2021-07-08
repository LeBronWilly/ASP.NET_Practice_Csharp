<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostBack_sender.aspx.cs" Inherits="PostBack_sender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <form id="form1" runat="server">
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button1" />
    </p>
        <p>
        <asp:Button ID="Button2" runat="server" OnClick="Button1_Click" Text="Button2 --  UseSubmitBehavior=false" UseSubmitBehavior="false" />
    </p>
    <div>
   
    
    </div>
    </form>
</body>
</html>
