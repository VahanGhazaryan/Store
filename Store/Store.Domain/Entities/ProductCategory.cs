using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public ICollection<ProductSubCategory> ProductSubCategories { get; set; }
        public ProductCategory()
        {
            ProductSubCategories = new List<ProductSubCategory>();
        }
    }
}
