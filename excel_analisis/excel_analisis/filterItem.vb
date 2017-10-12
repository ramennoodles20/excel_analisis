Public Class filterItem
    Public Sub New(ByRef text As String)
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.filter.Text = text
        Me.Name = text
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles delete.Click
        Me.Parent.Controls.Remove(Me)
    End Sub
End Class
