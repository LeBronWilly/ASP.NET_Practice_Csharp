<%@ Page Language="C#" AutoEventWireup="true" CodeFile="2_GridView_jQuery_Error.aspx.cs" Inherits="Book_Sample_GridView_jQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        var pageIndex = 1;
        var pageCount;

        //**************************************************
        $(window).scroll(function () {
            if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                GetRecords();   //計算視窗高度（Scroll Bar）被拉到下面就會啟動！展示更多記錄。
            }
        }); 
        //**************************************************

        function GetRecords() {
            pageIndex++;
            if (pageIndex == 2 || pageIndex <= pageCount) {
                $("#loader").show();
                $.ajax({
                    type: "POST",
                    url: "2_GridView_jQuery_Error.aspx/GetNewRecord",     // *** 記得修改檔名 ***
                    data: '{pageIndex: ' + pageIndex + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    },
                    error: function (response) {
                        alert(response.d);
                    }
                });
            }
        }
        function OnSuccess(response) {
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            pageCount = parseInt(xml.find("DT_PageCount").eq(0).find("Field_PageCount").text());
            //**************************************************************
            var customers = xml.find("test");   
            // Web Service傳回的XML文件，DataSet裡面的DataTable名稱

            customers.each(function () {
                var customer = $(this);
                //***********************************************************
                var table = $("#dvCustomers table").eq(0).clone(true);
                // 複製 HTML畫面上的<table>，所以GridView有十筆紀錄。後續jQuery產生的，也會有十筆紀錄
                //***********************************************************

                // GridView裡面每一筆記錄的「欄位」，都會有一個<span class="...">
                $(".X_id", table).html(customer.find("id").text());
                $(".X_test_time", table).html(customer.find("test_time").text());
                $(".X_title", table).html(customer.find("title").text());

                $("#dvCustomers").append(table).append("<br />XXXXXXXXXXXX<br />");
                // 畫出下一個表格<table>
            });
            $("#loader").hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

    <div id="dvCustomers">  <!-- ************ -->

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id" GridLines="Vertical" Width="388px">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:TemplateField HeaderText="id" InsertVisible="False" SortExpression="id">
                            <ItemTemplate>
                                <!-- jQuery會對應這個<span class="...">來操作，也就是每個欄位的 CssClass -->
                                <asp:Label ID="Label1" runat="server" CssClass="X_id" Text='<%# Bind("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="test_time" SortExpression="test_time">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" CssClass="X_test_time" Text='<%# Bind("test_time") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="title" SortExpression="title">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" CssClass="X_title" Text='<%# Bind("title") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" Height="100px" />
                </asp:GridView>
                <br />


                ******************************************************************<br />
    </div>

    <img id="loader" alt="" src="loading.gif" style="display: none" />
    <!-- 動畫小圖示，載入資料時會出現 -->


    </form>
</body>
</html>
