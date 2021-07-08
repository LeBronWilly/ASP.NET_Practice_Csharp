<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDownList_PostBack_Calculator.aspx.cs" Inherits="Book_Sample_Ch03_WebControls_DropDownList_PostBack_Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        問題源自&nbsp; <a href="http://www.blueshop.com.tw/board/FUM20041006161839LRJ/BRD201612072235585RY.html">http://www.blueshop.com.tw/board/FUM20041006161839LRJ/BRD201612072235585RY.html</a><br />
        <br />
        各位大大好，假設我只有一個dropdownlist、label、button 
        <br />
        接下來就是依照dropdownlist所選的數字用label依序顯示，<br />
        <br />
        最後按下button將所選到的數字做相加 
        <br />
        <br />
        &lt;asp:DropDownList ID="DropDownList1" runat="server"><br />
            &nbsp; &nbsp; &lt;asp:ListItem value="0">-----請選擇-----&lt;/asp:ListItem><br />
            &nbsp; &nbsp; &lt;asp:ListItem value="1">數字1&lt;/asp:ListItem><br />
            &nbsp; &nbsp; &lt;asp:ListItem value="2">數字2&lt;/asp:ListItem><br />
            &nbsp; &nbsp; &lt;asp:ListItem value="3">數字3&lt;/asp:ListItem><br />
            &nbsp; &nbsp; &lt;asp:ListItem value="4">數字4&lt;/asp:ListItem><br />
            &nbsp; &nbsp; &lt;asp:ListItem value="5">數字5&lt;/asp:ListItem><br />
        &lt;/asp:DropDownList>
        <br />
        <br />
        <strong>ex:我選了數字1和數字2及數字3，計算出1+2+3=6
        <br />
        </strong>
        <br />        <hr />        
        <br />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem value="0">-----請選擇-----</asp:ListItem>
            <asp:ListItem value="1">數字1</asp:ListItem>
            <asp:ListItem value="2">數字2</asp:ListItem>
            <asp:ListItem value="3">數字3</asp:ListItem>
            <asp:ListItem value="4">數字4</asp:ListItem>
            <asp:ListItem value="5">數字5</asp:ListItem>
        </asp:DropDownList>
    &nbsp;&nbsp; (AutoPostBack)<br />
        <br />
        <br />
        目前累加的結果：<asp:Label ID="Label1" runat="server" style="color: #0066FF">0</asp:Label>
        <br />
        <br />
            <asp:Label ID="Label3" runat="server" style="font-weight: 700; color: #00CC00"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
        <p>
            <asp:Label ID="Label2" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
        </p>
    </form>
</body>
</html>
