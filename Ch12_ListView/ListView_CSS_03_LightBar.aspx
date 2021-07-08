<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListView_CSS_03_LightBar.aspx.cs" Inherits="Book_Sample_Ch12_ListView_ListView_CSS_Easy" %>

<!-- HTML5不支援此效果，請不要在上方加上<!DOCTYPE html>字樣  -->
<!-- HTML5不支援此效果，請不要在上方加上<!DOCTYPE html>字樣  -->
<!-- HTML5不支援此效果，請不要在上方加上<!DOCTYPE html>字樣  -->

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <title>[光棒]滑鼠指向變色的表格_JavaScript光棒效果</title>
    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        沿用 GridView範例（JavaScript_光棒效果）<br />
        <br />
        <strong>1.&nbsp; HTML<span class="auto-style1">5</span>不支援此效果，請不要在上方加上<span class="auto-style1">&lt;!DOCTYPE html&gt;</span>字樣<br />
        2.&nbsp; &lt;td&gt;不可以加上 runat=&quot;server&quot;字樣，否則會將單引號( &#39; )重新編碼，導致效果出不來。<br />
        <br />
        </strong>
        <br />
        ListView搭配JavaScript<br />
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="id" DataSourceID="SqlDataSource1" GroupItemCount="3">
            <AlternatingItemTemplate>
                <td onmouseover="this.style.backgroundColor='ffc080'" onmouseout="this.style.backgroundColor='ffffff'">id:
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                    <br />test_time:
                    <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                    <br />title:
                    <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    <br /></td>
            </AlternatingItemTemplate>

            <EmptyDataTemplate>
                <table runat="server">
                    <tr>
                        <td>未傳回資料。</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <EmptyItemTemplate>
                   <td runat="server" />
            </EmptyItemTemplate>
            <GroupTemplate>
                <tr id="itemPlaceholderContainer" runat="server">
                    <td id="itemPlaceholder" runat="server"></td>
                </tr>
            </GroupTemplate>

            <ItemTemplate>
                <td onmouseover="this.style.backgroundColor='ffc080'" onmouseout="this.style.backgroundColor='ffffff'">id:
                    <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
                    <br />test_time:
                    <asp:Label ID="test_timeLabel" runat="server" Text='<%# Eval("test_time") %>' />
                    <br />title:
                    <asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' />
                    <br /></td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="groupPlaceholderContainer" runat="server" border="1">
                                <tr id="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>

        </asp:ListView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>" SelectCommand="SELECT [id], [test_time], [title] FROM [test]"></asp:SqlDataSource>
        <br />
    
    </div>
    </form>
</body>
</html>
