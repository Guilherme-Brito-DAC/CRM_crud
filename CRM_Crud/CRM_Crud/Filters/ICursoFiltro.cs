using CRM_Crud.Models;

namespace CRM_Crud.Filters
{
    public interface ICursoFiltro
    {
        void CursoPossuiVaga(int id);
        void VerificaSeAlgumDadoDoCursoEstaVazio(Curso curso);
    }
}