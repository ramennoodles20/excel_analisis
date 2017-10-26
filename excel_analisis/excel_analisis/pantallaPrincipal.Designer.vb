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
        Me.fill_rate = New System.Windows.Forms.TabPage()
        Me.fill_Rate_Panel = New System.Windows.Forms.Panel()
        Me.calendarFilter = New System.Windows.Forms.MonthCalendar()
        Me.stock_Rotation_Data_Tab = New System.Windows.Forms.TabPage()
        Me.stock_Rotation_Status_Tab = New System.Windows.Forms.TabPage()
        Me.lista_plantillas = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaPlantillaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalizarArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FillRateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockRotationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Tab_Principal.SuspendLayout()
        Me.fill_rate.SuspendLayout()
        Me.fill_Rate_Panel.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab_Principal
        '
        Me.Tab_Principal.AccessibleName = ""
        Me.Tab_Principal.Controls.Add(Me.fill_rate)
        Me.Tab_Principal.Controls.Add(Me.stock_Rotation_Data_Tab)
        Me.Tab_Principal.Controls.Add(Me.stock_Rotation_Status_Tab)
        Me.Tab_Principal.Location = New System.Drawing.Point(216, 12)
        Me.Tab_Principal.Name = "Tab_Principal"
        Me.Tab_Principal.SelectedIndex = 0
        Me.Tab_Principal.Size = New System.Drawing.Size(905, 573)
        Me.Tab_Principal.TabIndex = 0
        '
        'fill_rate
        '
        Me.fill_rate.AutoScroll = True
        Me.fill_rate.Controls.Add(Me.fill_Rate_Panel)
        Me.fill_rate.Location = New System.Drawing.Point(4, 22)
        Me.fill_rate.Name = "fill_rate"
        Me.fill_rate.Padding = New System.Windows.Forms.Padding(3)
        Me.fill_rate.Size = New System.Drawing.Size(897, 547)
        Me.fill_rate.TabIndex = 0
        Me.fill_rate.Text = "Fill Rate"
        Me.fill_rate.UseVisualStyleBackColor = True
        '
        'fill_Rate_Panel
        '
        Me.fill_Rate_Panel.Controls.Add(Me.calendarFilter)
        Me.fill_Rate_Panel.Dock = System.Windows.Forms.DockStyle.Top
        Me.fill_Rate_Panel.Location = New System.Drawing.Point(3, 3)
        Me.fill_Rate_Panel.Name = "fill_Rate_Panel"
        Me.fill_Rate_Panel.Size = New System.Drawing.Size(891, 238)
        Me.fill_Rate_Panel.TabIndex = 3
        '
        'calendarFilter
        '
        Me.calendarFilter.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.calendarFilter.Location = New System.Drawing.Point(321, 9)
        Me.calendarFilter.MaxSelectionCount = 400
        Me.calendarFilter.Name = "calendarFilter"
        Me.calendarFilter.TabIndex = 0
        '
        'stock_Rotation_Data_Tab
        '
        Me.stock_Rotation_Data_Tab.Location = New System.Drawing.Point(4, 22)
        Me.stock_Rotation_Data_Tab.Name = "stock_Rotation_Data_Tab"
        Me.stock_Rotation_Data_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.stock_Rotation_Data_Tab.Size = New System.Drawing.Size(897, 547)
        Me.stock_Rotation_Data_Tab.TabIndex = 1
        Me.stock_Rotation_Data_Tab.Text = "Stock Rotation-Data"
        Me.stock_Rotation_Data_Tab.UseVisualStyleBackColor = True
        '
        'stock_Rotation_Status_Tab
        '
        Me.stock_Rotation_Status_Tab.AutoScroll = True
        Me.stock_Rotation_Status_Tab.Location = New System.Drawing.Point(4, 22)
        Me.stock_Rotation_Status_Tab.Name = "stock_Rotation_Status_Tab"
        Me.stock_Rotation_Status_Tab.Padding = New System.Windows.Forms.Padding(3)
        Me.stock_Rotation_Status_Tab.Size = New System.Drawing.Size(897, 547)
        Me.stock_Rotation_Status_Tab.TabIndex = 2
        Me.stock_Rotation_Status_Tab.Text = "Stock Rotation-Staus"
        Me.stock_Rotation_Status_Tab.UseVisualStyleBackColor = True
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
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaPlantillaToolStripMenuItem, Me.AnalizarArchivoToolStripMenuItem})
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
        'AnalizarArchivoToolStripMenuItem
        '
        Me.AnalizarArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FillRateToolStripMenuItem, Me.StockRotationToolStripMenuItem})
        Me.AnalizarArchivoToolStripMenuItem.Name = "AnalizarArchivoToolStripMenuItem"
        Me.AnalizarArchivoToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.AnalizarArchivoToolStripMenuItem.Text = "Analizar Archivo"
        '
        'FillRateToolStripMenuItem
        '
        Me.FillRateToolStripMenuItem.Name = "FillRateToolStripMenuItem"
        Me.FillRateToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.FillRateToolStripMenuItem.Text = "Fill Rate "
        '
        'StockRotationToolStripMenuItem
        '
        Me.StockRotationToolStripMenuItem.Name = "StockRotationToolStripMenuItem"
        Me.StockRotationToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.StockRotationToolStripMenuItem.Text = "Stock Rotation"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'pantallaPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1133, 597)
        Me.Controls.Add(Me.Tab_Principal)
        Me.Controls.Add(Me.lista_plantillas)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "pantallaPrincipal"
        Me.Text = "Form1"
        Me.Tab_Principal.ResumeLayout(False)
        Me.fill_rate.ResumeLayout(False)
        Me.fill_Rate_Panel.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fill_rate As TabPage
    Friend WithEvents stock_Rotation_Data_Tab As TabPage
    Friend WithEvents lista_plantillas As ListBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NuevaPlantillaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnalizarArchivoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Tab_Principal As TabControl
    Friend WithEvents FillRateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StockRotationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents fill_Rate_Panel As Panel
    Friend WithEvents calendarFilter As MonthCalendar
    Friend WithEvents stock_Rotation_Status_Tab As TabPage
End Class
