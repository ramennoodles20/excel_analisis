Imports Excel = Microsoft.Office.Interop.Excel
MustInherit Class Analisis

    Public file As file
    Protected first_row As Integer
    Public values As New Hashtable()

    Sub New(ByVal pFile As file)
        Me.file = pFile
    End Sub

    MustOverride Overloads Sub analyze(ByVal filter As String, ByVal endDate As Date)
    MustOverride Overloads Sub analyze()
    Protected Function sum_division(ByVal column1 As Integer, ByVal column2 As Integer)
        Dim result As Integer = 0
        For row As Integer = 0 To file.table.Rows.Count - 1
            result += get_cell(row, column1) / get_cell(row, column2)
        Next row
        Return result
    End Function

    Protected Function sum_multiplication(ByVal column1 As Integer, ByVal column2 As Integer)
        Dim result As Double = 0
        For row As Integer = 0 To file.table.Rows.Count - 1
            result += get_cell(row, column1) * get_cell(row, column2)
        Next row
        Return result
    End Function


    Protected Function get_cell(ByVal row As Integer, ByVal column As Integer)
        Return file.table.Rows(row)(column)
    End Function

    Public Function getBrands()
        file.make_query("SELECT [Brand Desc]" &
                        " FROM " & file.activeTable &
                        " GROUP BY [Brand Desc]"
                        )

        Dim brands(file.table.Rows.Count - 1) As String
        For row As Integer = 0 To file.table.Rows.Count - 1
            brands(row) = file.table.Rows(row)(0)
        Next
        Return brands
    End Function
End Class
