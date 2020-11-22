using Avd4.Aula.DataSql.Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Avd4.Aula.Tests
{
    public class CursoTest
    {
        CursoRepositorio _cursoRepositorio = new CursoRepositorio();

        [Fact]
        public void Cadastrar()
        {
            _cursoRepositorio.Cadastrar(new Domain.Entidades.Curso
            {
                Nome = "Curso",
                Descricao = "Descricao"
            });
            Assert.True(true);
        }

        [Fact]
        public void Atualizat()
        {
            _cursoRepositorio.Atualizar(new Domain.Entidades.Curso
            {
                Id = 1,
                Nome = "Curso",
                Descricao = "Descricao"
            });
            Assert.True(true);
        }

        [Fact]
        public void Excluir()
        {
            _cursoRepositorio.Excluir(1);
            Assert.True(true);
        }

        [Fact]
        public void Listar()
        {
            var listar = _cursoRepositorio.Listar();
            Assert.True(listar.Any());
        }

        [Fact]
        public void Obter()
        {
            var obter = _cursoRepositorio.Obter(1);
            Assert.True(obter.Id > 0);
        }
    }
}