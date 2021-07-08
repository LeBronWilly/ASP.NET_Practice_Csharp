Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Services   ' *** Web Service 會用到 ***********************
Imports System.Collections.Generic

Partial Class VB
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then   '-- 第一次執行
            Repeater1.DataSource = GetCustomersData(1)   '--  自己寫的副程式，從第一頁開始
            Repeater1.DataBind()
        End If
    End Sub

    ' *** 自己寫的副程式 **************************（分頁）
    Public Shared Function GetCustomersData(ByVal pageIndex As Integer) As DataSet
        Dim query As String = "[GetCustomersPageWise]"   '-- 寫在DB裡面的預存程序
        Dim cmd As SqlCommand = New SqlCommand(query)
        cmd.CommandType = CommandType.StoredProcedure

        cmd.Parameters.AddWithValue("@PageIndex", pageIndex)
        cmd.Parameters.AddWithValue("@PageSize", 10)
        cmd.Parameters.Add("@PageCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        Return GetData(cmd)   '-- 交給下面的副程式繼續運行
    End Function

    Private Shared Function GetData(ByVal cmd As SqlCommand) As DataSet
        Dim strConnString As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("NorthwindConnectionString").ConnectionString
        Dim con As SqlConnection = New SqlConnection(strConnString)
        Dim sda As SqlDataAdapter = New SqlDataAdapter
        cmd.Connection = con
        sda.SelectCommand = cmd
        Dim ds As DataSet = New DataSet
        sda.Fill(ds, "Customers")

        Dim dt As DataTable = New DataTable("PageCount")
        dt.Columns.Add("PageCount")
        dt.Rows.Add()
        dt.Rows(0)(0) = cmd.Parameters("@PageCount").Value
        ds.Tables.Add(dt)

        Return ds    ' DataSet會自動關閉資料庫的連結
    End Function


    '************************************************************************
    <WebMethod()> _
    Public Shared Function GetCustomers(ByVal pageIndex As Integer) As String
        Return GetCustomersData(pageIndex).GetXml()
    End Function

End Class


