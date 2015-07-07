using ASPNETIdentity_GoogleAuthenticator.Abstract;
using ASPNETIdentity_GoogleAuthenticator.Entities;
using ASPNETIdentity_GoogleAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETIdentity_GoogleAuthenticator.Controllers
{
    [Audit]
    public class CartController : Controller
    {
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IProductRepository repo,IOrderProcessor proc)
        {
            repository = repo;
        orderProcessor = proc;
        }
        [Audit]
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
         [Audit]
        public RedirectToRouteResult AddToCart(Cart cart, int productId,
        string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
         [Audit]
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId,
        string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
         [Audit]
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
        [Audit]
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
    }
}

