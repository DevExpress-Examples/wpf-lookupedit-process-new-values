Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Data
Imports System.Windows.Input
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Editors
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.UI

Namespace HowToCreateLookUpEdit.ViewModel
    Public Class ProductListViewModel
        Inherits ViewModelBase


        Private products_Renamed As New ObservableCollection(Of Product)()
        Public ReadOnly Property Products() As ObservableCollection(Of Product)
            Get
                Return products_Renamed
            End Get
        End Property
        Public Sub New()
            MyBase.New()
            products_Renamed.Add(New Product() With {.ProductName = "Chang", .Country = "UK", .City = "Cowes", .UnitPrice = 19, .Quantity = 10, .ID = 1000})
            products_Renamed.Add(New Product() With {.ProductName = "Gravad lax", .Country = "Italy", .City = "Reggio Emilia", .UnitPrice = 12, .Quantity = 16, .ID = 1001})
            products_Renamed.Add(New Product() With {.ProductName = "Ravioli Angelo", .Country = "Brazil", .City = "Rio de Janeiro", .UnitPrice = 19, .Quantity = 12, .ID = 1002})
            products_Renamed.Add(New Product() With {.ProductName = "Tarte au sucre", .Country = "Germany", .City = "QUICK-Stop", .UnitPrice = 22, .Quantity = 50, .ID = 1003})
            products_Renamed.Add(New Product() With {.ProductName = "Steeleye Stout", .Country = "USA", .City = "Reggio Emilia", .UnitPrice = 18, .Quantity = 20, .ID = 1004})
            products_Renamed.Add(New Product() With {.ProductName = "Pavlova", .Country = "Austria", .City = "Graz", .UnitPrice = 21, .Quantity = 52, .ID = 1005})
            products_Renamed.Add(New Product() With {.ProductName = "Longlife Tofu", .Country = "USA", .City = "Boise", .UnitPrice = 7, .Quantity = 120, .ID = 1006})
            products_Renamed.Add(New Product() With {.ProductName = "Alice Mutton", .Country = "Mexico", .City = "México D.F.", .UnitPrice = 21, .Quantity = 15, .ID = 1007})
            products_Renamed.Add(New Product() With {.ProductName = "Alice Mutton", .Country = "Canada", .City = "Tsawwassen", .UnitPrice = 44, .Quantity = 16, .ID = 1008})
        End Sub

        Public _ShowProductFormCommand As ICommand

        Public ReadOnly Property ShowProductFormCommand() As ICommand
            Get
                If _ShowProductFormCommand Is Nothing Then
                    _ShowProductFormCommand = New DelegateCommand(Of String)(AddressOf OnShowProductFormCommandExecute)
                End If
                Return _ShowProductFormCommand
            End Get
        End Property

        Private ReadOnly Property DialogService() As IDialogService
            Get
                Return GetService(Of IDialogService)()
            End Get
        End Property

        Private Sub OnShowProductFormCommandExecute(ByVal parameter As String)
            If parameter = String.Empty Then
                Return
            End If
            Dim p As New Product() With {.ProductName = parameter}
            Dim addProductCommand As New UICommand() With {.Caption = "Add", .IsCancel = False, .IsDefault = True}

            Dim cancelProductCommand As New UICommand() With {.Caption = "Cancel", .IsDefault = False, .IsCancel = True}

            Dim result As UICommand = DialogService.ShowDialog(dialogCommands:= New List(Of UICommand)() From {addProductCommand, cancelProductCommand}, title:= "Add new row", viewModel:= p)

            If result Is addProductCommand Then
                products_Renamed.Add(p)
            End If
        End Sub
    End Class

    Public Class ProductListValueConverter
        Implements IEventArgsConverter

        Public Function Convert(ByVal sender As Object, ByVal args As Object) As Object Implements IEventArgsConverter.Convert
            Dim productName As String = DirectCast(args, ProcessNewValueEventArgs).DisplayText
            Return productName
        End Function
    End Class


    Public Class StringToIntConverter
        Implements IValueConverter

        #Region "IValueConverter Members"

        Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
            Return DirectCast(value, Integer)
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return value.ToString()
        End Function

        #End Region
    End Class
End Namespace