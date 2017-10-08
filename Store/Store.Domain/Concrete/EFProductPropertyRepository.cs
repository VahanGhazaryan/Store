using Store.Domain.Abstract;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Concrete
{
    public class EFProductPropertyRepository : IProductPropertyRepository
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<ProductProperty> ProductProperties
        {
            get { return context.ProductProproties; }
        }
        public void SaveProperty(ProductProperty prop)
        {
            context.ProductProproties.Add(prop);
            context.SaveChanges();
        }
    }
}
