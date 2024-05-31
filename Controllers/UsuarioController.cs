using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PI_lucianasilva_Atv4.Models;
using MySqlConnector;
using Microsoft.AspNetCore.Http;

namespace PI_lucianasilva_Atv4.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult CadastroUsuario()        
        {
            return View();        
        }

          [HttpPost]
         public IActionResult CadastroUsuario(usuario user)        
        {
            usuarioRepository uR = new usuarioRepository();
            uR.inserir(user);
            return RedirectToAction("Login"); 
                     
        }


         public IActionResult Login()        
        {
            return View();        
        }

        [HttpPost]
        public IActionResult Login(usuario user)        
        {
            usuarioRepository uR = new usuarioRepository();

            usuario usuarioLogado = uR.validarLogin(user);


            if(usuarioLogado == null)
            {
                ViewBag.Mensagem = "Login ou Senha Incorretos";
                return View();
            } 
            else
            {  
                HttpContext.Session.SetInt32("idUsuario", usuarioLogado.idUser);
                HttpContext.Session.SetString("nomeUsuario", usuarioLogado.nome);
                return RedirectToAction("Listar", "Agendamento");  

            }       
        }



        public IActionResult Logout()        
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");    
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}