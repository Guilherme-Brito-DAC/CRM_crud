using CRM_Crud.Models;
using CRM_Crud.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [ValidateAntiForgeryToken]
    public class CursoController : Controller
    {
        public ICursoRepository cursoRepository;

        public CursoController(ICursoRepository _cursoRepository)
        {
            cursoRepository = _cursoRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Curso curso)
        {
            cursoRepository.CriarCurso(curso);
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(cursoRepository.ListarUmCurso(id));
        }

        [HttpPut]
        public IActionResult Editar(Curso curso)
        {
            cursoRepository.EditarCurso(curso);
            return View();
        }

        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            cursoRepository.DeletarCurso(id);
            return View();
        }
    }
}
