using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecomsite.ViewModel
{
    public class ShoppingCartModel
    {
        public string Laptop_id { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public string Imagepath { get; set; }
        public string Laptop_name { get; set; }
    }
}