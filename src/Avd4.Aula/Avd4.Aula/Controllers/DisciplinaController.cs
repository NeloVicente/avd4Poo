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
    [Route("api/v1/disciplina")]
    [ApiController]
    public class DisciplinaController : ControllerBase
    {
        private DisciplinaRepositorio _disciplinaRepositorio = new DisciplinaRepositorio();

        [HttpPost, Route("cadastrar")]
        public IActionResult Cadastrar(Disciplina objeto)
        {
            try
            {
                _disciplinaRepositorio.Cadastrar(objeto);
                return Ok("Item salvo com sucesso");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost, Route("atualizar")]
        public IActionResult Atualizar(Disciplina objeto)
        {
            try
            {
                _disciplinaRepositorio.Atualizar(objeto);
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
                _disciplinaRepositorio.Excluir(id);
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
            List<Disciplina> retorno = _disciplinaRepositorio.Listar();
            return Ok(retorno);
        }

        [HttpGet, Route("obter/{id}")]
        public IActionResult Obter(int id)
        {
            Disciplina retorno = _disciplinaRepositorio.Obter(id);
            return Ok(retorno);
        }
    }
}
