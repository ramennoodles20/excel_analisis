Imports Excel = Microsoft.Office.Interop.Excel
MustInherit Class Analisis

    Public file As file
    Protected max_rows As Integer
    Protected max_columns As Integer
    Protected first_row As Integer

    Sub New(ByVal pFile As file)
        Me.file = pFile
        Me.max_rows = file.range.Rows.Count
        Me.max_columns = file.range.Columns.Count
        Me.first_row = find_first_row()
    End Sub

    MustOverride Overloads Sub analyze()

    MustOverride Overloads Sub analyze(ByVal filter As String)

    Protected Overloads Function sum_division(ByVal column1 As Integer, ByVal column2 As Integer)
        Dim result As Integer = 0
        Dim row As Integer = first_row
        While row <= max_rows
            result += get_cell(row, column1) / get_cell(row, column2)
            row += 1
        End While
        Return result
    End Function

    Protected Overloads Function sum_division(ByVal column1 As Integer, ByVal column2 As Integer, ByVal filter As String)
        Dim result As Integer = 0
        Dim row As Integer = first_row
        While row <= max_rows
            If (get_cell(row, 6).ToString.Contains(filter)) Then
                result += get_cell(row, column1) / get_cell(row, column2)
            End If
            row += 1
        End While
        Return result
    End Function


    Protected Overloads Function sum_multiplication(ByVal column1 As Integer, ByVal column2 As Integer)
        Dim result As Double = 0
        Dim row As Integer = first_row
        While row <= max_rows
            result += get_cell(row, column1) * get_cell(row, column2)
            row += 1
        End While
        Return result
    End Function

    Protected Overloads Function sum_multiplication(ByVal column1 As Integer, ByVal column2 As Integer, ByVal filter As String)
        Dim result As Double = 0
        Dim row As Integer = first_row
        While row <= max_rows
            If (get_cell(row, 6).ToString.Contains(filter)) Then
                result += get_cell(row, column1) * get_cell(row, column2)
            End If
            row += 1
        End While
        Return result
    End Function

    MustOverride Function find_first_row()


    Protected Function get_cell(ByVal row As Integer, ByVal column As Integer)
        Return CType(file.range.Cells(row, column), Excel.Range).Value
    End Function

End Class
