using ASPNETIdentity_GoogleAuthenticator.Abstract;
using ASPNETIdentity_GoogleAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETIdentity_GoogleAuthenticator.Controllers
{
     [Audit]
    public class NavController : Controller
    {
        // GET: Nav
        private IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}