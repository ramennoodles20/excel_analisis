Imports Excel = Microsoft.Office.Interop.Excel
Public Class file_reader
    Public path As String

    Private app As Excel.Application
    Private workBook As Excel.Workbook
    Private workSheet As Excel.Worksheet
    Private range As Excel.Range
    Private rCnt As Integer
    Private cCnt As Integer
    Private Obj As Object


    Public Sub open_File()
        app = New Excel.ApplicationClass()
        workBook = app.Workbooks.Open(path)
        workSheet = DirectCast(workBook.Sheets(1), Excel.Worksheet)
        For rCnt = 1 To range.Rows.Count
            For cCnt = 1 To range.Columns.Count
                Obj = CType(range.Cells(rCnt, cCnt), Excel.Range)
                MsgBox(Obj.value)
            Next
        Next
    End Sub



End Class