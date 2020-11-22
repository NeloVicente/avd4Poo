using Avd4.Aula.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Avd4.Aula.DataSql.Repositorio.Repositorio
{
    public class DisciplinaRepositorio : BaseRepositorio
    {
        public void Cadastrar(Disciplina disciplina)
        {
            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspCadastrarDisciplina";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Nome", Value = disciplina.Nome, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Descricao", Value = disciplina.Descricao, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@CargaHoraria", Value = disciplina.CargaHoraria, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@IdCurso", Value = disciplina.IdCurso, SqlDbType = SqlDbType.Int });

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

        public void Atualizar(Disciplina disciplina)
        {
            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspAlterarCadastroDisciplina";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = disciplina.Id, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Nome", Value = disciplina.Nome, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Descricao", Value = disciplina.Descricao, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@CargaHoraria", Value = disciplina.CargaHoraria, SqlDbType = SqlDbType.Int });
                
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
                        throw new Exception("Nenhuma disciplina encontrada.");
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
                string sql = "uspDeletarCadastroDisciplina";

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
                        throw new Exception("Nenhum disciplina encontrado.");
                    }
                }
            }
        }

        public List<Disciplina> Listar()
        {
            List<Disciplina> retorno = new List<Disciplina>();

            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspConsultarCadastroDisciplina";

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
                            retorno.Add(new Disciplina
                            {
                                Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                CargaHoraria = (dataReader["CargaHoraria"] == null) ? 0 : Convert.ToInt32(dataReader["CargaHoraria"]), 
                                Nome = (dataReader["Nome"] == null) ? null : dataReader["Nome"].ToString(),
                                Descricao = (dataReader["Descricao"] == null) ? null : dataReader["Descricao"].ToString(),
                                IdCurso = (dataReader["IdCurso"] == null) ? 0 : Convert.ToInt32(dataReader["IdCurso"])
                            });
                        }
                    }

                    // fecha a conexão
                    connection.Close();
                }
            }
            return retorno;
        }

        public Disciplina Obter(int id)
        {
            Disciplina retorno = new Disciplina();

            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspObterDisciplina";

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
                            retorno = new Disciplina
                            {
                                Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                Nome = (dataReader["Nome"] == null) ? null : dataReader["Nome"].ToString(),
                                Descricao = (dataReader["Descricao"] == null) ? null : dataReader["Descricao"].ToString(),
                                CargaHoraria = (dataReader["CargaHoraria"] == null) ? 0 : Convert.ToInt32(dataReader["CargaHoraria"]),
                                IdCurso = (dataReader["IdCurso"] == null) ? 0 : Convert.ToInt32(dataReader["IdCurso"])
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
