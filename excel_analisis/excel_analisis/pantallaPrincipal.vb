Imports Excel = Microsoft.Office.Interop.Excel
Public Class pantallaPrincipal

    Private fill_rate_file As New file()
    Dim analisis As Analisis

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

        fill_rate_file.path = "C:\Users\Curso\Desktop\excel_analisis\FILL RATE TO CEDI EM"
        fill_rate_file.open_File()
        analisis = New fill_rate(fill_rate_file)
        analisis.analyze("FOUR LOK")

        Dim filtered As Analisis = New fill_rate(fill_rate_file)
        filtered.analyze("MOKAI")

        Dim data As DataGridView = New DataGridView
        data.RowCount = 8
        data.ColumnCount = 2
        data.Dock = DockStyle.Top
        data.Height = 200
        data.RowHeadersVisible = False
        data.ColumnHeadersVisible = False

        data.Rows(0).Cells(1).Value = "Cajas Pedidas"
        data.Rows(1).Cells(1).Value = analisis.values.Item("boxesOrdered")
        data.Rows(2).Cells(1).Value = filtered.values.Item("boxesOrdered")
        data.Rows(3).Cells(1).Value = data.Rows(1).Cells(1).Value + data.Rows(2).Cells(1).Value

        data.Rows(0).Cells(2).Value = "Cajas Entregadas"
        data.Rows(1).Cells(2).Value = analisis.values.Item("boxesDelivered")
        data.Rows(2).Cells(2).Value = filtered.values.Item("boxesDelivered")
        data.Rows(3).Cells(2).Value = data.Rows(1).Cells(2).Value + data.Rows(2).Cells(2).Value

        data.Rows(0).Cells(3).Value = "Diferencia Cajas"
        data.Rows(1).Cells(3).Value = analisis.values.Item("boxDiference")
        data.Rows(2).Cells(3).Value = filtered.values.Item("boxDiference")
        data.Rows(3).Cells(3).Value = data.Rows(1).Cells(1).Value + data.Rows(2).Cells(1).Value

        data.Rows(0).Cells(4).Value = "% Nivel Servicio"
        data.Rows(1).Cells(4).Value = analisis.values.Item("servicePercent")
        data.Rows(2).Cells(4).Value = filtered.values.Item("servicePercent")
        data.Rows(3).Cells(4).Value = ((data.Rows(3).Cells(2).Value / data.Rows(3).Cells(1).Value)) * 100

        data.Rows(0).Cells(5).Value = "Ordenado $"
        data.Rows(1).Cells(5).Value = analisis.values.Item("amountOrdered")
        data.Rows(2).Cells(5).Value = filtered.values.Item("amountOrdered")
        data.Rows(3).Cells(5).Value = data.Rows(1).Cells(5).Value + data.Rows(2).Cells(5).Value

        data.Rows(0).Cells(6).Value = "Recibido $"
        data.Rows(1).Cells(6).Value = analisis.values.Item("amountDelivered")
        data.Rows(2).Cells(6).Value = filtered.values.Item("amountDelivered")
        data.Rows(3).Cells(6).Value = data.Rows(1).Cells(6).Value + data.Rows(2).Cells(6).Value

        data.Rows(0).Cells(7).Value = "Faltante $"
        data.Rows(1).Cells(7).Value = analisis.values.Item("amountLost")
        data.Rows(2).Cells(7).Value = filtered.values.Item("amountLost")
        data.Rows(3).Cells(7).Value = data.Rows(1).Cells(7).Value + data.Rows(2).Cells(7).Value


        data.Rows(3).Cells(0).Value = "Isleña"

        data.Columns(4).DefaultCellStyle.Format = "N2"
        data.Columns(5).DefaultCellStyle.Format = "N2"
        data.Columns(6).DefaultCellStyle.Format = "N2"
        data.Columns(7).DefaultCellStyle.Format = "N2"

        fill_rate.Controls.Add(data)

    End Sub

    Private Sub FillRateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FillRateToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'fill_rate_file.path = OpenFileDialog1.FileName
            'fill_rate_file.open_File()
            'analisis = New fill_rate(fill_rate_file)
            'analisis.analyze()
        End If
    End Sub
End Class
