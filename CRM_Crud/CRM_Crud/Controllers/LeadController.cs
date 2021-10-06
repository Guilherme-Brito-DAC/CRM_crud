using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Crud.Controllers
{
    public class LeadController : Controller
    {
        public ILeadRepository LeadRepository;

        public LeadController(ILeadRepository _LeadRepository)
        {
            LeadRepository = _LeadRepository;
        }

        public ActionResult Index()
        {
            return View(LeadRepository.ListarLeads());
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Lead Lead)
        {
            LeadRepository.CriarLead(Lead);
            return View("Index", LeadRepository.ListarLeads());
        }

        public ActionResult Editar(int id)
        {
            return View(LeadRepository.ListarUmLead(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Lead Lead)
        {
            LeadRepository.EditarLead(Lead);
            return View("Index", LeadRepository.ListarLeads());
        }

        public ActionResult Deletar(int id)
        {
            LeadRepository.DeletarLead(id);
            return View("Index", LeadRepository.ListarLeads());
        }
    }
}
