using CRM_Crud.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CRM_Crud.Repositories
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

        public Curso ListarUmCurso(string titulo)
        {
            return dbSet.Where(c => c.titulo.Contains(titulo)).SingleOrDefault();
        }

        public void DeletarCurso(int id)
        {

            dbSet.Remove(ListarUmCurso(id));
            context.SaveChanges();
        }

        public IList<Curso> Pesquisar(string campo, string pesquisa)
        {

            IList<Curso> resultado = new List<Curso>();

            switch (campo)
            {
                case "titulo":
                    resultado = dbSet.Where(c => c.titulo.Contains(pesquisa)).ToList();
                    break;

                case "periodo_letivo":
                    resultado = dbSet.Where(c => c.periodo_letivo.Contains(pesquisa)).ToList();
                    break;

                case "categoria":
                    resultado = dbSet.Where(c => c.categoria.Contains(pesquisa)).ToList();
                    break;

                default:
                    resultado = ListarCursos();
                    break;
            }

            return resultado;
        }
    }
}
