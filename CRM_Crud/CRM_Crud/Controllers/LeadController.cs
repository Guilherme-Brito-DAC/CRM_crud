using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CRM_Crud.Controllers
{
    public class LeadController : Controller
    {
        public ILeadRepository LeadRepository;

        public LeadController(ILeadRepository _LeadRepository)
        {
            LeadRepository = _LeadRepository;
        }

        public IList<Lead> ListarLeads()
        {
            return LeadRepository.ListarLeads();
        }

        public ActionResult Index()
        {
            return View(ListarLeads());
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Lead Lead)
        {
            try
            {
                LeadRepository.CriarLead(Lead);
                TempData["Confirmacao"] = "Lead criado com sucesso!";

                return View("Index", ListarLeads());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", ListarLeads());
            }
        }

        public ActionResult Editar(int id)
        {
            return View(LeadRepository.ListarUmLead(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Lead Lead)
        {
            try
            {
                LeadRepository.EditarLead(Lead);
                TempData["Confirmacao"] = "Lead editado com sucesso!";

                return View("Index", ListarLeads());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", ListarLeads());
            }
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                LeadRepository.DeletarLead(id);
                TempData["Confirmacao"] = "Lead excluido com sucesso!";

                return View("Index", ListarLeads());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", ListarLeads());
            }
        }
    }
}
