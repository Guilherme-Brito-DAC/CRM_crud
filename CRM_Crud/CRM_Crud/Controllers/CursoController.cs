using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CRM_Crud.Controllers
{
    public class CursoController : Controller
    {
        public ICursoRepository cursoRepository;

        public CursoController(ICursoRepository _cursoRepository)
        {
            cursoRepository = _cursoRepository;
        }

        public IList<Curso> ListarCursos()
        {
            return cursoRepository.ListarCursos();
        }

        public ActionResult Index()
        {
            return View(ListarCursos());
        }

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

                return View("Index", ListarCursos());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", ListarCursos());
            }
        }

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

                return View("Index", ListarCursos());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", ListarCursos());
            }
        }

        public ActionResult Deletar(int id)
        {
            try
            {
                cursoRepository.DeletarCurso(id);
                TempData["Confirmacao"] = "Curso deletado com sucesso!";

                return View("Index", ListarCursos());
            }
            catch (Exception e)
            {
                TempData["Erro"] = "Aconteceu um erro! ";

                return View("Index", ListarCursos());
            }
        }
    }
}
