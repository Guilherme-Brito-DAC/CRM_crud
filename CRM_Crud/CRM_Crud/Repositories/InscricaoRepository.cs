using CRM_Crud.Models;
using System.Collections.Generic;
using System.Linq;

namespace CRM_Crud.Repositories
{
    public class InscricaoRepository : BaseRepository<Inscricao>, IInscricaoRepository
    {
        public InscricaoRepository(ApplicationContext context) : base(context)
        {

        }

        public void CriarInscricao(Inscricao Inscricao)
        {
            dbSet.Add(Inscricao);
            context.SaveChanges();
        }

        public void EditarInscricao(Inscricao Inscricao)
        {
            dbSet.Update(Inscricao);
            context.SaveChanges();
        }

        public IList<Inscricao> ListarInscricoes()
        {
            return dbSet.ToList();
        }

        public Inscricao ListarUmaInscricao(int id)
        {
            return dbSet.Where(c => c.id == id).SingleOrDefault();
        }

        public IList<Inscricao> ListarInscricoesEmUmCurso(int id)
        {
            return dbSet.Where(c => c.curso_id == id).ToList();
        }

        public IList<Inscricao> ListarInscricoesDeUmLead(int id)
        {
            return dbSet.Where(c => c.lead_id == id).ToList();
        }

        public void DeletarInscricao(int id)
        {
            dbSet.Remove(ListarUmaInscricao(id));
            context.SaveChanges();
        }

        public IList<Inscricao> Pesquisar(string campo, string pesquisa)
        {
            IList<Inscricao> resultado = new List<Inscricao>();

            switch (campo)
            {
                case "nome":
                    resultado = dbSet.Where(c => c.nome.Contains(pesquisa)).ToList();
                    break;

                case "status":
                    resultado = dbSet.Where(c => c.status.Contains(pesquisa)).ToList();
                    break;

                case "titulo":
                    resultado = dbSet.Where(c => c.curso_id == int.Parse(pesquisa)).ToList();
                    break;

                default:
                    resultado = ListarInscricoes();
                    break;
            }

            return resultado;
        }
    }
}
