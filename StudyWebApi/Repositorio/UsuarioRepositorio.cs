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

        public Usuario ListarPorId(int id)
        {
            return _usuarioContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public Usuario Atualizar(Usuario usuario)
        {
            var existUsuario = this.ListarPorId(usuario.Id);

            if(existUsuario == null)
            {
                throw new Exception("Houve um erro ao buscar este ID no banco de dados!");
            }

            existUsuario.Nome = usuario.Nome;
            existUsuario.Login = usuario.Login;
            existUsuario.Email = usuario.Email;
            existUsuario.Perfil = usuario.Perfil;
            existUsuario.Senha = usuario.Senha;

            _usuarioContext.Usuarios.Update(existUsuario);
            _usuarioContext.SaveChanges();

            return existUsuario;
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
