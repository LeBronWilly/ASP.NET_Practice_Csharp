using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_B06_DataBinding_Food_Menu_Food_Menu_4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SqlDataSource2_Updated(object sender, SqlDataSourceStatusEventArgs e)
    {
        DropDownList1.DataBind();

        //-- 或是  DropDownList1.DataSourceID = "SqlDataSource1";
    }
}