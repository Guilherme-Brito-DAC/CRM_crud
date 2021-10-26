using CRM_Crud.Filters;
using CRM_Crud.Formatter;
using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CRM_Crud.Controllers
{
    [Authorize]
    public class InscricaoController : Controller
    {
        public IInscricaoRepository InscricaoRepository;
        public ICursoRepository CursoRepository;
        public IInscricaoFormatter InscricaoFormatter;
        public IInscricaoFiltro InscricaoFiltro;
        public ICursoFiltro CursoFiltro;

        public InscricaoController(IInscricaoRepository _InscricaoRepository, ICursoRepository _CursoRepository, IInscricaoFormatter _InscricaoFormatter, IInscricaoFiltro _InscricaoFiltro, ICursoFiltro _CursoFiltro)
        {
            InscricaoRepository = _InscricaoRepository;
            CursoRepository = _CursoRepository;
            InscricaoFormatter = _InscricaoFormatter;
            InscricaoFiltro = _InscricaoFiltro;
            CursoFiltro = _CursoFiltro;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(ListarViewInscricoes());
        }

        public IList<ViewInscricao> ListarViewInscricoes()
        {
            var inscricoes = InscricaoRepository.ListarInscricoes();
            var viewInscricoes = InscricaoFormatter.ListaDeInscricoesParaViewInscricao(inscricoes);
            return viewInscricoes;
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
                if (campo == "titulo")
                {
                    var curso = CursoRepository.ListarUmCurso(pesquisa);
                    pesquisa = curso != null ? curso.id.ToString() : "0";
                }

                var inscricoes = InscricaoRepository.Pesquisar(campo, pesquisa);
                var viewInscricoes = InscricaoFormatter.ListaDeInscricoesParaViewInscricao(inscricoes);

                return View("Index", viewInscricoes);
            }
            else
            {
                return View("Index", ListarViewInscricoes());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Inscricao Inscricao)
        {
            try
            {
                CursoFiltro.CursoPossuiVaga(Inscricao.curso_id);
                InscricaoFiltro.LeadDuplicadoEmUmCurso(Inscricao.lead_id, Inscricao.curso_id);

                Inscricao.data_de_inscricao = DateTime.Now;
                Inscricao.status = "Inscrito";
                InscricaoRepository.CriarInscricao(Inscricao);

                TempData["Confirmacao"] = "Inscrição criada com sucesso!";

                return View("Index", ListarViewInscricoes());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return View("Index", ListarViewInscricoes());
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

                return View("Index", ListarViewInscricoes());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return View("Index", ListarViewInscricoes());
            }
        }

        [HttpPost]
        public ActionResult Deletar(int id)
        {
            try
            {
                InscricaoRepository.DeletarInscricao(id);

                TempData["Confirmacao"] = "Inscrição excluida com sucesso!";

                return View("Index", ListarViewInscricoes());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return View("Index", ListarViewInscricoes());
            }
        }
    }
}
