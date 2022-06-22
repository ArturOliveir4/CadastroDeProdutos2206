using System.ComponentModel.DataAnnotations;

namespace CadastroDeProdutos.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do produto")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o preço do produto")]
        public float ? Preco { get; set; }
        [Range(1, 100, ErrorMessage = "Podem ser cadastrados no mínimo 1 produto, e no máximo 100 produtos")]
        public int Quantidade { get; set; }


    }
}
