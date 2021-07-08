<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RadioButtonList_TextBox_Validator.aspx.cs" Inherits="Book_Sample_Ch04_Validator_RadioButtonList_TextBox_Validator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        問題：「一個RadioButtonList , 選項分別是A和B<br />
        下方還有一個TextBox,
        <br />
        <br />
        當選擇A時, 若TextBox無輸入任何值,可以放行<br />
        但選擇B時, 如果TextBox是無輸入任何值,則進行驗證(必填)」<br />
        <br />
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="必填欄位" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" /><br />
    
    </div>
    </form>
</body>
</html>
