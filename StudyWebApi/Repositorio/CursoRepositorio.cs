using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StudyWebApi.Context;
using StudyWebApi.Models;

namespace StudyWebApi.Repositorio
{
    public class CursoRepositorio : ICursoRepositorio
    {

        private readonly CursoContext _cursoContext;

        public CursoRepositorio(CursoContext cursoContext)
        {
            _cursoContext = cursoContext;
        }
        public Curso Adicionar(Curso curso)
        {
            _cursoContext.Cursos.Add(curso);
            _cursoContext.SaveChanges();

            return curso;
        }

        public Curso ListarPorId(int id)
        {
            return _cursoContext.Cursos.FirstOrDefault(x=>x.ID == id);
            
        }

        public List<Curso> ListarCursosAtivos()
        {
            return _cursoContext.Cursos.Where(x => x.Status == true).ToList();
            
        }

        public Curso Atualizar(Curso curso)
        {
            var c = ListarPorId(curso.ID);

            if(c == null)
            {
                throw new Exception("Houve um erro ao buscar este ID no banco de dados!");
            }

            c.NomeCurso = curso.NomeCurso;
            c.Descricao = curso.Descricao;
            c.Status = curso.Status;
            c.Preco = curso.Preco;

            _cursoContext.Cursos.Update(c);
            _cursoContext.SaveChanges();

            return c;
            
        }

        public List<Curso> ListarCursosInativos()
        {
            return _cursoContext.Cursos.Where(x=>x.Status == false).ToList();
        }

        public Curso Deletar(Curso curso)
        {
            var c = _cursoContext.Cursos.Remove(curso);
            _cursoContext.SaveChanges();

            return curso;
        }
    }
}
