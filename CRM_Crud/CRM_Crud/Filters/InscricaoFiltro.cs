using CRM_Crud.Repositories;
using System;
using System.Linq;

namespace CRM_Crud.Filters
{
    public class InscricaoFiltro : IInscricaoFiltro
    {
        public IInscricaoRepository InscricaoRepository;

        public InscricaoFiltro(IInscricaoRepository inscricaoRepository)
        {
            InscricaoRepository = inscricaoRepository;
        }

        public void VerificaSeAlguemSeInscreveuNesseCurso(int curso_id)
        {
            var leads = InscricaoRepository.ListarInscricoesEmUmCurso(curso_id);

            if (leads.Count() > 0)
            {
                throw new Exception("Esse curso possuem inscrições, delete as inscrições primeiro");
            }
        }

        public void VerificaSeOLeadEstaInscritoEmAlgumCurso(int lead_id)
        {
            var leads = InscricaoRepository.ListarInscricoesDeUmLead(lead_id);

            if (leads.Count() > 0)
            {
                throw new Exception("Esse lead esta inscrito em algum curso");
            }
        }

        public void LeadDuplicadoEmUmCurso(int lead_id, int curso_id)
        {
            var inscricoes = InscricaoRepository.ListarInscricoesEmUmCurso(curso_id);
            var leadNoCurso = inscricoes.Where(l => l.lead_id == lead_id).ToList();

            if (leadNoCurso.Count() > 0)
            {
                throw new Exception("Esse lead já foi inscrito nesse curso");
            }
        }
    }
}
