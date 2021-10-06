using CRM.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Repositories
{
    public class LeadRepository : BaseRepository<Lead>, ILeadRepository
    {
        public LeadRepository(ApplicationContext context) : base(context)
        {

        }

        public void CriarLead(Lead Lead)
        {
            dbSet.Add(Lead);
            context.SaveChanges();
        }

        public void EditarLead(Lead Lead)
        {
            dbSet.Update(Lead);
            context.SaveChanges();
        }

        public IList<Lead> ListarLeads()
        {
            return dbSet.ToList();
        }

        public Lead ListarUmLead(int id)
        {
            return dbSet.Where(c => c.id == id).SingleOrDefault();
        }
       
        public void DeletarLead(int id)
        {
            dbSet.Remove(ListarUmLead(id));
            context.SaveChanges();
        }
    }
}
