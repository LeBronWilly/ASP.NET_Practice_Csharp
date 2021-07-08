<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Repeater_ViewState_02.aspx.cs" Inherits="Ch12_ListView_Repeater" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #009900;
        }
        .auto-style2 {
            color: #0066FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
            <HeaderTemplate>
                <div align="center">
            </HeaderTemplate>

            <ItemTemplate>
                <asp:Panel runat="server" EnableViewState="false">

                    <small>流水號： <%# Container.ItemIndex%> </small> &nbsp;&nbsp;&nbsp;&nbsp;
                    <%# DataBinder.Eval(Container.DataItem, "id")%>  &nbsp;&nbsp;&nbsp;&nbsp;
                    <b><%# DataBinder.Eval(Container.DataItem, "title")%> </b>
                    <hr />

                </asp:Panel>
            </ItemTemplate>

            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
            SelectCommand="SELECT [id],[title], [summary] FROM [test]"></asp:SqlDataSource>

    </div>


    </form>

    <p>
        資料來源：<a href="http://blog.miniasp.com/post/2008/11/29/Using-PlaceHolder-to-reduce-ViewState-size.aspx">http://blog.miniasp.com/post/2008/11/29/Using-PlaceHolder-to-reduce-ViewState-size.aspx</a>&nbsp;
    </p>
    <p>
        &nbsp;</p>
    <p class="auto-style2">
        &nbsp;直接<strong>「關閉」Repeater</strong>的 EnableViewState屬性</p>
    <p>
        <span class="auto-style2">&lt;input id="__VIEWSTATE" name="__VIEWSTATE" type="hidden" value="P77bDFs4Xl5CDJGbNVSXJjHOThjXDSa+D4OuYjPmXUxhekG9+5dxWzc3LH8FTKkrbOndTBwuq4wtnWxITJ1BsnkqlYd5o0e42Kyx32eab+nKQT4YtdpeVuzTqmkTcjzK2vurT71XCFO+zPZMhZbCSA==" /></span> </p>
    <p>
        或是</p>
    <p class="auto-style1">
        在&lt;ItemTemplate&gt;裡面加入 &lt;asp:Panel <strong>EnableViewState=&quot;False&quot;</strong>&gt;有何差異？</p>
    <p class="auto-style1">
        <strong>Panel比起PlaceHolder（請看下一個範例的比較），ViewState的內容較短！</strong></p>
    <p class="auto-style1">
        &lt;input id="__VIEWSTATE0" name="__VIEWSTATE" type="hidden" value="oQXbJVFkhHSubJhFUNGq9xjPDLGdXOvK+oG0QiK6fWPAAzJLHt40x4dUZU4nNTurOmff9705vIx4wqdlA6x4gNrZfEZoixyzAMo7Km3+3Qo=" /> </p>
    

</body>
</html>
