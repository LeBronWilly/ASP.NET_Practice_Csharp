using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeWork_Day_01 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {            
            int intYear = System.DateTime.Now.Year;
            int intMonth = System.DateTime.Now.Month;
            int intDay = System.DateTime.Now.Day;

            //年選單
            for (int i=0; i<=10; i++)
            {
                ddlYear.Items.Add((intYear - i).ToString());
            }
            //月選單
            changeMonthsDDLValue(intYear);
            //日選單
            changeDaysDDLValue(intYear, intMonth);

            //將 年月日 的下拉式選單，預設為當日
            ddlYear.Items.FindByValue(Convert.ToString(intYear)).Selected = true;            
            ddlMonths.Items.FindByValue(Convert.ToString(intMonth)).Selected = true;
            ddlDays.Items.FindByValue(Convert.ToString(intDay)).Selected = true;            
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {        
        if (!checkPassword())    // 自己寫的副程式 checkPassword
        {
            return;
        }

        labName.Text = txtName.Text;
        labBirthDay.Text = txtBirthDay.Text;
        LabSex.Text = rblSex.SelectedItem.Text;
        string strEducation = "";
        int j = 0;
        for (int i = 0; i < cblEducation.Items.Count;i++)
        {            
            if (cblEducation.Items[i].Selected)
            {
                j++;
                strEducation = strEducation + j + ". " + cblEducation.Items[i].Text + " ";                
            }
        }
        LabEducation.Text = strEducation;
        LabAccount.Text = txtAccount.Text;        

        Panel1.Visible = true;
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        txtBirthDay.Text = Calendar1.SelectedDate.ToShortDateString();
    }

    protected void txtConfirmPassword_TextChanged(object sender, EventArgs e)
    {
        checkPassword();
    }

    private bool checkPassword()
    {
        if (txtNewPassword.Text == txtConfirmPassword.Text)
        {
            labCheckPassword.Text = "";
            return true;
        }
        else
        {
            labCheckPassword.Text = "密碼不一致, 請重新輸入";
            txtNewPassword.Focus();
            return false;
        }
    }

    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        changeMonthsDDLValue(Convert.ToInt32(ddlYear.SelectedValue));
        changeDaysDDLValue(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonths.SelectedValue));
    }

    protected void ddlMonths_SelectedIndexChanged(object sender, EventArgs e)
    {
        changeDaysDDLValue(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonths.SelectedValue));
    }

    protected void ddlDays_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Calendar1.VisibleDate = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonths.SelectedValue), Convert.ToInt32(ddlDays.SelectedValue));
        Calendar1.TodaysDate = new DateTime(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonths.SelectedValue), Convert.ToInt32(ddlDays.SelectedValue));
    }
    private void changeMonthsDDLValue(int year)
    {
        //清除選單
        ddlMonths.Items.Clear();
        
        int intMaxMonth;
        if (year == System.DateTime.Now.Year)        
            intMaxMonth = System.DateTime.Now.Month;                    
        else
            intMaxMonth = 12;

        //月份選單
        for (int i = 0; i < intMaxMonth; i++)
        {
            ddlMonths.Items.Add((i + 1).ToString());
        }
    }

    private void changeDaysDDLValue(int year, int month)
    {
        //清除選單
        ddlDays.Items.Clear();
                
        int intDaysInMonth = System.DateTime.DaysInMonth(year, month);
        int intMaxDay;
        if (year == System.DateTime.Now.Year && month == System.DateTime.Now.Month)
            intMaxDay = System.DateTime.Now.Day;
        else
            intMaxDay = intDaysInMonth;

        //日選單            
        for (int i = 0; i < intMaxDay; i++)
        {
            ddlDays.Items.Add((i + 1).ToString());
        }
    }

    
}