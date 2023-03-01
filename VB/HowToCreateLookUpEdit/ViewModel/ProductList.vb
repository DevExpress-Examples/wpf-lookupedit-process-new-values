Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows.Data
Imports System.Windows.Input
Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Mvvm
Imports DevExpress.Xpf.Mvvm.UI

Namespace HowToCreateLookUpEdit.ViewModel

    Public Class ProductListViewModel
        Inherits ViewModelBase

        Private productsField As ObservableCollection(Of Product) = New ObservableCollection(Of Product)()

        Public ReadOnly Property Products As ObservableCollection(Of Product)
            Get
                Return productsField
            End Get
        End Property

        Public Sub New()
            MyBase.New()
            productsField.Add(New Product() With {.ProductName = "Chang", .Country = "UK", .City = "Cowes", .UnitPrice = 19, .Quantity = 10, .ID = 1000})
            productsField.Add(New Product() With {.ProductName = "Gravad lax", .Country = "Italy", .City = "Reggio Emilia", .UnitPrice = 12, .Quantity = 16, .ID = 1001})
            productsField.Add(New Product() With {.ProductName = "Ravioli Angelo", .Country = "Brazil", .City = "Rio de Janeiro", .UnitPrice = 19, .Quantity = 12, .ID = 1002})
            productsField.Add(New Product() With {.ProductName = "Tarte au sucre", .Country = "Germany", .City = "QUICK-Stop", .UnitPrice = 22, .Quantity = 50, .ID = 1003})
            productsField.Add(New Product() With {.ProductName = "Steeleye Stout", .Country = "USA", .City = "Reggio Emilia", .UnitPrice = 18, .Quantity = 20, .ID = 1004})
            productsField.Add(New Product() With {.ProductName = "Pavlova", .Country = "Austria", .City = "Graz", .UnitPrice = 21, .Quantity = 52, .ID = 1005})
            productsField.Add(New Product() With {.ProductName = "Longlife Tofu", .Country = "USA", .City = "Boise", .UnitPrice = 7, .Quantity = 120, .ID = 1006})
            productsField.Add(New Product() With {.ProductName = "Alice Mutton", .Country = "Mexico", .City = "México D.F.", .UnitPrice = 21, .Quantity = 15, .ID = 1007})
            productsField.Add(New Product() With {.ProductName = "Alice Mutton", .Country = "Canada", .City = "Tsawwassen", .UnitPrice = 44, .Quantity = 16, .ID = 1008})
        End Sub

        Public _ShowProductFormCommand As ICommand

        Public ReadOnly Property ShowProductFormCommand As ICommand
            Get
                If _ShowProductFormCommand Is Nothing Then _ShowProductFormCommand = New DelegateCommand(Of String)(AddressOf OnShowProductFormCommandExecute)
                Return _ShowProductFormCommand
            End Get
        End Property

        Private ReadOnly Property DialogService As IDialogService
            Get
                Return GetService(Of IDialogService)()
            End Get
        End Property

        Private Sub OnShowProductFormCommandExecute(ByVal parameter As String)
            If Equals(parameter, String.Empty) Then Return
            Dim p As Product = New Product() With {.ProductName = parameter}
            Dim addProductCommand As UICommand = New UICommand() With {.Caption = "Add", .IsCancel = False, .IsDefault = True}
            Dim cancelProductCommand As UICommand = New UICommand() With {.Caption = "Cancel", .IsDefault = False, .IsCancel = True}
            Dim result As UICommand = DialogService.ShowDialog(dialogCommands:=New List(Of UICommand)() From {addProductCommand, cancelProductCommand}, title:="Add new row", viewModel:=p)
            If result Is addProductCommand Then
                productsField.Add(p)
            End If
        End Sub
    End Class

    Public Class ProductListValueConverter
        Implements IEventArgsConverter

'#Region "IEventArgsConverter Members"
        Public Function Convert(ByVal args As Object) As Object Implements IEventArgsConverter.Convert
            Dim productName As String = CType(args, ProcessNewValueEventArgs).DisplayText
            Return productName
        End Function
'#End Region
    End Class

    Public Class StringToIntConverter
        Implements IValueConverter

'#Region "IValueConverter Members"
        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.Convert
            Return CInt(value)
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Return value.ToString()
        End Function
'#End Region
    End Class
End Namespace
