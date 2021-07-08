using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//***************************************************************************
using System.Configuration;
//-- 搭配 App.Config設定檔，取得DB連結字串。
//*** 必須自己動手，「加入參考」之後才能呼叫這個命名空間！ **************

using System.Data.SqlClient;
//----自己寫的（宣告）----


namespace WindowsApplication2_AdoNet_AppConf_CS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'testDataSet.test' 資料表。您可以視需要進行移動或移除。
            this.testTableAdapter.Fill(this.testDataSet.test);

        }


        private void Button1_Click(object sender, EventArgs e)
        {
            //=======微軟SDK文件的範本=======
            //----(連結資料庫)----連結字串，存在 App.Config裡面。這是 Windows From使用的設定檔。
            SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["WindowsApplication2_AdoNet_AppConf_CS.Properties.Settings.testConnectionString"].ConnectionString);
            //----上面已經事先寫好 System.Configuration命名空間 ----

            SqlDataReader dr = null;

            SqlCommand cmd = new SqlCommand("select top 10 id, title from test", Conn);

            try     //==== 以下程式，只放「執行期間」的指令！=====================
            {
                Conn.Open();   //---- 這時候才連結DB

                dr = cmd.ExecuteReader();   //---- 這時候執行SQL指令，取出資料

                while (dr.Read())
                {
                    TextBox1.Text += dr["id"] + "--" + dr["title"] + "\r\n";
                }
            }

            catch (Exception ex)  //---- 如果程式有錯誤或是例外狀況，將執行這一段
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
                    Conn.Dispose();   //---- 一開始宣告有用到 new的,最後必須以 .Dispose()結束
                }
            }

        }
    }
}
