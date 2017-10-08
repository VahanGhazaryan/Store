using Store.DAL.Abstract;
using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DAL.Concrete
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository() : base()
        {

        }

        public IEnumerable<Product> GetProducts()
        {
            return GetAll<Product>();
        }

        public Product GetById(int id)
        {
            return Find<Product>(id);
        }

        public void SaveProduct(Product product, bool isSaveChanges = true)
        {
            var dbProduct = Find<Product>(product.ProductId);
            if (dbProduct == null)
                Add<Product>(product);
            else
                SetValues(product, dbProduct);
            if (isSaveChanges)
                SaveChanges();
        }


        public Product DeleteProduct(int productId, bool isSaveChanges = true)
        {
            var dbEntry = Find<Product>(productId);
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
