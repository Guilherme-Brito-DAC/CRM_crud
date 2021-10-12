using CRM_Crud.Models;
using System.Collections.Generic;

namespace CRM_Crud.Repositories
{
    public interface IUsuarioRepository
    {
        void CriarUsuario(Usuario Usuario);
        void DeletarUsuario(int id);
        void EditarUsuario(Usuario Usuario);
        Usuario ListarUmUsuario(int id);
        IList<Usuario> ListarUsuarios();
        bool Login(Usuario Usuario);
    }
}