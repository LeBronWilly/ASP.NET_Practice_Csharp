<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fancyBox_Login.aspx.cs" Inherits="Book_Sample_Ch18_FileUpload_fancyBox_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>使用 fancyBox_v2.1.5</title>

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
            $(document).ready(function() {
	            $(".various").fancybox({
		            maxWidth	: 800,
		            maxHeight	: 600,
		            fitToView	: false,
		            width		: '70%',
		            height		: '70%',
		            autoSize	: false,
		            closeClick	: false,
		            openEffect	: 'none',
		            closeEffect	: 'none'
	            });
            });
    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>使用 fancyBox_v2.1.5</h3>
        <br /><br />

<ul class="list">
	<li>
		<a class="various fancybox.ajax" href="fancyBox_Login2.aspx">Ajax--登入畫面</a>
	</li>
</ul>


    </div>
    </form>
</body>
</html>
