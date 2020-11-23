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
{  /// <summary>
   /// Remover a view aluno da documentação do swagger
   /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("admin-inscricao")]
    public class InscricaoViewController : Controller
    {
        /// <summary>
        /// Defino a url base da api, para evitar subir uma versão para produção com uma url fixa localhost
        /// </summary>InscricaoViewController
        private readonly string UrlAPI;

        /// <summary>
        /// Utilizado o http context, para concatenar a url base da´API
        /// </summary>
        private readonly IHttpContextAccessor _httpContextAccessor;
        public InscricaoViewController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            UrlAPI = $"{ _httpContextAccessor.HttpContext.Request.Scheme}://{ _httpContextAccessor.HttpContext.Request.Host}/api/v1";
        }

        [HttpGet, Route("listar")]
        public IActionResult Listar()
        {
            // Obter lista de alunos da api
            var client = new RestClient($"{UrlAPI}/inscricao/listar");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // Fazer p parse do json para uma lista
            List<Inscricao> retorno = JsonConvert.DeserializeObject<List<Inscricao>>(response.Content);

            // Enviar a lista para a view, para ser carregada na tela
            return View(retorno);
        }

        [HttpGet, Route("cadastrar/{idAluno}")]
        public IActionResult Cadastrar(int idAluno)
        {
            Inscricao inscricao = new Inscricao { IdAluno = idAluno };

            // Obter lista de cursos da api
            var client = new RestClient($"{UrlAPI}/curso/listar");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            // Fazer p parse do json para uma lista
            List<Curso> retornoCurso = JsonConvert.DeserializeObject<List<Curso>>(response.Content);
            ViewBag.Cursos = retornoCurso.ToList();

            // Obter lista de cursos da api
            client = new RestClient($"{UrlAPI}/aluno/obter/{idAluno}");
            request = new RestRequest(Method.GET);
            response = client.Execute(request);

            // Fazer p parse do json para uma lista
            Aluno aluno = JsonConvert.DeserializeObject<Aluno>(response.Content);
            inscricao.Alunos = aluno;

            return View(inscricao);
        }

        [HttpPost, Route("cadastrar")]
        public IActionResult Cadastrar(Inscricao inscricao)
        {
            var client = new RestClient($"{UrlAPI}/inscricao/cadastrar");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(inscricao), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            TempData["sucesso"] = response.Content;

            // Obter lista de cursos da api
            client = new RestClient($"{UrlAPI}/curso/listar");
            request = new RestRequest(Method.GET);
            response = client.Execute(request);

            // Fazer p parse do json para uma lista
            List<Curso> retornoCurso = JsonConvert.DeserializeObject<List<Curso>>(response.Content);
            ViewBag.Cursos = retornoCurso.ToList();

            return View(inscricao);
        }

        [HttpGet, Route("atualizar/{id}")]
        public IActionResult Atualizar(int id)
        {
            // Obter lista de alunos da api
            var client = new RestClient($"{UrlAPI}/inscricao/obter/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            // Fazer p parse do json para uma lista
            Inscricao retorno = JsonConvert.DeserializeObject<Inscricao>(response.Content);

            // Obter lista de cursos da api
            client = new RestClient($"{UrlAPI}/curso/listar");
            request = new RestRequest(Method.GET);
            response = client.Execute(request);

            // Fazer p parse do json para uma lista
            List<Curso> retornoCurso = JsonConvert.DeserializeObject<List<Curso>>(response.Content);
            ViewBag.Cursos = retornoCurso.ToList();

            // Enviar a lista para a view, para ser carregada na tela
            return View(retorno);
        }

        [HttpPost, Route("atualizar")]
        public IActionResult Atualizar(Inscricao inscricao)
        {
            var client = new RestClient($"{UrlAPI}/inscricao/atualizar");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(inscricao), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            TempData["sucesso"] = response.Content;

            // Obter lista de cursos da api
            client = new RestClient($"{UrlAPI}/curso/listar");
            request = new RestRequest(Method.GET);
            response = client.Execute(request);

            // Fazer p parse do json para uma lista
            List<Curso> retornoCurso = JsonConvert.DeserializeObject<List<Curso>>(response.Content);
            ViewBag.Cursos = retornoCurso.ToList();

            return View(inscricao);
        }

        [HttpGet, Route("obter/{id}")]
        public IActionResult Obter(int id)
        {
            // Obter lista de alunos da api
            var client = new RestClient($"{UrlAPI}/inscricao/obter/{id}");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            // Fazer p parse do json para uma lista
            Inscricao retorno = JsonConvert.DeserializeObject<Inscricao>(response.Content);

            // Obter lista de cursos da api
            client = new RestClient($"{UrlAPI}/curso/listar");
            request = new RestRequest(Method.GET);
            response = client.Execute(request);

            // Fazer p parse do json para uma lista
            List<Curso> retornoCurso = JsonConvert.DeserializeObject<List<Curso>>(response.Content);
            ViewBag.Cursos = retornoCurso.ToList();
        
            // Enviar a lista para a view, para ser carregada na tela
            return View(retorno);
        }

        [HttpGet, Route("excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            return View(new Inscricao { Id = id });
        }

        [HttpPost, Route("excluir/{id}")]
        public IActionResult Excluir(string id)
        {
            var client = new RestClient($"{UrlAPI}/inscricao/excluir/{id}");
            var request = new RestRequest(Method.POST);
            IRestResponse response = client.Execute(request);

            TempData["sucesso"] = response.Content;

            return View(new Inscricao { Id = int.Parse(id) });
        }
    }
}
