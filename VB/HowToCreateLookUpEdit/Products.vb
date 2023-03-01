Imports DevExpress.Mvvm.DataAnnotations
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Namespace HowToCreateLookUpEdit

    Public Class Product

        <Display(GroupName:="General")>
        <[ReadOnly](True)>
        Public Property ID As Integer

        <Display(GroupName:="General")>
        Public Property ProductName As String

        <Display(GroupName:="Address")>
        Public Property Country As String

        <Display(GroupName:="Address")>
        Public Property City As String

        <Display(GroupName:="Order Detail")>
        <NumericMask(Mask:="c", UseAsDisplayFormat:=True)>
        Public Property UnitPrice As Double

        <Display(GroupName:="Order Detail")>
        Public Property Quantity As Integer
    End Class

    Public Class ProductData

        Public Shared Function GetProducts() As ObservableCollection(Of Product)
            Dim products = New ObservableCollection(Of Product) From {New Product() With {.ProductName = "Chang", .Country = "UK", .City = "Cowes", .UnitPrice = 19, .Quantity = 10, .ID = 1000}, New Product() With {.ProductName = "Gravad lax", .Country = "Italy", .City = "Reggio Emilia", .UnitPrice = 12, .Quantity = 16, .ID = 1001}, New Product() With {.ProductName = "Ravioli Angelo", .Country = "Brazil", .City = "Rio de Janeiro", .UnitPrice = 19, .Quantity = 12, .ID = 1002}, New Product() With {.ProductName = "Tarte au sucre", .Country = "Germany", .City = "QUICK-Stop", .UnitPrice = 22, .Quantity = 50, .ID = 1003}, New Product() With {.ProductName = "Steeleye Stout", .Country = "USA", .City = "Reggio Emilia", .UnitPrice = 18, .Quantity = 20, .ID = 1004}, New Product() With {.ProductName = "Pavlova", .Country = "Austria", .City = "Graz", .UnitPrice = 21, .Quantity = 52, .ID = 1005}, New Product() With {.ProductName = "Longlife Tofu", .Country = "USA", .City = "Boise", .UnitPrice = 7, .Quantity = 120, .ID = 1006}, New Product() With {.ProductName = "Alice Mutton", .Country = "Mexico", .City = "México D.F.", .UnitPrice = 21, .Quantity = 15, .ID = 1007}, New Product() With {.ProductName = "Alice Mutton", .Country = "Canada", .City = "Tsawwassen", .UnitPrice = 44, .Quantity = 16, .ID = 1008}}
            Return products
        End Function
    End Class
End Namespace
