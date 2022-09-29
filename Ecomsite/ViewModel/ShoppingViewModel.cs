using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecomsite.ViewModel
{
    public class ShoppingViewModel
    {
        public int Laptop_id { get; set; }
        public string Laptop_name { get; set; }
        public decimal Laptop_price { get; set; }
        public string Imagepath { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        /*   public string Item_Code
           {
               get; set;
           }*/
    }
}