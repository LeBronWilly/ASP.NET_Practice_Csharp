using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Book_Sample_B11_CaseStudy_Vote_CheckBoxList_2 : System.Web.UI.Page
{
    //*****************************
    int u_summary = 0;
    //*****************************

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //***前面兩段迴圈內容幾乎相同，所以抽離出來，寫成副程式

        CBL_Check(Label1, CheckBoxList1);  // 輸入兩個控制項，Label 與 CheckBoxList

        //Label1.Text = "";
        //for (int i = 0; i < CheckBoxList1.Items.Count; i++)   {
        //    if (CheckBoxList1.Items[i].Selected)   {
        //        if (CheckBoxList1.Items[i].Value != "0")   {
        //            Label1.Text += "<font color=darkgreen>答對！</font>";
        //            u_summary += Convert.ToInt32(CheckBoxList1.Items[i].Value);
        //        }
        //        else   {
        //            Label1.Text = "<font color=red>有錯誤喔～</font>";
        //            u_summary = 0;  //-- 有錯誤選項，立刻把分數歸零！2011/12/19修正。
        //            break;
        //        }
        //    }
        //}

        ////----------------------------------------------------------------------------
        CBL_Check(Label2, CheckBoxList2);  // 輸入兩個控制項，Label 與 CheckBoxList

        //Label2.Text = "";
        //for (int j = 0; j < CheckBoxList2.Items.Count; j++)   {
        //    if (CheckBoxList2.Items[j].Selected)    {
        //        if (CheckBoxList2.Items[j].Value != "0")   {
        //            Label2.Text += "<font color=darkgreen>答對！</font>";
        //            u_summary += Convert.ToInt32(CheckBoxList2.Items[j].Value);
        //        }
        //        else   {
        //            Label2.Text = "<font color=red>有錯誤喔～</font>";
        //            u_summary = 0;  //-- 有錯誤選項，立刻把分數歸零！2011/12/19修正。
        //            break;
        //        }
        //    }
        //}


        //----------------------------------------------------------------------------
        //-- 這個題目裡面，必須複選兩個才算正確 --
        Label3.Text = "";
        int u_summary_3 = 0;

        for (int k = 0; k < CheckBoxList3.Items.Count; k++)
        {
            if (CheckBoxList3.Items[k].Selected)
            {
                if (CheckBoxList3.Items[k].Value != "0")
                {
                    u_summary_3 += Convert.ToInt32(CheckBoxList3.Items[k].Value);
                }
                else
                {
                    Label3.Text = "<font color=red>有錯誤喔～</font>";
                    u_summary_3 = 0;  //-- 有錯誤選項，立刻把分數歸零！2011/12/19修正。
                    break;
                }
            }
        }
        
        if (u_summary_3 == 6)        {
            Label3.Text = "<font color=darkgreen>答對！</font>";
        }

        u_summary += Convert.ToInt32(u_summary_3);
        //----------------------------------------------------------------------------
        Label_summary.Text = u_summary.ToString();
    }


    //************************************************************(start)
    // 輸入兩個控制項，Label 與 CheckBoxList
    protected void CBL_Check(Label LB, CheckBoxList CBL)
    {
        LB.Text = "";
        for (int i = 0; i < CBL.Items.Count; i++)
        {
            if (CBL.Items[i].Selected)
            {
                if (CBL.Items[i].Value != "0")
                {
                    LB.Text += "<font color=darkgreen>答對！</font>";
                    u_summary += Convert.ToInt32(CBL.Items[i].Value);
                }
                else
                {
                    LB.Text = "<font color=red>有錯誤喔～</font>";
                }
            }
        }
    }
    //************************************************************(end)


    //資料來源：http://www.csharphelp.com/archives4/archive616.html
    public static string Left(string param, int length)
    {
        //we start at 0 since we want to get the characters starting from the
        //left and with the specified lenght and assign it to a variable
        string result = param.Substring(0, length);
        //return the result of the operation
        return result;
    }
}