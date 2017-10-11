Imports Excel = Microsoft.Office.Interop.Excel

Class fill_rate
    Inherits Analisis

    Sub New(ByVal pFile As file)
        MyBase.New(pFile)
    End Sub



    Overrides Function find_first_row()
        Dim row As Integer = 1
        Dim text As String
        text = get_cell(row, 1)
        While text <> "Country Code"
            text = get_cell(row, 1)
            row += 1
        End While
        Return row
    End Function

    Overloads Overrides Sub analyze()
        Dim boxOrdered As Integer = sum_division(7, 9)
        Dim boxDelivered As Integer = sum_division(8, 10)
        Dim boxDiference As Integer = boxOrdered - boxDelivered
        Dim servicePercent As Double = (boxDelivered / boxOrdered) * 100
        Dim amountOrdered As Double = sum_multiplication(7, 15)
        Dim amountDeliviered As Double = sum_multiplication(8, 15)
        Dim amountLost As Double = amountOrdered - amountDeliviered
        Dim missingItems As Hashtable = New Hashtable()
        missing_Items(missingItems)

        values.Add("boxesOrdered", boxOrdered)
        values.Add("boxesDelivered", boxDelivered)
        values.Add("boxDiference", boxDiference)
        values.Add("servicePercent", servicePercent)
        values.Add("amountOrdered", amountOrdered)
        values.Add("amountDelivered", amountDeliviered)
        values.Add("amountLost", amountLost)
        values.Add("missingItems", missingItems)

        'Debug.Print("Cajas pedidas " & boxOrdered)
        'Debug.Print("Cajas Entregadas " & boxDelivered)
        'Debug.Print("Diferencia cajas " & boxDiference)
        'Debug.Print("Porcentaje Servicio " & servicePercent)
        'Debug.Print("$ pedidos " & amountOrdered)
        'Debug.Print("$ entregados " & amountDeliviered)
        'Debug.Print("$ perdidos " & amountLost)
    End Sub

    Overloads Overrides Sub analyze(ByVal filter As String)
        Dim boxOrdered As Integer = sum_division(7, 9, filter)
        Dim boxDelivered As Integer = sum_division(8, 10, filter)
        Dim boxDiference As Integer = boxOrdered - boxDelivered
        Dim servicePercent As Double = (boxDelivered / boxOrdered) * 100
        Dim amountOrdered As Double = sum_multiplication(7, 15, filter)
        Dim amountDeliviered As Double = sum_multiplication(8, 15, filter)
        Dim amountLost As Double = amountOrdered - amountDeliviered
        Dim missingItems As Hashtable = New Hashtable()
        missing_Items(missingItems, filter)

        values.Add("boxesOrdered", boxOrdered)
        values.Add("boxesDelivered", boxDelivered)
        values.Add("boxDiference", boxDiference)
        values.Add("servicePercent", servicePercent)
        values.Add("amountOrdered", amountOrdered)
        values.Add("amountDelivered", amountDeliviered)
        values.Add("amountLost", amountLost)
        values.Add("missingItems", missingItems)

        'Debug.Print("Cajas pedidas " & boxOrdered)
        'Debug.Print("Cajas Entregadas " & boxDelivered)
        'Debug.Print("Diferencia cajas " & boxDiference)
        'Debug.Print("Porcentaje Servicio " & servicePercent)
        'Debug.Print("$ pedidos " & amountOrdered)
        'Debug.Print("$ entregados " & amountDeliviered)
        'Debug.Print("$ perdidos " & amountLost)
    End Sub

    Private Sub missing_Items(ByRef list As Hashtable)
        Dim row As Integer = first_row
        While row <= max_rows
            Dim order As Integer = get_cell(row, 7)
            Dim delivery As Integer = get_cell(row, 8)
            If (order <> delivery) Then
                Dim ordered As Integer = order / get_cell(row, 9)
                Dim delivered As Integer = delivery / get_cell(row, 10)
                list.Add(get_cell(row, 2) & get_cell(row, 6), ordered - delivered)

                'Debug.Print("   Faltan " & ordered - delivered & " de " & get_cell(row, 6))
            End If
            row += 1
        End While
    End Sub

    Private Sub missing_Items(ByRef list As Hashtable, ByVal filter As String)
        Dim row As Integer = first_row
        While row <= max_rows
            If (get_cell(row, 6).ToString.Contains(filter)) Then
                Dim order As Integer = get_cell(row, 7)
                Dim delivery As Integer = get_cell(row, 8)
                If (order <> delivery) Then
                    Dim ordered As Integer = order / get_cell(row, 9)
                    Dim delivered As Integer = delivery / get_cell(row, 10)
                    list.Add(get_cell(row, 2) & get_cell(row, 6), ordered - delivered)

                    'Debug.Print("   Faltan " & ordered - delivered & " de " & get_cell(row, 6))
                End If
            End If
            row += 1
        End While
    End Sub
End Class
