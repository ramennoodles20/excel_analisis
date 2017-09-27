Public Class pantallaPrincipal

    Private reader As file_reader = New file_reader()

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
            reader.path = OpenFileDialog1.FileName
            reader.open_File()
        End If
    End Sub

    Private Sub agregarPaso_Click(sender As Object, e As EventArgs) Handles agregarPaso.Click
        Dim new_panel As New Panel
        Dim padAll As New Padding(3, 3, 3, 3)
        Dim tipo As String
        tipo = operacion.SelectedIndex
        Select Case tipo
            Case 0 'two columns
                'controls 
                Dim first_column As New TextBox
                Dim operand As New ComboBox
                operand.Items.Add("*")
                operand.Items.Add("+")
                operand.Items.Add("-")
                operand.Items.Add("/")
                Dim second_column As New TextBox


                'control styling 
                first_column.Anchor = AnchorStyles.Left
                operand.Anchor = AnchorStyles.Left
                operand.Width = 40
                second_column.Anchor = AnchorStyles.Left


                'add controls to panel 
                new_panel.Controls.Add(first_column)
                new_panel.Controls.Add(operand)
                new_panel.Controls.Add(second_column)


            Case 1 'one column 
                'controls
                Dim column As New TextBox
                Dim operand As New ComboBox
                operand.Items.Add("*")
                operand.Items.Add("+")
                operand.Items.Add("-")
                operand.Items.Add("/")
                operand.Width = 40

                'control styling 
                column.Anchor = AnchorStyles.Left
                operand.Anchor = AnchorStyles.Left

                'add controls to panel 
                new_panel.Controls.Add(column)
                new_panel.Controls.Add(operand)
        End Select

        Dim delete_button As New Button

        delete_button.Anchor = AnchorStyles.Left
        delete_button.Text = "eliminar"

        new_panel.Controls.Add(delete_button)


        'new panel styling 
        new_panel.Dock = DockStyle.Top

        'add new panel to tab 
        Procedimiento.Controls.Add(new_panel)
    End Sub
End Class
