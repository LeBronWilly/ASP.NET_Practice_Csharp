<%@ Page Language="C#" AutoEventWireup="true" CodeFile="10_Multi_Upload_Only45_ReName.aspx.cs" Inherits="CS_10_Multi_Upload_Only45" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修正版（檔名重複，加入流水號）</title>
    <style type="text/css">
        .style1
        {
            color: #FF0000;
            font-weight: bold;
        }
        .style3
        {
            background-color: #FFCC00;
        }
        .auto-style1 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>       
        <br />
        <br />
        <h3>（檔名重複，加入流水號）</h3>
        <strong>.NET 4.5起</strong>&nbsp;&nbsp;&nbsp; FileUpload新的屬性，<strong>AllowMultiple</strong><br />
        <br />
        本範例可能的 Bug如下：<br />
        <br />
        (1) 抱歉！IE 9.0不能使用、不能同時選取多檔案 
        <br />
        <br />
        (2) <span class="style1"><span class="style3">修正此問題</span></span>&nbsp;
        <br />
        &nbsp; FileUpload1<span class="auto-style1"><strong>.PostedFile.</strong></span>FileName無法抓到「檔名」，抓到「Client端的完整路徑＋檔名」<br />
        &nbsp; 錯誤訊息為「不支援指定的路徑格式」。 
        <br />
        &nbsp; <strong>只有微軟 IE11 / Edge瀏覽器這樣</strong>。Chrome / FireFox只抓到「檔名」，無路徑。<br />
        <br />
&nbsp; 關於此錯誤，請參閱<strong><span class="auto-style1">範例 10_FileName_HttpPostedFile.aspx</span><br class="auto-style1" />
        </strong>
        <br />
        <hr />        
        大量檔案，批次上傳&nbsp; / <span class="style1"><span class="style3">Only .NET 4.5（含）後續版本！</span>
        <br /><br />
        
        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
        <br /><hr />&nbsp;&nbsp;

        <asp:Button ID="Button1" runat="server" 
            Text="Multi-Files ~ UPLOAD!  大量檔案，批次上傳！" OnClick="Button1_Click" />
    
    </div>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label><br />
    </p>
    </form>
</body>
</html>