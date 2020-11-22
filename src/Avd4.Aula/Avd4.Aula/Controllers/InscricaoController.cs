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
    [Route("api/v1/inscricao")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private InscricaoRepositorio _inscricaoRepositorio = new InscricaoRepositorio();

        [HttpPost, Route("cadastrar")]
        public IActionResult Cadastrar(Inscricao objeto)
        {
            try
            {
                objeto.ValidarDataInicioEConclusao(objeto);

                _inscricaoRepositorio.Cadastrar(objeto);
                return Ok("Item salvo com sucesso");
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        [HttpPost, Route("atualizar")]
        public IActionResult Atualizar(Inscricao objeto)
        {
            try
            {
                objeto.ValidarDataInicioEConclusao(objeto);

                _inscricaoRepositorio.Atualizar(objeto);
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
                _inscricaoRepositorio.Excluir(id);
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
            List<Inscricao> retorno = _inscricaoRepositorio.Listar();
            return Ok(retorno);
        }

        [HttpGet, Route("obter/{id}")]
        public IActionResult Obter(int id)
        {
            Inscricao retorno = _inscricaoRepositorio.Obter(id);
            return Ok(retorno);
        }
    }
}
