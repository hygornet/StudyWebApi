using StudyWebApi.Context;
using StudyWebApi.Models;

namespace StudyWebApi.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly CursoContext _usuarioContext;
        public UsuarioRepositorio(CursoContext usuarioRepositorio)
        {
            _usuarioContext = usuarioRepositorio;
        }
        public Usuario Adicionar(Usuario usuario)
        {
            _usuarioContext.Usuarios.Add(usuario);
            _usuarioContext.SaveChanges();

            return usuario;
        }

        public List<Usuario> ListarUsuarios()
        {
            return _usuarioContext.Usuarios.ToList();
        }

        public Usuario Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Deletar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario BuscarLogin(string login)
        {
            return _usuarioContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }
    }
}
