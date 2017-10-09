Imports Excel = Microsoft.Office.Interop.Excel

Class fill_rate
    Inherits Analisis


    Sub New(ByVal pFile As file)
        MyBase.New(pFile)
    End Sub

    Public values As New Hashtable()


    Overrides Sub analyze()
        values.Add("Cajas Pedidas", sum_division(7, 9))
        values.Add("Cajas Entregadas", sum_division(8, 10))
        values.Add("Diferencia Cajas", values.Item("Cajas Pedidas") - values.Item("Cajas Entregadas"))
        Debug.Print(values.Item("Cajas Pedidas"))
        Debug.Print(values.Item("Cajas Entregadas"))
        Debug.Print(values.Item("Diferencia Cajas"))
    End Sub
End Class
