<%@ Page Language="C#" AutoEventWireup="true" CodeFile="10_Multi_Upload_Only45_Error.aspx.cs" Inherits="CS_10_Multi_Upload_Only45" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>錯誤版</title>
    <style type="text/css">

        .auto-style1 {
            color: #FF0000;
        }
        .auto-style2 {
            color: #FF0000;
            background-color: #FFFF00;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
        <br /><br /><br />
        <strong>&nbsp; <span class="auto-style2">*** 錯誤版 *** </span>&nbsp;
        <br />
        <br />
        .NET 4.5起</strong>&nbsp;&nbsp;&nbsp; FileUpload新的屬性，<strong>AllowMultiple</strong><br />
        <br />
        <br />
        本範例可能的 Bug如下：<br />
        <br />
        (1) 抱歉！IE 9.0不能使用、不能同時選取多檔案 
        <br />
        <br />
        (2)&nbsp; FileUpload1<span class="auto-style1"><strong>.PostedFile.</strong></span>FileName無法抓到「檔名」，卻抓到「Client端的完整路徑＋檔名」<br />
        &nbsp; 錯誤訊息為「不支援指定的路徑格式」。 
        <br />
        &nbsp; <strong>只有微軟 IE11 / Edge瀏覽器這樣</strong>。Chrome / FireFox只抓到「檔名」，無路徑。 
        <br />
        <br />
&nbsp; 關於此錯誤，請參閱<strong><span class="auto-style1">範例 10_FileName_HttpPostedFile.aspx</span><br class="auto-style1" />
        <br />
        <br />
        </strong>
        <br />
        <br />
        大量檔案，批次上傳&nbsp; / Only .NET 4.5（含）後續版本！<br />
         <br /><hr />
        &nbsp;<asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
        <br />
        <br />
        <br />
        <hr />
&nbsp;&nbsp;
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