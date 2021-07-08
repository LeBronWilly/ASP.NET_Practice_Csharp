﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CSharp.aspx.cs" Inherits="_Default" %>

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
function Check_Click(objRef)
{
    //Get the Row based on checkbox
    var row = objRef.parentNode.parentNode;
    if(objRef.checked)
    {
        //If checked change color to Aqua
        row.style.backgroundColor = "aqua";
    }
    else
    {    
        //If not checked change back to original color
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
    
    //Get the reference of GridView
    var GridView = row.parentNode;
    
    //Get all input elements in Gridview
    var inputList = GridView.getElementsByTagName("input");
    
    for (var i=0;i<inputList.length;i++)
    {
        //The First element is the Header Checkbox
        var headerCheckBox = inputList[0];
        
        //Based on all or none checkboxes
        //are checked check/uncheck Header Checkbox
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
        var row = inputList[i].parentNode.parentNode;
        if(inputList[i].type == "checkbox"  && objRef != inputList[i])
        {
            if (objRef.checked)
            {
                //If the header checkbox is checked
                //check all checkboxes
                //and highlight all rows
                row.style.backgroundColor = "aqua";
                inputList[i].checked=true;
            }
            else
            {
                //If the header checkbox is checked
                //uncheck all checkboxes
                //and change rowcolor back to original 
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
    <asp:BoundField ItemStyle-Width="150px" DataField="CustomerID" HeaderText="CustomerID"  />
    <asp:BoundField ItemStyle-Width="150px" DataField="City" HeaderText="City" />
    <asp:BoundField ItemStyle-Width="150px" DataField="Country" HeaderText="Country"/>
    <asp:BoundField ItemStyle-Width="150px" DataField="PostalCode"  HeaderText= "PostalCode"/>
    </Columns> 
    </asp:GridView>
    </form>
</body>
</html>
