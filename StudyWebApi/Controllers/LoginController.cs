using Microsoft.AspNetCore.Mvc;
using StudyWebApi.Helper;
using StudyWebApi.Models;
using StudyWebApi.Repositorio;

namespace StudyWebApi.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        private readonly IEmail _email;
        public LoginController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao, IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepositorio.BuscarLogin(loginModel.Login);

                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"A senha do usuário é inválida. \nPor favor, tente novamente!";
                            return RedirectToAction("Index");
                        }
                    }

                    TempData["MensagemErro"] = $"Não identificamos este usuário na nossa base. \nPor favor, tente novamente!";

                    return RedirectToAction("Index");

                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não consegui localizar no banco de dados estes dados de login. \nVeja o erro detalhado: {erro.Message}!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepositorio.BuscarPorLoginEmail(redefinirSenhaModel.Login, redefinirSenhaModel.Email);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha de acesso é: {novaSenha}";
                        bool emailEnviado = _email.Enviar(usuario.Email, "Curso WEB - Hygor System | Nova senha de acesso", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos uma nova senha para o seu e-mail cadastrado. Verifique, por favor!";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o e-mail. Por favor, tente novamente!";
                        }
                        return RedirectToAction("Index");
                    }

                    TempData["MensagemErro"] = $"Algum dos dados informados não correspondem com os dados no banco de dados. Por favor, tente novamente!";

                    return RedirectToAction("Index");

                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos redefinir sua senha. \nVeja o erro detalhado: {erro.Message}!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index");
        }
    }
}
