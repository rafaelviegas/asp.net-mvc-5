﻿using System.Collections.Generic;
using System.Web.Mvc;
using CaelumEstoque.DAO;
using CaelumEstoque.Models;

namespace CaelumEstoque.Controllers
{
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
    }
}