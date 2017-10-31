Imports System.IO

Class stock_RotationData_View
    Inherits tab_Layout

    Public Sub New(ByRef tab As TabPage)
        MyBase.tabPage = tab

    End Sub

    Public Overrides Sub show_file()
        resetdataGrid()
        show_stock_rotation_results()
    End Sub

    Private Sub show_stock_rotation_results()
        Dim results As DataTable = analisis.values("base")
        dataGrid.RowCount += results.Rows.Count
        For row As Integer = 0 To results.Rows.Count - 1
            dataGrid.Rows(row + 1).Cells(0).Value = results.Rows(row)("Brand Desc")
            dataGrid.Rows(row + 1).Cells(1).Value = results.Rows(row)("Item Nbr")
            dataGrid.Rows(row + 1).Cells(2).Value = results.Rows(row)("Signing Desc")
            dataGrid.Rows(row + 1).Cells(3).Value = results.Rows(row)("Item Status")
            dataGrid.Rows(row + 1).Cells(4).Value = results.Rows(row)("Item Type")
            dataGrid.Rows(row + 1).Cells(5).Value = results.Rows(row)("rutas.Store Nbr")
            dataGrid.Rows(row + 1).Cells(6).Value = results.Rows(row)("rutas.Store Name")
            dataGrid.Rows(row + 1).Cells(7).Value = results.Rows(row)("Financial Rpt Code")
            dataGrid.Rows(row + 1).Cells(8).Value = results.Rows(row)("Range 1 POS Qty")
            dataGrid.Rows(row + 1).Cells(9).Value = results.Rows(row)("Range 2 POS Qty")
            dataGrid.Rows(row + 1).Cells(10).Value = results.Rows(row)("Range 3 POS Qty")
            dataGrid.Rows(row + 1).Cells(11).Value = results.Rows(row)("Range 4 POS Qty")
            dataGrid.Rows(row + 1).Cells(12).Value = results.Rows(row)("Sales")
            dataGrid.Rows(row + 1).Cells(13).Value = results.Rows(row)("Range 4 Curr Str On Hand Qty")
            dataGrid.Rows(row + 1).Cells(14).Value = results.Rows(row)("Rotation")
            dataGrid.Rows(row + 1).Cells(15).Value = results.Rows(row)("Range 4 Curr Traited Store/Item Comb")
            dataGrid.Rows(row + 1).Cells(16).Value = results.Rows(row)("EDD")
            dataGrid.Rows(row + 1).Cells(17).Value = results.Rows(row)("Agente")
            dataGrid.Rows(row + 1).Cells(18).Value = results.Rows(row)("Merca")
        Next
    End Sub

    Private Sub resetdataGrid()
        dataGrid.RowCount = 1
        dataGrid.RowCount = 1

        dataGrid.RowCount = 2
        dataGrid.ColumnCount = 19
        dataGrid.Dock = DockStyle.Top
        dataGrid.Height = 500
        dataGrid.RowHeadersVisible = False
        dataGrid.ColumnHeadersVisible = False

        dataGrid.Rows(0).Cells(0).Value = "Brand"
        dataGrid.Rows(0).Cells(1).Value = "Item Nbr"
        dataGrid.Rows(0).Cells(2).Value = "Signing Desc"
        dataGrid.Rows(0).Cells(3).Value = "Status"
        dataGrid.Rows(0).Cells(4).Value = "Type"
        dataGrid.Rows(0).Cells(5).Value = "Store Nbr"
        dataGrid.Rows(0).Cells(6).Value = "Store Name"
        dataGrid.Rows(0).Cells(7).Value = "Rpt"
        dataGrid.Rows(0).Cells(8).Value = past_weeks(4, analisis.file)
        dataGrid.Rows(0).Cells(9).Value = past_weeks(3, analisis.file)
        dataGrid.Rows(0).Cells(10).Value = past_weeks(2, analisis.file)
        dataGrid.Rows(0).Cells(11).Value = past_weeks(1, analisis.file)
        dataGrid.Rows(0).Cells(12).Value = "Sales"
        dataGrid.Rows(0).Cells(13).Value = "Inventario " & Date.Now.AddDays(-1).ToString("dd/MM")
        dataGrid.Rows(0).Cells(14).Value = "Rotacion"
        dataGrid.Rows(0).Cells(15).Value = "Valid"
        dataGrid.Rows(0).Cells(16).Value = "EDD"
        dataGrid.Rows(0).Cells(17).Value = "Agente"
        dataGrid.Rows(0).Cells(18).Value = "Merca"

        tabPage.Controls.Add(dataGrid)

    End Sub

    'gives the date of [weeks] past fridays since file creation date as string 
    Private Function past_weeks(ByVal weeks As Integer, ByVal file As file)
        Dim objFileInfo As New FileInfo(file.path)
        Dim createDate As Date = objFileInfo.CreationTime

        Dim today As Date = Now

        For week As Integer = 1 To weeks
            While today.DayOfWeek <> DayOfWeek.Saturday
                today = today.AddDays(-1)
            End While
            today = today.AddDays(-1)
        Next
        Return today.ToString("dd/MM/yyyy")
    End Function
End Class
