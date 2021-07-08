<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridView_Delete_MultiRow_6_PreRender.aspx.cs" Inherits="Book_Sample_Ch10_GridView_Delete_MultiRow_6_PreRender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <style type="text/css">
        .style1
        {
            color: #009900;
            background-color: #FFFF00;
        }
        .style2
        {
            color: #FF0000;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <p>
        批次刪除&nbsp; 多筆資料&nbsp;&nbsp; #6<strong><span class="style1">（分頁 / GridView _PreRender事件）</span></strong></p>
    <p>
        &nbsp;</p>
    <p>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" 
            PageSize="5" CellPadding="4" GridLines="Horizontal" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" OnPreRender="GridView1_PreRender">
            <Columns>
                <asp:TemplateField HeaderText="id(勾選,可刪除)" InsertVisible="False" SortExpression="id">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                        &nbsp;
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                    <ItemStyle BackColor="#CCFF99" />
                </asp:TemplateField>

                <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" DataFormatString="{0:d}" />
                <asp:BoundField DataField="class" HeaderText="class" SortExpression="class" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="summary" HeaderText="summary" SortExpression="summary" />
                <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#333333" />
            <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#487575" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#275353" />
        </asp:GridView>
        
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:testConnectionString %>" 
            SelectCommand="SELECT * FROM [test]"></asp:SqlDataSource>
    </p>
        <p class="style2">請點選「要刪除的」的資料後，務必按下按鈕！</p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="把勾選的那幾筆資料，刪除掉！" OnClick="Button1_Click" />
        </p>
        <p>&nbsp;</p>
    <p>您想刪除的那幾列（主索引鍵，P.K.）為：<asp:Label ID="Label2" runat="server"style="color: #990033"></asp:Label>
    </p>
    <div>
    
    </div>
    </form>
</body>
</html>
