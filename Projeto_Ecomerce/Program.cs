using Newtonsoft.Json;
using Projeto_Ecomerce_Biblioteca.Entidade;
using Projeto_Ecomerce_Biblioteca.Repository;
using System;
using System.Linq;

namespace Projeto_Ecomerce
{
    public class Program
    {
        private static Projeto_Ecomerce_Repositorio.DataBase.RepositoryAmigo repositoryAmigo = new Projeto_Ecomerce_Repositorio.DataBase.RepositoryAmigo();

        static void Main(string[] args)
        {
               
            Console.WriteLine("==============================================");
            Console.WriteLine("============== Gerencia de Aniversario ===========");
            Console.WriteLine("==============================================");

            var sair = false;

            while (!sair)
            {
                AniversarianteDoDia();
                Console.WriteLine("==============================================");
                ExibeOpções();
                var opt = Console.ReadLine();

                switch (opt)
                {
                    case "1":
                        CadastroAmigo();
                        break;
                    case "2":
                        AtualizarAmigo();
                        break;
                    case "3":
                        ExcluirAmigo();
                        break;
                    case "4":
                        ObterAmigo();
                        break;
                    case "5":
                        ListarTodosAmigos();
                        break;
                    case "q":
                        Console.WriteLine("Até Logo :)");
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }

            }
        }

        private static void ListarTodosAmigos()
        {
            IRepositoryAmigo repository = new Projeto_Ecomerce_Repositorio.Arquivo.RepositoryAmigo();

            Console.WriteLine("Exibindo Amigos");
            Console.WriteLine("");
            var amigos = repositoryAmigo.GetAll();
            Console.WriteLine(JsonConvert.SerializeObject(amigos, Formatting.Indented));
            Console.WriteLine("");
            Console.WriteLine("");
        }

        private static void ObterAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificado do amigo");

            var id = Convert.ToInt32(Console.ReadLine());
            var amigo = repositoryAmigo.GetAmigo(id);
            
            Console.WriteLine("");
            Console.WriteLine($"Exibindo amigo com o identificador {id}");
            Console.WriteLine("");
            Console.WriteLine(JsonConvert.SerializeObject(amigo, Formatting.Indented));
            CalcularTempo(amigo);

            Console.WriteLine("");
            Console.WriteLine("");

        }

        private static void ExcluirAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificado do amigo");

            var id = Convert.ToInt32(Console.ReadLine());
            var amigo = repositoryAmigo.GetAmigo(id);

            if (amigo == null)
                Console.WriteLine("Amigo não encontrado");
            else
            {
                repositoryAmigo.Delete(amigo);
                Console.WriteLine("Amigo excluido com sucesso");
            }
        }

        private static void AtualizarAmigo()
        {
            Console.WriteLine("");
            Console.WriteLine("Digite o identificado do amigo");

            var id = Convert.ToInt32(Console.ReadLine());
            var amigo = repositoryAmigo.GetAmigo(id);

            if (amigo == null)
            {
                Console.WriteLine("Amigo não encontrado");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine($"Exibindo Amigo com o identificador {id}");
                Console.WriteLine("");
                Console.WriteLine(JsonConvert.SerializeObject(amigo, Formatting.Indented));
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Digite o Nome do amigo");
                amigo.NomeCompleto = Console.ReadLine();

                Console.WriteLine("Digite o Sobrenome do amigo");
                amigo.Sobrenome = Console.ReadLine();

                Console.WriteLine("Digite a idade do amigo");
                amigo.Idade = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Digite a data de nascimento do amigo");
                amigo.DataNascimento = DateTime.Parse(Console.ReadLine());

                repositoryAmigo.Update(amigo, id);

                Console.WriteLine("");
                Console.WriteLine($"Exibindo novo amigo com o identificador {id}");
                Console.WriteLine("");
                Console.WriteLine(JsonConvert.SerializeObject(amigo, Formatting.Indented));
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        private static void CadastroAmigo()
        {
            var amigo = new Amigo();

            Console.WriteLine("Digite o Nome do amigo");
            amigo.NomeCompleto = Console.ReadLine();

            Console.WriteLine("Digite o Sobrenome do amigo");
            amigo.Sobrenome = Console.ReadLine();

            Console.WriteLine("Digite a idade do amigo");
            amigo.Idade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite a data de nascimento do amigo");
            amigo.DataNascimento = DateTime.Parse(Console.ReadLine());

            repositoryAmigo.Create(amigo);

            Console.WriteLine("Cadastro Realizado com sucesso!");

        }

        private static void ExibeOpções()
        {
            Console.WriteLine("Selecione as opções");
            Console.WriteLine("1 - Para criar um Amigo");
            Console.WriteLine("2 - Para atualizar um Amigo");
            Console.WriteLine("3 - Para excluir um Amigo");
            Console.WriteLine("4 - Para obter um Amigo");
            Console.WriteLine("5 - Para exibir todos os Amigo");
            Console.WriteLine("q - Para sair");
        }

        public static void CalcularTempo(Amigo amigo)
        {
            var proximo = DateTime.Now - amigo.DataNascimento;
            Console.WriteLine( $"Tempo para Aniversario: {proximo}");
        }

        public static void AniversarianteDoDia()
        {
            var contador = repositoryAmigo.GetAll();
            var listaAniversariante = repositoryAmigo.GetAll().Where(x => x.DataNascimento == DateTime.Today);
            Console.WriteLine(listaAniversariante);
            
        }
    }
}