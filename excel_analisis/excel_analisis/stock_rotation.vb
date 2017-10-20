Imports Microsoft.VisualBasic

Class stock_rotation
    Inherits Analisis

    Private routes_file_path As String
    Private routes As Boolean = True

    Sub New(ByVal pFile As file)
        MyBase.New(pFile)
    End Sub

    'Necessary 
    Public Overrides Sub analyze(filter As String, endDate As Date)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub analyze(ByVal routes_file_path As String)
        If (routes_file_path = "") Then
            routes = False
        End If
        file.make_query(
                        " SELECT [Brand Desc], [Item Nbr], [Signing Desc], [Item Status], [Item Type], [Store Nbr], [Store Name]," &
                        " [Financial Rpt Code], [Range 1 POS Qty], [Range 2 POS Qty], [Range 3 POS Qty], [Range 4 POS Qty]," &
                        " [Range 4 Curr Str On Hand Qty]" &
                        " FROM " & file.activeTable &
                        " ORDER BY [Store Name], [Range 4 Curr Str On Hand Qty] DESC"
                        )

        Dim base_values As DataTable = file.table
        analyze_table(base_values)

        values = New Hashtable()
        values.Add("base", base_values)

    End Sub

    Private Sub analyze_table(ByRef table As DataTable)
        table.Columns.Add("Rotation")
        table.Columns.Add("Sales")
        If (routes) Then
            table.Columns.Add("EDD")
            table.Columns.Add("Agente")
            table.Columns.Add("Merca")
        End If
        For Each line In table.Rows
            check_rotations(line)
            If (routes) Then
                check_routes(line)
            End If
        Next
    End Sub

    Private Sub check_rotations(ByRef line As DataRow)
        line("Sales") = line("Range 1 POS Qty") + line("Range 2 POS Qty") + line("Range 3 POS Qty") + line("Range 4 POS Qty")
        If (line("Sales") > 0) Then
            line("Rotation") = "OK"
        ElseIf (line("Range 4 Curr Str On Hand Qty") <= 0) Then
            line("Rotation") = "Out of Stock"
        Else
            line("Rotation") = "No Rotation"
        End If
        If routes Then
            check_routes(line)
        End If
    End Sub

    Private Sub check_routes(ByRef line As DataRow)

    End Sub
End Class
