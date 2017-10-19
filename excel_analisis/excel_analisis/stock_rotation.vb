Imports Microsoft.VisualBasic

Class stock_rotation
    Inherits Analisis

    Sub New(ByVal pFile As file)
        MyBase.New(pFile)
    End Sub

    'Necessary 
    Public Overrides Sub analyze(filter As String, endDate As Date)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub analyze()
        file.make_query(
                        " SELECT [Brand Desc], [Item Nbr], [Signing Desc], [Item Status], [Item Type], [Store Nbr], [Store Name]," &
                        " [Financial Rpt Code], [201734 POS Qty], [201735 POS Qty], [201736 POS Qty], [201737 POS Qty], [201738 POS Qty]," &
                        " [201738 Curr Str On Hand Qty]" &
                        " FROM " & file.activeTable &
                        " ORDER BY [Store Name], [201738 Curr Str On Hand Qty] DESC"
                        )

        Dim base_values As DataTable = file.table
        check_rotations(base_values)
        values = New Hashtable()
    End Sub

    Private Sub check_rotations(ByRef table As DataTable)
        table.Columns.Add("Rotacion")
        For Each line In table.Rows
            Debug.Print(line("201735 POS Qty"))
            Debug.Print("hols")
            If (line("201735 POS Qty") + line("201736 POS Qty") + line("201737 POS Qty") + line("201738 POS Qty")) Then
                line("Rotacion") = "OK"
            End If
        Next
    End Sub
End Class
