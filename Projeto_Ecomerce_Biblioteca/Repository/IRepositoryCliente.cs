using Projeto_Ecomerce_Biblioteca.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Ecomerce_Biblioteca.Repository
{
    public interface IRepositoryCliente
    {
        void Create(Cliente cliente);
        void Update(Cliente cliente, int id);
        void Delete(Cliente cliente);
        Cliente GetCliente(int id);
        List<Cliente> GetAll();
    }
}
