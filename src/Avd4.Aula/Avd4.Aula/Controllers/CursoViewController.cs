using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avd4.Aula.Domain.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Avd4.Aula.Controllers
{
    /// <summary>
    /// Remover a view aluno da documentação do swagger
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("admin-curso")]
    public class CursoViewController : Controller
    {
        /// <summary>
        /// Defino a url base da api, para evitar subir uma versão para produção com uma url fixa localhost
        /// </summary>
        private readonly string UrlAPI;

        /// <summary>
        /// Utilizado o http context, para concatenar a url base da´API
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CursoViewController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            UrlAPI = $"{ _httpContextAccessor.HttpContext.Request.Scheme}://{ _httpContextAccessor.HttpContext.Request.Host}/api/v1";
        }

        [HttpGet, Route("listar")]
        public IActionResult Listar()
        {
            // Obter lista de alunos da api
            var client = new RestClient($"{UrlAPI}/curso/listar");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // Fazer p parse do json para uma lista
            List<Curso> retorno = JsonConvert.DeserializeObject<List<Curso>>(response.Content);

            // Enviar a lista para a view, para ser carregada na tela
            return View(retorno);
        }

        [HttpGet, Route("cadastrar")]
        public IActionResult Cadastrar()
        {
            return View(new Curso());
        }

        [HttpPost, Route("cadastrar")]
        public IActionResult Cadastrar(Curso curso)
        {
            var client = new RestClient($"{UrlAPI}/curso/cadastrar");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(curso), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            TempData["sucesso"] = response.Content;

            return View(curso);
        }

        [HttpGet, Route("atualizar/{id}")]
        public IActionResult Atualizar(int id)
        {
            // Obter lista de alunos da api
            var client = new RestClient($"{UrlAPI}/curso/obter/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            // Fazer p parse do json para uma lista
            Curso retorno = JsonConvert.DeserializeObject<Curso>(response.Content);

            // Enviar a lista para a view, para ser carregada na tela
            return View(retorno);
        }

        [HttpPost, Route("atualizar")]
        public IActionResult Atualizar(Curso curso)
        {
            var client = new RestClient($"{UrlAPI}/curso/atualizar");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(curso), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            TempData["sucesso"] = response.Content;

            return View(curso);
        }

        [HttpGet, Route("obter/{id}")]
        public IActionResult Obter(int id)
        {
            // Obter lista de alunos da api
            var client = new RestClient($"{UrlAPI}/curso/obter/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            // Fazer p parse do json para uma lista
            Curso retorno = JsonConvert.DeserializeObject<Curso>(response.Content);

            // Enviar a lista para a view, para ser carregada na tela
            return View(retorno);
        }

        [HttpGet, Route("excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            return View(new Curso { Id = id });
        }

        [HttpPost, Route("excluir/{id}")]
        public IActionResult Excluir(string id)
        {
            var client = new RestClient($"{UrlAPI}/curso/excluir/{id}");
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);

            TempData["sucesso"] = response.Content;

            return View(new Curso { Id = int.Parse(id) });
        }
    }
}
