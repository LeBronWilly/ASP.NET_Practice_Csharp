<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckBoxList_2.aspx.cs" Inherits="Book_Sample_B11_CaseStudy_Vote_CheckBoxList_2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>點選下面的 CheckBoxList（複選），答對了才能得分！</title>
    <style type="text/css">
        .style1
        {
            color: #FF0000;
            font-weight: bold;
            background-color: #FFFF00;
        }
        .auto-style1 {
            color: #0066FF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <b><span class="auto-style1">將後置程式碼重複的部分，改成「副程式」</span><br />
        <br />
        <br />
        <br />
        點選下面的 CheckBoxList（複選），</b><span class="style1">答對了才能得分！<br />
        </span><br />
        <br />
        請問市面上最適合初學者入門的「ASP.NET」書籍是哪一本？<asp:Label ID="Label1" runat="server" ></asp:Label>
        &nbsp;
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem Value="3"><b>文魁出版，書號P8187，「ASP.NET專題實務」</b></asp:ListItem>
            <asp:ListItem Value="0">電腦入門？！</asp:ListItem>
            <asp:ListItem Value="0">洋蔥頭的「腦殘檢定」？！</asp:ListItem>
        </asp:CheckBoxList>
    
    <hr />
        <br />
        請問文魁出版的「ASP.NET專題實務」封面畫了什麼圖片？<asp:Label ID="Label2" runat="server" ></asp:Label>
        &nbsp;
        <asp:CheckBoxList ID="CheckBoxList2" runat="server">
            <asp:ListItem Value="0">米老鼠與唐老鴨？！</asp:ListItem>
            <asp:ListItem Value="3"><b>天使，而且拿了寶劍！</b></asp:ListItem>
            <asp:ListItem Value="0">Keroro軍曹？！</asp:ListItem>
        </asp:CheckBoxList>    
    
    <hr />
        <br />
        「ASP.NET專題實務」將會推出哪兩種語言的版本？<asp:Label ID="Label3" runat="server"></asp:Label>
        &nbsp;
        <asp:CheckBoxList ID="CheckBoxList3" runat="server">
            <asp:ListItem Value="3"><b>C#語法</b></asp:ListItem>
            <asp:ListItem Value="3"><b>VB語法</b></asp:ListItem>
            <asp:ListItem Value="0">JAVA語法？！</asp:ListItem>
        </asp:CheckBoxList>        
    <hr />
    
        <br />
        <asp:Button ID="Button1" runat="server" Text="計算總分" onclick="Button1_Click" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;
        「總分」：<asp:Label ID="Label_summary" runat="server" style="color: #FF0000"></asp:Label>
    
    </div>
    </form> 
</body>
</html>
