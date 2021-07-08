<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    var pageIndex = 1;
    var pageCount;
    $(window).scroll(function () {
        if ($(window).scrollTop() == $(document).height() - $(window).height()) {
            GetRecords();
        }
    }); 
    function GetRecords() {
        pageIndex++;
        if (pageIndex == 2 || pageIndex <= pageCount) {
            $("#loader").show();
            $.ajax({
                type: "POST",
                url: "CS.aspx/GetCustomers",
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
        pageCount = parseInt(xml.find("PageCount").eq(0).find("PageCount").text());
        var customers = xml.find("Customers");
        customers.each(function () {
            var customer = $(this);
            var table = $("#dvCustomers table").eq(0).clone(true);
            $(".name", table).html(customer.find("ContactName").text());
            $(".city", table).html(customer.find("City").text());
            $(".postal", table).html(customer.find("PostalCode").text());
            $(".country", table).html(customer.find("Country").text());
            $(".phone", table).html(customer.find("Phone").text());
            $(".fax", table).html(customer.find("Fax").text());
            $("#dvCustomers").append(table).append("<br />");
        });
        $("#loader").hide();
    }
</script>
</head>
<body style="font-family: Arial; font-size: 10pt">
    <form id="form1" runat="server">
<table>
<tr><td>
    <div id="dvCustomers">
        <asp:Repeater ID="rptCustomers" runat="server">
            <ItemTemplate>
                <table cellpadding="2" cellspacing="0" border="1" style="width: 200px; height: 100px;
                border: dashed 2px #04AFEF; background-color: #B0E2F5">
                <tr>
                    <td>
                        <b><u><span class="name">
                            <%# Eval("ContactName") %></span></u></b>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>City: </b><span class="city"><%# Eval("City") %></span><br />
                        <b>Postal Code: </b><span class="postal"><%# Eval("PostalCode") %></span><br />
                        <b>Country: </b><span class="country"><%# Eval("Country")%></span><br />
                        <b>Phone: </b><span class="phone"><%# Eval("Phone")%></span><br />
                        <b>Fax: </b><span class="fax"><%# Eval("Fax")%></span><br />
                    </td>
                </tr>
            </table>
            <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</td>
<td valign="bottom">
    <img id="loader" alt="" src="loading.gif" style="display: none" />
</td>
</tr>
</table>
    </form>
</body>
</html>
