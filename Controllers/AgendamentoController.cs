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
    public class AgendamentoController : Controller
    {
        public IActionResult FormAgendamento()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FormAgendamento(agendamentos ag)       
        {            
            agendamentosRepository aR = new agendamentosRepository();
            aR.Cadastrar(ag);
            return View("Sucesso");
        }

        public IActionResult Listar()
        {
            agendamentosRepository aR = new agendamentosRepository();
            return View(aR.Listar());
        }

        public IActionResult Editar(int idBusca)
        {
            agendamentosRepository aR = new agendamentosRepository();
            return View(aR.buscaId(idBusca));
        }

        [HttpPost]
        public IActionResult Editar(agendamentos ag)
        {
            agendamentosRepository aR = new agendamentosRepository();
            aR.Editar(ag);
            return RedirectToAction("Listar");
        }

        public IActionResult Deletar(int idDelete)
        {
            agendamentosRepository aR = new agendamentosRepository();
            aR.Deletar(idDelete);
            return RedirectToAction("Listar");
        }

        public IActionResult Sucesso()
        {
            return View();
        }
    }
}