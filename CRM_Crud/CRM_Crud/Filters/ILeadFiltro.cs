using CRM_Crud.Models;

namespace CRM_Crud.Filters
{
    public interface ILeadFiltro
    {
        void VerificaSeAlgumDadoDoLeadEstaVazio(Lead lead);
    }
}