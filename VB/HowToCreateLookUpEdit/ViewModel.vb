Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.UI
Imports DevExpress.Xpf.Editors
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace HowToCreateLookUpEdit

    Public Class ProductListViewModel
        Inherits ViewModelBase

        Public Property Products As ObservableCollection(Of Product)

        Public Sub New()
            Products = ProductData.GetProducts()
        End Sub

        Private ReadOnly Property DialogService As IDialogService
            Get
                Return GetService(Of IDialogService)()
            End Get
        End Property

        <Command>
        Public Sub ShowProductForm(ByVal parameter As String)
            Dim product As Product = New Product() With {.ProductName = parameter, .ID = Products.Max(Function(p) p.ID) + 1}
            Dim addProductCommand As UICommand = New UICommand() With {.Caption = "Add", .IsCancel = False, .IsDefault = True}
            Dim cancelProductCommand As UICommand = New UICommand() With {.Caption = "Cancel", .IsDefault = False, .IsCancel = True}
            Dim result As UICommand = DialogService.ShowDialog(dialogCommands:=New List(Of UICommand)() From {addProductCommand, cancelProductCommand}, title:="New Item", viewModel:=product)
            If result Is addProductCommand Then
                Products.Add(product)
            End If
        End Sub
    End Class

    Public Class ProductListValueConverter
        Implements IEventArgsConverter

        Public Function Convert(ByVal sender As Object, ByVal args As Object) As Object Implements IEventArgsConverter.Convert
            Dim productName As String = CType(args, ProcessNewValueEventArgs).DisplayText
            Return productName
        End Function
    End Class
End Namespace
