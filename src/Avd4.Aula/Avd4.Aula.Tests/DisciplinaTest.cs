using Avd4.Aula.DataSql.Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Avd4.Aula.Tests
{
    public class DisciplinaTest
    {
        DisciplinaRepositorio _disciplinaRepositorio = new DisciplinaRepositorio();

        [Fact]
        public void Cadastrar()
        {
            _disciplinaRepositorio.Cadastrar(new Domain.Entidades.Disciplina
            {
                IdCurso = 3,
                Nome = "Teste",
                Descricao = "teste",
                CargaHoraria = 10
            });
            Assert.True(true);
        }

        [Fact]
        public void Atualizar()
        {
            _disciplinaRepositorio.Atualizar(new Domain.Entidades.Disciplina
            {
                Id = 2,
                IdCurso = 3,
                Nome = "Teste",
                Descricao = "teste",
                CargaHoraria = 10
            });
            Assert.True(true);
        }

        [Fact]
        public void Excluir()
        {
            _disciplinaRepositorio.Excluir(12);
            Assert.True(true);
        }

        [Fact]
        public void Listar()
        {
            var listar = _disciplinaRepositorio.Listar();
            Assert.True(listar.Any());
        }

        [Fact]
        public void Obter()
        {
            var obter = _disciplinaRepositorio.Obter(12);
            Assert.True(obter.Id > 0);
        }
    }
}