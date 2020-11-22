using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Avd4.Aula.Domain.Entidades;
using Avd4.Aula.DataSql.Repositorio.Repositorio;

namespace Avd4.Aula.Controllers
{
    [Route("api/v1/aluno")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        /// <summary>
        /// Instanciar o repositorio 
        /// </summary>
        private AlunoRepositorio _alunoRepositorio = new AlunoRepositorio();

        /// <summary>
        /// Salva o aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [HttpPost, Route("cadastrar")]
        public IActionResult Cadastrar(Aluno aluno)
        {
            try
            {
                aluno.ValidarCamposObrigatorios(aluno);

                _alunoRepositorio.Cadastrar(aluno);
                return Ok("Item salvo com sucesso");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        /// <summary>
        /// Atualizar dados do aluno
        /// </summary>
        /// <param name="aluno"></param>
        /// <returns></returns>
        [HttpPost, Route("atualizar")]
        public IActionResult Atualizar(Aluno aluno)
        {
            try
            {
                _alunoRepositorio.Atualizar(aluno);
                return Ok("Item atualizado com sucesso");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        /// <summary>
        /// Excluir determinado aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _alunoRepositorio.Excluir(id);
                return Ok("Item excluido com sucesso");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        /// <summary>
        /// Listar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("listar")]
        public IActionResult Listar()
        {
            List<Aluno> alunos = _alunoRepositorio.Listar();
            return Ok(alunos);
        }

        /// <summary>
        /// Obter determinado aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("obter/{id}")]
        public IActionResult Obter(int id)
        {
            Aluno aluno = _alunoRepositorio.Obter(id);
            return Ok(aluno);
        }
    }
}
