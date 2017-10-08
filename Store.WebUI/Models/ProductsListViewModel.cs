using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DAL.Entities;

namespace Store.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IList<ProductViewModel> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}