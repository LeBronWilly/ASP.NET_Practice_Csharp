using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//----自己寫的（宣告）----
using System.Data.SqlClient;
//----自己寫的（宣告）----


namespace WindowsApplication1_ADO_NET_CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
        //=======微軟SDK文件的範本=======
        //----(連結資料庫)----把連結字串，固定(寫死)在程式碼裡面。
        SqlConnection Conn = new SqlConnection("Data Source=.\\MSSQLSERVER2008;Initial Catalog=test;Integrated Security=True");
        //---- C#的「\」符號有特殊用處。要使用 「\\」符號才能顯示出「\」符號。

        SqlDataReader dr = null;

        SqlCommand cmd = new SqlCommand("select top 1 title from test", Conn);

        try     //==== 以下程式，只放「執行期間」的指令！=====================
        {
            Conn.Open();   //---- 這時候才連結DB

            dr = cmd.ExecuteReader();   //---- 這時候執行SQL指令，取出資料

            while (dr.Read())
            {
                textBox1.Text = dr["title"].ToString();
            }
        }

        catch(Exception ex)  //---- 如果程式有錯誤或是例外狀況，將執行這一段
        {
            Console.WriteLine("Error Message----  " + ex.ToString());
            //-- Windows程式，改用 Console來取代 Response.Write()
        }

        finally
        {
            //---- Always call Close when done reading.
            if (dr != null) 
            {
                cmd.Cancel();
                //----關閉DataReader之前，一定要先「取消」SqlCommand
                //參考資料： http://blog.darkthread.net/blogs/darkthreadtw/archive/2007/04/23/737.aspx
                dr.Close();
            }
            //---- Close the connection when done with it.
            if (Conn.State == ConnectionState.Open) 
            {
                Conn.Close();
                Conn.Dispose();   //---- 一開始宣告有用到 New的,最後必須以 .Dispose()結束
            }
        }

        }
    }
}
