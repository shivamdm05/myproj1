using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecomsite.Models;
using Ecomsite.ViewModel;
namespace Ecomsite.Controllers
{
    public class ItemController : Controller
    {
        private laptopsEntities objlaptopsEntities;
        public ItemController()
        {
            objlaptopsEntities = new laptopsEntities();
        }
        // GET: Item
        public ActionResult Index()
        {
            ItemViewModel objItemViewModel = new ItemViewModel();
            objItemViewModel.CategorySelectListItem =(from objCat in objlaptopsEntities.categories

                                                       select new SelectListItem()
                                                       {
                                                           Text = objCat.category_name,
                                                           Value = objCat.category_id.ToString(),
                                                           Selected = true
                                                       });
            return View(objItemViewModel);
        }
        [HttpPost]
       public JsonResult Index(ItemViewModel objItemViewModel)
        {
            string NewImage = Guid.NewGuid() + Path.GetExtension(objItemViewModel.Imagepath.FileName);
            objItemViewModel.Imagepath.SaveAs(filename: Server.MapPath("~/Images/" + NewImage));
            laptop_model objItem = new laptop_model();
            objItem.imagepath = "~/Images/" + NewImage;
            objItem.category_id = objItemViewModel.Category_id;
            objItem.description = objItemViewModel.Description;
           
            objItem.laptop_id = Guid.NewGuid();
            objItem.laptop_name = objItemViewModel.Laptop_name;
            objItem.laptop_price = objItemViewModel.Laptop_price;
            objlaptopsEntities.laptop_model.Add(objItem);
            objlaptopsEntities.SaveChanges();
            return Json(data: new { Success = true, Message = "Item Added Successfully " }, JsonRequestBehavior.AllowGet);
        }
    }
}