using CadastroDeProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroDeProdutos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ProdutoModel> Produto { get; set; }

        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
