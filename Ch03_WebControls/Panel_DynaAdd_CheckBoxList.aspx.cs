using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_Ch03_WebControls_Panel_DynaAdd_CheckBoxList : System.Web.UI.Page
{

    protected void Page_Init(object sender, EventArgs e)
    {
        //CheckBoxList CBL = new CheckBoxList();
        //CBL.ID = "CheckBoxList1";
        //for (int i = 0;i < 10; i++)
        //{
        //    CBL.Items.Add(i.ToString());
        //}
        //Page.Form.Controls.Add(CBL);

        //if(!Page.IsPostBack)
        //{
        for (int i = 0; i < 10; i++)
        {
            CheckBox CB = new CheckBox();
            CB.ID = "CheckBox" + i.ToString();
            CB.Text = i.ToString();
            Page.Form.Controls.Add(CB);
        }
        //}  
    }


    //protected void Page_Load(object sender, EventArgs e)
    //{
    //    //CheckBoxList CBL = new CheckBoxList();
    //    //CBL.ID = "CheckBoxList1";
    //    //for (int i = 0;i < 10; i++)
    //    //{
    //    //    CBL.Items.Add(i.ToString());
    //    //}
    //    //Page.Form.Controls.Add(CBL);

    //    //if(!Page.IsPostBack)
    //    //{
    //    for (int i = 0; i < 10; i++)
    //        {
    //            CheckBox CB = new CheckBox();
    //            CB.ID = "CheckBox" + i.ToString();
    //            CB.Text = i.ToString();
    //            Page.Form.Controls.Add(CB);
    //        }
    //    //}  
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            CheckBox CB = (CheckBox)Page.FindControl("CheckBox" + i.ToString());
            if (CB.Checked)
            {
                Response.Write("CheckBox" + i.ToString() + "被選取了<br>");
            }
        }        
    }
}