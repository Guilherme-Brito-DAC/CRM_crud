using CRM_Crud.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRM_Crud.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationContext context) : base(context)
        {

        }

        public void CriarUsuario(Usuario Usuario)
        {
            dbSet.Add(Usuario);
            context.SaveChanges();
        }

        public void EditarUsuario(Usuario Usuario)
        {
            dbSet.Update(Usuario);
            context.SaveChanges();
        }

        public bool Login(Usuario Usuario)
        {
            var usuario = dbSet.Where(c => c.login == Usuario.login && c.senha == Usuario.senha).SingleOrDefault();

            if (usuario != null)
            {
                return true;
            }

            return false;
        }

        public IList<Usuario> ListarUsuarios()
        {
            return dbSet.ToList();
        }

        public Usuario ListarUmUsuario(int id)
        {
            return dbSet.Where(c => c.id == id).SingleOrDefault();
        }

        public void DeletarUsuario(int id)
        {
            dbSet.Remove(ListarUmUsuario(id));
            context.SaveChanges();
        }
    }
}
