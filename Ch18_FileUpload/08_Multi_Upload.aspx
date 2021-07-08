<%@ Page Language="C#" AutoEventWireup="true" CodeFile="08_Multi_Upload.aspx.cs" Inherits="Ch18_FileUpload_8_Multi_Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> </title>
    <style type="text/css">
        .style1
        {
            color: #FF0000;
            font-weight: bold;
        }
        .style2
        {
            color: #FFFFFF;
            font-weight: bold;
            background-color: #800000;
        }
        .style3
        {
            font-size: large;
            font-weight: bold;
        }
        .style4
        {
            background-color: #FFFF66;
        }
        .style5
        {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span class="style3">大量檔案，批次上傳</span>&nbsp; / <span class="style1">
        <span class="style5">本書獨有</span>
        <br />
        <br />
        FileUpload控制項<span class="style4">(批次上傳)</span><br />
        <br />
        </span> <span class="style2">寫法獨一無二，請別錯過<br />
        <br />
        </span><br /><hr />
        1.
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        2.
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <br />
        3.
        <asp:FileUpload ID="FileUpload3" runat="server" />
        <br />
        4.
        <asp:FileUpload ID="FileUpload4" runat="server" />
        <br />
        5.
        <asp:FileUpload ID="FileUpload5" runat="server" />
        <br />
        <hr />
&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" 
            Text="Multi-Files ~ UPLOAD!  大量檔案，批次上傳！" onclick="Button1_Click" />

    </div>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label>
        <br />
    </p>
    </form>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
 
</body>
</html>