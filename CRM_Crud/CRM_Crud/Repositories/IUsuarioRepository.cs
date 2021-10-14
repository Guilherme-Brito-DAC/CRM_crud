using CRM_Crud.Models;
using System.Collections.Generic;

namespace CRM_Crud.Repositories
{
    public interface IUsuarioRepository
    {
        void CriarUsuario(Usuario Usuario);
        Usuario ListarUmUsuario(int id);
        Usuario ListarUmUsuario(string login);
        bool Login(Usuario Usuario);
        void DeletarUsuario(int id);
        void EditarUsuario(Usuario usuario);
    }
}