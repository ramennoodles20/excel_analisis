Class stock_rotation
    Inherits Analisis

    Private routes_file As file
    Dim tester As Integer = 0
    Sub New(ByVal pFile As file)
        MyBase.New(pFile)
    End Sub

    'Necessary 
    Public Overrides Sub analyze(filter As String, endDate As Date)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub analyze()
        routes_file = New file(global_Paths.routes_path)
        values = New Hashtable
        save_table()
        check_Store_Status()
        check_agent_status()
        check_priority()
    End Sub

    Private Sub save_table()
        file.make_query(
                " SELECT [Brand Desc], [Item Nbr], [Signing Desc], [Item Status], [Item Type], [rutas.Store Nbr], [rutas.Store Name]," &
                " [Financial Rpt Code], [Range 1 POS Qty], [Range 2 POS Qty], [Range 3 POS Qty], [Range 4 POS Qty]," &
                " [Range 4 Curr Str On Hand Qty], [Range 4 Curr Traited Store/Item Comb], [EDD], [Merca], [Agente]" &
                " FROM(" & routes_file.path & "." & routes_file.activeTable & " rutas INNER JOIN " & file.path & "." & file.activeTable & " stock ON rutas.[Store Nbr] = stock.[Store Nbr])" &
                " ORDER BY [rutas.Store Name], [Range 4 Curr Str On Hand Qty] DESC"
                )
        Dim base_values As DataTable = file.table
        check_sales(base_values)
        values.Add("base", base_values)
    End Sub

    Private Sub check_sales(ByRef table As DataTable)
        table.Columns.Add("Rotation")
        table.Columns.Add("Sales")
        For Each line In table.Rows
            check_rotations(line)
        Next
    End Sub

    Private Sub check_rotations(ByRef line As DataRow)
        line("Sales") = line("Range 1 POS Qty") + line("Range 2 POS Qty") + line("Range 3 POS Qty") + line("Range 4 POS Qty")
        If (line("Sales") > 0) Then
            line("Rotation") = "OK"
        ElseIf (line("Range 4 Curr Str On Hand Qty") <= 0) Then
            line("Rotation") = "Out of Stock"
        Else
            line("Rotation") = "No Rotation"
        End If
    End Sub

    Private Sub check_Store_Status()
        Dim brands() As String = getBrands()
        Dim codes() As String = getStoreTypes()

        'stores all brand information with store type percentages
        Dim brand_Status As Hashtable = New Hashtable()

        For Each brand In brands
            'stores store type, percentage pairs 
            Dim brandStoreStatus As Hashtable = New Hashtable()

            For Each code In codes
                Dim storeStatus As Hashtable = New Hashtable()
                'total stores with code [code] that carry the brand [brand]
                file.make_query("SELECT COUNT([Brand Desc]) AS productCount" &
                                " FROM " & file.activeTable &
                                " WHERE([Financial Rpt Code] = '" & code & "') AND ([Brand Desc] = '" & brand & "')"
                                )
                Dim storeCount As Integer = file.table.Rows(0)("productCount")

                'total stores with OK status with code [code] that carry the brand [brand]
                file.make_query("SELECT COUNT([Brand Desc]) AS productCount" &
                                " FROM " & file.activeTable &
                                " WHERE ([Financial Rpt Code] = '" & code & "') AND ([Range 1 POS Qty] + [Range 2 POS Qty] + [Range 3 POS Qty] + [Range 4 POS Qty] > 0)" &
                                " AND ([Brand Desc] = '" & brand & "')")
                Dim okCount As Integer = file.table.Rows(0)("productCount")

                'total stores with NO Rotation status with code [code] that carry the brand [brand]
                file.make_query("SELECT        COUNT([Brand Desc]) AS productCount" &
                                " FROM " & file.activeTable &
                                " WHERE([Financial Rpt Code] = '" & code & "')" &
                                " AND ([Range 1 POS Qty] + [Range 2 POS Qty] + [Range 3 POS Qty] + [Range 4 POS Qty] <= 0)" &
                                " AND ([Range 4 Curr Str On Hand Qty] > 0)  And ([Brand Desc] = '" & brand & "')"
                                )
                Dim NRCount As Integer = file.table.Rows(0)("productCount")

                'total stores with Out of Stock status with code [code] that carry the brand [brand]
                file.make_query("SELECT COUNT([Brand Desc]) As productCount" &
                                " FROM " & file.activeTable &
                                " WHERE([Financial Rpt Code] = '" & code & "')" &
                                " AND ([Range 1 POS Qty] + [Range 2 POS Qty] + [Range 3 POS Qty] + [Range 4 POS Qty] <= 0)" &
                                " AND ([Range 4 Curr Str On Hand Qty] <= 0) And ([Brand Desc] = '" & brand & "')"
                                )
                Dim OutOfStockCount As Integer = file.table.Rows(0)("productCount")

                'storing status with percentage 
                storeStatus.Add("OK", (okCount / storeCount) * 100)
                storeStatus.Add("NR", (NRCount / storeCount) * 100)
                storeStatus.Add("OOS", (OutOfStockCount / storeCount) * 100)

                'only add store if it carries the brand 
                If Not (Double.IsNaN(storeStatus.Item("OK")) And Double.IsNaN(storeStatus.Item("NR")) And Double.IsNaN(storeStatus.Item("OOS"))) Then
                    brandStoreStatus.Add(code, storeStatus)
                End If
            Next
            'add all stores with percentages together with brand name  
            brand_Status.Add(brand, brandStoreStatus)
        Next
        values.Add("brandStatus", brand_Status)
    End Sub

    Private Sub check_agent_status()
        Dim agents() As String = getAgents()
        Dim codes() As String = getStoreTypes()
        'stores all agent information with store type percentages
        Dim agent_Status As Hashtable = New Hashtable()
        For Each agent In agents
            Dim agentStoreStatus As Hashtable = New Hashtable()
            file.make_query("SELECT COUNT([Agente]) as stores" &
                            " FROM(" & routes_file.path & "." & routes_file.activeTable & " rutas INNER JOIN " & file.path & "." & file.activeTable & " stock ON rutas.[Store Nbr] = stock.[Store Nbr])" &
                            " WHERE(Agente = '" & agent & "')")
            Dim totalCount As Integer = file.table.Rows(0)("stores")

            'ok status for stores supervised by [agent]
            file.make_query("SELECT COUNT([Agente]) as stores" &
                            " FROM(" & routes_file.path & "." & routes_file.activeTable & " rutas INNER JOIN " & file.path & "." & file.activeTable & " stock ON rutas.[Store Nbr] = stock.[Store Nbr])" &
                            " WHERE (Agente = '" & agent & "')" &
                            " AND ([Range 1 POS Qty] + [Range 2 POS Qty] + [Range 3 POS Qty] + [Range 4 POS Qty] > 0)")
            Dim okCount As Integer = file.table.Rows(0)("stores")

            'NO Rotation status for stores supervised by [agent]
            file.make_query("SELECT COUNT([Agente]) as stores" &
                            " FROM(" & routes_file.path & "." & routes_file.activeTable & " rutas INNER JOIN " & file.path & "." & file.activeTable & " stock ON rutas.[Store Nbr] = stock.[Store Nbr])" &
                            " WHERE (Agente = '" & agent & "')" &
                            " AND ([Range 1 POS Qty] + [Range 2 POS Qty] + [Range 3 POS Qty] + [Range 4 POS Qty] <= 0) AND ([Range 4 Curr Str On Hand Qty] > 0)")
            Dim NRCount As Integer = file.table.Rows(0)("stores")

            'Out of Stock status for stores supervised by [agent]
            file.make_query("SELECT COUNT([Agente]) as stores" &
                            " FROM(" & routes_file.path & "." & routes_file.activeTable & " rutas INNER JOIN " & file.path & "." & file.activeTable & " stock ON rutas.[Store Nbr] = stock.[Store Nbr])" &
                            " WHERE (Agente = '" & agent & "')" &
                            " AND ([Range 1 POS Qty] + [Range 2 POS Qty] + [Range 3 POS Qty] + [Range 4 POS Qty] <= 0) AND ([Range 4 Curr Str On Hand Qty] < 0)")
            Dim OutOfStockCount As Integer = file.table.Rows(0)("stores")

            'storing status with percentage 
            agentStoreStatus.Add("OK", (okCount / totalCount) * 100)
            agentStoreStatus.Add("NR", (NRCount / totalCount) * 100)
            agentStoreStatus.Add("OOS", (OutOfStockCount / totalCount) * 100)

            agent_Status.Add(agent, agentStoreStatus)
        Next
        values.Add("agentStatus", agent_Status)
    End Sub

    Private Sub check_priority()
        file.make_query(
            "SELECT DISTINCT t2.stock.[Store Name], t2.Agente, t2.Merca, t1.NRstores, t2.totalStores, t1.NRstores / t2.totalStores As percentage, t2.Zona" &
                " FROM(" &
                    " (SELECT [Store Name], COUNT([Store Name]) AS NRstores" &
                            " FROM " & file.path & "." & file.activeTable &
                            " WHERE([Range 1 POS Qty] + [Range 2 POS Qty] + [Range 3 POS Qty] + [Range 4 POS Qty] <= 0)" &
                            " GROUP BY [Store Name]) t1 RIGHT OUTER JOIN" &
                    " (SELECT stock.[Store Name], Agente, Merca, Zona, COUNT(stock.[Store Name]) AS totalStores" &
                            " FROM (" & routes_file.path & "." & routes_file.activeTable & " rutas RIGHT OUTER JOIN " & file.path & "." & file.activeTable & " stock ON rutas.[Store Nbr] = stock.[Store Nbr])" &
                            " GROUP BY stock.[Store Name], Agente, Merca, Zona) t2 ON t1.[Store Name] = t2.[Store Name])" &
            " ORDER BY t2.Zona"
                        )
        Dim priority As DataTable = file.table
        values.Add("priority", priority)
    End Sub

    'gets all agents from routes file 
    Private Function getAgents()
        file.make_query("SELECT [Agente]" &
                        " FROM " & routes_file.path & "." & routes_file.activeTable &
                        " WHERE (Agente is not NULL)" &
                        " GROUP BY [Agente]"
                        )
        Dim agents(file.table.Rows.Count - 1) As String
        For row As Integer = 0 To file.table.Rows.Count - 1
            agents(row) = file.table(row)(0)
        Next
        Return agents
    End Function
End Class
