using ASPNETIdentity_GoogleAuthenticator.Abstract;
using ASPNETIdentity_GoogleAuthenticator.Entities;
using ASPNETIdentity_GoogleAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security.AntiXss;

namespace ASPNETIdentity_GoogleAuthenticator.Controllers
{
    [Audit]
    [Authorize]
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 5;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
    [Audit]
        public ViewResult List(string category, int page = 1,String SearchTerm=null)
        {
            var str = AntiXssEncoder.HtmlEncode(SearchTerm,true);
            ViewBag.search = SearchTerm;
            ProductsListViewModel viewModel = new ProductsListViewModel
            {
                
                Products = repository.Products
                .Where(p=>SearchTerm==null ||p.Name.StartsWith(str))
               .Where(p => category == null || p.Category == category)
               .OrderBy(p => p.ProductID)
               .Skip((page - 1) * PageSize)
               .Take(PageSize)
                ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("_MovieResult", model);
            //}
            return View(viewModel);
        }

       
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}
