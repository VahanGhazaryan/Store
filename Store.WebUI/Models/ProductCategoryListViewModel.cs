using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WebUI.Models
{
    public class ProductCategoryListViewModel
    {
        public IEnumerable<Product> products { get; set; }

        public IEnumerable<ProductCategory> productCategories { get; set; }
    }
}