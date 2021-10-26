using CRM_Crud.Models;
using CRM_Crud.Repositories;
using System;
using System.Linq;

namespace CRM_Crud.Filters
{
    public class ErroFiltro : IErroFiltro
    {
        public IInscricaoRepository InscricaoRepository;
        public ICursoRepository CursoRepository;
        public ILeadRepository LeadRepository;

        public ErroFiltro(IInscricaoRepository _InscricaoRepository, ICursoRepository _CursoRepository, ILeadRepository _LeadRepository)
        {
            InscricaoRepository = _InscricaoRepository;
            CursoRepository = _CursoRepository;
            LeadRepository = _LeadRepository;
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

        public void CursoPossuiVaga(int id)
        {
            var curso = CursoRepository.ListarUmCurso(id);
            var max_de_inscricoes = curso.qnt_de_inscricoes;

            var inscricoes = InscricaoRepository.ListarInscricoesEmUmCurso(id).Count;

            if (inscricoes >= max_de_inscricoes)
            {
                throw new Exception("O curso que está tentando se inscrever não possui espaço");
            }
        }

        public void VerificaSeAlgumDadoDoCursoEstaVazio(Curso curso)
        {
            if (curso.titulo == "" || curso.periodo_letivo == "" || curso.categoria == "")
            {
                throw new Exception("O curso precisa de todos os dados preenchidos");
            }
        }

        public void VerificaSeAlgumDadoDoLeadEstaVazio(Lead lead)
        {
            if (lead.nome == "" || lead.telefone == "" || lead.cpf == "" || lead.email == "")
            {
                throw new Exception("O lead precisa de todos os dados preenchidos");
            }
        }
    }
}
