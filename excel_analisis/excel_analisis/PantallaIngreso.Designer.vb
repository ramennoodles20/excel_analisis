<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PantallaIngreso
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.addCompany = New System.Windows.Forms.Button()
        Me.deleteCompany = New System.Windows.Forms.Button()
        Me.FolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.companyContainer = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(399, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccione la Empresa por Analizar"
        '
        'addCompany
        '
        Me.addCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addCompany.Location = New System.Drawing.Point(18, 281)
        Me.addCompany.Name = "addCompany"
        Me.addCompany.Size = New System.Drawing.Size(85, 23)
        Me.addCompany.TabIndex = 2
        Me.addCompany.Text = "Agregar"
        Me.addCompany.UseVisualStyleBackColor = True
        '
        'deleteCompany
        '
        Me.deleteCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deleteCompany.Location = New System.Drawing.Point(109, 281)
        Me.deleteCompany.Name = "deleteCompany"
        Me.deleteCompany.Size = New System.Drawing.Size(85, 23)
        Me.deleteCompany.TabIndex = 5
        Me.deleteCompany.Text = "Eliminar"
        Me.deleteCompany.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Image = Global.excel_analisis.My.Resources.Resources.extraMile
        Me.Label3.Location = New System.Drawing.Point(280, 127)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(277, 80)
        Me.Label3.TabIndex = 4
        '
        'companyContainer
        '
        Me.companyContainer.FormattingEnabled = True
        Me.companyContainer.Location = New System.Drawing.Point(18, 47)
        Me.companyContainer.Name = "companyContainer"
        Me.companyContainer.Size = New System.Drawing.Size(176, 225)
        Me.companyContainer.TabIndex = 6
        '
        'PantallaIngreso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 346)
        Me.Controls.Add(Me.companyContainer)
        Me.Controls.Add(Me.deleteCompany)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.addCompany)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PantallaIngreso"
        Me.Text = "Selección de Empresa"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents addCompany As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents deleteCompany As Button
    Friend WithEvents FolderBrowser As FolderBrowserDialog
    Friend WithEvents companyContainer As ListBox
End Class
