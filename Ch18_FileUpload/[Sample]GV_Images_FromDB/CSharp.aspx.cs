using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        String strConnString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
        string strQuery = "select * from FileUpload_DB2 order by FileUpload_DB_id";
        SqlCommand cmd = new SqlCommand(strQuery);
        SqlConnection conn = new SqlConnection(strConnString);
        SqlDataAdapter sda = new SqlDataAdapter();
        cmd.CommandType = CommandType.Text;
        cmd.Connection = conn;
        try
        {
            conn.Open();
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView2.DataSource = dt;
            GridView2.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            conn.Close();
            sda.Dispose();
            conn.Dispose();
            dt.Dispose(); 
        } 
    }
}
