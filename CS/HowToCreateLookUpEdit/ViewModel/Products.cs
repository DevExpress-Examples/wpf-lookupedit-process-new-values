using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;

namespace HowToCreateLookUpEdit.ViewModel
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}