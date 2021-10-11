using CRM_Crud.Models;
using CRM_Crud.Repositories;
using System.Collections.Generic;

namespace CRM_Crud.Formatter
{
    public class InscricaoFormatter : IInscricaoFormatter
    {
        public ICursoRepository cursoRepository;

        public InscricaoFormatter(ICursoRepository _cursoRepository)
        {
            cursoRepository = _cursoRepository;
        }

        public ViewInscricao InscricaoParaViewInscricao(Inscricao inscricao)
        {
            var viewInscricao = new ViewInscricao();

            viewInscricao.nome = inscricao.nome;
            viewInscricao.data_de_inscricao = inscricao.data_de_inscricao;
            viewInscricao.lead_id = inscricao.lead_id;
            viewInscricao.status = inscricao.status;

            var curso = cursoRepository.ListarUmCurso(inscricao.curso_id);
            viewInscricao.curso = curso.titulo;

            return viewInscricao;
        }

        public IList<ViewInscricao> ListaDeInscricoesParaViewInscricao(IList<Inscricao> Inscricoes)
        {
            IList<ViewInscricao> viewInscricaos = new List<ViewInscricao>();

            foreach (var inscricao in Inscricoes)
            {
                viewInscricaos.Add(InscricaoParaViewInscricao(inscricao));
            }

            return viewInscricaos;
        }
    }
}
