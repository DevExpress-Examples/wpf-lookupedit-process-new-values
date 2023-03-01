using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Editors;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HowToCreateLookUpEdit {
    public class ProductListViewModel : ViewModelBase {
        public ObservableCollection<Product> Products { get; set; }
        public ProductListViewModel() {
            Products = ProductData.GetProducts();
        }

        IDialogService DialogService { get { return GetService<IDialogService>(); } }

        [Command]
        public void ShowProductForm(string parameter) {
            Product product = new Product() { ProductName = parameter, ID = Products.Max(p => p.ID) + 1 };

            UICommand addProductCommand = new UICommand() {
                Caption = "Add",
                IsCancel = false,
                IsDefault = true
            };
            UICommand cancelProductCommand = new UICommand() {
                Caption = "Cancel",
                IsDefault = false,
                IsCancel = true
            };

            UICommand result = DialogService.ShowDialog(
                 dialogCommands: new List<UICommand>() { addProductCommand, cancelProductCommand },
                 title: "New Item",
                 viewModel: product);

            if (result == addProductCommand) {
                Products.Add(product);
            }
        }
    }

    public class ProductListValueConverter : IEventArgsConverter {
        public object Convert(object sender, object args) {
            string productName = ((ProcessNewValueEventArgs)args).DisplayText;
            return productName;
        }
    }
}
