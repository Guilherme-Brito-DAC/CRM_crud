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
        public ActionResult Criar(Curso curso)
        {
            cursoRepository.CriarCurso(curso);
            return View("Index", cursoRepository.ListarCursos());
        }

        public ActionResult Editar(int id)
        {
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, IFormCollection collection)
        {

            return View();
        }

        public ActionResult Deletar(int id)
        {
            cursoRepository.DeletarCurso(id);
            return View("Index", cursoRepository.ListarCursos());
        }
    }
}
