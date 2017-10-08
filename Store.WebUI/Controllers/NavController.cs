using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.DAL.Abstract;

namespace Store.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductCategoryRepository productCategoryRepository;

        public NavController(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }
        public PartialViewResult Menu(string category)
        {
            ViewBag.SelectedCategory = category;
            Dictionary<int, string> categories = productCategoryRepository.GetProductCategoris().ToDictionary(x => x.Id, x => x.Name);
            return PartialView(categories);
        }
    }
}