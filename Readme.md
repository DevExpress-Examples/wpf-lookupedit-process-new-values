<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128645186/10.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2646)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/HowToCreateLookUpEdit/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/HowToCreateLookUpEdit/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/HowToCreateLookUpEdit/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/HowToCreateLookUpEdit/MainWindow.xaml.vb))
<!-- default file list end -->
# LookUpEdit - Processing New Values


<p>This example shows how to manually initialize a new value and add it to a data source.</p><p><strong>Update:</strong><strong><br />
</strong></p><p>Starting with version 13.1 of DevExpress controls, you can use the DevExpress MVVM Framework to accomplish this task. It is necessary to create a command in the view model (for instance, the ShowProductFormCommand command) and bind it with the <a href="http://documentation.devexpress.com/#WPF/DevExpressXpfEditorsLookUpEditBase_ProcessNewValuetopic"><u>LookUpEditBase.ProcessNewValue</u></a> event via the trigger. This would allow you to display the dialog (UserControl1.xaml file) for editing new source items in the LookUpEdit control when this even is raised. Then, you can implement custom logic in the OnShowProductFormCommandExecute (ProductList.cs file) method to process values in this dialog.</p><br />
<p>Please review our blogs to find additional information about DevExpress MVVM Framework:</p><p><a href="https://community.devexpress.com/blogs/wpf/archive/2013/08/29/getting-started-with-devexpress-mvvm-framework-commands-and-view-models.aspx"><u>Getting Started with DevExpress MVVM Framework. Commands and View Models.</u></a><u><br />
</u><a href="https://community.devexpress.com/blogs/wpf/archive/2013/09/30/devexpress-mvvm-framework-introduction-to-services-dxmessageboxservice-and-dialogservice.aspx"><u>DevExpress MVVM Framework. Introduction to Services, DXMessageBoxService and DialogService.</u></a><u><br />
</u><a href="https://community.devexpress.com/blogs/wpf/archive/2013/10/09/devexpress-mvvm-framework-interaction-of-viewmodels-idocumentmanagerservice.aspx"><u>DevExpress MVVM Framework. Interaction of ViewModels. IDocumentManagerService.</u></a></p>


<h3>Description</h3>

<p>This sample does no work correctly in version 11.2.11 due to the <a data-ticket="Q402474">Q402474: Handling the ProcessNewValue event raises an exception when the second record is added</a> bug. This problem is now fixed with the 11.2.12 and 12.1.3 releases.</p>

<br/>


