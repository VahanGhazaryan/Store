using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.UI.Models
{
    public class ProductCategoryViewModel
    {
        public IEnumerable<ProductCategory> Categories { get; set; }
    }

    public class ProductPropertyViewModel
    {
        public List<string> Properties { get; set; }
    }

    public class CreateProductCategoryViewModel
                 
    {
        [Required]
        [Display(Name = "Name of category")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        
        [DataType(DataType.Upload)]
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}