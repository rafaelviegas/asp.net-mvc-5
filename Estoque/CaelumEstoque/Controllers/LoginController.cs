using System.Web.Mvc;
using CaelumEstoque.DAO;

namespace CaelumEstoque.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(string login, string senha)
        {
            var dao = new UsuariosDAO();
            var usuario = dao.Busca(login, senha);
            if (usuario == null) return RedirectToAction("Index");

            Session["UsuarioLogado"] = usuario;
            return RedirectToAction("Index", "Produto");
        }
    }
}