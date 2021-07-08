<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_2_DataSet_Manual_Tables02.aspx.cs" Inherits="Ch10_Default_2_DataSet_Manual" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        使用ADO.NET 的 <span style="color: #0033cc; background-color: #ffff33">SqlDataAdapter /
            DataSet</span>。<br />
        Code Behind 完全手寫
        <br />
        ---------------------------------------------------------------------------------<br />
        <br />
        <span class="auto-style1"><strong>一個 DataSet裡面，有兩個 DataTable</strong></span><strong><br class="auto-style1" />
        </strong><span class="auto-style1"><strong>只要執行兩段 Select的SQL指令即可！<br />
        <br />
        透過TableMappings.Add()方法，設定DataTable的「名稱」</strong></span><br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" Font-Size="Small"
            ForeColor="#333333" GridLines="None" PageSize="5" DataKeyNames="id"  >
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#E3EAEB" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

        <br />
        <br />

    </div>
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" Font-Size="Small"
            ForeColor="Black" GridLines="Horizontal" PageSize="5" DataKeyNames="id" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"  >
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>

    </form>

</body>
</html>
