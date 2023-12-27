using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyWebApi.Context;
using StudyWebApi.Models;

namespace StudyWebApi.Repositorio
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly CursoContext _pessoaContext;

        public PessoaRepositorio(CursoContext pessoaContext)
        {
            _pessoaContext = pessoaContext;
        }

        public Pessoa Adicionar(Pessoa pessoa)
        {
            _pessoaContext.Pessoa.Add(pessoa);
            _pessoaContext.SaveChanges();

            return pessoa;
        }

        public List<SelectListItem> ListarCursos()
        {
            var curso = _pessoaContext.Cursos.Where(x=>x.Status == true).Select(x=> new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.NomeCurso
            }).ToList();

            return curso;
        }

        public List<Pessoa> ListarAlunos()
        {
            var pessoas = _pessoaContext.Pessoa.Include("Curso").ToList();

            return pessoas;
        }

        public Pessoa ListarPorId(int id)
        {
            return _pessoaContext.Pessoa.Include("Curso").FirstOrDefault(x => x.ID == id);
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {

            var aluno = ListarPorId(pessoa.ID);

            if (aluno == null)
            {
                throw new Exception("Houve um erro ao buscar este ID no banco de dados!");
            }

            aluno.Nome = pessoa.Nome;
            aluno.StatusCurso = pessoa.StatusCurso;
            aluno.DataIngresso = pessoa.DataIngresso;
            aluno.IDCurso = pessoa.IDCurso;

            _pessoaContext.Pessoa.Update(pessoa);
            _pessoaContext.SaveChanges();

            return pessoa;
        }

        public Pessoa Deletar(Pessoa pessoa)
        {
            var aluno = ListarPorId(pessoa.ID);

            if(aluno == null)
            {
                throw new Exception("Houve um erro ao buscar este ID no banco de dados!");
            }

            _pessoaContext.Pessoa.Remove(aluno);
            _pessoaContext.SaveChanges();

            return pessoa;
        }

        
    }
}
