Imports Excel = Microsoft.Office.Interop.Excel
Public Class file_reader
    Public path As String

    Private app As New Excel.Application
    Private workBook As Excel.Workbook
    Private workSheet As Excel.Worksheet
    Private range As Excel.Range


    Public Sub open_File()
        workBook = app.Workbooks.Open(path)
        workSheet = DirectCast(workBook.Sheets(1), Excel.Worksheet)
        range = workSheet.UsedRange
    End Sub

    Public Sub read_File()

    End Sub


End Class