Class stock_RotationStatus_View
    Inherits tab_Layout

    Public Sub New(ByRef tab As TabPage)
        MyBase.tabPage = tab
    End Sub

    Public Overrides Sub show_file()
        resetdataGrid()
        analyze_Brand_Status()
        analyze_Agent_Status()
        analyze_Priorities()
    End Sub

    Private Sub resetdataGrid()
        dataGrid.RowCount = 1
        dataGrid.RowCount = 1

        dataGrid.RowCount = 3
        dataGrid.ColumnCount = 10
        dataGrid.Dock = DockStyle.Top
        dataGrid.Height = 400
        dataGrid.RowHeadersVisible = False
        dataGrid.ColumnHeadersVisible = False

        dataGrid.Rows(0).Cells(0).Value = "Total Walmart | Marca"
        dataGrid.Rows(0).Cells(1).Value = "OK"
        dataGrid.Rows(0).Cells(2).Value = "NO Rotación"
        dataGrid.Rows(0).Cells(3).Value = "Out of Stock"

        dataGrid.Rows(0).Cells(5).Value = "Total Walmart | Agentes"
        dataGrid.Rows(0).Cells(6).Value = "OK"
        dataGrid.Rows(0).Cells(7).Value = "NO Rotación"
        dataGrid.Rows(0).Cells(8).Value = "Out of Stock"

        dataGrid.Columns(1).DefaultCellStyle.Format = "N2"
        dataGrid.Columns(2).DefaultCellStyle.Format = "N2"
        dataGrid.Columns(3).DefaultCellStyle.Format = "N2"

        dataGrid.Columns(6).DefaultCellStyle.Format = "N2"
        dataGrid.Columns(7).DefaultCellStyle.Format = "N2"
        dataGrid.Columns(8).DefaultCellStyle.Format = "N2"

        tabPage.Controls.Add(dataGrid)
    End Sub

    Private Sub analyze_Brand_Status()
        'get list of brands 
        Dim brands As Hashtable = analisis.values.Item("brandStatus")

        For Each brand In brands.Keys
            dataGrid.Rows.Insert(1, 1)
            dataGrid.Rows(1).Cells(0).Value = brand
            'get list of store codes for brand
            Dim storeCodes As Hashtable = brands.Item(brand)

            Dim okList = New List(Of Double)
            Dim nrList = New List(Of Double)
            Dim oosList = New List(Of Double)

            For Each code In storeCodes.Keys
                'get OK NR and OOS for the store code in the brand
                Dim statusPercent As Hashtable = storeCodes.Item(code)

                dataGrid.Rows.Insert(2, 1)

                dataGrid.Rows(2).Cells(0).Value = code
                dataGrid.Rows(2).Cells(1).Value = statusPercent.Item("OK")
                dataGrid.Rows(2).Cells(2).Value = statusPercent.Item("NR")
                dataGrid.Rows(2).Cells(3).Value = statusPercent.Item("OOS")

                okList.Add(statusPercent.Item("OK"))
                nrList.Add(statusPercent.Item("NR"))
                oosList.Add(statusPercent.Item("OOS"))
            Next
            'Display total for brand 
            dataGrid.Rows(1).Cells(1).Value = okList.Sum / okList.Count
            dataGrid.Rows(1).Cells(2).Value = nrList.Sum / nrList.Count
            dataGrid.Rows(1).Cells(3).Value = oosList.Sum / oosList.Count
        Next
    End Sub

    Private Sub analyze_Agent_Status()
        'get list of agents
        Dim agents As Hashtable = analisis.values.Item("agentStatus")

        If (dataGrid.RowCount < agents.Count) Then
            dataGrid.RowCount += agents.Count
        End If

        Dim row = 1
        For Each agent In agents.Keys
            'get agent status percent pairs 
            Dim agentStatus As Hashtable = agents.Item(agent)
            dataGrid.Rows(row).Cells(5).Value = agent
            dataGrid.Rows(row).Cells(6).Value = agentStatus.Item("OK")
            dataGrid.Rows(row).Cells(7).Value = agentStatus.Item("NR")
            dataGrid.Rows(row).Cells(8).Value = agentStatus.Item("OOS")
            row += 1
        Next
    End Sub

    'shows the priorities
    Private Sub analyze_Priorities()
        'wirtes the titles for the priorities
        write_Priorities()
        dataGrid.RowCount += 1
        Dim priorities As DataTable = analisis.values.Item("priority")

        Dim gamRow As Integer = dataGrid.RowCount - 2
        Dim ruralRow As Integer = dataGrid.RowCount - 2

        For Each row As DataRow In priorities.Rows
            'adds the line on one side or another using the column start position 
            If (row("Zona").Equals("GAM")) Then
                add_Priority(gamRow, 0, row)
                gamRow += 1
            Else
                add_Priority(ruralRow, 5, row)
                ruralRow += 1
            End If

            'makes sure there at least two rows after the last element of priorities. 
            If gamRow = dataGrid.RowCount - 1 Or ruralRow = dataGrid.RowCount - 1 Then
                dataGrid.RowCount += 1
            End If
        Next
    End Sub

    'adds a line to the priority at the row and column specified
    Private Sub add_Priority(ByVal row As Integer, ByVal column As Integer, ByVal infoRow As DataRow)
        dataGrid.Rows(row).Cells(column).Value = infoRow("Store Name")
        dataGrid.Rows(row).Cells(column + 1).Value = infoRow("Agente")
        dataGrid.Rows(row).Cells(column + 2).Value = infoRow("Merca")
        dataGrid.Rows(row).Cells(column + 3).Value = infoRow("NRstores") & "/" & infoRow("totalStores")
    End Sub

    'writes the titles for priorities at the last row of the data grid view.
    Private Sub write_Priorities()
        Dim lastRow As Integer = dataGrid.RowCount - 1
        dataGrid.RowCount += 3
        dataGrid.Rows(lastRow).Cells(0).Value = "Prioridades"

        dataGrid.Rows(lastRow + 2).Cells(0).Value = "GAM"
        dataGrid.Rows(lastRow + 2).Cells(1).Value = "Agente"
        dataGrid.Rows(lastRow + 2).Cells(2).Value = "Merca"
        dataGrid.Rows(lastRow + 2).Cells(3).Value = "Qty Status NR"

        dataGrid.Rows(lastRow + 2).Cells(5).Value = "Rural"
        dataGrid.Rows(lastRow + 2).Cells(6).Value = "Agente"
        dataGrid.Rows(lastRow + 2).Cells(7).Value = "Merca"
        dataGrid.Rows(lastRow + 2).Cells(8).Value = "Qty Status NR"
    End Sub

    Private Sub analyze_No_RotationStores()

    End Sub
End Class
