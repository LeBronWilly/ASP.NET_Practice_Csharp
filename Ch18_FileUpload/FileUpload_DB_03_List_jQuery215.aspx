<%@ Page Language="C#" debug="true" AutoEventWireup="true" CodeFile="FileUpload_DB_03_List_jQuery215.aspx.cs" Inherits="Book_Sample_Ch18_FileUpload_FileUpload_DB_02_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>使用 fancyBox_v2.1.5</title>
    <style type="text/css">
        .style2
        {
            background-color: #FFFF00;
        }
        .style3
        {
            color: #FF0000;
            font-weight: bold;
        }
    </style>

    

<!-- Add jQuery library -->
<script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>

<!-- Add mousewheel plugin (this is optional) -->
<script type="text/javascript" src="fancyBox-v2.1.5/lib/jquery.mousewheel-3.0.6.pack.js"></script>

<!-- Add fancyBox -->
<link rel="stylesheet" href="fancyBox-v2.1.5/source/jquery.fancybox.css?v=2.1.5" type="text/css" media="screen" />
<script type="text/javascript" src="fancyBox-v2.1.5/source/jquery.fancybox.pack.js?v=2.1.5"></script>

<!-- Optionally add helpers - button, thumbnail and/or media -->
<link rel="stylesheet" href="fancyBox-v2.1.5/source/helpers/jquery.fancybox-buttons.css?v=1.0.5" type="text/css" media="screen" />
<script type="text/javascript" src="fancyBox-v2.1.5/source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>
<script type="text/javascript" src="fancyBox-v2.1.5/source/helpers/jquery.fancybox-media.js?v=1.0.6"></script>

<link rel="stylesheet" href="fancyBox-v2.1.5/source/helpers/jquery.fancybox-thumbs.css?v=1.0.7" type="text/css" media="screen" />
<script type="text/javascript" src="fancyBox-v2.1.5/source/helpers/jquery.fancybox-thumbs.js?v=1.0.7"></script>
    <script>
        $(document).ready(function () {
            $(".fancybox-thumb").fancybox({
                prevEffect: 'none',
                nextEffect: 'none',
                helpers: {
                    title: {
                        type: 'outside'
                    },
                    thumbs: {
                        width: 50,
                        height: 50
                    }
                }
            });
        });
    </script> 


</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <b>上傳的檔案路徑，會存在DB裡面</b>（<span class="auto-style1">FileUpload_DB資料表 / jQuery版 [fancyBox效果]</span>）<br />
        圖片上傳之後，列在畫面上。<br />
        <br />
        (1). ListView的「樣版」需<b>動手加入 Image控制項</b>，用來展示圖片。<br />
        (2). 您可能需要修改「樣版」裡面，Image控制項的<b>「路徑」</b>。目前設定為 <span class="style3">
        Uploads/        </span>
        <br />
        <br />
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="FileUpload_DB_id" 
            DataSourceID="SqlDataSource1" GroupItemCount="3">
            <AlternatingItemTemplate>
                <td runat="server" style="background-color: #FFFFFF;color: #284775;">
                    FileUpload_DB_id:
                    <asp:Label ID="FileUpload_DB_idLabel" runat="server" 
                        Text='<%# Eval("FileUpload_DB_id") %>' />
                    <br />FileUpload_time:
                    <asp:Label ID="FileUpload_timeLabel" runat="server" 
                        Text='<%# Eval("FileUpload_time") %>' />
                    <br />上傳路徑與檔名：<br />
                    <asp:Label ID="test_idLabel" runat="server" Text='<%# "Uploads/" + Eval("FileUpload_FileName") %>' />
                    <br />
                    <br />



                    FileUpload_FileName + FileUpload_Memo:<br />
           <a class="fancybox-thumb" href='<%# "Uploads/" + Eval("FileUpload_FileName") %>' data-fancybox-group="gallery">
                    <asp:Image ID="Image1" runat="server"  Width="45px" Height="60px"
                                  ImageUrl='<%# "Uploads/" + Eval("FileUpload_FileName") %>'
                                  GenerateEmptyAlternateText="true" AlternateText='<%# Eval("FileUpload_Memo") %>' />
           </a>


                    <br />FileUpload_User:
                    <asp:Label ID="FileUpload_UserLabel" runat="server" 
                        Text='<%# Eval("FileUpload_User") %>' />
                    <br />
                </td>
            </AlternatingItemTemplate>

            <GroupTemplate>
                <tr ID="itemPlaceholderContainer" runat="server">
                    <td ID="itemPlaceholder" runat="server">
                    </td>
                </tr>
            </GroupTemplate>

            <ItemTemplate>
                <td runat="server" style="background-color: #E0FFFF;color: #333333;">
                    FileUpload_DB_id:
                    <asp:Label ID="FileUpload_DB_idLabel" runat="server" 
                        Text='<%# Eval("FileUpload_DB_id") %>' />
                    <br />FileUpload_time:
                    <asp:Label ID="FileUpload_timeLabel" runat="server" 
                        Text='<%# Eval("FileUpload_time") %>' />
                    <br />上傳路徑與檔名：<br />
                    <asp:Label ID="test_idLabel" runat="server" Text='<%# "Uploads/" + Eval("FileUpload_FileName") %>' />
                    <br />
                    <br />

                    FileUpload_FileName + FileUpload_Memo:<br />

        <a class="fancybox-thumb" href='<%# "Uploads/" + Eval("FileUpload_FileName") %>' data-fancybox-group="gallery">
                    <asp:Image ID="Image1" runat="server" Width="45px" Height="60px"
                         ImageUrl='<%# "Uploads/" + Eval("FileUpload_FileName") %>'
                        GenerateEmptyAlternateText="true" AlternateText='<%# Eval("FileUpload_Memo") %>' />
        </a>            


                    <br />FileUpload_User:
                    <asp:Label ID="FileUpload_UserLabel" runat="server" 
                        Text='<%# Eval("FileUpload_User") %>' />
                    <br />
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="groupPlaceholderContainer" runat="server" border="1" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr ID="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" 
                            style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                        ShowLastPageButton="True" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:testConnectionString %>" 
            SelectCommand="SELECT * FROM [FileUpload_DB]"></asp:SqlDataSource>
    
    </div>
    
    </form>
</body>
</html>
