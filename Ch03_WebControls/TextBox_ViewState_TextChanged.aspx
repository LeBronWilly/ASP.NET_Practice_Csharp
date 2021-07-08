<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TextBox_ViewState_TextChanged.aspx.cs" Inherits="Book_Sample_Ch02_TextBox_ViewState_TextChanged" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            color: #FF0000;
            font-weight: bold;
        }
        .style2
        {
            color: #0000FF;
            font-weight: bold;
        }
        .style3
        {
            color: #009900;
        }
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        取消&nbsp; TextBox的 ViewState（<span class="style1">EnableViewState屬性 = false</span>）<br />
        將無法判定 
        TextBox裡面的文字是否異動？而無法引發 TextChanged事件。<br />
        <br />
        參考資料： 
        <a href="http://msdn.microsoft.com/zh-tw/library/system.web.ui.control.viewstate.aspx">
        http://msdn.microsoft.com/zh-tw/library/system.web.ui.control.viewstate.aspx</a>
        <br />
        <span class="style3">伺服器控制項的檢視狀態（ViewState）是它<b>全部 [屬性值]</b>的累積。為了在 <b>HTTP 
        要求（Request）之間</b>保留這些值，ASP.NET 
        伺服器控制項使用這個屬性 (StateBag 類別的執行個體) 來儲存屬性值。然後這些值在處理後續的要求（Request）時，會當做變數傳遞給 HTML 
        隱藏輸入項目（如 &lt;input Type=Hidden....&gt;）。</span><br />
        <br />
        <br />
        執行步驟：<br />
        請依照三個步驟來作，並觀看結果。<br />
        <br />
        (1).&nbsp; 同時輸入一些文字，按下 Button按鈕一次。<br />
        <br />
        (2).&nbsp; 同時<strong>刪減</strong>幾個文字，但不要清空文字！ 重新按下 Button按鈕一次。<br />
        <br />
        (3).&nbsp; 不要去改文字了，只管<strong>一直按、重複按 Button</strong>，看看情況變化??<br />
        <br />
        (4).&nbsp; 把文字都「清空」，按下 Button按鈕<br />
&nbsp; <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" EnableViewState="False" 
                    ontextchanged="TextBox1_TextChanged"></asp:TextBox>
        （<span class="style1">EnableViewState屬性 = false</span>）<br />
        <br />
        <asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #FF0000"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp; TextBox裡面的文字（值）在PostBack時，會<strong>從Request來抓取</strong>而後填入TextBox。<br />
&nbsp;&nbsp;&nbsp;&nbsp; 如果跟 ViewState裡面的值<strong>相同</strong>，表示沒有異動（文字沒修改），<strong>不會</strong>觸發TextChanged事件。<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp; 但上面（紅色）已經<span class="auto-style1"><strong>關閉ViewState</strong></span>，所以PostBack之後，<span class="auto-style1"><strong>無法比對</strong></span>。<br />
&nbsp;&nbsp;&nbsp;&nbsp; 就算你一直按下按鈕，而且沒有改裡面的字，因為<span class="auto-style1"><strong>無法比對</strong></span><strong>而誤以為「文字被改了」</strong>，故執行TextChanged事件<br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp; 因此，你在<strong>第三個步驟，不斷地重複按下</strong> Button才會一直觸發 TextChanged事件。<br />
&nbsp;&nbsp;&nbsp;&nbsp; 因為ViewState被關閉，無法與 Request比對。<br />
        <br />
        ===========================================
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <br />
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" 
                   ontextchanged="TextBox2_TextChanged"></asp:TextBox>
        （<span class="style2">EnableViewState屬性 = true。預設值</span>）<br />
        <br />
        <asp:Label ID="Label2" runat="server" style="font-weight: 700; color: #0000FF"></asp:Label>
        <br />
        <br />
        注意！！如果換成「清單控制項」，如DropDownList，ViewState的使用與狀況，可能不同！<br />
        不能一概而論！<br />
    
    </div>
    </form>
</body>
</html>
