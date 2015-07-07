using ASPNETIdentity_GoogleAuthenticator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETIdentity_GoogleAuthenticator.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}