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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Servicos()
        {
            return View();
        }        
     

        public IActionResult Sucesso()
        {
            return View();
        }

         public IActionResult SucessoFc()
        {
            return View();
        }

         public IActionResult Espaco()
        {
            return View();
    
        }

      
         public IActionResult EsteticaF()
        {
            return View();
    
        }

         public IActionResult EsteticaC()
        {
            return View();
    
        }

         public IActionResult MaosePes()
        {
            return View();
    
        }

         public IActionResult Depilacao()
        {
            return View();
    
        }

          public IActionResult SpaDay()
        {
            return View();
    
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
