using Store.Domain.Abstract;
using Store.Domain.Entities;
using Store.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductCategoryRepository repositorycategory;

        public AdminController(IProductCategoryRepository repocategory)
        {
            repositorycategory = repocategory;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductCategoryIndex()
        {
            ProductCategoryViewModel model = new ProductCategoryViewModel();
            model.Categories = repositorycategory.ProductCategories;
            return View(model);
        }
        public ActionResult CreateProductCategory()
        {
            CreateProductCategoryViewModel model = new CreateProductCategoryViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProductCategory(CreateProductCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProductCategory p = new ProductCategory();
                p.Name = model.Name;
                p.Description = model.Description;
                if (model.ImageUpload != null)
                {
                    string fileName = System.IO.Path.GetFileName(model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(Server.MapPath("~/Images/" + fileName));
                    p.ImagePath = Server.MapPath("~/Images/" + fileName);
                }
                else
                {
                    ModelState.AddModelError("", "Image have not choosen");
                }

                if (ModelState.IsValid)
                {
                   // repositorycategory.SaveCategory(p);
                    return RedirectToAction("ProductCategoryIndex");
                }
            }

            return View();
            
        }


        public ActionResult CreateOption()
        {
            ProductPropertyViewModel model = new ProductPropertyViewModel();
          return PartialView("CreateOption", model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOption(List<string> values)
        {
            //db.Computers.Add(comp);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryMenu()
        {
            return PartialView("CategoryMenu");
        }

	}
}