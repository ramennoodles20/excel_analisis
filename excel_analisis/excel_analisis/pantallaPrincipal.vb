Imports Excel = Microsoft.Office.Interop.Excel
Public Class pantallaPrincipal

    Private reader As New file_reader()

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
            showFile(reader)
        End If
    End Sub

    Private Sub showFile(ByVal file_reader)
        Dim cell As Object
        viewPort.RowCount = file_reader.range.Rows.Count
        viewPort.ColumnCount = file_reader.range.Columns.Count
        Debug.Print(viewPort.ColumnCount)
        Debug.Print(viewPort.RowCount)
        For row = 1 To file_reader.range.Rows.Count
            For column = 1 To file_reader.range.Columns.Count
                cell = CType(file_reader.range.Cells(row, column), Excel.Range)
                viewPort.Rows(row - 1).Cells(column - 1).Value = cell.value
            Next
        Next
    End Sub

    Private Sub agregarPaso_Click(sender As Object, e As EventArgs) Handles agregarPaso.Click
        Dim new_panel As New FlowLayoutPanel
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
                first_column.Anchor = AnchorStyles.Top And AnchorStyles.Left
                operand.Anchor = AnchorStyles.Top And AnchorStyles.Left
                operand.Width = 40
                second_column.Anchor = AnchorStyles.Top And AnchorStyles.Left

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
                column.Anchor = AnchorStyles.Top And AnchorStyles.Left
                operand.Anchor = AnchorStyles.Top And AnchorStyles.Left

                'add controls to panel 
                new_panel.Controls.Add(column)
                new_panel.Controls.Add(operand)
        End Select

        'neutral elements
        Dim delete_button As New Button 'delete button 
        Dim type As New Label '[invisible] type of operation to add

        'neutral elements styling 
        delete_button.Anchor = AnchorStyles.Top And AnchorStyles.Left
        delete_button.Text = "eliminar"
        type.Text = tipo
        type.Visible = False

        'add neutral elements to panel 
        new_panel.Controls.Add(delete_button)
        new_panel.Controls.Add(type) 'ALWAYS LAST!!

        'new panel styling 
        new_panel.Dock = DockStyle.Top

        'add new panel to tab 
        Procedimiento.Controls.Add(new_panel)
    End Sub

    Private Sub Visualizar_Click(sender As Object, e As EventArgs) Handles Visualizar.Click
        For Each panel As Panel In getPanels()
            Dim operation As Integer = CType(panel.Controls(panel.Controls.Count - 1), Label).Text
            Select Case operation
                Case 0
                    realizar_Op_Dos_Columnas(panel.Controls)
                Case 1
                    realizar_Op_Una_Columna(panel.Controls)
            End Select
        Next
    End Sub

    Private Function getPanels()
        Dim controls As New ArrayList
        For Each control As Control In Procedimiento.Controls
            If TypeOf control Is Panel Then
                controls.Add(CType(control, Panel))
            End If
        Next
        Return controls
    End Function


End Class
