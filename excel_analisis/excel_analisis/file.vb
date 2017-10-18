Imports System.Data.OleDb
Public Class file
    Public path As String

    Private tableResults As DataTable = New DataTable()
    Public ReadOnly Property table() As DataTable
        Get
            Return tableResults
        End Get
    End Property

    Private firstTable As String
    Public ReadOnly Property activeTable() As String
        Get
            Return firstTable
        End Get
    End Property

    Private provider As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
    Private connString As String
    Private myConnection As OleDbConnection
    Private userTables As DataTable




    Public Sub New(ByRef pPath As String)
        Me.path = pPath
        Me.connString = provider & path
        Me.myConnection = New OleDbConnection(connString)
        open_File()
    End Sub

    Public Sub open_File()
        Dim restrictions() As String = {Nothing, Nothing, "Table", Nothing}

        myConnection.Open()
        userTables = myConnection.GetSchema("Tables")
        firstTable = "[" & userTables.Rows(0)(2) & "]"
        myConnection.Close()
    End Sub

    Public Sub make_query(ByVal query As String)
        Using (myConnection)
            myConnection.ConnectionString = connString
            myConnection.Open()
            Dim adapter As OleDbDataAdapter = New OleDbDataAdapter()
            adapter.SelectCommand = New OleDbCommand(query, myConnection)
            tableResults = New DataTable()
            adapter.Fill(tableResults)
            myConnection.Close()
        End Using
    End Sub
End Class
