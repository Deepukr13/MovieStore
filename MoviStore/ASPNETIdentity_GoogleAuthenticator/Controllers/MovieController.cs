using ASPNETIdentity_GoogleAuthenticator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPNETIdentity_GoogleAuthenticator.Controllers
{
     [Audit]
    public class MovieController : Controller
    {
        // GET: Movie
        [Audit]
        public ActionResult Index()
        {
            return View();
        }
        [Audit]
        public ActionResult Action()
        {
            return View();
        }
        [Audit]
        public ActionResult Comedy()
        {
            return View();
        }
        [Audit]
        public ActionResult Love()
        {
            return View();
        }
        [Audit]
        public ActionResult Thriller()
        {
            return View();
        }
        [Audit]
        public ActionResult Horror()
        {
            return View();
        }
        [Audit]
        public ActionResult Drama()
        {
            return View();
        }
    }
}