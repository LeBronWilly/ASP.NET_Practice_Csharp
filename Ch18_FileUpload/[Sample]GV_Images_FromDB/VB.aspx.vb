Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class VB
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Dim dt As New DataTable()
        Dim strConnString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("testConnectionString").ConnectionString
        Dim strQuery As String = "select * from FileUpload_DB2 order by FileUpload_DB_id"
        Dim cmd As New SqlCommand(strQuery)
        Dim conn As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter()
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        Try
            conn.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView2.DataSource = dt
            GridView2.DataBind()

        Catch ex As Exception
            Response.Write(ex.Message)
        Finally
            conn.Close()
            sda.Dispose()
            conn.Dispose()
            dt.Dispose()
        End Try
    End Sub
End Class
