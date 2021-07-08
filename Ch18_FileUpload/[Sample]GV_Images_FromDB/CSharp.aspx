<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CSharp.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Images from Database in GridView Example</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />參考資料：http://www.aspsnippets.com/Articles/Display-images-from-SQL-Server-Database-in-ASP.Net-GridView-control.aspx
        <br /><br />

    <table width = "100%">
    <tr>
        <td>
             <div>
                 <h3>使用GV裡面的 ImageField</h3>
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Caption = "Using ImageField">
                <Columns>
                    <asp:BoundField DataField = "FileUpload_DB_id" HeaderText = "FileUpload_DB_id" />
                    <asp:ImageField DataImageUrlField = "FileUpload_DB_id" DataImageUrlFormatString = "ImageCSharp.aspx?ImageID={0}" ControlStyle-Width = "100" ControlStyle-Height = "100" HeaderText = "Preview Image"/>
                </Columns> 
             </asp:GridView>
            </div>
        </td>
         <td>
             <div>
                 <h3>使用樣版 + &lt;ASP:Image&gt;控制項</h3>
              <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns = "false" Font-Names = "Arial" Caption = "Using ImageControl" >
                <Columns>
                    <asp:BoundField DataField = "FileUpload_DB_id" HeaderText = "FileUpload_DB_id" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" Height = "100" Width = "100" runat="server" ImageUrl = '<%# Eval("FileUpload_DB_id", "ImageCSharp.aspx?ImageID={0}")%>' />
                        </ItemTemplate> 
                    </asp:TemplateField> 
                </Columns> 
             </asp:GridView>
            </div>
        </td>
    </tr>
    </table>
    </form>
</body>
</html>
