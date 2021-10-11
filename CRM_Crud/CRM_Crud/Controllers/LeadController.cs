using CRM_Crud.Filters;
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
        public IErroFiltro ErroFiltro;

        public LeadController(ILeadRepository _LeadRepository, IErroFiltro _ErroFiltro)
        {
            LeadRepository = _LeadRepository;
            ErroFiltro = _ErroFiltro;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(LeadRepository.ListarLeads());
        }

        [HttpGet]
        public IList<Lead> ListarLeads()
        {
            return LeadRepository.ListarLeads();
        }

        [HttpGet]
        public ActionResult Pesquisar(string pesquisa, string campo)
        {
            if (!string.IsNullOrEmpty(pesquisa))
            {
                return View("Index", LeadRepository.Pesquisar(campo, pesquisa));
            }
            else
            {
                return View("Index", LeadRepository.ListarLeads()); 
            }
        }

        [HttpGet]
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

                return View("Index", LeadRepository.ListarLeads());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return View("Index", LeadRepository.ListarLeads());
            }
        }

        [HttpGet]
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

                return View("Index", LeadRepository.ListarLeads());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return View("Index", LeadRepository.ListarLeads());
            }
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                ErroFiltro.VerificaSeOLeadEstaInscritoEmAlgumCurso(id);

                LeadRepository.DeletarLead(id);
                TempData["Confirmacao"] = "Lead excluido com sucesso!";

                return View("Index", LeadRepository.ListarLeads());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return View("Index", LeadRepository.ListarLeads());
            }
        }
    }
}
