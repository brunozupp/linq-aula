using MeuSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuSite.Controllers
{
   
    public class ProdutoController : Controller
    {
        ProdutoBusiness produtoBusiness = new ProdutoBusiness();
        // GET: Produto
        public ActionResult Index()
        {
            if(TempData["Operation"] != null)
            {
                ViewBag.Operation = TempData["Operation"];
            }

            //Executa a lista de produtos no banco de dados.
            var lista = produtoBusiness.Listar();
            return View(lista);
        }

        public ActionResult Detalhes(int id)
        {
            //Executa a lista de produtos no banco de dados.
            var prod = produtoBusiness.Buscar(id);
            return View(prod);
        }

        public ActionResult Save(int id = 0)
        {
            if(id > 0)
            {
                Produto produto = produtoBusiness.Buscar(id);

                return View(produto);
            } else
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult Save(Produto produto)
        {

            try
            {
                if (produto.ID > 0)
                {
                    produtoBusiness.Alterar(produto);
                }
                else
                {
                    produtoBusiness.Inserir(produto);
                }

                TempData["Operation"] = new ResponseOperation {
                    Status = true,
                    Message = "Operação realizada com sucesso"
                };

                return Json(new { status = true });
            }
            catch (Exception)
            {
                TempData["Operation"] = new ResponseOperation
                {
                    Status = false,
                    Message = "Operação falhou"
                };

                return Json(new { status = false });
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                produtoBusiness.Deletar(id);

                TempData["Operation"] = new ResponseOperation
                {
                    Status = true,
                    Message = "Operação realizada com sucesso"
                };

                return RedirectToAction("Index", "Produto");
            }
            catch (Exception)
            {
                TempData["Operation"] = new ResponseOperation
                {
                    Status = true,
                    Message = "Operação falhou"
                };

                return RedirectToAction("Index", "Produto");
            }
        }
    }
}