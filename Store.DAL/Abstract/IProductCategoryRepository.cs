using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Abstract
{
    public interface IProductCategoryRepository
    {
        IEnumerable<ProductCategory> GetProductCategoris();

        ProductCategory GetById(int id);

        void SaveProductCategory(ProductCategory product, bool isSaveChanges = true);

        ProductCategory DeleteProductCategory(int productId, bool isSaveChanges = true);

        void SaveChanges();

    }
}
