namespace CRM_Crud.Filters
{
    public interface IInscricaoFiltro
    {
        void LeadDuplicadoEmUmCurso(int lead_id, int curso_id);
        void VerificaSeAlguemSeInscreveuNesseCurso(int curso_id);
        void VerificaSeOLeadEstaInscritoEmAlgumCurso(int lead_id);
    }
}