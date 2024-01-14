using StudyWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace StudyWebApi.Repositorio
{
    public interface IUsuarioRepositorio
    {
        public Usuario Adicionar(Usuario usuario);

        public List<Usuario> ListarUsuarios();

        public Usuario BuscarPorId(int id);

        public Usuario ListarPorId(int id);

        public Usuario BuscarLogin(string login);

        public Usuario BuscarPorLoginEmail(string login, string email);

        public Usuario Atualizar(Usuario usuario);

        public Usuario Deletar(Usuario usuario);

        public Usuario AlterarSenha(AlterarSenhaModel alterarSenhaModel);
    }
}
