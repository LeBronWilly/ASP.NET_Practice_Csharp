<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Homework_Day_01.aspx.cs" Inherits="HomeWork_Day_01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #CC00CC;
            font-size: x-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <span class="auto-style1"><strong>XYZ Corp.</strong></span><br />
        <br />
        Name :<asp:TextBox ID="txtName" runat="server" required title="請輸入姓名" OnTextChanged="txtName_TextChanged"></asp:TextBox>
        <br />
        =================================================<br />
        <br />
        BirthDay :<asp:TextBox ID="txtBirthDay" runat="server" required ReadOnly="True"></asp:TextBox>
        &nbsp;(唯讀 / ReadOnly)<br />
        <br />
        Year :
        <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
        </asp:DropDownList>
        Month :<asp:DropDownList ID="ddlMonths" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonths_SelectedIndexChanged">
        </asp:DropDownList>
        Day :<asp:DropDownList ID="ddlDays" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDays_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;(三個下拉式選單，均有設定AutoPostBack)<br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
        <br />
        Sex<br />
        <asp:RadioButtonList ID="rblSex" runat="server">
            <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
            <asp:ListItem Value="2">女</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        Education<br />
        <asp:CheckBoxList ID="cblEducation" runat="server">
            <asp:ListItem Value="1">國小</asp:ListItem>
            <asp:ListItem Value="2">國中</asp:ListItem>
            <asp:ListItem Value="3">高中職</asp:ListItem>
            <asp:ListItem Value="4">大學大專</asp:ListItem>
        </asp:CheckBoxList>
        =================================================<br />
        <br />
            Account 帳號 :<asp:TextBox ID="txtAccount" runat="server" required></asp:TextBox>
            <br />
            <br />
            New Password 密碼 :<asp:TextBox ID="txtNewPassword" runat="server" required TextMode="Password"></asp:TextBox>
            <br />
            <br />
            Confirm Password
        <br />
        密碼 再次確認 :<asp:TextBox ID="txtConfirmPassword" runat="server" required OnTextChanged="txtConfirmPassword_TextChanged" TextMode="Password"></asp:TextBox>
            <asp:Label ID="labCheckPassword" runat="server" ForeColor="#CC33FF"></asp:Label>
            <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    <div>
        <br />        

        <asp:Panel ID="Panel1" runat="server" Visible="False">
            Name :    <asp:Label ID="labName" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
            <br />
            BirthDay :   <asp:Label ID="labBirthDay" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
            <br />
            Sex :   <asp:Label ID="LabSex" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
            <br />
            Education :   <asp:Label ID="LabEducation" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
            <br />
            Account :   <asp:Label ID="LabAccount" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
