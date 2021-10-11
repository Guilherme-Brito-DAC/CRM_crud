using CRM_Crud.Filters;
using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CRM_Crud.Controllers
{
    public class InscricaoController : Controller
    {
        public IInscricaoRepository InscricaoRepository;
        public ICursoRepository CursoRepository;
        public IErroFiltro ErroFiltro;

        public InscricaoController(IInscricaoRepository _InscricaoRepository, ICursoRepository _CursoRepository, IErroFiltro _ErroFiltro)
        {
            InscricaoRepository = _InscricaoRepository;
            CursoRepository = _CursoRepository;
            ErroFiltro = _ErroFiltro;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(InscricaoRepository.ListarInscricoes());
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Pesquisar(string pesquisa, string campo)
        {
            if (!string.IsNullOrEmpty(pesquisa))
            {
                return View("Index", InscricaoRepository.Pesquisar(campo, pesquisa));
            }
            else
            {
                return View("Index", InscricaoRepository.ListarInscricoes());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Inscricao Inscricao)
        {
            try
            {
                ErroFiltro.CursoPossuiVaga(Inscricao.curso_id);
                ErroFiltro.LeadDuplicadoEmUmCurso(Inscricao.lead_id, Inscricao.curso_id);

                Inscricao.data_de_inscricao = DateTime.Now;
                Inscricao.status = "Inscrito";
                InscricaoRepository.CriarInscricao(Inscricao);

                TempData["Confirmacao"] = "Inscrição criada com sucesso!";

                return View("Index", InscricaoRepository.ListarInscricoes());

            }
            catch(Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

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
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

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
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return View("Index", InscricaoRepository.ListarInscricoes());
            }
        }
    }
}
