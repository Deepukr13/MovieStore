using ASPNETIdentity_GoogleAuthenticator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNETIdentity_GoogleAuthenticator.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

    }
}