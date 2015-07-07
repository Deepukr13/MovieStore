using ASPNETIdentity_GoogleAuthenticator.Abstract;
using ASPNETIdentity_GoogleAuthenticator.Concrete;
using ASPNETIdentity_GoogleAuthenticator.Entities;
using ASPNETIdentity_GoogleAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETIdentity_GoogleAuthenticator.Controllers
{
   [Authorize(Users = "Dhyaandeepu@gmail.com")]
    public class AdminController : Controller
    {
        // GET: Admin
        private IProductRepository repository;
        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted",
                deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }

        [Audit]
        public ActionResult AuditedAction()
        {
            return Content("Audit Fired!");
        }

        public ActionResult ViewAuditRecords()
        {
            var audits = new AuditingContext().AuditRecords;
            return View(audits);
        }
    
    }
}