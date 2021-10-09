using CRM_Crud.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRM_Crud.Repositories
{
    public class InscricaoRepository : BaseRepository<Inscricao>, IInscricaoRepository
    {
        public InscricaoRepository(ApplicationContext context) : base(context)
        {

        }

        public void CriarInscricao(Inscricao Inscricao)
        {
            dbSet.Add(Inscricao);
            context.SaveChanges();
        }

        public void EditarInscricao(Inscricao Inscricao)
        {
            dbSet.Update(Inscricao);
            context.SaveChanges();
        }

        public IList<Inscricao> ListarInscricoes()
        {
            return dbSet.ToList();
        }

        public Inscricao ListarUmaInscricao(int id)
        {
            return dbSet.Where(c => c.id == id).SingleOrDefault();
        }
       
        public void DeletarInscricao(int id)
        {
            dbSet.Remove(ListarUmaInscricao(id));
            context.SaveChanges();
        }

        public bool VerificaSePossuiCurso(int id)
        {
            var curso = dbSet.Where(c => c.curso_id == id).SingleOrDefault();

            if (curso != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificaSePossuiLead(int id)
        {
            var lead = dbSet.Where(c => c.lead_id == id).SingleOrDefault();
            
            if (lead != null)
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
