using CadastroDeProdutos.Models;

namespace CadastroDeProdutos.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsusario(UsuarioModel usuario);
        void RemoverSessaoDoUsusario();
        UsuarioModel BuscarSessaoDoUsusario();
    }
}
