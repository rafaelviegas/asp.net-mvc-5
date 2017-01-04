using System;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class ContadorController : Controller
    {
        // GET: Contador
        public ActionResult Index()
        {
            var valorNaSession = Session["contador"];
            var contador = Convert.ToInt32(valorNaSession);
                contador++;

            Session["contador"] = contador;

            return View(contador);
        }
    }
}