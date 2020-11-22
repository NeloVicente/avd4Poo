using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Avd4.Aula.Domain.Entidades;

namespace Avd4.Aula.DataSql.Repositorio.Repositorio
{
    public class AlunoRepositorio : BaseRepositorio
    {
        /// <summary>
        /// Salvar aluno
        /// </summary>
        public void Cadastrar(Aluno aluno)
        {
            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspCadastrarAluno";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Nome", Value = aluno.Nome, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Email", Value = aluno.Email, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Endereco", Value = aluno.Endereco, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Numero", Value = aluno.Numero, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Cidade", Value = aluno.Cidade, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Bairro", Value = aluno.Bairro, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Estado", Value = aluno.Estado, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Matricula", Value = aluno.Matricula, SqlDbType = SqlDbType.VarChar });

                    // tipo de execusão
                    command.CommandType = CommandType.StoredProcedure;

                    // abrir conexão com o banco
                    connection.Open();

                    // executa a procedure
                    command.ExecuteNonQuery();

                    // fecha a conexão
                    connection.Close();
                }
            }
        }

        public void Atualizar(Aluno aluno)
        {
            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspAlterarCadastroAluno";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = aluno.Id, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Nome", Value = aluno.Nome, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Email", Value = aluno.Email, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Endereco", Value = aluno.Endereco, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Numero", Value = aluno.Numero, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Cidade", Value = aluno.Cidade, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Bairro", Value = aluno.Bairro, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Estado", Value = aluno.Estado, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Matricula", Value = aluno.Matricula, SqlDbType = SqlDbType.VarChar });

                    // tipo de execusão
                    command.CommandType = CommandType.StoredProcedure;

                    // abrir conexão com o banco
                    connection.Open();

                    // executa a procedure
                    int resultado = command.ExecuteNonQuery();

                    // fecha a conexão
                    connection.Close();

                    if (resultado < 1)
                    {
                        throw new Exception("Nenhum aluno encontrado.");
                    }
                }
            }
        }

        public void Excluir(int id)
        {
            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspDeletarCadastroAluno";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = id, SqlDbType = SqlDbType.Int });

                    // tipo de execusão
                    command.CommandType = CommandType.StoredProcedure;

                    // abrir conexão com o banco
                    connection.Open();

                    // executa a procedure
                    int resultado = command.ExecuteNonQuery();

                    // fecha a conexão
                    connection.Close();

                    if (resultado < 1)
                    {
                        throw new Exception("Nenhum aluno encontrado.");
                    }
                }
            }
        }

        public List<Aluno> Listar()
        {
            List<Aluno> retorno = new List<Aluno>();

            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspConsultarCadastroAluno";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // tipo de execusão
                    command.CommandType = CommandType.StoredProcedure;

                    // abrir conexão com o banco
                    connection.Open();

                    // faz busca no banco 
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        // ler resultado e popula objeto retorno com os dados do aluno
                        while (dataReader.Read())
                        {
                            // adicionar retorno do select no objeto retorno
                            retorno.Add(new Aluno
                            {
                                Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                Nome = (dataReader["Nome"] == null) ? null : dataReader["Nome"].ToString(),
                                Email = (dataReader["Email"] == null) ? null : dataReader["Email"].ToString(),
                                Endereco = (dataReader["Endereco"] == null) ? null : dataReader["Endereco"].ToString(),
                                Numero = (dataReader["Numero"] == null) ? null : dataReader["Numero"].ToString(),
                                Cidade = (dataReader["Cidade"] == null) ? null : dataReader["Cidade"].ToString(),
                                Bairro = (dataReader["Bairro"] == null) ? null : dataReader["Bairro"].ToString(),
                                Estado = (dataReader["Estado"] == null) ? null : dataReader["Estado"].ToString(),
                                Matricula = (dataReader["Matricula"] == null) ? null : dataReader["Matricula"].ToString()
                            });
                        }
                    }

                    // fecha a conexão
                    connection.Close();
                }
            }

            return retorno;
        }

        public Aluno Obter(int id)
        {
            Aluno retorno = new Aluno();

            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspObterAluno";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = id, SqlDbType = SqlDbType.Int });

                    // tipo de execusão
                    command.CommandType = CommandType.StoredProcedure;

                    // abrir conexão com o banco
                    connection.Open();

                    // faz busca no banco 
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        // ler resultado e popula objeto retorno com os dados do aluno
                        while (dataReader.Read())
                        {
                            retorno = new Aluno
                            {
                                Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                Nome = (dataReader["Nome"] == null) ? null : dataReader["Nome"].ToString(),
                                Email = (dataReader["Email"] == null) ? null : dataReader["Email"].ToString(),
                                Endereco = (dataReader["Endereco"] == null) ? null : dataReader["Endereco"].ToString(),
                                Numero = (dataReader["Numero"] == null) ? null : dataReader["Numero"].ToString(),
                                Cidade = (dataReader["Cidade"] == null) ? null : dataReader["Cidade"].ToString(),
                                Bairro = (dataReader["Bairro"] == null) ? null : dataReader["Bairro"].ToString(),
                                Estado = (dataReader["Estado"] == null) ? null : dataReader["Estado"].ToString(),
                                Matricula = (dataReader["Matricula"] == null) ? null : dataReader["Matricula"].ToString()
                            };
                        }
                    }

                    // fecha a conexão
                    connection.Close();
                }
            }

            return retorno;
        }
    }
}
