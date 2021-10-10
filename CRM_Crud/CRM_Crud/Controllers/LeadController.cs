﻿using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace CRM_Crud.Controllers
{
    public class LeadController : Controller
    {
        public ILeadRepository LeadRepository;

        public LeadController(ILeadRepository _LeadRepository)
        {
            LeadRepository = _LeadRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(LeadRepository.ListarLeads());
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
            catch
            {
                TempData["Erro"] = "Aconteceu um erro! ";

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
            catch
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", LeadRepository.ListarLeads());
            }
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                LeadRepository.DeletarLead(id);
                TempData["Confirmacao"] = "Lead excluido com sucesso!";

                return View("Index", LeadRepository.ListarLeads());
            }
            catch
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", LeadRepository.ListarLeads());
            }
        }
    }
}
