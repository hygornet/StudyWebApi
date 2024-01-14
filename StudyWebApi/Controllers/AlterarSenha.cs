using Microsoft.AspNetCore.Mvc;
using StudyWebApi.Helper;
using StudyWebApi.Models;
using StudyWebApi.Repositorio;

namespace StudyWebApi.Controllers
{
    public class AlterarSenha : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenha(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenhaModel)
        {
            try
            {
                Usuario usuario = _sessao.BuscarSessaoUsuario();
                alterarSenhaModel.Id = usuario.Id;

                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.AlterarSenha(alterarSenhaModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenhaModel);
                }

                return View("Index", alterarSenhaModel);
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos alterar sua senha, tente novamente. Detalhes do erro: {error.Message}";
                return View("Index", alterarSenhaModel);
            }
            
        }
    }
}
