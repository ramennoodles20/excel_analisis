Imports Excel = Microsoft.Office.Interop.Excel
MustInherit Class Analisis

    Public file As file
    Protected max_rows As Integer
    Protected max_columns As Integer

    Sub New(ByVal pFile As file)
        Me.file = pFile
        Me.max_rows = file.range.Rows.Count
        Me.max_columns = file.range.Columns.Count
    End Sub

    MustOverride Sub analyze()

    Protected Function sum_division(ByVal column1 As Integer, ByVal column2 As Integer)
        Dim result As Integer = 0
        Dim row As Integer = find_first_row()
        While row < max_rows
            result += CType(file.range.Cells(row, column1), Excel.Range).Value / CType(file.range.Cells(row, column2), Excel.Range).Value
            row += 1
        End While
        Return result
    End Function

    Private Function find_first_row()
        Dim row As Integer = 1
        Dim text As String
        text = CType(file.range.Cells(row, 1), Excel.Range).Value
        While text <> "Country Code"
            text = CType(file.range.Cells(row, 1), Excel.Range).Value
            row += 1
        End While
        Return row
    End Function

End Class
