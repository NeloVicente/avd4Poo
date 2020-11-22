using Avd4.Aula.DataSql.Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Avd4.Aula.Tests
{
    public class InscricaoTest
    {
        InscricaoRepositorio _inscricaoRepositorio = new InscricaoRepositorio();

        [Fact]
        public void Cadastrar()
        {
            _inscricaoRepositorio.Cadastrar(new Domain.Entidades.Inscricao
            {
                IdAluno = 3,
                Status = "aguardando",
                DataInicio = DateTime.Now,
                DataConclusao = DateTime.Now.AddDays(1)
            });
            Assert.True(true);
        }

        [Fact]
        public void Atualizat()
        {
            _inscricaoRepositorio.Atualizar(new Domain.Entidades.Inscricao
            {
                Id = 5,
                IdAluno = 1,
                Status = "aguardando",
                DataInicio = DateTime.Now,
                DataConclusao = DateTime.Now.AddDays(1)
            });
            Assert.True(true);
        }

        [Fact]
        public void Excluir()
        {
            _inscricaoRepositorio.Excluir(6);
            Assert.True(true);
        }

        [Fact]
        public void Listar()
        {
            var listar = _inscricaoRepositorio.Listar();
            Assert.True(listar.Any());
        }

        [Fact]
        public void Obter()
        {
            var obter = _inscricaoRepositorio.Obter(5);
            Assert.True(obter.Id > 0);
        }
    }
}