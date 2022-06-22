using CadastroDeProdutos.Models;
using CadastroDeProdutos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Lista()
        {
            var produtos = _produtoRepositorio.BuscarTodos();
            return View(produtos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ProdutoModel produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepositorio.Adicionar(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }
      
        public IActionResult Editar(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        [HttpPost]
        public IActionResult Alterar(ProdutoModel produto)
        {
            if(ModelState.IsValid)
            {
                _produtoRepositorio.Atualizar(produto);
                return RedirectToAction("Lista");
            }

            return View("Editar", produto);
            
        }

        public IActionResult ApagarConfirmar(int id)
        {
            ProdutoModel produto = _produtoRepositorio.ListarPorId(id);
            return View(produto);
        }

        public IActionResult Apagar(int id)
        {
            _produtoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

    }
}
