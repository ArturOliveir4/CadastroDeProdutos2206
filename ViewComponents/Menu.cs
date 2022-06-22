using CadastroDeProdutos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CadastroDeProdutos.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokerAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuariologado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            UsuarioModel usuario = JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);

            return View(usuario);
        }
    }
}
