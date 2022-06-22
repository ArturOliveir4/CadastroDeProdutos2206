using CadastroDeProdutos.Data;
using CadastroDeProdutos.Models;

namespace CadastroDeProdutos.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ProdutoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ProdutoModel Adicionar(ProdutoModel produto)
        {
            _bancoContext.Produto.Add(produto);
            _bancoContext.SaveChanges();
            return produto;
        }

        public bool Apagar(int id)
        {
            ProdutoModel produtoBd = ListarPorId(id);

            if (produtoBd == null) throw new System.Exception("Erro na deleção do produto!");

            _bancoContext.Produto.Remove(produtoBd);
            _bancoContext.SaveChanges();

            return true;
        }

        public ProdutoModel Atualizar(ProdutoModel produto)
        {
            ProdutoModel produtoBd = ListarPorId(produto.Id);

            if (produtoBd == null) throw new System.Exception("Erro na atualização do produto!");

            produtoBd.Nome = produto.Nome;
            produtoBd.Preco = produto.Preco;
            produtoBd.Quantidade = produto.Quantidade;

            _bancoContext.Produto.Update(produtoBd);
            _bancoContext.SaveChanges();
            return produtoBd;
        }


        public List<ProdutoModel> BuscarTodos()
        {
            return _bancoContext.Produto.ToList();  
        }

        public ProdutoModel ListarPorId(int id)
        {
            return _bancoContext.Produto.FirstOrDefault(x => x.Id == id);
        }
    }
}
