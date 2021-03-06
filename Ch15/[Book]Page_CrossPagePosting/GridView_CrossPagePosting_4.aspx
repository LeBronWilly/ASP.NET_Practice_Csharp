<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridView_CrossPagePosting_4.aspx.cs" Inherits="Book_Sample_Ch15__Book_Page_CrossPagePosting_GridView_CrossPagePosting_4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>第二組（範例 3 / 4 ）</title>
    <style type="text/css">
        .auto-style1 {
            background-color: #FF99FF;
        }
        .auto-style2 {
            background-color: #CCFF99;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            上一頁傳來的資料，需要修改<br />
            <br />
            <strong><span class="auto-style1">這一頁等同於 範例 Page_1.aspx 與 Page_3.aspx</span></strong><br />
            <br />
            <br />
            <br />
            test_time欄位 :
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            title欄位 :&nbsp; 
        <asp:TextBox ID="TextBox2" runat="server" Width="400px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" PostBackUrl="GridView_CrossPagePosting_3.aspx" 
                Text="Button_修改後，跨網頁張貼。回到原本的網頁" />

            <br />
            <br />
            修改之後的資料，將「跨網頁張貼」傳回<strong>原本的 GridView_CrossPagePosting_3.aspx</strong><span class="auto-style2"><strong>（等同於範例 Page_2.aspx與 Page_4.aspx）</strong></span>
        </div>
    </form>
</body>
</html>
