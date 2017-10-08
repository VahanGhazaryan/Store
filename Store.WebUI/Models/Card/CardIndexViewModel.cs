using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WebUI.Models.Card
{
    public class CardIndexViewModel
    {
        public CardModel Card { get; set; }
        public string ReturnUrl { get; set; }
    }
}