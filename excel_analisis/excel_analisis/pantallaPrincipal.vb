Imports System
Imports System.IO
Imports System.Text
Public Class pantallaPrincipal

    Private fill_rate_file As file
    Dim fill_rate_analisis As Analisis

    Private stock_rotation_file As file
    Dim analisis As Analisis

    Dim fillRateData As DataGridView = New DataGridView
    Dim stockRotationData As DataGridView = New DataGridView

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
            fill_rate_file = New file(OpenFileDialog1.FileName)
            fill_rate_analisis = New fill_rate(fill_rate_file)
            showFillRateFile()
        End If
    End Sub

    Private Sub StockRotationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockRotationToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            stock_rotation_file = New file(OpenFileDialog1.FileName)
            analisis = New stock_rotation(stock_rotation_file)
            showStockRotationFile()
        End If
    End Sub

    Private Sub Calendar_DateChanged(sender As Object, e As MouseEventArgs) Handles calendarFilter.MouseUp
        If Not (IsNothing(Me.fill_rate_file)) Then
            showFillRateFile()
        End If
    End Sub

    Private Sub showStockRotationFile()
        resetStockRotationDataGrid()
        Dim button As RadioButton = stock_rotation_control.Controls.OfType(Of RadioButton).FirstOrDefault(Function(r) r.Checked = True)
        analisis.analyze(button.Tag)
        show_stock_rotation_results()
    End Sub

    Private Sub show_stock_rotation_results()
        Dim results As DataTable = analisis.values("base")
        stockRotationData.RowCount += results.Rows.Count
        For row As Integer = 0 To results.Rows.Count - 1
            stockRotationData.Rows(row + 1).Cells(0).Value = results.Rows(row)("Brand Desc")
            stockRotationData.Rows(row + 1).Cells(1).Value = results.Rows(row)("Item Nbr")
            stockRotationData.Rows(row + 1).Cells(2).Value = results.Rows(row)("Signing Desc")
            stockRotationData.Rows(row + 1).Cells(3).Value = results.Rows(row)("Item Status")
            stockRotationData.Rows(row + 1).Cells(4).Value = results.Rows(row)("Item Type")
            stockRotationData.Rows(row + 1).Cells(5).Value = results.Rows(row)("Store Nbr")
            stockRotationData.Rows(row + 1).Cells(6).Value = results.Rows(row)("Store Name")
            stockRotationData.Rows(row + 1).Cells(7).Value = results.Rows(row)("Financial Rpt Code")
            stockRotationData.Rows(row + 1).Cells(8).Value = results.Rows(row)("Range 1 POS Qty")
            stockRotationData.Rows(row + 1).Cells(9).Value = results.Rows(row)("Range 2 POS Qty")
            stockRotationData.Rows(row + 1).Cells(10).Value = results.Rows(row)("Range 3 POS Qty")
            stockRotationData.Rows(row + 1).Cells(11).Value = results.Rows(row)("Range 4 POS Qty")
            stockRotationData.Rows(row + 1).Cells(12).Value = results.Rows(row)("Sales")
            stockRotationData.Rows(row + 1).Cells(13).Value = results.Rows(row)("Range 4 Curr Str On Hand Qty")
            stockRotationData.Rows(row + 1).Cells(14).Value = results.Rows(row)("Rotation")
        Next
    End Sub

    Private Sub resetStockRotationDataGrid()
        stockRotationData.RowCount = 1
        stockRotationData.RowCount = 1

        stockRotationData.RowCount = 2
        stockRotationData.ColumnCount = 18
        stockRotationData.Dock = DockStyle.Top
        stockRotationData.Height = 400
        stockRotationData.RowHeadersVisible = False
        stockRotationData.ColumnHeadersVisible = False

        stockRotationData.Rows(0).Cells(0).Value = "Brand"
        stockRotationData.Rows(0).Cells(1).Value = "Item Nbr"
        stockRotationData.Rows(0).Cells(2).Value = "Signing Desc"
        stockRotationData.Rows(0).Cells(3).Value = "Status"
        stockRotationData.Rows(0).Cells(4).Value = "Type"
        stockRotationData.Rows(0).Cells(5).Value = "Store Nbr"
        stockRotationData.Rows(0).Cells(6).Value = "Store Name"
        stockRotationData.Rows(0).Cells(7).Value = "Rpt"
        stockRotationData.Rows(0).Cells(8).Value = past_weeks(4, stock_rotation_file)
        stockRotationData.Rows(0).Cells(9).Value = past_weeks(3, stock_rotation_file)
        stockRotationData.Rows(0).Cells(10).Value = past_weeks(2, stock_rotation_file)
        stockRotationData.Rows(0).Cells(11).Value = past_weeks(1, stock_rotation_file)
        stockRotationData.Rows(0).Cells(12).Value = "Sales"
        stockRotationData.Rows(0).Cells(13).Value = "Inventario " & Date.Now.AddDays(-1).ToString("dd/MM")
        stockRotationData.Rows(0).Cells(14).Value = "Rotacion"
        stockRotationData.Rows(0).Cells(15).Value = "EDD"
        stockRotationData.Rows(0).Cells(16).Value = "Agente"
        stockRotationData.Rows(0).Cells(17).Value = "Merca"

        stock_Rotation_Tab.Controls.Add(stockRotationData)

    End Sub

    'gives the date of [weeks] past fridays since file creatio date as string 
    Private Function past_weeks(ByVal weeks As Integer, ByVal file As file)
        Dim objFileInfo As New FileInfo(file.path)
        Dim createDate As Date = objFileInfo.CreationTime

        Dim today As Date = Now

        For week As Integer = 1 To weeks
            While today.DayOfWeek <> DayOfWeek.Saturday
                today = today.AddDays(-1)
                Debug.Print(today.ToString("dd/MM/yyyy"))
            End While
            today = today.AddDays(-1)
        Next

        Return today.ToString("dd/MM/yyyy")
    End Function

    'shows the fill rate analisis (calls ALL necessary functions)
    Private Sub showFillRateFile()
        resetFillRateDataGrid()
        'get the selected date
        Dim dateEnd As Date = calendarFilter.SelectionRange.End
        'get the brands in file
        Dim brands() As String = fill_rate_analisis.getBrands()
        analyze_fill_rate_results(dateEnd, brands)
        totalProducts(brands)
    End Sub

    Private Sub resetFillRateDataGrid()
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
        fillRateData.Rows(5).Cells(3).Value = "PENDIENTES"

        'show grid 
        fill_rate.Controls.Add(fillRateData)
    End Sub

    'analyzes products in fill rate file one by one
    Private Sub analyze_fill_rate_results(ByVal endDate As Date, ByVal brands() As String)
        'used to store pending items since showMissingProducts will add new rows and lower the results 
        Dim pending As Hashtable = New Hashtable()
        For Each brand In brands
            'add row to fill with product results
            fillRateData.Rows.Insert(1, 1)
            'get product results 
            fill_rate_analisis.analyze(brand, endDate)
            Dim results As Hashtable = fill_rate_analisis.values
            'show product results
            fillRateData.Rows(1).Cells(0).Value = brand
            fillRateData.Rows(1).Cells(1).Value = results.Item("boxesOrdered")
            fillRateData.Rows(1).Cells(2).Value = results.Item("boxesDelivered")
            fillRateData.Rows(1).Cells(3).Value = results.Item("boxDiference")
            fillRateData.Rows(1).Cells(4).Value = results.Item("servicePercent")
            fillRateData.Rows(1).Cells(5).Value = results.Item("amountOrdered")
            fillRateData.Rows(1).Cells(6).Value = results.Item("amountDelivered")
            fillRateData.Rows(1).Cells(7).Value = results.Item("amountLost")
            'show missing products for specific brand
            showMissingProducts(fill_rate_analisis.values.Item("missingItems"))
            'add brand and pending items to display after for loop 
            pending.Add(brand, results.Item("pendingItems"))
        Next
        showPendingProducts(pending)
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

    Private Sub showPendingProducts(ByVal hash As Hashtable)
        'add enough rows to display all products
        If (fillRateData.RowCount < 8 + hash.Keys.Count) Then
            fillRateData.RowCount += hash.Keys.Count + 1
        End If
        Dim row As Integer = 6 + hash.Keys.Count
        For Each key In hash.Keys
            fillRateData.Rows(row).Cells(3).Value = key
            fillRateData.Rows(row).Cells(4).Value = hash.Item(key)
            row += 1
        Next
    End Sub

    'adds all product values into one row 
    Private Sub totalProducts(ByVal brands() As String)
        fillRateData.Rows.Insert(brands.Count + 1, 1)
        fillRateData.Rows(brands.Count + 1).Cells(0).Value = "TOTAL"
        For row As Integer = 1 To brands.Count
            For column As Integer = 1 To 7
                fillRateData.Rows(brands.Count + 1).Cells(column).Value += fillRateData.Rows(row).Cells(column).Value
            Next
        Next
        'service percent is calculated differently 
        fillRateData.Rows(brands.Count + 1).Cells(4).Value = calculate_servicePercent(brands.Count)
    End Sub

    Private Function calculate_servicePercent(ByVal number As Integer)
        Dim sum As Double = 0
        For row As Integer = 1 To number
            sum += fillRateData.Rows(row).Cells(4).Value
        Next
        Debug.Print(sum)
        Return sum / number
    End Function

End Class
