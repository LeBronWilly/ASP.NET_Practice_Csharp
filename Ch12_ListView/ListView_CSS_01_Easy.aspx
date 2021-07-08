<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListView_CSS_01_Easy.aspx.cs" Inherits="Book_Sample_Ch12_ListView_ListView_CSS_Easy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <title>[光棒]滑鼠指向變色的表格_CSS_jQuery</title>

    <style type="text/css">
            .table-hover > tbody > tr:hover > td,
            .table-hover > tbody > tr:hover > th {
              background-color: #f5f5f5;
            }
   </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        沿用 GridView範例（Default_book_GridView_Light_6_CSS_Easy.aspx）<br />
        <br />
        ListView搭配CSS<br />
        <br />
        <br />
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <AlternatingItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                    </td>
                    <td>
                        <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="更新" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="取消" />
                    </td>
                    <td>
                        <asp:Label ID="idLabel1" runat="server" Text='<%# Eval("id") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="test_timeTextBox" runat="server" Text='<%# Bind("test_time") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="">
                    <tr>
                        <td>未傳回資料。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="插入" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="清除" />
                    </td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="test_timeTextBox" runat="server" Text='<%# Bind("test_time") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="titleTextBox" runat="server" Text='<%# Bind("title") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                    </td>
                    <td>
                        <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="0" style=""
                                class="table-hover">
                                <tr runat="server" style="">
                                    <th runat="server">id</th>
                                    <th runat="server">test_time</th>
                                    <th runat="server">title</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="">
                    <td>
                        <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                    </td>
                    <td>
                        <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                    </td>
                    <td>
                        <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title] FROM [test]"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
