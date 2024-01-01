using Microsoft.AspNetCore.Mvc.Rendering;
using StudyWebApi.Context;
using StudyWebApi.Models;

namespace StudyWebApi.Repositorio
{
    public interface IAlunoRepositorio
    {
        public List<Aluno> ListarAlunos();

        public List<SelectListItem> ListarCursos();

        public Aluno Adicionar(Aluno aluno);

        public Aluno ListarPorId(int id);

        public Aluno Atualizar(Aluno aluno);

        public Aluno Deletar(Aluno aluno);

        
        
    }
}
