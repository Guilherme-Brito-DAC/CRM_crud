﻿namespace CRM_Crud.Filters
{
    public interface IErroFiltro
    {
        void VerificaSeAlguemSeInscreveuNesseCurso(int curso_id);
        void VerificaSeOLeadEstaInscritoEmAlgumCurso(int lead_id);
        void LeadDuplicadoEmUmCurso(int lead_id, int curso_id);
        void CursoPossuiVaga(int id);
    }
}
