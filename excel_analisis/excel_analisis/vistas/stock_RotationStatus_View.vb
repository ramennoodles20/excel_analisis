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
        analyze_NRstores()
    End Sub

    Private Sub resetdataGrid()
        dataGrid.AllowUserToAddRows = False
        dataGrid.RowCount = 1
        dataGrid.RowCount = 1

        dataGrid.RowCount = 7
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

        dataGrid.Rows(3).Cells(0).Value = "Prioridades"

        dataGrid.Columns(1).DefaultCellStyle.Format = "N2"
        dataGrid.Columns(2).DefaultCellStyle.Format = "N2"
        dataGrid.Columns(3).DefaultCellStyle.Format = "N2"
        dataGrid.Columns(4).DefaultCellStyle.Format = "N2"

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
        Dim priorities As DataTable = analisis.values.Item("priority")

        'all titles will be written at the firstIndex row
        Dim firstIndex As Integer = dataGrid.RowCount - 2
        Dim currentRow As Integer = dataGrid.RowCount - 2
        Dim startColumn = 0
        Dim currentArea As String

        currentArea = nullToString(priorities.Rows(1)("Zona"))
        write_Priorities(firstIndex - 1, startColumn, currentArea)
        For Each row As DataRow In priorities.Rows
            'get the zone for the current row
            Dim rowZone As String
            rowZone = nullToString(row("Zona"))

            'if the zone is different then it will be placed in a different index 
            If Not rowZone.Equals(currentArea) Then
                currentArea = rowZone
                currentRow = firstIndex
                startColumn += 5
                write_Priorities(firstIndex - 1, startColumn, currentArea)
            End If

            'If there are no NRStores the store will not be added to the priority list
            If Not IsDBNull(row("NRStores")) Then
                add_Priority(currentRow, startColumn, row)
                currentRow += 1
            End If

            'makes sure there at least two rows after the last element of priorities. 
            If currentRow >= dataGrid.RowCount - 2 Then
                dataGrid.RowCount += 1
            End If

            'makes sure there are enough columns for a new priority
            If startColumn + 5 >= dataGrid.ColumnCount Then
                dataGrid.ColumnCount += 5
            End If
        Next
    End Sub

    'writes the priority row at the row statring from the column 
    Private Sub add_Priority(ByVal row As Integer, ByVal column As Integer, ByVal infoRow As DataRow)
        Dim agente As String = nullToString(infoRow("Agente"))
        Dim merca As String = nullToString(infoRow("Merca"))
        dataGrid.Rows(row).Cells(column).Value = infoRow("Store Name")
        dataGrid.Rows(row).Cells(column + 1).Value = agente
        dataGrid.Rows(row).Cells(column + 2).Value = merca
        dataGrid.Rows(row).Cells(column + 3).Value = infoRow("NRstores") & "/" & infoRow("totalStores")
    End Sub

    'writes the titles for priorities at the last row of the data grid view.
    Private Sub write_Priorities(ByVal row As Integer, ByVal column As Integer, ByVal area As String)
        dataGrid.Rows(row).Cells(column).Value = area
        dataGrid.Rows(row).Cells(column + 1).Value = "Agente"
        dataGrid.Rows(row).Cells(column + 2).Value = "Merca"
        dataGrid.Rows(row).Cells(column + 3).Value = "Qty Status NR"
    End Sub

    Private Sub analyze_NRstores()
        Dim stores As DataTable = analisis.values.Item("priority")
        stores = stores.Select("", "percentage DESC").CopyToDataTable
        dataGrid.Rows.Add({"NO Rotation By Stores"})
        Dim titles() As String = {
                                   "Tienda",
                                   "Agente",
                                   "Merca",
                                   "Qty Skus",
                                   "% NR"}
        dataGrid.Rows.Add(titles)
        For row As Integer = 0 To stores.Rows.Count - 1
            Dim info() As String = {stores.Rows(row)("Store Name"),
                                    nullToString(stores.Rows(row)("Agente")),
                                    nullToString(stores.Rows(row)("Merca")),
                                    nullToZero(stores.Rows(row)("NRstores")) & "/" & stores.Rows(row)("totalStores"),
                                    FormatPercent(nullToZero(stores.Rows(row)("percentage")), 2)}
            dataGrid.Rows.Add(info)
        Next
    End Sub

    Private Function nullToZero(ByRef value As Object)
        If IsDBNull(value) Then
            value = 0
        End If
        Return value
    End Function

    Private Function nullToString(ByRef value As Object)
        If IsDBNull(value) Then
            value = "No Disponible"
        End If
        Return value
    End Function
End Class
