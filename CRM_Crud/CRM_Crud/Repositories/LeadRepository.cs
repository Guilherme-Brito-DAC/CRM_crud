using CRM_Crud.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRM_Crud.Repositories
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

        public IList<Lead> Pesquisar(string campo,string pesquisa)
        {
            IList<Lead> resultado = new List<Lead>();

            switch (campo)
            {
                case "nome":
                    resultado = dbSet.Where(c => c.nome.Contains(pesquisa)).ToList();
                    break;

                case "email":
                    resultado = dbSet.Where(c => c.email.Contains(pesquisa)).ToList();
                    break;

                case "telefone":
                    resultado = dbSet.Where(c => c.telefone.Contains(pesquisa)).ToList();
                    break;

                case "cpf":
                    resultado = dbSet.Where(c => c.cpf.Contains(pesquisa)).ToList();
                    break;

                default:
                    resultado = ListarLeads();
                    break;
            }

            return resultado;
        }
    }
}
