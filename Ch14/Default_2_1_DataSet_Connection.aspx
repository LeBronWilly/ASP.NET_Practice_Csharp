<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_2_1_DataSet_Connection.aspx.cs" Inherits="Book_Sample_Ch14_Default_2_1_DataSet_Connection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .style1
        {
            font-weight: bold;
            color: #CCFFFF;
            background-color: #000099;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <span class="style1">測試 DataSet -- 「離線（非連線，Disconnect）」的資料存取</span><br />

    </div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
        CellPadding="4" DataKeyNames="id" ForeColor="Black" GridLines="Horizontal"
        OnPageIndexChanging="GridView1_PageIndexChanging">
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    </form>
</body>
</html>
