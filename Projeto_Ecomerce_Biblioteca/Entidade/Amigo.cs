using System;
using System.Collections.Generic;
using Entidade;
using Projeto_Ecomerce_Biblioteca.Repository;

namespace Projeto_Ecomerce_Biblioteca.Entidade
{
    public class Amigo
    {
        public Amigo()
        {

        }

        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Sobrenome { get; set; }
        public int Idade { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}