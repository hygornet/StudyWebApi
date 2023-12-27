using Microsoft.AspNetCore.Mvc.Rendering;
using StudyWebApi.Context;
using StudyWebApi.Models;

namespace StudyWebApi.Repositorio
{
    public interface IPessoaRepositorio
    {
        public List<Pessoa> ListarAlunos();

        public List<SelectListItem> ListarCursos();

        public Pessoa Adicionar(Pessoa pessoa);

        public Pessoa ListarPorId(int id);

        public Pessoa Atualizar(Pessoa pessoa);

        public Pessoa Deletar(Pessoa pessoa);

        
        
    }
}
