Imports Excel = Microsoft.Office.Interop.Excel
Public Class file
    Public path As String

    Private app As New Excel.Application
    Private workBook As Excel.Workbook
    Private workSheet As Excel.Worksheet
    Public range As Excel.Range


    Public Sub open_File()
        workBook = app.Workbooks.Open(path)
        workSheet = DirectCast(workBook.Sheets(1), Excel.Worksheet)
        range = workSheet.UsedRange
    End Sub
End Class