using Avd4.Aula.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Avd4.Aula.DataSql.Repositorio.Repositorio
{
    public class InscricaoRepositorio : BaseRepositorio
    {
        public void Cadastrar(Inscricao inscricao)
        {
            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspCadastrarInscricao";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@DataInicio", Value = inscricao.DataInicio, SqlDbType = SqlDbType.DateTime });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@DataConclusao", Value = inscricao.DataConclusao, SqlDbType = SqlDbType.DateTime });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Status", Value = inscricao.Status, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@IdAluno", Value = inscricao.IdAluno, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@IdCurso", Value = inscricao.IdCurso, SqlDbType = SqlDbType.Int });

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

        public void Atualizar(Inscricao inscricao)
        {
            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspAlterarCadastroInscricao";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = inscricao.Id, SqlDbType = SqlDbType.Int });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@DataInicio", Value = inscricao.DataInicio, SqlDbType = SqlDbType.DateTime });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@DataConclusao", Value = inscricao.DataConclusao, SqlDbType = SqlDbType.DateTime });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@Status", Value = inscricao.Status, SqlDbType = SqlDbType.VarChar });
                    command.Parameters.Add(new SqlParameter { ParameterName = "@IdCurso", Value = inscricao.IdCurso, SqlDbType = SqlDbType.Int });

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
                string sql = "uspDeletarCadastroInscricao";

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
                        throw new Exception("Nenhuma inscrição encontrada.");
                    }
                }
            }
        }

        public List<Inscricao> Listar()
        {
            List<Inscricao> retorno = new List<Inscricao>();
            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspConsultarCadastroInscricao";

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
                            retorno.Add(new Inscricao
                            {
                                Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                IdAluno = (dataReader["IdAluno"] == null) ? 0 : Convert.ToInt32(dataReader["IdAluno"]),
                                IdCurso = (dataReader["IdCurso"] == null) ? 0 : Convert.ToInt32(dataReader["IdCurso"]),
                                DataConclusao = (dataReader["DataConclusao"] == null) ? default : Convert.ToDateTime(dataReader["DataConclusao"]),
                                Status = (dataReader["Status"] == null) ? null : dataReader["Status"].ToString(),
                                DataInicio = (dataReader["DataInicio"] == null) ? default : Convert.ToDateTime(dataReader["DataInicio"]),
                            });
                        }
                    }

                    // fecha a conexão
                    connection.Close();
                }
            }

            // caso exista a inscrição, lista os alunos relacionados
            if (retorno != null && retorno.Any())
            {
                // iniciar a criação da conexão com o banco de dados
                using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
                {
                    var sql = "uspObterAluno";

                    foreach (var item in retorno)
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = item.IdAluno, SqlDbType = SqlDbType.Int });

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
                                    item.Alunos = new Aluno
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
                        }

                        // fecha a conexão
                        connection.Close();
                    }
                }
            }

            // caso exista a inscrição, lista os alunos relacionados
            if (retorno != null && retorno.Any())
            {
                // iniciar a criação da conexão com o banco de dados
                using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
                {
                    var sql = "uspObterCurso";

                    foreach (var item in retorno)
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = item.IdCurso, SqlDbType = SqlDbType.Int });

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
                                    item.Cursos = new Curso
                                    {
                                        Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                        Nome = (dataReader["Nome"] == null) ? null : dataReader["Nome"].ToString(),
                                        Descricao = (dataReader["Descricao"] == null) ? null : dataReader["Descricao"].ToString()
                                    };
                                }
                            }
                        }

                        // fecha a conexão
                        connection.Close();
                    }
                }
            }

            // caso exista a inscrição, lista os alunos relacionados
            if (retorno != null && retorno.Any())
            {
                // iniciar a criação da conexão com o banco de dados
                using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
                {
                    string sql = "uspObterDisciplinaPorCurso";

                    foreach (var item in retorno)
                    {
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.Add(new SqlParameter { ParameterName = "@IdCurso", Value = item.IdCurso, SqlDbType = SqlDbType.Int });

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
                                    item.Cursos.Disciplinas.Add(new Disciplina
                                    {
                                        Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                        CargaHoraria = (dataReader["CargaHoraria"] == null) ? 0 : Convert.ToInt32(dataReader["CargaHoraria"]),
                                        Nome = (dataReader["Nome"] == null) ? null : dataReader["Nome"].ToString(),
                                        Descricao = (dataReader["Descricao"] == null) ? null : dataReader["Descricao"].ToString()
                                    });
                                }
                            }
                        }

                        // fecha a conexão
                        connection.Close();
                    }
                }
            }

            return retorno;
        }

        public Inscricao Obter(int id)
        {
            Inscricao retorno = new Inscricao();

            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspObterInscricao";

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
                            retorno = new Inscricao
                            {
                                Id = (dataReader["Id"] == null) ? 0 : Convert.ToInt32(dataReader["Id"]),
                                IdAluno = (dataReader["IdAluno"] == null) ? 0 : Convert.ToInt32(dataReader["IdAluno"]),
                                IdCurso = (dataReader["IdCurso"] == null) ? 0 : Convert.ToInt32(dataReader["IdCurso"]),
                                DataInicio = (dataReader["DataInicio"] == null) ? default : Convert.ToDateTime(dataReader["DataInicio"].ToString()),
                                DataConclusao = (dataReader["DataConclusao"] == null) ? default : Convert.ToDateTime(dataReader["DataConclusao"].ToString()),
                                Status = (dataReader["Status"] == null) ? null : dataReader["Status"].ToString()
                            };
                        }
                    }

                    // fecha a conexão
                    connection.Close();
                }
            }

            // caso exista a inscrição, lista os alunos relacionados
            if (retorno != null)
            {
                // iniciar a criação da conexão com o banco de dados
                using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
                {
                    var sql = "uspObterAluno";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = retorno.IdAluno, SqlDbType = SqlDbType.Int });

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
                                retorno.Alunos = new Aluno
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
            }

            // caso exista a inscrição, lista os alunos relacionados
            if (retorno != null)
            {
                // iniciar a criação da conexão com o banco de dados
                using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
                {
                    var sql = "uspObterCurso";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add(new SqlParameter { ParameterName = "@Id", Value = retorno.IdCurso, SqlDbType = SqlDbType.Int });

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
                                retorno.Cursos = new Curso
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
            }

            // iniciar a criação da conexão com o banco de dados
            using (SqlConnection connection = new SqlConnection(_conexaoBancoDeDados))
            {
                // procedure para salvar o aluno
                string sql = "uspObterDisciplinaPorCurso";

                // inicia o comando para salvar os dados
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter { ParameterName = "@IdCurso", Value = retorno.IdCurso, SqlDbType = SqlDbType.Int });

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
                            retorno.Cursos.Disciplinas.Add(new Disciplina
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
