using DevExpress.Mvvm.DataAnnotations;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HowToCreateLookUpEdit {
    public class Product {
        [Display(GroupName = "General")]
        [ReadOnly(true)]
        public int ID { get; set; }
        [Display(GroupName = "General")]
        public string ProductName { get; set; }
        [Display(GroupName = "Address")]
        public string Country { get; set; }
        [Display(GroupName = "Address")]
        public string City { get; set; }
        [Display(GroupName = "Order Detail")]
        [NumericMask(Mask = "c", UseAsDisplayFormat = true)]
        public double UnitPrice { get; set; }
        [Display(GroupName = "Order Detail")]
        public int Quantity { get; set; }
    }
    public class ProductData {
        public static ObservableCollection<Product> GetProducts() {
            var products = new ObservableCollection<Product> {
                new Product() { ProductName = "Chang", Country = "UK", City = "Cowes", UnitPrice = 19, Quantity = 10, ID = 1000 },
                new Product() { ProductName = "Gravad lax", Country = "Italy", City = "Reggio Emilia", UnitPrice = 12, Quantity = 16, ID = 1001 },
                new Product() { ProductName = "Ravioli Angelo", Country = "Brazil", City = "Rio de Janeiro", UnitPrice = 19, Quantity = 12, ID = 1002 },
                new Product() { ProductName = "Tarte au sucre", Country = "Germany", City = "QUICK-Stop", UnitPrice = 22, Quantity = 50, ID = 1003 },
                new Product() { ProductName = "Steeleye Stout", Country = "USA", City = "Reggio Emilia", UnitPrice = 18, Quantity = 20, ID = 1004 },
                new Product() { ProductName = "Pavlova", Country = "Austria", City = "Graz", UnitPrice = 21, Quantity = 52, ID = 1005 },
                new Product() { ProductName = "Longlife Tofu", Country = "USA", City = "Boise", UnitPrice = 7, Quantity = 120, ID = 1006 },
                new Product() { ProductName = "Alice Mutton", Country = "Mexico", City = "México D.F.", UnitPrice = 21, Quantity = 15, ID = 1007 },
                new Product() { ProductName = "Alice Mutton", Country = "Canada", City = "Tsawwassen", UnitPrice = 44, Quantity = 16, ID = 1008 }
            };
            return products;
        }
    }
}
