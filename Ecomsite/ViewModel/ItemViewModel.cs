using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecomsite.ViewModel
{
    public class ItemViewModel
    {
        public int Laptop_id { get; set; }
        public int Category_id { get; set; }

        public string Laptop_name { get; set; }

        public string Description { get; set; }
        public decimal Laptop_price { get; set; }

        public HttpPostedFileBase Imagepath { get; set; }

        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }
    }
}