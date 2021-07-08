Imports System.Data
Imports System.Data.SqlClient
Partial Class PictureVB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("ImageID") IsNot Nothing Then
            Dim strConnString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("testConnectionString").ConnectionString
            Dim strQuery As String = "select * from FileUpload_DB2 where FileUpload_DB_id=@id"
            Dim cmd As SqlCommand = New SqlCommand(strQuery)
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(Request.QueryString("ImageID"))
            Dim conn As New SqlConnection(strConnString)
            Dim sda As New SqlDataAdapter
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn
            Dim dt As New DataTable
            Try
                conn.Open()
                sda.SelectCommand = cmd
                sda.Fill(dt)
            Catch ex As Exception
                dt = Nothing
            Finally
                conn.Close()
                sda.Dispose()
                conn.Dispose()
            End Try

            If dt IsNot Nothing Then
                ' 將圖片呈現出來！  
                Dim bytes() As Byte = CType(dt.Rows(0)("FileUpload_FileName"), Byte())

                Response.Buffer = True
                Response.Charset = ""
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.ContentType = "image/jpg"    '-- MIME Type
                'Response.AddHeader("content-disposition", "attachment;filename=" & dt.Rows(0)("Name").ToString())
                Response.BinaryWrite(bytes)
                Response.Flush()
                Response.End()
            End If
        End If
    End Sub
   

End Class
