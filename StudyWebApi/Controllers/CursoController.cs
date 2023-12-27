
using Microsoft.AspNetCore.Mvc;
using StudyWebApi.Context;
using StudyWebApi.Models;
using StudyWebApi.Repositorio;
using System.Web;

namespace StudyWebApi.Controllers
{
    public class CursoController : Controller
    {

        private readonly ICursoRepositorio _cursoRepositorio;
        public CursoController(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }


        public IActionResult Index()
        {
            var cursos = _cursoRepositorio.ListarCursosAtivos();

            return View(cursos);
        }

        public IActionResult Criar()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Criar(Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _cursoRepositorio.Adicionar(curso);
                    TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View(curso);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve alguma falha para cadastrar o curso. \nVeja o erro detalhado: {erro.Message}!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Detalhes(int id)
        {
            var curso = _cursoRepositorio.ListarPorId(id);

            if (curso == null)
            {
                return NoContent();
            }

            return View(curso);
        }

        public IActionResult Editar(int id)
        {
            var c = _cursoRepositorio.ListarPorId(id);

            if (c == null)
            {
                return NoContent();
            }

            return View(c);
        }

        [HttpPost]
        public IActionResult Editar(Curso curso)
        {
            Curso c = new Curso();

            c.ID = curso.ID;
            c.NomeCurso = curso.NomeCurso;
            c.Descricao = curso.Descricao;
            c.Preco = curso.Preco;
            c.Status = curso.Status;

            if(ModelState.IsValid)
            {
                _cursoRepositorio.Atualizar(c);
                return RedirectToAction("Index");
            }

            return View(c);
            
        }

        public IActionResult Inativos()
        {
            var cursos = _cursoRepositorio.ListarCursosInativos();
            return View(cursos);
        }

        public IActionResult Deletar(int id)
        {
            var c = _cursoRepositorio.ListarPorId(id);

            if (c == null)
            {
                return RedirectToAction("Index");
            }

            return View(c);
        }

        [HttpPost]
        public IActionResult Deletar(Curso curso)
        {
            _cursoRepositorio.Deletar(curso);

            return RedirectToAction("Index");
        }
    }
}
