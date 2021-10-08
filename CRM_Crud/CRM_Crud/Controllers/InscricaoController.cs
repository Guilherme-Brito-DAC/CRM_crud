using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRM_Crud.Controllers
{
    public class InscricaoController : Controller
    {
        public IInscricaoRepository InscricaoRepository;

        public InscricaoController(IInscricaoRepository _InscricaoRepository)
        {
            InscricaoRepository = _InscricaoRepository;
        }

        public ActionResult Index()
        {
            return View(InscricaoRepository.ListarInscricoes());
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Inscricao Inscricao)
        {
            Inscricao.data_de_inscricao = DateTime.Now;
            Inscricao.status = "Inscrito";
            InscricaoRepository.CriarInscricao(Inscricao);
            return View("Index", InscricaoRepository.ListarInscricoes());
        }

        public ActionResult Editar(int id)
        {
            return View(InscricaoRepository.ListarUmaInscricao(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Inscricao Inscricao)
        {
            InscricaoRepository.EditarInscricao(Inscricao);
            return View("Index", InscricaoRepository.ListarInscricoes());
        }

        public ActionResult Deletar(int id)
        {
            InscricaoRepository.DeletarInscricao(id);
            return View("Index", InscricaoRepository.ListarInscricoes());
        }
    }
}
