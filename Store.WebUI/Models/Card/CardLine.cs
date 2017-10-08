using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WebUI.Models.Card
{
    public class CardLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}