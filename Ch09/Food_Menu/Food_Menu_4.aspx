<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Food_Menu_4.aspx.cs" Inherits="Book_Sample_B06_DataBinding_Food_Menu_Food_Menu_4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #FF0000;
            background-color: #FFCCFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        讓您瞭解 <strong>DataBinding的時機，由電腦掌控？或是<span class="style1">自己寫程式掌控？</span></strong>有何差異？<br />
        <br />
        <br />
        食物種類：
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
            DataTextField="food_name" DataValueField="id">
        </asp:DropDownList>
        （請使用 AutoPostBack）
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
            SelectCommand="SELECT DISTINCT [food_name], [id] FROM [Food_Menu]"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <hr />
        挑選之後，可以編輯（修改）：<br />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
            CellPadding="4" DataKeyNames="id"
            DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Height="50px"
            Width="551px">
            <AlternatingRowStyle BackColor="White" />
            <CommandRowStyle BackColor="#D1DDF1" Font-Bold="True" />
            <EditRowStyle BackColor="#2461BF" />
            <FieldHeaderStyle BackColor="#DEE8F5" Font-Bold="True" />
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True"
                    SortExpression="id">
                    <HeaderStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="food_name" HeaderText="food_name(食物名稱)" SortExpression="food_name" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:testConnectionString %>"
            SelectCommand="SELECT * FROM [Food_Menu] WHERE ([id] = @id)" UpdateCommand="UPDATE [Food_Menu] SET [food_name] = @food_name WHERE [id] = @id" OnUpdated="SqlDataSource2_Updated">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="id" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="food_name" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </form>
    <p>
        需撰寫&nbsp; 後置程式碼！---- <span class="style1">SqlDataSource2_Updat<strong>ed</strong>事件</span></p>
</body>
</html>
