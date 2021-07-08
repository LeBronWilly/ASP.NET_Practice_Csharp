using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//----自己寫的（宣告)----
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
//----自己寫的（宣告)----

public partial class Book_Sample_Ch14_DataReader_Parameter_4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //----上面已經事先寫好NameSpace --  using System.Web.Configuration; ----     
        //----或是寫成下面這一行 (連結資料庫)----
        SqlConnection Conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString);

        string sqlstr = "";
        SqlCommand cmd = null;
        //********************************************************
        List<SqlParameter> list = new List<SqlParameter>();
        //********************************************************

        int parameter_num = 4;  // 每一則SQL指令裡面需要幾個參數？
        for (int i = 1; i <= 10; i++)
        {
            sqlstr += "Insert Into test(test_time, title, summary, article, author) Values(getdate(), ";
            int j = 1;
            while(j <= parameter_num)
            {   //重複組成「參數」
                string str = i.ToString() + j.ToString();   // 參數的編號，如 @Parameter11、@Parameter12、@Parameter13 ......
                string u_parameter = "@parameter" + str;
                string u_value = "數值" + str;

                if (j == parameter_num)      {
                    sqlstr += "@parameter" + str + "); ";   // 每一則SQL指令 (Insert Into) 的結尾，加上「分號」
                }
                else    {
                    sqlstr += "@parameter" + str + ", ";
                }
                //******************************************************************************
                // 資料來源 http://www.allenkuo.com/EBook5/view.aspx?TreeNodeID=13&id=251
                list.Add(new SqlParameter(u_parameter, u_value));
                //******************************************************************************
                j++;
            }
        }

        //*************************************************************************************************
        cmd = new SqlCommand(sqlstr, Conn);

        cmd.Parameters.Clear();
        cmd.Parameters.AddRange(list.ToArray<SqlParameter>());  // 把「陣列」值，批次加入參數裡面
        //*************************************************************************************************
        Response.Write("<hr>" + sqlstr + "<hr>");

        try     //==== 以下程式，只放「執行期間」的指令！=====================
        {
            //== 第一，連結資料庫。
            Conn.Open();   //---- 這時候才連結DB

            //== 第二，執行SQL指令。
            int k = cmd.ExecuteNonQuery();   //---- 這時候執行SQL指令，取出資料

            //==第三，自由發揮，把執行後的結果呈現到畫面上。
            Response.Write("<h3>共計新增" + k.ToString() + "筆記錄</h3>");
        }
        catch (Exception ex)
        {   //---- 如果程式有錯誤或是例外狀況，將執行這一段
            Response.Write("<b>Error Message----  </b>" + ex.ToString() + "<HR/>");
        }
        finally
        {   // == 第四，釋放資源、關閉資料庫的連結。
            //---- Always call Close when done reading.
            cmd.Cancel();
            //---- Close the connection when done with it.
            if (Conn.State == ConnectionState.Open)    {
                Conn.Close();
                Conn.Dispose(); //---- 一開始宣告有用到 New的,最後必須以 .Dispose()結束
            }
        }

    }
}