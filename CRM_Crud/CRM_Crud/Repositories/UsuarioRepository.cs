using CRM_Crud.Models;
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

        public bool Login(Usuario Usuario)
        {
            var usuario = dbSet.Where(c => c.login == Usuario.login && c.senha == Usuario.senha).SingleOrDefault();

            if (usuario != null)
            {
                return true;
            }

            return false;
        }

        public Usuario ListarUmUsuario(int id)
        {
            return dbSet.Where(c => c.id == id).SingleOrDefault();
        }

        public Usuario ListarUmUsuario(string login)
        {
            return dbSet.Where(c => c.login == login).SingleOrDefault();
        }

        public void EditarUsuario(Usuario usuario)
        {
            dbSet.Update(usuario);
            context.SaveChanges();
        }

        public void DeletarUsuario(int id)
        {
            dbSet.Remove(ListarUmUsuario(id));
            context.SaveChanges();
        }
    }
}
