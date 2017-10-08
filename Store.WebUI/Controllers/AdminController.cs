using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.DAL.Abstract;
using Store.DAL.Entities;
using Store.WebUI.Models;
using System.IO;
using Store.Common;

namespace Store.WebUI.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        private IProductRepository productRepository;
        private IProductCategoryRepository productCategoryRepository;

        public AdminController(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
            : base()
        {
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
        }
        public ActionResult Index()
        {
            var viewModel = new ProductCategoryListViewModel()
            {
                products = productRepository.GetProducts(),
                productCategories = productCategoryRepository.GetProductCategoris(),
            };
            return View(viewModel);
        }
        #region product
        public ViewResult CreateProduct()
        {
            var model = new ProductViewModel
            {
                Categories = productCategoryRepository.GetProductCategoris().Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateProduct([Bind(Include = "ProductId, Name, Description, ImageSrc, Price, CategoryId")]ProductViewModel model, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var product = mapper.Map<ProductViewModel, Product>(model);
                var savedFileName = Path.Combine(Server.MapPath(Constants.ImagePath), upload.FileName);
                upload.SaveAs(savedFileName);
                product.ImageSrc = Constants.ImagePath + upload.FileName;
                productRepository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(model);
            }
        }
        public ViewResult EditProduct(int productId)
        {
            var product = productRepository.GetById(productId);
            var model = mapper.Map<Product, ProductViewModel>(product);
            model.Categories = productCategoryRepository.GetProductCategoris().Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct([Bind(Include = "ProductId, Name, Description, ImageSrc, Price, CategoryId")]ProductViewModel model, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var product = mapper.Map<ProductViewModel, Product>(model);
                string fullPath = Request.MapPath(product.ImageSrc);
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                var savedFileName = Path.Combine(Server.MapPath(Constants.ImagePath), upload.FileName);
                upload.SaveAs(savedFileName);
                product.ImageSrc = Constants.ImagePath + upload.FileName;
                productRepository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            var deletedProduct = productRepository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Category
        public ViewResult CreateCategory()
        {
            return View(new ProductCategoryViewModel());
        }
        [HttpPost]
        public ActionResult CreateCategory(ProductCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = mapper.Map<ProductCategoryViewModel, ProductCategory>(model);
                productCategoryRepository.SaveProductCategory(category);
                TempData["message"] = string.Format("{0} has been saved", category.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(model);
            }
        }

        public ViewResult EditCategory(int id)
        {
            var category = productCategoryRepository.GetById(id);
            var model = mapper.Map<ProductCategory, ProductCategoryViewModel>(category);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCategory(ProductCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = mapper.Map<ProductCategoryViewModel, ProductCategory>(model);
                productCategoryRepository.SaveProductCategory(category);
                TempData["message"] = string.Format("{0} has been saved", category.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            var deletedCategory = productCategoryRepository.DeleteProductCategory(id);
            if (deletedCategory != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedCategory.Name);
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}