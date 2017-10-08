using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Abstract
{
    public interface IProductPropertyRepository
    {
        IEnumerable<ProductProperty> ProductProperties { get; }
        void SaveProperty(ProductProperty prop);
    }
}
