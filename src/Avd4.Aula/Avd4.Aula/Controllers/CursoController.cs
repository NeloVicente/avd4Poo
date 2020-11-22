using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avd4.Aula.DataSql.Repositorio.Repositorio;
using Avd4.Aula.Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avd4.Aula.Controllers
{
    [Route("api/v1/curso")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private CursoRepositorio _cursoRepositorio = new CursoRepositorio();

        [HttpPost, Route("cadastrar")]
        public IActionResult Cadastrar(Curso curso)
        {
            try
            {
                _cursoRepositorio.Cadastrar(curso);
                return Ok("Item salvo com sucesso");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost, Route("atualizar")]
        public IActionResult Atualizar(Curso curso)
        {
            try
            {
                _cursoRepositorio.Atualizar(curso);
                return Ok("Item atualizado com sucesso");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost, Route("excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _cursoRepositorio.Excluir(id);
                return Ok("Item excluido com sucesso");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpGet, Route("listar")]
        public IActionResult Listar()
        {
            List<Curso> retorno = _cursoRepositorio.Listar();
            return Ok(retorno);
        }

        [HttpGet, Route("obter/{id}")]
        public IActionResult Obter(int id)
        {
            Curso retorno = _cursoRepositorio.Obter(id);
            return Ok(retorno);
        }
    }
}
