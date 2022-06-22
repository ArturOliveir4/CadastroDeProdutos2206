using CadastroDeProdutos.Helper;
using CadastroDeProdutos.Models;
using CadastroDeProdutos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeProdutos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;   
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoDoUsusario() != null) return RedirectToAction("Index","Home");

            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {

            if (ModelState.IsValid)
            {
                UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                if (usuario!=null)
                {
                    if(usuario.SenhaValida(loginModel.Senha))
                    {
                        _sessao.CriarSessaoDoUsusario(usuario);
                        return RedirectToAction("Index", "Home", usuario);
                    }
                    
                }
            }

            return View("Index");

        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsusario();
            return RedirectToAction("Index", "Login");  
        }

    }
}
