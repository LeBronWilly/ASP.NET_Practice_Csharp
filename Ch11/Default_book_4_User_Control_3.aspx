<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_book_4_User_Control_3.aspx.cs" Inherits="Ch11_Default_book_4_User_Control_3" %>

<!--  '因為在程式的後置程式碼，動態載入UC。所以底下這一列可以刪除，也能正常執行。 -->
<%@ Register TagPrefix="MIS2000Lab" TagName="DataGrid2" Src="Default_book_4_UserControl_2.ascx"  %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>大腸包小腸 #1</title>
    <style type="text/css">
        .style1
        {
            font-size: large;
            font-weight: bold;
        }
        .style2
        {
            text-decoration: underline;
            color: #FF0000;
            font-size: small;
        }
    #res h3{display:inline}.r{font-size:medium}.r{display:inline;font-weight:normal;margin:0}h3{font-size:medium;font-weight:normal;padding:0;margin:0}
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span class="style1">大腸包小腸（單一GridView的Master-Detail功能）</span><br />
        &nbsp;&nbsp;&nbsp; 大的GridView用來展示 Master<br />
        &nbsp;&nbsp;&nbsp; 裡面包含一個小的GridView（使用者控制項），用來展示Detail<br />
        <br />
        <span class="style2">本範例的分頁、排序都會出現一些怪狀況∼&nbsp; 下一支程式才能解決。</span><br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id"
            DataSourceID="SqlDataSource1" Font-Size="Small" GridLines="Horizontal" AllowPaging="True"
            AllowSorting="True" AutoGenerateSelectButton="True" PageSize="5" OnRowCreated="GridView1_RowCreated"
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id">
                    <ItemStyle Font-Bold="True" ForeColor="Red" />
                </asp:BoundField>
                <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time"
                    DataFormatString="{0:d}">
                    <ItemStyle ForeColor="Blue" />
                </asp:BoundField>
                <asp:BoundField DataField="title" HeaderText="title（文章標題）" SortExpression="title">
                    <ItemStyle Font-Bold="True" Font-Size="Medium" ForeColor="Navy" />
                </asp:BoundField>
                <asp:BoundField DataField="summary" HeaderText="summary(摘要)" SortExpression="summary">
                    <ItemStyle ForeColor="Orange" />
                </asp:BoundField>
            </Columns>
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" Font-Bold="True" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
            DeleteCommand="DELETE FROM [test] WHERE [id] = @id" InsertCommand="INSERT INTO [test] ([test_time], [title], [summary]) VALUES (@test_time, @title, @summary)"
            SelectCommand="SELECT [id], [test_time], [title], [summary] FROM [test]" UpdateCommand="UPDATE [test] SET [test_time] = @test_time, [title] = @title, [summary] = @summary WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="test_time" Type="DateTime" />
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="summary" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="test_time" Type="DateTime" />
                <asp:Parameter Name="title" Type="String" />
                <asp:Parameter Name="summary" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <br />
        <br />
        <p align="right">
            本範例原始構想，出自黃忠成老師的大作 -- <a href="http://www.microsoft.com/taiwan/msdn/columns/huang_jhong_cheng/ASP_NET_GridView.htm">
                ASP.NET 2.0 GridView 範例集</a>
            <br />
            黃老師的作品難度偏高，因而改寫（濃縮）成本範例。
        </p>
    </div>
    </form>
</body>
</html>
