using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [ValidateAntiForgeryToken]
    public class LeadController : Controller
    {
        public ILeadRepository LeadRepository;

        public LeadController(ILeadRepository _LeadRepository)
        {
            LeadRepository = _LeadRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Lead Lead)
        {
            LeadRepository.CriarLead(Lead);
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(LeadRepository.ListarUmLead(id));
        }

        [HttpPut]
        public IActionResult Editar(Lead Lead)
        {
            LeadRepository.EditarLead(Lead);
            return View();
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            LeadRepository.DeletarLead(id);
            return View();
        }
    }
}
