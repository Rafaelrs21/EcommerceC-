using Dapper;
using Projeto_Ecomerce_Biblioteca.Entidade;
using Projeto_Ecomerce_Biblioteca.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto_Ecomerce_Repositorio.DataBase
{
    public class RepositoryAmigo : IRepositoryAmigo
    {
        private string Connection = @"Data Source=LAPTOP-L8FQSUD2\SQLEXPRESS01;Initial Catalog=AniversarioGerencia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Create(Amigo amigo)
        {
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                var sql = @"dbo.InsertAniversariante";

                conn.Execute(sql, new
                {
                    NomeCompleto = amigo.NomeCompleto,
                    Sobrenome = amigo.Sobrenome,
                    Idade = amigo.Idade,
                    DataNascimento = amigo.DataNascimento
                }, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

        public void Delete(Amigo amigo)
        {
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                var sql = @"dbo.DeleteAniversariante";

                conn.Execute(sql, new
                {
                    Id = amigo.Id,
                }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Amigo> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                var sql = @"[dbo].[SelectAllAniversariantes]";

                var resultado = conn.Query<Amigo>(sql, commandType: System.Data.CommandType.StoredProcedure);

                return resultado.AsList();
            }
        }

        public Amigo GetAmigo(int id)
        {
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                var sql = @"[dbo].[SelectAniversarianteBYId]";

                conn.Open();

                var command = conn.CreateCommand();

                command.CommandText = sql;
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Id", id));

                var result = command.ExecuteReader();

                Amigo amigo = null;

                while (result.Read())
                {
                    amigo = new Amigo();

                    amigo.Id = Convert.ToInt32(result[0]);
                    amigo.NomeCompleto = result[1].ToString();
                    amigo.Sobrenome = result[2].ToString();
                    amigo.Idade = Convert.ToInt32(result[3].ToString());
                    amigo.DataNascimento = Convert.ToDateTime(result[4]);
                }

                conn.Close();

                return amigo;
            }
        }

        public void Update(Amigo amigo, int id)
        {
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                var sql = @"dbo.UpdateAniversariante";

                conn.Execute(sql, new
                {
                    NomeCompleto = amigo.NomeCompleto,
                    Sobrenome = amigo.Sobrenome,
                    Idade = amigo.Idade,
                    DataNascimento = amigo.DataNascimento,
                    Id = id
                }, commandType: System.Data.CommandType.StoredProcedure); ;
            }
        }
    }
}
