using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyWebApi.Context;
using StudyWebApi.Models;

namespace StudyWebApi.Repositorio
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly ApplicationDbContext _alunoContext;

        public AlunoRepositorio(ApplicationDbContext alunoContext)
        {
            _alunoContext = alunoContext;
        }

        public Aluno Adicionar(Aluno aluno)
        {
            _alunoContext.Alunos.Add(aluno);
            _alunoContext.SaveChanges();

            return aluno;
        }

        public List<SelectListItem> ListarCursos()
        {
            var curso = _alunoContext.Cursos.Where(x=>x.Status == true).Select(x=> new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.NomeCurso
            }).ToList();

            return curso;
        }

        public List<Aluno> ListarAlunos()
        {
            var alunos = _alunoContext.Alunos.Include("Curso").ToList();

            return alunos;
        }

        public Aluno ListarPorId(int id)
        {
            return _alunoContext.Alunos.Include("Curso").FirstOrDefault(x => x.ID == id);
        }

        public Aluno Atualizar(Aluno aluno)
        {

            var itemAluno = ListarPorId(aluno.ID);

            if (aluno == null)
            {
                throw new Exception("Houve um erro ao buscar este ID no banco de dados!");
            }

            itemAluno.Nome = aluno.Nome;
            itemAluno.StatusCurso = aluno.StatusCurso;
            itemAluno.DataIngresso = aluno.DataIngresso;
            itemAluno.IDCurso = aluno.IDCurso;

            _alunoContext.Alunos.Update(aluno);
            _alunoContext.SaveChanges();

            return itemAluno;
        }

        public Aluno Deletar(Aluno aluno)
        {
            var itemAluno = ListarPorId(aluno.ID);

            if(itemAluno == null)
            {
                throw new Exception("Houve um erro ao buscar este ID no banco de dados!");
            }

            _alunoContext.Alunos.Remove(aluno);
            _alunoContext.SaveChanges();

            return aluno;
        }

        
    }
}
