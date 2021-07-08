Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.Services
Imports System.Collections.Generic

Partial Class VB
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            rptCustomers.DataSource = GetCustomersData(1)
            rptCustomers.DataBind()
        End If
    End Sub


    Public Shared Function GetCustomersData(ByVal pageIndex As Integer) As DataSet
        Dim query As String = "[GetCustomersPageWise]"   ' 寫在DB裡面的預存程序
        Dim cmd As SqlCommand = New SqlCommand(query)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@PageIndex", pageIndex)
        cmd.Parameters.AddWithValue("@PageSize", 10)
        cmd.Parameters.Add("@PageCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output
        Return GetData(cmd)
    End Function

    Private Shared Function GetData(ByVal cmd As SqlCommand) As DataSet
        Dim strConnString As String = ConfigurationManager.ConnectionStrings("NorthwindConnectionString").ConnectionString
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
        Return ds
    End Function

    <WebMethod()> _
    Public Shared Function GetCustomers(ByVal pageIndex As Integer) As String
        Return GetCustomersData(pageIndex).GetXml
    End Function


    ' -- 預存程序(DB)---------------------------------------  
    'USE [Northwind]
    'GO
    'Set ANSI_NULLS On
    'GO
    'Set QUOTED_IDENTIFIER On
    'GO
    'CREATE PROCEDURE [dbo].[GetCustomersPageWise]
    '      @PageIndex INT = 1
    '      ,@PageSize INT = 10
    '      ,@PageCount INT OUTPUT
    'AS
    'BEGIN
    '      Set NOCOUNT On;
    '      Select Case ROW_NUMBER() OVER
    '            (
    '                  ORDER BY [CustomerID] ASC
    '            )AS RowNumber
    '      ,[CustomerID]
    '      ,[CompanyName]
    '      ,[ContactName]
    '      ,[City]
    '      ,[Country]
    '      ,[PostalCode]
    '      ,[Phone]
    '      ,[Fax]
    '    INTO #Results
    '      FROM [Customers]

    '    Declare @RecordCount INT
    '      Select Case@RecordCount = COUNT(*) FROM #Results

    '      Set @PageCount = CEILING(CAST(@RecordCount As Decimal(10, 2)) / CAST(@PageSize As Decimal(10, 2)))
    '      PRINT       @PageCount

    '      Select Case* FROM #Results
    '      WHERE RowNumber BETWEEN(@PageIndex -1) * @PageSize + 1 And(((@PageIndex -1) * @PageSize + 1) + @PageSize) - 1

    '      DROP TABLE #Results
    'End

End Class


