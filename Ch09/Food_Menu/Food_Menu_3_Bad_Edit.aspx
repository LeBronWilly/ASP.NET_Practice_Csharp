<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Food_Menu_3_Bad_Edit.aspx.cs" Inherits="Book_Sample_B06_DataBinding_Food_Menu_Food_Menu_3_Bad_Edit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .style1 {
            background-color: #FFFF66;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    
        讓您瞭解 <strong>DataBinding的時機，<span class="style1">由電腦掌控？</span>或是自己寫程式掌控？</strong>有何差異？<br />
        <br />
        <br />
        食物種類：
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="SqlDataSource1" DataTextField="food_name" 
            DataValueField="id">
        </asp:DropDownList> （請使用 AutoPostBack）
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:testConnectionString %>" 
            SelectCommand="SELECT DISTINCT [food_name], [id] FROM [Food_Menu]">
        </asp:SqlDataSource>
        
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
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSource2" 
            ForeColor="Black" GridLines="Vertical" Height="50px" Width="551px">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <Fields>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                    ReadOnly="True" SortExpression="id">
                <HeaderStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="food_name" HeaderText="food_name(食物名稱)" 
                    SortExpression="food_name" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:testConnectionString %>" 
            SelectCommand="SELECT * FROM [Food_Menu] WHERE ([id] = @id)" 
            UpdateCommand="UPDATE [Food_Menu] SET [food_name] = @food_name WHERE [id] = @id">

            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="id" 
                    PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>

                <asp:Parameter Name="food_name" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
