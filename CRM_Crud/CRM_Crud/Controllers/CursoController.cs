using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Crud.Controllers
{
    public class CursoController : Controller
    {
        public ICursoRepository cursoRepository;

        public CursoController(ICursoRepository _cursoRepository)
        {
            cursoRepository = _cursoRepository;
        }

        public ActionResult Index()
        {
            return View(cursoRepository.ListarCursos());
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(Curso curso)
        {
            cursoRepository.CriarCurso(curso);
            return View("Index", cursoRepository.ListarCursos());
        }

        public ActionResult Editar(int id)
        {
            return View(cursoRepository.ListarUmCurso(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Curso curso)
        {
            cursoRepository.EditarCurso(curso);
            return View("Index", cursoRepository.ListarCursos());
        }

        public ActionResult Deletar(int id)
        {
            cursoRepository.DeletarCurso(id);
            return View("Index", cursoRepository.ListarCursos());
        }
    }
}
