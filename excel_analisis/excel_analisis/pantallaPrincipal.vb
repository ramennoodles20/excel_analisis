Imports System
Imports System.IO
Imports System.Text
Public Class pantallaPrincipal
    Private fill_rate_tab_controler As tab_Layout
    Private stock_rotationData_tab_controler As tab_Layout
    Private stock_rotationStatus_tab_controler As tab_Layout


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
        fill_rate_tab_controler = New fill_Rate_View(fill_rate)
        stock_rotationData_tab_controler = New stock_RotationData_View(stock_Rotation_Data_Tab)
        stock_rotationStatus_tab_controler = New stock_RotationStatus_View(stock_Rotation_Status_Tab)
    End Sub

    Private Sub FillRateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FillRateToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim file = New file(OpenFileDialog1.FileName)
            fill_rate_tab_controler.analisis = New fill_rate(file)
            fill_rate_tab_controler.show_file()
        End If
    End Sub

    Private Sub StockRotationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockRotationToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim file As file = New file(OpenFileDialog1.FileName)
            Dim infoFile As stock_rotation = New stock_rotation(file)
            '[GET PATH]
            infoFile.analyze("PATH")
            stock_rotationData_tab_controler.analisis = infoFile
            stock_rotationStatus_tab_controler.analisis = infoFile
            stock_rotationData_tab_controler.show_file()
            stock_rotationStatus_tab_controler.show_file()
        End If
    End Sub
End Class
