using Store.Domain.Abstract;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Concrete
{
    public class EFProductCategoryRepository : IProductCategoryRepository
        {
            private readonly ApplicationDbContext context = new ApplicationDbContext();
            public IEnumerable<ProductCategory> ProductCategories
            {
                get { return context.ProductCategories; }
            }
            public void SaveCategory(ProductCategory category)
            {
                context.ProductCategories.Add(category);
                context.SaveChanges();
            }
    }
}
