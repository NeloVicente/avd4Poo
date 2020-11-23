using Avd4.Aula.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Avd4.Aula.DataSql.Repositorio.Repositorio
{
    public class CursoRepositorio : BaseRepositorio
    {
        public void Cadastrar(Curso curso)
        {
            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspCadastrarCurso";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Nome", Value = curso.Nome, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Descricao", Value = curso.Descricao, SqlDbType = SqlDbType.VarChar });

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

        public void RelacionarCursoADiscipina(Curso curso)
        {

        }

        public void Atualizar(Curso curso)
        {
            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspAlterarCadastroCurso";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = curso.Id, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Nome", Value = curso.Nome, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Descricao", Value = curso.Descricao, SqlDbType = SqlDbType.VarChar });

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
                        throw new Exception("Nenhum curso encontrado.");
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
                string sql = "uspDeletarCadastroCurso";

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
                        throw new Exception("Nenhum curso encontrado.");
                    }
                }
            }
        }

        public List<Curso> Listar()
        {
            List<Curso> retorno = new List<Curso>();

            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspConsultarCadastroCurso";

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
                            retorno.Add(new Curso
                            {
                                Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                Nome = (dataReader["Nome"] == null) ? null : dataReader["Nome"].ToString(),
                                Descricao = (dataReader["Descricao"] == null) ? null : dataReader["Descricao"].ToString(),
                            });
                        }
                    }

                    // fecha a conexão
                    connection.Close();
                }
            }

            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // abrir conexão com o banco
                connection.Open();

                foreach (var item in retorno)
                {
                    // procedure para salvar o aluno
                    string sql = "uspObterDisciplinaPorCurso";

                    // inicia o comando para salvar os dados
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add(new SqlParameter { ParameterName = "@IdCurso", Value = item.Id, SqlDbType = SqlDbType.Int });

                        // tipo de execusão
                        command.CommandType = CommandType.StoredProcedure;

                        // faz busca no banco 
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            // ler resultado e popula objeto retorno com os dados do aluno
                            while (dataReader.Read())
                            {
                                item.Disciplinas.Add(new Disciplina
                                {
                                    Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                    Nome = (dataReader["Nome"] == null) ? null : dataReader["Nome"].ToString(),
                                    CargaHoraria = (dataReader["CargaHoraria"] == null) ? 0 : Convert.ToInt32(dataReader["CargaHoraria"]),
                                    Descricao = (dataReader["Descricao"] == null) ? null : dataReader["Descricao"].ToString()
                                });
                            }
                        }

                    }
                }

                // fecha a conexão
                connection.Close();
            }

            return retorno;
        }

        public Curso Obter(int id)
        {
            Curso retorno = new Curso();

            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspObterCurso";

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
                            retorno = new Curso
                            {
                                Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                Nome = (dataReader["Nome"] == null) ? null : dataReader["Nome"].ToString(),
                                Descricao = (dataReader["Descricao"] == null) ? null : dataReader["Descricao"].ToString()
                            };
                        }
                    }

                    // fecha a conexão
                    connection.Close();
                }
            }

            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspObterDisciplinaPorCurso";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@IdCurso", Value = retorno.Id, SqlDbType = SqlDbType.Int });

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
                            retorno.Disciplinas.Add(new Disciplina
                            {
                                Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                Nome = (dataReader["Nome"] == null) ? null : dataReader["Nome"].ToString(),
                                CargaHoraria = (dataReader["CargaHoraria"] == null) ? 0 : Convert.ToInt32(dataReader["CargaHoraria"]),
                                Descricao = (dataReader["Descricao"] == null) ? null : dataReader["Descricao"].ToString()
                            });
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
