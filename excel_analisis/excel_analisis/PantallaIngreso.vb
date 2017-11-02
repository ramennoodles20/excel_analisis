Public Class PantallaIngreso
    Private manager As New XMLmanager

    Private Sub onLoad(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadCompanies()
    End Sub

    Private Sub addCompany_Click(sender As Object, e As EventArgs) Handles addCompany.Click
        Dim name As String
        name = InputBox("Escriba el nombre de la nueva Empresa")
        If FolderBrowser.ShowDialog = DialogResult.OK Then
            Dim companyDirectory = FolderBrowser.SelectedPath
            manager.addCompany(name, companyDirectory)
            loadCompanies()
        End If
    End Sub

    Private Sub deleteCompany_Click(sender As Object, e As EventArgs) Handles deleteCompany.Click
        Dim selectedItem = companyContainer.SelectedItem.ToString
        manager.deleteCompany(selectedItem)
        loadCompanies()
    End Sub

    Private Sub loadCompanies()
        companyContainer.Items.Clear()
        For Each prop In manager.getCompanies
            Me.companyContainer.Items.Add(prop)
        Next
    End Sub

    Private Sub companyContainer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles companyContainer.DoubleClick
        Dim selectedItem = companyContainer.SelectedItem.ToString
        Dim directory = manager.getCompanyDirectory(selectedItem)
        global_Paths.current_acount = selectedItem
        global_Paths.main_directory = directory
        Me.Hide()
        Dim pantalleprincipal As New pantallaPrincipal
        pantalleprincipal.Show()
    End Sub
End Class