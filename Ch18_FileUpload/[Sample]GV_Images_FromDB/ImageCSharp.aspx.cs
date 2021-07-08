using System;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
protected void Page_Load(object sender, EventArgs e)
{
    if (Request.QueryString["ImageID"] != null)
    {
        string strQuery = "select * from FileUpload_DB2 where FileUpload_DB_id=@id";
        String strConnString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString["ImageID"]);
        SqlConnection conn = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        DataTable dt = new DataTable(); 
        cmd.Connection = conn;
        try
        {
            conn.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
        }
        catch
        {
            dt = null;
        }
        finally
        {
            conn.Close();
            sda.Dispose();
            conn.Dispose();
        }
        if (dt != null)
        {   // 將圖片呈現出來！
            Byte[] bytes = (Byte[])dt.Rows[0]["FileUpload_FileName"];

            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "image/jpg";    // MIME Type
            //Response.AddHeader("content-disposition", "attachment;filename=" + dt.Rows[0]["Name"].ToString());
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}
    private DataTable GetData(SqlCommand cmd)
    {
        DataTable dt = new DataTable();
        String strConnString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;
        try
        {
            conn.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }
        catch
        {
            return null;
        }
        finally
        {
            conn.Close();
            sda.Dispose();
            conn.Dispose();
        }
    }
}
