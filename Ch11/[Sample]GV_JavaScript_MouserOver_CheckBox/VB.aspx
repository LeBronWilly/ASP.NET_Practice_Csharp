<%@ Page Language="VB" AutoEventWireup="false" CodeFile="VB.aspx.vb" Inherits="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Scrollable Grid</title>
    <style type ="text/css" >
        .header
        {
           background-color:Green;
        }
    </style> 
    <script type = "text/javascript">
        function Check_Click(obj)
        {
            var row = obj.parentNode.parentNode;
            if(obj.checked)
            {
                row.style.backgroundColor = "aqua";
            }
            else
            {    
                if(row.rowIndex % 2 == 0)
                {
                   //Alternating Row Color
                   row.style.backgroundColor = "#C2D69B";
                }
                else
                {
                   row.style.backgroundColor = "white";
                }
            }
            var GridView = row.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            
            for (var i=0;i<inputList.length;i++)
            {
                var cell = inputList[i].parentNode;
                var headerCheckBox = inputList[0];
                var checked = true;
                if(inputList[i].type == "checkbox" && inputList[i] != headerCheckBox)
                {
                    if(!inputList[i].checked)
                    {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;
            
        }
    </script>
    <script type = "text/javascript">
        function checkAll(objRef)
        {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i=0;i<inputList.length;i++)
            {
                //Get the Cell To find out ColumnIndex
                var cell = inputList[i].parentNode;
                var row = inputList[i].parentNode.parentNode;
                if(inputList[i].type == "checkbox" && cell.cellIndex == 0 && objRef != inputList[i])
                {
                    if (objRef.checked)
                    {
                        row.style.backgroundColor = "aqua";
                        inputList[i].checked=true;
                    }
                    else
                    {
                        if(row.rowIndex % 2 == 0)
                        {
                           //Alternating Row Color
                           row.style.backgroundColor = "#C2D69B";
                        }
                        else
                        {
                           row.style.backgroundColor = "white";
                        }
                        inputList[i].checked=false;
                    }
                }
            }
        }
    </script>
<script type = "text/javascript">
function MouseEvents(objRef, evt)
{
    var checkbox = objRef.getElementsByTagName("input")[0];
   if (evt.type == "mouseover")
   {
        objRef.style.backgroundColor = "orange";
   }
   else
   {
        if (checkbox.checked)
        {
            objRef.style.backgroundColor = "aqua";
        }
        else if(evt.type == "mouseout")
        {
            if(objRef.rowIndex % 2 == 0)
            {
               //Alternating Row Color
               objRef.style.backgroundColor = "#C2D69B";
            }
            else
            {
               objRef.style.backgroundColor = "white";
            }
        }
   }
}
</script>  
</head>
<body>
    <form id="form1" runat="server">
   
        <asp:GridView ID="GridView1" runat="server"  HeaderStyle-CssClass = "header"
            AutoGenerateColumns = "false" Font-Names = "Arial"  OnRowDataBound = "RowDataBound"
            Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B" >
           <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll(this);" />
                </HeaderTemplate> 
               <ItemTemplate>
                   <asp:CheckBox ID="CheckBox1" runat="server" onclick = "Check_Click(this)" />
               </ItemTemplate> 
            </asp:TemplateField> 
            <asp:BoundField ItemStyle-Width = "150px" DataField = "CustomerID" HeaderText = "CustomerID" />
            <asp:BoundField ItemStyle-Width = "150px" DataField = "City" HeaderText = "City" />
            <asp:BoundField ItemStyle-Width = "150px" DataField = "Country" HeaderText = "Country"/>
            <asp:BoundField ItemStyle-Width = "150px" DataField = "PostalCode"  HeaderText = "PostalCode"/>
           </Columns> 
        </asp:GridView>
    </form>
</body>
</html>
