using Ecomsite.ViewModel;
using Ecomsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecomsite.Controllers
{
    public class LaptopStoreController : Controller
    {
        private laptopsEntities objlaptopsEntities;
        private List<ShoppingCartModel> listOfShoppingCartModel;
        public LaptopStoreController()
        {
            objlaptopsEntities = new laptopsEntities();
            listOfShoppingCartModel = new List<ShoppingCartModel>();
        }
        // GET: LaptopStore
        public ActionResult Index()
        {
            IEnumerable<ShoppingViewModel> listofLaptopStoreView = (from OBJitem in objlaptopsEntities.laptop_model
                                                                  join
                                                                  objcat in objlaptopsEntities.categories
                                                                  on OBJitem.category_id equals objcat.category_id
                                                                  select new ShoppingViewModel()
                                                                  {
                                                                      Imagepath = OBJitem.imagepath,
                                                                      Laptop_name = OBJitem.laptop_name,
                                                                      Description = OBJitem.description,
                                                                      Laptop_price = OBJitem.laptop_price,
                                                                      Laptop_id = OBJitem.laptop_id,
                                                                      Category = objcat.category_name,
                                                                    //  Item_code = OBJitem.Item_code,
                                                                  }).ToList();
            return View(listofLaptopStoreView);
        }


        [HttpPost]
        public JsonResult Index(string Item_id)
        {
            ShoppingCartModel objShoppingCartModel = new ShoppingCartModel();
            
            laptop_model objItem = objlaptopsEntities.laptop_model.Single(model => model.laptop_id.ToString() == Item_id);

              
            if (Session["CartCounter"] != null)
            {
                listOfShoppingCartModel = Session["CartItem"] as List<ShoppingCartModel>;
            }
            if (listOfShoppingCartModel.Any(model => model.Laptop_id == Item_id))
            {
                objShoppingCartModel = listOfShoppingCartModel.Single(model => model.Laptop_id == Item_id);
                objShoppingCartModel.Quantity = objShoppingCartModel.Quantity + 1;
                objShoppingCartModel.Total = objShoppingCartModel.Quantity * objShoppingCartModel.UnitPrice;
            }
            else
            {
                objShoppingCartModel.Laptop_id = Item_id;
                objShoppingCartModel.Imagepath = objItem.imagepath;
                objShoppingCartModel.Laptop_name = objItem.laptop_name;
                objShoppingCartModel.Quantity = 1;
                objShoppingCartModel.Total = objItem.laptop_price;
                objShoppingCartModel.UnitPrice = objItem.laptop_price;
                listOfShoppingCartModel.Add(objShoppingCartModel);
            }
            Session["CartCounter"] = listOfShoppingCartModel.Count;
            Session["CartItem"] = listOfShoppingCartModel;
            return Json(data: new { Sucess = true, Counter = listOfShoppingCartModel.Count },
           JsonRequestBehavior.AllowGet);
        }
        public ActionResult ShoppingCart()
        {
            listOfShoppingCartModel = Session["CartItem"] as List<ShoppingCartModel>;
            return View(listOfShoppingCartModel);
        }
    }
}












