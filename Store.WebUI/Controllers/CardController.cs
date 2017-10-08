using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.DAL.Abstract;
using Store.DAL.Entities;
using Store.WebUI.Models.Card;
using Store.WebUI.Models;

namespace Store.WebUI.Controllers
{
    public class CardController : BaseController
    {
        private IProductRepository productRepository;

        public CardController(IProductRepository repo) :base()
        {
            this.productRepository = repo;
        }

        public ViewResult Index(CardModel card, string returnUrl)
        {
            return View( new CardIndexViewModel { Card = card, ReturnUrl = returnUrl });
        }

        public PartialViewResult Summary(CardModel cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetailsViewModel());
        }

        [HttpPost]
        public ViewResult Checkout(CardModel card, ShippingDetailsViewModel shippingDetails)
        {
            if (card.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your card is empty!");
            }
            if (ModelState.IsValid)
            {
                card.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public RedirectToRouteResult AddToCard(CardModel card, int productId, int count, string returnUrl)
        {
            Product product = productRepository.GetProducts().FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                card.AddItem(product, count);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCard(CardModel card, int productId, string returnUrl)
        {
            Product product = productRepository.GetProducts().FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                card.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}