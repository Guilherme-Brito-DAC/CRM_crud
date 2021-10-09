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
            try
            {
                Inscricao.data_de_inscricao = DateTime.Now;
                Inscricao.status = "Inscrito";
                InscricaoRepository.CriarInscricao(Inscricao);

                TempData["Confirmacao"] = "Inscrição criada com sucesso!";

                return View("Index", InscricaoRepository.ListarInscricoes());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", InscricaoRepository.ListarInscricoes());
            }
        }

        public ActionResult Editar(int id)
        {
            return View(InscricaoRepository.ListarUmaInscricao(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Inscricao Inscricao)
        {
            try
            {
                InscricaoRepository.EditarInscricao(Inscricao);

                TempData["Confirmacao"] = "Inscrição editada com sucesso!";

                return View("Index", InscricaoRepository.ListarInscricoes());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", InscricaoRepository.ListarInscricoes());
            }
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                InscricaoRepository.DeletarInscricao(id);
                TempData["Confirmacao"] = "Inscrição excluida com sucesso!";

                return View("Index", InscricaoRepository.ListarInscricoes());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", InscricaoRepository.ListarInscricoes());
            }
        }
    }
}
