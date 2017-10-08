using Store.DAL.Abstract;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Concrete
{
    public class ProductCategoryRepository : BaseRepository, IProductCategoryRepository
    {
        public ProductCategoryRepository() : base()
        {

        }

        public IEnumerable<ProductCategory> GetProductCategoris()
        {
            return GetAll<ProductCategory>();
        }

        public ProductCategory GetById(int id)
        {
            return GetAll<ProductCategory>().FirstOrDefault(x => x.Id == id);
        }

        public void SaveProductCategory(ProductCategory product, bool isSaveChanges = true)
        {
            var dbProduct = Find<ProductCategory>(product.Id);
            if (dbProduct == null)
                Add<ProductCategory>(product);
            else
                SetValues(product, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }

        public ProductCategory DeleteProductCategory(int id, bool isSaveChanges = true)
        {
            var dbEntry = Find<ProductCategory>(id);
            if (dbEntry != null)
            {
                Remove(dbEntry);
                if (isSaveChanges)
                    SaveChanges();
            }
            return dbEntry;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
