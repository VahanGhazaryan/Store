using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Entities;

namespace Store.DAL.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        Product GetById(int id);

        void SaveProduct(Product product, bool isSaveChanges = true);

        Product DeleteProduct(int productId, bool isSaveChanges = true);

        void SaveChanges();
    }
}
