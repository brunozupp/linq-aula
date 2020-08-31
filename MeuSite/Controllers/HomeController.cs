using MeuSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var produtos = new ProdutoBusiness().Listar();

            ViewBag.Count = produtos.Count;
            
            if(produtos.Count > 0) ViewBag.Produtos = produtos.Take(6);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}