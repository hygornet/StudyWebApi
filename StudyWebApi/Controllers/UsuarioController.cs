﻿using Microsoft.AspNetCore.Mvc;
using StudyWebApi.Models;
using StudyWebApi.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudyWebApi.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            var usuarios = _usuarioRepositorio.ListarUsuarios();
            return View(usuarios);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var usuario = _usuarioRepositorio.BuscarLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"A senha do usuário é inválida. \nPor favor, tente novamente!";
                            return RedirectToAction("Login");
                        }
                    }

                    TempData["MensagemErro"] = $"Não identificamos este usuário na nossa base. \nPor favor, tente novamente!";

                    return RedirectToAction("Login");

                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não consegui localizar no banco de dados estes dados de login. \nVeja o erro detalhado: {erro.Message}!";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] =  $"Houve alguma falha para cadastrar o curso. \nVeja o erro detalhado: {erro.Message}!";
                return RedirectToAction("Index");
            }

            return View(usuario);
            
        }

        public IActionResult Editar()
        {
            return View();
        }
    }
}