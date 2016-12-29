
using System.Collections.Generic;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            var dao = new ProdutosDAO();
            var produtos = dao.Lista();
            ViewBag.Produtos = produtos;
            return View();
        }
    }
}