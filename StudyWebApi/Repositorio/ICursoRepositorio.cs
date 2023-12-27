using StudyWebApi.Models;

namespace StudyWebApi.Repositorio
{
    public interface ICursoRepositorio
    {
        public Curso Adicionar(Curso curso);

        public Curso Atualizar(Curso curso);

        public Curso Deletar(Curso curso);  

        public List<Curso> ListarCursosAtivos();

        public List<Curso> ListarCursosInativos();

        public Curso ListarPorId(int id);

        
    }
}
