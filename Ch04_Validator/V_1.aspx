<%@ Page Language="C#" AutoEventWireup="true" CodeFile="V_1.aspx.cs" Inherits="Ch04_Validator_V_1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RequiredField(�������)</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        RequiredField(�������)<br />
        <br /><br /><br />
        �п�J�����r�G<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox1" ErrorMessage="RequiredFieldValidator�A���i�d�ťաI" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />

        
        
        <asp:Button ID="Button1" runat="server" Text="Submit / �e�X" />
    
    </div>
    </form>
 
</body>
</html>
