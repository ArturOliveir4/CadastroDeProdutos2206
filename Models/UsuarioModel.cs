﻿using CadastroDeProdutos.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeProdutos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }

        public DateTime DataDeCadastro { get; set; }  
        
        public DateTime? DataAtualizacao { get; set; }

        public Boolean SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
