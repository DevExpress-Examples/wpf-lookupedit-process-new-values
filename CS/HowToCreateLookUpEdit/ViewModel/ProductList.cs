using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Mvvm;
using DevExpress.Xpf.Mvvm.UI;

namespace HowToCreateLookUpEdit.ViewModel
{
    public class ProductListViewModel : ViewModelBase 
    {
        ObservableCollection<Product> products = new ObservableCollection<Product>();
        public ObservableCollection<Product> Products { get { return products; } }
        public ProductListViewModel()
            : base()
        {
            products.Add(new Product() { ProductName = "Chang", Country = "UK", City = "Cowes", UnitPrice = 19, Quantity = 10, ID = 1000 });
            products.Add(new Product() { ProductName = "Gravad lax", Country = "Italy", City = "Reggio Emilia", UnitPrice = 12, Quantity = 16, ID = 1001 });
            products.Add(new Product() { ProductName = "Ravioli Angelo", Country = "Brazil", City = "Rio de Janeiro", UnitPrice = 19, Quantity = 12, ID = 1002 });
            products.Add(new Product() { ProductName = "Tarte au sucre", Country = "Germany", City = "QUICK-Stop", UnitPrice = 22, Quantity = 50, ID = 1003 });
            products.Add(new Product() { ProductName = "Steeleye Stout", Country = "USA", City = "Reggio Emilia", UnitPrice = 18, Quantity = 20, ID = 1004 });
            products.Add(new Product() { ProductName = "Pavlova", Country = "Austria", City = "Graz", UnitPrice = 21, Quantity = 52, ID = 1005 });
            products.Add(new Product() { ProductName = "Longlife Tofu", Country = "USA", City = "Boise", UnitPrice = 7, Quantity = 120, ID = 1006 });
            products.Add(new Product() { ProductName = "Alice Mutton", Country = "Mexico", City = "México D.F.", UnitPrice = 21, Quantity = 15, ID = 1007 });
            products.Add(new Product() { ProductName = "Alice Mutton", Country = "Canada", City = "Tsawwassen", UnitPrice = 44, Quantity = 16, ID = 1008 });         
        }

        public ICommand _ShowProductFormCommand;

        public ICommand ShowProductFormCommand
        {
            get
            {
                if (_ShowProductFormCommand == null)
                    _ShowProductFormCommand = new DelegateCommand<string>(OnShowProductFormCommandExecute);
                return _ShowProductFormCommand;
            }
        }
        
        IDialogService DialogService { get { return GetService<IDialogService>(); } }

        private void OnShowProductFormCommandExecute(string parameter)
        {
            if (parameter == string.Empty) return;
            Product p = new Product() { ProductName = parameter };
            UICommand addProductCommand = new UICommand()
            {
                Caption = "Add",
                IsCancel = false,
                IsDefault = true
            };

            UICommand cancelProductCommand = new UICommand()
            {
                Caption = "Cancel",
                IsDefault = false,
                IsCancel = true
            };

            UICommand result = DialogService.ShowDialog(
                 dialogCommands: new List<UICommand>() { addProductCommand, cancelProductCommand},
                 title: "Add new row",
                 viewModel: p);

            if (result == addProductCommand) {
                products.Add(p);
            }
        }
    }

    public class ProductListValueConverter : IEventArgsConverter
    {   
        #region IEventArgsConverter Members

        public object Convert(object args)
        {
            string productName = ((ProcessNewValueEventArgs)args).DisplayText;
            return productName;
        }

        #endregion
    }


    public class StringToIntConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        #endregion
    }
}
