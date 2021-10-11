using CRM_Crud.Models;
using System.Collections.Generic;

namespace CRM_Crud.Formatter
{
    public interface IInscricaoFormatter
    {
        ViewInscricao InscricaoParaViewInscricao(Inscricao inscricao);
        IList<ViewInscricao> ListaDeInscricoesParaViewInscricao(IList<Inscricao> Inscricoes);
    }
}