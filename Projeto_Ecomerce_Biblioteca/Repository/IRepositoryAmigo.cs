using Projeto_Ecomerce_Biblioteca.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_Ecomerce_Biblioteca.Repository
{
    public interface IRepositoryAmigo
    {
        void Create(Amigo amigo);
        void Update(Amigo amigo, int id);
        void Delete(Amigo amigo);
        Amigo GetAmigo(int id);
        List<Amigo> GetAll();
    }
}
