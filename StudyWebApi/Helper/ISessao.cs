using StudyWebApi.Models;

namespace StudyWebApi.Helper
{
    public interface ISessao
    {
        public void CriarSessaoUsuario(Usuario usuario);

        public void RemoverSessaoUsuario();

        public Usuario BuscarSessaoUsuario();


    }
}
