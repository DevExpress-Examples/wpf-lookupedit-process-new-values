Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports DevExpress.Mvvm

Namespace HowToCreateLookUpEdit.ViewModel
    Public Class Product
        Public Property ID() As Integer
        Public Property ProductName() As String
        Public Property Country() As String
        Public Property City() As String
        Public Property UnitPrice() As Integer
        Public Property Quantity() As Integer
    End Class
End Namespace