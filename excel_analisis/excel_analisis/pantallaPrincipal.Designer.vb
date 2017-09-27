<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class pantallaPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Tab_Principal = New System.Windows.Forms.TabControl()
        Me.reporte_final = New System.Windows.Forms.TabPage()
        Me.visualizacion = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.lista_plantillas = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaPlantillaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Procedimiento = New System.Windows.Forms.TabPage()
        Me.agregarPaso = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.operacion = New System.Windows.Forms.ComboBox()
        Me.Tab_Principal.SuspendLayout()
        Me.visualizacion.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.Procedimiento.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab_Principal
        '
        Me.Tab_Principal.AccessibleName = ""
        Me.Tab_Principal.Controls.Add(Me.reporte_final)
        Me.Tab_Principal.Controls.Add(Me.visualizacion)
        Me.Tab_Principal.Controls.Add(Me.Procedimiento)
        Me.Tab_Principal.Location = New System.Drawing.Point(216, 12)
        Me.Tab_Principal.Name = "Tab_Principal"
        Me.Tab_Principal.SelectedIndex = 0
        Me.Tab_Principal.Size = New System.Drawing.Size(905, 573)
        Me.Tab_Principal.TabIndex = 0
        '
        'reporte_final
        '
        Me.reporte_final.Location = New System.Drawing.Point(4, 22)
        Me.reporte_final.Name = "reporte_final"
        Me.reporte_final.Padding = New System.Windows.Forms.Padding(3)
        Me.reporte_final.Size = New System.Drawing.Size(897, 547)
        Me.reporte_final.TabIndex = 0
        Me.reporte_final.Text = "Reporte Final"
        Me.reporte_final.UseVisualStyleBackColor = True
        '
        'visualizacion
        '
        Me.visualizacion.Controls.Add(Me.DataGridView1)
        Me.visualizacion.Location = New System.Drawing.Point(4, 22)
        Me.visualizacion.Name = "visualizacion"
        Me.visualizacion.Padding = New System.Windows.Forms.Padding(3)
        Me.visualizacion.Size = New System.Drawing.Size(897, 547)
        Me.visualizacion.TabIndex = 1
        Me.visualizacion.Text = "Visualización"
        Me.visualizacion.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(891, 402)
        Me.DataGridView1.TabIndex = 1
        '
        'lista_plantillas
        '
        Me.lista_plantillas.FormattingEnabled = True
        Me.lista_plantillas.Location = New System.Drawing.Point(12, 31)
        Me.lista_plantillas.Name = "lista_plantillas"
        Me.lista_plantillas.Size = New System.Drawing.Size(176, 550)
        Me.lista_plantillas.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1133, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "menu"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaPlantillaToolStripMenuItem, Me.AgregarArchivoToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'NuevaPlantillaToolStripMenuItem
        '
        Me.NuevaPlantillaToolStripMenuItem.Name = "NuevaPlantillaToolStripMenuItem"
        Me.NuevaPlantillaToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.NuevaPlantillaToolStripMenuItem.Text = "Nueva Plantilla"
        '
        'AgregarArchivoToolStripMenuItem
        '
        Me.AgregarArchivoToolStripMenuItem.Name = "AgregarArchivoToolStripMenuItem"
        Me.AgregarArchivoToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.AgregarArchivoToolStripMenuItem.Text = "Agregar Archivo"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Procedimiento
        '
        Me.Procedimiento.Controls.Add(Me.operacion)
        Me.Procedimiento.Controls.Add(Me.Button2)
        Me.Procedimiento.Controls.Add(Me.agregarPaso)
        Me.Procedimiento.Location = New System.Drawing.Point(4, 22)
        Me.Procedimiento.Name = "Procedimiento"
        Me.Procedimiento.Padding = New System.Windows.Forms.Padding(3)
        Me.Procedimiento.Size = New System.Drawing.Size(897, 547)
        Me.Procedimiento.TabIndex = 2
        Me.Procedimiento.Text = "Procedimiento"
        Me.Procedimiento.UseVisualStyleBackColor = True
        '
        'agregarPaso
        '
        Me.agregarPaso.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.agregarPaso.Location = New System.Drawing.Point(134, 85)
        Me.agregarPaso.Name = "agregarPaso"
        Me.agregarPaso.Size = New System.Drawing.Size(75, 23)
        Me.agregarPaso.TabIndex = 0
        Me.agregarPaso.Text = "Paso"
        Me.agregarPaso.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(816, 518)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'operacion
        '
        Me.operacion.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.operacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.operacion.FormattingEnabled = True
        Me.operacion.Items.AddRange(New Object() {"Operación dos columnas", "Sumatoria "})
        Me.operacion.Location = New System.Drawing.Point(7, 85)
        Me.operacion.Name = "operacion"
        Me.operacion.Size = New System.Drawing.Size(121, 21)
        Me.operacion.TabIndex = 2
        '
        'pantallaPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1133, 597)
        Me.Controls.Add(Me.lista_plantillas)
        Me.Controls.Add(Me.Tab_Principal)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "pantallaPrincipal"
        Me.Text = "Form1"
        Me.Tab_Principal.ResumeLayout(False)
        Me.visualizacion.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Procedimiento.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents reporte_final As TabPage
    Friend WithEvents visualizacion As TabPage
    Friend WithEvents lista_plantillas As ListBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaPlantillaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AgregarArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Tab_Principal As TabControl
    Friend WithEvents Procedimiento As TabPage
    Friend WithEvents Button2 As Button
    Friend WithEvents agregarPaso As Button
    Friend WithEvents operacion As ComboBox
End Class
