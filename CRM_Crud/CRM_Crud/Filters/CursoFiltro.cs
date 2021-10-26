using CRM_Crud.Models;
using CRM_Crud.Repositories;
using System;

namespace CRM_Crud.Filters
{
    public class CursoFiltro : ICursoFiltro
    {
        public ICursoRepository CursoRepository;
        public IInscricaoRepository InscricaoRepository;

        public CursoFiltro(ICursoRepository cursoRepository, IInscricaoRepository inscricaoRepository)
        {
            CursoRepository = cursoRepository;
            InscricaoRepository = inscricaoRepository;
        }

        public void VerificaSeAlgumDadoDoCursoEstaVazio(Curso curso)
        {
            if (curso.titulo == "" || curso.periodo_letivo == "" || curso.categoria == "")
            {
                throw new Exception("O curso precisa de todos os dados preenchidos");
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
    }
}
