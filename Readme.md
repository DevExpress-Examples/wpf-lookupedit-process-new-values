<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/HowToCreateLookUpEdit/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/HowToCreateLookUpEdit/MainWindow.xaml))
* [UserControl1.xaml](./CS/HowToCreateLookUpEdit/UserControl1.xaml) (VB: [UserControl1.xaml](./VB/HowToCreateLookUpEdit/UserControl1.xaml))
* **[ProductList.cs](./CS/HowToCreateLookUpEdit/ViewModel/ProductList.cs) (VB: [ProductList.vb](./VB/HowToCreateLookUpEdit/ViewModel/ProductList.vb))**
* [Products.cs](./CS/HowToCreateLookUpEdit/ViewModel/Products.cs)
<!-- default file list end -->
# LookUpEdit - Processing New Values


<p>This example shows how to manually initialize a new value and add it to a data source.</p><p><strong>Update:</strong><strong><br />
</strong></p><p>Starting with version 13.1 of DevExpress controls, you can use the DevExpress MVVM Framework to accomplish this task. It is necessary to create a command in the view model (for instance, the ShowProductFormCommand command) and bind it with the <a href="http://documentation.devexpress.com/#WPF/DevExpressXpfEditorsLookUpEditBase_ProcessNewValuetopic"><u>LookUpEditBase.ProcessNewValue</u></a> event via the trigger. This would allow you to display the dialog (UserControl1.xaml file) for editing new source items in the LookUpEdit control when this even is raised. Then, you can implement custom logic in the OnShowProductFormCommandExecute (ProductList.cs file) method to process values in this dialog.</p><br />
<p>Please review our blogs to find additional information about DevExpress MVVM Framework:</p><p><a href="https://community.devexpress.com/blogs/wpf/archive/2013/08/29/getting-started-with-devexpress-mvvm-framework-commands-and-view-models.aspx"><u>Getting Started with DevExpress MVVM Framework. Commands and View Models.</u></a><u><br />
</u><a href="https://community.devexpress.com/blogs/wpf/archive/2013/09/30/devexpress-mvvm-framework-introduction-to-services-dxmessageboxservice-and-dialogservice.aspx"><u>DevExpress MVVM Framework. Introduction to Services, DXMessageBoxService and DialogService.</u></a><u><br />
</u><a href="https://community.devexpress.com/blogs/wpf/archive/2013/10/09/devexpress-mvvm-framework-interaction-of-viewmodels-idocumentmanagerservice.aspx"><u>DevExpress MVVM Framework. Interaction of ViewModels. IDocumentManagerService.</u></a></p>

<br/>


