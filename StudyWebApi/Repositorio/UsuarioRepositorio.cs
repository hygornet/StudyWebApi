using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyWebApi.Context;
using StudyWebApi.Helper;
using StudyWebApi.Models;

namespace StudyWebApi.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _usuarioContext;
        public UsuarioRepositorio(ApplicationDbContext usuarioRepositorio)
        {
            _usuarioContext = usuarioRepositorio;
        }
        public Usuario Adicionar(Usuario usuario)
        {
            _usuarioContext.Usuarios.Add(usuario);
            usuario.SetSenhaHash();
            _usuarioContext.SaveChanges();

            return usuario;
        }

        public List<Usuario> ListarUsuarios()
        {
            return _usuarioContext.Usuarios.Include(x=>x.Alunos).ToList();
        }

        public Usuario ListarPorId(int id)
        {
            return _usuarioContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public Usuario Atualizar(Usuario usuario)
        {
            var existUsuario = this.ListarPorId(usuario.Id);

            if (existUsuario == null)
            {
                throw new Exception("Houve um erro ao buscar este ID no banco de dados!");
            }

            existUsuario.Nome = usuario.Nome;
            existUsuario.Login = usuario.Login;
            existUsuario.Email = usuario.Email;
            existUsuario.Perfil = usuario.Perfil;
            existUsuario.Senha = usuario.Senha;
            existUsuario.DataAlteracao = DateTime.Now;

            _usuarioContext.Usuarios.Update(existUsuario);
            _usuarioContext.SaveChanges();

            return existUsuario;
        }

        public Usuario BuscarPorId(int id)
        {
            var usuario = _usuarioContext.Usuarios.FirstOrDefault(x => x.Id == id);

            return usuario;
        }

        public Usuario Deletar(Usuario usuario)
        {
            var user = this.ListarPorId(usuario.Id);

            if (user == null)
            {
                throw new Exception("Houve um erro ao buscar este ID no banco de dados!");
            }

            _usuarioContext.Usuarios.Remove(usuario);
            _usuarioContext.SaveChanges();

            return usuario;
        }

        public Usuario BuscarLogin(string login)
        {
            return _usuarioContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public Usuario BuscarPorLoginEmail(string login, string email)
        {
            return _usuarioContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper() && x.Email.ToUpper() == email.ToUpper());
        }

        public Usuario AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            Usuario usuario = BuscarPorId(alterarSenhaModel.Id);

            if (usuario == null) { throw new Exception("Houve um erro na atualização do usuário!"); }

            if (!usuario.SenhaValida(alterarSenhaModel.SenhaAtual)) { throw new Exception("Senha atual não confere!"); }

            if (usuario.SenhaValida(alterarSenhaModel.NovaSenha)) { throw new Exception("A nova senha deve ser diferente da senha atual!"); }

            usuario.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuario.DataAlteracao = DateTime.Now;

            _usuarioContext.Usuarios.Update(usuario);
            _usuarioContext.SaveChanges();

            return usuario;
        }

    }
}
    
