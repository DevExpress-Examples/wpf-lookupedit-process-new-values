Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Core

Namespace HowToCreateLookUpEdit
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Private products As ProductList
		Public Sub New()
			InitializeComponent()
			products = New ProductList()
			lookUpEdit1.ItemsSource = products
		End Sub

		Private control As Control
		Private Sub lookUpEdit1_ProcessNewValue(ByVal sender As DependencyObject, ByVal e As DevExpress.Xpf.Editors.ProcessNewValueEventArgs)
			control = New ContentControl() With {.Template = CType(Resources("addNewRecordTemplate"), ControlTemplate)}
			control.Tag = e
			Dim row As New Product()
			row.ProductName = e.DisplayText
			control.DataContext = row
			Dim owner As FrameworkElement = TryCast(sender, FrameworkElement)
			Dim closeHandler As New DialogClosedDelegate(AddressOf CloseAddNewRecordHandler)
			FloatingContainer.ShowDialogContent(control, owner, Size.Empty, New FloatingContainerParameters() With {.Title = "Add New Record", .AllowSizing = False, .ClosedDelegate = closeHandler, .ContainerFocusable = False, .ShowModal = True})
			e.PostponedValidation = True
			e.Handled = True
		End Sub
		Private Sub CloseAddNewRecordHandler(ByVal close? As Boolean)
			If close.HasValue AndAlso CBool(close) Then
				products.Add(TryCast(control.DataContext, Product))
			End If
			control = Nothing
		End Sub
	End Class
End Namespace
