using CRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Repositories
{
    public interface ILeadRepository
    {
        void CriarLead(Lead Lead);
        IList<Lead> ListarLeads();
        Lead ListarUmLead(int id);
        void EditarLead(Lead Lead);
        void DeletarLead(int id);
    }
}
