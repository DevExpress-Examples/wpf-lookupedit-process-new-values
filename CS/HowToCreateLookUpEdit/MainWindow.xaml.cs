using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core;

namespace HowToCreateLookUpEdit {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        ProductList products;
        public MainWindow() {
            InitializeComponent();
            products = new ProductList();
            lookUpEdit1.ItemsSource = products;
        }

        Control control;
        private void lookUpEdit1_ProcessNewValue(DependencyObject sender, DevExpress.Xpf.Editors.ProcessNewValueEventArgs e) {
            control = new ContentControl() { Template = (ControlTemplate)Resources["addNewRecordTemplate"] };
            control.Tag = e;
            Product row = new Product();
            row.ProductName = e.DisplayText;
            control.DataContext = row;
            FrameworkElement owner = sender as FrameworkElement;
            DialogClosedDelegate closeHandler = new DialogClosedDelegate(CloseAddNewRecordHandler);
            FloatingContainer.ShowDialogContent(control, owner, Size.Empty, new FloatingContainerParameters() {
                Title = "Add New Record",
                AllowSizing = false,
                ClosedDelegate = closeHandler,
                ContainerFocusable = false,
                ShowModal = true
            });
            e.PostponedValidation = true;
            e.Handled = true;
        }
        void CloseAddNewRecordHandler(bool? close) {
            if (close != null && (bool)close)
                products.Add(control.DataContext as Product);
            control = null;
        }
    }
}
