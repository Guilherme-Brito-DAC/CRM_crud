using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CRM_Crud.Controllers
{
    [AllowAnonymous]
    public class UsuarioController : Controller
    {
        public IUsuarioRepository usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            if (usuarioRepository.Login(usuario))
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("username", usuario.login));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.login));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("index", "lead");
            }

            TempData["Erro"] = "Usuario ou senha incorretos!";
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(Usuario usuario)
        {
            try
            {
                var user = usuarioRepository.ListarUmUsuario(usuario.login);

                if (user == null)
                {
                    usuarioRepository.CriarUsuario(usuario);
                    TempData["Confirmacao"] = "Usuário cadastrado com sucesso!";

                    return View("Login");
                }

                throw new Exception("Já existe um usuário com este login!");
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Algum erro aconteceu! " + e.Message;
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            TempData["Confirmacao"] = "Tchau! Nós sentiremos sua falta";

            return Redirect("login");
        }
    }
}
