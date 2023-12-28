using StudyWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace StudyWebApi.Repositorio
{
    public interface IUsuarioRepositorio
    {
        public Usuario Adicionar(Usuario usuario);

        public List<Usuario> ListarUsuarios();

        public Usuario BuscarLogin(string login);

        public Usuario Atualizar(Usuario usuario);

        public Usuario Deletar(Usuario usuario);
    }
}
