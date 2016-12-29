using System.Web.Mvc;
using CaelumEstoque.DAO;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            var dao = new CategoriasDAO();
            var categorias = dao.Lista();
            ViewBag.Categorias = categorias;
            return View();
        }
    }
}