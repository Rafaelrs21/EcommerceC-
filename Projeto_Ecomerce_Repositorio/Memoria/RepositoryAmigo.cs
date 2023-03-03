using Projeto_Ecomerce_Biblioteca.Entidade;
using Projeto_Ecomerce_Biblioteca.Repository;
using System.Collections.Generic;

namespace Projeto_Ecomerce_Repositorio.Memoria
{
    public class RepositoryAmigo : IRepositoryAmigo
    {
        private static List<Amigo> Clientes { get; set; } = new List<Amigo>();

        public void Create(Amigo cliente)
        {
            cliente.Id = RepositoryAmigo.Clientes.Count + 1;
            RepositoryAmigo.Clientes.Add(cliente);
        }

        public void Delete(Amigo cliente)
        {
            RepositoryAmigo.Clientes.Remove(cliente);
        }

        public List<Amigo> GetAll()
        {
            return RepositoryAmigo.Clientes;
        }

        public Amigo GetAmigo(int id)
        {
            return RepositoryAmigo.Clientes.Find(x => x.Id == id);
        }

        public void Update(Amigo cliente, int id)
        {
            var clienteOld = this.GetAmigo(id);

            this.Delete(clienteOld);
            this.Create(cliente);

        }
    }
}
