using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    [Route("admin-aluno")]
    public class AlunoViewController : Controller
    {
        /// <summary>
        /// Defino a url base da api, para evitar subir uma versão para produção com uma url fixa localhost
        /// </summary>
        private readonly string UrlAPI;

        /// <summary>
        /// Utilizado o http context, para concatenar a url base da´API
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AlunoViewController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            UrlAPI = $"{ _httpContextAccessor.HttpContext.Request.Scheme}://{ _httpContextAccessor.HttpContext.Request.Host}/api/v1";
        }

        [HttpGet, Route("listar")]
        public IActionResult Listar()
        {
            // Obter lista de alunos da api
            var client = new RestClient($"{UrlAPI}/aluno/listar");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // Fazer p parse do json para uma lista
            List<Aluno> retorno = JsonConvert.DeserializeObject<List<Aluno>>(response.Content);

            // Enviar a lista para a view, para ser carregada na tela
            return View(retorno);
        }

        [HttpGet, Route("cadastrar")]
        public IActionResult Cadastrar()
        {
            return View(new Aluno());
        }

        [HttpPost, Route("cadastrar")]
        public IActionResult Cadastrar(Aluno aluno)
        {
            var client = new RestClient($"{UrlAPI}/aluno/cadastrar");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(aluno), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            TempData["sucesso"] = response.Content;

            return View(aluno);
        }

        [HttpGet, Route("atualizar/{id}")]
        public IActionResult Atualizar(int id)
        {
            // Obter lista de alunos da api
            var client = new RestClient($"{UrlAPI}/aluno/obter/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            // Fazer p parse do json para uma lista
            Aluno retorno = JsonConvert.DeserializeObject<Aluno>(response.Content);

            // Enviar a lista para a view, para ser carregada na tela
            return View(retorno);
        }

        [HttpPost, Route("atualizar")]
        public IActionResult Atualizar(Aluno aluno)
        {
            var client = new RestClient($"{UrlAPI}/aluno/atualizar");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(aluno), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            TempData["sucesso"] = response.Content;

            return View(aluno);
        }

        [HttpGet, Route("matricula/{id}")]
        public IActionResult Matricula(int id)
        {
            // Obter lista de alunos da api
            var client = new RestClient($"{UrlAPI}/aluno/obter/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            // Fazer p parse do json para uma lista
            Aluno retorno = JsonConvert.DeserializeObject<Aluno>(response.Content);

            // Enviar a lista para a view, para ser carregada na tela
            return View(retorno);
        }

        [HttpPost, Route("matricula")]
        public IActionResult Matricula(Aluno aluno)
        {
            var client = new RestClient($"{UrlAPI}/aluno/atualizar");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(aluno), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            TempData["sucesso"] = response.Content;

            return View(aluno);
        }

        [HttpGet, Route("obter/{id}")]
        public IActionResult Obter(int id)
        {
            // Obter lista de alunos da api
            var client = new RestClient($"{UrlAPI}/aluno/obter/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            // Fazer p parse do json para uma lista
            Aluno retorno = JsonConvert.DeserializeObject<Aluno>(response.Content);

            // Enviar a lista para a view, para ser carregada na tela
            return View(retorno);
        }

        [HttpGet, Route("excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            return View(new Aluno { Id = id });
        }

        [HttpPost, Route("excluir/{id}")]
        public IActionResult Excluir(string id)
        {
            var client = new RestClient($"{UrlAPI}/aluno/excluir/{id}");
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);

            TempData["sucesso"] = response.Content;

            return View(new Aluno { Id = int.Parse(id) });
        }
    }
}
