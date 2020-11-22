using Avd4.Aula.DataSql.Repositorio.Repositorio;
using System;
using System.Linq;
using Xunit;

namespace Avd4.Aula.Tests
{
    public class AlunoTest
    {
        AlunoRepositorio _alunoRepositorio = new AlunoRepositorio();

        [Fact]
        public void Cadastrar()
        {
            _alunoRepositorio.Cadastrar(new Domain.Entidades.Aluno
            {

                Nome = "João",
                Matricula = "1",
                Email = "a@gmail.com",
                Endereco = "avenida",
                Numero = "1100",
                Bairro = "copacabana",
                Cidade = "rio de janeiro",
                Estado = "rj"

            });
            Assert.True(true);
        }

        [Fact]
        public void Atualizat()
        {
            _alunoRepositorio.Atualizar(new Domain.Entidades.Aluno
            {

                Id = 2,
                Nome = "João",
                Matricula = "1",
                Email = "a@gmail.com",
                Endereco = "avenida",
                Numero = "1100",
                Bairro = "copacabana",
                Cidade = "rio de janeiro",
                Estado = "rj"

            });
            Assert.True(true);
        }

        [Fact]
        public void Excluir()
        {
            _alunoRepositorio.Excluir(1);
            Assert.True(true);
        }

        [Fact]
        public void Listar()
        {
            var listar = _alunoRepositorio.Listar();
            Assert.True(listar.Any());
        }

        [Fact]
        public void Obter()
        {
            var obter = _alunoRepositorio.Obter(2);
            Assert.True(obter.Id > 0);
        }
    }
}
