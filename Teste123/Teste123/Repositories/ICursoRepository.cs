using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Repositories
{
    public interface ICursoRepository
    {
        void CriarCurso(Curso curso);
        IList<Curso> ListarCursos();
        Curso ListarUmCurso(int id);
        void EditarCurso(Curso curso);
        void DeletarCurso(int id);
    }
}
