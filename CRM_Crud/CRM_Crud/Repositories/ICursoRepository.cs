using CRM_Crud.Models;
using System.Collections.Generic;

namespace CRM_Crud.Repositories
{
    public interface ICursoRepository
    {
        void CriarCurso(Curso curso);
        IList<Curso> ListarCursos();
        IList<Curso> Pesquisar(string campo, string pesquisa);
        Curso ListarUmCurso(int id);
        Curso ListarUmCurso(string titulo);
        void EditarCurso(Curso curso);
        void DeletarCurso(int id);
    }
}
