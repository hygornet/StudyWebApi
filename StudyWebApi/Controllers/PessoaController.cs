using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyWebApi.Models;
using StudyWebApi.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudyWebApi.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;
        public PessoaController(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }
        public IActionResult Index()
        {
            var pessoas = _pessoaRepositorio.ListarAlunos();
            return View(pessoas);
        }

        public IActionResult Criar()
        {
            ViewBag.NomeCurso2 = _pessoaRepositorio.ListarCursos().ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Criar(Pessoa pessoa)
        {

            try
            {
                ViewBag.NomeCurso2 = _pessoaRepositorio.ListarCursos().ToList();
                if (ModelState.IsValid)
                {
                    _pessoaRepositorio.Adicionar(pessoa);
                    TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Houve alguma falha para cadastrar o curso. \nVeja o erro detalhado: {ex.Message}!";
                return RedirectToAction("Index");
            }

            

            return View(pessoa);
  
        }

        public IActionResult Editar(int id)
        {

            var aluno = _pessoaRepositorio.ListarPorId(id);
            ViewBag.NomeCurso2 = _pessoaRepositorio.ListarCursos().ToList();

            if (aluno == null)
            {
                return NoContent();
            }

            return View(aluno);
        }

        [HttpPost]
        public IActionResult Editar(Pessoa pessoa)
        {

            Pessoa aluno = new Pessoa();

            try
            {
                aluno.ID = pessoa.ID;
                aluno.Nome = pessoa.Nome;
                aluno.StatusCurso = pessoa.StatusCurso;
                aluno.DataIngresso = pessoa.DataIngresso;
                aluno.IDCurso = pessoa.IDCurso;

                if (ModelState.IsValid)
                {
                    _pessoaRepositorio.Atualizar(pessoa);
                    TempData["MensagemSucesso"] = "Registro alterado com sucesso!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Houve alguma falha para cadastrar o curso. \nVeja o erro detalhado: {erro.Message}!";
                return RedirectToAction("Index");
            }

            return View(pessoa);
            
        }

        public IActionResult Deletar(int id)
        {
            var aluno = _pessoaRepositorio.ListarPorId(id);
            return View(aluno);
        }

        [HttpPost]
        public IActionResult Deletar(Pessoa pessoa)
        {

            try
            {
                _pessoaRepositorio.Deletar(pessoa);
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
            var aluno = _pessoaRepositorio.ListarPorId(id);
            return View(aluno);
        }

        
    }
}
