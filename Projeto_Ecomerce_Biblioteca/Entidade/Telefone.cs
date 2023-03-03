using Entidade;

namespace Projeto_Ecomerce_Biblioteca.Entidade
{
    public class Telefone
    {
         public int NumeroLinha { get; set; }
        public int DDD { get; set; }
        public int NumeroEstado { get; set; }

        public TipoTelefoneEnum TipoTelefone { get; set; }
    }
}