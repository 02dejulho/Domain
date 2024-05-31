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
    public class FaleConoscoController : Controller
    {
        public IActionResult FormFaleconosco()        
        {
            return View();        
        }

          [HttpPost]
         public IActionResult FormFaleconosco(faleconosco fc)        
        {
            faleconoscoRepository fcR = new faleconoscoRepository();
            fcR.inserir(fc);
            return View("Sucessofc"); 
                     
        }

          public IActionResult ListarMensagem()
        {
            faleconoscoRepository fcR = new faleconoscoRepository();
            return View(fcR.ListarMensagem());
        }

        public IActionResult SucessoFc()
        {
            return View();
        }
                     
        
    }
}