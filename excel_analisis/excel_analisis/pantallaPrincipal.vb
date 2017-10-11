Imports Excel = Microsoft.Office.Interop.Excel
Public Class pantallaPrincipal

    Private fill_rate_file As New file()
    Dim analisis As Analisis

    Dim fillRateData As DataGridView = New DataGridView
    Dim products As New List(Of String)(New String() {"FOUR LOK", "MOKAI"})

    Private CW As Integer = Me.Width ' Current Width
    Private CH As Integer = Me.Height ' Current Height
    Private IW As Integer = Me.Width ' Initial Width
    Private IH As Integer = Me.Height ' Initial Height

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Dim RW As Double = (Me.Width - CW) / CW
        Dim RH As Double = (Me.Height - CH) / CH

        For Each Ctrl As Control In Controls
            Ctrl.Width += CInt(Ctrl.Width * RW)
            Ctrl.Height += CInt(Ctrl.Height * RH)
            Ctrl.Left += CInt(Ctrl.Left * RW)
            Ctrl.Top += CInt(Ctrl.Top * RH)
        Next

        CW = Me.Width
        CH = Me.Height

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles MyBase.Load
        IW = Me.Width
        IH = Me.Height
    End Sub

    Private Sub FillRateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FillRateToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            fill_rate_file.path = OpenFileDialog1.FileName
            fill_rate_file.open_File()
            analisis = New fill_rate(fill_rate_file)
            configureDataGrid()
            fill_rate.Controls.Add(fillRateData)
            showFillRateFile()
        End If
    End Sub

    Private Sub configureDataGrid()
        'format data grid
        fillRateData.RowCount = 7
        fillRateData.ColumnCount = 10
        fillRateData.Dock = DockStyle.Top
        fillRateData.Height = 400
        fillRateData.RowHeadersVisible = False
        fillRateData.ColumnHeadersVisible = False

        fillRateData.Columns(4).DefaultCellStyle.Format = "N2"
        fillRateData.Columns(5).DefaultCellStyle.Format = "N2"
        fillRateData.Columns(6).DefaultCellStyle.Format = "N2"
        fillRateData.Columns(7).DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub showFillRateFile()

        analisis.analyze("FOUR LOK")
        Dim four As Hashtable = analisis.values

        analisis.analyze("MOKAI")
        Dim mokai As Hashtable = analisis.values

        'analisis general
        fillRateData.Rows(0).Cells(1).Value = "Cajas Pedidas"
        fillRateData.Rows(1).Cells(1).Value = four.Item("boxesOrdered")
        fillRateData.Rows(2).Cells(1).Value = mokai.Item("boxesOrdered")
        fillRateData.Rows(3).Cells(1).Value = fillRateData.Rows(1).Cells(1).Value + fillRateData.Rows(2).Cells(1).Value

        fillRateData.Rows(0).Cells(2).Value = "Cajas Entregadas"
        fillRateData.Rows(1).Cells(2).Value = four.Item("boxesDelivered")
        fillRateData.Rows(2).Cells(2).Value = mokai.Item("boxesDelivered")
        fillRateData.Rows(3).Cells(2).Value = fillRateData.Rows(1).Cells(2).Value + fillRateData.Rows(2).Cells(2).Value

        fillRateData.Rows(0).Cells(3).Value = "Diferencia Cajas"
        fillRateData.Rows(1).Cells(3).Value = four.Item("boxDiference")
        fillRateData.Rows(2).Cells(3).Value = mokai.Item("boxDiference")
        fillRateData.Rows(3).Cells(3).Value = fillRateData.Rows(1).Cells(3).Value + fillRateData.Rows(2).Cells(3).Value

        fillRateData.Rows(0).Cells(4).Value = "% Nivel Servicio"
        fillRateData.Rows(1).Cells(4).Value = four.Item("servicePercent")
        fillRateData.Rows(2).Cells(4).Value = mokai.Item("servicePercent")
        fillRateData.Rows(3).Cells(4).Value = ((fillRateData.Rows(3).Cells(2).Value / fillRateData.Rows(3).Cells(1).Value)) * 100

        fillRateData.Rows(0).Cells(5).Value = "Ordenado $"
        fillRateData.Rows(1).Cells(5).Value = four.Item("amountOrdered")
        fillRateData.Rows(2).Cells(5).Value = mokai.Item("amountOrdered")
        fillRateData.Rows(3).Cells(5).Value = fillRateData.Rows(1).Cells(5).Value + fillRateData.Rows(2).Cells(5).Value

        fillRateData.Rows(0).Cells(6).Value = "Recibido $"
        fillRateData.Rows(1).Cells(6).Value = four.Item("amountDelivered")
        fillRateData.Rows(2).Cells(6).Value = mokai.Item("amountDelivered")
        fillRateData.Rows(3).Cells(6).Value = fillRateData.Rows(1).Cells(6).Value + fillRateData.Rows(2).Cells(6).Value

        fillRateData.Rows(0).Cells(7).Value = "Faltante $"
        fillRateData.Rows(1).Cells(7).Value = four.Item("amountLost")
        fillRateData.Rows(2).Cells(7).Value = mokai.Item("amountLost")
        fillRateData.Rows(3).Cells(7).Value = fillRateData.Rows(1).Cells(7).Value + fillRateData.Rows(2).Cells(7).Value

        'analisis de faltantes
        fillRateData.Rows(5).Cells(0).Value = "FALTANTES"

        Dim row As Integer = 6
        Dim items As Hashtable = four.Item("missingItems")
        fillRateData.RowCount += items.Count
        For Each key In items.Keys
            fillRateData.Rows(row).Cells(0).Value = key
            fillRateData.Rows(row).Cells(1).Value = items.Item(key)
            row += 1
        Next

        row = fillRateData.RowCount
        items = mokai.Item("missingItems")
        fillRateData.RowCount += items.Count
        For Each key In items.Keys
            fillRateData.Rows(row).Cells(0).Value = key
            fillRateData.Rows(row).Cells(1).Value = items.Item(key)
            row += 1
        Next

        fill_rate.Controls.Add(fillRateData)

    End Sub
End Class
