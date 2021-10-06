using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Repositories
{
    public class CursoRepository : BaseRepository<Curso>, ICursoRepository
    {
        public CursoRepository(ApplicationContext context) : base(context)
        {

        }

        public void CriarCurso(Curso curso)
        {
            dbSet.Add(curso);
            context.SaveChanges();
        }

        public void EditarCurso(Curso curso)
        {
            dbSet.Update(curso);
            context.SaveChanges();
        }

        public IList<Curso> ListarCursos()
        {
            return dbSet.ToList();
        }

        public Curso ListarUmCurso(int id)
        {
            return dbSet.Where(c => c.id == id).SingleOrDefault();
        }
       
        public void DeletarCurso(int id)
        {
            dbSet.Remove(ListarUmCurso(id));
            context.SaveChanges();
        }
    }
}
