using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CRM_Crud.Controllers
{
    public class CursoController : Controller
    {
        public ICursoRepository cursoRepository;

        public CursoController(ICursoRepository _cursoRepository)
        {
            cursoRepository = _cursoRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(cursoRepository.ListarCursos());
        }

        [HttpGet]
        public IList<Curso> ListarCursos()
        {
            return cursoRepository.ListarCursos();
        }

        [HttpGet]
        public ActionResult Pesquisar(string pesquisa, string campo)
        {
            if (!string.IsNullOrEmpty(pesquisa))
            {
                return View("Index", cursoRepository.Pesquisar(campo, pesquisa));
            }
            else
            {
                return View("Index", cursoRepository.ListarCursos());
            }
        }

        [HttpGet]
        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Curso curso)
        {
            try
            {
                cursoRepository.CriarCurso(curso);
                TempData["Confirmacao"] = "Curso criado com sucesso!";

                return View("Index", cursoRepository.ListarCursos());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return View("Index", cursoRepository.ListarCursos());
            }
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            return View(cursoRepository.ListarUmCurso(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Curso curso)
        {
            try
            {
                cursoRepository.EditarCurso(curso);
                TempData["Confirmacao"] = "Curso editado com sucesso!";

                return View("Index", cursoRepository.ListarCursos());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return View("Index", cursoRepository.ListarCursos());
            }
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                cursoRepository.DeletarCurso(id);
                TempData["Confirmacao"] = "Curso deletado com sucesso!";

                return View("Index", cursoRepository.ListarCursos());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! " + e.Message;

                return View("Index", cursoRepository.ListarCursos());
            }
        }
    }
}
