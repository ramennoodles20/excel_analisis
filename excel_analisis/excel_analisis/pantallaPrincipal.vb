Imports Excel = Microsoft.Office.Interop.Excel
Imports System
Imports System.IO
Imports System.Text
Public Class pantallaPrincipal

    Private fill_rate_file As New file()
    Dim analisis As Analisis

    Dim fillRateData As DataGridView = New DataGridView
    Dim products As New List(Of String)

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
        load_filters()
    End Sub

    Private Sub load_filters()
        Dim reader As StreamReader = New StreamReader("C:\Users\Curso\Desktop\excel_analisis\fill rate filters.txt")
        Do While reader.Peek() >= 0
            Dim line As String = reader.ReadLine
            add_new_filter(line)
        Loop
        reader.Close()
    End Sub

    Private Sub FillRateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FillRateToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            fill_rate_file.path = OpenFileDialog1.FileName
            fill_rate_file.open_File()
            analisis = New fill_rate(fill_rate_file)
            showFillRateFile()
        End If
    End Sub

    Private Sub resetDataGrid()
        fillRateData.RowCount = 1
        fillRateData.ColumnCount = 1

        'format data grid
        fillRateData.RowCount = 7
        fillRateData.ColumnCount = 10
        fillRateData.Dock = DockStyle.Top
        fillRateData.Height = 400
        fillRateData.RowHeadersVisible = False
        fillRateData.ColumnHeadersVisible = False

        'column formats
        fillRateData.Columns(4).DefaultCellStyle.Format = "N2"
        fillRateData.Columns(5).DefaultCellStyle.Format = "N2"
        fillRateData.Columns(6).DefaultCellStyle.Format = "N2"
        fillRateData.Columns(7).DefaultCellStyle.Format = "N2"

        'titles
        fillRateData.Rows(0).Cells(1).Value = "Cajas Pedidas"
        fillRateData.Rows(0).Cells(2).Value = "Cajas Entregadas"
        fillRateData.Rows(0).Cells(3).Value = "Diferencia Cajas"
        fillRateData.Rows(0).Cells(4).Value = "% Nivel Servicio"
        fillRateData.Rows(0).Cells(5).Value = "Ordenado $"
        fillRateData.Rows(0).Cells(6).Value = "Recibido $"
        fillRateData.Rows(0).Cells(7).Value = "Faltante $"
        fillRateData.Rows(5).Cells(0).Value = "FALTANTES"

        'show grid 
        fill_rate.Controls.Add(fillRateData)
    End Sub

    Private Sub showFillRateFile()
        resetDataGrid()
        analyzeProductResults()
        totalProducts()
    End Sub

    Private Sub analyzeProductResults()
        For Each product In products
            'add row to fill with product results
            fillRateData.Rows.Insert(1, 1)
            'get product results 
            analisis.analyze(product)
            Dim results As Hashtable = analisis.values
            'show product results
            fillRateData.Rows(1).Cells(1).Value = results.Item("boxesOrdered")
            fillRateData.Rows(1).Cells(2).Value = results.Item("boxesDelivered")
            fillRateData.Rows(1).Cells(3).Value = results.Item("boxDiference")
            fillRateData.Rows(1).Cells(4).Value = results.Item("servicePercent")
            fillRateData.Rows(1).Cells(5).Value = results.Item("amountOrdered")
            fillRateData.Rows(1).Cells(6).Value = results.Item("amountDelivered")
            fillRateData.Rows(1).Cells(7).Value = results.Item("amountLost")
            showMissingProducts(analisis.values.Item("missingItems"))
        Next
    End Sub

    Private Sub showMissingProducts(ByVal items As Hashtable)
        'start at last row 
        Dim row As Integer = fillRateData.RowCount - 1
        'add enough rows to display all products
        fillRateData.RowCount += items.Count + 1
        For Each key In items.Keys
            fillRateData.Rows(row).Cells(0).Value = key
            fillRateData.Rows(row).Cells(1).Value = items.Item(key)
            row += 1
        Next
    End Sub

    Private Sub totalProducts()
        fillRateData.Rows.Insert(products.Count + 1, 1)
        For row As Integer = 1 To products.Count
            For column As Integer = 1 To 7
                fillRateData.Rows(products.Count + 1).Cells(column).Value += fillRateData.Rows(row).Cells(column).Value
            Next
        Next
        'service percent is calculated differently 
        fillRateData.Rows(products.Count + 1).Cells(4).Value = (fillRateData.Rows(products.Count + 1).Cells(2).Value / fillRateData.Rows(products.Count + 1).Cells(1).Value) * 100
    End Sub


    Private Sub add_new_filter(ByVal text As String)
        Dim filterItem As New filterItem(text)
        filterList.Controls.Add(filterItem)
        products.Add(text)
    End Sub

    Private Sub add_filter_Click(sender As Object, e As EventArgs) Handles add_filter.Click
        add_new_filter(filter_text.Text)
        showFillRateFile()
    End Sub

    Private Sub filter_removed(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles filterList.ControlRemoved
        products.Remove(e.Control.Name)
    End Sub
End Class
