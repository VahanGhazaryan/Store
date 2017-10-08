using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.DAL.Entities;
using Store.WebUI.Models.Card;

namespace Store.WebUI.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            CardModel cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (CardModel)controllerContext.HttpContext.Session[sessionKey];
            }
            if (cart == null)
            {
                cart = new CardModel();
                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            return cart;
        }
    }
}