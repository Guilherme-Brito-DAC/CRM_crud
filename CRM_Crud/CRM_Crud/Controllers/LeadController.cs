using CRM_Crud.Filters;
using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CRM_Crud.Controllers
{
    [Authorize]
    public class LeadController : Controller
    {
        public ILeadRepository LeadRepository;
        public ILeadFiltro LeadFiltro;
        public IInscricaoFiltro InscricaoFiltro;

        public LeadController(ILeadRepository _LeadRepository, ILeadFiltro _LeadFiltro, IInscricaoFiltro _InscricaoFiltro)
        {
            LeadRepository = _LeadRepository;
            LeadFiltro = _LeadFiltro;
            InscricaoFiltro = _InscricaoFiltro;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return Ok(View(LeadRepository.ListarLeads()));
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
                return Ok(View("Index", LeadRepository.Pesquisar(campo, pesquisa)));
            }
            else
            {
                return BadRequest(View("Index", LeadRepository.ListarLeads())); 
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
                LeadFiltro.VerificaSeAlgumDadoDoLeadEstaVazio(Lead);

                LeadRepository.CriarLead(Lead);
                TempData["Confirmacao"] = "Lead criado com sucesso!";

                return Ok(View("Index", LeadRepository.ListarLeads()));
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;
                
                return BadRequest(View("Index", LeadRepository.ListarLeads()));
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
                LeadFiltro.VerificaSeAlgumDadoDoLeadEstaVazio(Lead);

                LeadRepository.EditarLead(Lead);
                TempData["Confirmacao"] = "Lead editado com sucesso!";

                return Ok(View("Index", LeadRepository.ListarLeads()));
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return BadRequest(View("Index", LeadRepository.ListarLeads()));
            }
        }

        [HttpPost]
        public ActionResult Deletar(int id)
        {
            try
            {
                InscricaoFiltro.VerificaSeOLeadEstaInscritoEmAlgumCurso(id);

                LeadRepository.DeletarLead(id);
                TempData["Confirmacao"] = "Lead excluido com sucesso!";

                return Ok(View("Index", LeadRepository.ListarLeads()));
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return BadRequest(View("Index", LeadRepository.ListarLeads()));
            }
        }
    }
}
