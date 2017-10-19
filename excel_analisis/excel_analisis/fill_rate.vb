Imports Excel = Microsoft.Office.Interop.Excel

Class fill_rate
    Inherits Analisis

    Sub New(ByVal pFile As file)
        MyBase.New(pFile)
    End Sub

    Public Overrides Sub analyze()
        MsgBox("No ha escogido un rango de fecha")
    End Sub

    Overrides Sub analyze(ByVal brand As String, ByVal endDate As Date)
        file.make_query(
                        " SELECT  [Whse Qty Ordered (eaches)], [WHPK Qty], [Whse Qty Received (eaches)], [VNPK Qty], [Unit Cost]" &
                        " FROM " & file.activeTable &
                        " WHERE ([PO Cancel Date] < '" & endDate.ToString("MM/dd/yyyy") & "')" &
                        " AND ([Brand Desc] = '" & brand & "')"
                        )

        values = New Hashtable()
        Dim boxOrdered As Integer = sum_division(0, 1)
        Dim boxDelivered As Integer = sum_division(2, 3)
        Dim boxDiference As Integer = boxOrdered - boxDelivered
        Dim servicePercent As Double = (boxDelivered / boxOrdered) * 100
        Dim amountOrdered As Double = sum_multiplication(0, 4)
        Dim amountDeliviered As Double = sum_multiplication(2, 4)
        Dim amountLost As Double = amountOrdered - amountDeliviered
        Dim missingItems As Hashtable = New Hashtable()
        missing_Items(missingItems, endDate, brand)
        Dim pendingItems As Integer
        pending_Items(pendingItems, endDate, brand)

        values.Add("boxesOrdered", boxOrdered)
        values.Add("boxesDelivered", boxDelivered)
        values.Add("boxDiference", boxDiference)
        values.Add("servicePercent", servicePercent)
        values.Add("amountOrdered", amountOrdered)
        values.Add("amountDelivered", amountDeliviered)
        values.Add("amountLost", amountLost)
        values.Add("missingItems", missingItems)
        values.Add("pendingItems", pendingItems)

    End Sub

    Private Sub missing_Items(ByRef list As Hashtable, ByVal endDate As Date, ByVal brand As String)
        file.make_query(" SELECT [Whse Qty Ordered (eaches)], [Whse Qty Received (eaches)], [WHPK Qty], [VNPK Qty], [Signing Desc], [PO Number]" &
                        " FROM " & file.activeTable &
                        " WHERE ([Whse Qty Ordered (eaches)] > [Whse Qty Received (eaches)])" &
                        " AND ([PO Cancel Date] < '" & endDate.ToString("MM/dd/yyyy") & "')" &
                        " AND ([Brand Desc] = '" & brand & "')"
                        )

        Dim ordered As Integer
        Dim recieved As Integer
        For row As Integer = 0 To file.table.Rows.Count - 1
            ordered = get_cell(row, 0) / get_cell(row, 2)
            recieved = get_cell(row, 1) / get_cell(row, 3)
            list.Add(get_cell(row, 5) & " " & get_cell(row, 4), (ordered) - (recieved))
        Next
    End Sub

    Private Sub pending_Items(ByRef pending As Integer, ByVal endDate As Date, ByVal brand As String)
        file.make_query(" SELECT [Whse Qty Ordered (eaches)], [Whse Qty Received (eaches)], [WHPK Qty], [VNPK Qty], [Signing Desc]" &
                        " FROM " & file.activeTable &
                        " WHERE ([Whse Qty Ordered (eaches)] > [Whse Qty Received (eaches)])" &
                        " AND ([PO Cancel Date] >= '" & endDate.ToString("MM/dd/yyyy") & "')" &
                        " AND ([Brand Desc] = '" & brand & "')"
                        )

        Dim ordered As Integer = 0
        Dim recieved As Integer = 0
        For row As Integer = 0 To file.table.Rows.Count - 1
            ordered += get_cell(row, 0) / get_cell(row, 2)
            recieved += get_cell(row, 1) / get_cell(row, 3)
        Next
        pending = ordered - recieved
    End Sub


End Class
