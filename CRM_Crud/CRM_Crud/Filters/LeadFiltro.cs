using CRM_Crud.Models;
using System;

namespace CRM_Crud.Filters
{
    public class LeadFiltro : ILeadFiltro
    {
        public void VerificaSeAlgumDadoDoLeadEstaVazio(Lead lead)
        {
            if (lead.nome == "" || lead.telefone == "" || lead.cpf == "" || lead.email == "")
            {
                throw new Exception("O lead precisa de todos os dados preenchidos");
            }
        }
    }
}
