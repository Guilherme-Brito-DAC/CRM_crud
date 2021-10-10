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

        public InscricaoController(IInscricaoRepository _InscricaoRepository, ICursoRepository _CursoRepository)
        {
            InscricaoRepository = _InscricaoRepository;
            CursoRepository = _CursoRepository;
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
                if (CursoPossuiVaga(Inscricao.curso_id))
                {
                    Inscricao.data_de_inscricao = DateTime.Now;
                    Inscricao.status = "Inscrito";
                    InscricaoRepository.CriarInscricao(Inscricao);

                    TempData["Confirmacao"] = "Inscrição criada com sucesso!";

                    return View("Index", InscricaoRepository.ListarInscricoes());
                }
                else
                {
                    TempData["Erro"] = "O curso que está tentando se inscrever não possui espaço";

                    return View("Index", InscricaoRepository.ListarInscricoes());
                }
            }
            catch 
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
            catch 
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
            catch 
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", InscricaoRepository.ListarInscricoes());
            }
        }

        public bool CursoPossuiVaga(int id)
        {
            var curso = CursoRepository.ListarUmCurso(id);
            var max_de_inscricoes = curso.qnt_de_inscricoes;

            var inscricoes = InscricaoRepository.ListarInscricoesEmUmCurso(id).Count;

            if (max_de_inscricoes > inscricoes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
