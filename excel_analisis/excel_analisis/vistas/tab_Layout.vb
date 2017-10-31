Imports System.Globalization
MustInherit Class tab_Layout

    Protected numberFormat = System.Globalization.CultureInfo.CreateSpecificCulture("en-US")
    Protected numberStyle As NumberStyles = NumberStyles.Any

    Public analisis As Analisis
    Protected tabPage As Panel
    Protected dataGrid As DataGridView = New DataGridView

    Protected titleFont As DataGridViewCellStyle = New DataGridViewCellStyle
    Protected subtitleFont As DataGridViewCellStyle = New DataGridViewCellStyle
    Protected totalFormat As DataGridViewCellStyle = New DataGridViewCellStyle
    Protected groupFormat As DataGridViewCellStyle = New DataGridViewCellStyle

    Public Sub New()
        init_fonts()
    End Sub

    Private Sub init_fonts()
        titleFont.BackColor = Color.Cyan
        titleFont.Font = New Font("Arial", 8, FontStyle.Bold)

        subtitleFont.Font = New Font("Calibri", 9, FontStyle.Bold)


        totalFormat.ForeColor = Color.White
        totalFormat.BackColor = Color.Gray

        groupFormat.BackColor = Color.Linen
    End Sub

    MustOverride Sub show_file()
End Class
