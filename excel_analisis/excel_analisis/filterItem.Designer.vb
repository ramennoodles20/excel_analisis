<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class filterItem
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.filter = New System.Windows.Forms.Label()
        Me.delete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'filter
        '
        Me.filter.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.filter.AutoSize = True
        Me.filter.Location = New System.Drawing.Point(3, 5)
        Me.filter.Name = "filter"
        Me.filter.Size = New System.Drawing.Size(39, 13)
        Me.filter.TabIndex = 0
        Me.filter.Text = "Label1"
        '
        'delete
        '
        Me.delete.Dock = System.Windows.Forms.DockStyle.Right
        Me.delete.Location = New System.Drawing.Point(114, 0)
        Me.delete.Name = "delete"
        Me.delete.Size = New System.Drawing.Size(23, 23)
        Me.delete.TabIndex = 1
        Me.delete.Text = "x"
        Me.delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.delete.UseVisualStyleBackColor = True
        '
        'filterItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.delete)
        Me.Controls.Add(Me.filter)
        Me.Name = "filterItem"
        Me.Size = New System.Drawing.Size(137, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents filter As Label
    Friend WithEvents delete As Button
End Class
