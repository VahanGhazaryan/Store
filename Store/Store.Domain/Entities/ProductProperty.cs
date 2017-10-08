using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class ProductProperty
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int? ProductSubCategoryId { get; set; }
        public ProductCategory ProductSubCategory { get; set; }
        public ICollection<ProductPropertyValue> ProductPropertyValues { get; set; }
        public ProductProperty()
        {
            ProductPropertyValues = new List<ProductPropertyValue>();
        }
    }
}
