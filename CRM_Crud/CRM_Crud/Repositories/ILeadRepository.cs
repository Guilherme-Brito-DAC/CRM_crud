using CRM_Crud.Models;
using System.Collections.Generic;

namespace CRM_Crud.Repositories
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
