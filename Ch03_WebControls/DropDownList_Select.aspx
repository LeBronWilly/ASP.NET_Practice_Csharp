<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDownList_Select.aspx.cs" Inherits="Book_Sample_Ch03_HTML_Web_DropDownList_Select" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
	<select id="Select1" name="D1" runat="server">
		<option>M.Benz</option>
		<option>BMW</option>
		<option>Toyota</option>
		<option>Honda</option>
	</select>
		<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
		<br />
		<br />
    </form>
	</body>
</html>
