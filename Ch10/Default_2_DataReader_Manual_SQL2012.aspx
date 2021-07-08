<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_2_DataReader_Manual_SQL2012.aspx.cs" Inherits="Book_Sample_Ch10_Default_2_DataReader_Manual" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            background-color: #99FF66;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        使用ADO.NET 的 <span class="auto-style1">SqlCommand / DataReader</span>。<br />
        Code Behind 完全手寫     
        <br />
        <br />
        改用 DataReader來做，您必須<strong>「關閉」GridView分頁功能</strong> (.AllowPaging = false)<br />
        ---------------------------------------------------------------------------------<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" 
            ForeColor="#333333" GridLines="None" PageSize="5" DataKeyNames="id"
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing"
            OnRowUpdating="GridView1_RowUpdating">
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#E3EAEB" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ButtonType="Button" ShowEditButton="True" />
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>

        <br />
        <asp:Label ID="Label1" runat="server" style="font-weight: 700"></asp:Label>
        <br />
        <br />
        使用ADO.NET 的 <span class="auto-style1">SqlCommand / DataReader</span>。<br />
        Code Behind 完全手寫  <br />

    </div>
        <p>  &nbsp;</p>

    </form>

</body>
</html>
