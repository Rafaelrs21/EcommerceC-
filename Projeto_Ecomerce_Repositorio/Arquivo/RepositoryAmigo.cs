using Newtonsoft.Json;
using Projeto_Ecomerce_Biblioteca.Entidade;
using Projeto_Ecomerce_Biblioteca.Repository;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Projeto_Ecomerce_Repositorio.Arquivo
{
    public class RepositoryAmigo : IRepositoryAmigo
    {
        private string file_entrega = "file_entrega.txt";
        private string path_arquivo = @"C:\Users\santi\Ecomerce_Project";
        private List<Amigo> Amigos { get; set; }

        public RepositoryAmigo()
        {
            if (Directory.Exists(path_arquivo) == false)
                Directory.CreateDirectory(path_arquivo);

            var pathArquivo = Path.Combine(path_arquivo, file_entrega);

            if (File.Exists(pathArquivo) == false)
                File.Create(pathArquivo);

        }

        public void GravaArquivo()
        {
            var pathArquivo = Path.Combine(path_arquivo, file_entrega);
            using (FileStream file = File.Open(pathArquivo, FileMode.Open, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    var json = JsonConvert.SerializeObject(this.Amigos);

                    writer.Write(json);
                    writer.Flush();
                    writer.Close();
                }

                file.Close();
            }
        }

        public void LerArquivo()
        {
            var pathArquivo = Path.Combine(path_arquivo, file_entrega);
            using (FileStream file = File.Open(pathArquivo, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    var list_json = reader.ReadToEnd();
                    this.Amigos = JsonConvert.DeserializeObject<List<Amigo>>(list_json);

                    if (Amigos == null)
                        Amigos = new List<Amigo>();

                    reader.Close();
                }
                file.Close();
            }
        }

        public void Create(Amigo amigo)
        {
            var maxId = 0;

            if (this.Amigos.Count > 0)
                maxId = this.Amigos.Max(x => x.Id) + 1;

            amigo.Id = maxId;

            this.Amigos.Add(amigo);

        }

        public void Delete(Amigo amigo)
        {
            var client_delete = this.Amigos.Find(x => x.Id == amigo.Id);
            Amigos.Remove(client_delete);
        }

        public List<Amigo> GetAll()
        {
            return this.Amigos;
        }

        public Amigo GetAmigo(int id)
        {
            return this.Amigos.Find(x => x.Id == id);
        }

        public void Update(Amigo amigo, int id)
        {
            var amigoOld = this.GetAmigo(id);

            this.Delete(amigoOld);
            this.Create(amigo);
        }
    }
}
