using CadastroDeProdutos.Data;
using CadastroDeProdutos.Models;

namespace CadastroDeProdutos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataDeCadastro = DateTime.Now;
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioBd = ListarPorId(id);

            if (usuarioBd == null) throw new System.Exception("Erro na deleção do usuário!");

            _bancoContext.Usuario.Remove(usuarioBd);
            _bancoContext.SaveChanges();

            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioBd = ListarPorId(usuario.Id);

            if (usuarioBd == null) throw new System.Exception("Erro na atualização do produto!");

            usuarioBd.Nome = usuario.Nome;
            usuarioBd.Login = usuario.Login;
            usuarioBd.Email = usuario.Email;
            usuarioBd.Perfil = usuario.Perfil;
            usuarioBd.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuario.Update(usuarioBd);
            _bancoContext.SaveChanges();
            return usuarioBd;
        }

        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuario.ToList();  
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Id == id);
        }
    }
}
