
Imports System
Imports System.Globalization
Class fill_Rate_View
    Inherits tab_Layout
    Private calendar As MonthCalendar



    Public Sub New(ByRef tab As TabPage)
        MyBase.tabPage = tab
        For Each panel In tab.Controls
            For Each control In panel.controls
                If control.GetType() Is GetType(MonthCalendar) Then
                    calendar = control
                    AddHandler calendar.MouseUp, AddressOf Calendar_DateChanged
                    Exit For
                End If
            Next
        Next
    End Sub

    'shows the fill rate analisis (calls ALL necessary functions)
    Public Overrides Sub show_file()
        resetdataGrid()
        'get the selected date
        Dim dateEnd As Date = calendar.SelectionRange.End
        Dim dateStart As Date = calendar.SelectionRange.Start
        'get the brands in file
        Dim brands() As String = analisis.getBrands()
        analyze_fill_rate_results(dateStart, dateEnd, brands)
        totalProducts(brands)
        formatTotals(brands)
    End Sub

    Private Sub resetdataGrid()
        dataGrid.RowCount = 1
        dataGrid.ColumnCount = 1

        'format data grid
        dataGrid.AllowUserToAddRows = False


        dataGrid.RowCount = 7
        dataGrid.ColumnCount = 8
        dataGrid.Dock = DockStyle.Top
        dataGrid.Height = 500
        dataGrid.RowHeadersVisible = False
        dataGrid.ColumnHeadersVisible = False

        'titles
        dataGrid.Rows(0).Cells(1).Value = "Cajas Pedidas"
        dataGrid.Rows(0).Cells(2).Value = "Cajas Entregadas"
        dataGrid.Rows(0).Cells(3).Value = "Diferencia Cajas"
        dataGrid.Rows(0).Cells(4).Value = "% Nivel Servicio"
        dataGrid.Rows(0).Cells(5).Value = "Ordenado $"
        dataGrid.Rows(0).Cells(6).Value = "Recibido $"
        dataGrid.Rows(0).Cells(7).Value = "Faltante $"

        dataGrid.Rows(0).Cells(1).Style = titleFont
        dataGrid.Rows(0).Cells(2).Style = titleFont
        dataGrid.Rows(0).Cells(3).Style = titleFont
        dataGrid.Rows(0).Cells(4).Style = titleFont
        dataGrid.Rows(0).Cells(5).Style = titleFont
        dataGrid.Rows(0).Cells(6).Style = titleFont
        dataGrid.Rows(0).Cells(7).Style = titleFont

        dataGrid.Rows(5).Cells(0).Value = "FALTANTES"
        dataGrid.Rows(5).Cells(3).Value = "PENDIENTES"

        dataGrid.Rows(5).Cells(0).Style = subtitleFont
        dataGrid.Rows(5).Cells(3).Style = subtitleFont

        'show grid 
        tabPage.Controls.Add(dataGrid)
    End Sub

    'analyzes products in fill rate file one by one
    Private Sub analyze_fill_rate_results(ByVal startDate As Date, ByVal endDate As Date, ByVal brands() As String)
        'used to store pending items sence showMissingProducts will add new rows and lower the results 
        Dim pending As Hashtable = New Hashtable()

        For Each brand In brands
            'add row to fill with product results
            dataGrid.Rows.Insert(1, 1)
            'get product results 
            analisis.analyze(brand, endDate, startDate)
            Dim results As Hashtable = analisis.values

            'write brand name with format 
            dataGrid.Rows(1).Cells(0).Value = brand
            dataGrid.Rows(1).Cells(0).Style = subtitleFont

            'show brand results
            dataGrid.Rows(1).Cells(1).Value = results.Item("boxesOrdered")
            dataGrid.Rows(1).Cells(2).Value = results.Item("boxesDelivered")
            dataGrid.Rows(1).Cells(3).Value = results.Item("boxDiference")
            dataGrid.Rows(1).Cells(4).Value = FormatPercent(results.Item("servicePercent"))
            dataGrid.Rows(1).Cells(5).Value = Double.Parse(results.Item("amountOrdered")).ToString("C2", numberFormat)
            dataGrid.Rows(1).Cells(6).Value = Double.Parse(results.Item("amountDelivered")).ToString("C2", numberFormat)
            dataGrid.Rows(1).Cells(7).Value = Double.Parse(results.Item("amountLost")).ToString("C2", numberFormat)

            'show missing products for specific brand
            showMissingProducts(analisis.values.Item("missingItems"))
            'add brand and pending items to display after for loop 
            pending.Add(brand, results.Item("pendingItems"))
        Next
        'show all products for all brands 
        showPendingProducts(pending)
    End Sub

    Private Sub showMissingProducts(ByVal items As Hashtable)
        'start at last row 
        Dim row As Integer = dataGrid.RowCount - 1
        'add enough rows to display all products
        dataGrid.RowCount += items.Count + 1
        For Each key In items.Keys
            dataGrid.Rows(row).Cells(0).Value = key
            dataGrid.Rows(row).Cells(1).Value = items.Item(key)

            dataGrid.Rows(row).Cells(0).Style = groupFormat
            dataGrid.Rows(row).Cells(1).Style = groupFormat
            row += 1
        Next
    End Sub

    Private Sub showPendingProducts(ByVal hash As Hashtable)
        'add enough rows to display all products
        If (dataGrid.RowCount < 8 + hash.Keys.Count) Then
            dataGrid.RowCount += hash.Keys.Count + 1
        End If
        Dim row As Integer = 6 + hash.Keys.Count
        For Each key In hash.Keys
            dataGrid.Rows(row).Cells(3).Value = key
            dataGrid.Rows(row).Cells(4).Value = hash.Item(key)

            dataGrid.Rows(row).Cells(3).Style = groupFormat
            dataGrid.Rows(row).Cells(4).Style = groupFormat
            row += 1
        Next
    End Sub

    'adds all product values into one row 
    Private Sub totalProducts(ByVal brands() As String)
        dataGrid.Rows.Insert(brands.Count + 1, 1)
        dataGrid.Rows(brands.Count + 1).Cells(0).Value = "TOTAL"
        dataGrid.Rows(brands.Count + 1).Cells(0).Style = totalFormat
        For row As Integer = 1 To brands.Count
            For column As Integer = 1 To 7
                Dim add = Double.Parse(Replace(dataGrid.Rows(row).Cells(column).Value, "%", ""), numberStyle, numberFormat)
                dataGrid.Rows(brands.Count + 1).Cells(column).Value += add
                dataGrid.Rows(brands.Count + 1).Cells(column).Style = totalFormat
            Next
        Next
        'service percent is calculated differently 
        dataGrid.Rows(brands.Count + 1).Cells(4).Value = calculate_servicePercent(brands.Count)
    End Sub

    Private Function calculate_servicePercent(ByVal number As Integer)
        Dim sum As Double = 0
        For row As Integer = 1 To number
            sum += Double.Parse(Replace(dataGrid.Rows(row).Cells(4).Value, "%", ""))
        Next
        Debug.Print(sum)
        Return sum / number
    End Function

    Private Sub Calendar_DateChanged(sender As Object, e As MouseEventArgs)
        If Not (IsNothing(analisis)) Then
            show_file()
        End If
    End Sub

    'gives format to the totals row (not essencial)
    Private Sub formatTotals(ByVal brands() As String)
        Dim row As Integer = brands.Count + 1
        Dim percentFilled As Double = dataGrid.Rows(row).Cells(4).Value
        Dim totalOrdered As Double = dataGrid.Rows(row).Cells(5).Value
        Dim totalDelivered As Double = dataGrid.Rows(row).Cells(6).Value
        Dim difference As Double = dataGrid.Rows(row).Cells(7).Value

        dataGrid.Rows(row).Cells(4).Value = FormatPercent(percentFilled / 100)
        dataGrid.Rows(row).Cells(5).Value = Double.Parse(totalOrdered).ToString("C2", numberFormat)
        dataGrid.Rows(row).Cells(6).Value = Double.Parse(totalDelivered).ToString("C2", numberFormat)
        dataGrid.Rows(row).Cells(7).Value = Double.Parse(difference).ToString("C2", numberFormat)
    End Sub

End Class