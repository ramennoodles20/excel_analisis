Imports Excel = Microsoft.Office.Interop.Excel
Public Class pantallaPrincipal

    Private file As New file()

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

    Private Sub AgregarArchivoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarArchivoToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            file.path = OpenFileDialog1.FileName
            file.open_File()
            Dim Analisis As fill_rate = New fill_rate(file)
            Analisis.analyze()
        End If
    End Sub
End Class
