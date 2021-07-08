<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_01_CSS.aspx.cs" Inherits="Book_Sample_Ch11_jQuery_GridView_Header_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>將 您 的 表 格 或 GridView 固 定 標 題 列 與 凍 結 欄 位</title>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.0/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.9.1/jquery-ui.min.js"></script>
    <script type="text/javascript" src="gridviewScroll.min.js"></script>
    <link href="GridviewScroll.css" rel="stylesheet" />
        <script type="text/javascript">
	    $(document).ready(function () {
	        gridviewScroll();
	    });
	
	    function gridviewScroll() {
	        gridView1 = $('#GridView1').gridviewScroll({
                width: 600,
                height: 300,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 1,
                arrowsize: 30,
                varrowtopimg: "Images/arrowvt.png",
                varrowbottomimg: "Images/arrowvb.png",
                harrowleftimg: "Images/arrowhl.png",
                harrowrightimg: "Images/arrowhr.png",
                headerrowcount: 3,     /* 表頭（標題欄位）要鎖定3列 */
                railsize: 16,
                barsize: 8
            });
	    }
	</script>

    <style type="text/css">
        .auto-style1 {
            color: #FF0000;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        原作：&nbsp; <a href="http://gridviewscroll.aspcity.idv.tw/">http://gridviewscroll.aspcity.idv.tw/</a><br />
        將 您 的 表 格 或 GridView 固 定 標 題 列 與 凍 結 欄 位<br />
        <br />
        簡單作法：<br />
        直接設定「表頭列（HeaderStyle）」與「資料列（RowStyle）」，加入<span class="auto-style1"><strong>CssClass屬性</strong></span>即可！！<br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="test_time" HeaderText="test_time" SortExpression="test_time" />
                <asp:BoundField DataField="title" HeaderText="title" SortExpression="title" />
                <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
            </Columns>
            
            <HeaderStyle CssClass="GridviewScrollHeader" />
            <RowStyle CssClass="GridviewScrollItem" />

        </asp:GridView>   <!-- ** 重點在上面兩段 CssClass  ******************  -->


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:testConnectionString %>" 
            SelectCommand="SELECT top 100 [id], [test_time], [title], [author] FROM [test]"></asp:SqlDataSource>
        <br />
    
    </div>
    </form>
</body>
</html>
