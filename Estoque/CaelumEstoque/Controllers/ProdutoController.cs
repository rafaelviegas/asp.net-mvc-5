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

        public ActionResult Form()
        {
            var categoriasDao = new CategoriasDAO();
            var categorias = categoriasDao.Lista();

            ViewBag.Categorias = categorias;

            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            var dao = new ProdutosDAO();

            dao.Adiciona(produto);

            return RedirectToAction("Index");
        }

    }
}