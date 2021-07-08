<%@ Page Language="C#" debug="true" AutoEventWireup="true" CodeFile="GridView_Delete_MultiRow_4_Page.aspx.cs" Inherits="Book_Sample_Ch10_GridView_Delete_MultiRow_4_Page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>批次刪除多筆資料 #4 （分頁，RowDataBound事件）</title>
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
        批次刪除&nbsp; 多筆資料&nbsp;&nbsp; #4<strong><span class="style1">（分頁 / RowDataBound事件）</span></strong></p>
    <p>
        &nbsp;</p>
    <p>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" 
            PageSize="5" CellPadding="4" ForeColor="#333333" GridLines="None" 
            onpageindexchanging="GridView1_PageIndexChanging" 
            onrowdatabound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField HeaderText="id(勾選,可刪除)" InsertVisible="False" 
                    SortExpression="id">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                        &nbsp;
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="test_time" HeaderText="test_time" 
                    SortExpression="test_time" DataFormatString="{0:d}" />
                <asp:BoundField DataField="class" HeaderText="class" SortExpression="class" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="summary" HeaderText="summary" 
                    SortExpression="summary" />
                <asp:BoundField DataField="author" HeaderText="author" 
                    SortExpression="author" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:testConnectionString %>" 
            SelectCommand="SELECT * FROM [test]"></asp:SqlDataSource>
    </p>
        <p class="style2">
            請點選「要刪除的」的資料後，務必按下按鈕！
        </p>
        <p class="style2">
            ......如果不想按下Button，改用「分頁」就直接記錄，請把Button_Click事件的程式，移到GridViw的 &quot;分頁&quot;事件裡面即可</p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="把勾選的那幾筆資料，刪除掉！" OnClick="Button1_Click" />
        </p>
        <p>
            &nbsp;</p>
    <p>
        您想刪除的那幾列（主索引鍵，P.K.）為：<asp:Label ID="Label2" runat="server" 
            style="color: #990033"></asp:Label>
    </p>
    <div>
    
    </div>
    </form>
</body>
</html>

