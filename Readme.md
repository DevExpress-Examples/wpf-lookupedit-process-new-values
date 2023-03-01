<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128645186/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2646)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF LookUpEdit - Process New Values

This example allows users to add new items to the [LookUpEdit](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.LookUp.LookUpEdit) and posts these items to the data source.

![image](https://user-images.githubusercontent.com/65009440/222120568-b6090226-1647-435f-8f2a-ad053530a131.png)

## Implementation Details

1. Use the [LookUpEditBase.AddNewButtonPlacement](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.LookUpEditBase.AddNewButtonPlacement) property to display the **Add New** button.
2. When a user clicks this button or enters a value that does not exist in the data source, the `LookUpEdit` raises the [ProcessNewValue](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.LookUpEditBase.ProcessNewValue) event.
3. Create an [EventToCommand](https://docs.devexpress.com/WPF/DevExpress.Mvvm.UI.EventToCommand) behavior and execute the `ShowProductForm` command when the `ProcessNewValue` event is raised.
4. In the `ShowProductForm` command, use the [DialogService](https://docs.devexpress.com/WPF/17467/mvvm-framework/services/predefined-set/dialog-services/dialogservice) to invoke a new item dialog. This dialog contains the [DataLayoutControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.LayoutControl.DataLayoutControl) that allows users to specify the item's properties.
5. Add the specified item to the data source if the user clicks the **Add** button.

   ![image](https://user-images.githubusercontent.com/65009440/222123270-90b5c62c-aefa-46fa-b1c1-004f3d822747.png)

## Files to Review

* [MainWindow.xaml](./CS/HowToCreateLookUpEdit/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/HowToCreateLookUpEdit/MainWindow.xaml))
* [ViewModel.cs](./CS/HowToCreateLookUpEdit/ViewModel.cs) (VB: [ViewModel.vb](./VB/HowToCreateLookUpEdit/ViewModel.vb))
* [Products.cs](./CS/HowToCreateLookUpEdit/Products.cs) (VB: [Products.vb](./VB/HowToCreateLookUpEdit/Products.vb))

## Documentation

* [LookUpEdit](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.LookUp.LookUpEdit)
* [LookUpEditBase.ProcessNewValue](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.LookUpEditBase.ProcessNewValue)
* [LookUpEditBase.AddNewButtonPlacement](https://docs.devexpress.com/WPF/DevExpress.Xpf.Editors.LookUpEditBase.AddNewButtonPlacement)
* [DialogService](https://docs.devexpress.com/WPF/17467/mvvm-framework/services/predefined-set/dialog-services/dialogservice)
* [DataLayoutControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.LayoutControl.DataLayoutControl)
* [EventToCommand](https://docs.devexpress.com/WPF/DevExpress.Mvvm.UI.EventToCommand)

## More Examples

* [WPF LookUpEdit - Customize the Embedded Data Grid](https://github.com/DevExpress-Examples/wpf-lookupedit-customize-the-embedded-data-grid)
* [WPF LookUpEdit - Filter by Multiple Columns](https://github.com/DevExpress-Examples/wpf-lookupedit-filter-by-multiple-columns)
* [Use DialogService to Show a Modal Dialog Window](https://github.com/DevExpress-Examples/wpf-mvvm-framework-ui-services-dialogservice)
