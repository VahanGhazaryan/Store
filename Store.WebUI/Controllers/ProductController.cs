using Store.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.WebUI.Models;
using Store.Common;
using Store.DAL.Entities;

namespace Store.WebUI.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository productRepository;
        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductController(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository) : base()
        {
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
        }
        public ViewResult List(int? categoryId, int page = 1)
        {
            var model = new ProductsListViewModel();
            var dbProducts = productRepository.GetProducts().ToList();
            model.Products = mapper.Map<IList<Product>, IList<ProductViewModel>>(dbProducts);
            model.Products = model.Products.Where(p => categoryId == null || p.CategoryId == categoryId.Value)
                                                    .OrderBy(p => p.ProductId)
                                                    .Skip((page - 1) * Constants.PageSize)
                                                    .Take(Constants.PageSize).ToList();
            model.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = Constants.PageSize,
                TotalItems = categoryId.HasValue ? dbProducts.Where(p => p.CategoryId == categoryId).Count() : dbProducts.Count()

            };
            model.CurrentCategory = categoryId.HasValue ? productCategoryRepository.GetById(categoryId.Value).Name : string.Empty;
            return View(model);
        }
    }
}