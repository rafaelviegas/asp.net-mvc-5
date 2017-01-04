using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Filters;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        // GET: Produtos
        [Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {
            var dao = new ProdutosDAO();
            var produtos = dao.Lista();

            return View(produtos);
        }

        public ActionResult Form()
        {
            var categoriasDao = new CategoriasDAO();
            var categorias = categoriasDao.Lista();

            ViewBag.Categorias = categorias;
            ViewBag.Produto = new Produto();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Produto produto)
        {
            const int idInformatica = 1;

            if (produto.CategoriaId.Equals(idInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.Invalido","Informática com preço abaixo de 100");
            }

            if (ModelState.IsValid)
            {

                var dao = new ProdutosDAO();
                dao.Adiciona(produto);

                return RedirectToAction("Index");
            }

            var categoriasDao = new CategoriasDAO();
            ViewBag.Produto = produto;
            ViewBag.Categorias = categoriasDao.Lista();
            return View("Form");
        }

        [Route("produtos/{id}",Name = "VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            var dao = new ProdutosDAO();
            var produto = dao.BuscaPorId(id);
            ViewBag.Produto = produto;

            return View();

        }

        public ActionResult DecrementaQtd(int id)
        {
            var dao = new ProdutosDAO();

            var produto = dao.BuscaPorId(id);
                produto.Quantidade--;

                dao.Atualiza(produto);

            return Json(produto);
        }
    }
}