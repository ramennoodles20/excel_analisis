Imports System
Imports System.IO
Imports System.Xml

Public Class XMLmanager
    Public doc As XDocument = XDocument.Load("companies.xml")


    Public Function getCompanies()
        Dim root = doc.Root
        Dim companies(root.Elements.Count - 1) As String
        Dim i As Integer = 0
        For Each company In root.Elements
            companies(i) = company.Elements("name").Value
            i += 1
        Next
        Return companies
    End Function

    Public Sub addCompany(ByVal companyName, companyDirectory)
        Dim newCompany As XElement = New XElement("company")
        Dim newCompanyName As XElement = New XElement("name", companyName)
        Dim newCompanyDirectory As XElement = New XElement("directory", companyDirectory)

        newCompany.Add(newCompanyName)
        newCompany.Add(newCompanyDirectory)

        doc.Root.Add(newCompany)
        doc.Save("companies.xml")
    End Sub

    Public Sub deleteCompany(ByVal deletedCompany As String)
        Dim root = doc.Root
        For Each element In doc.Root.Elements
            Dim companyName = element.Elements("name").Value
            If companyName.Equals(deletedCompany) Then
                element.Remove()
            End If
        Next
        doc.Save("companies.xml")
    End Sub

    Public Sub editCompany(ByVal companyName As String, ByVal newDirectory As String)
        For Each element In doc.Root.Elements
            Dim company = element.Elements("name").Value
            If company.Equals(companyName) Then
                element.Elements("directory").Value = newDirectory
            End If
        Next
        doc.Save("companies.xml")
    End Sub

    Public Function getCompanyDirectory(ByVal targetCompany)
        For Each element In doc.Root.Elements
            Dim companyName = element.Elements("name").Value
            If companyName.Equals(targetCompany) Then
                Return element.Elements("directory").Value
            End If
        Next
        Return Nothing
    End Function
End Class
