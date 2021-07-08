Imports System.Data
Imports System.Data.SqlClient
Partial Class VB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim strQuery As String = "select top 10 * from customers"
        Dim cmd As New SqlCommand(strQuery)
        Dim dt As DataTable = GetData(cmd)  '--自己寫的副程式
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    Protected Sub RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Attributes.Add("onmouseover", "MouseEvents(this, event)")  '-- 每一列（<tr>）加入JavaScript特效
            e.Row.Attributes.Add("onmouseout", "MouseEvents(this, event)")

        End If
    End Sub

    '-- 自己寫的副程式 ---------------------------------------------
    Public Function GetData(ByVal cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim strConnString As String = System.Configuration.ConfigurationManager.ConnectionStrings("NorthwindConnectionString").ConnectionString
        Dim conn As New SqlConnection(strConnString)
        Dim sda As New SqlDataAdapter
        cmd.CommandType = CommandType.Text
        cmd.Connection = conn
        Try
            conn.Open()
            sda.SelectCommand = cmd
            sda.Fill(dt)
            Return dt
        Catch ex As Exception
            Response.Write(ex.Message)
            Return Nothing
        Finally
            conn.Close()
            sda.Dispose()
            conn.Dispose()
        End Try
    End Function
End Class
