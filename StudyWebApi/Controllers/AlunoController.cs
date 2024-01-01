using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyWebApi.Models;
using StudyWebApi.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudyWebApi.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepositorio _alunoRepositorio;
        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }
        public IActionResult Index()
        {
            var pessoas = _alunoRepositorio.ListarAlunos();
            return View(pessoas);
        }

        public IActionResult Criar()
        {
            ViewBag.NomeCurso2 = _alunoRepositorio.ListarCursos().ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Criar(Aluno aluno)
        {

            try
            {
                ViewBag.NomeCurso2 = _alunoRepositorio.ListarCursos().ToList();
                if (ModelState.IsValid)
                {
                    _alunoRepositorio.Adicionar(aluno);
                    TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Houve alguma falha para cadastrar o curso. \nVeja o erro detalhado: {ex.Message}!";
                return RedirectToAction("Index");
            }

            

            return View(aluno);
  
        }

        public IActionResult Editar(int id)
        {

            var aluno = _alunoRepositorio.ListarPorId(id);
            ViewBag.NomeCurso2 = _alunoRepositorio.ListarCursos().ToList();

            if (aluno == null)
            {
                return NoContent();
            }

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Editar(Aluno aluno)
        {

            Aluno newAluno = new Aluno();

            try
            {
                newAluno.ID = aluno.ID;
                newAluno.Nome = aluno.Nome;
                newAluno.StatusCurso = aluno.StatusCurso;
                newAluno.DataIngresso = aluno.DataIngresso;
                newAluno.IDCurso = aluno.IDCurso;

                if (ModelState.IsValid)
                {
                    _alunoRepositorio.Atualizar(aluno);
                    TempData["MensagemSucesso"] = "Registro alterado com sucesso!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve alguma falha para cadastrar o curso. \nVeja o erro detalhado: {erro.Message}!";
                return RedirectToAction("Index");
            }

            return View(aluno);
            
        }

        public IActionResult Deletar(int id)
        {
            var aluno = _alunoRepositorio.ListarPorId(id);
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Deletar(Aluno aluno)
        {

            try
            {
                _alunoRepositorio.Deletar(aluno);
                TempData["MensagemSucesso"] = $"Registro deletado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve alguma falha para cadastrar o curso. \nVeja o erro detalhado: {erro.Message}!";
                return RedirectToAction("Index");
            }

        }

        public IActionResult Detalhes(int id)
        {
            var aluno = _alunoRepositorio.ListarPorId(id);
            return View(aluno);
        }

        
    }
}
