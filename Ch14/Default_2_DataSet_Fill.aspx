<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_2_DataSet_Fill.aspx.cs" Inherits="Book_Sample_Ch14_Default_2_DataSet_Fill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>兩個Select指令，同時查詢兩個資料表</title>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
        .auto-style2 {
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <p>
        <a href="https://msdn.microsoft.com/zh-tw/library/y4b211hz(v=vs.110).aspx">https://msdn.microsoft.com/zh-tw/library/y4b211hz(v=vs.110).aspx</a>
        <br />
    </p>
    <p>
        當指定的查詢傳回<span class="auto-style1"><strong>多項結果</strong></span>時，會將結果集放置於<span class="auto-style1"><strong>個別資料表</strong></span>中。</p>
    <p>
        將整數值附加到指定的資料表名稱 (例如，&quot;Table&quot;、&quot;Table1&quot;、&quot;Table2&quot; 等等)，即可命名額外的結果集。由於不會針對 &quot;不傳回資料列&quot;的查詢建立資料表，因此，如果您想要處理後面接著選取查詢的插入查詢，則為選取查詢所建立的資料表將命名為 &quot;Table&quot;，因為它是第一個建立的資料表。</p>
    <p>
        ===============================</p>
    <p>
        當我執行這一句SQL指令（用分號「;」串連兩句查詢）會有什麼情況？</p>
    <p>
        Select top 10 * From test<strong><span class="auto-style2">; </span></strong>Select top 10 * from test_talk</p>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <p>
            &nbsp;</p>
        <p>
            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    <div>
    
    </div>
    </form>
</body>
</html>
