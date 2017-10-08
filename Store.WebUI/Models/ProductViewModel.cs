using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.WebUI.Models
{
    public class ProductViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public int CategoryId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        public string ImageSrc { get; set; }
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        [Range(0.01, 1.79769e+308, ErrorMessage = "Please enter a positive price")]
        [Required]
        public decimal Price { get; set; }

        public int Count { get; set; }

        public List<SelectListItem> Categories { get; set; }

    }
}